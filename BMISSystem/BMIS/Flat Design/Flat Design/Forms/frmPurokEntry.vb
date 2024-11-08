Imports MySql.Data.MySqlClient

Public Class frmPurokEntry

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IS_EMPTY(txtPurok) = True Then Return
        If IS_EMPTY(txtPresident) = True Then Return

        Try
            condb()
            If MsgBox("Save this record? Click yes to confirm.", vbYesNo + vbQuestion, "New Purok") = vbYes Then
                Dim cmd As MySqlCommand
                cmd = New MySqlCommand("INSERT INTO purok (purok,president) VALUES (@purok,@president)", cdb)
                With cmd
                    cmd.Parameters.AddWithValue("@purok", txtPurok.Text)
                    cmd.Parameters.AddWithValue("@president", txtPresident.Text)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    condb_close(cdb)
                End With
                MsgBox("Record has save successfully", vbInformation, "New Purok")
                AuditTrail("Added Purok " & txtPurok.Text & " " & txtPresident.Text, "New Purok")
                Clear()
                frmPurokList.LoadPurok()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48, "Error Message")
        End Try
    End Sub

    Sub Clear()
        txtPurok.Clear()
        txtPresident.Clear()
        txtPurok.Focus()
    End Sub

    Private Sub frmPurokEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If IS_EMPTY(txtPurok) = True Then Return
        If IS_EMPTY(txtPresident) = True Then Return
        Try
            condb()
            If MsgBox("Save this record? Click yes to confirm.", vbYesNo + vbQuestion, "New Purok") = vbYes Then
                Dim cmd As MySqlCommand
                cmd = New MySqlCommand("UPDATE purok SET purok=@purok, president=@president WHERE purok=@purok", cdb)
                With cmd
                    cmd.Parameters.AddWithValue("@purok", txtPurok.Text)
                    cmd.Parameters.AddWithValue("@president", txtPresident.Text)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    condb_close(cdb)
                End With
                MsgBox("Record has updated successfully", vbInformation, "Purok Entry")
                AuditTrail("Update Purok " & txtPurok.Text & " " & txtPresident.Text, "Update Purok")
                Clear()
                frmPurokList.LoadPurok()
                Me.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48, "Error Message")
        End Try
    End Sub
End Class