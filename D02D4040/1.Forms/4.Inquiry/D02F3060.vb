Imports System
Public Class D02F3060
    Dim dtCaptionCols As DataTable

#Region "Const of tdbg - Total of Columns: 50"
    Private Const COL_AssetID As Integer = 0                  ' Mã
    Private Const COL_AssetName As Integer = 1                ' Tên
    Private Const COL_AssetNo As Integer = 2                  ' Số hiệu
    Private Const COL_ShortName As Integer = 3                ' Tên tắt
    Private Const COL_AssetTag As Integer = 4                 ' Thẻ tài sản
    Private Const COL_PurchaseDate As Integer = 5             ' Ngày mua
    Private Const COL_AssetDate As Integer = 6                ' Ngày tiếp nhận
    Private Const COL_UseDate As Integer = 7                  ' Ngày sử dụng
    Private Const COL_CountryID As Integer = 8                ' Nước sản xuất
    Private Const COL_ManagementObjTypeID As Integer = 9      ' Mã loại phòng ban QL
    Private Const COL_ManagementObjID As Integer = 10         ' Mã phòng ban QL
    Private Const COL_ManagementObjName As Integer = 11       ' Tên phòng ban QL
    Private Const COL_ObjectTypeID As Integer = 12            ' Mã loại bộ phận tiếp nhận
    Private Const COL_ObjectID As Integer = 13                ' Mã bộ phận tiếp nhận
    Private Const COL_ObjectName As Integer = 14              ' Tên bộ phận tiếp nhận
    Private Const COL_EmployeeID As Integer = 15              ' Mã người tiếp nhận
    Private Const COL_EmployeeName As Integer = 16            ' Tên người tiếp nhận
    Private Const COL_Notes As Integer = 17                   ' Ghi chú
    Private Const COL_ACode01ID As Integer = 18               ' ACode01ID
    Private Const COL_ACode01Name As Integer = 19             ' ACode01Name
    Private Const COL_ACode02ID As Integer = 20               ' ACode02ID
    Private Const COL_ACode02Name As Integer = 21             ' ACode02Name
    Private Const COL_ACode03ID As Integer = 22               ' ACode03ID
    Private Const COL_ACode03Name As Integer = 23             ' ACode03Name
    Private Const COL_ACode04ID As Integer = 24               ' ACode04ID
    Private Const COL_ACode04Name As Integer = 25             ' ACode04Name
    Private Const COL_ACode05ID As Integer = 26               ' ACode05ID
    Private Const COL_ACode05Name As Integer = 27             ' ACode05Name
    Private Const COL_AssetAccountID As Integer = 28          ' TK tài sản
    Private Const COL_DepAccountID As Integer = 29            ' TK khấu hao
    Private Const COL_StrDebitAccountID As Integer = 30       ' TK phân bổ
    Private Const COL_BeginALPeriod As Integer = 31           ' Kỳ bắt đầu KH
    Private Const COL_ServiceLife As Integer = 32             ' Số kỳ KH
    Private Const COL_DepreciatedPeriod As Integer = 33       ' Số kỳ đã KH
    Private Const COL_RemainPeriod As Integer = 34            ' Số kỳ KH còn lại
    Private Const COL_OpenningCAmount As Integer = 35         ' Nguyên giá hình thành
    Private Const COL_NotDepOpenningCAmount As Integer = 36   ' Nguyên giá đất hình thành
    Private Const COL_DepOpenningCAmount As Integer = 37      ' Nguyên giá xây dựng hình thành
    Private Const COL_IncreaseCAmount As Integer = 38         ' Tăng nguyên giá trong kỳ
    Private Const COL_DecreaseCAmount As Integer = 39         ' Giảm nguyên giá trong kỳ
    Private Const COL_ClosingCAmount As Integer = 40          ' Nguyên giá sau tăng giảm trong kỳ
    Private Const COL_DepreciationAmount As Integer = 41      ' Khấu hao lũy kế 
    Private Const COL_OpenningLTDDepreciation As Integer = 42 ' Hao mòn lũy kế đầu kỳ
    Private Const COL_OpenningCost As Integer = 43            ' Giá trị còn lại đầu kỳ
    Private Const COL_NotDepOpenningCost As Integer = 44      ' Giá trị còn lại đầu kỳ không khấu hao
    Private Const COL_DepOpenningCost As Integer = 45         ' Giá trị còn lại đầu kỳ khấu hao
    Private Const COL_ClosingLTDDepreciation As Integer = 46  ' Hao mòn lũy kế cuối kỳ
    Private Const COL_RemainAmount As Integer = 47            ' Giá trị còn lại cuối kỳ
    Private Const COL_NotDepRemainAmount As Integer = 48      ' Giá trị còn lại cuối kỳ không khấu hao
    Private Const COL_DepRemainAmount As Integer = 49         ' Giá trị còn lại cuối kỳ khấu hao
