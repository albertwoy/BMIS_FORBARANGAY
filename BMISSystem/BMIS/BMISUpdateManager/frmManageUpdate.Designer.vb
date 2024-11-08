<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageUpdate))
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnInstall = New System.Windows.Forms.Button()
        Me.pbar1 = New System.Windows.Forms.ProgressBar()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.lblsoftwarename = New System.Windows.Forms.Label()
        Me.lblsoftstatus = New System.Windows.Forms.Label()
        Me.lbldevelopername = New System.Windows.Forms.Label()
        Me.lblcompanyname = New System.Windows.Forms.Label()
        Me.appNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslblstatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts_statfilename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnkill = New System.Windows.Forms.Button()
        Me.btndel = New System.Windows.Forms.Button()
        Me.btnstartap = New System.Windows.Forms.Button()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.btnbrwfile = New System.Windows.Forms.Button()
        Me.lblftpstatus = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.groupBox1.SuspendLayout()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.groupBox1.Controls.Add(Me.btnInstall)
        Me.groupBox1.Controls.Add(Me.pbar1)
        Me.groupBox1.Controls.Add(Me.tableLayoutPanel1)
        Me.groupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(15, 97)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox1.Size = New System.Drawing.Size(1107, 412)
        Me.groupBox1.TabIndex = 14
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Installing Info"
        '
        'btnInstall
        '
        Me.btnInstall.Font = New System.Drawing.Font("Calibri", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInstall.Image = Global.BMISUpdateManager.My.Resources.Resources.icons8_installing_updates_36
        Me.btnInstall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInstall.Location = New System.Drawing.Point(208, 316)
        Me.btnInstall.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.Padding = New System.Windows.Forms.Padding(200, 0, 0, 0)
        Me.btnInstall.Size = New System.Drawing.Size(665, 62)
        Me.btnInstall.TabIndex = 2
        Me.btnInstall.Text = "            Install Updates"
        Me.btnInstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'pbar1
        '
        Me.pbar1.Location = New System.Drawing.Point(17, 289)
        Me.pbar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbar1.Name = "pbar1"
        Me.pbar1.Size = New System.Drawing.Size(1073, 16)
        Me.pbar1.TabIndex = 1
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 2
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.71289!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.28711!))
        Me.tableLayoutPanel1.Controls.Add(Me.label7, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.label5, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.label3, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.label2, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.lblsoftwarename, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.lblsoftstatus, 1, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.lbldevelopername, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.lblcompanyname, 1, 2)
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(17, 53)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 4
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(1073, 229)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'label7
        '
        Me.label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(4, 188)
        Me.label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(60, 23)
        Me.label7.TabIndex = 6
        Me.label7.Text = "Status"
        '
        'label5
        '
        Me.label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(4, 131)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(89, 23)
        Me.label5.TabIndex = 4
        Me.label5.Text = "Company:"
        '
        'label3
        '
        Me.label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(4, 74)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(95, 23)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Developer:"
        '
        'label2
        '
        Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(4, 17)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(144, 23)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Software Name : "
        '
        'lblsoftwarename
        '
        Me.lblsoftwarename.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblsoftwarename.AutoSize = True
        Me.lblsoftwarename.Location = New System.Drawing.Point(408, 17)
        Me.lblsoftwarename.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsoftwarename.Name = "lblsoftwarename"
        Me.lblsoftwarename.Size = New System.Drawing.Size(28, 23)
        Me.lblsoftwarename.TabIndex = 8
        Me.lblsoftwarename.Text = "---"
        '
        'lblsoftstatus
        '
        Me.lblsoftstatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblsoftstatus.AutoSize = True
        Me.lblsoftstatus.Location = New System.Drawing.Point(408, 188)
        Me.lblsoftstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsoftstatus.Name = "lblsoftstatus"
        Me.lblsoftstatus.Size = New System.Drawing.Size(28, 23)
        Me.lblsoftstatus.TabIndex = 9
        Me.lblsoftstatus.Text = "---"
        '
        'lbldevelopername
        '
        Me.lbldevelopername.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbldevelopername.AutoSize = True
        Me.lbldevelopername.Location = New System.Drawing.Point(408, 74)
        Me.lbldevelopername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldevelopername.Name = "lbldevelopername"
        Me.lbldevelopername.Size = New System.Drawing.Size(183, 23)
        Me.lbldevelopername.TabIndex = 10
        Me.lbldevelopername.Text = "TopingCoy IT Solutions"
        '
        'lblcompanyname
        '
        Me.lblcompanyname.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblcompanyname.AutoSize = True
        Me.lblcompanyname.Location = New System.Drawing.Point(408, 131)
        Me.lblcompanyname.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblcompanyname.Name = "lblcompanyname"
        Me.lblcompanyname.Size = New System.Drawing.Size(135, 23)
        Me.lblcompanyname.TabIndex = 11
        Me.lblcompanyname.Text = "Alcon Enterprise"
        '
        'appNameToolStripMenuItem
        '
        Me.appNameToolStripMenuItem.Name = "appNameToolStripMenuItem"
        Me.appNameToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.appNameToolStripMenuItem.Size = New System.Drawing.Size(89, 24)
        Me.appNameToolStripMenuItem.Text = "AppName"
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.appNameToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.menuStrip1.Size = New System.Drawing.Size(1137, 28)
        Me.menuStrip1.TabIndex = 15
        Me.menuStrip1.Text = "menuStrip1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblstatus, Me.ts_statfilename})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 516)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1137, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslblstatus
        '
        Me.tslblstatus.Name = "tslblstatus"
        Me.tslblstatus.Size = New System.Drawing.Size(1117, 17)
        Me.tslblstatus.Spring = True
        '
        'ts_statfilename
        '
        Me.ts_statfilename.Name = "ts_statfilename"
        Me.ts_statfilename.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ts_statfilename.Size = New System.Drawing.Size(69, 20)
        Me.ts_statfilename.Text = "Filename"
        Me.ts_statfilename.Visible = False
        '
        'Timer1
        '
        '
        'btnkill
        '
        Me.btnkill.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnkill.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnkill.Location = New System.Drawing.Point(729, 143)
        Me.btnkill.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnkill.Name = "btnkill"
        Me.btnkill.Size = New System.Drawing.Size(177, 44)
        Me.btnkill.TabIndex = 4
        Me.btnkill.Text = "Kill Process"
        Me.btnkill.UseVisualStyleBackColor = True
        '
        'btndel
        '
        Me.btndel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btndel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndel.Location = New System.Drawing.Point(444, 143)
        Me.btndel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btndel.Name = "btndel"
        Me.btndel.Size = New System.Drawing.Size(135, 44)
        Me.btndel.TabIndex = 2
        Me.btndel.Text = "Delete"
        Me.btndel.UseVisualStyleBackColor = True
        '
        'btnstartap
        '
        Me.btnstartap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnstartap.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnstartap.Location = New System.Drawing.Point(587, 143)
        Me.btnstartap.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnstartap.Name = "btnstartap"
        Me.btnstartap.Size = New System.Drawing.Size(135, 44)
        Me.btnstartap.TabIndex = 3
        Me.btnstartap.Text = "Start App"
        Me.btnstartap.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel1.BackgroundImage = Global.BMISUpdateManager.My.Resources.Resources.upperborder
        Me.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel1.Controls.Add(Me.btnbrwfile)
        Me.panel1.Controls.Add(Me.lblftpstatus)
        Me.panel1.Controls.Add(Me.Button1)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.pictureBox1)
        Me.panel1.Location = New System.Drawing.Point(0, 48)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1137, 87)
        Me.panel1.TabIndex = 12
        '
        'btnbrwfile
        '
        Me.btnbrwfile.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnbrwfile.Location = New System.Drawing.Point(924, 21)
        Me.btnbrwfile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnbrwfile.Name = "btnbrwfile"
        Me.btnbrwfile.Size = New System.Drawing.Size(88, 44)
        Me.btnbrwfile.TabIndex = 12
        Me.btnbrwfile.Text = "Browse.."
        Me.btnbrwfile.UseVisualStyleBackColor = True
        '
        'lblftpstatus
        '
        Me.lblftpstatus.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblftpstatus.AutoSize = True
        Me.lblftpstatus.Location = New System.Drawing.Point(1017, 62)
        Me.lblftpstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblftpstatus.Name = "lblftpstatus"
        Me.lblftpstatus.Size = New System.Drawing.Size(62, 17)
        Me.lblftpstatus.TabIndex = 11
        Me.lblftpstatus.Text = "ftpstatus"
        Me.lblftpstatus.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.Location = New System.Drawing.Point(1013, 21)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 44)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Upload"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Calibri", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(179, 27)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(363, 29)
        Me.label1.TabIndex = 1
        Me.label1.Text = "BMIS Application Update Manager"
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox1.BackgroundImage = Global.BMISUpdateManager.My.Resources.Resources.mvw_korem
        Me.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pictureBox1.Location = New System.Drawing.Point(4, 0)
        Me.pictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(151, 78)
        Me.pictureBox1.TabIndex = 0
        Me.pictureBox1.TabStop = False
        '
        'frmManageUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 538)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.btndel)
        Me.Controls.Add(Me.btnkill)
        Me.Controls.Add(Me.btnstartap)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage BMIS Update"
        Me.groupBox1.ResumeLayout(False)
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnInstall As System.Windows.Forms.Button
    Private WithEvents pbar1 As System.Windows.Forms.ProgressBar
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents appNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents btnkill As System.Windows.Forms.Button
    Private WithEvents btnstartap As System.Windows.Forms.Button
    Private WithEvents btndel As System.Windows.Forms.Button
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tslblstatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblsoftwarename As System.Windows.Forms.Label
    Friend WithEvents lblsoftstatus As System.Windows.Forms.Label
    Friend WithEvents lbldevelopername As System.Windows.Forms.Label
    Friend WithEvents lblcompanyname As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblftpstatus As System.Windows.Forms.Label
    Friend WithEvents btnbrwfile As System.Windows.Forms.Button
    Friend WithEvents ts_statfilename As System.Windows.Forms.ToolStripStatusLabel
End Class
