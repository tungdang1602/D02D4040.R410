Imports System
Imports System.Text
'#-------------------------------------------------------------------------------------
'# Created Date: 30/09/2010 3:29:46 PM
'# Created User: Thiên Huỳnh
'# Modify Date: 30/09/2010 3:29:46 PM
'# Modify User: Thiên Huỳnh
'#-------------------------------------------------------------------------------------
Public Class D02F3100
	Dim dtCaptionCols As DataTable



#Region "Const of tdbg - Total of Columns: 26"
    Private Const COL_CipNo As Integer = 0           ' Mã XDCB
    Private Const COL_AccountID As Integer = 1       ' Tài khoản
    Private Const COL_CipName As Integer = 2         ' Tên XDCB
    Private Const COL_Status As Integer = 3          ' Trạng thái
    Private Const COL_ContractorID As Integer = 4    ' Mã nhà thầu
    Private Const COL_ContractorName As Integer = 5  ' Tên nhà thầu
    Private Const COL_Description As Integer = 6     ' Diễn giải
    Private Const COL_XCode01ID As Integer = 7       ' Mã phân tích 1
    Private Const COL_XCode02ID As Integer = 8       ' Mã phân tích 2
    Private Const COL_XCode03ID As Integer = 9       ' Mã phân tích 3
    Private Const COL_XCode04ID As Integer = 10      ' Mã phân tích 4
    Private Const COL_XCode05ID As Integer = 11      ' Mã phân tích 5
    Private Const COL_XCode06ID As Integer = 12      ' Mã phân tích 6
    Private Const COL_XCode07ID As Integer = 13      ' Mã phân tích 7
    Private Const COL_XCode08ID As Integer = 14      ' Mã phân tích 8
    Private Const COL_XCode09ID As Integer = 15      ' Mã phân tích 9
    Private Const COL_XCode10ID As Integer = 16      ' Mã phân tích 10
    Private Const COL_OpeningAmt As Integer = 17     ' Số dư đầu kỳ
    Private Const COL_IncreaseAmt As Integer = 18    ' Phát sinh tăng trong kỳ
    Private Const COL_DecreaseAmt As Integer = 19    ' Phát sinh giảm trong kỳ
    Private Const COL_LTDIncreaseAmt As Integer = 20 ' Lũy kế tăng
    Private Const COL_LTDDecreaseAmt As Integer = 21 ' Lũy kế giảm
    Private Const COL_YTDIncreaseAmt As Integer = 22 ' Lũy kế tăng từ đầu năm
    Private Const COL_YTDDecreaseAmt As Integer = 23 ' Lũy kế giảm từ đầu năm
    Private Const COL_ClosingAmt As Integer = 24     ' Số dư cuối kỳ
    Private Const COL_CipID As Integer = 25          ' CipID
#End Region


#Region "Const of tdbg1 - Total of Columns: 10"
    Private Const COLD_VoucherDate As Integer = 0     ' Ngày phiếu
    Private Const COLD_VoucherTypeID As Integer = 1   ' Loại phiếu
    Private Const COLD_VoucherID As Integer = 2       ' Số chứng từ
    Private Const COLD_Decription As Integer = 3      ' Diễn giải phiếu
    Private Const COLD_CipNo As Integer = 4           ' Mã XDCB
    Private Const COLD_CipName As Integer = 5         ' Tên XDCB
    Private Const COLD_DebitAccountID As Integer = 6  ' TK Nợ
    Private Const COLD_CreditAccountID As Integer = 7 ' TK Có
    Private Const COLD_OriginalAmount As Integer = 8  ' Số tiền nguyên tệ
    Private Const COLD_ConvertedAmount As Integer = 9 ' Số tiền quy đổi
