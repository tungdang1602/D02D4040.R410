Imports System
Public Class D02F0600
	Dim report As D99C2003
	Private _formIDPermission As String = "D02F0600"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property

    Private _AssetID As String = ""
    Private _AssetName As String = ""
    Private _AuditLog As Int16 = 0
    Private dt, dtObjectID As DataTable
    Dim arrAcode(4) As Boolean
    Dim bUseACode As Boolean = False


#Region "Const of tdbg - Total of Columns: 39"
    Private Const COL_AssetID As Integer = 0             ' Mã tài sản
    Private Const COL_AssetCDVID As Integer = 1          ' Mã tài sản ĐV
    Private Const COL_AssetName As Integer = 2           ' Tên tài sản
    Private Const COL_ShortName As Integer = 3           ' Tên tắt
    Private Const COL_AssetTag As Integer = 4            ' Thẻ tài sản
    Private Const COL_ObjectID As Integer = 5            ' Mã bộ phận quản lý
    Private Const COL_ObjectName As Integer = 6          ' Tên bộ phận quản lý
    Private Const COL_AssetUserID As Integer = 7         ' Mã người tiếp nhận
    Private Const COL_FullName As Integer = 8            ' Tên người tiếp nhận
    Private Const COL_LocationID As Integer = 9          ' Vị trí
    Private Const COL_SettupPeriod As Integer = 10       ' Kỳ hình thành
    Private Const COL_ConvertedAmount As Integer = 11    ' Nguyên giá
    Private Const COL_DepreciatedAmount As Integer = 12  ' Định mức khấu hao
    Private Const COL_AmountDepreciation As Integer = 13 ' Hao mòn lũy kế
    Private Const COL_RemainAmount As Integer = 14       ' Giá trị còn lại
    Private Const COL_AssetAccountID As Integer = 15     ' TK tài sản
    Private Const COL_DepAccountID As Integer = 16       ' TK khấu hao
    Private Const COL_ServiceLife As Integer = 17        ' Số kỳ khấu hao
    Private Const COL_DepreciatedPeriod As Integer = 18  ' Số kỳ đã khấu hao
    Private Const COL_AssetPeriod As Integer = 19        ' Kỳ nhập tài sản
    Private Const COL_DivisionID As Integer = 20         ' Đơn vị
    Private Const COL_ACode01ID As Integer = 21          ' Maõ phaân tích taøi saûn 1(Maõ)
    Private Const COL_ACode01Name As Integer = 22        ' Maõ phaân tích taøi saûn 1(Teân)
    Private Const COL_ACode02ID As Integer = 23          ' Maõ phaân tích taøi saûn 2(Maõ)
    Private Const COL_ACode02Name As Integer = 24        ' Maõ phaân tích taøi saûn 2(Teân)
    Private Const COL_ACode03ID As Integer = 25          ' Maõ phaân tích taøi saûn 3(Maõ)
    Private Const COL_ACode03Name As Integer = 26        ' Maõ phaân tích taøi saûn 3(Teân)
    Private Const COL_ACode04ID As Integer = 27          ' Maõ phaân tích taøi saûn 4(Maõ)
    Private Const COL_ACode04Name As Integer = 28        ' Maõ phaân tích taøi saûn 4(Teân)
    Private Const COL_ACode05ID As Integer = 29          ' Maõ phaân tích taøi saûn 5(Maõ)
    Private Const COL_ACode05Name As Integer = 30        ' Maõ phaân tích taøi saûn 5(Teân)
    Private Const COL_IsCompleted As Integer = 31        ' Đã hình thành
    Private Const COL_IsLiquidated As Integer = 32       ' Đã thanh lý
    Private Const COL_IsChangeDivision As Integer = 33   ' Chuyển ĐV
    Private Const COL_Disabled As Integer = 34           ' KSD
    Private Const COL_CreateUserID As Integer = 35       ' CreateUserID
    Private Const COL_CreateDate As Integer = 36         ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 37   ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 38     ' LastModifyDate
#End Region


    Private dtGrid As DataTable
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Dim sFilter As New System.Text.StringBuilder()
    Dim iHeight As Integer = 0

    Dim oFilterCombo As Lemon3.Controls.FilterCombo '13/11/2019, id 126579-Thêm Filter bar cho mục Tài khoản tài sản, Bộ phận tiếp nhận, tính năng xuất Excel cho Danh mục tài sản cố định và anchor cho màn hình Danh mục tài sản cố định

