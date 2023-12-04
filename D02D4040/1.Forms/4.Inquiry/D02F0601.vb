Imports System
Imports System.IO
Public Class D02F0601

    Private _savedOK As Boolean
    Public ReadOnly Property SavedOK() As Boolean
        Get
            Return _savedOK
        End Get
    End Property

    Private sPathImage As String = ""
#Region "Variables of IGE"
    Private _S1 As String = ""
    Private _S2 As String = ""
    Private _S3 As String = ""
    Private _OutputOrder As String = ""
    Private _OutputLength As Integer = 0
    Private _AssetSeperated As Boolean = False
    Private _Seperator As String = ""
    Private _TableName As String = "D02T0001"
#End Region

#Region "Const of tdbgDetail"
    Private Const COL_OrderNum As Integer = 0          ' STT
    Private Const COL_EquipmentID As Integer = 1       ' Mã thiết bị đính kèm
    Private Const COL_EquipmentName As Integer = 2     ' Tên thiết bị đính kèm
    Private Const COL_EquipmentQuantity As Integer = 3 ' Số lượng
    Private Const COL_EquipmentValue As Integer = 4    ' Giá trị
    Private Const COL_ObjectTypeID As Integer = 5      ' Loại phòng ban
    Private Const COL_ObjectID As Integer = 6          ' Mã phòng ban
    Private Const COL_Notes As Integer = 7             ' Ghi chú
#End Region

#Region "Property"
    Private mAssetID As String = ""
    Public WriteOnly Property AssetID() As String
        Set(ByVal value As String)
            mAssetID = value
        End Set
    End Property

    Private mAssetID_D02F0601 As String = ""
    Public ReadOnly Property AssetID_D02F0601() As String
        Get
            Return mAssetID_D02F0601
        End Get
    End Property
