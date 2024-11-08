Imports System.Linq

Public Class MainForm
    Dim menumode As New MenuClass
    
    Private Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        selectedmenu = 0
        menumode.btnremove_spaces()
        If btnDashboard.Tag = Nothing Then
            btnDashboard.Text = Space(5) & btnDashboard.Text
        End If
        btnDashboard.Tag = "click"

        Dim f As frmDashBoard = frmDashBoard
        menumode.changebtnbackcolor_default(btnDashboard)
        Label1.Text = "Main / Dashboard"
        f.TopLevel = False
        Panel5.Controls.Add(f)
        f.BringToFront()
        f.Width = Panel5.Width
        f.Height = Panel5.Height
        f.Get_Dashboard()
        f.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Dim c As Integer
        If MsgBox("Are you sure you want to logout?", 4 + 32, "LOG-OUT?") = 7 Then
            c = 1
        Else
            condb_close(cdb)
            Me.Close()
            LoginForm.Show()


        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim dt As Date
        condb()
        dt = gettime2(3)
        savetrails(_userid, "LogOut to MU Insurance Generator " & "--" & _user, dt)
        condb_close(cdb)
        End
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnlogout.PerformClick()
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'condb()
        '  btndashboard.PerformClick()
        Me.txtnewversion.Text = String.Format("{0}", My.Application.Info.Version.ToString)
        tsupdatelab.Text = "System Version (" & Me.txtnewversion.Text & ")"
        pgbar1.Size = New System.Drawing.Size(stst1.Width - 155, 17)

        btnDashboard.PerformClick()
        Timer1.Enabled = True

        '  pgbar1.Width = stst1.Width - 318
    End Sub

    Private Sub btnNewResident_Click(sender As Object, e As EventArgs) Handles btnNewResident.Click
        selectedmenu = 1

        Dim f As frmResidentList = frmResidentList
        menumode.changebtnbackcolor_default(btnNewResident)

        menumode.btnremove_spaces()
        If btnNewResident.Tag = Nothing Then
            btnNewResident.Text = Space(5) & btnNewResident.Text
        End If
        btnNewResident.Tag = "click"

        Label1.Text = "Main / Resident"
        f.TopLevel = False

        Panel5.Controls.Add(f)
        f.BringToFront()
        f.Width = Panel5.Width
        f.Height = Panel5.Height
        f.Show()
    End Sub

    Private Sub btnuserm_Click(sender As Object, e As EventArgs)
        With frmcreateuser
            selectedmenu = 2
            .TopLevel = False
            '  closeallforms(Me)
            ' closeallforms(frmaddvisitor)
            'changebtnbackcolor_default(btnuserm)
            Panel5.Controls.Clear()
            Panel5.Controls.Add(frmcreateuser)
            .BringToFront()
            .Show()
        End With
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs)
        With frmDashBoard
            selectedmenu = 3
            .TopLevel = False
            '  changebtnbackcolor_default(btnissued)
            ' currentopenform = frmdashboard
            Panel5.Controls.Clear()
            closeallforms(frmDashBoard)
            Panel5.Controls.Add(frmDashBoard)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnagency_Click(sender As Object, e As EventArgs)
        With frmvpassdetail
            selectedmenu = 4
            .TopLevel = False
            ' changebtnbackcolor_default(btnagency)
            ' currentopenform = frmdashboard
            Panel5.Controls.Clear()
            closeallforms(frmDashBoard)
            Panel5.Controls.Add(frmvpassdetail)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnResidentRecords_Click(sender As Object, e As EventArgs) Handles btnBrgyClearance.Click
        selectedmenu = 1

        Dim f As frmBrgyClearanceList = frmBrgyClearanceList
        menumode.changebtnbackcolor_default(btnBrgyClearance)

        menumode.btnremove_spaces()
        If btnBrgyClearance.Tag = Nothing Then
            btnBrgyClearance.Text = Space(5) & btnBrgyClearance.Text
        End If
        btnBrgyClearance.Tag = "click"

        Label1.Text = "Main / Brgy. Clearance"
        f.TopLevel = False

        Panel5.Controls.Add(f)
        f.BringToFront()
        f.Width = Panel5.Width
        f.Height = Panel5.Height
        f.Show()

        'With frmtrails
        '    selectedmenu = 2

        '    Dim f As frmtrails = frmtrails

        '    menumode.btnremove_spaces()
        '    If btnResidentRecords.Tag = Nothing Then
        '        btnResidentRecords.Text = Space(5) & btnResidentRecords.Text
        '    End If
        '    btnResidentRecords.Tag = "click"

        '    menumode.changebtnbackcolor_default(btnResidentRecords)
        '    Label1.Text = "Main  /  User Trail"
        '    f.TopLevel = False
        '    Panel5.Controls.Add(f)
        '    f.BringToFront()
        '    f.Width = Panel5.Width
        '    f.Height = Panel5.Height
        '    f.Show()
        'End With


    End Sub

   
    Private Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        Dim dt As Date
        condb()
        dt = gettime2(3)
        savetrails(_userid, "LogOut to BMIS " & "--" & _user, dt)
        condb_close(cdb)
        End
    End Sub


    Private Sub SystemUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmDownloadUpdates.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel6.Visible = False
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        frmDownloadUpdates.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        checkupdate()
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = intX
        Me.Height = intY - 45
        Me.Left = 0
        Me.Top = 0
    End Sub

    
    Private Sub btnPurok_Click(sender As Object, e As EventArgs) Handles btnPurok.Click
        selectedmenu = 1

        Dim f As frmPurokList = frmPurokList
        menumode.changebtnbackcolor_default(btnPurok)

        menumode.btnremove_spaces()
        If btnPurok.Tag = Nothing Then
            btnPurok.Text = Space(5) & btnPurok.Text
        End If
        btnPurok.Tag = "click"

        Label1.Text = "Main  /  New Purok"
        f.TopLevel = False

        Panel5.Controls.Add(f)
        f.BringToFront()
        f.Width = Panel5.Width
        f.Height = Panel5.Height
        f.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnOfficial_Click(sender As Object, e As EventArgs) Handles btnOfficial.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub


End Class