#Region "Load Form"

    Private Sub D02F0600_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()

        '13/11/2019, id 126579-Thêm Filter bar cho mục Tài khoản tài sản, Bộ phận tiếp nhận, tính năng xuất Excel cho Danh mục tài sản cố định và anchor cho màn hình Danh mục tài sản cố định
        oFilterCombo = New Lemon3.Controls.FilterCombo
        oFilterCombo.CheckD91 = True
        oFilterCombo.UseFilterCombo(tdbcAssetAccountIDFrom, tdbcAssetAccountIDTo)
        oFilterCombo.AddPairObject(tdbcObjectTypeID, tdbcObjectID) 'Đă bổ sung cột Loại ĐT
        oFilterCombo.UseFilterComboObjectID()

        SetShortcutPopupMenu(Me, tbrTableToolStrip, ContextMenuStrip1)
        Loadlanguage()
        LoadTDBCombo()
        SetBackColorObligatory()
        SetColumnACode()
        gbEnabledUseFind = False
        btnManagement_Click(Nothing, Nothing)
        ResetColorGrid(tdbg, 0, 2)
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtAssetID, txtAssetID.MaxLength)
        tdbg_NumberFormat()
        CheckMenuOther()
        VisibleBySystem() '28/3/2017, Trần Hoàng Anh: id 75367-Bổ sung tính năng điều chuyển đơn vị TSCĐ
        ResetGrid(False)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_tai_san_co_dinh_-_D02F0600") & UnicodeCaption(gbUnicode) 'Danh móc tªi s¶n cç ¢Ünh - D02F0600
        '================================================================ 
        btnManagement.Text = "1. " & rl3("Thong_tin_quan_ly") '1. Thông tin quản lý
        btnFinancial.Text = "2. " & rl3("Thong_tin_tai_chinh") '2. Thông tin tài chính
        btnAnalysis.Text = "3. " & rl3("Ma_phan_tich") '3. Mã phân tích
        btnFilter.Text = rl3("Loc") & " (F5)" '&Lọc
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblAssetID.Text = rl3("Ma_tai_san_co_chua") 'Mã tài sản có chứa
        lblAssetName.Text = rl3("Ten_tai_san_co_chua") 'Tên tài sản có chứa
        lblPeriod.Text = rl3("Ky_hinh_thanh") 'Kỳ hình thành
        '================================================================ 
        grpFilter.Text = rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("AssetID").Caption = rL3("Ma_tai_san") 'Mã tài sản
        tdbg.Columns("AssetCDVID").Caption = rL3("Ma_tai_san_DV")          ' Mã tài sản ĐV
        tdbg.Columns("AssetName").Caption = rl3("Ten_tai_san") 'Tên tài sản
        tdbg.Columns("ShortName").Caption = rl3("Ten_tat") 'Tên tắt
        tdbg.Columns("AssetTag").Caption = rl3("The_tai_san") 'Thẻ tài sản
        tdbg.Columns("ObjectID").Caption = rl3("Ma_bo_phan_quan_ly") 'Mã bộ phận quản lý
        tdbg.Columns("ObjectName").Caption = rl3("Ten_bo_phan_quan_ly") 'Tên bộ phận quản lý
        tdbg.Columns("AssetUserID").Caption = rl3("Ma_nguoi_tiep_nhan") 'Mã người tiếp nhận
        tdbg.Columns("FullName").Caption = rL3("Ten_nguoi_tiep_nhan") 'Tên người tiếp nhận
        tdbg.Columns("LocationID").Caption = rL3("Vi_tri")
        tdbg.Columns("ConvertedAmount").Caption = rl3("Nguyen_gia") 'Nguyên giá
        tdbg.Columns("DepreciatedAmount").Caption = rl3("Dinh_muc_khau_hao") 'Định mức khấu hao
        tdbg.Columns("AmountDepreciation").Caption = rl3("Hao_mon_luy_ke") 'Hao mòn lũy kế
        tdbg.Columns("RemainAmount").Caption = rl3("Gia_tri_con_lai") 'Giá trị còn lại
        tdbg.Columns("AssetAccountID").Caption = rl3("TK_tai_san") 'TK tài sản
        tdbg.Columns("DepAccountID").Caption = rl3("TK_khau_hao") 'TK khấu hao
        tdbg.Columns("ServiceLife").Caption = rl3("So_ky_khau_hao") 'Số kỳ khấu hao
        tdbg.Columns("DepreciatedPeriod").Caption = rl3("So_ky_da_khau_hao") 'Số kỳ đã khấu hao
        tdbg.Columns("AssetPeriod").Caption = rl3("Ky_nhap_tai_san") 'Kỳ nhập tài sản
        tdbg.Columns("ACode01ID").Caption = rl3("Ma_phan_tich_tai_san") & " 1" 'Mã phân tích tài sản 1
        tdbg.Columns("ACode01Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("ACode02ID").Caption = rl3("Ma_phan_tich_tai_san") & " 2" 'Mã phân tích tài sản 2
        tdbg.Columns("ACode02Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("ACode03ID").Caption = rl3("Ma_phan_tich_tai_san") & " 3" 'Mã phân tích tài sản 3
        tdbg.Columns("ACode03Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("ACode04ID").Caption = rl3("Ma_phan_tich_tai_san") & " 4" 'Mã phân tích tài sản 4
        tdbg.Columns("ACode04Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("ACode05ID").Caption = rl3("Ma_phan_tich_tai_san") & " 5" 'Mã phân tích tài sản 5
        tdbg.Columns("ACode05Name").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("IsCompleted").Caption = rl3("Da_hinh_thanh") 'Đã hình thành
        tdbg.Columns("IsLiquidated").Caption = rL3("Da_thanh_ly") 'Đã thanh lý
        tdbg.Columns("IsChangeDivision").Caption = rL3("Chuyen_DV")   ' Chuyển ĐV
        tdbg.Columns("Disabled").Caption = rl3("KSD") 'Không sử dụng
        tdbg.Columns(COL_DivisionID).Caption = rl3("Don_vi")
        tdbg.Columns(COL_SettupPeriod).Caption = rl3("Ky_hinh_thanh")
        '================================================================ 
        tsmInputFixedAsset.Text = rl3("Phieu_nhap_TSCD") 'Phiếu nhập TSCĐ
        tsmListFixedAsset.Text = rl3("Danh_muc_TSCD") 'Danh mục TSCĐ
        tsbInputFixedAsset.Text = rl3("Phieu_nhap_TSCD") 'Phiếu nhập TSCĐ
        tsbListFixedAsset.Text = rl3("Danh_muc_TSCD") 'Danh mục TSCĐ
        mnsInputFixedAsset.Text = rl3("Phieu_nhap_TSCD") 'Phiếu nhập TSCĐ
        mnsListFixedAsset.Text = rl3("Danh_muc_TSCD") 'Danh mục TSCĐ

        '================================================================ 
        chkIsDisposed.Text = rL3("Hien_nhung_tai_san_da_thanh_ly") 'Hiển những tài sản đã thanh lý
        chkShowDisabled.Text = rL3("Hien_thi_danh_muc_khong_su_dung")
        '================================================================
        '================================================================ 
        lblAssetAccountID.Text = rL3("Tai_khoan_tai_san") 'Tài khoản tài sản
        lblObjectID.Text = rL3("Bo_phan_tiep_nhan") 'Bộ phận tiếp nhận
        lblTypeCodeID.Text = rL3("Loai_ma_phan_tich") 'Loại mã phân tích
        '================================================================ 
        tdbcAssetAccountIDFrom.Columns("AccountID").Caption = rL3("Ma") 'Mã
        tdbcAssetAccountIDFrom.Columns("AccountName").Caption = rL3("Ten") 'Tên
        tdbcAssetAccountIDTo.Columns("AccountID").Caption = rL3("Ma") 'Mã
        tdbcAssetAccountIDTo.Columns("AccountName").Caption = rL3("Ten") 'Tên
        tdbcObjectID.Columns("ObjectTypeID").Caption = rL3("Loai_DT") 'Loại ĐT
        tdbcObjectID.Columns("ObjectID").Caption = rL3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectName").Caption = rL3("Ten") 'Tên
        tdbcTypeCodeID.Columns("TypeCodeID").Caption = rL3("Ma") 'Mã
        tdbcTypeCodeID.Columns("Description").Caption = rL3("Ten") 'Tên
        tdbcACodeIDFrom.Columns("ACodeID").Caption = rL3("Ma") 'Mã
        tdbcACodeIDFrom.Columns("Description").Caption = rL3("Ten") 'Tên
        tdbcACodeIDTo.Columns("ACodeID").Caption = rL3("Ma") 'Mã
        tdbcACodeIDTo.Columns("Description").Caption = rL3("Ten") 'Tên

    End Sub

    '28/3/2017, Trần Hoàng Anh: id 75367-Bổ sung tính năng điều chuyển đơn vị TSCĐ
    Private Sub VisibleBySystem()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AssetCDVID).Visible = D02Systems.AllowChangeDivision
        tdbg.Splits(SPLIT0).DisplayColumns(COL_AssetCDVID).AllowSizing = D02Systems.AllowChangeDivision
        tdbg.Splits(SPLIT2).DisplayColumns(COL_IsChangeDivision).Visible = D02Systems.AllowChangeDivision
        tdbg.Splits(SPLIT2).DisplayColumns(COL_IsChangeDivision).AllowSizing = D02Systems.AllowChangeDivision
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        Dim sSQL As String = SQLStoreD02P0612()
        dtGrid = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =’’
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
        If sKey <> "" Then
            Dim dt1 As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt1.Select(tdbg.Columns(COL_AssetID).DataField & "=" & SQLString(sKey), dt1.DefaultView.Sort)
            If dr.Length > 0 Then tdbg.Row = dt1.Rows.IndexOf(dr(0)) 'dùng tdbg.Bookmark có thể không đúng
            If Not tdbg.Focused Then tdbg.Focus() 'Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
        End If
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If Not chkShowDisabled.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "Disabled =0"
        End If
        If Not chkIsDisposed.Checked Then
            If strFind <> "" Then strFind &= " And "
            strFind &= "IsLiquidated = 0"
        End If
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid(Optional bCalFooter As Boolean = True)
        CheckMenuOther()
        If bCalFooter Then
            FooterSumNew(tdbg, COL_ConvertedAmount, COL_DepreciatedAmount, COL_AmountDepreciation, COL_RemainAmount)
            FooterTotalGrid(tdbg, COL_AssetID)
        End If
    End Sub

    Private Sub CheckMenuOther()
        CheckMenu(Me.Name, tbrTableToolStrip, tdbg.RowCount, gbEnabledUseFind, False, ContextMenuStrip1)
        tsmInputFixedAsset.Enabled = tdbg.RowCount > 0
        tsmListFixedAsset.Enabled = tdbg.RowCount > 0
        mnsInputFixedAsset.Enabled = tdbg.RowCount > 0
        mnsListFixedAsset.Enabled = tdbg.RowCount > 0
        tsbInputFixedAsset.Enabled = tdbg.RowCount > 0
        tsbListFixedAsset.Enabled = tdbg.RowCount > 0

    End Sub

    Private Sub D02F0600_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
            Exit Sub
        End If
        If e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
            Exit Sub
        End If
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.NumPad1, Keys.D1
                    If btnManagement.Enabled = True Then
                        btnManagement_Click(Nothing, e)
                    End If
                    Exit Sub
                Case Keys.NumPad2, Keys.D2
                    If btnFinancial.Enabled = True Then
                        btnFinancial_Click(Nothing, e)
                    End If
                    Exit Sub
                Case Keys.NumPad3, Keys.D3
                    If btnAnalysis.Enabled = True Then
                        btnAnalysis_Click(Nothing, e)
                    End If
                    Exit Sub
            End Select
        End If
    End Sub

    'Private Sub tdbg_NumberFormat()
    '    tdbg.Columns(COL_ConvertedAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    '    tdbg.Columns(COL_DepreciatedAmount).NumberFormat = DxxFormat.DecimalPlaces
    '    tdbg.Columns(COL_AmountDepreciation).NumberFormat = DxxFormat.DecimalPlaces
    '    tdbg.Columns(COL_RemainAmount).NumberFormat = DxxFormat.DecimalPlaces
    '    tdbg.Columns(COL_ServiceLife).NumberFormat = DxxFormat.DefaultNumber2
    '    tdbg.Columns(COL_DepreciatedPeriod).NumberFormat = DxxFormat.DefaultNumber2
    'End Sub

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_ConvertedAmount).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_DepreciatedAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_AmountDepreciation).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_RemainAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_ServiceLife).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_DepreciatedPeriod).DataField, DxxFormat.DefaultNumber2, 28, 8)
        InputNumber(tdbg, arr)
    End Sub

