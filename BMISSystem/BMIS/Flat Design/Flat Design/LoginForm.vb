Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient
Imports System.Data.Sql
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class LoginForm
    Dim cm As MySqlCommand


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        pn_bar.Visible = True
        If txtUser.Text = String.Empty Then
            txtUser.Focus()
            MsgBox("Required missing field!", vbCritical)
            pn_bar.Visible = False
            Return
        End If

        Dim dt As Date
        condb()
        dt = gettime2(3)
        cm = New MySqlCommand("SELECT * FROM bmis_useraccout001  WHERE BINARY username1=@user", cdb)
        cm.Parameters.AddWithValue("@user", txtUser.Text.Trim)
        my_datatab = retrieve_data_from_command(cm)
        If my_datatab.Rows.Count > 0 Then
            Dim rws As DataRow
            rws = my_datatab.Rows(0)
            _user = txtUser.Text.Trim
            _userid = rws("user_id").ToString
            _pass = rws("password1").ToString
            ' _user = EncryptNew("test")
            '_user = EncryptNew("root")
            If EncryptNew(txtPass.Text.Trim) = _pass Then

                'savetrails(_userid, "Login to BMIS succeeded " & "--" & _user, dt)
                pn_bar.Visible = False
                MainForm.Show()

                txtUser.Focus()
                txtUser.Text = Nothing
                txtPass.Text = Nothing
                Me.Hide()
                MsgBox("Username and Password Verified", 64, "Access Granted")
            Else
                savetrails(_userid, "Failed Login " & "--" & _user, dt)
                MsgBox("Unknown username and password", 48, "Access Denied")
            End If
           
            pn_bar.Visible = False

        Else
            '  savetrails("0", "Failed Login USERNAME " & "--" & txtUser.Text.Trim, dt)
            MsgBox("Please check, no account associated with this ( USERNAME ) : " & txtUser.Text.Trim, 48, "Username account not Found")
            pn_bar.Visible = False
        End If

        condb_close(cdb)
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        End
    End Sub

    Private Sub txtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            OK.PerformClick()
        End If
    End Sub

    Private Sub frmloginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   condb()
    End Sub

    Private Sub txtUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUser.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPass.Focus()
        End If
    End Sub


End Class
