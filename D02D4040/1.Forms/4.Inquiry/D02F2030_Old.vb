Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 02/04/2013 2:46:39 PM
'# Created User: VANVINH
'# Modify Date: 02/04/2013 2:46:39 PM
'# Modify User: VANVINH
'# Description: Theo ID 
'#-------------------------------------------------------------------------------------
Public Class D02F2030_Old
    Dim dtCaptionCols As DataTable


#Region "Const of tdbg"
    Private Const COL_OrderNum As Integer = 0     ' STT
    Private Const COL_Description As Integer = 1  ' Thông tin
    Private Const COL_ColHeader1 As Integer = 2   ' ColHeader1
    Private Const COL_ColHeader2 As Integer = 3   ' ColHeader2
    Private Const COL_ColHeader3 As Integer = 4   ' ColHeader3
    Private Const COL_ColHeader4 As Integer = 5   ' ColHeader4
    Private Const COL_ColHeader5 As Integer = 6   ' ColHeader5
    Private Const COL_ColHeader6 As Integer = 7   ' ColHeader6
    Private Const COL_ColHeader7 As Integer = 8   ' ColHeader7
    Private Const COL_ColHeader8 As Integer = 9   ' ColHeader8
    Private Const COL_ColHeader9 As Integer = 10  ' ColHeader9
    Private Const COL_ColHeader10 As Integer = 11 ' ColHeader10
    Private Const COL_ColHeader11 As Integer = 12 ' ColHeader11
    Private Const COL_ColHeader12 As Integer = 13 ' ColHeader12
    Private Const COL_ColHeader13 As Integer = 14 ' ColHeader13
    Private Const COL_ColHeader14 As Integer = 15 ' ColHeader14
    Private Const COL_ColHeader15 As Integer = 16 ' ColHeader15
    Private Const COL_Total As Integer = 17       ' Tổng cộng
    Private Const COL_FormatDisplay As Integer = 18 ' FormatDisplay