#End Region
    'Private Sub Reload_tdbg()
    '    ResetColorGrid(tdbg, SPLIT0, SPLIT2)
    '    ResetSplitDividerSize(tdbg)
    '    LoadTDBGrid()
    '    tdbg_NumberFormat()
    '    btnManagement_Click(Nothing, Nothing)
    '    Assign_AuditLog()
    'End Sub

    Private Sub Assign_AuditLog()
        Dim sSQL As String = "Select Audit From D91T9200 WITH(NOLOCK) Where AuditCode='Assets'"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            _AuditLog = CType(dt.Rows(0)("Audit"), Int16)
        Else
            _AuditLog = 0
        End If
    End Sub


    'Private Sub LoadTDBGrid()
    '    Dim sSQL As String = ""
    '    sSQL = SQLStoreD02P0612()
    '    dt = ReturnDataTable(sSQL)
    '    LoadDataSource(tdbg, dt)
    '    SetColumnACode()
    '    CheckMenu(PARA_FormIDPermission, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    '    CheckMenuOther()
    '    LoadFooter()
    'End Sub

    Private Sub SetColumnACode()
        Dim sSQL As String
        sSQL = "SELECT * FROM D02T0040 WITH(NOLOCK) "
        sSQL &= "WHERE Type = 'A' AND RIGHT(TypeCodeID, 2) IN ('01','02','03','04','05') "
        sSQL &= "ORDER BY TypeCodeID "
        Dim dtACode As DataTable
        dtACode = ReturnDataTable(sSQL)
        If dtACode.Rows.Count > 0 Then
            For i As Integer = 0 To 4
                tdbg.Splits(1).DisplayColumns(COL_ACode01ID + i * 2).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Splits(1).DisplayColumns(COL_ACode01ID + i * 2 + 1).HeadingStyle.Font = FontUnicode(gbUnicode)
                If gsLanguage = "84" Then
                    tdbg.Columns(COL_ACode01ID + i * 2).Caption = dtACode.Rows(i).Item(IIf(gbUnicode, "VieTypeCodeNameU", "VieTypeCodeName").ToString).ToString & " (" & IIf(gbUnicode, ConvertVniToUnicode(rl3("Ma_VNI")), rl3("Ma_VNI")).ToString & ")"
                    tdbg.Columns(COL_ACode01ID + i * 2 + 1).Caption = dtACode.Rows(i).Item(IIf(gbUnicode, "VieTypeCodeNameU", "VieTypeCodeName").ToString).ToString & " (" & IIf(gbUnicode, ConvertVniToUnicode(rl3("Ten_VNI")), rl3("Ten_VNI")).ToString & ")"
                Else
                    tdbg.Columns(COL_ACode01ID + i * 2).Caption = dtACode.Rows(i).Item(IIf(gbUnicode, "EngTypeCodeNameU", "EngTypeCodeName").ToString).ToString & " (" & IIf(gbUnicode, ConvertVniToUnicode(rl3("Ma_VNI")), rl3("Ma_VNI")).ToString & ")"
                    tdbg.Columns(COL_ACode01ID + i * 2 + 1).Caption = dtACode.Rows(i).Item(IIf(gbUnicode, "EngTypeCodeNameU", "EngTypeCodeName").ToString).ToString & " (" & IIf(gbUnicode, ConvertVniToUnicode(rl3("Ten_VNI")), rl3("Ten_VNI")).ToString & ")"
                End If
                arrAcode(i) = Not CType(dtACode.Rows(i).Item("Disabled").ToString, Boolean)
                If Not bUseACode And Not CType(dtACode.Rows(i).Item("Disabled").ToString, Boolean) = True Then
                    bUseACode = True
                End If
            Next
        End If
    End Sub

#Region "TDBG Event"

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If iHeight <= tdbg.Splits(0).ColumnCaptionHeight Then Exit Sub
        If tdbg.FilterActive Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If tsbEdit.Enabled Then
            tsbEdit_Click(sender, Nothing)
        ElseIf tsbView.Enabled Then
            tsbView_Click(sender, Nothing)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbg.MouseClick
        iHeight = e.Location.Y
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            tdbg_DoubleClick(Nothing, Nothing)
        End If
        HotKeyCtrlVOnGrid(tdbg, e)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_IsCompleted, COL_IsLiquidated, COL_Disabled
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_ConvertedAmount, COL_DepreciatedAmount, COL_AmountDepreciation, COL_RemainAmount, COL_AssetAccountID, COL_DepAccountID, COL_ServiceLife, COL_DepreciatedPeriod
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