#End Region

    Dim dtPeriod As DataTable
    Dim dtCodeID As DataTable
    Dim dtGrid As DataTable
    Dim sFilter As New StringBuilder("")
    Dim sField_Group() As Integer = {COL_OpeningAmt, COL_IncreaseAmt, COL_DecreaseAmt, COL_LTDIncreaseAmt, COL_LTDDecreaseAmt, COL_YTDIncreaseAmt, COL_YTDDecreaseAmt, COL_ClosingAmt}
    Private usrOption As D09U1111
    Dim bLoadUserControl As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeft, grpDivision)
        AnchorForControl(EnumAnchorStyles.TopLeftRight, grpAnylistCode)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg1)

        AnchorForControl(EnumAnchorStyles.BottomLeft, btnShowOption)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnClose)
    End Sub

    Private Sub D02F3100_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
            Case Keys.F5
                btnFilter_Click(sender, e)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
                '*********************************************************
                'Chuẩn hóa Mẫu Truy vấn B3: Các phím nóng
            Case Keys.Escape 'UserControl Hiển thị
                If giRefreshUserControl = 0 Then
                    If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                        usrOption.D09U1111Refresh()
                    End If
                End If
                usrOption.Hide()
            Case Keys.F12  'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
                LoadUserControl()
        End Select
        'If e.KeyCode = Keys.Control Then
        '    If e.KeyCode = Keys.F Then
        '        mnuFind_Click(Nothing, Nothing)
        '    ElseIf e.KeyCode = Keys.A Then
        '        mnuListAll_Click(Nothing, Nothing)
        '    End If
        'End If
    End Sub

    Private Sub D02F3100_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        Loadlanguage()
        LoadTDBCombo()
        InputbyUnicode(Me, gbUnicode)
        ResetColorGrid(tdbg, 0, 1)
        ResetSplitDividerSize(tdbg)
        tdbg_NumberFormat()
        LoadCaptionCipID()
        tdbcPeriodFr.Text = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcPeriodTo.Text = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        '*****************************************
        'Chuẩn hóa D09U1111 B2_0: đẩy vào Arr các cột có Visible = True (khi nhấn các nút trên lưới)
        'CHÚ Ý: Luôn luôn để đúng thứ tự nút Nhấn trên lưới
        'Đặt các dòng code sau vào cuối FormLoad
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList

        'Add column visible and Group
        AddColVisible(tdbg, SPLIT0, Arr, , , , gbUnicode)
        AddColVisible(tdbg, SPLIT1, Arr, , , , gbUnicode)
        '*****************************************
        'Chuẩn hóa D09U1111 B2: Khởi tạo UserControl    
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, Arr)
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, , , , , gbUnicode)
        '*****************************************
        SetShortcutPopupMenu(ContextMenuStrip1)
        MyCheckMenu()
        SetResolutionForm(Me, ContextMenuStrip1)
        grpDetail.Visible = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OpeningAmt).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_IncreaseAmt).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_DecreaseAmt).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_LTDIncreaseAmt).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_LTDDecreaseAmt).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_YTDIncreaseAmt).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_YTDDecreaseAmt).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_ClosingAmt).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg1.Columns(COLD_ConvertedAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg1.Columns(COLD_OriginalAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals

    End Sub


    Private Sub LoadCaptionCipID()
        Dim sSQL As String
        Dim dtTmp As DataTable
        sSQL = "Select TypeCodeID, " & IIf(gsLanguage = "84", "VieTypeCodeName", "EngTypeCodeName").ToString & UnicodeJoin(gbUnicode) & " As TypeCodeName, Disabled From D02T0040 WITH(NOLOCK) WHere Type = 'X'"
        dtTmp = ReturnDataTable(sSQL)
        If dtTmp.Rows.Count > 0 Then
            For i As Integer = 0 To dtTmp.Rows.Count - 1
                tdbg.Splits(0).DisplayColumns(COL_XCode01ID + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(COL_XCode01ID + i).Caption = dtTmp.Rows(i).Item("TypeCodeName").ToString
                tdbg.Splits(0).DisplayColumns(COL_XCode01ID + i).Visible = Not CBool(dtTmp.Rows(i).Item("Disabled").ToString)
            Next
        End If
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_tong_hop_XDCB_-_D02F3100") & UnicodeCaption(gbUnicode) 'Truy vÊn tång híp XDCB - D02F3100
        '================================================================ 
        lblDivisionID.Text = rl3("Don_vi") 'Đơn vị
        lblPeriodFr.Text = rl3("Ky") 'Kỳ
        lblCipNo.Text = rl3("Ma_XDCB") 'Mã XDCB
        lblTypeCodeID.Text = rl3("Ma_phan_tich_XDCB") 'Mã phân tích XDCB
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" '&Lọc
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnShowOption.Text = rl3("Hien_thi") & " (F12)" 'Hiển thị (F12)
        '================================================================ 
        tdbcDivisionID.Columns("DivisionID").Caption = rl3("Ma") 'Mã
        tdbcDivisionID.Columns("DivisionName").Caption = rl3("Ten") 'Tên
        tdbcCodeID.Columns("CodeID").Caption = rl3("Ma") 'Mã
        tdbcCodeID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcTypeCodeID.Columns("TypeCodeID").Caption = rl3("Ma") 'Mã
        tdbcTypeCodeID.Columns("TypeCodeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcCipNo.Columns("CipNo").Caption = rl3("Ma") 'Mã
        tdbcCipNo.Columns("CipName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("CipNo").Caption = rl3("Ma_XDCB") 'Mã XDCB
        tdbg.Columns("CipName").Caption = rl3("Ten_XDCB") 'Tên XDCB
        tdbg.Columns("ContractorID").Caption = rl3("Ma_nha_thau") 'Mã nhà thầu
        tdbg.Columns("ContractorName").Caption = rl3("Ten_nha_thau") 'Tên nhà thầu
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("OpeningAmt").Caption = rl3("So_du_dau_ky") 'Số dư đầu kỳ
        tdbg.Columns("IncreaseAmt").Caption = rl3("Phat_sinh_tang_trong_ky") 'Phát sinh tăng trong kỳ
        tdbg.Columns("DecreaseAmt").Caption = rl3("Phat_sinh_giam_trong_ky") 'Phát sinh giảm trong kỳ
        tdbg.Columns("LTDIncreaseAmt").Caption = rl3("Luy_ke_tang") 'Lũy kế tăng
        tdbg.Columns("LTDDecreaseAmt").Caption = rl3("Luy_ke_giam") 'Lũy kế giảm
        tdbg.Columns("YTDIncreaseAmt").Caption = rl3("Luy_ke_tang_tu_dau_nam") 'Lũy kế tăng từ đầu năm
        tdbg.Columns("YTDDecreaseAmt").Caption = rl3("Luy_ke_giam_tu_dau_nam") 'Lũy kế giảm từ đầu năm
        tdbg.Columns("ClosingAmt").Caption = rl3("So_du_cuoi_ky") 'Số dư cuối kỳ
        '================================================================ 
        'mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        'mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        'mnuExportToExcel.Text = rl3("Xuat__Excel") 'Xuất &Excel

        '================================================================ 
        tdbg.Columns(COL_AccountID).Caption = rL3("Tai_khoan") 'Tài khoản ' ID : 249418 - Bổ sung cột  "Tài Khoản"
        
        '================================================================ 
        grpDetail.Text = rL3("Thong_tin_chi_tiet") 'Thông tin chi tiết
        '================================================================ 
        tdbg1.Columns(COLD_VoucherDate).Caption = rL3("Ngay_phieu") 'Ngày phiếu
        tdbg1.Columns(COLD_VoucherTypeID).Caption = rL3("Loai_phieu") 'Loại phiếu
        tdbg1.Columns(COLD_VoucherID).Caption = rL3("So_chung_tu") 'Số chứng từ
        tdbg1.Columns(COLD_Decription).Caption = rL3("Dien_giai_phieu") 'Diễn giải phiếu
        tdbg1.Columns(COLD_CipNo).Caption = rL3("Ma_XDCB") 'Mã XDCB
        tdbg1.Columns(COLD_CipName).Caption = rL3("Ten_XDCB") 'Tên XDCB
        tdbg1.Columns(COLD_DebitAccountID).Caption = rL3("TK_no") 'TK Nợ
        tdbg1.Columns(COLD_CreditAccountID).Caption = rL3("TK_co") 'TK Có
        tdbg1.Columns(COLD_OriginalAmount).Caption = rL3("So_tien_nguyen_te") 'Số tiền nguyên tệ
        tdbg1.Columns(COLD_ConvertedAmount).Caption = rL3("So_tien_quy_doi") 'Số tiền quy đổi


        '================================================================ 

        tdbg.Columns(COL_Status).Caption = rL3("Trang_thai") 'Trạng thái


    End Sub

    Private Sub LoadUserControl()
        'Nhấn F12: hiển thị usercontrol D09U1111
        If bLoadUserControl Then
            usrOption.Location = New Point(tdbg.Location.X, tdbg.Top + tdbg.Height - usrOption.Height)
            Me.Controls.Add(usrOption)
            usrOption.BringToFront()
            usrOption.ShowForm(tdbg)
            usrOption.Visible = True
            bLoadUserControl = False
        Else
            usrOption.Visible = True
        End If
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDivisionID
        dtPeriod = LoadTablePeriodReport(D02)
        LoadCboDivisionIDAll(tdbcDivisionID, D02, , gbUnicode)

        LoadCboPeriodReport(tdbcPeriodFr, tdbcPeriodTo, dtPeriod, "%")

        'Load tdbcTypeCodeID
        sSQL = "Select 0 as DisplayOrder, '%' As CodeID, " & AllName & " As Description, '%' As TypeCodeID Union" & vbCrLf
        sSQL &= "Select 1 as DisplayOrder,ACodeID As CodeID, Description" & UnicodeJoin(gbUnicode) & " as Description, TypeCodeID From D02T0041 WITH(NOLOCK)" & vbCrLf
        sSQL &= "Where Type = 'X' And Disabled = 0 Order By DisplayOrder,TypeCodeID, CodeID"
        dtCodeID = ReturnDataTable(sSQL)

        sSQL = "Select 0 as DisplayOrder, '%' As TypeCodeID, " & AllName & " As TypeCodeName Union" & vbCrLf
        sSQL &= "Select 1 as DisplayOrder, TypeCodeID, " & IIf(gsLanguage = "84", "VieTypeCodeName", "EngTypeCodeName").ToString & UnicodeJoin(gbUnicode) & " as TypeCodeName" & vbCrLf
        sSQL &= "From D02T0040 WITH(NOLOCK) Where Disabled = 0 And Type = 'X' Order By DisplayOrder,TypeCodeID"
        LoadDataSource(tdbcTypeCodeID, sSQL, gbUnicode)

        LoadCodeID("%")
        LoadCipNo()
    End Sub

    Private Sub LoadCodeID(ByVal ID As String)
        LoadDataSource(tdbcCodeID, ReturnTableFilter(dtCodeID, "TypeCodeID = " & SQLString(ID) & " Or TypeCodeID = '%'", True), gbUnicode)
    End Sub

    Private Sub LoadCipNo()
        Dim sSQL As String
        sSQL = "Select  0 as DisplayOrder,'%' As  CipNo, " & AllName & " As CipName Union" & vbCrLf
        sSQL &= "Select 1 as DisplayOrder,CipNo, CipName" & UnicodeJoin(gbUnicode) & " as CipName From D02T0100 WITH(NOLOCK) Where Disabled = 0" & vbCrLf
        If tdbcDivisionID.Text <> "%" Then
            sSQL &= "And DivisionID = " & SQLString(tdbcDivisionID.Text) & vbCrLf
        End If
        If tdbcTypeCodeID.Text <> "%" And tdbcTypeCodeID.Text <> "" And tdbcCodeID.Text <> "%" And tdbcCodeID.Text <> "" Then
            sSQL &= "And " & tdbcTypeCodeID.Text & "ID" & " = " & SQLString(tdbcCodeID.Text)
        End If
        sSQL &= " Order By DisplayOrder,CipNo"
        LoadDataSource(tdbcCipNo, sSQL, gbUnicode)
    End Sub

    'Public Sub ResetFilter(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
    '    'Set lại các giá trị FilterText
    '    tdbg.UpdateData()
    '    Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
    '    For Each dc In tdbg.Columns
    '        dc.FilterText = ""
    '    Next dc
    'End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Me.Cursor = Cursors.WaitCursor
        ' If sFilter.ToString <> "" Then ResetFilter(tdbg) : sFilter = New StringBuilder("")
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        dtGrid = ReturnDataTable(SQLStoreD02P2200(tdbcCipNo.Text, "", ""))
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        MyCheckMenu()
        FooterSumNew(tdbg, sField_Group)
        FooterTotalGrid(tdbg, COL_CipNo)
    End Sub

    Private Sub MyCheckMenu()
        '6/9/2021, id 183504-Lỗi user KT002 không click chuột phải được
        CheckMenu(Me.Name, ContextMenuStrip1, tdbg.RowCount, gbEnabledUseFind)
    End Sub

    Private Function SQLStoreD02P2200(ByVal sCipNo As String, ByVal sDataType As String, ByVal sCipID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2200 "
        sSQL &= SQLString(tdbcDivisionID.Text) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFr.Columns("TranMonth").Value.ToString) & COMMA 'MonthFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFr.Columns("TranYear").Value.ToString) & COMMA 'YearFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Value.ToString) & COMMA 'MonthTo, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Value.ToString) & COMMA 'YearTo, int, NOT NULL
        sSQL &= SQLString(sCipNo) & COMMA 'CipNo, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTypeCodeID.Text) & COMMA
        sSQL &= SQLString(tdbcCodeID.Text) & COMMA
        sSQL &= SQLNumber(IIf(giTranMonth = 13, 1, 0)) & COMMA
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(sDataType) & COMMA
        sSQL &= SQLString(sCipID)
        Return sSQL
    End Function

#Region "Active Find Client - List All "
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


    Private Sub mnsFind_Click(sender As Object, e As EventArgs) Handles mnsFind.Click
        'If Not CallMenuFromGrid(tdbg, e) Then Exit Sub
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, gdtCaptionExcel, sField_Group)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, gdtCaptionExcel.DefaultView.ToTable), Me, SQLNumber("0"), gbUnicode)
        '*****************************************
    End Sub

    Private Sub mnsListAll_Click(sender As Object, e As EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

#End Region

#Region "Events tdbcDivisionID load tdbcPeriodFr"

    Private Sub tdbcDivisionID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.GotFocus
        'Dùng phím Enter
        tdbcDivisionID.Tag = tdbcDivisionID.Text
    End Sub

    Private Sub tdbcDivisionID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcDivisionID.MouseDown
        'Di chuyển chuột
        tdbcDivisionID.Tag = tdbcDivisionID.Text
    End Sub

    Private Sub tdbcDivisionID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDivisionID.LostFocus
        If tdbcDivisionID.Tag.ToString = "" And tdbcDivisionID.Text = "" Then Exit Sub
        If tdbcDivisionID.Tag.ToString = tdbcDivisionID.Text And tdbcDivisionID.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcDivisionID.FindStringExact(tdbcDivisionID.Text) = -1 Then
            tdbcDivisionID.Text = ""
            LoadCboPeriodReport(tdbcPeriodFr, tdbcPeriodTo, dtPeriod, "-1")
            Exit Sub
        End If
        LoadCboPeriodReport(tdbcPeriodFr, tdbcPeriodTo, dtPeriod, tdbcDivisionID.Text)
    End Sub

    Private Sub tdbcPeriodFr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodFr.LostFocus
        If tdbcPeriodFr.FindStringExact(tdbcPeriodFr.Text) = -1 Then tdbcPeriodFr.Text = ""
    End Sub

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

#End Region

#Region "Events tdbcTypeCodeID load tdbcCodeID with txtCodeName"

    Private Sub tdbcTypeCodeID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeCodeID.GotFocus
        'Dùng phím Enter
        tdbcTypeCodeID.Tag = tdbcTypeCodeID.Text
    End Sub

    Private Sub tdbcTypeCodeID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcTypeCodeID.MouseDown
        'Di chuyển chuột
        tdbcTypeCodeID.Tag = tdbcTypeCodeID.Text
    End Sub

    Private Sub tdbcTypeCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeCodeID.LostFocus
        If tdbcTypeCodeID.Tag.ToString = "" And tdbcTypeCodeID.Text = "" Then Exit Sub
        If tdbcTypeCodeID.Tag.ToString = tdbcTypeCodeID.Text And tdbcTypeCodeID.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcTypeCodeID.FindStringExact(tdbcTypeCodeID.Text) = -1 OrElse tdbcTypeCodeID.SelectedValue Is Nothing Then
            tdbcTypeCodeID.Text = ""
            LoadCodeID("-1")
            LoadCipNo()
            Exit Sub
        End If
        LoadCodeID(tdbcTypeCodeID.SelectedValue.ToString())
        LoadCipNo()
    End Sub

    Private Sub tdbcCodeID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCodeID.GotFocus
        'Dùng phím Enter
        tdbcCodeID.Tag = tdbcCodeID.Text
    End Sub

    Private Sub tdbcCodeID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcCodeID.MouseDown
        'Di chuyển chuột
        tdbcCodeID.Tag = tdbcCodeID.Text
    End Sub

    Private Sub tdbcCodeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCodeID.SelectedValueChanged
        If tdbcCodeID.SelectedValue Is Nothing Then
            txtCodeName.Text = ""
        Else
            txtCodeName.Text = tdbcCodeID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcCodeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCodeID.LostFocus
        If tdbcCodeID.Tag.ToString = "" And tdbcCodeID.Text = "" Then Exit Sub
        If tdbcCodeID.Tag.ToString = tdbcCodeID.Text And tdbcCodeID.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcTypeCodeID.FindStringExact(tdbcTypeCodeID.Text) = -1 OrElse tdbcTypeCodeID.SelectedValue Is Nothing Then
            tdbcCodeID.Text = ""
        End If
        LoadCipNo()
    End Sub

    Private Sub tdbcCipNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCipNo.SelectedValueChanged
        If tdbcCipNo.SelectedValue Is Nothing Then
            txtCipName.Text = ""
        Else
            txtCipName.Text = tdbcCipNo.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcCipNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcCipNo.LostFocus
        If tdbcCipNo.FindStringExact(tdbcCipNo.Text) = -1 Then tdbcCipNo.Text = ""
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnShowOption_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowOption.Click
        LoadUserControl()
    End Sub

    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub


    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_OpeningAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_IncreaseAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_DecreaseAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_LTDIncreaseAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_LTDDecreaseAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_YTDIncreaseAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_YTDDecreaseAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_ClosingAmt
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub mnsExportToExcel_Click(sender As Object, e As EventArgs) Handles mnsExportToExcel.Click
        'If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        '*****************************************
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)
        'Chuẩn hóa D09U1111 B7: Xuất Excel (Nếu lưới có nút Hiển thị)
        'Dim frm As New D99F2222
        'ResetTableForExcel(tdbg, gdtCaptionExcel, sField_Group)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = gdtCaptionExcel
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With


    End Sub

    'Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
    '    mnuFind.Enabled = tdbg.RowCount > 0 Or gbEnabledUseFind
    '    mnuListAll.Enabled = tdbg.RowCount > 0 Or gbEnabledUseFind
    '    mnuExportToExcel.Enabled = tdbg.RowCount > 0
    'End Sub
    Dim dtGridD As DataTable
    Private Sub LoadTDBGridDetail()
        If mnsShowDetail.Checked Then
            dtGridD = ReturnDataTable(SQLStoreD02P2200(tdbg.Columns(COL_CipNo).Text, "Grid_Details", tdbg.Columns(COL_CipID).Text))

            LoadDataSource(tdbg1, dtGridD, gbUnicode)
        End If
       
    End Sub
    Private Sub mnsShowDetail_Click(sender As Object, e As EventArgs) Handles mnsShowDetail.Click
        mnsShowDetail.Checked = Not mnsShowDetail.Checked
        grpDetail.Visible = mnsShowDetail.Checked
        If mnsShowDetail.Checked Then
            tdbg.Height = tdbg.Height - grpDetail.Height - 10
        Else
            tdbg.Height = tdbg.Height + grpDetail.Height + 10
        End If

        LoadTDBGridDetail()
    End Sub

    Private Sub tdbg_RowColChange(sender As Object, e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If mnsShowDetail.Checked Then
            LoadTDBGridDetail()
        End If
    End Sub

End Class