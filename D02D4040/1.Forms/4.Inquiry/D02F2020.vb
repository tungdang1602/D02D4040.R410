Public Class D02F2020
	Dim report As D99C2003
	Dim dtCaptionCols As DataTable

#Region "Const of tdbg"
    Private Const COL_OrderNo As Integer = 0           ' STT
    Private Const COL_AssetID As Integer = 1           ' Mã tài sản
    Private Const COL_CipNo As Integer = 2             ' Mã XDCB
    Private Const COL_Description As Integer = 3       ' Diễn giải
    Private Const COL_EstimateCost As Integer = 4      ' Dự toán hạng mục
    Private Const COL_ActualCost As Integer = 5        ' Giá trị thi công
    Private Const COL_DifferenceCAmount As Integer = 6 ' Chênh lệch
#End Region

    Dim dtPeriod As DataTable
    Dim dtGrid As New DataTable
    'Dim dtCaptionCols As DataTable
    Dim bRefreshFilter As Boolean = False
    Dim sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    Dim sFilter As New StringBuilder
    Dim bIsLoadForm As Boolean = False

    Private Sub LoadTDBCombo()
        dtPeriod = LoadTablePeriodReport(D02)
        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, dtPeriod, gsDivisionID)
        tdbcPeriodFrom.SelectedValue = Format(giTranMonth, "00") & "/" & giTranYear.ToString
        tdbcPeriodTo.SelectedValue = Format(giTranMonth, "00") & "/" & giTranYear.ToString

        'Load tdbcAssetID
        Dim sSQL As String = ""
        sSQL = "Select " & AllCode & " as AssetID, " & AllName & " as Assetname, 0 AS DisplayOrder "
        sSQL &= "Union All "
        sSQL &= "Select AssetID, Assetname" & UnicodeJoin(gbUnicode) & " as Assetname, 1 AS DisplayOrder "
        sSQL &= "From D02T0001 WITH(NOLOCK) "
        sSQL &= "Where DivisionID = " & SQLString(gsDivisionID)
        sSQL &= " Order by DisplayOrder, AssetID"
        LoadDataSource(tdbcAssetID, sSQL, gbUnicode)
        tdbcAssetID.SelectedIndex = 0
    End Sub

    Private Sub D02F2020_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(sender, Nothing)
        ElseIf e.KeyCode = Keys.F12 Then ' Mở
            btnF12_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then 'Đóng
            If giRefreshUserControl = 0 Then
                If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                    usrOption.D09U1111Refresh()
                End If
            End If
            usrOption.Hide()
        End If
    End Sub

    Private Sub D02F2020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        gbEnabledUseFind = False
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        LoadTDBCombo()
        CallD09U1111(True)
        tdbg_NumberFormat()
        ResetGrid()
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        SetBackColorObligatory()
        ResetColorGrid(tdbg)
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub
#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub
#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