#End Region


#Region "Menu Click"


    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click, tsmAdd.Click, mnsAdd.Click
        Dim f As New D02F0601()
        f.AssetID = ""
        f.FormState = EnumFormState.FormAdd
        f.ShowDialog()
        '  Reload_tdbg()
        ' SetCurrentRow(tdbg, COL_AssetID, f.AssetID_D02F0601)
        If f.SavedOK Then LoadTDBGrid(True, f.AssetID_D02F0601)
        f.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click, tsmEdit.Click, mnsEdit.Click
        Dim f As New D02F0601()
        f.AssetID = tdbg.Columns(COL_AssetID).Text
        f.FormState = EnumFormState.FormEdit
        f.ShowDialog()
        If f.SavedOK Then
            LoadTDBGrid(False, tdbg.Columns(COL_AssetID).Text)
        End If
        f.Dispose()
    End Sub

    Private Sub tsbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbView.Click, tsmView.Click, mnsView.Click
        Dim f As New D02F0601()
        f.AssetID = tdbg.Columns(COL_AssetID).Text
        f.FormState = EnumFormState.FormView
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Function AllowDelete() As Boolean
        Return CheckStore(SQLStoreD02P0010())
    End Function

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowDelete() Then Exit Sub
        _AssetID = tdbg.Columns(COL_AssetID).Text
        _AssetName = tdbg.Columns(COL_AssetName).Text
        Dim iCurrentRow As Integer = tdbg.Row
        Dim sSQL As String = ""
        sSQL = "Delete D02T0001 Where AssetID=" & SQLString(_AssetID)
        sSQL &= vbCrLf
        sSQL &= "Delete D02T4001 Where DivisionID=" & SQLString(gsDivisionID) & " And AssetID=" & SQLString(_AssetID)
        sSQL &= vbCrLf
        sSQL &= "Delete D02T0004 Where AssetID=" & SQLString(_AssetID) & " And DivisionID=" & SQLString(gsDivisionID)
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        If bRunSQL And _AuditLog = 1 Then
            'sSQL = SQLStoreD91P9106()
            ExecuteSQL(SQLGeneral.SQLStoreD91P9106("02", "Assets", "03", tdbg.Columns(COL_AssetID).Text, tdbg.Columns(COL_AssetName).Text))
            DeleteGridEvent(tdbg, dtGrid, gbEnabledUseFind)
            DeleteOK()
            ' Reload_tdbg()
            If tdbg.RowCount > 1 Then tdbg.Row = iCurrentRow - 1
        Else
            D99C0008.MsgCanNotDelete()
        End If
    End Sub

#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Dim dtCaptionCols As DataTable
    'Cần sửa Tìm kiếm như sau:
    'Bỏ sự kiện Finder_FindClick.
    'Sửa tham số Me.Name -> Me
    'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
    'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
    'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property


    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        'Dim sSQL As String = ""
        'gbEnabledUseFind = True
        'sSQL = "Select * From D02V1234 "
        'sSQL &= "Where FormID = " & SQLString(Me.Name) & " And Mode = '01' And Language = " & SQLString(gsLanguage)
        'ShowFindDialogClient(Finder, sSQL, Me, gbUnicode)

        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        CreateTableCaption()
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me, tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub
    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub tsbInputFixedAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbInputFixedAsset.Click, tsmInputFixedAsset.Click, mnsInputFixedAsset.Click
        'Dim report As New D99C1003
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        '************************************()
        Me.Cursor = Cursors.WaitCursor
        Dim sReportName As String = "D02R3011"
        Dim sReportCaption As String = rL3("Phieu_nhap_TSCDF")
        Dim conn As New SqlConnection(gsConnectionString)
        With report
            .OpenConnection(conn)
            Dim sSQLSub As String = "Select Top 1 * From D91T0025 WITH(NOLOCK)"
            Dim sSubReport As String = "D02R0000"
            UnicodeSubReport(sSubReport, sSQLSub, gsDivisionID, gbUnicode)
            .AddSub(sSQLSub, sSubReport & ".rpt")
            Dim sSQL As String = SQLStoreD02P3013() ' SQLStringD02R3011()
            .AddMain(sSQL)
            'Dim sLang As String = ""
            Dim sPathReport As String = ""
            ' sLang = GetSetting("D02", "Options", "nRPLang", "0")
            'Select Case Trim(sLang)
            '    Case "0"
            '        sPathReport = Application.StartupPath & "\XReports\" & sReportName & ".rpt"
            '    Case "1"
            '        sPathReport = Application.StartupPath & "\XReports\VE-XReports\" & sReportName & ".rpt"
            '    Case "2"
            '        sPathReport = Application.StartupPath & "\XReports\E-XReports\" & sReportName & ".rpt"
            'End Select
            sPathReport = UnicodeGetReportPath(gbUnicode, D02Options.ReportLanguage, "") & sReportName & ".rpt"
            .PrintReport(sPathReport, sReportCaption & " - " & sReportName)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbListFixedAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListFixedAsset.Click, tsmListFixedAsset.Click, mnsListFixedAsset.Click
        'Dim report As New D99C1003
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        'If Not AllowNewD99C2003(report, Me) Then Exit Sub
        '************************************()
        Me.Cursor = Cursors.WaitCursor
        '        Dim conn As New SqlConnection(gsConnectionString)
        '        Dim sReportName As String = "D02R3020"
        '        Dim sReportCaption As String = rL3("Danh_sach_TSCD")
        '        Dim sSQL1 As String = SQLStoreD02P3020()
        '        ExecuteSQL(sSQL1)
        '        With report
        '            .OpenConnection(conn)
        '            Dim sSQLSub As String = "Select Top 1 * From D91T0025 WITH(NOLOCK)"
        '            Dim sSubReport As String = "D02R0000"
        '            UnicodeSubReport(sSubReport, sSQLSub, gsDivisionID, gbUnicode)
        '            .AddSub(sSQLSub, sSubReport & ".rpt")
        '            Dim sSQL As String = ""
        '            Dim sSQLList As String = ""
        '            For i As Integer = 0 To tdbg.RowCount - 1
        '                sSQLList &= SQLString(tdbg(i, COL_AssetID).ToString) & ", "
        '            Next
        '            sSQLList = sSQLList.Substring(0, sSQLList.Length - 2)
        '            sSQL &= "Select * From D02V3020 Where UserID=" & SQLString(gsUserID) & vbCrLf
        '            sSQL &= "And AssetID In (" & sSQLList & ") Order by GroupID, AssetID"
        '            sSQL &= vbCrLf & SQLStoreD02P3020()
        '            .AddMain(sSQL)
        '            Dim sPathReport As String = ""
        '            sPathReport = UnicodeGetReportPath(gbUnicode, D02Options.ReportLanguage, "") & sReportName & ".rpt"
        '            .PrintReport(sPathReport, sReportCaption & " - " & sReportName)
        '        End With
        Print(Me, Me.Name)
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub printReport(ByVal sReportName As String, ByVal sReportPath As String, ByVal sReportCaption As String, ByVal sSQL As String)
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        Dim conn As New SqlConnection(gsConnectionString)
        With report
            .OpenConnection(conn)
            Dim sSQLSub As String = "Select Top 1 * From D91T0025 WITH(NOLOCK)"
            Dim sSubReport As String = "D02R0000"
            UnicodeSubReport(sSubReport, sSQLSub, gsDivisionID, gbUnicode)
            .AddSub(sSQLSub, sSubReport & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption & " - " & sReportName)
        End With
    End Sub

    Private Sub Print(ByVal form As Form, ByVal sReportTypeID As String, Optional ByVal ModuleID As String = "02")
        Dim sReportName As String = "D02R3020"
        Dim sReportPath As String = ""
        Dim sReportTitle As String = ""
        Dim sCustomReport As String = ""
        Dim file As String = D99D0541.GetReportPathNew(ModuleID, sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)
        If sReportName = "" Then Exit Sub

        Dim sSQL1 As String = SQLStoreD02P3020()
        ExecuteSQL(sSQL1)

        Dim sSQL As String = ""
        Dim sSQLList As String = ""
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQLList &= SQLString(tdbg(i, COL_AssetID).ToString) & ", "
        Next
        sSQLList = sSQLList.Substring(0, sSQLList.Length - 2)
        sSQL &= "Select * From D02V3020 Where UserID=" & SQLString(gsUserID) & vbCrLf
        sSQL &= "And AssetID In (" & sSQLList & ") Order by GroupID, AssetID"
        sSQL &= vbCrLf & SQLStoreD02P3020()
        Select Case file.ToLower
            Case "rpt"
                printReport(sReportName, sReportPath, sReportTitle, sSQL)
            Case Else
                D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, file, sSQL)
        End Select
    End Sub

