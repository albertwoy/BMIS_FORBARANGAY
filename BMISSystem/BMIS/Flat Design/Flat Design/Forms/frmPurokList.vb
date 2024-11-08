Imports MySql.Data.MySqlClient

Public Class frmPurokList

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        frmPurokEntry.ShowDialog()
    End Sub

    Private Sub frmPurokList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPurok()
    End Sub

    Sub LoadPurok()
        condb()
        Try
            Dim qry As String = Nothing
            With dgvPurok
                .Rows.Clear()
                'qry = "SELECT * from purok ORDER BY purok asc limit 1000"
                qry = "SELECT * from purok WHERE purok like '%" & txtSearch.Text.Trim & "%' OR president like '%" & txtSearch.Text.Trim & "%' ORDER BY purok"
                Using cmd = New MySqlCommand()
                    cmd.Connection = cdb
                    cmd.CommandText = qry
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    displaydata(cmd)
                End Using
            End With
            condb_close(cdb)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48, "Error Message")
        End Try
    End Sub

    Sub displaydata(cmd)
        condb()
        Dim dt_purok As DataTable
        dt_purok = retrieve_data_from_command(cmd)
        If dt_purok.Rows.Count > 0 Then
            Dim r As Integer = 0
            Dim n As Integer = 0
            With dgvPurok
                For Each rdr As DataRow In dt_purok.Rows
                    .RowCount += 1
                    r = .RowCount - 1
                    n += 1
                    .Item(0, r).Value = n
                    .Item(1, r).Value = rdr("purok").ToString
                    .Item(2, r).Value = rdr("president").ToString
                Next
            End With
        End If
        dt_purok.Dispose()
        condb_close(cdb)
    End Sub

    Private Sub dgvPurok_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurok.CellContentClick
        Dim colName As String = dgvPurok.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            With frmPurokEntry
                .txtPurok.Text = dgvPurok.Rows(e.RowIndex).Cells(1).Value.ToString
                .txtPresident.Text = dgvPurok.Rows(e.RowIndex).Cells(2).Value.ToString
                .btnSave.Enabled = False
                .btnUpdate.Enabled = True
                .ShowDialog()
            End With
        ElseIf colName = "colDelete" Then
            If MsgBox("Delete this record? Click yes to confirm", vbYesNo + vbQuestion) = vbYes Then
                condb()
                cmd = New MySqlCommand("delete from purok where purok like '" & dgvPurok.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cdb)
                cmd.ExecuteNonQuery()
                condb_close(cdb)
                AuditTrail("Delete Purok " & dgvPurok.Rows(e.RowIndex).Cells(1).Value.ToString & Space(2) & dgvPurok.Rows(e.RowIndex).Cells(2).Value.ToString, "Delete Purok")
                MsgBox("Record has been successfully deleted!", vbInformation)
                LoadPurok()
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadPurok()
    End Sub
End Class