#End Region
    Private Sub tdbcAssetID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetID.SelectedValueChanged
        If tdbcAssetID.SelectedValue Is Nothing Then
            txtAssetName.Text = ""
        Else
            txtAssetName.Text = tdbcAssetID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcAssetID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAssetID.LostFocus
        If tdbcAssetID.FindStringExact(tdbcAssetID.Text) = -1 Then
            tdbcAssetID.Text = ""
        End If
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2021
    '# Created User: Trần Hoàng Nhân
    '# Created Date: 23/05/2012 04:11:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2021() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D02P2021 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcPeriodFrom)) & COMMA 'PeriodFrom, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcPeriodTo)) & COMMA 'PeriodTo, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcAssetID.Text) & COMMA 'AssetID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD02P2021()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub
    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        tsbFind.Enabled = gbEnabledUseFind Or tdbg.RowCount > 0
        tsmFind.Enabled = tsbFind.Enabled
        mnsFind.Enabled = tsbFind.Enabled

        tsbListAll.Enabled = tsbFind.Enabled
        tsmListAll.Enabled = tsbListAll.Enabled
        mnsListAll.Enabled = tsbListAll.Enabled

        tsbPrint.Enabled = tdbg.RowCount > 0
        tsmPrint.Enabled = tsbPrint.Enabled
        mnsPrint.Enabled = tsbPrint.Enabled

        tsbExportToExcel.Enabled = tdbg.RowCount > 0
        tsmExportToExcel.Enabled = tsbExportToExcel.Enabled
        mnsExportToExcel.Enabled = tsbExportToExcel.Enabled

        FooterTotalGrid(tdbg, COL_AssetID)
        ' FooterSumNew(tdbg, COL_ActualCost, COL_EstimateCost)
        UpdateTDBGOrderNum(tdbg, COL_OrderNo, , True)
        '*Them ngay 26/3/2013 theo ID 55336 bởi Văn Vinh
        FooterSumNew(tdbg, COL_EstimateCost, COL_ActualCost, COL_DifferenceCAmount)
        '**************************************
    End Sub
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False
    'Cần sửa Tìm kiếm như sau:
	'Bỏ sự kiện Finder_FindClick.
	'Sửa tham số Me.Name -> Me
	'Phải tạo biến properties có tên chính xác strNewFind và strNewServer
	'Sửa gdtCaptionExcel thành dtCaptionCols: biến toàn cục trong form
	'Nếu có F12 dùng D09U1111 thì Sửa dtCaptionCols thành ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable)

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        'If dtCaptionCols Is Nothing OrElse dtCaptionCols.Rows.Count < 1 Then 'Incident 72333
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbg, SPLIT0, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)
        'End If
        Dim ArrFieldExclude() As String = {"OrderNo"}
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode, ArrFieldExclude)
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub tdbg_FilterChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
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

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If e.ColIndex = COL_OrderNo Then
            tdbg.AllowSort = False
        Else
            tdbg.AllowSort = True
        End If
    End Sub

 
    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e, COL_OrderNo)
    End Sub
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_OrderNo
                e.Handled = CheckKeyPress(e.KeyChar, True)
            Case COL_EstimateCost, COL_ActualCost
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_DifferenceCAmount
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDotSign)
        End Select
    End Sub

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If Not AllowSave() Then Exit Sub
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        LoadTDBGrid()
    End Sub
    Private usrOption As D09U1111
    Dim arr As New ArrayList

    Private Sub CallD09U1111(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst = True Then

            'Những cột bắt buộc nhập
            '  Dim arrColObligatory() As Integer = {COL_VoucherID, COL_ItemName, COL_CurrencyID, COL_ExchangeRate, COL_OriginalAmount, COL_ConvertedAmount}
            '-----------------------------------
            'Các cột ở SPLIT0
            AddColVisible(tdbg, SPLIT0, arr, , , , gbUnicode)
            AddColVisible(tdbg, SPLIT1, arr, , , , gbUnicode)
        End If
        'Dim dtCaptionCols As DataTable
        dtCaptionCols = CreateTableForExcel(tdbg, arr)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub


    Private Sub btnF12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsPrint.Click, tsbPrint.Click, tsmPrint.Click
        '    If Not AllowPrint() Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
		If Not AllowNewD99C2003(report, Me) Then Exit Sub
		'************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D02R2020"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        'Dim sSQL As String = ""
        Dim sSubReportName As String = ""
        Dim sSQLSub As String = ""

        'Gán giá trị cho sSubReportName và sSQLSub
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, True)
        sReportCaption = rl3("Truy_van_tinh_hinh_tai_san_co_dinh_va_XDCB_VF") & " - " & sReportName
        'Gán giá trị cho sPathReport
        sPathReport = UnicodeGetReportPath(gbUnicode, D02Options.ReportLanguage, "") & sReportName & ".rpt"
        ' sSQL = "?????"
        With report
            .OpenConnection(conn)
            ' .AddParameter("?????", "?????")
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(dtGrid.DefaultView.ToTable)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportToExcel.Click, mnsExportToExcel.Click, tsmExportToExcel.Click
        '*****************************************
        'Chuẩn hóa D09U1111: Xuất Excel (Nếu lưới có nút Hiển thị)
        'Dim frm As New D99F2222	
        'ResetTableForExcel(tdbg, gdtCaptionExcel)
        'With frm
        '    .UseUnicode = gbUnicode
        '    .FormID = Me.Name
        '    .dtLoadGrid = gdtCaptionExcel
        '    .GroupColumns = gsGroupColumns
        '    .dtExportTable = dtGrid
        '    .ShowDialog()
        '    .Dispose()
        'End With
        'Gọi form Xuất Excel như sau:
        ResetTableForExcel(tdbg, dtCaptionCols)
        CallShowD99F2222(Me, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), dtGrid, gsGroupColumns)

    End Sub
    Private Function AllowSave() As Boolean
        If tdbcPeriodFrom.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcPeriodFrom.Focus()
            Return False
        End If
        If tdbcPeriodTo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Ky"))
            tdbcPeriodTo.Focus()
            Return False
        End If
        If Not CheckValidPeriodFromTo(tdbcPeriodFrom, tdbcPeriodTo) Then
            Return False
        End If
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Truy_van_tinh_hinh_tai_san_co_dinh_va_XDCB_-_D02F2020") & UnicodeCaption(gbUnicode) 'Truy vÊn tØnh hØnh tªi s¶n cç ¢Ünh vª XDCB - D02F2020
        '================================================================ 
        lblAssetID.Text = rl3("Ma_tai_san") 'Mã tài sản
        lblPeriod.Text = rl3("Ky") 'Kỳ
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnF12.Text = "F12 (" & rl3("Hien_thi") & ")" ' Hiển thị
        '================================================================ 
        tdbcAssetID.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcAssetID.Columns("Assetname").Caption = rl3("Ten") 'Tên
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        '================================================================ 
        tdbg.Columns("OrderNo").Caption = rl3("STT") 'STT
        tdbg.Columns("AssetID").Caption = rl3("Ma_tai_san") 'Mã tài sản
        tdbg.Columns("CipNo").Caption = rl3("Ma_XDCB") 'Mã XDCB
        tdbg.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns("EstimateCost").Caption = rL3("Du_toan_han_muc") 'Dự toán hạn mục
        tdbg.Columns("ActualCost").Caption = rL3("Gia_tri_thi_cong") 'Giá trị thi công
        tdbg.Columns("DifferenceCAmount").Caption = rL3("Chenh_lech") 'Chênh lệch
    End Sub
    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_EstimateCost).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_ActualCost).NumberFormat = DxxFormat.D90_ConvertedDecimals
        tdbg.Columns(COL_DifferenceCAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    End Sub
    
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AnchorForControl(EnumAnchorStyles.TopLeftRight, txtAssetName)
        AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnF12)
    End Sub
End Class