#End Region
    Private dtObjectID As DataTable
    Private dtSupplierID As DataTable

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    Reload()
                    LoadAddNew()
                    Dim sSQL As String = SQLGetInfoAddNew()
                    Dim dt As DataTable = ReturnDataTable(sSQL)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("AssetAuto").ToString() = "False" Then
                            tdbcAssetS1ID.Enabled = False
                            tdbcAssetS2ID.Enabled = False
                            tdbcAssetS3ID.Enabled = False
                            btnSetNewKey.Enabled = False
                        Else
                            txtAssetID.Enabled = False
                            _OutputOrder = dt.Rows(0)("AssetOutputOrder").ToString()
                            _OutputLength = Convert.ToInt16(dt.Rows(0)("AssetOutputLength"))
                            _AssetSeperated = Convert.ToBoolean(dt.Rows(0)("AssetSeperated"))
                            _Seperator = dt.Rows(0)("AssetSeperator").ToString()
                            If dt.Rows(0)("AssetS1Enabled").ToString() = "True" Then
                                tdbcAssetS1ID.Enabled = True
                                tdbcAssetS1ID.Text = dt.Rows(0)("AssetS1Default").ToString()
                            Else
                                tdbcAssetS1ID.Enabled = False
                            End If
                            If dt.Rows(0)("AssetS2Enabled").ToString() = "True" Then
                                tdbcAssetS2ID.Enabled = True
                                tdbcAssetS2ID.Text = dt.Rows(0)("AssetS2Default").ToString()
                            Else
                                tdbcAssetS2ID.Enabled = False
                            End If
                            If dt.Rows(0)("AssetS3Enabled").ToString() = "True" Then
                                tdbcAssetS3ID.Enabled = True
                                tdbcAssetS3ID.Text = dt.Rows(0)("AssetS3Default").ToString()
                            Else
                                tdbcAssetS3ID.Enabled = False
                            End If
                        End If
                    End If
                Case EnumFormState.FormEdit
                    Reload()
                    LoadEdit()
                    LoadEdit_Data()
                Case EnumFormState.FormView
                    Reload()
                    LoadEdit_Data()
                    btnSave.Enabled = False
                    btnNext.Enabled = False
                    tdbcAssetS1ID.Enabled = False
                    tdbcAssetS2ID.Enabled = False
                    tdbcAssetS3ID.Enabled = False
                    txtAssetID.Enabled = False
                    btnSetNewKey.Enabled = False
                    grp03.Enabled = False
            End Select
        End Set
    End Property

    Private Sub LoadAddNew()
        c1datePurchaseDate.Value = Date.Today
        c1datePeriod.Value = giTranMonth.ToString() & "/" & giTranYear.ToString()
        c1dateDepPeriod.Value = giTranMonth.ToString() & "/" & giTranYear.ToString()
        c1dateTranDate.Value = giTranMonth.ToString() & "/" & giTranYear.ToString()
        grp03.Enabled = False
        btnNext.Enabled = False
        tdbcAssetAccountID.SelectedIndex = 0
        tdbcDepAccountID.SelectedIndex = 0
        tdbcMethodID.SelectedIndex = 0
        tdbcMethodEndID.SelectedIndex = 0
        tdbcAssignmentTypeID.SelectedIndex = 0
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""
        sSQL = SQLStoreD02P0613()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Status").ToString() = "1" Then

                tdbcObjectTypeID.Enabled = False
                tdbcObjectID.Enabled = False
                tdbcEmployeeID.Enabled = False
                grp01.Enabled = False
                grp02.Enabled = False
                grp03.Enabled = False
                tdbcAssetAccountID.Enabled = False
                tdbcDepAccountID.Enabled = False
            End If
        End If
        tdbcAssetS1ID.Enabled = False
        tdbcAssetS2ID.Enabled = False
        tdbcAssetS3ID.Enabled = False
        txtAssetID.Enabled = False
        btnSetNewKey.Enabled = False
        btnNext.Enabled = False
        grp03.Enabled = False
    End Sub

    Private Sub LoadEdit_Data()
        Dim sSQL As String = ""

        sSQL = "SELECT T01.*, N19.CurrentCost AS N19ConvertedAmount, " & vbCrLf
        sSQL &= "CASE WHEN N19.DepreciationAmount = 0 " & vbCrLf
        sSQL &= "THEN N19.DepreciatedAmount ELSE N19.DepreciationAmount END AS N19DepreciationAmount, N19.RemainAmount AS N19RemainAmount," & vbCrLf
        sSQL &= "N19.ServiceLife AS N19ServiceLife, N19.DepreciatedPeriod AS N19DepreciatedPeriod, N19.CurrentLTDDepreciation AS N19AmountDepreciation " & vbCrLf
        sSQL &= "FROM 		D02T0001 T01 WITH(NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN D02N0019(" & giTranMonth & ", " & giTranYear & ") N19 " & vbCrLf
        sSQL &= "ON	T01.AssetID = N19.AssetID AND T01.DivisionID = N19.DivisionID " & vbCrLf
        sSQL &= "Where T01.AssetID=" & SQLString(mAssetID) & " AND T01.DivisionID=" & SQLString(gsDivisionID)

        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then

            tdbcAssetS1ID.Text = dt.Rows(0).Item("AssetS1ID").ToString()
            tdbcAssetS2ID.Text = dt.Rows(0).Item("AssetS2ID").ToString()
            tdbcAssetS3ID.Text = dt.Rows(0).Item("AssetS3ID").ToString()
            txtAssetID.Text = dt.Rows(0).Item("AssetID").ToString()
            txtAssetName.Text = dt.Rows(0).Item(IIf(gbUnicode, "AssetNameU", "AssetName").ToString).ToString()
            txtNotes.Text = dt.Rows(0).Item(IIf(gbUnicode, "NotesU", "Notes").ToString).ToString()
            'LoadTDBCombo()
            tdbcObjectTypeID.SelectedValue = dt.Rows(0).Item("ObjectTypeID").ToString()
            tdbcObjectID.SelectedValue = dt.Rows(0).Item("ObjectID").ToString()
            tdbcEmployeeID.SelectedValue = dt.Rows(0).Item("EmployeeID").ToString()
            txtShortName.Text = dt.Rows(0).Item(IIf(gbUnicode, "ShortNameU", "ShortName").ToString).ToString()
            txtAssetTag.Text = dt.Rows(0).Item(IIf(gbUnicode, "AssetTagU", "AssetTag").ToString).ToString()
            tdbcSupplierOTID.SelectedValue = dt.Rows(0).Item("SupplierOTID").ToString()
            tdbcSupplierID.SelectedValue = dt.Rows(0).Item("SupplierID").ToString()
            c1datePurchaseDate.Value = dt.Rows(0).Item("PurchaseDate").ToString()
            chkMaintainable.Checked = CType(dt.Rows(0).Item("Maintainable"), Boolean)
            tdbcAssetAccountID.SelectedValue = dt.Rows(0).Item("AssetAccountID").ToString()
            tdbcDepAccountID.SelectedValue = dt.Rows(0).Item("DepAccountID").ToString()
            c1datePeriod.Value = Format(dt.Rows(0).Item("UseMonth"), "0#") & "/" & dt.Rows(0).Item("UseYear").ToString()
            c1dateDepPeriod.Value = Format(dt.Rows(0).Item("DepMonth"), "0#") & "/" & dt.Rows(0).Item("DepYear").ToString()
            c1dateTranDate.Value = Format(dt.Rows(0).Item("TranMonth"), "0#") & "/" & dt.Rows(0).Item("TranYear").ToString()
            tdbcMethodID.SelectedValue = dt.Rows(0).Item("MethodID").ToString()
            tdbcMethodEndID.SelectedValue = dt.Rows(0).Item("MethodEndID").ToString()
            tdbcDeprTableID.SelectedValue = dt.Rows(0).Item("DeprTableID").ToString()
            tdbcAssignmentTypeID.SelectedValue = dt.Rows(0).Item("AssignmentTypeID").ToString()
            txtConvertedAmount.Text = dt.Rows(0).Item("N19ConvertedAmount").ToString()
            txtRemainAmount.Text = dt.Rows(0).Item("N19RemainAmount").ToString()
            txtDepreciatedPeriod.Text = dt.Rows(0).Item("N19DepreciatedPeriod").ToString()
            txtDepreciationAmount.Text = dt.Rows(0).Item("N19DepreciationAmount").ToString()
            txtAmountDepreciation.Text = dt.Rows(0).Item("N19AmountDepreciation").ToString()
            txtServiceLife.Text = dt.Rows(0).Item("N19ServiceLife").ToString()
            txtPercentage.Text = dt.Rows(0).Item("Percentage").ToString()
            txtSpecification.Text = dt.Rows(0).Item(IIf(gbUnicode, "SpecificationU", "Specification").ToString).ToString()
            txtCountryID.Text = dt.Rows(0).Item("CountryID").ToString()
            txtMadeYear.Text = dt.Rows(0).Item("MadeYear").ToString()
            txtSeriNo.Text = dt.Rows(0).Item("SeriNo").ToString()
            txtVersion.Text = dt.Rows(0).Item("Version").ToString()
            txtAssetNo.Text = dt.Rows(0).Item("AssetNo").ToString()
            txtUnitName.Text = dt.Rows(0).Item("UnitName" & UnicodeJoin(gbUnicode)).ToString()
            txtTool.Text = dt.Rows(0).Item("Tool" & UnicodeJoin(gbUnicode)).ToString()
            txtIndex1.Text = dt.Rows(0).Item("Index1").ToString()
            txtIndex2.Text = dt.Rows(0).Item("Index2").ToString()
            txtIndex3.Text = dt.Rows(0).Item("Index3").ToString()
            txtIndex4.Text = dt.Rows(0).Item("Index4").ToString()
            txtIndex5.Text = dt.Rows(0).Item("Index5").ToString()
            txtIndex6.Text = dt.Rows(0).Item("Index6").ToString()
            tdbcAcode01ID.SelectedValue = dt.Rows(0).Item("Acode01ID").ToString()
            tdbcAcode02ID.SelectedValue = dt.Rows(0).Item("Acode02ID").ToString()
            tdbcAcode03ID.SelectedValue = dt.Rows(0).Item("Acode03ID").ToString()
            tdbcAcode04ID.SelectedValue = dt.Rows(0).Item("Acode04ID").ToString()
            tdbcAcode05ID.SelectedValue = dt.Rows(0).Item("Acode05ID").ToString()
            tdbcAcode06ID.SelectedValue = dt.Rows(0).Item("Acode06ID").ToString()
            tdbcAcode07ID.SelectedValue = dt.Rows(0).Item("Acode07ID").ToString()
            tdbcAcode08ID.SelectedValue = dt.Rows(0).Item("Acode08ID").ToString()
            tdbcAcode09ID.SelectedValue = dt.Rows(0).Item("Acode09ID").ToString()
            tdbcAcode10ID.SelectedValue = dt.Rows(0).Item("Acode10ID").ToString()
        End If
        LoadImage()
    End Sub

    Private Function SQLGetInfoAddNew() As String
        Dim sSQL As String = ""
        sSQL = "Select AssetAuto,"
        sSQL &= "AssetS1Enabled, AssetS1Default,"
        sSQL &= "AssetS2Enabled, AssetS2Default,"
        sSQL &= "AssetS3Enabled, AssetS3Default,"
        sSQL &= "AssetOutputOrder, AssetOutputLength,"
        sSQL &= "AssetSeperated, AssetSeperator "
        sSQL &= "From D02T0000 WITH(NOLOCK)"
        Return sSQL
    End Function

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcAssetS1ID
        If gsLanguage = "84" Then
            sSQL = "Select '<<' as AssetS1ID," & IIf(gbUnicode, "N'<Thêm mới>'", "'<Theâm môùi>'").ToString & "  as AssetS1Name Union Select AssetS1ID, AssetS1Name" & UnicodeJoin(gbUnicode) & " as AssetS1Name From D02T1000 WITH(NOLOCK) Where Disabled=0 Order by AssetS1ID"
        Else
            sSQL = "Select '<<' as AssetS1ID, 'Add' as AssetS1Name Union Select AssetS1ID, AssetS1Name" & UnicodeJoin(gbUnicode) & " as AssetS1Name From D02T1000 WITH(NOLOCK) Where Disabled=0 Order by AssetS1ID"
        End If
        LoadDataSource(tdbcAssetS1ID, sSQL, gbUnicode)
        'Load tdbcAssetS2ID
        If gsLanguage = "84" Then
            sSQL = "Select '<<' as AssetS2ID," & IIf(gbUnicode, "N'<Thêm mới>'", "'<Theâm môùi>'").ToString & " as AssetS2Name Union Select AssetS2ID, AssetS2Name" & UnicodeJoin(gbUnicode) & " as AssetS2Name From D02T2000 WITH(NOLOCK) Where Disabled=0 Order by AssetS2ID"
        Else
            sSQL = "Select '<<' as AssetS2ID, 'Add' as AssetS2Name Union Select AssetS2ID, AssetS2Name" & UnicodeJoin(gbUnicode) & " as AssetS2Name From D02T2000 WITH(NOLOCK) Where Disabled=0 Order by AssetS2ID"
        End If
        LoadDataSource(tdbcAssetS2ID, sSQL, gbUnicode)
        'Load tdbcAssetS3ID
        If gsLanguage = "84" Then
            sSQL = "Select '<<' as AssetS3ID," & IIf(gbUnicode, "N'<Thêm mới>'", "'<Theâm môùi>'").ToString & " as AssetS3Name Union Select AssetS3ID, AssetS3Name" & UnicodeJoin(gbUnicode) & " as AssetS3Name From D02T3000 WITH(NOLOCK) Where Disabled=0 Order by AssetS3ID"
        Else
            sSQL = "Select '<<' as AssetS3ID, 'Add' as AssetS3Name Union Select AssetS3ID, AssetS3Name" & UnicodeJoin(gbUnicode) & " as AssetS3Name From D02T3000 WITH(NOLOCK) Where Disabled=0 Order by AssetS3ID"
        End If
        LoadDataSource(tdbcAssetS3ID, sSQL, gbUnicode)
        'Load tdbcObjectTypeID
        If gsLanguage = "84" Then
            sSQL = "Select ObjectTypeID, ObjectTypeName" & UnicodeJoin(gbUnicode) & " as ObjectTypeName From D91T0005 WITH(NOLOCK) Order by ObjectTypeID"
        ElseIf gsLanguage = "01" Then
            sSQL = "Select ObjectTypeID, ObjectTypeName01" & UnicodeJoin(gbUnicode) & " as ObjectTypeName From D91T0005 WITH(NOLOCK) Order by ObjectTypeID"
        End If

        LoadDataSource(tdbcObjectTypeID, sSQL, gbUnicode)
        LoadDataSource(tdbcSupplierOTID, sSQL, gbUnicode)
        LoadDataSource(tdbdObjectTypeID, sSQL, gbUnicode)
        'Load tdbdOjectID
        sSQL = "Select ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName, ObjectTypeID From Object WITH(NOLOCK) Where Disabled=0 " ' and ObjectTypeID=" & SQLString(ID)
        dtObjectID = ReturnDataTable(sSQL)
        'Load tdbcEmployeeID
        sSQL = "Select ObjectID as EmployeeID, ObjectName" & UnicodeJoin(gbUnicode) & " as EmployeeName From Object WITH(NOLOCK) Where ObjectTypeID='NV' Order by ObjectID"
        LoadDataSource(tdbcEmployeeID, sSQL, gbUnicode)
        'Load tdbcAssetAccountID
        sSQL = "Select AccountID,  " & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName" & UnicodeJoin(gbUnicode), "AccountName01" & UnicodeJoin(gbUnicode)).ToString & " as AccountName  From D90T0001 WITH(NOLOCK) Where GroupID='7' and OffAccount=0 and AccountStatus=0 Order by AccountID"
        LoadDataSource(tdbcAssetAccountID, sSQL, gbUnicode)
        'Load tdbcDepAccountID
        sSQL = "Select AccountID,  " & IIf(geLanguage = EnumLanguage.Vietnamese, "AccountName" & UnicodeJoin(gbUnicode), "AccountName01" & UnicodeJoin(gbUnicode)).ToString & " as AccountName From D90T0001 WITH(NOLOCK) Where GroupID='19' and OffAccount=0 and AccountStatus=0 Order by AccountID"
        LoadDataSource(tdbcDepAccountID, sSQL, gbUnicode)
        'Load tdbcMethodID
        sSQL = "Select convert(varchar(20),IntCode) as MethodID,Description" & UnicodeJoin(gbUnicode) & " as MethodName From D02T8000 WITH(NOLOCK) Where Type=0 and ModuleID='02' and Language='84' Order by IntCode"
        LoadDataSource(tdbcMethodID, sSQL, gbUnicode)
        'Load tdbcMethodEndID
        sSQL = "Select convert(varchar(20),IntCode) as MethodEndID,Description" & UnicodeJoin(gbUnicode) & " as MethodEndName From D02T8000 WITH(NOLOCK) Where Type=1 and ModuleID='02' and Language='84' Order by IntCode"
        LoadDataSource(tdbcMethodEndID, sSQL, gbUnicode)
        'Load tdbcDeprTableID
        sSQL = "Select DeprTableID, DeprTableName" & UnicodeJoin(gbUnicode) & " as DeprTableName From D02T0070 WITH(NOLOCK) Where Disabled=0 And DivisionID=" & SQLString(gsDivisionID)
        LoadDataSource(tdbcDeprTableID, sSQL, gbUnicode)
        'Load tdbcAssignmentTypeID
        sSQL = "Select AssignmentTypeID, AssignmentTypeName" & UnicodeJoin(gbUnicode) & "  as AssignmentTypeName From D02V0041"
        LoadDataSource(tdbcAssignmentTypeID, sSQL, gbUnicode)
        'Load tdbcAcode01ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A01' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode01ID, sSQL, gbUnicode)
        'Load tdbcAcode02ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A02' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode02ID, sSQL, gbUnicode)
        'Load tdbcAcode03ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A03' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode03ID, sSQL, gbUnicode)
        'Load tdbcAcode04ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A04' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode04ID, sSQL, gbUnicode)
        'Load tdbcAcode05ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A05' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode05ID, sSQL, gbUnicode)
        'Load tdbcAcode06ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A06' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode06ID, sSQL, gbUnicode)
        'Load tdbcAcode07ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A07' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode07ID, sSQL, gbUnicode)
        'Load tdbcAcode08ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A08' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode08ID, sSQL, gbUnicode)
        'Load tdbcAcode09ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A09' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode09ID, sSQL, gbUnicode)
        'Load tdbcAcode10ID
        sSQL = "Select ACodeID, Description" & UnicodeJoin(gbUnicode) & " as Description From D02T0041 WITH(NOLOCK) Where TypeCodeID='A10' and Disabled=0 Order by AcodeID"
        LoadDataSource(tdbcAcode10ID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbcObjectID(ByVal ID As String)
        LoadDataSource(tdbcObjectID, ReturnTableFilter(dtObjectID, "ObjectTypeID = " & SQLString(ID), True), gbUnicode)
    End Sub

    Private Sub LoadtdbcSupplierID(ByVal ID As String)
        LoadDataSource(tdbcSupplierID, ReturnTableFilter(dtObjectID, "ObjectTypeID = " & SQLString(ID), True), gbUnicode)
    End Sub

    Private Sub LoadtdbdObjectID(ByVal ID As String)
        LoadDataSource(tdbdObjectID, ReturnTableFilter(dtObjectID, "ObjectTypeID=" & SQLString(ID), True), gbUnicode)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = "Select DivisionID,AssetID,EquipmentID,OrderNum,EquipmentName" & UnicodeJoin(gbUnicode) & " as EquipmentName,Notes" & UnicodeJoin(gbUnicode) & " as Notes,EquipmentQuantity,ObjectTypeID,ObjectID,EquipmentValue "
        sSQL &= "From D02T4001 WITH(NOLOCK) "
        sSQL &= "Where AssetID = " & SQLString(mAssetID) & " and DivisionID=" & SQLString(gsDivisionID)
        sSQL &= "Order by OrderNum"
        LoadDataSource(tdbgDetail, sSQL, gbUnicode)
    End Sub


#Region "Events tdbcAssetS1ID"

    Private Sub tdbcAssetS1ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetS1ID.Close
        If tdbcAssetS1ID.FindStringExact(tdbcAssetS1ID.Text) = -1 Then tdbcAssetS1ID.Text = ""
    End Sub

    Private Sub tdbcAssetS1ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAssetS1ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAssetS1ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAssetS2ID"

    Private Sub tdbcAssetS2ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetS2ID.Close
        If tdbcAssetS2ID.FindStringExact(tdbcAssetS2ID.Text) = -1 Then tdbcAssetS2ID.Text = ""
    End Sub

    Private Sub tdbcAssetS2ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAssetS2ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAssetS2ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAssetS3ID"

    Private Sub tdbcAssetS3ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetS3ID.Close
        If tdbcAssetS3ID.FindStringExact(tdbcAssetS3ID.Text) = -1 Then tdbcAssetS3ID.Text = ""
    End Sub

    Private Sub tdbcAssetS3ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAssetS3ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAssetS3ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcObjectTypeID load tdbcObjectID with txtObjectName"

    Private Sub tdbcObjectTypeID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.Close
        If tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 Then tdbcObjectTypeID.Text = ""
    End Sub

    Private Sub tdbcObjectTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.SelectedValueChanged
        If Not (tdbcObjectTypeID.Tag Is Nothing OrElse tdbcObjectTypeID.Tag.ToString = "") Then
            tdbcObjectTypeID.Tag = ""
            Exit Sub
        End If
        If tdbcObjectTypeID.SelectedValue Is Nothing Then
            LoadtdbcObjectID("-1")
            Exit Sub
        End If
        LoadtdbcObjectID(tdbcObjectTypeID.SelectedValue.ToString())
        tdbcObjectID.Text = ""
        txtObjectName.Text = ""
    End Sub

    Private Sub tdbcObjectTypeID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcObjectTypeID.KeyDown
        If e.Alt = True Then
            tdbcObjectTypeID.AutoDropDown = False
        Else
            tdbcObjectTypeID.AutoDropDown = True
        End If
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcObjectTypeID.Text = ""
    End Sub

    Private Sub tdbcObjectID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.Close
        If tdbcObjectID.FindStringExact(tdbcObjectID.Text) = -1 Then
            tdbcObjectID.Text = ""
            txtObjectName.Text = ""
        End If
    End Sub

    Private Sub tdbcObjectID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.SelectedValueChanged
        txtObjectName.Text = tdbcObjectID.Columns(1).Value.ToString()
    End Sub

    Private Sub tdbcObjectID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcObjectID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcObjectID.Text = ""
            txtObjectName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcSupplierOTID load tdbcSupplierID with txtSupplierName"

    Private Sub tdbcSupplierOTID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSupplierOTID.Close
        If tdbcSupplierOTID.FindStringExact(tdbcSupplierOTID.Text) = -1 Then tdbcSupplierOTID.Text = ""
    End Sub

    Private Sub tdbcSupplierOTID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSupplierOTID.SelectedValueChanged
        If Not (tdbcSupplierOTID.Tag Is Nothing OrElse tdbcSupplierOTID.Tag.ToString = "") Then
            tdbcSupplierOTID.Tag = ""
            Exit Sub
        End If
        If tdbcSupplierOTID.SelectedValue Is Nothing Then
            LoadtdbcSupplierID("-1")
            Exit Sub
        End If
        LoadtdbcSupplierID(tdbcSupplierOTID.SelectedValue.ToString())
        tdbcSupplierID.Text = ""
        txtSupplierName.Text = ""
    End Sub

    Private Sub tdbcSupplierOTID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSupplierOTID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcSupplierOTID.Text = ""
    End Sub

    Private Sub tdbcSupplierID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSupplierID.Close
        If tdbcSupplierID.FindStringExact(tdbcSupplierID.Text) = -1 Then
            tdbcSupplierID.Text = ""
            txtSupplierName.Text = ""
        End If
    End Sub

    Private Sub tdbcSupplierID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcSupplierID.SelectedValueChanged
        txtSupplierName.Text = tdbcSupplierID.Columns(1).Value.ToString()
    End Sub

    Private Sub tdbcSupplierID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcSupplierID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcSupplierID.Text = ""
            txtSupplierName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcEmployeeID with txtEmployeeName"

    Private Sub tdbcEmployeeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.Close
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
            tdbcEmployeeID.Text = ""
            txtEmployeeName.Text = ""
        End If
    End Sub

    Private Sub tdbcEmployeeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.SelectedValueChanged
        txtEmployeeName.Text = tdbcEmployeeID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcEmployeeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcEmployeeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcEmployeeID.Text = ""
            txtEmployeeName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcMethodID with txtMethodName"

    Private Sub tdbcMethodID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodID.Close
        If tdbcMethodID.FindStringExact(tdbcMethodID.Text) = -1 Then
            tdbcMethodID.Text = ""
            txtMethodName.Text = ""
        End If
    End Sub

    Private Sub tdbcMethodID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodID.SelectedValueChanged
        txtMethodName.Text = tdbcMethodID.Columns(1).Value.ToString
        If tdbcMethodID.Text.Trim = "0" Then
            tdbcDeprTableID.SelectedValue = "-1"
            txtDeprTableName.Text = ""
            tdbcDeprTableID.Enabled = False
        Else
            tdbcDeprTableID.Enabled = True
            tdbcDeprTableID.SelectedIndex = 0
        End If
    End Sub

    Private Sub tdbcMethodID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcMethodID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcMethodID.Text = ""
            txtMethodName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcMethodEndID with txtMethodEndName"

    Private Sub tdbcMethodEndID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodEndID.Close
        If tdbcMethodEndID.FindStringExact(tdbcMethodEndID.Text) = -1 Then
            tdbcMethodEndID.Text = ""
            txtMethodEndName.Text = ""
        End If
    End Sub

    Private Sub tdbcMethodEndID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodEndID.SelectedValueChanged
        txtMethodEndName.Text = tdbcMethodEndID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcMethodEndID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcMethodEndID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcMethodEndID.Text = ""
            txtMethodEndName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcAcode01ID"

    Private Sub tdbcAcode01ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode01ID.Close
        If tdbcAcode01ID.FindStringExact(tdbcAcode01ID.Text) = -1 Then tdbcAcode01ID.Text = ""
    End Sub

    Private Sub tdbcAcode01ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode01ID.KeyDown
        If e.Alt = True Then
            tdbcAcode01ID.AutoDropDown = False
        Else
            tdbcAcode01ID.AutoDropDown = True
        End If
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode01ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode02ID"

    Private Sub tdbcAcode02ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode02ID.Close
        If tdbcAcode02ID.FindStringExact(tdbcAcode02ID.Text) = -1 Then tdbcAcode02ID.Text = ""
    End Sub

    Private Sub tdbcAcode02ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode02ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode02ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode03ID"

    Private Sub tdbcAcode03ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode03ID.Close
        If tdbcAcode03ID.FindStringExact(tdbcAcode03ID.Text) = -1 Then tdbcAcode03ID.Text = ""
    End Sub

    Private Sub tdbcAcode03ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode03ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode03ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode04ID"

    Private Sub tdbcAcode04ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode04ID.Close
        If tdbcAcode04ID.FindStringExact(tdbcAcode04ID.Text) = -1 Then tdbcAcode04ID.Text = ""
    End Sub

    Private Sub tdbcAcode04ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode04ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode04ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode05ID"

    Private Sub tdbcAcode05ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode05ID.Close
        If tdbcAcode05ID.FindStringExact(tdbcAcode05ID.Text) = -1 Then tdbcAcode05ID.Text = ""
    End Sub

    Private Sub tdbcAcode05ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode05ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode05ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode06ID"

    Private Sub tdbcAcode06ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode06ID.Close
        If tdbcAcode06ID.FindStringExact(tdbcAcode06ID.Text) = -1 Then tdbcAcode06ID.Text = ""
    End Sub

    Private Sub tdbcAcode06ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode06ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode06ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode07ID"

    Private Sub tdbcAcode07ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode07ID.Close
        If tdbcAcode07ID.FindStringExact(tdbcAcode07ID.Text) = -1 Then tdbcAcode07ID.Text = ""
    End Sub

    Private Sub tdbcAcode07ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode07ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode07ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode08ID"

    Private Sub tdbcAcode08ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode08ID.Close
        If tdbcAcode08ID.FindStringExact(tdbcAcode08ID.Text) = -1 Then tdbcAcode08ID.Text = ""
    End Sub

    Private Sub tdbcAcode08ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode08ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode08ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode09ID"

    Private Sub tdbcAcode09ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode09ID.Close
        If tdbcAcode09ID.FindStringExact(tdbcAcode09ID.Text) = -1 Then tdbcAcode09ID.Text = ""
    End Sub

    Private Sub tdbcAcode09ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode09ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode09ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAcode10ID"

    Private Sub tdbcAcode10ID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAcode10ID.Close
        If tdbcAcode10ID.FindStringExact(tdbcAcode10ID.Text) = -1 Then tdbcAcode10ID.Text = ""
    End Sub

    Private Sub tdbcAcode10ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAcode10ID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAcode10ID.Text = ""
    End Sub

#End Region

    Private Function SQLGetCaptionFrameIndex() As String
        Dim sSQL As String = ""
        sSQL = "Select FieldName,"
        sSQL &= IIf(gsLanguage = "01", "EngCaption" & UnicodeJoin(gbUnicode), "VieCaption" & UnicodeJoin(gbUnicode)).ToString()
        sSQL &= " as Caption, Disabled "
        sSQL &= "From D02T0039 WITH(NOLOCK)"
        Return sSQL
    End Function

    Private Sub AssignCaptionFrameIndex()
        Dim sSQL As String = SQLGetCaptionFrameIndex()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        lblIndex1.Font = FontUnicode(gbUnicode)
        lblIndex2.Font = FontUnicode(gbUnicode)
        lblIndex3.Font = FontUnicode(gbUnicode)
        lblIndex4.Font = FontUnicode(gbUnicode)
        lblIndex5.Font = FontUnicode(gbUnicode)
        lblIndex6.Font = FontUnicode(gbUnicode)
        lblIndex1.Text = dt.Rows(0)("Caption").ToString()
        txtIndex1.Enabled = Not CType(dt.Rows(0)("Disabled").ToString(), Boolean)
        lblIndex2.Text = dt.Rows(1)("Caption").ToString()
        txtIndex2.Enabled = Not CType(dt.Rows(1)("Disabled").ToString(), Boolean)
        lblIndex3.Text = dt.Rows(2)("Caption").ToString()
        txtIndex3.Enabled = Not CType(dt.Rows(2)("Disabled").ToString(), Boolean)
        lblIndex4.Text = dt.Rows(3)("Caption").ToString()
        txtIndex4.Enabled = Not CType(dt.Rows(3)("Disabled").ToString(), Boolean)
        lblIndex5.Text = dt.Rows(4)("Caption").ToString()
        txtIndex5.Enabled = Not CType(dt.Rows(4)("Disabled").ToString(), Boolean)
        lblIndex6.Text = dt.Rows(5)("Caption").ToString()
        txtIndex6.Enabled = Not CType(dt.Rows(5)("Disabled").ToString(), Boolean)
    End Sub

    Private Function SQLGetCaptionInTab4() As String
        Dim sSQL As String = ""
        sSQL = "Select TypeCodeID, Disabled, " & IIf(geLanguage = EnumLanguage.Vietnamese, "VieTypeCodeName" & UnicodeJoin(gbUnicode), "EngTypeCodeName" & UnicodeJoin(gbUnicode)).ToString & " as AcodeCaption" & vbCrLf
        'sSQL &= "(Case when 0=0 then VieTypeCodeName else EngTypeCodeName End) as AcodeCaption "
        sSQL &= "From D02T0040 WITH(NOLOCK) "
        sSQL &= "Where Type='A'"
        sSQL &= "Order by TypeCodeID"
        Return sSQL
    End Function

    Private Sub AssignCaptionInTab4()
        Dim sSQL As String = SQLGetCaptionInTab4()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        lblAcode01ID.Font = FontUnicode(gbUnicode)
        lblAcode02ID.Font = FontUnicode(gbUnicode)
        lblAcode03ID.Font = FontUnicode(gbUnicode)
        lblAcode04ID.Font = FontUnicode(gbUnicode)
        lblAcode05ID.Font = FontUnicode(gbUnicode)
        lblAcode06ID.Font = FontUnicode(gbUnicode)
        lblAcode07ID.Font = FontUnicode(gbUnicode)
        lblAcode08ID.Font = FontUnicode(gbUnicode)
        lblAcode09ID.Font = FontUnicode(gbUnicode)
        lblAcode10ID.Font = FontUnicode(gbUnicode)
        lblAcode01ID.Text = dt.Rows(0)("AcodeCaption").ToString()
        lblAcode02ID.Text = dt.Rows(1)("AcodeCaption").ToString()
        lblAcode03ID.Text = dt.Rows(2)("AcodeCaption").ToString()
        lblAcode04ID.Text = dt.Rows(3)("AcodeCaption").ToString()
        lblAcode05ID.Text = dt.Rows(4)("AcodeCaption").ToString()
        lblAcode06ID.Text = dt.Rows(5)("AcodeCaption").ToString()
        lblAcode07ID.Text = dt.Rows(6)("AcodeCaption").ToString()
        lblAcode08ID.Text = dt.Rows(7)("AcodeCaption").ToString()
        lblAcode09ID.Text = dt.Rows(8)("AcodeCaption").ToString()
        lblAcode10ID.Text = dt.Rows(9)("AcodeCaption").ToString()
    End Sub

    Private Sub D02F0601_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtSeriNo, 50)
        Me.KeyPreview = True
        'AddHandler Me.KeyPress, AddressOf FormKeyPress
        FormatNumber()
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Reload()
        MakeSameLocation()
        tdbgDetail_LockedColumns()
        LoadTDBCombo()
        LoadTDBGrid()
        AssignCaptionInTab4()
        AssignCaptionFrameIndex()
    End Sub

    Private Sub MakeSameLocation()
        grpDetail.Left = lblTool.Left
        grpDetail.Top = txtTool.Top - 5
    End Sub

    Private Sub btnDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        grpDetail.Visible = True
        grpIndex.Visible = False
    End Sub

    Private Sub btnCloseDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseDetail.Click
        grpDetail.Visible = False
        grpIndex.Visible = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        mAssetID_D02F0601 = txtAssetID.Text
        Me.Close()
    End Sub

    Private Sub FormatNumber()
        If _FormState = EnumFormState.FormAdd Then Exit Sub
        If txtConvertedAmount.Text <> "" Then txtConvertedAmount.Text = SQLNumber(txtConvertedAmount.Text, DxxFormat.D90_ConvertedDecimals)
        If txtRemainAmount.Text <> "" Then txtRemainAmount.Text = SQLNumber(txtRemainAmount.Text, DxxFormat.DecimalPlaces)
        If txtDepreciationAmount.Text <> "" Then txtDepreciationAmount.Text = SQLNumber(txtDepreciationAmount.Text, DxxFormat.DecimalPlaces)
        If txtAmountDepreciation.Text <> "" Then txtAmountDepreciation.Text = SQLNumber(txtAmountDepreciation.Text, DxxFormat.DecimalPlaces)
        If txtPercentage.Text <> "" Then txtPercentage.Text = SQLNumber(txtPercentage.Text, DxxFormat.DefaultNumber2)
        If txtIndex1.Text <> "" Then txtIndex1.Text = SQLNumber(txtIndex1.Text, DxxFormat.DefaultNumber2)
        If txtIndex2.Text <> "" Then txtIndex2.Text = SQLNumber(txtIndex2.Text, DxxFormat.DefaultNumber2)
        If txtIndex3.Text <> "" Then txtIndex3.Text = SQLNumber(txtIndex3.Text, DxxFormat.DefaultNumber2)
        If txtIndex4.Text <> "" Then txtIndex4.Text = SQLNumber(txtIndex4.Text, DxxFormat.DefaultNumber2)
        If txtIndex5.Text <> "" Then txtIndex5.Text = SQLNumber(txtIndex5.Text, DxxFormat.DefaultNumber2)
        If txtIndex6.Text <> "" Then txtIndex6.Text = SQLNumber(txtIndex6.Text, DxxFormat.DefaultNumber2)
    End Sub

    Private Sub btnConvertedAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertedAmount.Click
        Dim f As New D02F0602()
        f.VisibleControlsConvertedAmount(True)
        f.VisibleControlsDepreciation(False)
        f.VisibleControlsHistory(False)
        f.Mode = 1
        f.AssetID = txtAssetID.Text
        f.AssetName = txtAssetName.Text
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub btnDepreciate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepreciate.Click
        Dim f As New D02F0602()
        f.VisibleControlsDepreciation(True)
        f.VisibleControlsConvertedAmount(False)
        f.VisibleControlsHistory(False)
        f.Mode = 2
        f.AssetID = txtAssetID.Text
        f.AssetName = txtAssetName.Text
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub btnHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Dim f As New D02F0602()
        f.VisibleControlsHistory(True)
        f.VisibleControlsConvertedAmount(False)
        f.VisibleControlsDepreciation(False)
        f.Mode = 3
        f.AssetID = txtAssetID.Text
        f.AssetName = txtAssetName.Text
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub tdbcAssetS1ID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAssetS1ID.SelectedValueChanged
        '_S1 = tdbcAssetS1ID.SelectedValue.ToString()
        'txtAssetID.Text = CreateIGE(_TableName, "AssetID", _S1, _S2, _S3, OutOrderEnum.lmSSSN, _OutputLength, _Seperator)
        'D02X0002.GetNewVoucherNo(_S1, _S2, _S3, _OutputOrder, _OutputLength, _Seperator, txtAssetID, False)
    End Sub

    Private Sub tdbcAssetS2ID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAssetS2ID.SelectedValueChanged
        '_S2 = tdbcAssetS2ID.SelectedValue.ToString()
        'txtAssetID.Text = CreateIGE(_TableName, "AssetID", _S1, _S2, _S3, OutOrderEnum.lmSSSN, _OutputLength, _Seperator)
        'D02X0002.GetNewVoucherNo(_S1, _S2, _S3, _OutputOrder, _OutputLength, _Seperator, txtAssetID, False)
    End Sub

    Private Sub tdbcAssetS3ID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAssetS3ID.SelectedValueChanged
        '_S3 = tdbcAssetS3ID.SelectedValue.ToString()
        'txtAssetID.Text = CreateIGE(_TableName, "AssetID", _S1, _S2, _S3, OutOrderEnum.lmSSSN, _OutputLength, _Seperator)
        'D02X0002.GetNewVoucherNo(_S1, _S2, _S3, _OutputOrder, _OutputLength, _Seperator, txtAssetID, False)
    End Sub

    Private Sub tdbgDetail_LockedColumns()
        tdbgDetail.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbgDetail_NumberFormat()
        'tdbgDetail.Columns(COL_EquipmentQuantity).NumberFormat = ????? 
        'tdbgDetail.Columns(COL_EquipmentValue).NumberFormat = ????? 
    End Sub

    Private Sub SetKeyPressTextbox()

    End Sub

    Private Sub tdbgDetail_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgDetail.AfterDelete
        'UpdateOrderNum(tdbgDetail, COL_OrderNum)
        UpdateTDBGOrderNum(tdbgDetail, COL_OrderNum)
    End Sub

    Private Sub tdbgDetail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgDetail.KeyPress
        Select Case tdbgDetail.Col
            Case COL_OrderNum
            Case COL_EquipmentID
            Case COL_EquipmentName
            Case COL_EquipmentQuantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_EquipmentValue
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_ObjectTypeID
            Case COL_ObjectID
            Case COL_Notes
        End Select
    End Sub

    Private Sub tdbgDetail_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.AfterColUpdate
        'Select Case e.ColIndex
        '    Case COL_OrderNum
        '    Case COL_EquipmentID
        '        tdbgDetail.Columns(COL_OrderNum).Text = (Val(tdbgDetail.Bookmark) + 1).ToString
        '    Case COL_EquipmentName
        '        tdbgDetail.Columns(COL_OrderNum).Text = (Val(tdbgDetail.Bookmark) + 1).ToString
        '    Case COL_EquipmentQuantity
        '        tdbgDetail.Columns(COL_OrderNum).Text = (Val(tdbgDetail.Bookmark) + 1).ToString
        '    Case COL_EquipmentValue
        '        tdbgDetail.Columns(COL_OrderNum).Text = (Val(tdbgDetail.Bookmark) + 1).ToString
        '    Case COL_ObjectTypeID
        '        tdbgDetail.Columns(COL_OrderNum).Text = (Val(tdbgDetail.Bookmark) + 1).ToString
        '        LoadtdbdObjectID(tdbgDetail.Columns(COL_ObjectTypeID).Text)
        '    Case COL_ObjectID
        '        tdbgDetail.Columns(COL_OrderNum).Text = (Val(tdbgDetail.Bookmark) + 1).ToString
        '    Case COL_Notes
        '        tdbgDetail.Columns(COL_OrderNum).Text = (Val(tdbgDetail.Bookmark) + 1).ToString
        'End Select
        UpdateTDBGOrderNum(tdbgDetail, COL_OrderNum, e.ColIndex)
    End Sub

    Private Sub btnSetNewKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetNewKey.Click
        D02X0002.GetNewVoucherNo(_S1, _S2, _S3, _OutputOrder, _OutputLength, _Seperator, txtAssetID, True, _TableName)
    End Sub

    Private Function SQLGetAssetID() As String
        Dim sSQL As String = ""
        sSQL = "Select 1 From D02T0001 WITH(NOLOCK) "
        sSQL &= "Where AssetID=" & SQLString(txtAssetID.Text) & " and DivisionID=" & SQLString(gsDivisionID)
        Return sSQL
    End Function

    Private Function AllowSave() As Boolean
        If tdbcAssetS1ID.Enabled And tdbcAssetS1ID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_tai_san") & " 1")
            tdbcAssetS1ID.Focus()
            Return False
        End If
        If tdbcAssetS2ID.Enabled And tdbcAssetS2ID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_tai_san") & " 2")
            tdbcAssetS2ID.Focus()
            Return False
        End If
        If tdbcAssetS3ID.Enabled And tdbcAssetS3ID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ma_tai_san") & " 3")
            tdbcAssetS3ID.Focus()
            Return False
        End If
        If txtAssetID.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_tai_san"))
            txtAssetID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            Dim sSQL As String = SQLGetAssetID()
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                D99C0008.MsgDuplicatePKey()
                Return False
            End If
        End If
        If txtAssetName.Text = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_tai_san"))
            txtAssetName.Focus()
            Return False
        End If
        If tdbcObjectTypeID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_bo_phan_tiep_nhan"))
            tab.SelectedTab = tab.TabPages(0)
            tdbcObjectTypeID.Focus()
            Return False
        End If
        If tdbcObjectID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Bo_phan_tiep_nhan"))
            tab.SelectedTab = tab.TabPages(0)
            tdbcObjectID.Focus()
            Return False
        End If
        If tdbcSupplierOTID.Text <> "" And tdbcSupplierID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nha_cung_cap"))
            tab.SelectedTab = tab.TabPages(0)
            tdbcSupplierID.Focus()
            Return False
        End If
        If tdbcAssetAccountID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tai_khoan_tai_san"))
            tab.SelectedTab = tab.TabPages(1)
            tdbcAssetAccountID.Focus()
            Return False
        End If
        If tdbcDepAccountID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tai_khoan_khau_hao"))
            tab.SelectedTab = tab.TabPages(1)
            tdbcDepAccountID.Focus()
            Return False
        End If
        If tdbcMethodID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phuong_phap_khau_hao"))
            tab.SelectedTab = tab.TabPages(1)
            tdbcMethodID.Focus()
            Return False
        End If
        If tdbcMethodEndID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Xu_ly_khau_hao_ky_cuoi"))
            tab.SelectedTab = tab.TabPages(1)
            tdbcMethodEndID.Focus()
            Return False
        End If
        If tdbcDeprTableID.Enabled = True And tdbcDeprTableID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Bang_khau_hao"))
            tab.SelectedTab = tab.TabPages(1)
            tdbcDeprTableID.Focus()
            Return False
        End If
        If tdbcAssignmentTypeID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Kieu_phan_bo"))
            tab.SelectedTab = tab.TabPages(1)
            tdbcAssignmentTypeID.Focus()
            Return False
        End If
        If CDbl(c1dateDepPeriod.Text.Substring(3, 4)) < 1900 OrElse CDbl(c1dateDepPeriod.Text.Substring(3, 4)) > 2100 Then
            D99C0008.MsgL3(rl3("Ky_bat_dau_phai_nam_trong_khoang_tu_1900_den_2100"))
            tab.SelectedTab = tab.TabPages(1)
            c1dateDepPeriod.Focus()
            Return False
        End If
        If CDbl(c1datePeriod.Text.Substring(3, 4)) < 1900 OrElse CDbl(c1datePeriod.Text.Substring(3, 4)) > 2100 Then
            D99C0008.MsgL3(rl3("Ky_su_dung_phai_nam_trong_khoang_tu_1900_den_2100"))
            tab.SelectedTab = tab.TabPages(1)
            c1datePeriod.Focus()
            Return False
        End If
        If CDbl(c1dateTranDate.Text.Substring(3, 4)) < 1900 OrElse CDbl(c1dateTranDate.Text.Substring(3, 4)) > 2100 Then
            D99C0008.MsgL3(rl3("Ky_hinh_thanh_phai_nam_trong_khoang_tu_1900_den_2100"))
            tab.SelectedTab = tab.TabPages(1)
            c1dateTranDate.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If tdbgDetail(i, COL_EquipmentID).ToString() = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_thiet_bi"))
                tab.SelectedTab = tab.TabPages(2)
                tdbgDetail.Bookmark = i
                tdbgDetail.Col = COL_EquipmentID
                tdbgDetail.Focus()
                Return False
            End If
            If tdbgDetail(i, COL_EquipmentName).ToString() = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ten_thiet_bi"))
                tab.SelectedTab = tab.TabPages(2)
                tdbgDetail.Bookmark = i
                tdbgDetail.Col = COL_EquipmentName
                tdbgDetail.Focus()
                Return False
            End If
            If tdbgDetail(i, COL_ObjectTypeID).ToString() <> "" And tdbgDetail(i, COL_ObjectID).ToString() = "" Then
                D99C0008.MsgNotYetChoose(rl3("Phong_ban"))
                tab.SelectedTab = tab.TabPages(2)
                tdbgDetail.Bookmark = i
                tdbgDetail.Col = COL_ObjectID
                tdbgDetail.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If D99C0008.MsgAskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL = SQLInsertD02T0001()
                sSQL &= vbCrLf
                sSQL &= SQLInsertD02T4001s()
                sSQL &= vbCrLf
                sSQL &= SQLGeneral.SQLStoreD91P9106("02", "Assets", "01", txtAssetID.Text, txtAssetName.Text)
            Case EnumFormState.FormEdit
                sSQL = SQLInsertD02T0001()
                sSQL &= vbCrLf
                sSQL &= SQLInsertD02T4001s()
                sSQL &= vbCrLf
                sSQL &= SQLGeneral.SQLStoreD91P9106("02", "Assets", "02", txtAssetID.Text, txtAssetName.Text)
        End Select
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL Then
            SaveOK()
            SQLInsertD02T0004()
            _savedOK = True
            If _FormState = EnumFormState.FormAdd Then
                btnSave.Enabled = False
                btnNext.Enabled = True
                btnNext.Focus()
            ElseIf _FormState = EnumFormState.FormEdit Then
                btnSave.Enabled = True
                btnClose.Enabled = True
                btnClose.Focus()
            End If
            LoadImage()
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T0001
    '# Create User: Hoàng Đức Thịnh
    '# Create Date: 03/08/2006 10:40:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T0001() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D02T0001 Where AssetID=" & SQLString(txtAssetID.Text) & " and DivisionID=" & SQLString(gsDivisionID)
        sSQL &= vbCrLf
        sSQL &= "Insert Into D02T0001("
        sSQL &= "AssetID, AssetNameU, ShortNameU, DivisionID, AssetS1ID, "
        sSQL &= "AssetS2ID, AssetS3ID, AssetDate, AssetAccountID, DepAccountID, "
        sSQL &= "MethodID, MethodEndID, CountryID, MadeYear, SeriNo, "
        sSQL &= "Version, AssetNo, AssetTag, UseMonth, UseYear, "
        sSQL &= "TranMonth, TranYear, DepMonth, DepYear, Comment, "
        sSQL &= "ObjectTypeID, ObjectID, EmployeeID, FullNameU, Specification, "
        sSQL &= "NotesU, ConvertedAmount, DepreciatedAmount, RemainAmount, DepreciatedPeriod, "
        sSQL &= "Percentage, AmountDepreciation, ServiceLife, Index1, Index2, "
        sSQL &= "Index3, Index4, Index5, Index6, ACode01ID, "
        sSQL &= "ACode02ID, ACode03ID, ACode04ID, ACode05ID, ACode06ID, "
        sSQL &= "ACode07ID, ACode08ID, ACode09ID, ACode10ID, ToolU, "
        sSQL &= "IsCompleted, IsRevalued, IsDisposed, SetUpFrom, Disabled, "
        sSQL &= "CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, DeprTableID, "
        sSQL &= "AssignmentTypeID, UseDate, Maintainable, SupplierOTID, SupplierID, "
        sSQL &= "PurchaseDate, UnitNameU"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtAssetID.Text) & COMMA 'AssetID [KEY], VarChar[20], NOT NULL
        sSQL &= SQLStringUnicode(txtAssetName.Text, gbUnicode, True) & COMMA 'AssetName, VarChar[100], NULL
        sSQL &= SQLStringUnicode(txtShortName.Text, gbUnicode, True) & COMMA 'ShortName, VarChar[20], NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAssetS1ID.SelectedValue) & COMMA 'AssetS1ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAssetS2ID.SelectedValue) & COMMA 'AssetS2ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAssetS3ID.SelectedValue) & COMMA 'AssetS3ID, VarChar[20], NULL
        sSQL &= SQLDateSave(c1datePurchaseDate.Text) & COMMA 'AssetDate, DateTime, NULL
        sSQL &= SQLString(tdbcAssetAccountID.SelectedValue) & COMMA 'AssetAccountID, VarChar[20], NULL
        sSQL &= SQLString(tdbcDepAccountID.SelectedValue) & COMMA 'DepAccountID, VarChar[20], NULL
        sSQL &= SQLNumber(tdbcMethodID.SelectedValue) & COMMA 'MethodID, TinyInt, NOT NULL
        sSQL &= SQLNumber(tdbcMethodEndID.SelectedValue) & COMMA 'MethodEndID, TinyInt, NOT NULL
        sSQL &= SQLString(txtCountryID.Text) & COMMA 'CountryID, VarChar[20], NULL
        sSQL &= SQLNumber(txtMadeYear.Text) & COMMA 'MadeYear, Int, NULL
        sSQL &= SQLString(txtSeriNo.Text) & COMMA 'SeriNo, VarChar[20], NULL
        sSQL &= SQLString(txtVersion.Text) & COMMA 'Version, VarChar[20], NULL
        sSQL &= SQLString(txtAssetNo.Text) & COMMA 'AssetNo, VarChar[20], NULL
        sSQL &= SQLString(txtAssetTag.Text) & COMMA 'AssetTag, VarChar[100], NULL
        If c1datePeriod.Text.Length > 4 Then
            sSQL &= SQLNumber(c1datePeriod.Text.Substring(0, 2)) & COMMA 'UseMonth, TinyInt, NULL
            sSQL &= SQLNumber(c1datePeriod.Text.Substring(3, 4)) & COMMA 'UseYear, SmallInt, NULL
        Else
            sSQL &= SQLNumber("") & COMMA
            sSQL &= SQLNumber("") & COMMA
        End If
        If c1dateTranDate.Text.Length > 4 Then
            sSQL &= SQLNumber(c1dateTranDate.Text.Substring(0, 2)) & COMMA 'TranMonth, TinyInt, NULL
            sSQL &= SQLNumber(c1dateTranDate.Text.Substring(3, 4)) & COMMA 'TranYear, SmallInt, NULL
        Else
            sSQL &= SQLNumber("") & COMMA
            sSQL &= SQLNumber("") & COMMA
        End If
        If c1dateDepPeriod.Text.Length > 4 Then
            sSQL &= SQLNumber(c1dateDepPeriod.Text.Substring(0, 2)) & COMMA 'DepMonth, TinyInt, NULL
            sSQL &= SQLNumber(c1dateDepPeriod.Text.Substring(3, 4)) & COMMA 'DepYear, SmallInt, NULL
        Else
            sSQL &= SQLNumber("") & COMMA
            sSQL &= SQLNumber("") & COMMA
        End If
        sSQL &= SQLString("") & COMMA 'Comment, VarChar[50], NULL
        sSQL &= SQLString(tdbcObjectTypeID.SelectedValue) & COMMA 'ObjectTypeID, VarChar[20], NULL
        sSQL &= SQLString(tdbcObjectID.SelectedValue) & COMMA 'ObjectID, VarChar[20], NULL
        sSQL &= SQLString(tdbcEmployeeID.SelectedValue) & COMMA 'EmployeeID, VarChar[20], NULL
        sSQL &= SQLStringUnicode(txtEmployeeName.Text, gbUnicode, True) & COMMA 'FullName, VarChar[250], NULL
        sSQL &= SQLString(txtSpecification.Text) & COMMA 'Specification, VarChar[250], NULL
        sSQL &= SQLStringUnicode(txtNotes.Text, gbUnicode, True) & COMMA 'Notes, VarChar[250], NULL
        sSQL &= SQLMoney(txtConvertedAmount.Text) & COMMA 'ConvertedAmount, Money, NULL
        sSQL &= SQLMoney(txtDepreciationAmount.Text) & COMMA 'DepreciatedAmount, Money, NULL
        sSQL &= SQLMoney(txtRemainAmount.Text) & COMMA 'RemainAmount, Money, NULL
        sSQL &= SQLNumber(txtDepreciatedPeriod.Text) & COMMA 'DepreciatedPeriod, Int, NULL
        sSQL &= SQLMoney(txtPercentage.Text) & COMMA 'Percentage, Money, NULL
        sSQL &= SQLMoney(txtAmountDepreciation.Text) & COMMA 'AmountDepreciation, Money, NULL
        sSQL &= SQLNumber(txtServiceLife.Text) & COMMA 'ServiceLife, Int, NULL
        sSQL &= SQLMoney(txtIndex1.Text) & COMMA 'Index1, Money, NULL
        sSQL &= SQLMoney(txtIndex2.Text) & COMMA 'Index2, Money, NULL
        sSQL &= SQLMoney(txtIndex3.Text) & COMMA 'Index3, Money, NULL
        sSQL &= SQLMoney(txtIndex4.Text) & COMMA 'Index4, Money, NULL
        sSQL &= SQLMoney(txtIndex5.Text) & COMMA 'Index5, Money, NULL
        sSQL &= SQLMoney(txtIndex6.Text) & COMMA 'Index6, Money, NULL
        sSQL &= SQLString(tdbcAcode01ID.Text) & COMMA 'ACode01ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode02ID.Text) & COMMA 'ACode02ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode03ID.Text) & COMMA 'ACode03ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode04ID.Text) & COMMA 'ACode04ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode05ID.Text) & COMMA 'ACode05ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode06ID.Text) & COMMA 'ACode06ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode07ID.Text) & COMMA 'ACode07ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode08ID.Text) & COMMA 'ACode08ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode09ID.Text) & COMMA 'ACode09ID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAcode10ID.Text) & COMMA 'ACode10ID, VarChar[20], NULL
        sSQL &= SQLStringUnicode(txtTool.Text, gbUnicode, True) & COMMA 'Tool, VarChar[100], NULL
        sSQL &= SQLNumber("0") & COMMA 'IsCompleted, Bit, NOT NULL
        sSQL &= SQLNumber("0") & COMMA 'IsRevalued, Bit, NOT NULL
        sSQL &= SQLNumber("0") & COMMA 'IsDisposed, Bit, NOT NULL
        sSQL &= SQLString("") & COMMA 'SetUpFrom, VarChar[20], NULL
        sSQL &= SQLNumber("") & COMMA 'Disabled, Bit, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, VarChar[20], NOT NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, DateTime, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, VarChar[20], NOT NULL
        sSQL &= "GetDate()" & COMMA 'LastModifyDate, DateTime, NOT NULL
        sSQL &= SQLString(tdbcDeprTableID.SelectedValue) & COMMA 'DeprTableID, VarChar[20], NULL
        sSQL &= SQLString(tdbcAssignmentTypeID.SelectedValue) & COMMA 'AssignmentTypeID, VarChar[20], NOT NULL
        sSQL &= "NULL" & COMMA 'UseDate, DateTime, NULL
        sSQL &= SQLNumber(chkMaintainable.Checked) & COMMA 'Maintainable, TinyInt, NOT NULL
        sSQL &= SQLString(tdbcSupplierOTID.SelectedValue) & COMMA 'SupplierOTID, VarChar[20], NOT NULL
        sSQL &= SQLString(tdbcSupplierID.SelectedValue) & COMMA 'SupplierID, VarChar[20], NOT NULL
        sSQL &= SQLDateSave(c1datePurchaseDate.Value) & COMMA 'PurchaseDate, DateTime, NULL
        sSQL &= SQLStringUnicode(txtUnitName.Text, gbUnicode, True) 'UnitName, VarChar[20], NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T4001s
    '# Create User: Hoàng Đức Thịnh
    '# Create Date: 03/08/2006 11:54:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T4001s() As String
        Dim sRet As String = ""
        Dim sSQL As String = ""
        sRet &= "Delete From D02T4001 Where AssetID=" & SQLString(txtAssetID.Text) & " and divisionID=" & SQLString(gsDivisionID)
        sRet &= vbCrLf
        For i As Integer = 0 To tdbgDetail.Splits(0).Rows.Count - 2
            sSQL = ""
            sSQL &= "Insert Into D02T4001("
            sSQL &= "DivisionID, AssetID, EquipmentID, OrderNum, EquipmentNameU, "
            sSQL &= "NotesU, EquipmentQuantity, ObjectTypeID, ObjectID, EquipmentValue"
            sSQL &= ") Values ("
            sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], VarChar[20], NOT NULL
            sSQL &= SQLString(txtAssetID.Text) & COMMA 'AssetID [KEY], VarChar[20], NOT NULL
            sSQL &= SQLString(tdbgDetail(i, COL_EquipmentID)) & COMMA 'EquipmentID [KEY], VarChar[20], NOT NULL
            sSQL &= SQLNumber(tdbgDetail(i, COL_OrderNum)) & COMMA 'OrderNum, BigInt, NULL
            sSQL &= SQLStringUnicode(tdbgDetail(i, COL_EquipmentName), gbUnicode, True) & COMMA 'EquipmentName, VarChar[50], NULL
            sSQL &= SQLStringUnicode(tdbgDetail(i, COL_Notes), gbUnicode, True) & COMMA 'Notes, VarChar[250], NULL
            sSQL &= SQLMoney(tdbgDetail(i, COL_EquipmentQuantity)) & COMMA 'EquipmentQuantity, Decimal, NULL
            sSQL &= SQLString(tdbgDetail(i, COL_ObjectTypeID)) & COMMA 'ObjectTypeID, VarChar[20], NULL
            sSQL &= SQLString(tdbgDetail(i, COL_ObjectID)) & COMMA 'ObjectID, VarChar[20], NULL
            sSQL &= SQLMoney(tdbgDetail(i, COL_EquipmentValue)) 'EquipmentValue, Money, NOT NULL
            sSQL &= ")"
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        _FormState = EnumFormState.FormAdd
        tdbcAssetS1ID.SelectedValue = "-1"
        tdbcAssetS2ID.SelectedValue = "-1"
        tdbcAssetS3ID.SelectedValue = "-1"
        txtAssetID.Text = ""
        txtAssetName.Text = ""
        txtNotes.Text = ""
        tdbcObjectTypeID.SelectedValue = "-1"
        tdbcEmployeeID.SelectedValue = "-1"
        txtEmployeeName.Text = ""
        txtShortName.Text = ""
        txtAssetTag.Text = ""
        txtAssetNo.Text = ""
        tdbcSupplierOTID.SelectedValue = "-1"
        chkMaintainable.Checked = False
        tdbcAssetAccountID.SelectedValue = "-1"
        tdbcDepAccountID.SelectedValue = "-1"
        LoadAddNew()
        tdbcMethodID.SelectedValue = "-1"
        txtMethodName.Text = ""
        tdbcMethodEndID.SelectedValue = "-1"
        txtMethodEndName.Text = ""
        tdbcDeprTableID.SelectedValue = "-1"
        txtDeprTableName.Text = ""
        tdbcAssignmentTypeID.SelectedValue = "-1"
        txtAssignmentTypeName.Text = ""
        txtSpecification.Text = ""
        txtCountryID.Text = ""
        txtMadeYear.Text = ""
        txtSeriNo.Text = ""
        txtVersion.Text = ""
        txtUnitName.Text = ""
        txtTool.Text = ""
        txtIndex1.Text = ""
        txtIndex2.Text = ""
        txtIndex3.Text = ""
        txtIndex4.Text = ""
        txtIndex5.Text = ""
        txtIndex6.Text = ""
        mAssetID = ""
        LoadTDBGrid()
        tdbcAcode01ID.SelectedValue = "-1"
        tdbcAcode02ID.SelectedValue = "-1"
        tdbcAcode03ID.SelectedValue = "-1"
        tdbcAcode04ID.SelectedValue = "-1"
        tdbcAcode05ID.SelectedValue = "-1"
        tdbcAcode06ID.SelectedValue = "-1"
        tdbcAcode07ID.SelectedValue = "-1"
        tdbcAcode08ID.SelectedValue = "-1"
        tdbcAcode09ID.SelectedValue = "-1"
        tdbcAcode10ID.SelectedValue = "-1"
        picImage.Image = Nothing
        tab.SelectedTab = tab.TabPages(0)
        btnNext.Enabled = False
        btnSave.Enabled = True
        LoadAddNew()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0613
    '# Create User: Hoàng Đức Thịnh
    '# Create Date: 04/08/2006 07:54:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0613() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0613 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, VarChar[20], NOT NULL
        sSQL &= SQLString(mAssetID) 'AssetID, VarChar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9106
    '# Create User: Hoàng Đức Thịnh
    '# Create Date: 04/08/2006 09:20:24
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD91P9106() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Declare @date DateTime Set @date=(Select GetDate()) " & vbCrLf
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= "@date" & COMMA 'AuditDate, DateTime, NOT NULL
    '    sSQL &= SQLString("Assets") & COMMA 'AuditCode, VarChar[20], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, VarChar[20], NOT NULL
    '    sSQL &= SQLString("02") & COMMA 'ModuleID, VarChar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, VarChar[20], NOT NULL
    '    sSQL &= SQLString(IIf(_FormState = EnumFormState.FormAdd, "01", "02")) & COMMA 'EventID, VarChar[20], NOT NULL
    '    sSQL &= SQLString(txtAssetID.Text) & COMMA 'Desc1, VarChar[250], NOT NULL
    '    sSQL &= SQLString(txtAssetName.Text) & COMMA 'Desc2, VarChar[250], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'Desc3, VarChar[250], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'Desc4, VarChar[250], NOT NULL
    '    sSQL &= SQLString("") 'Desc5, VarChar[250], NOT NULL
    '    Return sSQL
    'End Function

    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim open As OpenFileDialog = New OpenFileDialog()
        open.CheckPathExists = True
        open.CheckPathExists = True
        open.AddExtension = False
        open.Multiselect = False
        open.Title = "Add file"
        open.InitialDirectory = "C:\"
        open.Filter = "BMP file (*.bmp)|*.bmp|JPG file (*.jpg)|*.jpg|JPEG file (*.jpeg)|*.jpeg|GIF file (*.gif)|*.gif"
        open.FilterIndex = 1
        open.ValidateNames = True
        open.RestoreDirectory = True
        Return open
    End Function

    Private Sub SQLInsertD02T0004()
        If sPathImage = "" Then Exit Sub
        Dim image As Byte()
        Dim f As FileInfo = New FileInfo(sPathImage)

        Dim fileLength As Long = f.Length
        Dim fs As FileStream = New FileStream(sPathImage, FileMode.Open, FileAccess.Read, FileShare.Read)
        image = New Byte(Convert.ToInt32(fileLength)) {}
        Dim iBytesRead As Integer = fs.Read(image, 0, Convert.ToInt32(fileLength))
        fs.Close()
        Dim sSQL As String = "Delete From D02T0004 Where AssetID=" & SQLString(txtAssetID.Text) & " and DivisionID=" & SQLString(gsDivisionID)
        sSQL &= vbCrLf
        sSQL &= "Insert Into D02T0004(AssetID, DivisionID, AssetImage, Extension) "
        sSQL &= "Values(@AssetID, @DivisionID, @AssetImage, @Extension)"
        Dim conn As SqlConnection = New SqlConnection(gsConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(sSQL, conn)

        cmd.Parameters.Add("@AssetID", SqlDbType.VarChar)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar)
        cmd.Parameters.Add("@AssetImage", SqlDbType.Image)
        cmd.Parameters.Add("@Extension", SqlDbType.VarChar)
        cmd.Parameters("@AssetID").Value = txtAssetID.Text
        cmd.Parameters("@DivisionID").Value = gsDivisionID
        cmd.Parameters("@AssetImage").Value = image
        cmd.Parameters("@Extension").Value = f.Extension
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
        cmd.Dispose()
        conn.Dispose()
    End Sub

    Private Sub LoadImage()
        Dim sSQL As String = "Select AssetImage From D02T0004 WITH(NOLOCK) Where AssetID = " & SQLString(txtAssetID.Text) & " and DivisionID=" & SQLString(gsDivisionID)
        If ReturnDataTable(sSQL).Rows.Count = 0 Then Exit Sub
        Dim conn As SqlConnection = New SqlConnection(gsConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(sSQL, conn)
        conn.Open()
        Dim image As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
        conn.Close()
        conn.Dispose()
        sSQL = "Select Extension From D02T0004 WITH(NOLOCK) Where AssetID = " & SQLString(txtAssetID.Text) & " and DivisionID=" & SQLString(gsDivisionID)
        Dim FileName As String = "Image" & Trim(ReturnScalar(sSQL))
        Dim FInfo As FileInfo = New FileInfo(FileName)
        If FInfo.Exists Then FInfo.Delete()
        Dim fs As FileStream = New FileStream(FileName, FileMode.CreateNew, FileAccess.Write)
        fs.Write(image, 0, image.Length)
        fs.Flush()
        fs.Close()
        fs.Dispose()
        picImage.Load(FileName)
        FInfo.Delete()
    End Sub

    Private Sub btnImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImage.Click
        Dim open As OpenFileDialog = GetOpenFileDialog()
        open.ShowDialog()
        sPathImage = open.FileName
        open.Dispose()
        If sPathImage <> "" Then picImage.Load(sPathImage)
    End Sub

    Private Sub btnAttact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttact.Click
        'Dim frm As New D91F4010
        'With frm
        '    .FormName = "D91F4010"
        '    .FormState = _FormState
        '    .TableName = "D02T0001" 'Truyền giá trị khác nhau từng module
        '    .Key01ID = txtAssetID.Text 'Giá trị khóa chính
        '    .Key02ID = "" 'Theo TL phân tích quy định
        '    .Key03ID = "" 'Theo TL phân tích quy định
        '    .Key04ID = "" 'Theo TL phân tích quy định
        '    .Key05ID = "" 'Theo TL phân tích quy định
        '    .ShowDialog()
        'End With

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "TableName", "D02T0001")
        SetProperties(arrPro, "Key1ID", txtAssetID.Text)
        SetProperties(arrPro, "Status", L3Byte(IIf(_FormState = EnumFormState.FormView, 0, 1)))
        SetProperties(arrPro, "bNewDatabase", False) 'Lưu database mới ATT, không phải database hiện tại
        CallFormShowDialog("D91D0340", "D91F4010", arrPro)
        btnAttact.Text = rl3("Dinh_ke_m") & Space(1) & "(" & ReturnAttachmentNumber("D02T0001", txtAssetID.Text) & ")"  'Đính kèm
    End Sub

    Private Sub btnNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNote.Click
        'Dim frm As New D91F4010
        'With frm
        '    .FormName = "D91F2010"
        '    .FormState = _FormState
        '    .TableName = "D02T0001" 'Truyền giá trị khác nhau từng module
        '    .Key01ID = txtAssetID.Text 'Giá trị khóa chính 
        '    .Key02ID = "" 'Theo TL phân tích quy định
        '    .Key03ID = "" 'Theo TL phân tích quy định
        '    .Key04ID = "" 'Theo TL phân tích quy định
        '    .Key05ID = "" 'Theo TL phân tích quy định
        '    .ShowDialog()
        'End With
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "TableName", "D02T0001")
        SetProperties(arrPro, "Key1ID", txtAssetID.Text)
        SetProperties(arrPro, "Status", L3Byte(IIf(_FormState = EnumFormState.FormView, 0, 1)))
        SetProperties(arrPro, "bNewDatabase", False) 'Lưu database mới ATT, không phải database hiện tại
        CallFormShowDialog("D91D0340", "D91F2010", arrPro)
        btnNote.Text = rL3("Ghi__chu") & Space(1) & "(" & ReturnNotesNumber("D02T0001", txtAssetID.Text) & ")"  'Ghi chú
    End Sub

    Private Sub txtAssetID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAssetID.LostFocus
        txtAssetID.Text = txtAssetID.Text.ToUpper()
    End Sub

    Private Sub txtMadeYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMadeYear.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.Number)
    End Sub

    Private Sub txtIndex1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndex1.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtIndex2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndex2.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtIndex3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndex3.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtIndex4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndex4.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtIndex5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndex5.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtIndex6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndex6.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub D02F0601_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Keys.D1 Then
            tab.SelectedTab = tab.TabPages("tab01")
            Exit Sub
        End If
        If e.Alt = True And e.KeyCode = Keys.D2 Then
            tab.SelectedTab = tab.TabPages("tab02")
            Exit Sub
        End If
        If e.Alt = True And e.KeyCode = Keys.D3 Then
            tab.SelectedTab = tab.TabPages("tab03")
            Exit Sub
        End If
        If e.Alt = True And e.KeyCode = Keys.D4 Then
            tab.SelectedTab = tab.TabPages("tab04")
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub c1dateTranDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1dateTranDate.KeyDown
        e.Handled = False
    End Sub

    Private Sub c1dateTranDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles c1dateTranDate.KeyPress
        e.Handled = False
    End Sub

    Private Sub c1dateDepPeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1dateDepPeriod.KeyDown
        e.Handled = False
    End Sub

    Private Sub c1dateDepPeriod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles c1dateDepPeriod.KeyPress
        e.Handled = False
    End Sub

    Private Sub c1datePeriod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles c1datePeriod.KeyDown
        e.Handled = False
    End Sub

    Private Sub c1datePeriod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles c1datePeriod.KeyPress
        e.Handled = False
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_danh_muc_tai_san_co_dinh_-__D02F0601") & UnicodeCaption(gbUnicode) 'ThiÕt lËp danh móc tªi s¶n cç ¢Ünh -  D02F0601
        '================================================================ 
        lblAssetS1ID.Text = rl3("Ma_tai_san") 'Mã tài sản
        lblAssetName.Text = rl3("Ten_tai_san") 'Tên tài sản
        lblObjectTypeID.Text = rl3("Bo_phan_tiep_nhan") 'Bộ phận tiếp nhận
        lblEmployeeID.Text = rl3("Nguoi_tiep_nhan") 'Người tiếp nhận
        lblShortName.Text = rl3("Ten_tat") 'Tên tắt
        lblAssetTag.Text = rl3("The_tai_san") 'Thẻ tài sản
        lblAssetNo.Text = rl3("So_hieu") 'Số hiệu
        lblSupplierOTID.Text = rl3("Nha_cung_cap") 'Nhà cung cấp
        lbltePurchaseDate.Text = rl3("Ngay_mua") 'Ngày mua
        lblConvertedAmount.Text = rl3("Nguyen_gia") 'Nguyên giá
        lblRemainAmount.Text = rl3("Gia_tri_con_lai") 'Giá trị còn lại
        lblDepreciatedPeriod.Text = rl3("Thoi_gian_da_khau_hao_(ky)") 'Thời gian đã khấu hao (kỳ)
        lblDepreciationAmount.Text = rl3("Muc_khau_hao") 'Mức khấu hao
        lblAmountDepreciation.Text = rl3("Hao_mon_luy_ke") 'Hao mòn lũy kế
        lblServiceLife.Text = rl3("Thoi_gian_khau_hao_(ky)") 'Thời gian khấu hao (kỳ)
        lblPercentage.Text = rl3("Ty_le_khau_hao") 'Tỷ lệ khấu hao
        lblMethodID.Text = rl3("Phuong_phap_KH") 'Phương pháp KH
        lblMethodEndID.Text = rl3("Xu_ly_khau_hao_ky_cuoi") 'Xử lý khấu hao kỳ cuối
        lblDeprTableID.Text = rl3("Bang_khau_hao") 'Bảng khấu hao
        lblAssignmentTypeID.Text = rl3("Kieu_phan_bo") 'Kiểu phân bổ
        lblPeriod.Text = rl3("Ky_su_dung") 'Kỳ sử dụng
        lblPeriodDep.Text = rl3("Ky_bat_dau_tinh_khau_hao") 'Kỳ bắt đầu tính khấu hao
        lblPeriodTran.Text = rl3("Ky_hinh_thanh") 'Kỳ hình thành
        lblAssetAccountID.Text = rl3("Tai_khoan_tai_san") 'Tài khoản tài sản
        lblDepAccountID.Text = rl3("Tai_khoan_khau_hao") 'Tài khoản khấu hao
        lblIndex3.Text = rl3("Chi_so") & " 3" 'Chỉ số 3
        lblIndex4.Text = rl3("Chi_so") & " 4" 'Chỉ số 4
        lblIndex5.Text = rl3("Chi_so") & " 5" 'Chỉ số 5
        lblIndex6.Text = rl3("Chi_so") & " 6" 'Chỉ số 6
        lblSpecification.Text = rl3("Dac_diem") 'Đặc điểm
        lblCountryID.Text = rl3("Nuoc_san_xuat") 'Nước sản xuất
        lblMadeYear.Text = rl3("Nam_san_xuat") 'Năm sản xuất
        lblSeriNo.Text = rl3("So_Seri") 'Số Sêri
        lblVersion.Text = rl3("The_he") 'Thế hệ
        lblTool.Text = rl3("Thiet_bi_dinh_kem") 'Thiết bị đính kèm
        lblUnitName.Text = rl3("Don_vi_tinh") 'Đơn vị tính
        lblNotes.Text = rl3("Ghi_chu") 'Ghi chú
        '================================================================ 

        btnConvertedAmount.Text = rl3("Nguyen_gia") 'Nguyên giá
        btnDepreciate.Text = rl3("Khau_hao") 'Khấu hao
        btnHistory.Text = rl3("Lich_su") 'Lịch sử
        btnNote.Text = rl3("_Ghi_chu") '&Ghi chú
        btnAttact.Text = rl3("Dinh__kem") 'Đính &kèm
        btnImage.Text = rl3("_Hinh_anh") '&Hình ảnh
       
        'btnCloseDetail.Text = rl3("X") 'X
        btnDetail.Text = rl3("Chi_tiet") 'Chi tiết
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") '&Nhập tiếp
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        chkMaintainable.Text = rl3("Bao_duong") 'Bảo dưỡng
        '================================================================ 
        grpDetail.Text = rl3("Thiet_bi_dinh_kem") 'Thiết bị đính kèm
        grpIndex.Text = rl3("Cac_chi_so") 'Các chỉ số
        '============================================================== 
        tab01.Text = "1. " & rl3("Thong_tin_quan_ly") '1. Thông tin quản lý
        tab02.Text = "2. " & rl3("Thong_tin_tai_chinh") '2. Thông tin tài chính
        tab03.Text = "3. " & rl3("Thong_tin_ky_thuat")  '3. Thông tin kỹ thuật
        tab04.Text = "4. " & rl3("Thong_tin_phan_tich")  '4. Thông tin phân tích
        '================================================================ 
        tdbcAssetS1ID.Columns("AssetS1ID").Caption = rl3("Ma") 'Mã
        tdbcAssetS1ID.Columns("AssetS1Name").Caption = rl3("Ten") 'Tên
        tdbcAssetS2ID.Columns("AssetS2ID").Caption = rl3("Ma") 'Mã
        tdbcAssetS2ID.Columns("AssetS2Name").Caption = rl3("Ten") 'Tên
        tdbcAssetS3ID.Columns("AssetS3ID").Caption = rl3("Ma") 'Mã
        tdbcAssetS3ID.Columns("AssetS3Name").Caption = rl3("Ten") 'Tên
        tdbcSupplierID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbcSupplierID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbcSupplierOTID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbcSupplierOTID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbcObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbcObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAssignmentTypeID.Columns("AssignmentTypeID").Caption = rl3("Ma") 'Mã
        tdbcAssignmentTypeID.Columns("AssignmentTypeName").Caption = rl3("Ten") 'Tên
        tdbcDeprTableID.Columns("DeprTableID").Caption = rl3("Ma") 'Mã
        tdbcDeprTableID.Columns("DeprTableName").Caption = rl3("Ten") 'Tên
        tdbcMethodEndID.Columns("MethodEndID").Caption = rl3("Ma") 'Mã
        tdbcMethodEndID.Columns("MethodEndName").Caption = rl3("Ten") 'Tên
        tdbcMethodID.Columns("MethodID").Caption = rl3("Ma") 'Mã
        tdbcMethodID.Columns("MethodName").Caption = rl3("Ten") 'Tên
        tdbcDepAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcDepAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAssetAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbcAssetAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbcAcode10ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode10ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode09ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode09ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode08ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode08ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode07ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode07ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode06ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode06ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode05ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode05ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode04ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode04ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode03ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode03ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode02ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode02ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcAcode01ID.Columns("ACodeID").Caption = rl3("Ma") 'Mã
        tdbcAcode01ID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbdObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbdObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbdObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã 
        tdbdObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbgDetail.Columns("OrderNum").Caption = rl3("STT") 'STT
        tdbgDetail.Columns("EquipmentID").Caption = rl3("Ma_thiet_bi_dinh_kem") 'Mã thiết bị đính kèm
        tdbgDetail.Columns("EquipmentName").Caption = rl3("Ten_thiet_bi_dinh_kem") 'Tên thiết bị đính kèm
        tdbgDetail.Columns("EquipmentQuantity").Caption = rl3("So_luong") 'Số lượng
        tdbgDetail.Columns("EquipmentValue").Caption = rl3("Gia_tri_") 'Giá trị
        tdbgDetail.Columns("ObjectTypeID").Caption = rl3("Loai_phong_ban") 'Loại phòng ban
        tdbgDetail.Columns("ObjectID").Caption = rL3("Ma_phong_ban") 'Mã phòng ban
        tdbgDetail.Columns("Notes").Caption = rL3("Ghi_chu") 'Ghi chú
    End Sub

    Private Sub tdbgDetail_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbgDetail.BeforeColEdit
        Select Case e.ColIndex
            Case COL_ObjectID
                LoadtdbdObjectID(tdbgDetail.Columns(COL_ObjectTypeID).Text)
        End Select
    End Sub

    Private Sub tdbgDetail_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.ComboSelect
        Select Case e.ColIndex
            Case COL_ObjectTypeID
                tdbgDetail.Columns(COL_ObjectTypeID).Text = tdbdObjectTypeID.Columns("ObjectTypeID").Value.ToString
                tdbgDetail.Columns(COL_ObjectID).Text = ""
            Case COL_ObjectID
                tdbgDetail.Columns(COL_ObjectID).Text = tdbdObjectID.Columns("ObjectID").Value.ToString
        End Select
    End Sub

    Private Sub tdbgDetail_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgDetail.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_EquipmentQuantity
                If Not IsNumeric(tdbgDetail.Columns(COL_EquipmentQuantity).Text) Then e.Cancel = True
            Case COL_EquipmentValue
                If Not IsNumeric(tdbgDetail.Columns(COL_EquipmentValue).Text) Then e.Cancel = True
            Case COL_ObjectTypeID
                If tdbgDetail.Columns(COL_ObjectTypeID).Text <> tdbdObjectTypeID.Columns("ObjectTypeID").Text Then
                    tdbgDetail.Columns(COL_ObjectTypeID).Text = ""
                End If
            Case COL_ObjectID
                If tdbgDetail.Columns(COL_ObjectID).Text <> tdbdObjectID.Columns("ObjectID").Text Then
                    tdbgDetail.Columns(COL_ObjectID).Text = ""
                End If
            Case COL_Notes
        End Select
    End Sub

