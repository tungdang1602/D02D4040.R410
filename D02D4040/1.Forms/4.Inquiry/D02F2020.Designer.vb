<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F2020
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F2020))
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbFind = New System.Windows.Forms.ToolStripButton()
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsdActive = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_DExport = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_DPrint = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tdbcAssetID = New C1.Win.C1List.C1Combo()
        Me.lblAssetID = New System.Windows.Forms.Label()
        Me.txtAssetName = New System.Windows.Forms.TextBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_Export = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_Print = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tdbcPeriodTo = New C1.Win.C1List.C1Combo()
        Me.tdbcPeriodFrom = New C1.Win.C1List.C1Combo()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblPeriod = New System.Windows.Forms.Label()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.tdbcAssetID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPeriodTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPeriodFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(10, 10)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(500, 500)
        Me.C1TrueDBGrid1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator2, Me.tsbExportToExcel, Me.ToolStripSeparator5, Me.tsbPrint, Me.ToolStripSeparator9, Me.tsbClose, Me.ToolStripSeparator10, Me.tsdActive})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1018, 26)
        Me.ToolStrip1.TabIndex = 10
        '
        'tsbFind
        '
        Me.tsbFind.Name = "tsbFind"
        Me.tsbFind.Size = New System.Drawing.Size(68, 23)
        Me.tsbFind.Text = "Tìm &kiếm"
        '
        'tsbListAll
        '
        Me.tsbListAll.Name = "tsbListAll"
        Me.tsbListAll.Size = New System.Drawing.Size(91, 23)
        Me.tsbListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 26)
        '
        'tsbExportToExcel
        '
        Me.tsbExportToExcel.Name = "tsbExportToExcel"
        Me.tsbExportToExcel.Size = New System.Drawing.Size(74, 23)
        Me.tsbExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 26)
        '
        'tsbPrint
        '
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(25, 23)
        Me.tsbPrint.Text = "&In"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 26)
        '
        'tsbClose
        '
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(47, 23)
        Me.tsbClose.Text = "Đón&g"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 26)
        '
        'tsdActive
        '
        Me.tsdActive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFind, Me.tsmListAll, Me.ToolStripSeparator_DExport, Me.tsmExportToExcel, Me.ToolStripSeparator_DPrint, Me.tsmPrint})
        Me.tsdActive.Name = "tsdActive"
        Me.tsdActive.Size = New System.Drawing.Size(82, 23)
        Me.tsdActive.Text = "&Thực hiện"
        '
        'tsmFind
        '
        Me.tsmFind.Name = "tsmFind"
        Me.tsmFind.Size = New System.Drawing.Size(160, 24)
        Me.tsmFind.Text = "Tìm &kiếm"
        '
        'tsmListAll
        '
        Me.tsmListAll.Name = "tsmListAll"
        Me.tsmListAll.Size = New System.Drawing.Size(160, 24)
        Me.tsmListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator_DExport
        '
        Me.ToolStripSeparator_DExport.Name = "ToolStripSeparator_DExport"
        Me.ToolStripSeparator_DExport.Size = New System.Drawing.Size(157, 6)
        '
        'tsmExportToExcel
        '
        Me.tsmExportToExcel.Name = "tsmExportToExcel"
        Me.tsmExportToExcel.Size = New System.Drawing.Size(160, 24)
        Me.tsmExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator_DPrint
        '
        Me.ToolStripSeparator_DPrint.Name = "ToolStripSeparator_DPrint"
        Me.ToolStripSeparator_DPrint.Size = New System.Drawing.Size(157, 6)
        '
        'tsmPrint
        '
        Me.tsmPrint.Name = "tsmPrint"
        Me.tsmPrint.Size = New System.Drawing.Size(160, 24)
        Me.tsmPrint.Text = "&In"
        '
        'tdbcAssetID
        '
        Me.tdbcAssetID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcAssetID.AllowColMove = False
        Me.tdbcAssetID.AllowSort = False
        Me.tdbcAssetID.AlternatingRows = True
        Me.tdbcAssetID.AutoCompletion = True
        Me.tdbcAssetID.AutoDropDown = True
        Me.tdbcAssetID.Caption = ""
        Me.tdbcAssetID.CaptionHeight = 17
        Me.tdbcAssetID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcAssetID.ColumnCaptionHeight = 17
        Me.tdbcAssetID.ColumnFooterHeight = 17
        Me.tdbcAssetID.ColumnWidth = 100
        Me.tdbcAssetID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcAssetID.DisplayMember = "AssetID"
        Me.tdbcAssetID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcAssetID.DropDownWidth = 500
        Me.tdbcAssetID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcAssetID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcAssetID.EmptyRows = True
        Me.tdbcAssetID.ExtendRightColumn = True
        Me.tdbcAssetID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetID.Images.Add(CType(resources.GetObject("tdbcAssetID.Images"), System.Drawing.Image))
        Me.tdbcAssetID.ItemHeight = 15
        Me.tdbcAssetID.Location = New System.Drawing.Point(391, 31)
        Me.tdbcAssetID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcAssetID.MaxDropDownItems = CType(8, Short)
        Me.tdbcAssetID.MaxLength = 20
        Me.tdbcAssetID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcAssetID.Name = "tdbcAssetID"
        Me.tdbcAssetID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcAssetID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcAssetID.Size = New System.Drawing.Size(169, 23)
        Me.tdbcAssetID.TabIndex = 5
        Me.tdbcAssetID.ValueMember = "AssetID"
        Me.tdbcAssetID.PropBag = resources.GetString("tdbcAssetID.PropBag")
        '
        'lblAssetID
        '
        Me.lblAssetID.AutoSize = True
        Me.lblAssetID.Location = New System.Drawing.Point(290, 36)
        Me.lblAssetID.Name = "lblAssetID"
        Me.lblAssetID.Size = New System.Drawing.Size(56, 13)
        Me.lblAssetID.TabIndex = 4
        Me.lblAssetID.Text = "Mã tài sản"
        Me.lblAssetID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAssetName
        '
        Me.txtAssetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtAssetName.Location = New System.Drawing.Point(566, 31)
        Me.txtAssetName.MaxLength = 250
        Me.txtAssetName.Name = "txtAssetName"
        Me.txtAssetName.ReadOnly = True
        Me.txtAssetName.Size = New System.Drawing.Size(367, 22)
        Me.txtAssetName.TabIndex = 6
        Me.txtAssetName.TabStop = False
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(939, 31)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 7
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator_Export, Me.mnsExportToExcel, Me.ToolStripSeparator_Print, Me.mnsPrint})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(157, 112)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(156, 24)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(156, 24)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator_Export
        '
        Me.ToolStripSeparator_Export.Name = "ToolStripSeparator_Export"
        Me.ToolStripSeparator_Export.Size = New System.Drawing.Size(153, 6)
        '
        'mnsExportToExcel
        '
        Me.mnsExportToExcel.Name = "mnsExportToExcel"
        Me.mnsExportToExcel.Size = New System.Drawing.Size(156, 24)
        Me.mnsExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator_Print
        '
        Me.ToolStripSeparator_Print.Name = "ToolStripSeparator_Print"
        Me.ToolStripSeparator_Print.Size = New System.Drawing.Size(153, 6)
        '
        'mnsPrint
        '
        Me.mnsPrint.Name = "mnsPrint"
        Me.mnsPrint.Size = New System.Drawing.Size(156, 24)
        Me.mnsPrint.Text = "&In"
        '
        'btnF12
        '
        Me.btnF12.AutoSize = True
        Me.btnF12.FlatAppearance.BorderSize = 0
        Me.btnF12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnF12.ForeColor = System.Drawing.Color.Blue
        Me.btnF12.Location = New System.Drawing.Point(0, 614)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(35, 23)
        Me.btnF12.TabIndex = 9
        Me.btnF12.Text = "F12"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 62)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1012, 547)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 8
        Me.tdbg.Tag = "COL"
        '
        'tdbcPeriodTo
        '
        Me.tdbcPeriodTo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodTo.AllowColMove = False
        Me.tdbcPeriodTo.AllowColSelect = True
        Me.tdbcPeriodTo.AllowSort = False
        Me.tdbcPeriodTo.AlternatingRows = True
        Me.tdbcPeriodTo.AutoCompletion = True
        Me.tdbcPeriodTo.AutoDropDown = True
        Me.tdbcPeriodTo.AutoSelect = True
        Me.tdbcPeriodTo.Caption = ""
        Me.tdbcPeriodTo.CaptionHeight = 17
        Me.tdbcPeriodTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodTo.ColumnCaptionHeight = 17
        Me.tdbcPeriodTo.ColumnFooterHeight = 17
        Me.tdbcPeriodTo.ColumnHeaders = False
        Me.tdbcPeriodTo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodTo.DisplayMember = "Period"
        Me.tdbcPeriodTo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodTo.DropDownWidth = 89
        Me.tdbcPeriodTo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodTo.EmptyRows = True
        Me.tdbcPeriodTo.ExtendRightColumn = True
        Me.tdbcPeriodTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.Images.Add(CType(resources.GetObject("tdbcPeriodTo.Images"), System.Drawing.Image))
        Me.tdbcPeriodTo.ItemHeight = 15
        Me.tdbcPeriodTo.Location = New System.Drawing.Point(154, 31)
        Me.tdbcPeriodTo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodTo.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodTo.MaxLength = 32767
        Me.tdbcPeriodTo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodTo.Name = "tdbcPeriodTo"
        Me.tdbcPeriodTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodTo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodTo.Size = New System.Drawing.Size(89, 23)
        Me.tdbcPeriodTo.TabIndex = 3
        Me.tdbcPeriodTo.ValueMember = "Period"
        Me.tdbcPeriodTo.PropBag = resources.GetString("tdbcPeriodTo.PropBag")
        '
        'tdbcPeriodFrom
        '
        Me.tdbcPeriodFrom.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodFrom.AllowColMove = False
        Me.tdbcPeriodFrom.AllowColSelect = True
        Me.tdbcPeriodFrom.AllowSort = False
        Me.tdbcPeriodFrom.AlternatingRows = True
        Me.tdbcPeriodFrom.AutoCompletion = True
        Me.tdbcPeriodFrom.AutoDropDown = True
        Me.tdbcPeriodFrom.AutoSelect = True
        Me.tdbcPeriodFrom.Caption = ""
        Me.tdbcPeriodFrom.CaptionHeight = 17
        Me.tdbcPeriodFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodFrom.ColumnCaptionHeight = 17
        Me.tdbcPeriodFrom.ColumnFooterHeight = 17
        Me.tdbcPeriodFrom.ColumnHeaders = False
        Me.tdbcPeriodFrom.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodFrom.DisplayMember = "Period"
        Me.tdbcPeriodFrom.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodFrom.DropDownWidth = 89
        Me.tdbcPeriodFrom.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodFrom.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFrom.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodFrom.EmptyRows = True
        Me.tdbcPeriodFrom.ExtendRightColumn = True
        Me.tdbcPeriodFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFrom.Images.Add(CType(resources.GetObject("tdbcPeriodFrom.Images"), System.Drawing.Image))
        Me.tdbcPeriodFrom.ItemHeight = 15
        Me.tdbcPeriodFrom.Location = New System.Drawing.Point(45, 31)
        Me.tdbcPeriodFrom.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodFrom.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodFrom.MaxLength = 32767
        Me.tdbcPeriodFrom.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodFrom.Name = "tdbcPeriodFrom"
        Me.tdbcPeriodFrom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodFrom.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodFrom.Size = New System.Drawing.Size(89, 23)
        Me.tdbcPeriodFrom.TabIndex = 1
        Me.tdbcPeriodFrom.ValueMember = "Period"
        Me.tdbcPeriodFrom.PropBag = resources.GetString("tdbcPeriodFrom.PropBag")
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.Location = New System.Drawing.Point(137, 36)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(13, 13)
        Me.lblLine.TabIndex = 2
        Me.lblLine.Text = "--"
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(8, 36)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(19, 13)
        Me.lblPeriod.TabIndex = 0
        Me.lblPeriod.Text = "Kỳ"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'D02F2020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 637)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.tdbcPeriodTo)
        Me.Controls.Add(Me.tdbcPeriodFrom)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.tdbcAssetID)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblAssetID)
        Me.Controls.Add(Me.txtAssetName)
        Me.Controls.Add(Me.tdbg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F2020"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Truy vÊn tØnh hØnh tªi s¶n cç ¢Ünh vª XDCB - D02F2020"
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.tdbcAssetID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPeriodTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPeriodFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbExportToExcel As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsdActive As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsmFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsmListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_DExport As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsmExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_DPrint As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsmPrint As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tdbcAssetID As C1.Win.C1List.C1Combo
    Private WithEvents lblAssetID As System.Windows.Forms.Label
    Private WithEvents txtAssetName As System.Windows.Forms.TextBox
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents btnF12 As System.Windows.Forms.Button
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Export As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Print As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsPrint As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbcPeriodTo As C1.Win.C1List.C1Combo
    Private WithEvents tdbcPeriodFrom As C1.Win.C1List.C1Combo
    Private WithEvents lblLine As System.Windows.Forms.Label
    Private WithEvents lblPeriod As System.Windows.Forms.Label
End Class