#End Region

#End Region
    'Private Sub LoadFooter()
    '    tdbg.Columns(COL_ConvertedAmount).FooterText = Format(Sum(COL_ConvertedAmount, tdbg), DxxFormat.D90_ConvertedDecimals)
    '    tdbg.Columns(COL_DepreciatedAmount).FooterText = Format(Sum(COL_DepreciatedAmount, tdbg), DxxFormat.DecimalPlaces)
    '    tdbg.Columns(COL_AmountDepreciation).FooterText = Format(Sum(COL_AmountDepreciation, tdbg), DxxFormat.DecimalPlaces)
    '    tdbg.Columns(COL_RemainAmount).FooterText = Format(Sum(COL_RemainAmount, tdbg), DxxFormat.DecimalPlaces)
    '    tdbg.Columns(COL_AssetID).FooterText = TongCong(tdbg.RowCount)
    'End Sub

#Region " Button Click "


    Private Sub btnManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagement.Click
        tdbg.Focus()
        VisibleColumns(1)
    End Sub

    Private Sub btnFinancial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinancial.Click
        tdbg.Focus()
        VisibleColumns(2)
    End Sub

    Private Sub btnAnalysis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnalysis.Click
        tdbg.Focus()
        VisibleColumns(3)
    End Sub

    Private Sub VisibleColumns(ByVal btn As Integer)
        Select Case btn
            Case 1
                btnManagement.Enabled = False : btnFinancial.Enabled = True : btnAnalysis.Enabled = bUseACode
                With tdbg.Splits(1).DisplayColumns
                    .Item(COL_ShortName).Visible = True : .Item(COL_AssetTag).Visible = True : .Item(COL_ObjectID).Visible = True : .Item(COL_ObjectName).Visible = True : .Item(COL_AssetUserID).Visible = True : .Item(COL_FullName).Visible = True
                    .Item(COL_ConvertedAmount).Visible = False : .Item(COL_DepreciatedAmount).Visible = False : .Item(COL_AmountDepreciation).Visible = False : .Item(COL_RemainAmount).Visible = False : .Item(COL_AssetAccountID).Visible = False : .Item(COL_DepAccountID).Visible = False : .Item(COL_ServiceLife).Visible = False : .Item(COL_DepreciatedPeriod).Visible = False : .Item(COL_AssetPeriod).Visible = False : .Item(COL_DivisionID).Visible = False
                    .Item(COL_ACode01ID).Visible = False : .Item(COL_ACode02ID).Visible = False : .Item(COL_ACode03ID).Visible = False : .Item(COL_ACode04ID).Visible = False : .Item(COL_ACode05ID).Visible = False
                    .Item(COL_ACode01Name).Visible = False : .Item(COL_ACode02Name).Visible = False : .Item(COL_ACode03Name).Visible = False : .Item(COL_ACode04Name).Visible = False : .Item(COL_ACode05Name).Visible = False : .Item(COL_LocationID).Visible = True
                End With
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_ShortName
            Case 2
                btnManagement.Enabled = True : btnFinancial.Enabled = False : btnAnalysis.Enabled = bUseACode
                With tdbg.Splits(1).DisplayColumns
                    .Item(COL_ShortName).Visible = False : .Item(COL_AssetTag).Visible = False : .Item(COL_ObjectID).Visible = False : .Item(COL_ObjectName).Visible = False : .Item(COL_AssetUserID).Visible = False : .Item(COL_FullName).Visible = False
                    .Item(COL_ConvertedAmount).Visible = True : .Item(COL_DepreciatedAmount).Visible = True : .Item(COL_AmountDepreciation).Visible = True : .Item(COL_RemainAmount).Visible = True : .Item(COL_AssetAccountID).Visible = True : .Item(COL_DepAccountID).Visible = True : .Item(COL_ServiceLife).Visible = True : .Item(COL_DepreciatedPeriod).Visible = True : .Item(COL_AssetPeriod).Visible = True : .Item(COL_DivisionID).Visible = True
                    .Item(COL_ACode01ID).Visible = False : .Item(COL_ACode02ID).Visible = False : .Item(COL_ACode03ID).Visible = False : .Item(COL_ACode04ID).Visible = False : .Item(COL_ACode05ID).Visible = False
                    .Item(COL_ACode01Name).Visible = False : .Item(COL_ACode02Name).Visible = False : .Item(COL_ACode03Name).Visible = False : .Item(COL_ACode04Name).Visible = False : .Item(COL_ACode05Name).Visible = False : .Item(COL_LocationID).Visible = False
                End With
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_ConvertedAmount
            Case 3
                btnManagement.Enabled = True : btnFinancial.Enabled = True : btnAnalysis.Enabled = False
                With tdbg.Splits(1).DisplayColumns
                    .Item(COL_ShortName).Visible = False : .Item(COL_AssetTag).Visible = False : .Item(COL_ObjectID).Visible = False : .Item(COL_ObjectName).Visible = False : .Item(COL_AssetUserID).Visible = False : .Item(COL_FullName).Visible = False : .Item(COL_LocationID).Visible = False
                    .Item(COL_ConvertedAmount).Visible = False : .Item(COL_DepreciatedAmount).Visible = False : .Item(COL_AmountDepreciation).Visible = False : .Item(COL_RemainAmount).Visible = False : .Item(COL_AssetAccountID).Visible = False : .Item(COL_DepAccountID).Visible = False : .Item(COL_ServiceLife).Visible = False : .Item(COL_DepreciatedPeriod).Visible = False : .Item(COL_AssetPeriod).Visible = False : .Item(COL_DivisionID).Visible = False
                    For i As Integer = 0 To 4
                        .Item(COL_ACode01ID + i * 2).Visible = arrAcode(i)
                        .Item(COL_ACode01ID + i * 2 + 1).Visible = arrAcode(i)
                    Next
                End With
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_ACode01ID
        End Select
    End Sub
