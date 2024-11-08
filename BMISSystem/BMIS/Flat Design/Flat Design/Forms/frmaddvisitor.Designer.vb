<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmaddvisitor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmaddvisitor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbar1 = New System.Windows.Forms.ProgressBar()
        Me.tsproll = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsprint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsssadd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsref = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.tsfileloc = New System.Windows.Forms.ToolStripButton()
        Me.tb4 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tb3 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.gname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nationalt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tb2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.tsproll.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pbar1)
        Me.Panel1.Controls.Add(Me.tsproll)
        Me.Panel1.Controls.Add(Me.tb4)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.tb3)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.dtp2)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.dtp1)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.dgv1)
        Me.Panel1.Controls.Add(Me.tb2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.tb1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(972, 616)
        Me.Panel1.TabIndex = 0
        '
        'pbar1
        '
        Me.pbar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbar1.Location = New System.Drawing.Point(16, 548)
        Me.pbar1.Name = "pbar1"
        Me.pbar1.Size = New System.Drawing.Size(943, 10)
        Me.pbar1.TabIndex = 29
        Me.pbar1.Visible = False
        '
        'tsproll
        '
        Me.tsproll.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsproll.AutoSize = False
        Me.tsproll.BackColor = System.Drawing.Color.Transparent
        Me.tsproll.Dock = System.Windows.Forms.DockStyle.None
        Me.tsproll.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator2, Me.tsprint, Me.ToolStripSeparator3, Me.tsssadd, Me.ToolStripSeparator4, Me.tsref, Me.ToolStripSeparator5, Me.btnClose, Me.tsfileloc})
        Me.tsproll.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsproll.Location = New System.Drawing.Point(16, 568)
        Me.tsproll.Name = "tsproll"
        Me.tsproll.Size = New System.Drawing.Size(933, 39)
        Me.tsproll.TabIndex = 7
        Me.tsproll.Text = "ToolStrip1"
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = False
        Me.btnAdd.BackColor = System.Drawing.Color.DarkMagenta
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(200, 36)
        Me.btnAdd.Text = "Save and &Generate Pass"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.BackColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(5, 36)
        '
        'tsprint
        '
        Me.tsprint.AutoSize = False
        Me.tsprint.BackColor = System.Drawing.Color.DarkMagenta
        Me.tsprint.Enabled = False
        Me.tsprint.ForeColor = System.Drawing.Color.White
        Me.tsprint.Image = CType(resources.GetObject("tsprint.Image"), System.Drawing.Image)
        Me.tsprint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsprint.Name = "tsprint"
        Me.tsprint.Size = New System.Drawing.Size(100, 36)
        Me.tsprint.Text = "Reprint Pass"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.BackColor = System.Drawing.Color.White
        Me.ToolStripSeparator3.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(5, 36)
        '
        'tsssadd
        '
        Me.tsssadd.AutoSize = False
        Me.tsssadd.BackColor = System.Drawing.Color.DarkMagenta
        Me.tsssadd.ForeColor = System.Drawing.Color.White
        Me.tsssadd.Image = CType(resources.GetObject("tsssadd.Image"), System.Drawing.Image)
        Me.tsssadd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsssadd.Name = "tsssadd"
        Me.tsssadd.Size = New System.Drawing.Size(100, 36)
        Me.tsssadd.Text = "New"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.BackColor = System.Drawing.Color.White
        Me.ToolStripSeparator4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(5, 36)
        '
        'tsref
        '
        Me.tsref.AutoSize = False
        Me.tsref.BackColor = System.Drawing.Color.DarkMagenta
        Me.tsref.ForeColor = System.Drawing.Color.White
        Me.tsref.Image = CType(resources.GetObject("tsref.Image"), System.Drawing.Image)
        Me.tsref.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsref.Name = "tsref"
        Me.tsref.Size = New System.Drawing.Size(100, 36)
        Me.tsref.Text = "Refresh"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.AutoSize = False
        Me.ToolStripSeparator5.BackColor = System.Drawing.Color.White
        Me.ToolStripSeparator5.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(5, 36)
        '
        'btnClose
        '
        Me.btnClose.AutoSize = False
        Me.btnClose.BackColor = System.Drawing.Color.DarkMagenta
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 36)
        Me.btnClose.Text = "Close"
        '
        'tsfileloc
        '
        Me.tsfileloc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsfileloc.Image = CType(resources.GetObject("tsfileloc.Image"), System.Drawing.Image)
        Me.tsfileloc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsfileloc.Name = "tsfileloc"
        Me.tsfileloc.Size = New System.Drawing.Size(23, 4)
        '
        'tb4
        '
        Me.tb4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb4.Location = New System.Drawing.Point(522, 77)
        Me.tb4.Name = "tb4"
        Me.tb4.Size = New System.Drawing.Size(319, 24)
        Me.tb4.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(439, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 16)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "INCLUSIONS:"
        '
        'tb3
        '
        Me.tb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb3.Location = New System.Drawing.Point(138, 78)
        Me.tb3.Name = "tb3"
        Me.tb3.Size = New System.Drawing.Size(279, 24)
        Me.tb3.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(31, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 16)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Apartment Type :"
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Location = New System.Drawing.Point(523, 130)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(273, 20)
        Me.dtp2.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(443, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 16)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Check OUT:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Location = New System.Drawing.Point(138, 131)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(273, 20)
        Me.dtp1.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(72, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 16)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Check IN:"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToResizeColumns = False
        Me.dgv1.AllowUserToResizeRows = False
        Me.dgv1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gname, Me.cno, Me.nationalt})
        Me.dgv1.Location = New System.Drawing.Point(16, 164)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(944, 382)
        Me.dgv1.TabIndex = 6
        '
        'gname
        '
        Me.gname.HeaderText = "Guest Name"
        Me.gname.Name = "gname"
        Me.gname.Width = 280
        '
        'cno
        '
        Me.cno.HeaderText = "Contact No/s"
        Me.cno.Name = "cno"
        Me.cno.Width = 160
        '
        'nationalt
        '
        Me.nationalt.HeaderText = "Nationality"
        Me.nationalt.Name = "nationalt"
        Me.nationalt.Width = 180
        '
        'tb2
        '
        Me.tb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb2.Location = New System.Drawing.Point(138, 47)
        Me.tb2.Name = "tb2"
        Me.tb2.Size = New System.Drawing.Size(61, 26)
        Me.tb2.TabIndex = 1
        Me.tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(41, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "No. Of Persons :"
        '
        'tb1
        '
        Me.tb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb1.Location = New System.Drawing.Point(138, 18)
        Me.tb1.Name = "tb1"
        Me.tb1.Size = New System.Drawing.Size(382, 24)
        Me.tb1.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(38, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Travel Agency :"
        '
        'frmaddvisitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(972, 616)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmaddvisitor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.tsproll.ResumeLayout(false)
        Me.tsproll.PerformLayout
        CType(Me.dgv1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents tsproll As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsssadd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsref As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsfileloc As System.Windows.Forms.ToolStripButton
    Friend WithEvents tb4 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tb3 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents tb2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nationalt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents tsprint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
End Class