#End Region

    Dim dtGrid As DataTable

    Private Sub D02F2030_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLInsertClose()
    End Sub

    Private Sub D02F2030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If

        If e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
            tdbg.Focus()
            Exit Sub
        End If
        '***************************************
        ' update 9/5/2013 id 56268 - ẨN TÍNH NĂNG F12 (HIỂN THỊ)
        '        'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
        '        If e.KeyCode = Keys.F12 Then ' Mở
        '            btnF12_Click(Nothing, Nothing)
        '        End If
        '        If e.KeyCode = Keys.Escape Then 'Đóng
        '            If giRefreshUserControl = 0 Then
        '                If D99C0008.MsgAsk(rl3("Thong_tin_tren_luoi_da_thay_doi_ban_co_muon_Refresh_lai_khong")) = Windows.Forms.DialogResult.Yes Then
        '                    usrOption.D09U1111Refresh()
        '                End If
        '            End If
        '            usrOption.Hide()
        '        End If
    End Sub

    Private Sub D02F2030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        InputbyUnicode(Me, gbUnicode)
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        ResetSplitDividerSize(tdbg)
        ' If ContextMenuStrip1 IsNot Nothing Then
        'ContextMenuStrip1.Items("mnsExportToExcel").Image = My.Resources.ExportToExcel
        'ContextMenuStrip1.Items("mnsExportToExcel").Text = rL3("Xuat__Excel") 'Xuất &Excel
        SetShortcutPopupMenuNew(Me, Nothing, ContextMenuStrip1, False)
        'End If
        SetBackColorObligatory()
        mnsExportToExcel.Enabled = tdbg.RowCount > 0
        LoadTDBCombo()
        LoadDefault()
        LoadLanguage()
        tdbg_NumberFormat()
        CheckMenu(Me.Name, Nothing, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        CallD09U1111_Button(True)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_tong_hop_TSCD_-_D02F2030") & UnicodeCaption(gbUnicode) 'Truy vÊn tång híp TSCD - D02F2030
        '================================================================ 

        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnFilter.Text = rl3("_Loc") & Space(1) & "(F5)"  '&Lọc
        '================================================================ 
        ' optDate.Text = rl3("Ngay") 'Ngày
        lblPeriod.Text = rl3("Ky") 'Kỳ
        '================================================================ 
        grp1.Text = rl3("Tieu_thuc_loc") 'Tiêu thức lọc
        '================================================================ 
        btnF12.Text = "F12 (" & rl3("Hien_thi") & ")"
        lblColData.Text = rl3("Tieu_chi_dung_cot")
        lblGroupSelectionID1.Text = rl3("Tieu_thuc_1") 'Tiêu thức 1
        lblGroupSelectionID2.Text = rl3("Tieu_thuc_2") 'Tiêu thức 2
        lblGroupSelectionID3.Text = rl3("Tieu_thuc_3") 'Tiêu thức 3
        lblGroupSelectionID4.Text = rl3("Tieu_thuc_4") 'Tiêu thức 4
        lblGroupSelectionID5.Text = rl3("Tieu_thuc_5") 'Tiêu thức 5
        tdbcColData.Columns("ColData").Caption = rl3("Ma") 'Mã
        tdbcColData.Columns("Description").Caption = rl3("Ten") 'Tên

        tdbcGroupSelectionID1.Columns("GroupSelectionID").Caption = rl3("Ma") 'Mã
        tdbcGroupSelectionID1.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcGroupSelectionID2.Columns("GroupSelectionID").Caption = rl3("Ma") 'Mã
        tdbcGroupSelectionID2.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcGroupSelectionID3.Columns("GroupSelectionID").Caption = rl3("Ma") 'Mã
        tdbcGroupSelectionID3.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcGroupSelectionID4.Columns("GroupSelectionID").Caption = rl3("Ma") 'Mã
        tdbcGroupSelectionID4.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcGroupSelectionID5.Columns("GroupSelectionID").Caption = rl3("Ma") 'Mã
        tdbcGroupSelectionID5.Columns("Description").Caption = rl3("Ten") 'Tên

        tdbcFromSelection01ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcFromSelection01ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcToSelection01ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcToSelection01ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcFromSelection02ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcFromSelection02ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcToSelection02ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcToSelection02ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcFromSelection03ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcFromSelection03ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcToSelection03ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcToSelection03ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcFromSelection04ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcFromSelection04ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcToSelection04ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcToSelection04ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcFromSelection05ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcFromSelection05ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        tdbcToSelection05ID.Columns("SelectionID").Caption = rl3("Ma") 'Mã
        tdbcToSelection05ID.Columns("SelectionName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("OrderNum").Caption = rl3("STT") 'STT
        tdbg.Columns("Description").Caption = rl3("Thong_tin") 'Thông tin
        tdbg.Columns("Total").Caption = rL3("Tong_cong") 'Tổng cộng
        '================================================================ 
        chkIsViewDetail.Text = rL3("Xem_chi_tiet_ma_TSCD") 'Xem chi tiết mã TSCĐ

    End Sub

    Private Sub SetBackColorObligatory()
        tdbcColData.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Dim Numberformat As Integer = 0
    Private Sub tdbg_NumberFormat()

        Dim sSQL As String = "SELECT MAX(D91V0010.UnitPriceDecimals) FROM D91V0010 WHERE IsBaseCurrency = 1"
        Numberformat = L3Int(ReturnScalar(sSQL))
        tdbg.Columns(COL_ColHeader1).Tag = Numberformat
        tdbg.Columns(COL_ColHeader2).Tag = Numberformat
        tdbg.Columns(COL_ColHeader3).Tag = Numberformat
        tdbg.Columns(COL_ColHeader4).Tag = Numberformat
        tdbg.Columns(COL_ColHeader5).Tag = Numberformat
        tdbg.Columns(COL_ColHeader6).Tag = Numberformat
        tdbg.Columns(COL_ColHeader7).Tag = Numberformat
        tdbg.Columns(COL_ColHeader8).Tag = Numberformat
        tdbg.Columns(COL_ColHeader9).Tag = Numberformat
        tdbg.Columns(COL_ColHeader10).Tag = Numberformat
        tdbg.Columns(COL_ColHeader11).Tag = Numberformat
        tdbg.Columns(COL_ColHeader12).Tag = Numberformat
        tdbg.Columns(COL_ColHeader13).Tag = Numberformat
        tdbg.Columns(COL_ColHeader14).Tag = Numberformat
        tdbg.Columns(COL_ColHeader15).Tag = Numberformat
        tdbg.Columns(COL_Total).Tag = Numberformat

        tdbg.Columns(COL_ColHeader1).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader2).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader3).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader4).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader5).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader6).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader7).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader8).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader9).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader10).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader11).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader12).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader13).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader14).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_ColHeader15).NumberFormat = "FormatText Event"
        tdbg.Columns(COL_Total).NumberFormat = "FormatText Event"
    End Sub

    Private Sub LoadDefault()
        tdbcFromPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcToPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear
        Dim sSQL As String = ""
        sSQL = "SELECT 	SelectionID AS ColData FROM	D91T2024 WITH(NOLOCK) WHERE  SelectionGroup = 'ColData' AND 	UserID = " & SQLString(gsUserID) & " AND FormID = 'D02F2030'"
        tdbcColData.SelectedValue = ReturnScalar(sSQL)
        sSQL = "SELECT 	SelectionID AS GroupSelectionID FROM D91T2024 WITH(NOLOCK) WHERE SelectionGroup = 'GroupSelection01ID'  AND 	UserID = " & SQLString(gsUserID) & " AND FormID = 'D02F2030'"
        tdbcGroupSelectionID1.Text = ReturnScalar(sSQL)
        sSQL = "SELECT 	SelectionID AS GroupSelectionID FROM D91T2024 WITH(NOLOCK) WHERE SelectionGroup = 'GroupSelection02ID'  AND 	UserID = " & SQLString(gsUserID) & " AND FormID = 'D02F2030'"
        tdbcGroupSelectionID2.Text = ReturnScalar(sSQL)
        sSQL = "SELECT 	SelectionID AS GroupSelectionID FROM D91T2024 WITH(NOLOCK) WHERE SelectionGroup = 'GroupSelection03ID'  AND 	UserID = " & SQLString(gsUserID) & " AND FormID = 'D02F2030'"
        tdbcGroupSelectionID3.Text = ReturnScalar(sSQL)
        sSQL = "SELECT 	SelectionID AS GroupSelectionID FROM D91T2024 WITH(NOLOCK) WHERE SelectionGroup = 'GroupSelection04ID'  AND 	UserID = " & SQLString(gsUserID) & " AND FormID = 'D02F2030'"
        tdbcGroupSelectionID4.Text = ReturnScalar(sSQL)
        sSQL = "SELECT 	SelectionID AS GroupSelectionID FROM D91T2024 WITH(NOLOCK) WHERE SelectionGroup = 'GroupSelection05ID'  AND 	UserID = " & SQLString(gsUserID) & " AND FormID = 'D02F2030'"
        tdbcGroupSelectionID5.Text = ReturnScalar(sSQL)
    End Sub

    Private Sub LoadTDBCombo()
        LoadCboPeriodReport(tdbcFromPeriod, tdbcToPeriod, D02)
        '*Update 12/4/2013 theo ID 53095 của Bảo Chi bởi Văn Vinh
        Dim sSQL As String = ""
        sSQL = "--DO nguon cho combo tieu thuc dung cot" & vbCrLf
        sSQL &= "SELECT 	GroupID AS ColData, GroupName" & UnicodeJoin(gbUnicode) & " AS Description	"
        sSQL &= " FROM 	D02V2030 WHERE 	Language= " & SQLString(gsLanguage) & " AND	Type = 0 ORDER BY Type,GroupID "
        LoadDataSource(tdbcColData, sSQL, gbUnicode)
        sSQL = "--Do nguon cho 5 combo tieu thuc loc " & vbCrLf
        sSQL &= " SELECT 	GroupID AS GroupSelectionID , GroupName" & UnicodeJoin(gbUnicode) & "  AS Description"
        sSQL &= " FROM 	D02V2030 WHERE 	Language= " & SQLString(gsLanguage) & " AND	Type = 1 ORDER BY Type,GroupID "
        Dim dtGroupID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcGroupSelectionID1, dtGroupID.Copy, gbUnicode)
        LoadDataSource(tdbcGroupSelectionID2, dtGroupID.Copy, gbUnicode)
        LoadDataSource(tdbcGroupSelectionID3, dtGroupID.Copy, gbUnicode)
        LoadDataSource(tdbcGroupSelectionID4, dtGroupID.Copy, gbUnicode)
        LoadDataSource(tdbcGroupSelectionID5, dtGroupID.Copy, gbUnicode)
        '**********************************************
    End Sub

    Private Sub LoadComboSelectionXXID(ByVal C1Combo1 As C1.Win.C1List.C1Combo, ByVal C1Combo2 As C1.Win.C1List.C1Combo, ByVal sGroupSelection As String)
        Dim sSQL As String = SQLStoreD02P2032(sGroupSelection)
        Dim dtGroupID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1Combo1, dtGroupID, gbUnicode)
        LoadDataSource(C1Combo2, dtGroupID.Copy, gbUnicode)
    End Sub

    Private Sub LoadCaptionSplit2()
        Dim dt As DataTable
        dt = ReturnDataTable(SQLStoreD02P2031)
        If dt.Rows.Count > 0 Then
            Dim i As Integer
            For j As Integer = COL_ColHeader1 To COL_ColHeader15
                tdbg.Splits(SPLIT1).DisplayColumns(j).Visible = False
                tdbg.Splits(SPLIT1).DisplayColumns(j).AllowSizing = False
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("ColHeader").ToString = tdbg.Columns(j).DataField Then
                        tdbg.Columns(j).Caption = dt.Rows(i).Item("Description").ToString
                        Dim fontStyle As FontStyle = tdbg.Splits(SPLIT1).DisplayColumns(j).HeadingStyle.Font.Style
                        tdbg.Splits(SPLIT1).DisplayColumns(j).HeadingStyle.Font = FontUnicode(gbUnicode, fontStyle)
                        tdbg.Splits(SPLIT1).DisplayColumns(j).Visible = True
                        tdbg.Splits(SPLIT1).DisplayColumns(j).AllowSizing = True
                    End If
                Next
            Next
        Else
            tdbg.Splits(SPLIT1).SplitSize = 0
            tdbg.Splits(SPLIT1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
            tdbg.Splits(SPLIT1).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Automatic
        End If
    End Sub

    Private Sub optPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPeriod.Click
        'ReadOnlyControl(c1dateDateFrom)
        'ReadOnlyControl(c1dateDateTo)
        'UnReadOnlyControl(tdbcFromPeriod)
        'UnReadOnlyControl(tdbcToPeriod)
        'tdbcFromPeriod.Text = giTranMonth.ToString("00") & "/" & giTranYear
        'tdbcToPeriod.Text = giTranMonth.ToString("00") & "/" & giTranYear
    End Sub

    Private Sub optDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDate.Click
        'ReadOnlyControl(tdbcToPeriod)
        'ReadOnlyControl(tdbcFromPeriod)
        'UnReadOnlyControl(c1dateDateTo)
        'UnReadOnlyControl(c1dateDateFrom)
        'c1dateDateTo.Value = Date.Now
        'c1dateDateFrom.Value = Date.Now
    End Sub

#Region "Cau lenh SQL"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2030
    '# Created User: VANVINH
    '# Created Date: 15/04/2013 10:33:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2030() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrLf)
        sSQL &= "Exec D02P2030 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcFromPeriod.Columns("TranMonth").Text) & COMMA 'FromMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcFromPeriod.Columns("TranYear").Text) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcToPeriod.Columns("TranMonth").Text) & COMMA 'ToMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcToPeriod.Columns("TranYear").Text) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcColData).ToString) & COMMA 'ColData, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcGroupSelectionID1.Text) & COMMA 'GroupSelection01ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcGroupSelectionID2.Text) & COMMA 'GroupSelection02ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcGroupSelectionID3.Text) & COMMA 'GroupSelection03ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcGroupSelectionID4.Text) & COMMA 'GroupSelection04ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcGroupSelectionID5.Text) & COMMA 'GroupSelection05ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcFromSelection01ID.Text) & COMMA 'FromSelection01ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToSelection01ID.Text) & COMMA 'ToSelection01ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcFromSelection02ID.Text) & COMMA 'FromSelection02ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToSelection02ID.Text) & COMMA 'ToSelection02ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcFromSelection03ID.Text) & COMMA 'FromSelection03ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToSelection03ID.Text) & COMMA 'ToSelection03ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcFromSelection04ID.Text) & COMMA 'FromSelection04ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToSelection04ID.Text) & COMMA 'ToSelection04ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcFromSelection05ID.Text) & COMMA 'FromSelection05ID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToSelection05ID.Text) & COMMA 'ToSelection05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkIsViewDetail.Checked) 'IsViewDetail, tinyint, NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2031
    '# Created User: VANVINH
    '# Created Date: 02/04/2013 04:49:15
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2031() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon caption va thiet lap an hien cho 15 cot du lieu dong" & vbCrLf)
        sSQL &= "Exec D02P2031 "
        sSQL &= SQLString(ReturnValueC1Combo(tdbcColData).ToString) & COMMA 'ColData, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2032
    '# Created User: VANVINH
    '# Created Date: 12/04/2013 02:15:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2032(ByVal sGroupSelection As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho 10 combo Tieu thuc loc tu den" & vbCrLf)
        sSQL &= "Exec D02P2032 "
        sSQL &= SQLString(sGroupSelection) & COMMA 'GroupSelection, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub SQLInsertClose()
        Dim sSQL As String = ""
        sSQL = "-- Xoa gia tri duoc chon gan nhat cua user " & vbCrLf
        sSQL &= " DELETE FROM D91T2024  WHERE 	UserID = " & SQLString(gsUserID) & " AND 	FormID = 'D02F2030' " & vbCrLf
        sSQL &= "-- Luu gia tri chon cua tieu chi dung cot" & vbCrLf
        sSQL &= " INSERT INTO D91T2024 (UserID, SelectionGroup, SelectionID, SelectionName, SelectionNameU, FormID) VALUES (" & SQLString(gsUserID) & ", 'ColData', " & SQLString(ReturnValueC1Combo(tdbcColData).ToString) & ", '', '', 'D02F2030')" & vbCrLf
        sSQL &= "-- Luu gia tri chon cua 5 tieu thuc" & vbCrLf
        If tdbcGroupSelectionID1.Text <> "" Then sSQL &= " INSERT INTO D91T2024 (UserID, SelectionGroup, SelectionID, SelectionName, SelectionNameU, FormID) VALUES (" & SQLString(gsUserID) & ", 'GroupSelection01ID', " & SQLString(tdbcGroupSelectionID1.Text) & ", '', '', 'D02F2030')" & vbCrLf
        If tdbcGroupSelectionID2.Text <> "" Then sSQL &= " INSERT INTO D91T2024 (UserID, SelectionGroup, SelectionID, SelectionName, SelectionNameU, FormID) VALUES (" & SQLString(gsUserID) & ", 'GroupSelection02ID', " & SQLString(tdbcGroupSelectionID2.Text) & ", '', '', 'D02F2030')" & vbCrLf
        If tdbcGroupSelectionID3.Text <> "" Then sSQL &= " INSERT INTO D91T2024 (UserID, SelectionGroup, SelectionID, SelectionName, SelectionNameU, FormID) VALUES (" & SQLString(gsUserID) & ", 'GroupSelection03ID', " & SQLString(tdbcGroupSelectionID3.Text) & ", '', '', 'D02F2030')" & vbCrLf
        If tdbcGroupSelectionID4.Text <> "" Then sSQL &= " INSERT INTO D91T2024 (UserID, SelectionGroup, SelectionID, SelectionName, SelectionNameU, FormID) VALUES (" & SQLString(gsUserID) & ", 'GroupSelection04ID', " & SQLString(tdbcGroupSelectionID4.Text) & ", '', '', 'D02F2030')" & vbCrLf
        If tdbcGroupSelectionID5.Text <> "" Then sSQL &= " INSERT INTO D91T2024 (UserID, SelectionGroup, SelectionID, SelectionName, SelectionNameU, FormID) VALUES (" & SQLString(gsUserID) & ", 'GroupSelection05ID', " & SQLString(tdbcGroupSelectionID5.Text) & ", '', '', 'D02F2030')" & vbCrLf
        ExecuteSQL(sSQL)
    End Sub

#End Region
#Region "Events tdbcColData"

    Private Sub tdbcColData_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcColData.LostFocus
        If tdbcColData.FindStringExact(tdbcColData.Text) = -1 Then tdbcColData.Text = ""
    End Sub

#End Region

#Region "Events tdbcToSelection05ID"

    Private Sub tdbcToSelection05ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToSelection05ID.LostFocus
        If tdbcToSelection05ID.FindStringExact(tdbcToSelection05ID.Text) = -1 Then tdbcToSelection05ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcFromSelection05ID"

    Private Sub tdbcFromSelection05ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromSelection05ID.LostFocus
        If tdbcFromSelection05ID.FindStringExact(tdbcFromSelection05ID.Text) = -1 Then tdbcFromSelection05ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcToSelection04ID"

    Private Sub tdbcToSelection04ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToSelection04ID.LostFocus
        If tdbcToSelection04ID.FindStringExact(tdbcToSelection04ID.Text) = -1 Then tdbcToSelection04ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcFromSelection04ID"

    Private Sub tdbcFromSelection04ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromSelection04ID.LostFocus
        If tdbcFromSelection04ID.FindStringExact(tdbcFromSelection04ID.Text) = -1 Then tdbcFromSelection04ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcToSelection03ID"

    Private Sub tdbcToSelection03ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToSelection03ID.LostFocus
        If tdbcToSelection03ID.FindStringExact(tdbcToSelection03ID.Text) = -1 Then tdbcToSelection03ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcFromSelection03ID"

    Private Sub tdbcFromSelection03ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromSelection03ID.LostFocus
        If tdbcFromSelection03ID.FindStringExact(tdbcFromSelection03ID.Text) = -1 Then tdbcFromSelection03ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcToSelection02ID"

    Private Sub tdbcToSelection02ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToSelection02ID.LostFocus
        If tdbcToSelection02ID.FindStringExact(tdbcToSelection02ID.Text) = -1 Then tdbcToSelection02ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcFromSelection02ID"

    Private Sub tdbcFromSelection02ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromSelection02ID.LostFocus
        If tdbcFromSelection02ID.FindStringExact(tdbcFromSelection02ID.Text) = -1 Then tdbcFromSelection02ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcToSelection01ID"

    Private Sub tdbcToSelection01ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToSelection01ID.LostFocus
        If tdbcToSelection01ID.FindStringExact(tdbcToSelection01ID.Text) = -1 Then tdbcToSelection01ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcFromSelection01ID"

    Private Sub tdbcFromSelection01ID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromSelection01ID.LostFocus
        If tdbcFromSelection01ID.FindStringExact(tdbcFromSelection01ID.Text) = -1 Then tdbcFromSelection01ID.Text = ""
    End Sub

#End Region

#Region "Events tdbcGroupSelectionID5"

    Private Sub tdbcGroupSelectionID5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID5.LostFocus
        If tdbcGroupSelectionID5.FindStringExact(tdbcGroupSelectionID5.Text) = -1 Then
            tdbcGroupSelectionID5.Text = ""
            tdbcFromSelection05ID.Enabled = False
            tdbcToSelection05ID.Enabled = False
            tdbcFromSelection05ID.Text = ""
            tdbcToSelection05ID.Text = ""
        End If

    End Sub

    Private Sub tdbcGroupSelectionID5_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID5.SelectedValueChanged
        If tdbcGroupSelectionID5.Text = "" Then
            tdbcFromSelection05ID.Enabled = False
            tdbcToSelection05ID.Enabled = False
            tdbcFromSelection05ID.Text = ""
            tdbcToSelection05ID.Text = ""
        Else
            LoadComboSelectionXXID(tdbcFromSelection05ID, tdbcToSelection05ID, tdbcGroupSelectionID5.Text)
            tdbcFromSelection05ID.Enabled = True
            tdbcToSelection05ID.Enabled = True
        End If

    End Sub
#End Region

#Region "Events tdbcGroupSelectionID4"

    Private Sub tdbcGroupSelectionID4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID4.LostFocus
        If tdbcGroupSelectionID4.FindStringExact(tdbcGroupSelectionID4.Text) = -1 Then
            tdbcGroupSelectionID4.Text = ""
            tdbcFromSelection04ID.Enabled = False
            tdbcToSelection04ID.Enabled = False
            tdbcFromSelection04ID.Text = ""
            tdbcToSelection04ID.Text = ""
        End If

    End Sub

    Private Sub tdbcGroupSelectionID4_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID4.SelectedValueChanged
        If tdbcGroupSelectionID4.Text = "" Then
            tdbcFromSelection04ID.Enabled = False
            tdbcToSelection04ID.Enabled = False
            tdbcFromSelection04ID.Text = ""
            tdbcToSelection04ID.Text = ""
        Else
            LoadComboSelectionXXID(tdbcFromSelection04ID, tdbcToSelection04ID, tdbcGroupSelectionID4.Text)
            tdbcFromSelection04ID.Enabled = True
            tdbcToSelection04ID.Enabled = True
        End If

    End Sub
#End Region

#Region "Events tdbcGroupSelectionID3"

    Private Sub tdbcGroupSelectionID3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID3.LostFocus
        If tdbcGroupSelectionID3.FindStringExact(tdbcGroupSelectionID3.Text) = -1 Then
            tdbcGroupSelectionID3.Text = ""
            tdbcFromSelection03ID.Enabled = False
            tdbcToSelection03ID.Enabled = False
            tdbcFromSelection03ID.Text = ""
            tdbcToSelection03ID.Text = ""
        End If

    End Sub

    Private Sub tdbcGroupSelectionID3_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID3.SelectedValueChanged
        If tdbcGroupSelectionID3.Text = "" Then
            tdbcFromSelection03ID.Enabled = False
            tdbcToSelection03ID.Enabled = False
            tdbcFromSelection03ID.Text = ""
            tdbcToSelection03ID.Text = ""
        Else
            LoadComboSelectionXXID(tdbcFromSelection03ID, tdbcToSelection03ID, tdbcGroupSelectionID3.Text)
            tdbcFromSelection03ID.Enabled = True
            tdbcToSelection03ID.Enabled = True
        End If
    End Sub
#End Region

#Region "Events tdbcGroupSelectionID2"

    Private Sub tdbcGroupSelectionID2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID2.LostFocus
        If tdbcGroupSelectionID2.FindStringExact(tdbcGroupSelectionID2.Text) = -1 Then
            tdbcGroupSelectionID2.Text = ""
            tdbcFromSelection02ID.Enabled = False
            tdbcToSelection02ID.Enabled = False
            tdbcFromSelection02ID.Text = ""
            tdbcToSelection02ID.Text = ""
        End If

    End Sub

    Private Sub tdbcGroupSelectionID2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID2.SelectedValueChanged
        If tdbcGroupSelectionID2.Text = "" Then
            tdbcFromSelection02ID.Enabled = False
            tdbcToSelection02ID.Enabled = False
            tdbcFromSelection02ID.Text = ""
            tdbcToSelection02ID.Text = ""
        Else
            LoadComboSelectionXXID(tdbcFromSelection02ID, tdbcToSelection02ID, tdbcGroupSelectionID2.Text)
            tdbcFromSelection02ID.Enabled = True
            tdbcToSelection02ID.Enabled = True
        End If
    End Sub
#End Region

#Region "Events tdbcGroupSelectionID1"

    Private Sub tdbcGroupSelectionID1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID1.LostFocus
        If tdbcGroupSelectionID1.FindStringExact(tdbcGroupSelectionID1.Text) = -1 Then
            tdbcGroupSelectionID1.Text = ""
            tdbcFromSelection01ID.Enabled = False
            tdbcToSelection01ID.Enabled = False
            tdbcFromSelection01ID.Text = ""
            tdbcToSelection01ID.Text = ""
        End If

    End Sub

    Private Sub tdbcGroupSelectionID1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcGroupSelectionID1.SelectedValueChanged
        If tdbcGroupSelectionID1.Text = "" Then
            tdbcFromSelection01ID.Enabled = False
            tdbcToSelection01ID.Enabled = False
            tdbcFromSelection01ID.Text = ""
            tdbcToSelection01ID.Text = ""
        Else
            LoadComboSelectionXXID(tdbcFromSelection01ID, tdbcToSelection01ID, tdbcGroupSelectionID1.Text)
            tdbcFromSelection01ID.Enabled = True
            tdbcToSelection01ID.Enabled = True
        End If
    End Sub
#End Region

#Region "Events tdbcToPeriod"

    Private Sub tdbcToPeriod_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcToPeriod.Close
        If tdbcToPeriod.FindStringExact(tdbcToPeriod.Text) = -1 Then tdbcToPeriod.Text = ""

    End Sub

    Private Sub tdbcToPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToPeriod.LostFocus
        If tdbcToPeriod.Text = "" Then
            tdbcToPeriod.Text = tdbcToPeriod.Tag.ToString
        End If
    End Sub


    Private Sub tdbcToPeriod_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcToPeriod.SelectedValueChanged
        tdbcToPeriod.Tag = tdbcToPeriod.Text
    End Sub
#End Region

#Region "Events tdbcFromPeriod"

    Private Sub tdbcFromPeriod_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcFromPeriod.Close
        If tdbcFromPeriod.FindStringExact(tdbcFromPeriod.Text) = -1 Then tdbcFromPeriod.Text = ""
    End Sub

    Private Sub tdbcFromPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromPeriod.LostFocus
        If tdbcFromPeriod.Text = "" Then
            tdbcFromPeriod.Text = tdbcFromPeriod.Tag.ToString
        End If
    End Sub

    Private Sub tdbcFromPeriod_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcFromPeriod.SelectedValueChanged
        tdbcFromPeriod.Tag = tdbcFromPeriod.Text
    End Sub
#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs)
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
        tdbc.SelectedValue = "%"
    End Sub

    Private Sub c1dateDateFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateDateFrom.LostFocus
        If c1dateDateFrom.Text = "" Then
            c1dateDateFrom.Value = Now.Date
        End If
    End Sub

    Private Sub c1dateDateTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1dateDateTo.LostFocus
        If c1dateDateTo.Text = "" Then
            c1dateDateTo.Value = Now.Date
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowFilter() As Boolean
        If optPeriod.Checked Then
            If Not CheckValidPeriodFromTo(tdbcFromPeriod, tdbcToPeriod) Then Return False
        Else
            If Not CheckValidDateFromTo(c1dateDateFrom, c1dateDateTo) Then Return False
        End If
        If tdbcColData.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tieu_chi_dung_cot"))
            tdbcColData.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD02P2030()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = ""
        dtGrid.DefaultView.RowFilter = strFind
        'mnsExportToExcel.Enabled = tdbg.RowCount > 0
        'mnsPrint.Enabled = tdbg.RowCount > 0
        CheckMenu(Me.Name, Nothing, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowFilter() Then Exit Sub
        LoadCaptionSplit2()
        LoadTDBGrid()
        CallD09U1111_Button(True)
    End Sub

    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If tdbg(e.Row, COL_FormatDisplay).ToString = "BOLD" Then
            e.CellStyle.Font = FontUnicode(gbUnicode, FontStyle.Bold)
        ElseIf tdbg(e.Row, COL_FormatDisplay).ToString = "ITALIC" Then
            e.CellStyle.Font = FontUnicode(gbUnicode, FontStyle.Italic)
        ElseIf tdbg(e.Row, COL_FormatDisplay).ToString = "BOLD-ITALIC" Then
            e.CellStyle.Font = FontUnicode(gbUnicode, FontStyle.Bold Or FontStyle.Italic)
        End If
    End Sub

    'Dim dtCaptionCols As DataTable
    Private Sub mnsExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsExportToExcel.Click
        ' update 20/5/2013 id 56606 - Lỗi lưu giá trị cũ
        '  If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, arrColObligatory, , , gbUnicode)
        AddColVisible(tdbg, SPLIT2, Arr, arrColObligatory, , , gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'Gọi form Xuất Excel như sau:
        'ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)
        ' End If
        'Dim frm As New D99F2222
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = dtCaptionCols
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With

    End Sub

    Private Sub tdbg_FormatText(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FormatTextEventArgs) Handles tdbg.FormatText
        If Number(e.Value) = 0 Then
            e.Value = ""
        Else
            e.Value = FormatNumber(e.Value, Numberformat)
        End If
    End Sub

    '*****************************************
    Private Sub CallD09U1111_Button(ByVal bLoadFirst As Boolean)
        'Chuẩn hóa D09U1111 B2: đẩy vào Arr các cột có Visible = True 
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If usrOption IsNot Nothing Then
            usrOption = Nothing
        End If
        'Những cột bắt buộc nhập
        If bLoadFirst = True Then
            Dim arrColObligatory() As Integer = {COL_Description, COL_Total}
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arrMaster, arrColObligatory, , , gbUnicode)
            AddColVisible(tdbg, SPLIT2, arrMaster, arrColObligatory, , , gbUnicode)
        End If
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, tdbg.Top + tdbg.Height - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Dim report As D99C2003
    Private Sub mnsPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsPrint.Click
        'If Not AllowPrint() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
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
        Dim sReportName As String = "D02R2030"
        Dim sReportPath As String = ""
        Dim sReportTitle As String = ""
        Dim sCustomReport As String = ""
        Dim file As String = D99D0541.GetReportPathNew(ModuleID, sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)
        If sReportName = "" Then Exit Sub

        Dim sSQL As String = ""
        Select Case file.ToLower
            Case "rpt"
                printReport(sReportName, sReportPath, sReportTitle, SQLStoreD02P2030())
            Case Else
                D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, file, dtGrid)
        End Select
    End Sub
End Class