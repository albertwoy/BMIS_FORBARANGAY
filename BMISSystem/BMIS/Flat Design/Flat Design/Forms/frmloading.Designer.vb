<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmloading
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmloading))
        Me.pn_bar = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pgloading = New System.Windows.Forms.PictureBox()
        Me.pn_bar.SuspendLayout()
        CType(Me.pgloading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pn_bar
        '
        Me.pn_bar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pn_bar.BackColor = System.Drawing.Color.Snow
        Me.pn_bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pn_bar.Controls.Add(Me.Label6)
        Me.pn_bar.Controls.Add(Me.pgloading)
        Me.pn_bar.Location = New System.Drawing.Point(1, 2)
        Me.pn_bar.Name = "pn_bar"
        Me.pn_bar.Size = New System.Drawing.Size(423, 89)
        Me.pn_bar.TabIndex = 147
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(2, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(415, 19)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "This may take several seconds..."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgloading
        '
        Me.pgloading.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgloading.Image = CType(resources.GetObject("pgloading.Image"), System.Drawing.Image)
        Me.pgloading.Location = New System.Drawing.Point(0, 37)
        Me.pgloading.Name = "pgloading"
        Me.pgloading.Size = New System.Drawing.Size(419, 48)
        Me.pgloading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pgloading.TabIndex = 489
        Me.pgloading.TabStop = False
        '
        'frmloading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.ClientSize = New System.Drawing.Size(425, 93)
        Me.Controls.Add(Me.pn_bar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmloading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loading Data"
        Me.pn_bar.ResumeLayout(False)
        CType(Me.pgloading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pn_bar As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pgloading As System.Windows.Forms.PictureBox
End Class
