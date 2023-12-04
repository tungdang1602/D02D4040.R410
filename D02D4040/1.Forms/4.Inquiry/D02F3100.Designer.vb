<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F3100
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F3100))
        Me.grpDivision = New System.Windows.Forms.GroupBox()
        Me.lblDivisionID = New System.Windows.Forms.Label()
        Me.tdbcPeriodTo = New C1.Win.C1List.C1Combo()
        Me.tdbcPeriodFr = New C1.Win.C1List.C1Combo()
        Me.lblPeriodFr = New System.Windows.Forms.Label()
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo()
        Me.grpAnylistCode = New System.Windows.Forms.GroupBox()
        Me.lblCipNo = New System.Windows.Forms.Label()
        Me.lblTypeCodeID = New System.Windows.Forms.Label()
        Me.tdbcCodeID = New C1.Win.C1List.C1Combo()
        Me.tdbcTypeCodeID = New C1.Win.C1List.C1Combo()
        Me.tdbcCipNo = New C1.Win.C1List.C1Combo()
        Me.txtCipName = New System.Windows.Forms.TextBox()
        Me.txtCodeName = New System.Windows.Forms.TextBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsShowDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_Export = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnShowOption = New System.Windows.Forms.Button()
        Me.tdbg1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grpDetail = New System.Windows.Forms.GroupBox()
        Me.grpDivision.SuspendLayout()
        CType(Me.tdbcPeriodTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPeriodFr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAnylistCode.SuspendLayout()
        CType(Me.tdbcCodeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcTypeCodeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcCipNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDivision
        '
        Me.grpDivision.Controls.Add(Me.lblDivisionID)
        Me.grpDivision.Controls.Add(Me.tdbcPeriodTo)
        Me.grpDivision.Controls.Add(Me.tdbcPeriodFr)
        Me.grpDivision.Controls.Add(Me.lblPeriodFr)
        Me.grpDivision.Controls.Add(Me.tdbcDivisionID)
        Me.grpDivision.Location = New System.Drawing.Point(3, 3)
        Me.grpDivision.Name = "grpDivision"
        Me.grpDivision.Size = New System.Drawing.Size(325, 80)
        Me.grpDivision.TabIndex = 0
        Me.grpDivision.TabStop = False
        '
        'lblDivisionID
        '
        Me.lblDivisionID.AutoSize = True
        Me.lblDivisionID.Location = New System.Drawing.Point(11, 24)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(38, 13)
        Me.lblDivisionID.TabIndex = 0
        Me.lblDivisionID.Text = "Đơn vị"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.tdbcPeriodTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodTo.ColumnHeaders = False
        Me.tdbcPeriodTo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodTo.DisplayMember = "Period"
        Me.tdbcPeriodTo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodTo.DropDownWidth = 94
        Me.tdbcPeriodTo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodTo.EmptyRows = True
        Me.tdbcPeriodTo.ExtendRightColumn = True
        Me.tdbcPeriodTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.Images.Add(CType(resources.GetObject("tdbcPeriodTo.Images"), System.Drawing.Image))
        Me.tdbcPeriodTo.Location = New System.Drawing.Point(223, 47)
        Me.tdbcPeriodTo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodTo.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodTo.MaxLength = 32767
        Me.tdbcPeriodTo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodTo.Name = "tdbcPeriodTo"
        Me.tdbcPeriodTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodTo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodTo.Size = New System.Drawing.Size(94, 21)
        Me.tdbcPeriodTo.TabIndex = 5
        Me.tdbcPeriodTo.ValueMember = "Period"
        Me.tdbcPeriodTo.PropBag = resources.GetString("tdbcPeriodTo.PropBag")
        '
        'tdbcPeriodFr
        '
        Me.tdbcPeriodFr.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodFr.AllowColMove = False
        Me.tdbcPeriodFr.AllowSort = False
        Me.tdbcPeriodFr.AlternatingRows = True
        Me.tdbcPeriodFr.AutoCompletion = True
        Me.tdbcPeriodFr.AutoDropDown = True
        Me.tdbcPeriodFr.AutoSelect = True
        Me.tdbcPeriodFr.Caption = ""
        Me.tdbcPeriodFr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodFr.ColumnHeaders = False
        Me.tdbcPeriodFr.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodFr.DisplayMember = "Period"
        Me.tdbcPeriodFr.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodFr.DropDownWidth = 94
        Me.tdbcPeriodFr.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodFr.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFr.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodFr.EmptyRows = True
        Me.tdbcPeriodFr.ExtendRightColumn = True
        Me.tdbcPeriodFr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFr.Images.Add(CType(resources.GetObject("tdbcPeriodFr.Images"), System.Drawing.Image))
        Me.tdbcPeriodFr.Location = New System.Drawing.Point(108, 47)
        Me.tdbcPeriodFr.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodFr.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodFr.MaxLength = 32767
        Me.tdbcPeriodFr.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodFr.Name = "tdbcPeriodFr"
        Me.tdbcPeriodFr.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodFr.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodFr.Size = New System.Drawing.Size(94, 21)
        Me.tdbcPeriodFr.TabIndex = 3
        Me.tdbcPeriodFr.ValueMember = "Period"
        Me.tdbcPeriodFr.PropBag = resources.GetString("tdbcPeriodFr.PropBag")
        '
        'lblPeriodFr
        '
        Me.lblPeriodFr.AutoSize = True
        Me.lblPeriodFr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodFr.Location = New System.Drawing.Point(11, 53)
        Me.lblPeriodFr.Name = "lblPeriodFr"
        Me.lblPeriodFr.Size = New System.Drawing.Size(19, 13)
        Me.lblPeriodFr.TabIndex = 2
        Me.lblPeriodFr.Text = "Kỳ"
        Me.lblPeriodFr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcDivisionID
        '
        Me.tdbcDivisionID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDivisionID.AllowColMove = False
        Me.tdbcDivisionID.AllowColSelect = True
        Me.tdbcDivisionID.AllowSort = False
        Me.tdbcDivisionID.AlternatingRows = True
        Me.tdbcDivisionID.AutoCompletion = True
        Me.tdbcDivisionID.AutoDropDown = True
        Me.tdbcDivisionID.AutoSelect = True
        Me.tdbcDivisionID.Caption = ""
        Me.tdbcDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDivisionID.ColumnWidth = 100
        Me.tdbcDivisionID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDivisionID.DisplayMember = "DivisionID"
        Me.tdbcDivisionID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDivisionID.DropDownWidth = 500
        Me.tdbcDivisionID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDivisionID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDivisionID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDivisionID.EmptyRows = True
        Me.tdbcDivisionID.ExtendRightColumn = True
        Me.tdbcDivisionID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDivisionID.Images.Add(CType(resources.GetObject("tdbcDivisionID.Images"), System.Drawing.Image))
        Me.tdbcDivisionID.Location = New System.Drawing.Point(108, 19)
        Me.tdbcDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDivisionID.MaxLength = 32767
        Me.tdbcDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDivisionID.Name = "tdbcDivisionID"
        Me.tdbcDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.Size = New System.Drawing.Size(209, 21)
        Me.tdbcDivisionID.TabIndex = 1
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'grpAnylistCode
        '
        Me.grpAnylistCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAnylistCode.Controls.Add(Me.lblCipNo)
        Me.grpAnylistCode.Controls.Add(Me.lblTypeCodeID)
        Me.grpAnylistCode.Controls.Add(Me.tdbcCodeID)
        Me.grpAnylistCode.Controls.Add(Me.tdbcTypeCodeID)
        Me.grpAnylistCode.Controls.Add(Me.tdbcCipNo)
        Me.grpAnylistCode.Controls.Add(Me.txtCipName)
        Me.grpAnylistCode.Controls.Add(Me.txtCodeName)
        Me.grpAnylistCode.Location = New System.Drawing.Point(334, 3)
        Me.grpAnylistCode.Name = "grpAnylistCode"
        Me.grpAnylistCode.Size = New System.Drawing.Size(681, 80)
        Me.grpAnylistCode.TabIndex = 1
        Me.grpAnylistCode.TabStop = False
        '
        'lblCipNo
        '
        Me.lblCipNo.AutoSize = True
        Me.lblCipNo.Location = New System.Drawing.Point(6, 53)
        Me.lblCipNo.Name = "lblCipNo"
        Me.lblCipNo.Size = New System.Drawing.Size(54, 13)
        Me.lblCipNo.TabIndex = 4
        Me.lblCipNo.Text = "Mã XDCB"
        Me.lblCipNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTypeCodeID
        '
        Me.lblTypeCodeID.AutoSize = True
        Me.lblTypeCodeID.Location = New System.Drawing.Point(6, 23)
        Me.lblTypeCodeID.Name = "lblTypeCodeID"
        Me.lblTypeCodeID.Size = New System.Drawing.Size(103, 13)
        Me.lblTypeCodeID.TabIndex = 0
        Me.lblTypeCodeID.Text = "Mã phân tích XDCB"
        Me.lblTypeCodeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcCodeID
        '
        Me.tdbcCodeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcCodeID.AllowColMove = False
        Me.tdbcCodeID.AllowColSelect = True
        Me.tdbcCodeID.AllowSort = False
        Me.tdbcCodeID.AlternatingRows = True
        Me.tdbcCodeID.AutoCompletion = True
        Me.tdbcCodeID.AutoDropDown = True
        Me.tdbcCodeID.AutoSelect = True
        Me.tdbcCodeID.Caption = ""
        Me.tdbcCodeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcCodeID.ColumnWidth = 100
        Me.tdbcCodeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcCodeID.DisplayMember = "CodeID"
        Me.tdbcCodeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcCodeID.DropDownWidth = 500
        Me.tdbcCodeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcCodeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcCodeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcCodeID.EmptyRows = True
        Me.tdbcCodeID.ExtendRightColumn = True
        Me.tdbcCodeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcCodeID.Images.Add(CType(resources.GetObject("tdbcCodeID.Images"), System.Drawing.Image))
        Me.tdbcCodeID.Location = New System.Drawing.Point(249, 19)
        Me.tdbcCodeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcCodeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcCodeID.MaxLength = 32767
        Me.tdbcCodeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcCodeID.Name = "tdbcCodeID"
        Me.tdbcCodeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcCodeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcCodeID.Size = New System.Drawing.Size(128, 21)
        Me.tdbcCodeID.TabIndex = 2
        Me.tdbcCodeID.ValueMember = "CodeID"
        Me.tdbcCodeID.PropBag = resources.GetString("tdbcCodeID.PropBag")
        '
        'tdbcTypeCodeID
        '
        Me.tdbcTypeCodeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTypeCodeID.AllowColMove = False
        Me.tdbcTypeCodeID.AllowColSelect = True
        Me.tdbcTypeCodeID.AllowSort = False
        Me.tdbcTypeCodeID.AlternatingRows = True
        Me.tdbcTypeCodeID.AutoCompletion = True
        Me.tdbcTypeCodeID.AutoDropDown = True
        Me.tdbcTypeCodeID.AutoSelect = True
        Me.tdbcTypeCodeID.Caption = ""
        Me.tdbcTypeCodeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTypeCodeID.ColumnHeaders = False
        Me.tdbcTypeCodeID.ColumnWidth = 100
        Me.tdbcTypeCodeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTypeCodeID.DisplayMember = "TypeCodeID"
        Me.tdbcTypeCodeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTypeCodeID.DropDownWidth = 500
        Me.tdbcTypeCodeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTypeCodeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTypeCodeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTypeCodeID.EmptyRows = True
        Me.tdbcTypeCodeID.ExtendRightColumn = True
        Me.tdbcTypeCodeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTypeCodeID.Images.Add(CType(resources.GetObject("tdbcTypeCodeID.Images"), System.Drawing.Image))
        Me.tdbcTypeCodeID.Location = New System.Drawing.Point(115, 19)
        Me.tdbcTypeCodeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTypeCodeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTypeCodeID.MaxLength = 32767
        Me.tdbcTypeCodeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTypeCodeID.Name = "tdbcTypeCodeID"
        Me.tdbcTypeCodeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTypeCodeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTypeCodeID.Size = New System.Drawing.Size(128, 21)
        Me.tdbcTypeCodeID.TabIndex = 1
        Me.tdbcTypeCodeID.ValueMember = "TypeCodeID"
        Me.tdbcTypeCodeID.PropBag = resources.GetString("tdbcTypeCodeID.PropBag")
        '
        'tdbcCipNo
        '
        Me.tdbcCipNo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcCipNo.AllowColMove = False
        Me.tdbcCipNo.AllowColSelect = True
        Me.tdbcCipNo.AllowSort = False
        Me.tdbcCipNo.AlternatingRows = True
        Me.tdbcCipNo.AutoCompletion = True
        Me.tdbcCipNo.AutoDropDown = True
        Me.tdbcCipNo.AutoSelect = True
        Me.tdbcCipNo.Caption = ""
        Me.tdbcCipNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcCipNo.ColumnWidth = 100
        Me.tdbcCipNo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcCipNo.DisplayMember = "CipNo"
        Me.tdbcCipNo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcCipNo.DropDownWidth = 500
        Me.tdbcCipNo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcCipNo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcCipNo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcCipNo.EmptyRows = True
        Me.tdbcCipNo.ExtendRightColumn = True
        Me.tdbcCipNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcCipNo.Images.Add(CType(resources.GetObject("tdbcCipNo.Images"), System.Drawing.Image))
        Me.tdbcCipNo.Location = New System.Drawing.Point(115, 47)
        Me.tdbcCipNo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcCipNo.MaxDropDownItems = CType(8, Short)
        Me.tdbcCipNo.MaxLength = 32767
        Me.tdbcCipNo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcCipNo.Name = "tdbcCipNo"
        Me.tdbcCipNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcCipNo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcCipNo.Size = New System.Drawing.Size(128, 21)
        Me.tdbcCipNo.TabIndex = 5
        Me.tdbcCipNo.ValueMember = "CipNo"
        Me.tdbcCipNo.PropBag = resources.GetString("tdbcCipNo.PropBag")
        '
        'txtCipName
        '
        Me.txtCipName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCipName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCipName.Location = New System.Drawing.Point(249, 47)
        Me.txtCipName.Name = "txtCipName"
        Me.txtCipName.ReadOnly = True
        Me.txtCipName.Size = New System.Drawing.Size(425, 20)
        Me.txtCipName.TabIndex = 6
        Me.txtCipName.TabStop = False
        '
        'txtCodeName
        '
        Me.txtCodeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCodeName.Location = New System.Drawing.Point(383, 19)
        Me.txtCodeName.Name = "txtCodeName"
        Me.txtCodeName.ReadOnly = True
        Me.txtCodeName.Size = New System.Drawing.Size(291, 20)
        Me.txtCodeName.TabIndex = 3
        Me.txtCodeName.TabStop = False
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(939, 89)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 2
        Me.btnFilter.Text = "&Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(932, 677)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tdbg.ColumnFooters = True
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(12, 127)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        Me.tdbg.Size = New System.Drawing.Size(996, 544)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 3
        Me.tdbg.Tag = "COL"
        Me.tdbg.UseColumnStyles = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsShowDetail, Me.ToolStripSeparator1, Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator_Export, Me.mnsExportToExcel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(156, 104)
        '
        'mnsShowDetail
        '
        Me.mnsShowDetail.Name = "mnsShowDetail"
        Me.mnsShowDetail.Size = New System.Drawing.Size(155, 22)
        Me.mnsShowDetail.Text = "&Hiển thị chi tiết"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(155, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(155, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator_Export
        '
        Me.ToolStripSeparator_Export.Name = "ToolStripSeparator_Export"
        Me.ToolStripSeparator_Export.Size = New System.Drawing.Size(152, 6)
        '
        'mnsExportToExcel
        '
        Me.mnsExportToExcel.Name = "mnsExportToExcel"
        Me.mnsExportToExcel.Size = New System.Drawing.Size(155, 22)
        Me.mnsExportToExcel.Text = "Xuất &Excel"
        '
        'btnShowOption
        '
        Me.btnShowOption.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnShowOption.Location = New System.Drawing.Point(12, 677)
        Me.btnShowOption.Name = "btnShowOption"
        Me.btnShowOption.Size = New System.Drawing.Size(90, 22)
        Me.btnShowOption.TabIndex = 5
        Me.btnShowOption.Text = "Hiển thị (F12)"
        Me.btnShowOption.UseVisualStyleBackColor = True
        '
        'tdbg1
        '
        Me.tdbg1.AllowColMove = False
        Me.tdbg1.AllowColSelect = False
        Me.tdbg1.AllowFilter = False
        Me.tdbg1.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg1.AllowUpdate = False
        Me.tdbg1.AlternatingRows = True
        Me.tdbg1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tdbg1.ColumnFooters = True
        Me.tdbg1.EmptyRows = True
        Me.tdbg1.ExtendRightColumn = True
        Me.tdbg1.FilterBar = True
        Me.tdbg1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg1.Images.Add(CType(resources.GetObject("tdbg1.Images"), System.Drawing.Image))
        Me.tdbg1.Location = New System.Drawing.Point(4, 19)
        Me.tdbg1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg1.Name = "tdbg1"
        Me.tdbg1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg1.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg1.PrintInfo.PageSettings = CType(resources.GetObject("tdbg1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg1.PropBag = resources.GetString("tdbg1.PropBag")
        Me.tdbg1.RecordSelectors = False
        Me.tdbg1.Size = New System.Drawing.Size(989, 303)
        Me.tdbg1.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg1.TabAcrossSplits = True
        Me.tdbg1.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg1.TabIndex = 6
        Me.tdbg1.Tag = "COLD"
        Me.tdbg1.UseColumnStyles = False
        '
        'grpDetail
        '
        Me.grpDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetail.Controls.Add(Me.tdbg1)
        Me.grpDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpDetail.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.grpDetail.Location = New System.Drawing.Point(12, 343)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(998, 328)
        Me.grpDetail.TabIndex = 7
        Me.grpDetail.TabStop = False
        Me.grpDetail.Text = "Thông tin chi tiết"
        Me.grpDetail.Visible = False
        '
        'D02F3100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 704)
        Me.Controls.Add(Me.btnShowOption)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpDetail)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.grpAnylistCode)
        Me.Controls.Add(Me.grpDivision)
        Me.Controls.Add(Me.tdbg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F3100"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Truy vÊn tång híp XDCB - D02F3100"
        Me.grpDivision.ResumeLayout(False)
        Me.grpDivision.PerformLayout()
        CType(Me.tdbcPeriodTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPeriodFr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAnylistCode.ResumeLayout(False)
        Me.grpAnylistCode.PerformLayout()
        CType(Me.tdbcCodeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcTypeCodeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcCipNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents grpDivision As System.Windows.Forms.GroupBox
    Private WithEvents grpAnylistCode As System.Windows.Forms.GroupBox
    Private WithEvents tdbcCodeID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcTypeCodeID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcCipNo As C1.Win.C1List.C1Combo
    Private WithEvents txtCipName As System.Windows.Forms.TextBox
    Private WithEvents txtCodeName As System.Windows.Forms.TextBox
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents lblDivisionID As System.Windows.Forms.Label
    Private WithEvents tdbcPeriodTo As C1.Win.C1List.C1Combo
    Private WithEvents tdbcPeriodFr As C1.Win.C1List.C1Combo
    Private WithEvents lblPeriodFr As System.Windows.Forms.Label
    Private WithEvents tdbcDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents lblCipNo As System.Windows.Forms.Label
    Private WithEvents lblTypeCodeID As System.Windows.Forms.Label
    Private WithEvents btnShowOption As System.Windows.Forms.Button
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Export As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tdbg1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents grpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents mnsShowDetail As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class