#End Region

#Region "SQL String "


    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD02P0612
    ''# Create User: HOANG DUC THINH
    ''# Create Date: 18/07/2006 10:40:24
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD02P0612() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D02P0612 "
    '    sSQL &= SQLString(gsDivisionID) & COMMA
    '    sSQL &= SQLNumber(giTranMonth) & COMMA
    '    sSQL &= SQLNumber(giTranYear) & COMMA
    '    sSQL &= SQLString(sFind) & COMMA
    '    sSQL &= SQLNumber(0) & COMMA
    '    sSQL &= SQLString("") & COMMA
    '    sSQL &= SQLString("") & COMMA
    '    sSQL &= SQLNumber(gbUnicode)
    '    Return sSQL
    'End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0612
    '# Created User: HUỲNH KHANH
    '# Created Date: 19/05/2015 06:39:25
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0612() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Loc du lieu" & vbCrlf)
        sSQL &= "Exec D02P0612 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString("") & COMMA 'strFind, varchar[8000], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(txtAssetID.Text) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(txtAssetName.Text) & COMMA 'AssetName, nvarchar, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcMonthFrom, "TranMonth")) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcMonthFrom, "TranYear")) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcMonthTo, "TranMonth")) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcMonthTo, "TranYear")) & COMMA 'TranYear, int, NOT NULL
        sSQL &= "N" & SQLString(strDivisionID) & COMMA 'strFindDivisionID, nvarchar, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAssetAccountIDFrom)) & COMMA 'AssetAccountIDFrom, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAssetAccountIDTo)) & COMMA 'AssetAccountIDTo, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcTypeCodeID)) & COMMA 'TypeCodeID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcACodeIDFrom)) & COMMA 'AcodeIDFrom, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcACodeIDTo)) & COMMA 'AcodeIDTo, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcObjectTypeID)) & COMMA 'ObjectTypeID, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcObjectID)) 'ObjectID, varchar[50], NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P0010
    '# Create User: HOANG DUC THINH
    '# Create Date: 19/07/2006 7:40:24
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P0010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P0010 "
        sSQL &= SQLString(_AssetID)
        Return sSQL
    End Function


    'Private Function SQLStoreD91P9106() As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Declare @date DateTime Set @date=(Select GetDate()) " & vbCrLf
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= "@date" & COMMA 'AuditDate, DateTime, NOT NULL
    '    sSQL &= SQLString("Assets") & COMMA 'AuditCode, VarChar[20], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, VarChar[20], NOT NULL
    '    sSQL &= SQLString("02") & COMMA 'ModuleID, VarChar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, VarChar[20], NOT NULL
    '    sSQL &= SQLString("03") & COMMA 'EventID, VarChar[20], NOT NULL
    '    sSQL &= SQLString(_AssetID) & COMMA 'Desc1, VarChar[250], NOT NULL
    '    sSQL &= SQLString(_AssetName) & COMMA 'Desc2, VarChar[250], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'Desc3, VarChar[250], NOT NULL
    '    sSQL &= SQLString("") & COMMA 'Desc4, VarChar[250], NOT NULL
    '    sSQL &= SQLString("") 'Desc5, VarChar[250], NOT NULL
    '    Return sSQL
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P3013
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 20/03/2012 08:21:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: In phiếu nhập tài sản cố định
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P3013() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P3013 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_AssetID).Text) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'FromMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= "N" & SQLString(strDivisionID)
        Return sSQL
    End Function


    'Private Function SQLStringD02R3011() As String
    '    Dim sSQL As String = ""
    '    sSQL = "Select D02V1111.SupplierName" & UnicodeJoin(gbUnicode) & " as SupplierName, D02V1111.OBJECTADDRESS" & UnicodeJoin(gbUnicode) & " as OBJECTADDRESS,"
    '    sSQL &= "D02V1111.TELNO, D02V1111.VOUCHERNO,"
    '    sSQL &= "D02V1111.VOUCHERDATE, D02V1111.SERINO,"
    '    sSQL &= "D02V1111.Description" & UnicodeJoin(gbUnicode) & " as Description, D02V1111.RECIEVIEDDIVISION" & UnicodeJoin(gbUnicode) & " as RECIEVIEDDIVISION,"
    '    sSQL &= "D02V1111.AssetID, D02V1111.AssetName" & UnicodeJoin(gbUnicode) & " as AssetName,"
    '    sSQL &= "D02V1111.CONVERTEDAMOUNT, D02V1111.TAXAMOUNT "
    '    sSQL &= "From D02V1111 D02V1111 "
    '    sSQL &= "Where DivisionID=" & SQLString(gsDivisionID)
    '    sSQL &= " And TranMonth + TranYear * 100 <= " & giTranMonth + giTranYear * 100
    '    sSQL &= " And AssetID=" & SQLString(tdbg.Columns(COL_AssetID).Text)
    '    sSQL &= " Order by D02V1111.SupplierName Asc"
    '    Return sSQL
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P3020
    '# Create User: Hoàng Đức Thịnh
    '# Create Date: 07/08/2006 03:55:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: In Danh mục TSCĐ
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P3020() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P3020 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, VarChar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'GroupTypeID, VarChar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'TypeCodeID, VarChar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'FromAssetID, VarChar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'ToAssetID, VarChar[20], NOT NULL
        sSQL &= SQLMoney(ReturnValueC1Combo(tdbcMonthFrom, "TranMonth")) & COMMA 'FromMonth, Money, NOT NULL
        sSQL &= SQLMoney(ReturnValueC1Combo(tdbcMonthFrom, "TranYear")) & COMMA 'FromYear, Money, NOT NULL
        sSQL &= SQLMoney(ReturnValueC1Combo(tdbcMonthTo, "TranMonth")) & COMMA 'ToMonth, Money, NOT NULL
        sSQL &= SQLMoney(ReturnValueC1Combo(tdbcMonthTo, "TranYear")) & COMMA 'ToYear, Money, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcDivisionID)) & COMMA 'DivisionID, VarChar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'ReportTypeID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'ReportID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= "0,0,1,0,'%','%','%','%',"
        sSQL &= "N" & SQLString(strDivisionID)
        Return sSQL
    End Function
