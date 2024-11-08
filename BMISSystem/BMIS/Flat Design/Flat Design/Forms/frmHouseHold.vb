Imports MySql.Data.MySqlClient

Public Class frmHouseHold

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmHouseHold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRecords()
    End Sub

    Sub LoadRecords()
        condb()
        Try
            Dim qry As String = Nothing
            With dgvHouseHold
                .Rows.Clear()
                qry = "SELECT * from residents where CONCAT(lastname, firstname, address) like '%" & txtSearch.Text.Trim & "%' AND category like 'HEAD OF THE FAMILY' ORDER BY lastname asc limit 1000"
                Using cmd = New MySqlCommand()
                    cmd.Connection = cdb
                    cmd.CommandText = qry
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    displaydata(cmd)
                End Using
                lblCount.Text = "Record(s) found ( " + dgvHouseHold.RowCount.ToString + ")"
            End With
            condb_close(cdb)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48, "Error Message")
        End Try
    End Sub

    Sub displaydata(cmd)
        condb()
        Dim dt As DataTable
        dt = retrieve_data_from_command(cmd)
        If dt.Rows.Count > 0 Then
            Dim r As Integer = 0
            Dim n As Integer = 0
            With dgvHouseHold
                For Each rdr As DataRow In dt.Rows
                    .RowCount += 1
                    r = .RowCount - 1
                    n += 1
                    .Item(0, r).Value = n
                    .Item(1, r).Value = rdr("id").ToString
                    .Item(2, r).Value = rdr("lastname").ToString
                    .Item(3, r).Value = rdr("firstname").ToString
                    .Item(4, r).Value = rdr("midname").ToString
                    .Item(5, r).Value = rdr("address").ToString
                    .Item(6, r).Value = rdr("houseno").ToString
                Next
            End With
        End If
        dt.Dispose()
        condb_close(cdb)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadRecords()
    End Sub

    Private Sub dgvResident_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHouseHold.CellContentClick
        Dim colName As String = dgvHouseHold.Columns(e.ColumnIndex).Name
        If colName = "colSelect" Then
            frmResidentEntry.txtHouseNo.Text = dgvHouseHold.CurrentRow.Cells(6).Value.ToString
            frmResidentEntry.txtHeadofFamily.Text = dgvHouseHold.CurrentRow.Cells(2).Value.ToString + ", " + Space(1) + dgvHouseHold.CurrentRow.Cells(3).Value.ToString
            Me.Dispose()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class