#End Region


    Private Const COL_Total As Integer = 49

    Private dtGrid As DataTable
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private Sub D02F3060_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        InputbyUnicode(Me, gbUnicode)

        gbEnabledUseFind = False
        LoadTDBCombo()
        LoadDefault()
        LoadLanguage()
        LoadCaptionACodeID()

        tdbg_NumberFormat()
        SetBackColorObligatory()
        ResetSplitDividerSize(tdbg)
        InputDateInTrueDBGrid(tdbg, COL_PurchaseDate)
        InputDateInTrueDBGrid(tdbg, COL_AssetDate, COL_UseDate)

        ResetGrid()
        CallD99U1111()
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D02F3060_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub LoadDefault()
        'tdbcFromPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        'tdbcToPeriod.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString

        tdbcAssetIDFrom.SelectedValue = "%"
        tdbcAssetIDTo.SelectedValue = "%"

        tdbcTypeCodeID.SelectedValue = "%"
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_tong_ket_khau_hao_TSCD") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Truy vÊn tång kÕt khÊu hao TSCD
        '================================================================ 
        lblTypeCodeID.Text = rl3("Ma_phan_tich") 'Mã phân tích
        lblPeriod.Text = rl3("Ky") 'Kỳ
        lblAssetIDFrom.Text = rL3("Tai_san") 'Tài sản
        lblObjectID.Text = rL3("Bo_phan_quan_ly_tai_san") 'Bộ phận quản lý tài sản
        lblAssetAccountIDFrom.Text = rL3("Tai_khoan_TS") 'Tài khoản TS
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc (F5)
        btnF12.Text = "F12 ( " & rl3("Hien_thi") & " )" 'F12 (Hiển thị)
        '================================================================ 
        chkISDisposed.Text = rl3("Hien_thi_tai_san_da_thanh_ly") '"Hiển thị tài sản đã thanh lý"
        '================================================================ 
        tdbcAssetIDTo.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcAssetIDTo.Columns("AssetName").Caption = rl3("Ten") 'Tên
        tdbcAssetIDFrom.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcAssetIDFrom.Columns("AssetName").Caption = rl3("Ten") 'Tên
        tdbcToCCodeID.Columns("AcodeID").Caption = rl3("Ma") 'Mã
        tdbcToCCodeID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcFromCCodeID.Columns("AcodeID").Caption = rl3("Ma") 'Mã
        tdbcFromCCodeID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcTypeCodeID.Columns("TypeCodeID").Caption = rl3("Ma") 'Mã
        tdbcTypeCodeID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbcAssetAccountIDFrom.Columns("AccountID").Caption = rL3("Ma") 'Mã
        tdbcAssetAccountIDFrom.Columns("AccountName").Caption = rL3("Ten") 'Tên
        tdbcAssetAccountIDTo.Columns("AccountID").Caption = rL3("Ma") 'Mã
        tdbcAssetAccountIDTo.Columns("AccountName").Caption = rL3("Ten") 'Tên
        tdbcObjectID.Columns("ObjectID").Caption = rL3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectID").Caption = rL3("Ten") 'Tên
        '================================================================ 
        'tdbg.Columns(COL_AssetID).Caption = rL3("Ma") 'Mã
        'tdbg.Columns(COL_AssetName).Caption = rL3("Ten") 'Tên
        'tdbg.Columns(COL_AssetNo).Caption = rL3("So_hieu") 'Số hiệu
        'tdbg.Columns(COL_ShortName).Caption = rL3("Ten_tat") 'Tên tắt
        'tdbg.Columns(COL_AssetTag).Caption = rL3("The_tai_san") 'Thẻ tài sản
        'tdbg.Columns(COL_PurchaseDate).Caption = rL3("Ngay_mua") 'Ngày mua
        'tdbg.Columns(COL_AssetDate).Caption = rL3("Ngay_tiep_nhan") 'Ngày tiếp nhận
        'tdbg.Columns(COL_UseDate).Caption = rL3("Ngay_su_dung") 'Ngày sử dụng
        'tdbg.Columns(COL_CountryID).Caption = rL3("Nuoc_san_xuat") 'Nước sản xuất
        ''tdbg.Columns(COL_ObjectID).Caption = rL3("Ma_bo_phan_QL") 'Mã bộ phận QL
        ''tdbg.Columns(COL_ObjectName).Caption = rL3("Ten_bo_phan_QL") 'Tên bộ phận QL
        'tdbg.Columns(COL_EmployeeID).Caption = rL3("Ma_nguoi_tiep_nhan") 'Mã người tiếp nhận
        'tdbg.Columns(COL_EmployeeName).Caption = rL3("Ten_nguoi_tiep_nhan") 'Tên người tiếp nhận
        'tdbg.Columns(COL_Notes).Caption = rL3("Ghi_chu") 'Ghi chú
        'tdbg.Columns(COL_AssetAccountID).Caption = rL3("TK_tai_san") 'TK tài sản
        'tdbg.Columns(COL_DepAccountID).Caption = rL3("TK_khau_hao") 'TK khấu hao
        ''16/11/2020, Võ Hồng Thiên Nhi:id 147010-Hỗ trợ bổ sung thêm cột tài khoản chi phí phân bổ
        'tdbg.Columns(COL_StrDebitAccountID).Caption = rL3("TK_phan_bo")       ' TK phân bổ

        'tdbg.Columns(COL_BeginALPeriod).Caption = rL3("Ky_bat_dau_KH") 'Kỳ bắt đầu KH
        'tdbg.Columns(COL_ServiceLife).Caption = rL3("So_ky_KH") 'Số kỳ KH
        'tdbg.Columns(COL_DepreciatedPeriod).Caption = rL3("So_ky_da_KH") 'Số kỳ đã KH
        'tdbg.Columns(COL_RemainPeriod).Caption = rL3("So_ky_KH_con_lai") 'Số kỳ KH còn lại
        'tdbg.Columns(COL_OpenningCAmount).Caption = rL3("Nguyen_gia_hinh_thanhU") 'Nguyên giá hình thành
        'tdbg.Columns(COL_NotDepOpenningCAmount).Caption = rL3("Nguyen_gia_dat_hinh_thanh") 'Nguyên giá đất hình thành
        'tdbg.Columns(COL_DepOpenningCAmount).Caption = rL3("Nguyen_gia_xay_dung_hinh_thanh")   'Nguyên giá xây dựng hình thành
        'tdbg.Columns(COL_IncreaseCAmount).Caption = rL3("Tang_nguyen_gia_trong_ky") 'Tăng nguyên giá trong kỳ
        'tdbg.Columns(COL_DecreaseCAmount).Caption = rL3("Giam_nguyen_gia_trong_ky") 'Giảm nguyên giá trong kỳ
        'tdbg.Columns(COL_ClosingCAmount).Caption = rL3("Nguyen_gia_sau_tang_giam_trong_ky") 'Nguyên giá sau tăng giảm trong kỳ
        'tdbg.Columns(COL_DepreciationAmount).Caption = rL3("Khau_hao_luy_ke") 'Khấu hao lũy kế 
        'tdbg.Columns(COL_OpenningLTDDepreciation).Caption = rL3("Hao_mon_luy_ke_dau_ky") 'Hao mòn lũy kế đầu kỳ
        'tdbg.Columns(COL_OpenningCost).Caption = rL3("Gia_tri_con_lai_dau_ky") 'Giá trị còn lại đầu kỳ
        'tdbg.Columns(COL_NotDepOpenningCost).Caption = rL3("Gia_tri_con_lai_dau_ky_khong_khau_hao") 'Giá trị còn lại đầu kỳ không khấu hao
        'tdbg.Columns(COL_DepOpenningCost).Caption = rL3("Gia_tri_con_lai_dau_ky_khau_hao") 'Giá trị còn lại đầu kỳ khấu hao
        'tdbg.Columns(COL_ClosingLTDDepreciation).Caption = rL3("Hao_mon_luy_ke_cuoi_ky") 'Hao mòn lũy kế cuối kỳ
        'tdbg.Columns(COL_RemainAmount).Caption = rL3("Gia_tri_con_lai_cuoi_ky") 'Giá trị còn lại cuối kỳ
        'tdbg.Columns(COL_NotDepRemainAmount).Caption = rL3("Gia_tri_con_lai_cuoi_ky_khong_khau_hao") 'Giá trị còn lại cuối kỳ không khấu hao
        'tdbg.Columns(COL_DepRemainAmount).Caption = rL3("Gia_tri_con_lai_cuoi_ky_khau_hao") 'Giá trị còn lại cuối kỳ khấu hao
        ''================================================================ 
        lblDivisionID.Text = rL3("Don_vi") 'Đơn vị
        tdbcDivisionID.Columns("DivisionID").Caption = rL3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rL3("Ten") 'Tên


        '================================================================ 

        '================================================================ 
        tdbg.Columns(COL_AssetID).Caption = rL3("Ma") 'Mã
        tdbg.Columns(COL_AssetName).Caption = rL3("Ten") 'Tên
        tdbg.Columns(COL_AssetNo).Caption = rL3("So_hieu") 'Số hiệu
        tdbg.Columns(COL_ShortName).Caption = rL3("Ten_tat") 'Tên tắt
        tdbg.Columns(COL_AssetTag).Caption = rL3("The_tai_san") 'Thẻ tài sản
        tdbg.Columns(COL_PurchaseDate).Caption = rL3("Ngay_mua") 'Ngày mua
        tdbg.Columns(COL_AssetDate).Caption = rL3("Ngay_tiep_nhan") 'Ngày tiếp nhận
        tdbg.Columns(COL_UseDate).Caption = rL3("Ngay_su_dung") 'Ngày sử dụng
        tdbg.Columns(COL_CountryID).Caption = rL3("Nuoc_san_xuat") 'Nước sản xuất
        tdbg.Columns(COL_ManagementObjTypeID).Caption = rL3("Ma_loai_phong_ban_QL") 'Mã loại phòng ban QL
        tdbg.Columns(COL_ManagementObjID).Caption = rL3("Ma_phong_ban_QL") 'Mã phòng ban QL
        tdbg.Columns(COL_ManagementObjName).Caption = rL3("Ten_phong_ban_QL") 'Tên phòng ban QL
        tdbg.Columns(COL_ObjectTypeID).Caption = rL3("Ma_loai_bo_phan_tiep_nhan") 'Mã loại bộ phận tiếp nhận
        tdbg.Columns(COL_ObjectID).Caption = rL3("Ma_bo_phan_tiep_nhanU") 'Mã bộ phận tiếp nhận
        tdbg.Columns(COL_ObjectName).Caption = rL3("Ten_bo_phan_tiep_nhanU") 'Tên bộ phận tiếp nhận
        tdbg.Columns(COL_EmployeeID).Caption = rL3("Ma_nguoi_tiep_nhan") 'Mã người tiếp nhận
        tdbg.Columns(COL_EmployeeName).Caption = rL3("Ten_nguoi_tiep_nhan") 'Tên người tiếp nhận
        tdbg.Columns(COL_Notes).Caption = rL3("Ghi_chu") 'Ghi chú
        tdbg.Columns(COL_AssetAccountID).Caption = rL3("TK_tai_san") 'TK tài sản
        tdbg.Columns(COL_DepAccountID).Caption = rL3("TK_khau_hao") 'TK khấu hao
        tdbg.Columns(COL_StrDebitAccountID).Caption = rL3("TK_phan_bo") 'TK phân bổ
        tdbg.Columns(COL_BeginALPeriod).Caption = rL3("Ky_bat_dau_KH") 'Kỳ bắt đầu KH
        tdbg.Columns(COL_ServiceLife).Caption = rL3("So_ky_KH") 'Số kỳ KH
        tdbg.Columns(COL_DepreciatedPeriod).Caption = rL3("So_ky_da_KH") 'Số kỳ đã KH
        tdbg.Columns(COL_RemainPeriod).Caption = rL3("So_ky_KH_con_lai") 'Số kỳ KH còn lại
        tdbg.Columns(COL_OpenningCAmount).Caption = rL3("Nguyen_gia_hinh_thanhU") 'Nguyên giá hình thành
        tdbg.Columns(COL_NotDepOpenningCAmount).Caption = rL3("Nguyen_gia_dat_hinh_thanh") 'Nguyên giá đất hình thành
        tdbg.Columns(COL_DepOpenningCAmount).Caption = rL3("Nguyen_giá_xay_dụng_hinh_thành") 'Nguyên giá xây dựng hình thành
        tdbg.Columns(COL_IncreaseCAmount).Caption = rL3("Tang_nguyen_gia_trong_ky") 'Tăng nguyên giá trong kỳ
        tdbg.Columns(COL_DecreaseCAmount).Caption = rL3("Giảm_nguyen_giá_trong_kỳ") 'Giảm nguyên giá trong kỳ
        tdbg.Columns(COL_ClosingCAmount).Caption = rL3("Nguyen_giá_sau_tang_giảm_trong_kỳ") 'Nguyên giá sau tăng giảm trong kỳ
        tdbg.Columns(COL_DepreciationAmount).Caption = rL3("Khau_hao_luy_ke") 'Khấu hao lũy kế 
        tdbg.Columns(COL_OpenningLTDDepreciation).Caption = rL3("Hao_mon_luy_ke_dau_ky") 'Hao mòn lũy kế đầu kỳ
        tdbg.Columns(COL_OpenningCost).Caption = rL3("Gia_tri_con_lai_dau_ky") 'Giá trị còn lại đầu kỳ
        tdbg.Columns(COL_NotDepOpenningCost).Caption = rL3("Gia_tri_con_lai_dau_ky_khong_khau_hao") 'Giá trị còn lại đầu kỳ không khấu hao
        tdbg.Columns(COL_DepOpenningCost).Caption = rL3("Gia_tri_con_lai_dau_ky_khau_hao") 'Giá trị còn lại đầu kỳ khấu hao
        tdbg.Columns(COL_ClosingLTDDepreciation).Caption = rL3("Hao_mon_luy_ke_cuoi_ky") 'Hao mòn lũy kế cuối kỳ
        tdbg.Columns(COL_RemainAmount).Caption = rL3("Gia_tri_con_lai_cuoi_ky") 'Giá trị còn lại cuối kỳ
        tdbg.Columns(COL_NotDepRemainAmount).Caption = rL3("Gia_tri_con_lai_cuoi_ky_khong_khau_hao") 'Giá trị còn lại cuối kỳ không khấu hao
        tdbg.Columns(COL_DepRemainAmount).Caption = rL3("Gia_tri_con_lai_cuoi_ky_khau_hao") 'Giá trị còn lại cuối kỳ khấu hao


    End Sub

    Dim dtCodeID, dtPeriod, dtAsset As DataTable

    Private Sub LoadTDBCombo()
        'NGOCHUY-112153 - ‎07/‎09/‎2018 -Bổ sung tính năng lọc theo đơn vị tại màn hình Truy vấn Tổng kết khấu hao tài sản cố định D02F3060
        'Load tdbcFromPeriod - tdbcToPeriod
        dtPeriod = LoadTablePeriodReport("D02")
        'Load tdbcDivisionID
        LoadCboDivisionIDAll(tdbcDivisionID, D02, , gbUnicode)
        tdbcDivisionID.SelectedValue = gsDivisionID

        'LoadCboPeriodReport(tdbcFromPeriod, tdbcToPeriod, D02)
        'Dim sSQL As String = ""
        'sSQL = "--Do nguon combo Ma tai san" & vbCrLf
        'sSQL &= "SELECT 		 '%' AS AssetID, " & AllName & " AS AssetName, 0 AS DisplayOrder " & vbCrLf
        'sSQL &= "UNION ALL" & vbCrLf
        'sSQL &= "SELECT 		DISTINCT N19.AssetID, N19.AssetName" & UnicodeJoin(gbUnicode) & " As AssetName, 1 AS DisplayOrder " & vbCrLf
        'sSQL &= "FROM		D02N0019 (" & giTranMonth & ", " & giTranYear & ") AS N19  " & vbCrLf
        'sSQL &= "LEFT JOIN	D02T0001 AS T01 ON T01.AssetID = N19.AssetID  " & vbCrLf
        'sSQL &= "WHERE 		N19.IsCompleted = 1 " & vbCrLf
        'sSQL &= "AND N19.Disabled = 0 " & vbCrLf
        'sSQL &= "AND N19.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        'sSQL &= "ORDER BY	DisplayOrder, AssetID" & vbCrLf

        Dim sSQL As String = ""
        sSQL = "--Do nguon combo Ma tai san" & vbCrLf
        sSQL &= "SELECT 		 '%' AS AssetID, " & AllName & " AS AssetName, 0 AS DisplayOrder, '%' as DivisionID " & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT 		DISTINCT N19.AssetID, N19.AssetName" & UnicodeJoin(gbUnicode) & " As AssetName, 1 AS DisplayOrder, N19.DivisionID " & vbCrLf
        sSQL &= "FROM		D02N0019 (" & giTranMonth & ", " & giTranYear & ") AS N19  " & vbCrLf
        sSQL &= "LEFT JOIN	D02T0001 AS T01 ON T01.AssetID = N19.AssetID  " & vbCrLf
        sSQL &= "WHERE 		N19.IsCompleted = 1 " & vbCrLf
        sSQL &= "AND N19.Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY	DisplayOrder, AssetID" & vbCrLf
        dtAsset = ReturnDataTable(sSQL)
        'LoadDataSource(tdbcAssetIDFrom, dtAsset.DefaultView.ToTable, gbUnicode)
        'LoadDataSource(tdbcAssetIDTo, dtAsset.DefaultView.ToTable, gbUnicode)
        LoadtdbcAssetToDivisionID(gsDivisionID)

        'Load tdbcTypeCodeID
        sSQL = "SELECT 	'%' AS TypeCodeID, " & AllName & " AS Description, 0 AS DisplayOrder UNION ALL " & vbCrLf
        sSQL &= "SELECT 	TypeCodeID, VieTypeCodeName" & UnicodeJoin(gbUnicode) & " AS Description, 1 AS DisplayOrder" & vbCrLf
        sSQL &= "FROM D02T0040 WITH(NOLOCK) WHERE 	Type = 'A' AND Disabled = 0 ORDER BY TypeCodeID "
        LoadDataSource(tdbcTypeCodeID, sSQL, gbUnicode)

        ' update 7/8/2013 id 57853
        'Load tdbcFromCCodeID
        sSQL = "SELECT 	'%' AS AcodeID, " & AllName & " AS Description, '%' AS TypeCodeID, 0 AS DisplayOrder UNION ALL " & vbCrLf
        sSQL &= " SELECT  AcodeID, Description" & UnicodeJoin(gbUnicode) & " As Description, TypeCodeID,  1 AS DisplayOrder           " & vbCrLf
        sSQL &= " FROM   D02T0041 WITH(NOLOCK) WHERE  Type = 'A' ORDER BY DisplayOrder, TypeCodeID, AcodeID"
        dtCodeID = ReturnDataTable(sSQL)
        LoadtdbcFromToCCodeID("-1")

        sSQL = "-- Combo tai khoan tai san" & vbCrLf
        sSQL &= " SELECT  0 AS DisplayOrder, " & AllCode & " AS AccountID,  " & AllName & " AS AccountName  "
        sSQL &= " UNION ALL "
        sSQL &= " SELECT 0 AS DisplayOrder , AccountID,  AccountName" & UnicodeJoin(gbUnicode)
        sSQL &= " FROM D90T0001 WITH(NOLOCK) "
        sSQL &= " WHERE GroupID='7' "
        sSQL &= " AND AccountStatus = 0"
        sSQL &= " AND OffAccount = 0"
        sSQL &= " AND Disabled = 0"

        Dim dtTable As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcAssetAccountIDFrom, dtTable, gbUnicode)
        tdbcAssetAccountIDFrom.SelectedValue = "%"
        LoadDataSource(tdbcAssetAccountIDTo, dtTable.DefaultView.ToTable, gbUnicode)
        tdbcAssetAccountIDTo.SelectedValue = "%"

        sSQL = "-- Combo bo phan quan ly tai san" & vbCrLf
        sSQL &= " SELECT  	0 AS DisplayOrder, " & AllCode & " AS ObjectID, " & AllName & "  AS ObjectName"
        sSQL &= " UNION ALL"
        sSQL &= " SELECT 	0 AS DisplayOrder, Object.ObjectID As ObjectID,ObjectName" & UnicodeJoin(gbUnicode)
        sSQL &= " FROM 	Object WITH(NOLOCK)"
        sSQL &= " INNER JOIN	D02T0001 T1 WITH(NOLOCK) ON T1.ObjectID = Object.ObjectID"
        sSQL &= " WHERE Object.Disabled = 0"
        LoadDataSource(tdbcObjectID, sSQL, gbUnicode)
        tdbcObjectID.SelectedValue = "%"
    End Sub

    Private Sub LoadtdbcFromToCCodeID(ByVal sTypeCodeID As String)
        Dim dt As DataTable = ReturnTableFilter(dtCodeID, "TypeCodeID = '%' OR TypeCodeID = " & SQLString(sTypeCodeID), True)
        LoadDataSource(tdbcFromCCodeID, dt, gbUnicode)
        LoadDataSource(tdbcToCCodeID, dt.DefaultView.ToTable, gbUnicode)
        tdbcFromCCodeID.SelectedValue = "%"
        tdbcToCCodeID.SelectedValue = "%"
    End Sub

    Private Sub LoadCaptionACodeID()
        Dim sSQL As String = "--Caption cac cot Ma phan tich" & vbCrLf
        sSQL &= "SELECT " & IIf(geLanguage = EnumLanguage.Vietnamese, "VieTypeCodeName", "EngTypeCodeName").ToString & UnicodeJoin(gbUnicode) & " as Caption, "
        sSQL &= " * FROM D02T0040 WITH(NOLOCK) WHERE 		Type = 'A' AND RIGHT(TypeCodeID, 2) IN ('01','02','03','04','05') ORDER BY  	TypeCodeID"

        Dim dtCaption As DataTable = ReturnDataTable(sSQL)
        If dtCaption Is Nothing Then Exit Sub
        If dtCaption.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To 4
            Dim sCaption As String = IIf(gbUnicode, dtCaption.Rows(i).Item("Caption").ToString, ConvertVniToUnicode(dtCaption.Rows(i).Item("Caption").ToString)).ToString

            tdbg.Columns(COL_ACode01ID + (i * 2)).Caption = sCaption & " (" & rl3("Ma") & ")"
            tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i * 2)).Visible = Not L3Bool(dtCaption.Rows(i).Item("Disabled"))
            tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i * 2)).AllowSizing = tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i * 2)).Visible
            '   tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + i).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i)).HeadingStyle.Font.Style)

            tdbg.Columns(COL_ACode01ID + (i * 2) + 1).Caption = sCaption & " (" & rl3("Ten") & ")"
            tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i * 2) + 1).Visible = Not L3Bool(dtCaption.Rows(i).Item("Disabled"))
            tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i * 2) + 1).AllowSizing = tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i * 2) + 1).Visible
            '   tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i * 2) + 1).HeadingStyle.Font = FontUnicode(gbUnicode, tdbg.Splits(SPLIT0).DisplayColumns(COL_ACode01ID + (i * 2) + 1).HeadingStyle.Font.Style)
        Next

    End Sub

    Dim iSplitWidth As Integer = 0
    Dim iLastAddCol As Integer = -1
    Dim dtCol As DataTable
    Private sColSumFooter() As String
    Private Sub LoadTableCaption()
        iSplitWidth = 0
        '========================================================
        dtCol = ReturnDataTable(SQLStoreD02P3061()) 'Đổ nguồn table caption cột động
        '        If tdbg.Splits.Count > 1 Then
        '            tdbg.RemoveHorizontalSplit(1)
        '        End If
        '        tdbg.InsertHorizontalSplit(1)
        '        tdbg.Splits(1).RecordSelectors = False
        '        If dtCol.Rows.Count > 0 Then
        '            tdbg.Splits(1).SplitSize = 1
        '        Else
        '            tdbg.Splits(1).SplitSize = 0
        '        End If

        'Clear cột động trước đó
        For i As Integer = tdbg.Columns.Count - 1 To COL_Total + 1 Step -1
            tdbg.Columns.RemoveAt(i)
        Next

        '11/10/2018, Trần Như Đạt: id 113890-Bổ sung tính năng sum tổng ở màn hình Truy vấn Tổng kết khấu hao TSCD D02F3060
        If sColSumFooter IsNot Nothing AndAlso sColSumFooter.Length > 0 Then sColSumFooter = Nothing 'xóa tất cả phần tử trong mảng
        Dim j As Integer = 0

        'Add cột động vào lưới
        For i As Integer = 0 To dtCol.Rows.Count - 1
            AddColumns(i, dtCol)
            '11/10/2018, Trần Như Đạt: id 113890-Bổ sung tính năng sum tổng ở màn hình Truy vấn Tổng kết khấu hao TSCD D02F3060
            If dtCol.Rows(i).Item("DataType").ToString = "N" And L3Byte(dtCol.Rows(i).Item("IsSumFooter").ToString) = 1 Then
                If sColSumFooter Is Nothing OrElse sColSumFooter.Length = 0 Then
                    ReDim sColSumFooter(0)
                Else
                    ReDim Preserve sColSumFooter(sColSumFooter.Length)
                End If
                sColSumFooter(j) = dtCol.Rows(i).Item("FieldName").ToString

                j += 1
            End If
        Next

        'Incident 71799 bổ sung Cột Vị trí sau cột tổng cộng
        Dim sField As String = "LocationID"
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
        dc.Caption = rL3("Vi_tri")
        dc.DataField = sField
        tdbg.Columns.Add(dc)
        tdbg.Splits(0).DisplayColumns(sField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        tdbg.Splits(0).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
        tdbg.Columns(sField).DataWidth = 140
        tdbg.Splits(0).DisplayColumns(sField).Visible = True

        '        For i As Integer = 0 To COL_Total
        '            tdbg.Splits(1).DisplayColumns(i).Visible = False
        '        Next

        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
    End Sub

    Private Sub AddColumns(ByVal i As Integer, ByVal dtCol As DataTable)
        Dim sField As String = dtCol.Rows(i).Item("FieldName").ToString
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
        dc.Caption = dtCol.Rows(i).Item("Caption").ToString
        dc.DataField = sField
        tdbg.Columns.Add(dc)
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        If dtCol.Rows(i).Item("DataType").ToString = "S" Then 'String
            tdbg.Splits(0).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            tdbg.Columns(sField).DataWidth = L3Int(dtCol.Rows(i).Item("Length").ToString)
        ElseIf dtCol.Rows(0).Item("DataType").ToString = "D" Then 'DateTime
            tdbg.Splits(0).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            tdbg.Columns(sField).NumberFormat = "ShortDate"
            InputDateInTrueDBGrid(tdbg, IndexOfColumn(tdbg, sField))
        Else  'Number
            tdbg.Splits(0).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            '   tdbg.Columns(sField).NumberFormat = DxxFormat.D90_ConvertedDecimals
            AddColFormatText(dtFormat, tdbg, DxxFormat.D90_ConvertedDecimals, sField)
        End If
        'Format style
        tdbg.Splits(0).DisplayColumns(sField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        tdbg.Splits(0).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
        tdbg.Splits(0).DisplayColumns(sField).Style.Font = FontUnicode(gbUnicode)
        tdbg.Splits(0).DisplayColumns(sField).Width = L3Int(dtCol.Rows(i).Item("Length").ToString)
        tdbg.Columns(sField).DataWidth = 20
        tdbg.Splits(0).DisplayColumns(sField).Visible = True 'L3Bool(dtCol.Rows(i).Item("ControlFormat").ToString <> "H")
        ' If dtCol.Rows(i).Item("ControlFormat").ToString = "O" Then tdbg.Splits(0).DisplayColumns(sField).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        ' tdbg.Splits(0).DisplayColumns(sField).FetchStyle = True
    End Sub

    Private Sub CallD99U1111(Optional ByVal bLoad As Boolean = True)
        Dim sMode As Object = ReturnValueC1Combo(tdbcFromPeriod).ToString & ReturnValueC1Combo(tdbcToPeriod).ToString
        If dtF12 Is Nothing Then
            Dim arrColObligatory() As Object = {COL_AssetID}
            usrOption.AddColVisible(tdbg, SPLIT0, dtF12, -1, arrColObligatory, COL_AssetID, COL_Total) 'Duyệt hết split 0 vì có hiển thị các cột ở cuối cùng như COL_D08T0300_Status
        Else
            If COL_Total = tdbg.Columns.Count - 1 Then
                bLoad = False
                ' sMode = -1
            Else
                Dim dr() As DataRow = dtF12.Select("Mode ='" & sMode.ToString & "'")
                If dr.Length > 0 Then bLoad = False 'Đã thêm mode rồi thì không thêm nữa
            End If
        End If

        If bLoad Then
            '  If tdbg.Splits.Count > 1 Then
            usrOption.AddColVisible(tdbg, SPLIT0, dtF12, sMode, , COL_Total + 1, L3Int(tdbg.Columns.Count - 1)) 'Duyệt hết split 0 vì có hiển thị các cột ở cuối cùng như COL_D08T0300_Status
            '  usrOption.EditModeColVisible(dtF12, sMode, tdbg, COL_Total, L3Int(tdbg.Columns.Count - 1))
            '        Else
            '
            '        End If
            '****************************
        End If
        usrOption.picClose_Click(Nothing, Nothing)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12, sMode)
    End Sub

    Private Function AllowFilter() As Boolean

        If tdbcDivisionID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Don_vi"))
            tdbcDivisionID.Focus()
            Return False
        End If
        If Not CheckValidPeriodFromTo(tdbcFromPeriod, tdbcToPeriod) Then
            Return False
        End If
        If tdbcTypeCodeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ma_phan_tich"))
            tdbcTypeCodeID.Focus()
            Return False
        End If
        If tdbcFromCCodeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ma_phan_tich"))
            tdbcFromCCodeID.Focus()
            Return False
        End If
        If tdbcToCCodeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Ma_phan_tich"))
            tdbcToCCodeID.Focus()
            Return False
        End If
        If tdbcAssetIDFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Tai_san"))
            tdbcAssetIDFrom.Focus()
            Return False
        End If
        If tdbcAssetIDTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Tai_san"))
            tdbcAssetIDTo.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcFromPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcToPeriod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcAssetIDFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcAssetIDTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcTypeCodeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcFromCCodeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcToCCodeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcDivisionID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Dim dtFormat As DataTable 'bảng cột số 0 hiển thị NULL
    Private Sub tdbg_NumberFormat()
        AddColFormatText(dtFormat, tdbg, DxxFormat.D90_ConvertedDecimals, tdbg.Columns(COL_OpenningCAmount).DataField, tdbg.Columns(COL_NotDepOpenningCAmount).DataField, tdbg.Columns(COL_DepOpenningCAmount).DataField, tdbg.Columns(COL_IncreaseCAmount).DataField, tdbg.Columns(COL_DecreaseCAmount).DataField, tdbg.Columns(COL_ClosingCAmount).DataField, tdbg.Columns(COL_DepreciationAmount).DataField, tdbg.Columns(COL_OpenningLTDDepreciation).DataField, tdbg.Columns(COL_OpenningCost).DataField, tdbg.Columns(COL_NotDepOpenningCost).DataField, tdbg.Columns(COL_DepOpenningCost).DataField, tdbg.Columns(COL_ClosingLTDDepreciation).DataField, tdbg.Columns(COL_RemainAmount).DataField, tdbg.Columns(COL_NotDepRemainAmount).DataField, tdbg.Columns(COL_DepRemainAmount).DataField)
    End Sub


    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click

        'Doan code nay lam theo chuan cho combo phan tich vao tai san
        If ReturnValueC1Combo(tdbcToCCodeID) = "" AndAlso ReturnValueC1Combo(tdbcFromCCodeID) <> "" Then
            tdbcToCCodeID.SelectedValue = ReturnValueC1Combo(tdbcFromCCodeID)
        ElseIf ReturnValueC1Combo(tdbcToCCodeID) <> "" AndAlso ReturnValueC1Combo(tdbcFromCCodeID) = "" Then
            tdbcFromCCodeID.SelectedValue = ReturnValueC1Combo(tdbcToCCodeID)
        End If

        If ReturnValueC1Combo(tdbcAssetIDTo) = "" AndAlso ReturnValueC1Combo(tdbcAssetIDFrom) <> "" Then
            tdbcAssetIDTo.SelectedValue = ReturnValueC1Combo(tdbcAssetIDFrom)
        ElseIf ReturnValueC1Combo(tdbcAssetIDTo) <> "" AndAlso ReturnValueC1Combo(tdbcAssetIDFrom) = "" Then
            tdbcAssetIDFrom.SelectedValue = ReturnValueC1Combo(tdbcAssetIDTo)
        End If

        If ReturnValueC1Combo(tdbcAssetAccountIDTo) = "" AndAlso ReturnValueC1Combo(tdbcAssetAccountIDFrom) <> "" Then
            tdbcAssetAccountIDTo.SelectedValue = ReturnValueC1Combo(tdbcAssetAccountIDFrom)
        ElseIf ReturnValueC1Combo(tdbcAssetAccountIDTo) <> "" AndAlso ReturnValueC1Combo(tdbcAssetAccountIDFrom) = "" Then
            tdbcAssetAccountIDFrom.SelectedValue = ReturnValueC1Combo(tdbcAssetAccountIDTo)
        End If

        If Not AllowFilter() Then Exit Sub

        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        LoadTableCaption()

        LoadTDBGrid(True)
        'dtF12 = Nothing
        CallD99U1111()
        tdbg.Splits(0).LeftCol = 0
        '        tdbg.Splits(0).SplitSize = 9
        '        If tdbg.Splits.Count > 1 Then tdbg.Splits(1).SplitSize = 16
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        If FlagAdd Then
            ' Thêm mới thì gán sFind ="" và gán FilterText =""
            ResetFilter(tdbg, sFilter, bRefreshFilter)
            sFind = ""
        End If
        Dim sSQL As String = SQLStoreD02P3060()
        dtGrid = ReturnDataTable(sSQL)
        If dtGrid Is Nothing Then Exit Sub
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_AssetID)

        '8/4/2022, id 226776-Lỗi dữ liệu màn hình Truy vấn tổng kết khấu hao TSCĐ
        'FooterSumNew(tdbg, COL_OpenningCAmount, COL_NotDepOpenningCAmount, COL_DepOpenningCAmount, COL_IncreaseCAmount, COL_DecreaseCAmount, COL_ClosingCAmount, COL_DepreciationAmount, COL_OpenningLTDDepreciation, COL_OpenningCost, COL_NotDepOpenningCost, COL_DepOpenningCost, COL_ClosingLTDDepreciation, COL_RemainAmount, COL_NotDepRemainAmount, COL_DepRemainAmount)
        FooterSumNew(tdbg, dtFormat)
        ''11/10/2018, Trần Như Đạt: id 113890-Bổ sung tính năng sum tổng ở màn hình Truy vấn Tổng kết khấu hao TSCD D02F3060
        'If sColSumFooter IsNot Nothing AndAlso sColSumFooter.Length > 0 Then FooterSumNew(tdbg, sColSumFooter)
    End Sub
    

    Private Sub tsmExportToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmExportToExcel.Click, tsbExportToExcel.Click, mnsExportToExcel.Click
        'Lưới không có nút Hiển thị
        'Nếu lưới không có Group thì mở dòng code If dtCaptionCols Is Nothing Then
        'và truyền đối số cuối cùng là False vào hàm AddColVisible
        'If dtCaptionCols Is Nothing orelse dtCaptionCols.Rows.Count < 1 Then
        Dim arrColObligatory() As Integer = {COL_AssetID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        Dim frm As New D99F2222
        'Gọi form Xuất Excel như sau:
        'ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, dtCaptionCols, dtGrid, gsGroupColumns)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = dtCaptionCols
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid 'Table load dữ liệu cho lưới
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

#Region "Events tdbcFromPeriod"

    Private Sub tdbcFromPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromPeriod.LostFocus
        If tdbcFromPeriod.FindStringExact(tdbcFromPeriod.Text) = -1 Then tdbcFromPeriod.Text = ""
    End Sub

#End Region

#Region "Events tdbcToPeriod"

    Private Sub tdbcToPeriod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToPeriod.LostFocus
        If tdbcToPeriod.FindStringExact(tdbcToPeriod.Text) = -1 Then tdbcToPeriod.Text = ""
    End Sub

#End Region

#Region "Events tdbcTypeCodeID load tdbcFromCCodeID"

    Private Sub tdbcTypeCodeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeCodeID.SelectedValueChanged
        If tdbcTypeCodeID.SelectedValue Is Nothing OrElse tdbcTypeCodeID.Text = "" Then
            LoadtdbcFromToCCodeID("%")
            tdbcFromCCodeID.SelectedValue = "%"
            tdbcToCCodeID.SelectedValue = "%"
            ReadOnlyControl(tdbcFromCCodeID, tdbcToCCodeID)
            Exit Sub
        End If
        LoadtdbcFromToCCodeID(tdbcTypeCodeID.SelectedValue.ToString())
        If tdbcTypeCodeID.Text = "%" Then
            ReadOnlyControl(tdbcFromCCodeID, tdbcToCCodeID)
        Else
            UnReadOnlyControl(True, tdbcFromCCodeID, tdbcToCCodeID)
        End If
    End Sub

    Private Sub tdbcTypeCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeCodeID.LostFocus
        If tdbcTypeCodeID.FindStringExact(tdbcTypeCodeID.Text) = -1 Then
            tdbcTypeCodeID.Text = ""
            tdbcFromCCodeID.SelectedValue = "%"
            tdbcToCCodeID.SelectedValue = "%"
        End If

    End Sub


#End Region


#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
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
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property


    'Dim dtCaptionCols As DataTable

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then 'Incident 72333
        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {COL_AssetID}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

#Region "tdbg event"

    Dim sFilter As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_FormatText(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FormatTextEventArgs) Handles tdbg.FormatText
        EventFormatText(dtFormat, e)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_ServiceLife, COL_DepreciatedPeriod, COL_RemainPeriod, COL_OpenningCAmount, COL_IncreaseCAmount, COL_DecreaseCAmount, COL_ClosingCAmount, COL_DepreciationAmount, COL_RemainAmount, COL_ClosingLTDDepreciation, COL_RemainAmount, COL_NotDepRemainAmount, COL_DepRemainAmount
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
        If tdbg.Col > COL_Total Then ' all cot dộng la cột số
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If

    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P3061
    '# Created User: Hoàng Nhân
    '# Created Date: 05/12/2013 04:42:14
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P3061() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Khoi tao cot dong cho cac cot Muc khau hao" & vbCrlf)
        sSQL &= "Exec D02P3061 "
        sSQL &= SQLString(tdbcDivisionID.SelectedValue) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcFromPeriod, "TranMonth")) & COMMA 'FromMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcFromPeriod, "TranYear")) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcToPeriod, "TranMonth")) & COMMA 'ToMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcToPeriod, "TranYear")) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P3060
    '# Created User: Hoàng Nhân
    '# Created Date: 05/12/2013 05:22:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P3060() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrlf)
        sSQL &= "Exec D02P3060 "
        sSQL &= SQLString(tdbcDivisionID.SelectedValue) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcFromPeriod, "TranMonth")) & COMMA 'FromMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcFromPeriod, "TranYear")) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcToPeriod, "TranMonth")) & COMMA 'ToMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcToPeriod, "TranYear")) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLString(tdbcAssetIDFrom.Text) & COMMA 'AssetIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcAssetIDTo.Text) & COMMA 'AssetIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTypeCodeID.Text) & COMMA 'TypeCodeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcFromCCodeID.Text) & COMMA 'AcodeIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToCCodeID.Text) & COMMA 'AcodeIDTo, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkISDisposed.Checked) & COMMA 'ISDisposed, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAssetAccountIDFrom)) & COMMA 'AssetAccountIDFrom, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAssetAccountIDTo)) & COMMA 'AssetAccountIDTo, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcObjectID)) 'ObjectID, varchar[50], NOT NULL

        Return sSQL
    End Function
    'ID - 244187 : Bố sung Store In
    Private Function SQLStoreD02P3060_Print(sReportID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrLf)
        sSQL &= "Exec D02P3060 "
        sSQL &= SQLString(tdbcDivisionID.SelectedValue) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcFromPeriod, "TranMonth")) & COMMA 'FromMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcFromPeriod, "TranYear")) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcToPeriod, "TranMonth")) & COMMA 'ToMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(ReturnValueC1Combo(tdbcToPeriod, "TranYear")) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLString(tdbcAssetIDFrom.Text) & COMMA 'AssetIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcAssetIDTo.Text) & COMMA 'AssetIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTypeCodeID.Text) & COMMA 'TypeCodeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcFromCCodeID.Text) & COMMA 'AcodeIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToCCodeID.Text) & COMMA 'AcodeIDTo, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkISDisposed.Checked) & COMMA 'ISDisposed, tinyint, NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAssetAccountIDFrom)) & COMMA 'AssetAccountIDFrom, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcAssetAccountIDTo)) & COMMA 'AssetAccountIDTo, varchar[50], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcObjectID)) & COMMA 'ObjectID, varchar[50], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsWeb, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(sReportID)  'ReportID, varchar[20], NOT NULL
        Return sSQL
    End Function