#End Region

    'Private Sub chkShowDisabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
    '    If dtGrid Is Nothing Then Exit Sub
    '    ReLoadTDBGrid()
    'End Sub
    Dim dtPeriod, dtCodeID As DataTable


    Private Sub LoadTDBCombo()
        'Load tdbcMonthFrom
        dtPeriod = LoadTablePeriodReport("D02")
        'Load tdbcDivisionID
        LoadCboDivisionIDAll(tdbcDivisionID, D02, , gbUnicode)
        tdbcDivisionID.Text = gsDivisionID

        Dim sSQL As String = ""
        sSQL = "-- Combo tai khoan tai san" & vbCrLf
        sSQL &= "SELECT		0 AS DisplayOrder, '%' AS AccountID, " & AllName & "  AS AccountName  "
        sSQL &= " UNION ALL"
        sSQL &= " SELECT 	0 AS DisplayOrder , AccountID,  AccountName" & UnicodeJoin(gbUnicode) & "  AS AccountName  "
        sSQL &= " FROM		D90T0001 WITH(NOLOCK) "
        sSQL &= " WHERE		GroupID='7' "
        sSQL &= " AND AccountStatus = 0"
        sSQL &= " AND OffAccount = 0"
        sSQL &= " AND Disabled = 0"

        Dim dtTable As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcAssetAccountIDFrom, dtTable, gbUnicode)
        tdbcAssetAccountIDFrom.SelectedValue = "%"
        LoadDataSource(tdbcAssetAccountIDTo, dtTable.DefaultView.ToTable, gbUnicode)
        tdbcAssetAccountIDTo.SelectedValue = "%"

        'sSQL = "--Combo bo phan tiep nhan" & vbCrLf
        'sSQL &= "SELECT  		0 AS DisplayOrder, '%' AS ObjectID, " & AllName & " AS ObjectName"
        'sSQL &= " UNION ALL"
        'sSQL &= " SELECT 	DISTINCT 0 AS DisplayOrder,Object.ObjectID,ObjectName" & UnicodeJoin(gbUnicode) & "  AS ObjectName"
        'sSQL &= " FROM 		Object WITH(NOLOCK)"
        'sSQL &= " INNER JOIN	D02T0001 T1 WITH(NOLOCK) ON T1.ObjectID = Object.ObjectID"
        'sSQL &= " WHERE Object.Disabled = 0"
        'LoadDataSource(tdbcObjectID, sSQL, gbUnicode)
        'tdbcObjectID.SelectedValue = "%"

        'Load tdbcObjectID
        Using obj As Lemon3.Data.LoadData.ObjectID = New Lemon3.Data.LoadData.ObjectID
            obj.UnionAll = Lemon3.Data.eUnionAll.All
            obj.LoadObjectID(tdbcObjectID, dtObjectID)
        End Using

        LoadObjectTypeIDAll(tdbcObjectTypeID, gbUnicode)
        tdbcObjectTypeID.SelectedValue = "%"
        tdbcObjectID.Text = "%"

        sSQL = "--Combo ma phan tich" & vbCrLf
        sSQL &= "SELECT 	'%' AS AcodeID," & AllName & "  AS Description, '%' AS TypeCodeID,0 AS DisplayOrder "
        sSQL &= " UNION ALL"
        sSQL &= " SELECT  AcodeID,Description" & UnicodeJoin(gbUnicode) & " AS Description,TypeCodeID, 1 AS DisplayOrder"
        sSQL &= " FROM	D02T0041 WITH(NOLOCK)"
        sSQL &= " WHERE  Type = 'A'"
        sSQL &= " ORDER BY DisplayOrder, TypeCodeID, AcodeID"
        dtCodeID = ReturnDataTable(sSQL)

        sSQL = "--Combo loai ma phan tich" & vbCrLf
        sSQL &= " SELECT 	0 AS DisplayOrder, '%' AS TypeCodeID, " & AllName & " AS Description"
        sSQL &= " UNION ALL"
        sSQL &= " SELECT 	1 AS DisplayOrder,TypeCodeID,VieTypeCodeName" & UnicodeJoin(gbUnicode) & " AS Description "
        sSQL &= " FROM   	D02T0040 WITH(NOLOCK) "
        sSQL &= " WHERE 	Type = 'A' AND Disabled = 0 "
        sSQL &= " ORDER BY TypeCodeID"
        LoadDataSource(tdbcTypeCodeID, sSQL, gbUnicode)
        tdbcTypeCodeID.SelectedValue = "%"

        
        LoadACodeID(ReturnValueC1Combo(tdbcTypeCodeID))

       
    End Sub

    Private Sub LoadACodeID(ByVal sTypeCodeID As String)
        Dim dtTable As DataTable
        If sTypeCodeID <> "%" Then
            dtTable = ReturnTableFilter(dtCodeID, "TypeCodeID = " & SQLString(sTypeCodeID), True)
        Else
            dtTable = dtCodeID
        End If
        LoadDataSource(tdbcACodeIDFrom, dtTable, gbUnicode)
        tdbcACodeIDFrom.SelectedValue = "%"
        LoadDataSource(tdbcACodeIDTo, dtTable.Copy, gbUnicode)
        tdbcACodeIDTo.SelectedValue = "%"
    End Sub


#Region "Events tdbcObjectTypeID load tdbcObjectID with txtObjectName"
    Private Sub tdbcObjectTypeID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.GotFocus
        tdbcObjectTypeID.Tag = tdbcObjectTypeID.Text
    End Sub

    Private Sub tdbcObjectTypeID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcObjectTypeID.KeyDown
        tdbcObjectTypeID.Tag = tdbcObjectTypeID.Text
    End Sub

    Private Sub tdbcObjectTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.LostFocus
        If tdbcObjectTypeID.Tag Is Nothing Then Exit Sub
        If tdbcObjectTypeID.Tag.ToString = tdbcObjectTypeID.Text Then
            If oFilterCombo.IsNewFilter And tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 Then
                oFilterCombo.LoadtdbcObjectID(tdbcObjectID, dtObjectID, "-1")
            End If
            Exit Sub
        End If
        If tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 Then
            tdbcObjectTypeID.Text = "%"
            oFilterCombo.LoadtdbcObjectID(tdbcObjectID, dtObjectID, "-1")
            tdbcObjectID.Text = "%"
            Exit Sub
        End If
        tdbcObjectID.Text = "%"
    End Sub

    Private Sub tdbcObjectTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.SelectedValueChanged
        oFilterCombo.LoadtdbcObjectID(tdbcObjectID, dtObjectID, ReturnValueC1Combo(tdbcObjectTypeID))
        tdbcObjectID.Text = "%"
    End Sub

    Private Sub tdbcObjectID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.SelectedValueChanged
        If tdbcObjectID.SelectedValue Is Nothing Then
            txtObjectName.Text = ""
        Else
            txtObjectName.Text = tdbcObjectID.Columns("ObjectName").Value.ToString
        End If
    End Sub

    Private Sub tdbcObjectID_Validated(sender As Object, e As EventArgs) Handles tdbcObjectID.Validated
        oFilterCombo.FilterCombo(tdbcObjectID, e)
        If tdbcObjectID.FindStringExact(tdbcObjectID.Text) = -1 Then tdbcObjectID.Text = "%"
    End Sub
#End Region



