Imports MySql.Data.MySqlClient

Public Class frmBrgyClearanceList

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        frmBrgyClearanceEntry.ShowDialog()
    End Sub
End Class