#Region "Events tdbcAssetIDFrom load tdbcAssetIDTo"

    Private Sub tdbcAssetIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAssetIDFrom.LostFocus
        If tdbcAssetIDFrom.FindStringExact(tdbcAssetIDFrom.Text) = -1 Then
            tdbcAssetIDFrom.Text = ""
            Exit Sub
        End If
        SetValueTo(tdbcAssetIDFrom, tdbcAssetIDTo)
    End Sub

    Private Sub tdbcAssetIDTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAssetIDTo.LostFocus
        If tdbcAssetIDTo.FindStringExact(tdbcAssetIDTo.Text) = -1 Then
            tdbcAssetIDTo.Text = ""
        End If
    End Sub
#End Region
#Region "Events tdbcAssetAccountIDFrom load tdbcAssetAccountIDTo"

    Private Sub tdbcAssetAccountIDFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAssetAccountIDFrom.LostFocus
        If tdbcAssetAccountIDFrom.FindStringExact(tdbcAssetAccountIDFrom.Text) = -1 Then
            tdbcAssetAccountIDFrom.Text = ""
            Exit Sub
        End If
        SetValueTo(tdbcAssetAccountIDFrom, tdbcAssetAccountIDTo)
    End Sub

    Private Sub tdbcAssetAccountIDTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcAssetAccountIDTo.LostFocus
        If tdbcAssetAccountIDTo.FindStringExact(tdbcAssetAccountIDTo.Text) = -1 Then
            tdbcAssetAccountIDTo.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcFromCCodeID load tdbcToCCodeID"

    Private Sub tdbcFromCCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcFromCCodeID.LostFocus
        If tdbcFromCCodeID.FindStringExact(tdbcFromCCodeID.Text) = -1 Then
            tdbcFromCCodeID.Text = ""
            Exit Sub
        End If
        SetValueTo(tdbcFromCCodeID, tdbcToCCodeID)
    End Sub

    Private Sub tdbcToCCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcToCCodeID.LostFocus
        If tdbcToCCodeID.FindStringExact(tdbcToCCodeID.Text) = -1 Then
            tdbcFromCCodeID.Text = ""
            tdbcToCCodeID.Text = ""
        End If

    End Sub