#Region "Events tdbcTypeCodeID load tdbcACodeIDFrom"

    Private Sub tdbcTypeCodeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeCodeID.SelectedValueChanged
        If tdbcTypeCodeID.SelectedValue Is Nothing OrElse tdbcTypeCodeID.Text = "" Then
            LoadACodeID("-1")
            tdbcACodeIDFrom.Text = ""
            tdbcACodeIDTo.Text = ""
            Exit Sub
        End If
        LoadACodeID(ReturnValueC1Combo(tdbcTypeCodeID))
        tdbcACodeIDFrom.Text = ""
        tdbcACodeIDTo.Text = ""
    End Sub

    Private Sub tdbcTypeCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeCodeID.LostFocus
        If tdbcTypeCodeID.FindStringExact(tdbcTypeCodeID.Text) = -1 Then
            tdbcTypeCodeID.Text = ""
            tdbcACodeIDFrom.Text = ""
            tdbcACodeIDTo.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub tdbcACodeIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcACodeIDFrom.LostFocus
        If tdbcACodeIDFrom.FindStringExact(tdbcACodeIDFrom.Text) = -1 Then tdbcACodeIDFrom.Text = ""
    End Sub

    Private Sub tdbcACodeIDTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcACodeIDTo.LostFocus
        If tdbcACodeIDTo.FindStringExact(tdbcACodeIDTo.Text) = -1 Then tdbcACodeIDTo.Text = ""
    End Sub

#End Region


    Private Sub LoadMonth(ByVal sDivisionID As String)
        LoadCboPeriodReport(tdbcMonthFrom, tdbcMonthTo, dtPeriod, sDivisionID)
        tdbcMonthFrom.SelectedIndex = 0
        tdbcMonthTo.SelectedIndex = 0
    End Sub

#Region "Events tdbcDivisionID with txtDivisionName"
    Dim strDivisionID As String = ""

    Private Sub tdbcDivisionID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDivisionID.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim sSQL As String = ""
            sSQL = "SELECT	 Distinct T99.DivisionID as SelectionID, T16.DivisionName" & UnicodeJoin(gbUnicode) & " as SelectionName" & vbCrLf ', Cast(0 as bit) as Selected
            sSQL &= "FROM	 D02T9999 T99 WITH(NOLOCK) " & vbCrLf
            sSQL &= "INNER JOIN  D91T0016 T16 WITH(NOLOCK) ON T99.DivisionID = T16.DivisionID " & vbCrLf
            sSQL &= "INNER JOIN  D91T0060 T60 WITH(NOLOCK) ON T99.DivisionID = T60.DivisionID " & vbCrLf
            sSQL &= "WHERE T16.Disabled = 0 AND T60.UserID = " & SQLString(gsUserID)
            sSQL &= " ORDER BY T99.DivisionID"
            ' If tdbcDivisionID.Tag Is Nothing Then Exit Sub 'tdbc.Tag lưu câu SQL đổ nguồn cho combo
            Me.Cursor = Cursors.WaitCursor
            strDivisionID = HotKeyF2D91F6020(sSQL, tdbcDivisionID) 'Gán giá trị sau khi tìm kiếm
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing Then
            txtDivisionName.Text = "%"
            LoadMonth("-1")
        Else
            LoadMonth(tdbcDivisionID.SelectedValue.ToString())
            txtDivisionName.Text = tdbcDivisionID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = "%"
        End If
        If tdbcDivisionID.Text.Trim = "" Then
            tdbcDivisionID.SelectedValue = "%"
        End If
    End Sub
#End Region

    Private Sub SetBackColorObligatory()
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMonthFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcMonthTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub


    Private Function AllowFilter() As Boolean
        If tdbcDivisionID.Text = "" Then
            D99C0008.MsgNotYetChoose(rl3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If tdbcMonthFrom.Text = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ky"))
            tdbcMonthFrom.Focus()
            Return False
        End If
        If tdbcMonthTo.Text = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ky"))
            tdbcMonthTo.Focus()
            Return False
        End If
        If Not CheckValidPeriodFromTo(tdbcMonthFrom, tdbcMonthTo) Then Return False
        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        btnFilter.Focus()
        If Not AllowFilter() Then Exit Sub
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        LoadTDBGrid()
    End Sub

    Private Sub txtAssetName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetName.KeyPress
        e.Handled = e.KeyChar = "'"
    End Sub

#Region "Events tdbcMonthFrom"

    Private Sub tdbcMonthFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMonthFrom.LostFocus
        If tdbcMonthFrom.FindStringExact(tdbcMonthFrom.Text) = -1 Then tdbcMonthFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcMonthTo"

    Private Sub tdbcMonthTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMonthTo.LostFocus
        If tdbcMonthTo.FindStringExact(tdbcMonthTo.Text) = -1 Then tdbcMonthTo.Text = ""
    End Sub

#End Region


    Private Sub mnsExportToCustomExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sReportTypeID As String = "D02F0600"
        Dim sReportName As String = "" '"DXXRXXXX"
        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sCustomReport As String = "" '= tdbcTranTypeID.Columns("InvoiceForm").Text
        Try
            Dim file As String = GetReportPathNew("02", sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)
            If sReportName = "" Then Exit Sub
            'MessageBox.Show("DLL D99D0541")
            Select Case file.ToLower
                '            Case "rpt"
                '                printReport(sReportName, sReportPath)
                Case "xls", "xlsx"
                    Me.Cursor = Cursors.WaitCursor
                    Dim sPathFile As String = GetObjectFile(sReportTypeID, sReportName, file, sReportPath)
                    If sPathFile = "" Then Exit Select
                    MyExcel(dtGrid, sPathFile, file, False)
            End Select
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkIsDisposed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsDisposed.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub chkShowDisabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowDisabled.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub tdbcAssetAccountIDFrom_Validated(sender As Object, e As EventArgs) Handles tdbcAssetAccountIDFrom.Validated
        oFilterCombo.FilterCombo(tdbcAssetAccountIDFrom, e)
        If tdbcAssetAccountIDFrom.FindStringExact(tdbcAssetAccountIDFrom.Text) = -1 Then tdbcAssetAccountIDFrom.Text = "%"
    End Sub

    Private Sub tdbcAssetAccountIDTo_Validated(sender As Object, e As EventArgs) Handles tdbcAssetAccountIDTo.Validated
        oFilterCombo.FilterCombo(tdbcAssetAccountIDTo, e)
        If tdbcAssetAccountIDTo.FindStringExact(tdbcAssetAccountIDTo.Text) = -1 Then tdbcAssetAccountIDTo.Text = "%"
    End Sub

    '13/11/2019, id 126579-Thêm Filter bar cho mục Tài khoản tài sản, Bộ phận tiếp nhận, tính năng xuất Excel cho Danh mục tài sản cố định và anchor cho màn hình Danh mục tài sản cố định
    Private Sub tsbExportToExcel_Click(sender As Object, e As EventArgs) Handles tsbExportToExcel.Click, tsmExportToExcel.Click, mnsExportToExcel.Click
        CreateTableCaption()
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
    End Sub

    Private Sub CreateTableCaption()
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            If tdbg.Splits(i).SplitSize = 0 Then Continue For
            If tdbg.Splits(i).SplitSize = 1 And tdbg.Splits(i).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact Then Continue For
            AddColVisible(tdbg, i, Arr, , False, False, gbUnicode)
        Next
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
    End Sub
End Class