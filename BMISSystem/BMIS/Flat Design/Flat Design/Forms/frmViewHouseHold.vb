Imports MySql.Data.MySqlClient

Public Class frmViewHouseHold

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    ' Sub loadrecords()
    '    cmd = New MySqlCommand("select CONCAT(lastname, ' ', firstname, ' ', midname)as fullname, address from residents where category like 'MEMBER'", cdb)
    'End Sub

    Sub loadrecords(hsno As String)
        Try
            condb()
            Dim qry As String = Nothing
            With dgvHouseHold1
                .Rows.Clear()
                'qry = "SELECT * from residents where category like 'HEAD OF THE FAMILY' ORDER BY lastname asc limit 1000"
                Dim srchstring As String = Nothing
                srchstring = hsno
                If hsno <> Nothing Then
                    qry = "SELECT CONCAT(lastname, ' ', firstname, ' ', midname)as fullname, birthdate, address from residents where houseno =@hno and category = 'MEMBER' ORDER BY lastname asc limit 1000"
                    Using cmd = New MySqlCommand()
                        cmd.Connection = cdb
                        cmd.CommandText = qry
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@hno", srchstring)
                        cmd.ExecuteNonQuery()
                        ' displaydata(cmd)
                        displaydata_HouseHold(cmd)
                    End Using
                End If

                '  lblCount.Text = "Record(s) found ( " + dgvResident.RowCount.ToString + ")"
            End With
            condb_close(cdb)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48, "Error Message")
        End Try
    End Sub

    Sub displaydata_HouseHold(cmd)
        condb()
        Dim dt As DataTable
        dt = retrieve_data_from_command(cmd)
        If dt.Rows.Count > 0 Then
            Dim r As Integer = 0
            Dim n As Integer = 0
            With dgvHouseHold1
                For Each rdr As DataRow In dt.Rows
                    .RowCount += 1
                    r = .RowCount - 1
                    n += 1
                    .Item(0, r).Value = n
                    .Item(1, r).Value = rdr("fullname").ToString
                    .Item(2, r).Value = rdr("birthdate").ToString
                    .Item(3, r).Value = rdr("address").ToString
                    '.Item(4, r).Value = rdr("id").ToString
                Next
            End With
        End If
        dt.Dispose()
        condb_close(cdb)
    End Sub



    Private Sub dgvHouseHold1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHouseHold1.CellContentClick

    End Sub
End Class