#End Region


    Private Sub mnsExportToCustomExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sReportTypeID As String = "D02F3060"
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

    Private Sub mnsPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click, tsmPrint.Click, mnsPrint.Click
        'Dim sReportTypeID As String = "D02F3060"
        'Dim sReportName As String = "" '"DXXRXXXX"
        'Dim sReportPath As String = ""
        'Dim sReportTitle As String = "" 'Thêm biến
        'Dim sCustomReport As String = "" '= tdbcTranTypeID.Columns("InvoiceForm").Text
        'Try
        '    Dim file As String = GetReportPathNew("02", sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)
        '    If sReportName = "" Then Exit Sub
        '    'MessageBox.Show("DLL D99D0541")
        '    Select Case file.ToLower
        '        '            Case "rpt"
        '        '                printReport(sReportName, sReportPath)
        '        Case "xls", "xlsx"
        '            Me.Cursor = Cursors.WaitCursor
        '            Dim sPathFile As String = GetObjectFile(sReportTypeID, sReportName, file, sReportPath)
        '            If sPathFile = "" Then Exit Select
        '            MyExcel(dtGrid, sPathFile, file, False)
        '    End Select
        'Catch ex As Exception

        'Finally
        '    Me.Cursor = Cursors.Default
        'End Try
        Me.Cursor = Cursors.WaitCursor
        Print(Me)
        Me.Cursor = Cursors.Default
    End Sub


    'Dim report As D99C2003
    'Private Sub printReport(ByVal sReportName As String, ByVal sReportPath As String, ByVal sReportCaption As String, ByVal sSQL As String)
    '    If Not AllowNewD99C2003(report, Me) Then Exit Sub
    '    Dim conn As New SqlConnection(gsConnectionString)
    '    With report
    '        .OpenConnection(conn)
    '        Dim sSQLSub As String = "Select Top 1 * From D91T0025 WITH(NOLOCK)"
    '        Dim sSubReport As String = "D02R0000"
    '        UnicodeSubReport(sSubReport, sSQLSub, gsDivisionID, gbUnicode)
    '        .AddSub(sSQLSub, sSubReport & ".rpt")
    '        .AddMain(sSQL)
    '        .PrintReport(sReportPath, sReportCaption & " - " & sReportName)
    '    End With
    'End Sub
    Dim report As D99C2003
    Private Sub Print(ByVal form As Form, Optional ByVal sReportTypeID As String = "D02F3060", Optional ByVal ModuleID As String = "02")
        Dim sReportName As String = ""
        Dim sReportPath As String = ""
        Dim sReportTitle As String = ""
        Dim sCustomReport As String = ""
        Dim sReportID As String = ""
        Dim file As String = D99D0541.GetReportPathNew(ModuleID, sReportTypeID, sReportName, sCustomReport, sReportPath, sReportTitle)
        If sReportName = "" Then Exit Sub
        form.Cursor = Cursors.WaitCursor
        Dim sSQL As String = ""

        Try
            Select Case file.ToLower
                Case "rpt"
                    If Not AllowNewD99C2003(report, Me) Then form.Cursor = Cursors.Default : Exit Sub
                    '************************************
                    Dim conn As New SqlConnection(gsConnectionString)
                    Dim sReportCaption As String = ""
                    Dim sSubReportName As String = ""
                    Dim sSQLSub As String = ""

                    sReportTitle = "" 'Thêm biến
                    sCustomReport = ""

                    sReportCaption = rL3("Truy_van_tong_ket_khau_hao_TSCD") & " - " & sReportName

                    'Gán giá trị cho sSubReportName và sSQLSub
                    UnicodeSubReport(sSubReportName, sSQLSub, tdbcDivisionID.SelectedValue, True)
                    sSQL = SQLStoreD02P3060_Print(sReportName) 'ID - 244187 : Bố sung Store In
                    With report
                        .OpenConnection(conn)
                        .AddSub(sSQLSub, sSubReportName & ".rpt")
                        .AddMain(sSQL)
                        .PrintReport(sReportPath, sReportCaption)
                    End With
                Case Else
                    sSQL = SQLStoreD02P3060_Print(sReportName)
                    D99D0541.PrintOfficeType(sReportTypeID, sReportName, sReportPath, file, sSQL)
            End Select
        Catch ex As Exception
            form.Cursor = Cursors.Default
        End Try
        form.Cursor = Cursors.Default
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '1/8/2018, id 110619-Hỗ trợ mở rộng màn hình D02F3060
        AnchorForControl(EnumAnchorStyles.TopLeftRight, GroupBox1)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnF12)
    End Sub

    Private Sub tdbcDivisionID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcDivisionID.SelectedValueChanged
        If tdbcDivisionID.SelectedValue Is Nothing OrElse tdbcDivisionID.Text = "" Then
            LoadtdbcAssetToDivisionID("%")
            'ReadOnlyControl(tdbcAssetIDFrom, tdbcAssetIDTo)
            Exit Sub
        End If
        LoadCboPeriodReport(tdbcFromPeriod, tdbcToPeriod, dtPeriod, tdbcDivisionID.Text)
        tdbcFromPeriod.SelectedIndex = 0
        tdbcToPeriod.SelectedIndex = 0
        LoadtdbcAssetToDivisionID(tdbcDivisionID.SelectedValue.ToString())
    End Sub
    Private Sub tdbcDivisionID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = "%"
        End If
        If tdbcDivisionID.Text.Trim = "" Then
            tdbcDivisionID.SelectedValue = "%"
        End If
    End Sub

    'Load 2 combo tài sản theo combo Đơn vị
    Private Sub LoadtdbcAssetToDivisionID(ByVal sDivisionID As String)
        If dtAsset Is Nothing Then Exit Sub
        If tdbcDivisionID.Text = "%" Then
            LoadDataSource(tdbcAssetIDFrom, dtAsset, gbUnicode)
            LoadDataSource(tdbcAssetIDTo, dtAsset.DefaultView.ToTable, gbUnicode)
            tdbcAssetIDFrom.SelectedValue = "%"
            tdbcAssetIDTo.SelectedValue = "%"
            Exit Sub
        End If
        Dim dt As DataTable = ReturnTableFilter(dtAsset, "divisionid = '%' or divisionid = " & SQLString(sDivisionID), True)
        LoadDataSource(tdbcAssetIDFrom, dt, gbUnicode)
        LoadDataSource(tdbcAssetIDTo, dt.DefaultView.ToTable, gbUnicode)
        tdbcAssetIDFrom.SelectedValue = "%"
        tdbcAssetIDTo.SelectedValue = "%"
    End Sub


End Class