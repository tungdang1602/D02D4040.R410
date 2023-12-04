<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D02F3060
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D02F3060))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDivisionID = New System.Windows.Forms.Label()
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo()
        Me.tdbcAssetAccountIDTo = New C1.Win.C1List.C1Combo()
        Me.tdbcAssetAccountIDFrom = New C1.Win.C1List.C1Combo()
        Me.tdbcObjectID = New C1.Win.C1List.C1Combo()
        Me.chkISDisposed = New System.Windows.Forms.CheckBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.tdbcAssetIDTo = New C1.Win.C1List.C1Combo()
        Me.tdbcAssetIDFrom = New C1.Win.C1List.C1Combo()
        Me.tdbcToCCodeID = New C1.Win.C1List.C1Combo()
        Me.tdbcFromCCodeID = New C1.Win.C1List.C1Combo()
        Me.tdbcTypeCodeID = New C1.Win.C1List.C1Combo()
        Me.lblTypeCodeID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblToCCodeID = New System.Windows.Forms.Label()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.tdbcToPeriod = New C1.Win.C1List.C1Combo()
        Me.tdbcFromPeriod = New C1.Win.C1List.C1Combo()
        Me.lblAssetIDFrom = New System.Windows.Forms.Label()
        Me.lblAssetIDTo = New System.Windows.Forms.Label()
        Me.lblObjectID = New System.Windows.Forms.Label()
        Me.lblAssetAccountIDFrom = New System.Windows.Forms.Label()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_Export = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbFind = New System.Windows.Forms.ToolStripButton()
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsdActive = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_DExport = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcAssetAccountIDTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcAssetAccountIDFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcObjectID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcAssetIDTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcAssetIDFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcToCCodeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcFromCCodeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcTypeCodeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcToPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcFromPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDivisionID)
        Me.GroupBox1.Controls.Add(Me.tdbcDivisionID)
        Me.GroupBox1.Controls.Add(Me.tdbcAssetAccountIDTo)
        Me.GroupBox1.Controls.Add(Me.tdbcAssetAccountIDFrom)
        Me.GroupBox1.Controls.Add(Me.tdbcObjectID)
        Me.GroupBox1.Controls.Add(Me.chkISDisposed)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.tdbcAssetIDTo)
        Me.GroupBox1.Controls.Add(Me.tdbcAssetIDFrom)
        Me.GroupBox1.Controls.Add(Me.tdbcToCCodeID)
        Me.GroupBox1.Controls.Add(Me.tdbcFromCCodeID)
        Me.GroupBox1.Controls.Add(Me.tdbcTypeCodeID)
        Me.GroupBox1.Controls.Add(Me.lblTypeCodeID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblToCCodeID)
        Me.GroupBox1.Controls.Add(Me.lblPeriod)
        Me.GroupBox1.Controls.Add(Me.tdbcToPeriod)
        Me.GroupBox1.Controls.Add(Me.tdbcFromPeriod)
        Me.GroupBox1.Controls.Add(Me.lblAssetIDFrom)
        Me.GroupBox1.Controls.Add(Me.lblAssetIDTo)
        Me.GroupBox1.Controls.Add(Me.lblObjectID)
        Me.GroupBox1.Controls.Add(Me.lblAssetAccountIDFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1012, 107)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblDivisionID
        '
        Me.lblDivisionID.AutoSize = True
        Me.lblDivisionID.Location = New System.Drawing.Point(17, 20)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(38, 13)
        Me.lblDivisionID.TabIndex = 22
        Me.lblDivisionID.Text = "Đơn vị"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcDivisionID
        '
        Me.tdbcDivisionID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDivisionID.AllowColMove = False
        Me.tdbcDivisionID.AllowSort = False
        Me.tdbcDivisionID.AlternatingRows = True
        Me.tdbcDivisionID.AutoCompletion = True
        Me.tdbcDivisionID.AutoDropDown = True
        Me.tdbcDivisionID.Caption = ""
        Me.tdbcDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
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
        Me.tdbcDivisionID.Location = New System.Drawing.Point(95, 17)
        Me.tdbcDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDivisionID.MaxLength = 32767
        Me.tdbcDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDivisionID.Name = "tdbcDivisionID"
        Me.tdbcDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.Size = New System.Drawing.Size(285, 21)
        Me.tdbcDivisionID.TabIndex = 1
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'tdbcAssetAccountIDTo
        '
        Me.tdbcAssetAccountIDTo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcAssetAccountIDTo.AllowColMove = False
        Me.tdbcAssetAccountIDTo.AllowSort = False
        Me.tdbcAssetAccountIDTo.AlternatingRows = True
        Me.tdbcAssetAccountIDTo.AutoCompletion = True
        Me.tdbcAssetAccountIDTo.AutoDropDown = True
        Me.tdbcAssetAccountIDTo.Caption = ""
        Me.tdbcAssetAccountIDTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcAssetAccountIDTo.ColumnWidth = 100
        Me.tdbcAssetAccountIDTo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcAssetAccountIDTo.DisplayMember = "AccountID"
        Me.tdbcAssetAccountIDTo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcAssetAccountIDTo.DropDownWidth = 500
        Me.tdbcAssetAccountIDTo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcAssetAccountIDTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetAccountIDTo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcAssetAccountIDTo.EmptyRows = True
        Me.tdbcAssetAccountIDTo.ExtendRightColumn = True
        Me.tdbcAssetAccountIDTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetAccountIDTo.Images.Add(CType(resources.GetObject("tdbcAssetAccountIDTo.Images"), System.Drawing.Image))
        Me.tdbcAssetAccountIDTo.Location = New System.Drawing.Point(676, 44)
        Me.tdbcAssetAccountIDTo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcAssetAccountIDTo.MaxDropDownItems = CType(8, Short)
        Me.tdbcAssetAccountIDTo.MaxLength = 32767
        Me.tdbcAssetAccountIDTo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcAssetAccountIDTo.Name = "tdbcAssetAccountIDTo"
        Me.tdbcAssetAccountIDTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcAssetAccountIDTo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcAssetAccountIDTo.Size = New System.Drawing.Size(150, 21)
        Me.tdbcAssetAccountIDTo.TabIndex = 17
        Me.tdbcAssetAccountIDTo.ValueMember = "AccountID"
        Me.tdbcAssetAccountIDTo.PropBag = resources.GetString("tdbcAssetAccountIDTo.PropBag")
        '
        'tdbcAssetAccountIDFrom
        '
        Me.tdbcAssetAccountIDFrom.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcAssetAccountIDFrom.AllowColMove = False
        Me.tdbcAssetAccountIDFrom.AllowSort = False
        Me.tdbcAssetAccountIDFrom.AlternatingRows = True
        Me.tdbcAssetAccountIDFrom.AutoCompletion = True
        Me.tdbcAssetAccountIDFrom.AutoDropDown = True
        Me.tdbcAssetAccountIDFrom.Caption = ""
        Me.tdbcAssetAccountIDFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcAssetAccountIDFrom.ColumnWidth = 100
        Me.tdbcAssetAccountIDFrom.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcAssetAccountIDFrom.DisplayMember = "AccountID"
        Me.tdbcAssetAccountIDFrom.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcAssetAccountIDFrom.DropDownWidth = 500
        Me.tdbcAssetAccountIDFrom.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcAssetAccountIDFrom.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetAccountIDFrom.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcAssetAccountIDFrom.EmptyRows = True
        Me.tdbcAssetAccountIDFrom.ExtendRightColumn = True
        Me.tdbcAssetAccountIDFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetAccountIDFrom.Images.Add(CType(resources.GetObject("tdbcAssetAccountIDFrom.Images"), System.Drawing.Image))
        Me.tdbcAssetAccountIDFrom.Location = New System.Drawing.Point(559, 44)
        Me.tdbcAssetAccountIDFrom.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcAssetAccountIDFrom.MaxDropDownItems = CType(8, Short)
        Me.tdbcAssetAccountIDFrom.MaxLength = 32767
        Me.tdbcAssetAccountIDFrom.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcAssetAccountIDFrom.Name = "tdbcAssetAccountIDFrom"
        Me.tdbcAssetAccountIDFrom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcAssetAccountIDFrom.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcAssetAccountIDFrom.Size = New System.Drawing.Size(107, 21)
        Me.tdbcAssetAccountIDFrom.TabIndex = 16
        Me.tdbcAssetAccountIDFrom.ValueMember = "AccountID"
        Me.tdbcAssetAccountIDFrom.PropBag = resources.GetString("tdbcAssetAccountIDFrom.PropBag")
        '
        'tdbcObjectID
        '
        Me.tdbcObjectID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcObjectID.AllowColMove = False
        Me.tdbcObjectID.AllowSort = False
        Me.tdbcObjectID.AlternatingRows = True
        Me.tdbcObjectID.AutoCompletion = True
        Me.tdbcObjectID.AutoDropDown = True
        Me.tdbcObjectID.Caption = ""
        Me.tdbcObjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcObjectID.ColumnWidth = 100
        Me.tdbcObjectID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcObjectID.DisplayMember = "ObjectID"
        Me.tdbcObjectID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcObjectID.DropDownWidth = 500
        Me.tdbcObjectID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcObjectID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcObjectID.EmptyRows = True
        Me.tdbcObjectID.ExtendRightColumn = True
        Me.tdbcObjectID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectID.Images.Add(CType(resources.GetObject("tdbcObjectID.Images"), System.Drawing.Image))
        Me.tdbcObjectID.Location = New System.Drawing.Point(559, 71)
        Me.tdbcObjectID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcObjectID.MaxDropDownItems = CType(8, Short)
        Me.tdbcObjectID.MaxLength = 32767
        Me.tdbcObjectID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcObjectID.Name = "tdbcObjectID"
        Me.tdbcObjectID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcObjectID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcObjectID.Size = New System.Drawing.Size(107, 21)
        Me.tdbcObjectID.TabIndex = 19
        Me.tdbcObjectID.ValueMember = "ObjectID"
        Me.tdbcObjectID.PropBag = resources.GetString("tdbcObjectID.PropBag")
        '
        'chkISDisposed
        '
        Me.chkISDisposed.AutoSize = True
        Me.chkISDisposed.Location = New System.Drawing.Point(676, 75)
        Me.chkISDisposed.Name = "chkISDisposed"
        Me.chkISDisposed.Size = New System.Drawing.Size(152, 17)
        Me.chkISDisposed.TabIndex = 20
        Me.chkISDisposed.Text = "Hiển thị tài sản đã thanh lý"
        Me.chkISDisposed.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(921, 74)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(79, 22)
        Me.btnFilter.TabIndex = 21
        Me.btnFilter.Text = "Lọc (F5)"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'tdbcAssetIDTo
        '
        Me.tdbcAssetIDTo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcAssetIDTo.AllowColMove = False
        Me.tdbcAssetIDTo.AllowSort = False
        Me.tdbcAssetIDTo.AlternatingRows = True
        Me.tdbcAssetIDTo.AutoCompletion = True
        Me.tdbcAssetIDTo.AutoDropDown = True
        Me.tdbcAssetIDTo.Caption = ""
        Me.tdbcAssetIDTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcAssetIDTo.ColumnWidth = 100
        Me.tdbcAssetIDTo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcAssetIDTo.DisplayMember = "AssetID"
        Me.tdbcAssetIDTo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcAssetIDTo.DropDownWidth = 500
        Me.tdbcAssetIDTo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcAssetIDTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetIDTo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcAssetIDTo.EmptyRows = True
        Me.tdbcAssetIDTo.ExtendRightColumn = True
        Me.tdbcAssetIDTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetIDTo.Images.Add(CType(resources.GetObject("tdbcAssetIDTo.Images"), System.Drawing.Image))
        Me.tdbcAssetIDTo.Location = New System.Drawing.Point(252, 73)
        Me.tdbcAssetIDTo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcAssetIDTo.MaxDropDownItems = CType(8, Short)
        Me.tdbcAssetIDTo.MaxLength = 32767
        Me.tdbcAssetIDTo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcAssetIDTo.Name = "tdbcAssetIDTo"
        Me.tdbcAssetIDTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcAssetIDTo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcAssetIDTo.Size = New System.Drawing.Size(128, 21)
        Me.tdbcAssetIDTo.TabIndex = 9
        Me.tdbcAssetIDTo.ValueMember = "AssetID"
        Me.tdbcAssetIDTo.PropBag = resources.GetString("tdbcAssetIDTo.PropBag")
        '
        'tdbcAssetIDFrom
        '
        Me.tdbcAssetIDFrom.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcAssetIDFrom.AllowColMove = False
        Me.tdbcAssetIDFrom.AllowSort = False
        Me.tdbcAssetIDFrom.AlternatingRows = True
        Me.tdbcAssetIDFrom.AutoCompletion = True
        Me.tdbcAssetIDFrom.AutoDropDown = True
        Me.tdbcAssetIDFrom.Caption = ""
        Me.tdbcAssetIDFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcAssetIDFrom.ColumnWidth = 100
        Me.tdbcAssetIDFrom.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcAssetIDFrom.DisplayMember = "AssetID"
        Me.tdbcAssetIDFrom.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcAssetIDFrom.DropDownWidth = 500
        Me.tdbcAssetIDFrom.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcAssetIDFrom.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetIDFrom.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcAssetIDFrom.EmptyRows = True
        Me.tdbcAssetIDFrom.ExtendRightColumn = True
        Me.tdbcAssetIDFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcAssetIDFrom.Images.Add(CType(resources.GetObject("tdbcAssetIDFrom.Images"), System.Drawing.Image))
        Me.tdbcAssetIDFrom.Location = New System.Drawing.Point(95, 73)
        Me.tdbcAssetIDFrom.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcAssetIDFrom.MaxDropDownItems = CType(8, Short)
        Me.tdbcAssetIDFrom.MaxLength = 32767
        Me.tdbcAssetIDFrom.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcAssetIDFrom.Name = "tdbcAssetIDFrom"
        Me.tdbcAssetIDFrom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcAssetIDFrom.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcAssetIDFrom.Size = New System.Drawing.Size(128, 21)
        Me.tdbcAssetIDFrom.TabIndex = 7
        Me.tdbcAssetIDFrom.ValueMember = "AssetID"
        Me.tdbcAssetIDFrom.PropBag = resources.GetString("tdbcAssetIDFrom.PropBag")
        '
        'tdbcToCCodeID
        '
        Me.tdbcToCCodeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcToCCodeID.AllowColMove = False
        Me.tdbcToCCodeID.AllowSort = False
        Me.tdbcToCCodeID.AlternatingRows = True
        Me.tdbcToCCodeID.AutoCompletion = True
        Me.tdbcToCCodeID.AutoDropDown = True
        Me.tdbcToCCodeID.AutoSelect = True
        Me.tdbcToCCodeID.Caption = ""
        Me.tdbcToCCodeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcToCCodeID.ColumnWidth = 100
        Me.tdbcToCCodeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcToCCodeID.DisplayMember = "ACodeID"
        Me.tdbcToCCodeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcToCCodeID.DropDownWidth = 500
        Me.tdbcToCCodeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcToCCodeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcToCCodeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcToCCodeID.EmptyRows = True
        Me.tdbcToCCodeID.ExtendRightColumn = True
        Me.tdbcToCCodeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcToCCodeID.Images.Add(CType(resources.GetObject("tdbcToCCodeID.Images"), System.Drawing.Image))
        Me.tdbcToCCodeID.Location = New System.Drawing.Point(850, 15)
        Me.tdbcToCCodeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcToCCodeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcToCCodeID.MaxLength = 32767
        Me.tdbcToCCodeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcToCCodeID.Name = "tdbcToCCodeID"
        Me.tdbcToCCodeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcToCCodeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcToCCodeID.Size = New System.Drawing.Size(150, 21)
        Me.tdbcToCCodeID.TabIndex = 14
        Me.tdbcToCCodeID.ValueMember = "ACodeID"
        Me.tdbcToCCodeID.PropBag = resources.GetString("tdbcToCCodeID.PropBag")
        '
        'tdbcFromCCodeID
        '
        Me.tdbcFromCCodeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcFromCCodeID.AllowColMove = False
        Me.tdbcFromCCodeID.AllowSort = False
        Me.tdbcFromCCodeID.AlternatingRows = True
        Me.tdbcFromCCodeID.AutoCompletion = True
        Me.tdbcFromCCodeID.AutoDropDown = True
        Me.tdbcFromCCodeID.AutoSelect = True
        Me.tdbcFromCCodeID.Caption = ""
        Me.tdbcFromCCodeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcFromCCodeID.ColumnWidth = 100
        Me.tdbcFromCCodeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcFromCCodeID.DisplayMember = "ACodeID"
        Me.tdbcFromCCodeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcFromCCodeID.DropDownWidth = 500
        Me.tdbcFromCCodeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcFromCCodeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcFromCCodeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcFromCCodeID.EmptyRows = True
        Me.tdbcFromCCodeID.ExtendRightColumn = True
        Me.tdbcFromCCodeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcFromCCodeID.Images.Add(CType(resources.GetObject("tdbcFromCCodeID.Images"), System.Drawing.Image))
        Me.tdbcFromCCodeID.Location = New System.Drawing.Point(676, 15)
        Me.tdbcFromCCodeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcFromCCodeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcFromCCodeID.MaxLength = 32767
        Me.tdbcFromCCodeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcFromCCodeID.Name = "tdbcFromCCodeID"
        Me.tdbcFromCCodeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcFromCCodeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcFromCCodeID.Size = New System.Drawing.Size(150, 21)
        Me.tdbcFromCCodeID.TabIndex = 12
        Me.tdbcFromCCodeID.ValueMember = "ACodeID"
        Me.tdbcFromCCodeID.PropBag = resources.GetString("tdbcFromCCodeID.PropBag")
        '
        'tdbcTypeCodeID
        '
        Me.tdbcTypeCodeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTypeCodeID.AllowColMove = False
        Me.tdbcTypeCodeID.AllowSort = False
        Me.tdbcTypeCodeID.AlternatingRows = True
        Me.tdbcTypeCodeID.AutoCompletion = True
        Me.tdbcTypeCodeID.AutoDropDown = True
        Me.tdbcTypeCodeID.Caption = ""
        Me.tdbcTypeCodeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTypeCodeID.ColumnWidth = 100
        Me.tdbcTypeCodeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTypeCodeID.DisplayMember = "TypeCodeID"
        Me.tdbcTypeCodeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTypeCodeID.DropDownWidth = 450
        Me.tdbcTypeCodeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTypeCodeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTypeCodeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTypeCodeID.EmptyRows = True
        Me.tdbcTypeCodeID.ExtendRightColumn = True
        Me.tdbcTypeCodeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTypeCodeID.Images.Add(CType(resources.GetObject("tdbcTypeCodeID.Images"), System.Drawing.Image))
        Me.tdbcTypeCodeID.Location = New System.Drawing.Point(559, 15)
        Me.tdbcTypeCodeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTypeCodeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTypeCodeID.MaxLength = 32767
        Me.tdbcTypeCodeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTypeCodeID.Name = "tdbcTypeCodeID"
        Me.tdbcTypeCodeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTypeCodeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTypeCodeID.Size = New System.Drawing.Size(107, 21)
        Me.tdbcTypeCodeID.TabIndex = 11
        Me.tdbcTypeCodeID.ValueMember = "TypeCodeID"
        Me.tdbcTypeCodeID.PropBag = resources.GetString("tdbcTypeCodeID.PropBag")
        '
        'lblTypeCodeID
        '
        Me.lblTypeCodeID.AutoSize = True
        Me.lblTypeCodeID.Location = New System.Drawing.Point(415, 20)
        Me.lblTypeCodeID.Name = "lblTypeCodeID"
        Me.lblTypeCodeID.Size = New System.Drawing.Size(71, 13)
        Me.lblTypeCodeID.TabIndex = 10
        Me.lblTypeCodeID.Text = "Mã phân tích"
        Me.lblTypeCodeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(230, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "---"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToCCodeID
        '
        Me.lblToCCodeID.AutoSize = True
        Me.lblToCCodeID.Location = New System.Drawing.Point(829, 20)
        Me.lblToCCodeID.Name = "lblToCCodeID"
        Me.lblToCCodeID.Size = New System.Drawing.Size(16, 13)
        Me.lblToCCodeID.TabIndex = 13
        Me.lblToCCodeID.Text = "---"
        Me.lblToCCodeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(17, 49)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(19, 13)
        Me.lblPeriod.TabIndex = 2
        Me.lblPeriod.Text = "Kỳ"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcToPeriod
        '
        Me.tdbcToPeriod.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcToPeriod.AllowColMove = False
        Me.tdbcToPeriod.AllowSort = False
        Me.tdbcToPeriod.AlternatingRows = True
        Me.tdbcToPeriod.AutoCompletion = True
        Me.tdbcToPeriod.AutoDropDown = True
        Me.tdbcToPeriod.Caption = ""
        Me.tdbcToPeriod.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcToPeriod.ColumnHeaders = False
        Me.tdbcToPeriod.ColumnWidth = 100
        Me.tdbcToPeriod.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcToPeriod.DisplayMember = "Period"
        Me.tdbcToPeriod.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcToPeriod.DropDownWidth = 128
        Me.tdbcToPeriod.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcToPeriod.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcToPeriod.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcToPeriod.EmptyRows = True
        Me.tdbcToPeriod.ExtendRightColumn = True
        Me.tdbcToPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcToPeriod.Images.Add(CType(resources.GetObject("tdbcToPeriod.Images"), System.Drawing.Image))
        Me.tdbcToPeriod.Location = New System.Drawing.Point(252, 44)
        Me.tdbcToPeriod.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcToPeriod.MaxDropDownItems = CType(8, Short)
        Me.tdbcToPeriod.MaxLength = 32767
        Me.tdbcToPeriod.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcToPeriod.Name = "tdbcToPeriod"
        Me.tdbcToPeriod.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcToPeriod.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcToPeriod.Size = New System.Drawing.Size(128, 21)
        Me.tdbcToPeriod.TabIndex = 5
        Me.tdbcToPeriod.ValueMember = "Period"
        Me.tdbcToPeriod.PropBag = resources.GetString("tdbcToPeriod.PropBag")
        '
        'tdbcFromPeriod
        '
        Me.tdbcFromPeriod.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcFromPeriod.AllowColMove = False
        Me.tdbcFromPeriod.AllowSort = False
        Me.tdbcFromPeriod.AlternatingRows = True
        Me.tdbcFromPeriod.AutoCompletion = True
        Me.tdbcFromPeriod.AutoDropDown = True
        Me.tdbcFromPeriod.Caption = ""
        Me.tdbcFromPeriod.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcFromPeriod.ColumnHeaders = False
        Me.tdbcFromPeriod.ColumnWidth = 100
        Me.tdbcFromPeriod.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcFromPeriod.DisplayMember = "Period"
        Me.tdbcFromPeriod.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcFromPeriod.DropDownWidth = 128
        Me.tdbcFromPeriod.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcFromPeriod.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcFromPeriod.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcFromPeriod.EmptyRows = True
        Me.tdbcFromPeriod.ExtendRightColumn = True
        Me.tdbcFromPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcFromPeriod.Images.Add(CType(resources.GetObject("tdbcFromPeriod.Images"), System.Drawing.Image))
        Me.tdbcFromPeriod.Location = New System.Drawing.Point(95, 44)
        Me.tdbcFromPeriod.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcFromPeriod.MaxDropDownItems = CType(8, Short)
        Me.tdbcFromPeriod.MaxLength = 32767
        Me.tdbcFromPeriod.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcFromPeriod.Name = "tdbcFromPeriod"
        Me.tdbcFromPeriod.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcFromPeriod.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcFromPeriod.Size = New System.Drawing.Size(128, 21)
        Me.tdbcFromPeriod.TabIndex = 3
        Me.tdbcFromPeriod.ValueMember = "Period"
        Me.tdbcFromPeriod.PropBag = resources.GetString("tdbcFromPeriod.PropBag")
        '
        'lblAssetIDFrom
        '
        Me.lblAssetIDFrom.AutoSize = True
        Me.lblAssetIDFrom.Location = New System.Drawing.Point(17, 76)
        Me.lblAssetIDFrom.Name = "lblAssetIDFrom"
        Me.lblAssetIDFrom.Size = New System.Drawing.Size(42, 13)
        Me.lblAssetIDFrom.TabIndex = 6
        Me.lblAssetIDFrom.Text = "Tài sản"
        Me.lblAssetIDFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAssetIDTo
        '
        Me.lblAssetIDTo.AutoSize = True
        Me.lblAssetIDTo.Location = New System.Drawing.Point(230, 78)
        Me.lblAssetIDTo.Name = "lblAssetIDTo"
        Me.lblAssetIDTo.Size = New System.Drawing.Size(16, 13)
        Me.lblAssetIDTo.TabIndex = 8
        Me.lblAssetIDTo.Text = "---"
        Me.lblAssetIDTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObjectID
        '
        Me.lblObjectID.AutoSize = True
        Me.lblObjectID.Location = New System.Drawing.Point(415, 76)
        Me.lblObjectID.Name = "lblObjectID"
        Me.lblObjectID.Size = New System.Drawing.Size(118, 13)
        Me.lblObjectID.TabIndex = 18
        Me.lblObjectID.Text = "Bộ phận quản lý tài sản"
        Me.lblObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAssetAccountIDFrom
        '
        Me.lblAssetAccountIDFrom.AutoSize = True
        Me.lblAssetAccountIDFrom.Location = New System.Drawing.Point(415, 49)
        Me.lblAssetAccountIDFrom.Name = "lblAssetAccountIDFrom"
        Me.lblAssetAccountIDFrom.Size = New System.Drawing.Size(72, 13)
        Me.lblAssetAccountIDFrom.TabIndex = 15
        Me.lblAssetAccountIDFrom.Text = "Tài khoản TS"
        Me.lblAssetAccountIDFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.ColumnFooters = True
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 141)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        Me.tdbg.Size = New System.Drawing.Size(1012, 483)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 2
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator_Export, Me.mnsExportToExcel, Me.ToolStripSeparator1, Me.mnsPrint})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(141, 104)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(140, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(140, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator_Export
        '
        Me.ToolStripSeparator_Export.Name = "ToolStripSeparator_Export"
        Me.ToolStripSeparator_Export.Size = New System.Drawing.Size(137, 6)
        '
        'mnsExportToExcel
        '
        Me.mnsExportToExcel.Name = "mnsExportToExcel"
        Me.mnsExportToExcel.Size = New System.Drawing.Size(140, 22)
        Me.mnsExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(137, 6)
        '
        'mnsPrint
        '
        Me.mnsPrint.Name = "mnsPrint"
        Me.mnsPrint.Size = New System.Drawing.Size(140, 22)
        Me.mnsPrint.Text = "&In"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator2, Me.tsbExportToExcel, Me.ToolStripSeparator3, Me.tsbPrint, Me.ToolStripSeparator4, Me.tsbClose, Me.ToolStripSeparator10, Me.tsdActive})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1018, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'tsbFind
        '
        Me.tsbFind.Name = "tsbFind"
        Me.tsbFind.Size = New System.Drawing.Size(60, 22)
        Me.tsbFind.Text = "Tìm &kiếm"
        '
        'tsbListAll
        '
        Me.tsbListAll.Name = "tsbListAll"
        Me.tsbListAll.Size = New System.Drawing.Size(77, 22)
        Me.tsbListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbExportToExcel
        '
        Me.tsbExportToExcel.Name = "tsbExportToExcel"
        Me.tsbExportToExcel.Size = New System.Drawing.Size(65, 22)
        Me.tsbExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPrint
        '
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(23, 22)
        Me.tsbPrint.Text = "&In"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbClose
        '
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(40, 22)
        Me.tsbClose.Text = "Đón&g"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'tsdActive
        '
        Me.tsdActive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFind, Me.tsmListAll, Me.ToolStripSeparator_DExport, Me.tsmExportToExcel, Me.ToolStripSeparator5, Me.tsmPrint})
        Me.tsdActive.Name = "tsdActive"
        Me.tsdActive.Size = New System.Drawing.Size(72, 22)
        Me.tsdActive.Text = "&Thực hiện"
        '
        'tsmFind
        '
        Me.tsmFind.Name = "tsmFind"
        Me.tsmFind.Size = New System.Drawing.Size(140, 22)
        Me.tsmFind.Text = "Tìm &kiếm"
        '
        'tsmListAll
        '
        Me.tsmListAll.Name = "tsmListAll"
        Me.tsmListAll.Size = New System.Drawing.Size(140, 22)
        Me.tsmListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator_DExport
        '
        Me.ToolStripSeparator_DExport.Name = "ToolStripSeparator_DExport"
        Me.ToolStripSeparator_DExport.Size = New System.Drawing.Size(137, 6)
        '
        'tsmExportToExcel
        '
        Me.tsmExportToExcel.Name = "tsmExportToExcel"
        Me.tsmExportToExcel.Size = New System.Drawing.Size(140, 22)
        Me.tsmExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(137, 6)
        '
        'tsmPrint
        '
        Me.tsmPrint.Name = "tsmPrint"
        Me.tsmPrint.Size = New System.Drawing.Size(140, 22)
        Me.tsmPrint.Text = "&In"
        '
        'btnF12
        '
        Me.btnF12.AutoSize = True
        Me.btnF12.BackColor = System.Drawing.SystemColors.Control
        Me.btnF12.FlatAppearance.BorderSize = 0
        Me.btnF12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnF12.ForeColor = System.Drawing.Color.Blue
        Me.btnF12.Location = New System.Drawing.Point(3, 630)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(97, 25)
        Me.btnF12.TabIndex = 3
        Me.btnF12.Text = "F12 (Hiển thị)"
        Me.btnF12.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnF12.UseVisualStyleBackColor = False
        '
        'D02F3060
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D02F3060"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Truy vÊn tång kÕt khÊu hao TSCD - D02F3060"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcAssetAccountIDTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcAssetAccountIDFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcObjectID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcAssetIDTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcAssetIDFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcToCCodeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcFromCCodeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcTypeCodeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcToPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcFromPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcToCCodeID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcFromCCodeID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcTypeCodeID As C1.Win.C1List.C1Combo
    Private WithEvents lblTypeCodeID As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents lblToCCodeID As System.Windows.Forms.Label
    Private WithEvents lblPeriod As System.Windows.Forms.Label
    Private WithEvents tdbcToPeriod As C1.Win.C1List.C1Combo
    Private WithEvents tdbcFromPeriod As C1.Win.C1List.C1Combo
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents tdbcAssetIDTo As C1.Win.C1List.C1Combo
    Private WithEvents tdbcAssetIDFrom As C1.Win.C1List.C1Combo
    Private WithEvents lblAssetIDFrom As System.Windows.Forms.Label
    Private WithEvents lblAssetIDTo As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Export As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbExportToExcel As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsdActive As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsmFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsmListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_DExport As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsmExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnF12 As System.Windows.Forms.Button
    Private WithEvents chkISDisposed As System.Windows.Forms.CheckBox
    Private WithEvents tdbcObjectID As C1.Win.C1List.C1Combo
    Private WithEvents lblObjectID As System.Windows.Forms.Label
    Private WithEvents tdbcAssetAccountIDFrom As C1.Win.C1List.C1Combo
    Private WithEvents lblAssetAccountIDFrom As System.Windows.Forms.Label
    Private WithEvents tdbcAssetAccountIDTo As C1.Win.C1List.C1Combo
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsPrint As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsmPrint As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tdbcDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents lblDivisionID As System.Windows.Forms.Label
End Class