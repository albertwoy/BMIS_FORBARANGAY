Imports System.IO

Public Class frmAppName

    Private Sub frmAppName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblappname.Text = My.Settings.AppNameFull
        tbtimeinterval.Text = My.Settings.TimerInterval
        tbappname.Text = My.Settings.AppN
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.AppNameFull = lblappname.Text
        My.Settings.TimerInterval = tbtimeinterval.Text
        My.Settings.AppN = tbappname.Text
        My.Settings.Save()

        frmManageUpdate.lblsoftwarename.Text = My.Settings.AppN

        Me.Close()


    End Sub

    Private Sub tbappname_TextChanged(sender As Object, e As EventArgs) Handles tbappname.TextChanged

        lblappname.Text = tbappname.Text & ".exe"
    End Sub

    Private Sub tbtimeinterval_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbtimeinterval.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 And Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tbtimeinterval_TextChanged(sender As Object, e As EventArgs) Handles tbtimeinterval.TextChanged

    End Sub
End Class