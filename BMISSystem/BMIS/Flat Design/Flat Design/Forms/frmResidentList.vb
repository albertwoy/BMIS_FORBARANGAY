Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmResidentList

    Dim menumode As New MenuClass

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        frmResidentEntry.LoadPurok()
        frmResidentEntry.btnUpdate.Enabled = False
        frmResidentEntry.picResident.BackgroundImage = Image.FromFile(Application.StartupPath & "\id.png")
        frmResidentEntry.ShowDialog()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmResidentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadResident()
        LoadHouseHold()
    End Sub

    Sub LoadResident()
        Try
            condb()
            Dim qry As String = Nothing
            With dgvResident
                .Rows.Clear()
                qry = "SELECT * from residents where CONCAT(lastname, firstname, address) like '%" & txtSearch.Text.Trim & "%' ORDER BY lastname asc limit 1000"
                Using cmd = New MySqlCommand()
                    cmd.Connection = cdb
                    cmd.CommandText = qry
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    displaydata(cmd)
                End Using
                '   lblCount.Text = "Record(s) found ( " + dgvResident.RowCount.ToString + ")"
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
            With dgvResident
                For Each rdr As DataRow In dt.Rows
                    .RowCount += 1
                    r = .RowCount - 1
                    n += 1
                    .Item(0, r).Value = n
                    .Item(1, r).Value = rdr("nid").ToString
                    .Item(2, r).Value = rdr("lastname").ToString
                    .Item(3, r).Value = rdr("firstname").ToString
                    .Item(4, r).Value = rdr("midname").ToString
                    .Item(5, r).Value = rdr("birthdate").ToString
                    .Item(6, r).Value = rdr("age").ToString
                    .Item(7, r).Value = rdr("gender").ToString
                    .Item(8, r).Value = rdr("civilstatus").ToString
                    .Item(9, r).Value = rdr("category").ToString
                    .Item(10, r).Value = rdr("address").ToString
                    .Item(11, r).Value = rdr("houseno").ToString
                    .Item(12, r).Value = rdr("id").ToString
                Next
            End With
        End If
        dt.Dispose()
        condb_close(cdb)
    End Sub

    Sub LoadHouseHold()
        Try
            condb()
            Dim qry As String = Nothing
            With dgvHouseHold
                .Rows.Clear()
                'qry = "SELECT * from residents where CONCAT(lastname, firstname, address) like '%" & txtSearch.Text.Trim & "%' and category like '%" HEAD OF THE FAMILY '%" ORDER BY lastname asc limit 1000"
                qry = "SELECT * from residents where category like 'HEAD OF THE FAMILY' ORDER BY lastname asc limit 1000"
                Using cmd = New MySqlCommand()
                    cmd.Connection = cdb
                    cmd.CommandText = qry
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                    ' displaydata(cmd)
                    displaydata_HouseHold(cmd)
                End Using
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
            With dgvHouseHold
                For Each rdr As DataRow In dt.Rows
                    .RowCount += 1
                    r = .RowCount - 1
                    n += 1
                    .Item(0, r).Value = n
                    .Item(1, r).Value = rdr("nid").ToString
                    .Item(2, r).Value = rdr("lastname").ToString
                    .Item(3, r).Value = rdr("firstname").ToString
                    .Item(4, r).Value = rdr("midname").ToString
                    .Item(5, r).Value = rdr("birthdate").ToString
                    .Item(6, r).Value = rdr("age").ToString
                    .Item(7, r).Value = rdr("gender").ToString
                    .Item(8, r).Value = rdr("civilstatus").ToString
                    .Item(9, r).Value = rdr("category").ToString
                    .Item(10, r).Value = rdr("address").ToString
                    .Item(11, r).Value = rdr("houseno").ToString
                    .Item(12, r).Value = rdr("id").ToString
                Next
            End With
        End If
        dt.Dispose()
        condb_close(cdb)
    End Sub


    Private Sub dgvResident_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResident.CellContentClick
        Dim colName As String = dgvResident.Columns(e.ColumnIndex).Name

        If colName = "colEdit" Then
            With frmResidentEntry
                condb()
                cmd = New MySqlCommand("select  nid, lastname, firstname, midname, alias, birthdate, birthplace, age, civilstatus, gender, religion, email, contactno, voters, precintno, purok, education, occupation, address, category, houseno, head, disability, status, id from residents where id = '" & dgvResident.Rows(e.RowIndex).Cells(12).Value.ToString & "'", cdb)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    'Dim len As Long = rd.GetBytes(0, 0, Nothing, 0, 0)
                    'Dim array(CInt(len)) As Byte
                    'rd.GetBytes(0, 0, array, 0, CInt(len))

                    'Dim ms As New MemoryStream(array)
                    'Dim bitmap As New System.Drawing.Bitmap(ms)
                    'If Not bitmap Is Nothing Then

                    'End If
                    ' .picResident.BackgroundImage = bitmap
                    .txtNID.Text = rd.Item("nid").ToString
                    .txtLastname.Text = rd.Item("lastname").ToString
                    .txtFirstname.Text = rd.Item("firstname").ToString
                    .txtMidname.Text = rd.Item("midname").ToString
                    .txtAlias.Text = rd.Item("alias").ToString
                    .dtpDOB.Text = rd.Item("birthdate").ToString
                    .txtBirthplace.Text = rd.Item("birthplace").ToString
                    .txtAge.Text = rd.Item("age").ToString
                    .cboCivilStatus.Text = rd.Item("civilstatus").ToString
                    .cboGender.Text = rd.Item("gender").ToString
                    .cboReligion.Text = rd.Item("religion").ToString
                    .txtEmail.Text = rd.Item("email").ToString
                    .txtContact.Text = rd.Item("contactno").ToString
                    .cboVoters.Text = rd.Item("voters").ToString
                    .txtPrecint.Text = rd.Item("precintno").ToString
                    .cboPurok.Text = rd.Item("purok").ToString
                    .txtEducation.Text = rd.Item("education").ToString
                    .txtOccupation.Text = rd.Item("occupation").ToString
                    .txtAddress.Text = rd.Item("address").ToString
                    .cboCategory.Text = rd.Item("category").ToString
                    .txtHouseNo.Text = rd.Item("houseno").ToString
                    .txtHeadofFamily.Text = rd.Item("head").ToString
                    .cboPwd.Text = rd.Item("disability").ToString
                    .cboStatus.Text = rd.Item("status").ToString
                    .txtID.Text = rd.Item("id").ToString
                    .btnSave.Enabled = False


                End If
                rd.Dispose()
                rd.Close()
                cmd.Dispose()

                cmd = New MySqlCommand("SELECT picture FROM residents_pics WHERE resident_id=@rsid", cdb)
                cmd.Parameters.AddWithValue("@rsid", .txtID.Text.Trim)
                Dim dtb As DataTable
                dtb = New DataTable
                dtb = retrieve_data_from_command(cmd)
                cmd.Dispose()
                If dtb.Rows.Count > 0 Then
                    Dim rwx As DataRow = dtb.Rows(0)
                    If Not rwx("picture") Is Nothing Then
                        .Label42.Visible = True
                        .picResident.BackgroundImage = Byte2Image(rwx("picture"))
                    End If
                End If
                .ShowDialog()

                condb_close(cdb)
            End With
        ElseIf colName = "colDelete" Then
            If MsgBox("Delete this record? Click yes to confirm", vbYesNo + vbQuestion) = vbYes Then
                condb()
                cm = New MySqlCommand("delete from residents where id like '" & dgvResident.Rows(e.RowIndex).Cells(12).Value.ToString & "'", cdb)
                cm.ExecuteNonQuery()
                condb_close(cdb)

                Dim fullname As String = dgvResident.Rows(e.RowIndex).Cells(2).Value.ToString & ", " & dgvResident.Rows(e.RowIndex).Cells(3).Value.ToString & Space(2) & dgvResident.Rows(e.RowIndex).Cells(4).Value.ToString
                AuditTrail("Delete Resident " & dgvResident.Rows(e.RowIndex).Cells(1).Value.ToString & Space(2) & fullname, "Delete Module")
                MsgBox("Record has been successfully deleted!", vbInformation)
                LoadResident()
            End If
        End If

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadResident()
    End Sub

    Private Sub dgvHouseHold_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHouseHold.CellContentClick
        Dim colName As String = dgvHouseHold.Columns(e.ColumnIndex).Name

        Dim _id, hsno As String
        _id = dgvHouseHold.Rows(e.RowIndex).Cells(12).Value.ToString
        If colName = "btnView" Then
            With frmViewHouseHold
                condb()
                Try
                    'cmd = New MySqlCommand("select (lastname + ',' + firstname + '' + midname) as fullname, houseno, address from residents where id=@id", cdb)
                    cmd = New MySqlCommand("select CONCAT(lastname, ' ', firstname, ' ', midname)as fullname, houseno from residents where id=@id", cdb)
                    cmd.Parameters.AddWithValue("@id", _id)
                    rd = cmd.ExecuteReader
                    hsno = Nothing
                    If rd.HasRows Then
                        rd.Read()
                        hsno = rd("houseno").ToString
                        .lblHouseno.Text = rd("houseno").ToString
                        .lblHead.Text = rd("fullname").ToString
                    End If

                    rd.Dispose()
                    condb_close(cdb)

                    frmViewHouseHold.loadrecords(hsno)
                    .ShowDialog()

                Catch ex As Exception
                    MsgBox(ex.Message.ToString, 48, "Error Message")
                End Try

            End With
        End If
    End Sub

    Sub loadrecords()

    End Sub
End Class