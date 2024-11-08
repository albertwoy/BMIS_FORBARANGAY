Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmResidentEntry

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'MainForm.Label1.Text = "Main"
        Me.Dispose()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using o As New OpenFileDialog With {.Filter = "(Image files)|*.jpg;*.png*.gif;|Jpg, *.jpg|Png, *.png|Gif, |*.gif", .Multiselect = False, .Title = "Select Image"}
            If o.ShowDialog = 1 Then
                If o.FileName <> Nothing Then
                    'picResident.BackgroundImage = Image.FromFile(o.FileName)
                    picResident.BackgroundImage = ResizeImage(Image.FromFile(o.FileName), New Size(800, 686))
                    OpenFileDialog1.FileName = o.FileName
                Else
                    MsgBox("Please select proper file/filename", 48, "Error on File")
                End If
          
            End If
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        '  If IS_EMPTY(txtNID) = True Then Return
        If IS_EMPTY(txtLastname) = True Then Return
        If IS_EMPTY(txtFirstname) = True Then Return
        If IS_EMPTY(txtMidname) = True Then Return
        If IS_EMPTY(txtBirthplace) = True Then Return
        If dtpDOB.Text = Date.Today Then
            MsgBox("Check birth date!", vbInformation)
            Return
        End If
        If IS_EMPTY(cboStatus) = True Then Return
        If IS_EMPTY(cboGender) = True Then Return
        If IS_EMPTY(cboReligion) = True Then Return
        If IS_EMPTY(txtContact) = True Then Return
        If IS_EMPTY(cboVoters) = True Then Return
        If IS_EMPTY(cboPurok) = True Then Return
        If IS_EMPTY(txtEducation) = True Then Return
        If IS_EMPTY(txtOccupation) = True Then Return
        If IS_EMPTY(txtAddress) = True Then Return
        If IS_EMPTY(cboCategory) = True Then Return
        '  If IS_EMPTY(txtHouseNo) = True Then Return
        'If IS_EMPTY(cboHead) = True Then Return
        If IS_EMPTY(cboStatus) = True Then Return


        ' Try
        condb()
        If MsgBox("Save this record? Click yes to confirm.", vbYesNo + vbQuestion, "New Resident") = vbYes Then
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("INSERT INTO residents (nid,lastname,firstname,midname,alias,birthdate,birthplace,age,civilstatus,gender,religion,email,contactno,voters,precintno,purok,education,occupation,address,category,houseno,head,disability,status) VALUES (@nid,@lastname,@firstname,@midname,@alias,@birthdate,@birthplace,@age,@civilstatus,@gender,@religion,@email,@contactno,@voters,@precintno,@purok,@education,@occupation,@address,@category,@houseno,@head,@disability,@status);SELECT @@IDENTITY", cdb)

            Dim mstream As New System.IO.MemoryStream

            picResident.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)

            Dim arrImage() As Byte = mstream.GetBuffer

            With cmd
                Dim lastid As Integer = 0

                cmd.Parameters.AddWithValue("@nid", txtNID.Text)
                cmd.Parameters.AddWithValue("@lastname", txtLastname.Text)
                cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text)
                cmd.Parameters.AddWithValue("@midname", txtMidname.Text)
                cmd.Parameters.AddWithValue("@alias", txtAlias.Text)
                cmd.Parameters.AddWithValue("@birthdate", dtpDOB.Value)
                cmd.Parameters.AddWithValue("@birthplace", txtBirthplace.Text)
                cmd.Parameters.AddWithValue("@age", txtAge.Text)
                cmd.Parameters.AddWithValue("@civilstatus", cboCivilStatus.Text)
                cmd.Parameters.AddWithValue("@gender", cboGender.Text)
                cmd.Parameters.AddWithValue("@religion", cboReligion.Text)
                cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@contactno", txtContact.Text)
                cmd.Parameters.AddWithValue("@voters", cboVoters.Text)
                cmd.Parameters.AddWithValue("@precintno", txtPrecint.Text)
                cmd.Parameters.AddWithValue("@purok", cboPurok.Text)
                cmd.Parameters.AddWithValue("@education", txtEducation.Text)
                cmd.Parameters.AddWithValue("@occupation", txtOccupation.Text)
                cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@category", cboCategory.Text)
                cmd.Parameters.AddWithValue("@houseno", txtHouseNo.Text)
                cmd.Parameters.AddWithValue("@head", txtHeadofFamily.Text)
                cmd.Parameters.AddWithValue("@disability", cboPwd.Text)
                cmd.Parameters.AddWithValue("@status", cboStatus.Text)
                ' cmd.Parameters.AddWithValue("@picture", arrImage)
                'cmd.ExecuteNonQuery()
                'cmd.Dispose()

                'cmd = New MySqlCommand("", cdb)
                lastid = cmd.ExecuteScalar()
                cmd.Dispose()

                cmd = New MySqlCommand("INSERT INTO residents_pics(resident_id,picture) VALUES(@rsid,@picimg)", cdb)
                cmd.Parameters.AddWithValue("@rsid", lastid)
                cmd.Parameters.AddWithValue("@picimg", arrImage)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

            End With

            Dim fullname As String = txtLastname.Text & ", " & txtFirstname.Text & Space(2) & txtMidname.Text
            AuditTrail("Added New Resident " & txtNID.Text & Space(2) & fullname, "Resident Module")
            MsgBox("Record has been successfully saved!", vbInformation)
            Clear()
            frmResidentList.LoadResident()
            frmDashBoard.Get_Dashboard()
        End If
        'cdb.Close()
        condb_close(cdb)
        ' Catch ex As Exception
        'MsgBox(ex.Message.ToString, 48, "Error Message")
        '  End Try

    End Sub

    Sub Clear()
        picResident.BackgroundImage = Image.FromFile(Application.StartupPath & "\id.png")
        txtNID.Clear()
        txtLastname.Clear()
        txtFirstname.Clear()
        txtMidname.Clear()
        txtAlias.Clear()
        dtpDOB.Text = Nothing
        txtBirthplace.Clear()
        txtAge.Clear()
        cboCivilStatus.Text = Nothing
        cboGender.Text = Nothing
        cboReligion.Text = Nothing
        txtEmail.Clear()
        txtContact.Clear()
        cboVoters.Text = Nothing
        txtPrecint.Clear()
        cboPurok.Text = Nothing
        txtEducation.Clear()
        txtOccupation.Clear()
        txtAddress.Clear()
        cboCategory.Text = Nothing
        txtHouseNo.Clear()
        txtHeadofFamily.Clear()
        cboPwd.Text = Nothing
        cboStatus.Text = Nothing
        'picResident.BackgroundImage = Nothing
        txtNID.Focus()
    End Sub

    Private Sub frmResidentEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'picResident.BackgroundImage = Image.FromFile(Application.StartupPath & "\id.png")


    End Sub

    Sub LoadPurok()
        condb()
        Dim qry As String = Nothing
        Dim rmd As New MySqlCommand

        cboPurok.Items.Clear()
        cboPurok.DisplayMember = "text"
        qry = "Select * from purok ORDER BY purok"
        rmd = New MySqlCommand(qry, cdb)
        rmd.ExecuteNonQuery()
        Dim relr = rmd.ExecuteReader()
        While relr.Read()
            cboPurok.Items.Add(New With {.Text = relr("purok").ToString()}) ', .Value = relr("suppliername").ToString()})
        End While
        relr.Close()
        rmd.Dispose()
        condb_close(cdb)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            '  If IS_EMPTY(txtNID) = True Then Return
            If IS_EMPTY(txtLastname) = True Then Return
            If IS_EMPTY(txtFirstname) = True Then Return
            If IS_EMPTY(txtMidname) = True Then Return
            If IS_EMPTY(txtBirthplace) = True Then Return
            If dtpDOB.Text = Date.Today Then
                MsgBox("Check birth date!", vbInformation)
                Return
            End If
            If IS_EMPTY(cboStatus) = True Then Return
            If IS_EMPTY(cboGender) = True Then Return
            If IS_EMPTY(cboReligion) = True Then Return
            If IS_EMPTY(txtContact) = True Then Return
            If IS_EMPTY(cboVoters) = True Then Return
            If IS_EMPTY(cboPurok) = True Then Return
            If IS_EMPTY(txtEducation) = True Then Return
            If IS_EMPTY(txtOccupation) = True Then Return
            If IS_EMPTY(txtAddress) = True Then Return
            If IS_EMPTY(cboCategory) = True Then Return
            '  If IS_EMPTY(txtHouseNo) = True Then Return
            'If IS_EMPTY(cboHead) = True Then Return
            If IS_EMPTY(cboStatus) = True Then Return

            If MsgBox("Update this record? Click yes to confirm.", vbYesNo + vbQuestion) = vbYes Then
                condb()
                If OpenFileDialog1.FileName <> "OpenFileDialog1" Then
                    cmd = New MySqlCommand("update residents set nid=@nid, lastname=@lastname, firstname=@firstname, midname=@midname, alias=@alias, birthdate=@birthdate, birthplace=@birthplace, age=@age, civilstatus=@civilstatus, gender=@gender, religion=@religion, email=@email, contactno=@contactno, voters=@voters, precintno=@precintno, purok=@purok, education=@education, occupation=@occupation, address=@address, category=@category, houseno=@houseno, head=@head, disability=@disability, status=@status where id=@id", cdb)
                Else
                    cmd = New MySqlCommand("update residents set nid=@nid, lastname=@lastname, firstname=@firstname, midname=@midname, alias=@alias, birthdate=@birthdate, birthplace=@birthplace, age=@age, civilstatus=@civilstatus, gender=@gender, religion=@religion, email=@email, contactno=@contactno, voters=@voters, precintno=@precintno, purok=@purok, education=@education, occupation=@occupation, address=@address, category=@category, houseno=@houseno, head=@head, disability=@disability, status=@status where id=@id", cdb)
                End If

                Dim mstream As New System.IO.MemoryStream
                picResident.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage() As Byte = mstream.GetBuffer

                With cmd
                    .Parameters.AddWithValue("@nid", txtNID.Text)
                    .Parameters.AddWithValue("@lastname", txtLastname.Text)
                    .Parameters.AddWithValue("@firstname", txtFirstname.Text)
                    .Parameters.AddWithValue("@midname", txtMidname.Text)
                    .Parameters.AddWithValue("@alias", txtAlias.Text)
                    .Parameters.AddWithValue("@birthdate", dtpDOB.Value)
                    .Parameters.AddWithValue("@birthplace", txtBirthplace.Text)
                    .Parameters.AddWithValue("@age", txtAge.Text)
                    .Parameters.AddWithValue("@civilstatus", cboCivilStatus.Text)
                    .Parameters.AddWithValue("@gender", cboGender.Text)
                    .Parameters.AddWithValue("@religion", cboReligion.Text)
                    .Parameters.AddWithValue("@email", txtEmail.Text)
                    .Parameters.AddWithValue("@contactno", txtContact.Text)
                    .Parameters.AddWithValue("@voters", cboVoters.Text)
                    .Parameters.AddWithValue("@precintno", txtPrecint.Text)
                    .Parameters.AddWithValue("@purok", cboPurok.Text)
                    .Parameters.AddWithValue("@education", txtEducation.Text)
                    .Parameters.AddWithValue("@occupation", txtOccupation.Text)
                    .Parameters.AddWithValue("@address", txtAddress.Text)
                    .Parameters.AddWithValue("@category", cboCategory.Text)
                    .Parameters.AddWithValue("@houseno", txtHouseNo.Text)
                    .Parameters.AddWithValue("@head", txtHeadofFamily.Text)
                    .Parameters.AddWithValue("@disability", cboPwd.Text)
                    .Parameters.AddWithValue("@status", cboStatus.Text)
                    ' If OpenFileDialog1.FileName <> "OpenFileDialog1" Then .Parameters.AddWithValue("@picture", arrImage)
                    .Parameters.AddWithValue("@id", txtID.Text)
                    .ExecuteNonQuery()
                    .Dispose()
                    If Not OpenFileDialog1.FileName Is Nothing Then
                        cmd = New MySqlCommand("SELECT resident_id FROM residents_pics WHERE resident_id=@rsidmain", cdb)
                        cmd.Parameters.AddWithValue("@rsidmain", txtID.Text.Trim)

                        Dim dtb As DataTable
                        dtb = New DataTable
                        dtb = retrieve_data_from_command(cmd)
                        cmd.Dispose()
                        If dtb.Rows.Count > 0 Then
                            cmd = New MySqlCommand("UPDATE residents_pics SET picture=@picimg WHERE resident_id=@rsid1", cdb)
                            cmd.Parameters.AddWithValue("@rsid1", txtID.Text.Trim)
                            cmd.Parameters.AddWithValue("@picimg", arrImage)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                        Else
                            cmd = New MySqlCommand("INSERT INTO residents_pics(resident_id,picture) VALUES(@rsid2,@picimg)", cdb)
                            cmd.Parameters.AddWithValue("@rsid2", txtID.Text.Trim)
                            cmd.Parameters.AddWithValue("@picimg", arrImage)
                            .ExecuteNonQuery()
                            .Dispose()
                        End If
                    End If


                End With
                condb_close(cdb)

                Dim fullname As String = txtLastname.Text & ", " & txtFirstname.Text & Space(2) & txtMidname.Text
                AuditTrail("Update Resident " & txtNID.Text & Space(2) & fullname, "Update Module")
                MsgBox("Record has been successfully updated!", vbInformation)
                Clear()
                frmResidentList.LoadResident()
                Me.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString, 48, "Error Message")
        End Try
    End Sub

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        'Dim datecheck As String
        'Dim today As System.DateTime = System.DateTime.Now
        'datecheck = dtpDOB.Text

        'Dim yearnow As Integer = today.Year
        'Dim yeardtp As Integer = dtpDOB.Value.Year
        'Dim rightyear As Integer = dtpDOB.Value.Year
        'Dim minimage As Integer = yeardtp - rightyear
        'Dim currentage As Integer = yearnow - yeardtp
        'txtAge.Text = currentage.ToString
        'Dim bdate As String = DateTime.Today

        Dim age As Integer = Today.Year - dtpDOB.Value.Year
        txtAge.Text = age.ToString

    End Sub

    Private Sub cboCivilStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCivilStatus.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboCivilStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCivilStatus.SelectedIndexChanged

    End Sub

    Private Sub cboGender_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboGender.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGender.SelectedIndexChanged

    End Sub

    Private Sub cboReligion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboReligion.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboReligion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReligion.SelectedIndexChanged

    End Sub

    Private Sub cboVoters_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboVoters.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboVoters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVoters.SelectedIndexChanged
        If cboVoters.Text = "YES" Then
            txtPrecint.Enabled = True
        Else
            txtPrecint.Enabled = False
        End If
    End Sub

    Private Sub cboPurok_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPurok.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboPurok_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPurok.SelectedIndexChanged

    End Sub

    Private Sub cboCategory_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCategory.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged

        If cboCategory.Text = "HEAD OF THE FAMILY" Then
            txtHouseNo.Enabled = True
            btnHouseNo.Visible = False
        Else
            txtHouseNo.Enabled = False
            btnHouseNo.Visible = True
        End If
    End Sub

    Private Sub cboHead_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub cboHead_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboPwd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPwd.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboPwd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPwd.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboStatus.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub btnHouseNo_Click(sender As Object, e As EventArgs) Handles btnHouseNo.Click
        frmHouseHold.ShowDialog()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub picResident_Click(sender As Object, e As EventArgs) Handles picResident.Click
        If Not picResident.BackgroundImage Is Nothing Then

            pboxlarge.Image = picResident.BackgroundImage

            pboxlarge.BringToFront()
            pboxlarge.Visible = True
            Linkpiclarge.BringToFront()
            Linkpiclarge.Visible = True
        Else
            Linkpiclarge.Visible = False
            pboxlarge.Image = Nothing
        End If
    End Sub
    Private _scale As New SizeF(1, 1)
    Private _scaleDelta As New SizeF(0.01, 0.01)
    Private Sub pboxlarge_MouseWheel(sender As Object, e As MouseEventArgs) Handles pboxlarge.MouseWheel
        _scale.Height = 1
        _scale.Width = 1

        If e.Delta < 0 Then
            _scale += _scaleDelta
        ElseIf e.Delta > 0 Then
            _scale -= _scaleDelta
        End If

        If e.Delta <> 0 Then _
        pboxlarge.Scale(_scale)
    End Sub

    Private Sub Linkpiclarge_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Linkpiclarge.LinkClicked
      
        pboxlarge.Visible = False
        pboxlarge.SendToBack()
        Linkpiclarge.Visible = False
        Linkpiclarge.SendToBack()
    End Sub

    Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContact.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And ("0123456789").IndexOf(e.KeyChar) = -1) Then  'Or (e.KeyChar = "." And Data.Text.ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtContact_TextChanged(sender As Object, e As EventArgs) Handles txtContact.TextChanged

    End Sub
End Class