#Region "Events tdbcAssetAccountID"

    Private Sub tdbcAssetAccountID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetAccountID.Close
        If tdbcAssetAccountID.FindStringExact(tdbcAssetAccountID.Text) = -1 Then tdbcAssetAccountID.Text = ""
    End Sub

    Private Sub tdbcAssetAccountID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAssetAccountID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcAssetAccountID.Text = ""
    End Sub

#End Region

#Region "Events tdbcDepAccountID"

    Private Sub tdbcDepAccountID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDepAccountID.Close
        If tdbcDepAccountID.FindStringExact(tdbcDepAccountID.Text) = -1 Then tdbcDepAccountID.Text = ""
    End Sub

    Private Sub tdbcDepAccountID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepAccountID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcDepAccountID.Text = ""
    End Sub

#End Region

#Region "Events tdbcAssignmentTypeID with txtAssignmentTypeName"

    Private Sub tdbcAssignmentTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssignmentTypeID.Close
        If tdbcAssignmentTypeID.FindStringExact(tdbcAssignmentTypeID.Text) = -1 Then
            tdbcAssignmentTypeID.Text = ""
            txtAssignmentTypeName.Text = ""
        End If
    End Sub

    Private Sub tdbcAssignmentTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssignmentTypeID.SelectedValueChanged
        txtAssignmentTypeName.Text = tdbcAssignmentTypeID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcAssignmentTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAssignmentTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcAssignmentTypeID.Text = ""
            txtAssignmentTypeName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcDeprTableID with txtDeprTableName"

    Private Sub tdbcDeprTableID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDeprTableID.Close
        If tdbcDeprTableID.FindStringExact(tdbcDeprTableID.Text) = -1 Then
            tdbcDeprTableID.Text = ""
            txtDeprTableName.Text = ""
        End If
    End Sub

    Private Sub tdbcDeprTableID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDeprTableID.SelectedValueChanged
        txtDeprTableName.Text = tdbcDeprTableID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcDeprTableID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDeprTableID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDeprTableID.Text = ""
            txtDeprTableName.Text = ""
        End If
    End Sub

#End Region

    Private Sub tdbgDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgDetail.KeyDown
        If e.Shift And e.KeyCode = Keys.Insert Then
            HotKeyShiftInsert(tdbgDetail, 0, COL_OrderNum, tdbgDetail.Columns.Count)
        End If
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbgDetail)
        End If
        If e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbgDetail)
        End If
    End Sub

    Private Sub tdbgDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgDetail.KeyUp
        If e.KeyCode = Keys.Enter Then
            HotKeyEnterGrid(tdbgDetail, COL_OrderNum, e)
        End If
    End Sub

    Private Sub tdbgDetail_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgDetail.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        If tdbgDetail.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbgDetail.Columns(COL_EquipmentName).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
        End If
    End Sub
End Class