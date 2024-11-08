<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcreateuser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcreateuser))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsref = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.tsfileloc = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpg1 = New System.Windows.Forms.TabPage()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.cboutyp = New System.Windows.Forms.ComboBox()
        Me.tbuinitial = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbcp_unem = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbpasswd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbusernm = New System.Windows.Forms.TextBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.lbluserid = New System.Windows.Forms.Label()
        Me.rid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usrnem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.upwd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.utyp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cuser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dcreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uedit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbpg1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(865, 555)
        Me.Panel1.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator2, Me.tsref, Me.ToolStripSeparator5, Me.btnClose, Me.tsfileloc})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(9, 498)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(847, 39)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me.btnAdd.Text = "Save User Information"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.BackColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(5, 36)
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpg1)
        Me.TabControl1.Location = New System.Drawing.Point(8, 49)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(852, 440)
        Me.TabControl1.TabIndex = 5
        '
        'tbpg1
        '
        Me.tbpg1.Controls.Add(Me.dg1)
        Me.tbpg1.Controls.Add(Me.cboutyp)
        Me.tbpg1.Controls.Add(Me.tbuinitial)
        Me.tbpg1.Controls.Add(Me.Label4)
        Me.tbpg1.Controls.Add(Me.Label3)
        Me.tbpg1.Controls.Add(Me.tbcp_unem)
        Me.tbpg1.Controls.Add(Me.Label2)
        Me.tbpg1.Controls.Add(Me.tbpasswd)
        Me.tbpg1.Controls.Add(Me.Label1)
        Me.tbpg1.Controls.Add(Me.tbusernm)
        Me.tbpg1.Controls.Add(Me.UsernameLabel)
        Me.tbpg1.Location = New System.Drawing.Point(4, 22)
        Me.tbpg1.Margin = New System.Windows.Forms.Padding(2)
        Me.tbpg1.Name = "tbpg1"
        Me.tbpg1.Padding = New System.Windows.Forms.Padding(2)
        Me.tbpg1.Size = New System.Drawing.Size(844, 414)
        Me.tbpg1.TabIndex = 0
        Me.tbpg1.Text = "User Information"
        Me.tbpg1.UseVisualStyleBackColor = True
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeColumns = False
        Me.dg1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dg1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rid, Me.usrnem, Me.upwd, Me.cname, Me.utyp, Me.uini, Me.cuser, Me.dcreated, Me.uedit})
        Me.dg1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dg1.Location = New System.Drawing.Point(5, 168)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(835, 244)
        Me.dg1.TabIndex = 34
        '
        'cboutyp
        '
        Me.cboutyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboutyp.FormattingEnabled = True
        Me.cboutyp.Items.AddRange(New Object() {"Admin", "User"})
        Me.cboutyp.Location = New System.Drawing.Point(272, 37)
        Me.cboutyp.Margin = New System.Windows.Forms.Padding(2)
        Me.cboutyp.Name = "cboutyp"
        Me.cboutyp.Size = New System.Drawing.Size(120, 21)
        Me.cboutyp.TabIndex = 21
        '
        'tbuinitial
        '
        Me.tbuinitial.Location = New System.Drawing.Point(272, 86)
        Me.tbuinitial.Margin = New System.Windows.Forms.Padding(2)
        Me.tbuinitial.Name = "tbuinitial"
        Me.tbuinitial.Size = New System.Drawing.Size(120, 20)
        Me.tbuinitial.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(270, 65)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 19)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "User Initial :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(270, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 19)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "User Type :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbcp_unem
        '
        Me.tbcp_unem.Location = New System.Drawing.Point(18, 138)
        Me.tbcp_unem.Margin = New System.Windows.Forms.Padding(2)
        Me.tbcp_unem.Name = "tbcp_unem"
        Me.tbcp_unem.Size = New System.Drawing.Size(374, 20)
        Me.tbcp_unem.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 117)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 19)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Complete Name of User"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbpasswd
        '
        Me.tbpasswd.Location = New System.Drawing.Point(20, 81)
        Me.tbpasswd.Margin = New System.Windows.Forms.Padding(2)
        Me.tbpasswd.Name = "tbpasswd"
        Me.tbpasswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbpasswd.Size = New System.Drawing.Size(190, 20)
        Me.tbpasswd.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 65)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbusernm
        '
        Me.tbusernm.Location = New System.Drawing.Point(18, 37)
        Me.tbusernm.Margin = New System.Windows.Forms.Padding(2)
        Me.tbusernm.Name = "tbusernm"
        Me.tbusernm.Size = New System.Drawing.Size(192, 20)
        Me.tbusernm.TabIndex = 13
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(16, 16)
        Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(165, 19)
        Me.UsernameLabel.TabIndex = 12
        Me.UsernameLabel.Text = "&User name"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.btncancel)
        Me.Panel6.Controls.Add(Me.lbluserid)
        Me.Panel6.Location = New System.Drawing.Point(1, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(864, 30)
        Me.Panel6.TabIndex = 118
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(7, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 21)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "ADD USER"
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
        Me.btncancel.Location = New System.Drawing.Point(791, 0)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(72, 30)
        Me.btncancel.TabIndex = 19
        Me.btncancel.Text = "Close (x)"
        Me.btncancel.UseVisualStyleBackColor = False
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
        'rid
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray
        Me.rid.DefaultCellStyle = DataGridViewCellStyle3
        Me.rid.HeaderText = "recid"
        Me.rid.Name = "rid"
        Me.rid.ReadOnly = True
        Me.rid.Visible = False
        Me.rid.Width = 10
        '
        'usrnem
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray
        Me.usrnem.DefaultCellStyle = DataGridViewCellStyle4
        Me.usrnem.HeaderText = "Username"
        Me.usrnem.Name = "usrnem"
        Me.usrnem.ReadOnly = True
        Me.usrnem.Width = 80
        '
        'upwd
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gray
        Me.upwd.DefaultCellStyle = DataGridViewCellStyle5
        Me.upwd.HeaderText = "Password"
        Me.upwd.Name = "upwd"
        Me.upwd.ReadOnly = True
        Me.upwd.Width = 120
        '
        'cname
        '
        Me.cname.HeaderText = "User Complete Name"
        Me.cname.Name = "cname"
        Me.cname.ReadOnly = True
        Me.cname.Width = 180
        '
        'utyp
        '
        Me.utyp.HeaderText = "User Type"
        Me.utyp.Name = "utyp"
        Me.utyp.ReadOnly = True
        Me.utyp.Width = 80
        '
        'uini
        '
        Me.uini.HeaderText = "User Initial"
        Me.uini.Name = "uini"
        Me.uini.ReadOnly = True
        Me.uini.Width = 80
        '
        'cuser
        '
        Me.cuser.HeaderText = "Created User"
        Me.cuser.Name = "cuser"
        Me.cuser.ReadOnly = True
        Me.cuser.Width = 80
        '
        'dcreated
        '
        Me.dcreated.HeaderText = "Date Created"
        Me.dcreated.Name = "dcreated"
        Me.dcreated.ReadOnly = True
        '
        'uedit
        '
        Me.uedit.HeaderText = "Action"
        Me.uedit.Name = "uedit"
        Me.uedit.ReadOnly = True
        Me.uedit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.uedit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.uedit.Width = 60
        '
        'frmcreateuser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 555)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmcreateuser"
        Me.Text = "frmcreateuser"
        Me.Panel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpg1.ResumeLayout(False)
        Me.tbpg1.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbpg1 As System.Windows.Forms.TabPage
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents cboutyp As System.Windows.Forms.ComboBox
    Friend WithEvents tbuinitial As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbcp_unem As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbpasswd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbusernm As System.Windows.Forms.TextBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsref As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsfileloc As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents lbluserid As System.Windows.Forms.Label
    Friend WithEvents rid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usrnem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents upwd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents utyp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cuser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dcreated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uedit As System.Windows.Forms.DataGridViewButtonColumn
End Class
