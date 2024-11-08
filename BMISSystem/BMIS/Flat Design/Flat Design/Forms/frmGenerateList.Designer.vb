<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerateList))
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cbosems = New System.Windows.Forms.ComboBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbluserid = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.checkall = New System.Windows.Forms.CheckBox()
        Me.tsproll = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslblprogress = New System.Windows.Forms.ToolStripLabel()
        Me.btnexportdata = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ForSubmissionListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubmittedListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvlist1 = New System.Windows.Forms.DataGridView()
        Me.dgvlist2 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbsearch = New System.Windows.Forms.TextBox()
        Me.chksub = New System.Windows.Forms.CheckBox()
        Me.ctxmenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteSelectedRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tsproll.SuspendLayout()
        CType(Me.dgvlist1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvlist2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmenu1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbosems
        '
        Me.cbosems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbosems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbosems.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbosems.FormattingEnabled = True
        Me.cbosems.Location = New System.Drawing.Point(144, 8)
        Me.cbosems.Margin = New System.Windows.Forms.Padding(2)
        Me.cbosems.Name = "cbosems"
        Me.cbosems.Size = New System.Drawing.Size(326, 27)
        Me.cbosems.TabIndex = 112
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(15, 11)
        Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(169, 19)
        Me.UsernameLabel.TabIndex = 113
        Me.UsernameLabel.Text = "Select Semester : "
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Controls.Add(Me.btncancel)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lbluserid)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1077, 30)
        Me.Panel1.TabIndex = 115
        '
        'btncancel
        '
        Me.btncancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncancel.BackColor = System.Drawing.Color.Red
        Me.btncancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncancel.FlatAppearance.BorderSize = 0
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.ForeColor = System.Drawing.Color.White
        Me.btncancel.Location = New System.Drawing.Point(1005, 0)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(72, 30)
        Me.btncancel.TabIndex = 24
        Me.btncancel.Text = "Close (x)"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(7, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(166, 21)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "INSURANCE LISTING"
        '
        'lbluserid
        '
        Me.lbluserid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluserid.ForeColor = System.Drawing.Color.White
        Me.lbluserid.Location = New System.Drawing.Point(248, 7)
        Me.lbluserid.Name = "lbluserid"
        Me.lbluserid.Size = New System.Drawing.Size(110, 20)
        Me.lbluserid.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.OldLace
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(11, 107)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1059, 24)
        Me.Panel2.TabIndex = 117
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(1, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "For Submission"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.Gold
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.checkall)
        Me.Panel3.Location = New System.Drawing.Point(11, 446)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1059, 50)
        Me.Panel3.TabIndex = 118
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 19)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Submitted List"
        '
        'checkall
        '
        Me.checkall.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkall.AutoSize = True
        Me.checkall.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkall.ForeColor = System.Drawing.Color.Blue
        Me.checkall.Location = New System.Drawing.Point(21, 25)
        Me.checkall.Name = "checkall"
        Me.checkall.Size = New System.Drawing.Size(87, 23)
        Me.checkall.TabIndex = 152
        Me.checkall.Text = "Check all"
        Me.checkall.UseVisualStyleBackColor = True
        '
        'tsproll
        '
        Me.tsproll.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsproll.AutoSize = False
        Me.tsproll.BackColor = System.Drawing.Color.Transparent
        Me.tsproll.Dock = System.Windows.Forms.DockStyle.None
        Me.tsproll.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.tslblprogress, Me.btnexportdata, Me.ToolStripSeparator2})
        Me.tsproll.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsproll.Location = New System.Drawing.Point(11, 70)
        Me.tsproll.Name = "tsproll"
        Me.tsproll.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsproll.Size = New System.Drawing.Size(1057, 33)
        Me.tsproll.TabIndex = 146
        Me.tsproll.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.BackColor = System.Drawing.Color.White
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(5, 36)
        Me.ToolStripSeparator1.Visible = False
        '
        'tslblprogress
        '
        Me.tslblprogress.Font = New System.Drawing.Font("Segoe UI", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblprogress.Name = "tslblprogress"
        Me.tslblprogress.Size = New System.Drawing.Size(0, 0)
        Me.tslblprogress.Visible = False
        '
        'btnexportdata
        '
        Me.btnexportdata.AutoSize = False
        Me.btnexportdata.BackColor = System.Drawing.Color.AliceBlue
        Me.btnexportdata.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ForSubmissionListToolStripMenuItem, Me.SubmittedListToolStripMenuItem})
        Me.btnexportdata.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportdata.ForeColor = System.Drawing.Color.Black
        Me.btnexportdata.Image = CType(resources.GetObject("btnexportdata.Image"), System.Drawing.Image)
        Me.btnexportdata.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexportdata.Name = "btnexportdata"
        Me.btnexportdata.Size = New System.Drawing.Size(180, 32)
        Me.btnexportdata.Text = "Export"
        '
        'ForSubmissionListToolStripMenuItem
        '
        Me.ForSubmissionListToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ForSubmissionListToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForSubmissionListToolStripMenuItem.Name = "ForSubmissionListToolStripMenuItem"
        Me.ForSubmissionListToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ForSubmissionListToolStripMenuItem.Text = "For Submission List"
        '
        'SubmittedListToolStripMenuItem
        '
        Me.SubmittedListToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SubmittedListToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubmittedListToolStripMenuItem.Name = "SubmittedListToolStripMenuItem"
        Me.SubmittedListToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SubmittedListToolStripMenuItem.Text = "Submitted List"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.BackColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(5, 36)
        Me.ToolStripSeparator2.Visible = False
        '
        'dgvlist1
        '
        Me.dgvlist1.AllowUserToAddRows = False
        Me.dgvlist1.AllowUserToDeleteRows = False
        Me.dgvlist1.AllowUserToResizeColumns = False
        Me.dgvlist1.AllowUserToResizeRows = False
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.MintCream
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvlist1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvlist1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvlist1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvlist1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlist1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist1.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvlist1.Location = New System.Drawing.Point(11, 132)
        Me.dgvlist1.Name = "dgvlist1"
        Me.dgvlist1.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist1.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvlist1.RowHeadersVisible = False
        Me.dgvlist1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvlist1.RowsDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvlist1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvlist1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvlist1.Size = New System.Drawing.Size(1059, 289)
        Me.dgvlist1.TabIndex = 147
        '
        'dgvlist2
        '
        Me.dgvlist2.AllowUserToAddRows = False
        Me.dgvlist2.AllowUserToDeleteRows = False
        Me.dgvlist2.AllowUserToResizeColumns = False
        Me.dgvlist2.AllowUserToResizeRows = False
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvlist2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvlist2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvlist2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvlist2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlist2.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist2.DefaultCellStyle = DataGridViewCellStyle28
        Me.dgvlist2.Location = New System.Drawing.Point(11, 500)
        Me.dgvlist2.Name = "dgvlist2"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist2.RowHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgvlist2.RowHeadersVisible = False
        Me.dgvlist2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvlist2.RowsDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvlist2.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvlist2.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvlist2.Size = New System.Drawing.Size(1059, 222)
        Me.dgvlist2.TabIndex = 148
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(465, 76)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 19)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "Search :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbsearch
        '
        Me.tbsearch.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbsearch.Location = New System.Drawing.Point(532, 73)
        Me.tbsearch.Name = "tbsearch"
        Me.tbsearch.Size = New System.Drawing.Size(281, 27)
        Me.tbsearch.TabIndex = 150
        '
        'chksub
        '
        Me.chksub.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chksub.AutoSize = True
        Me.chksub.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chksub.ForeColor = System.Drawing.Color.Blue
        Me.chksub.Location = New System.Drawing.Point(823, 75)
        Me.chksub.Name = "chksub"
        Me.chksub.Size = New System.Drawing.Size(186, 23)
        Me.chksub.TabIndex = 151
        Me.chksub.Text = "Search in Submitted List"
        Me.chksub.UseVisualStyleBackColor = True
        '
        'ctxmenu1
        '
        Me.ctxmenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteSelectedRowToolStripMenuItem})
        Me.ctxmenu1.Name = "xtmenu1"
        Me.ctxmenu1.Size = New System.Drawing.Size(210, 26)
        '
        'DeleteSelectedRowToolStripMenuItem
        '
        Me.DeleteSelectedRowToolStripMenuItem.Image = CType(resources.GetObject("DeleteSelectedRowToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteSelectedRowToolStripMenuItem.Name = "DeleteSelectedRowToolStripMenuItem"
        Me.DeleteSelectedRowToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.DeleteSelectedRowToolStripMenuItem.Text = "&Delete Selected Row ( F2 )"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.AutoScroll = True
        Me.Panel4.AutoScrollMargin = New System.Drawing.Size(100, 0)
        Me.Panel4.AutoScrollMinSize = New System.Drawing.Size(1, 0)
        Me.Panel4.Controls.Add(Me.chksub)
        Me.Panel4.Controls.Add(Me.tbsearch)
        Me.Panel4.Controls.Add(Me.dgvlist2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.dgvlist1)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.tsproll)
        Me.Panel4.Controls.Add(Me.cbosems)
        Me.Panel4.Controls.Add(Me.UsernameLabel)
        Me.Panel4.Location = New System.Drawing.Point(0, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1077, 731)
        Me.Panel4.TabIndex = 152
        '
        'frmGenerateList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 776)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGenerateList"
        Me.Text = "Generate List for Insurance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tsproll.ResumeLayout(False)
        Me.tsproll.PerformLayout()
        CType(Me.dgvlist1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvlist2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmenu1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbosems As System.Windows.Forms.ComboBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbluserid As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tsproll As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslblprogress As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnexportdata As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ForSubmissionListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubmittedListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvlist1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvlist2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbsearch As System.Windows.Forms.TextBox
    Friend WithEvents chksub As System.Windows.Forms.CheckBox
    Friend WithEvents ctxmenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteSelectedRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents checkall As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btncancel As System.Windows.Forms.Button
End Class
