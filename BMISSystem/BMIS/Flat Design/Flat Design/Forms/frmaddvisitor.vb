Imports System
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Linq
Imports System.Configuration
Imports System.Xml
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmaddvisitor
    Dim autos1 As New AutoCompleteStringCollection
    Dim autos2 As New AutoCompleteStringCollection
    Dim autos3 As New AutoCompleteStringCollection
    Dim autos4 As New AutoCompleteStringCollection
    Dim autos5 As New AutoCompleteStringCollection
    Dim autos6 As New AutoCompleteStringCollection
    Dim dtb As DataTable
    Dim ds1 As New DataSet1
    Dim tvhed1 As DataTable = ds1.Tables("tvhed")
    Dim tvdet1 As DataTable = ds1.Tables("tvdet")
    Dim passgenerated As Integer = 0
    Sub loadautosuggest(st As String, mytextbox As TextBox, myautosuggest As AutoCompleteStringCollection)
        Dim Sql As String = Nothing
        Dim mfield As String = "vi_trava"
        dtb = New DataTable
        condb()
        If st = 1 Then
            myautosuggest.Clear()
            Sql = "SELECT DISTINCT(" & mfield & ") FROM visitor_passes001"
        ElseIf st = 2 Then
            myautosuggest.Clear()
            mfield = "vi_apa"
            Sql = "SELECT DISTINCT(" & mfield & ") FROM visitor_passes001"
        ElseIf st = 3 Then
            myautosuggest.Clear()
            mfield = "vi_inc"
            Sql = "SELECT DISTINCT(" & mfield & ") FROM visitor_passes001"
        ElseIf st = 4 Then
            myautosuggest.Clear()
            mfield = "visnat"
            Sql = "SELECT DISTINCT(" & mfield & ") FROM vistab_001"
        ElseIf st = 5 Then
            myautosuggest.Clear()
            mfield = "viscpname"
            Sql = "SELECT DISTINCT(" & mfield & ") FROM vistab_001"
        ElseIf st = 6 Then
            myautosuggest.Clear()
            mfield = "visctno"
            Sql = "SELECT DISTINCT(" & mfield & ") FROM vistab_001"
        End If

        Using cmd As New MySqlCommand(Sql, cdb)
            dtb = retrieve_data_from_command(cmd)
            If dtb.Rows.Count > 0 Then
                For Each r As DataRow In dtb.Rows
                    myautosuggest.Add(r("" & mfield & "").ToString())
                Next
                mytextbox.AutoCompleteSource = AutoCompleteSource.CustomSource
                mytextbox.AutoCompleteCustomSource = myautosuggest
                mytextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End If
        End Using
        dtb = Nothing
        condb_close(cdb)
    End Sub

    Private Sub Form2_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        loadautosuggest(1, tb1, autos1)
        loadautosuggest(2, tb3, autos2)
        loadautosuggest(3, tb4, autos3)

    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadautosuggest(1, tb1, autos1)
        loadautosuggest(2, tb3, autos2)
        loadautosuggest(3, tb4, autos3)
    End Sub

    Private Sub Form2_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel1.Left = (Me.Width - Panel1.Width) / 2
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        tsprint.Enabled = False
        Me.Close()
        Me.Dispose()
        passgenerated = 0
        MainForm.btnDashboard.PerformClick()
    End Sub
    Private Sub save_qrcodeGen()
        Try
            'If Me.PictureBox1.Image IsNot Nothing Then
            '    Me.PictureBox1.Image.Save(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, Me.txtCode.Text & ".jpg"))
            '    MessageBox.Show("QR is successfully saved")
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub SaveQRCODE()
        Dim SD As New SaveFileDialog
        SD.FileName = "Visual Qr Code Generator"
        SD.Filter = "PNG Files Only(*.png)|*.png"
        If SD.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Try
                Dim savepath As String = dsktopath & SD.FileName
                ' pbQrCodeImg.Image.Save(SD.FileName, System.Drawing.Imaging.ImageFormat.Png)
                MsgBox("Image Has been Save", MsgBoxStyle.Information)
            Catch ex As Exception

            End Try

        End If
    End Sub
    Function generate_qrcode(vpcode As String)

        Dim sql As String = Nothing


        sql = "SELECT vispasscode FROM visitor_passes001 WHERE vispasscode=@vpc"
        cmd = New MySqlCommand(sql, cdb)
        cmd.Parameters.AddWithValue("@vpc", vpcode)
        cmd.ExecuteNonQuery()

        cmd.Dispose()
        Using cmd = New MySqlCommand("sql", cdb)
            cmd.Parameters.AddWithValue("@vpc", vpcode)
            dtb = New DataTable
            dtb = retrieve_data_from_command(cmd)
            If dtb.Rows.Count > 0 Then
                vpcode = GenerateRandomString(5) & gettime2(4)
                generate_qrcode(vpcode)
            Else
                Return vpcode
            End If
            cmd.Dispose()
            dtb = Nothing
        End Using
        Return True

    End Function
    Dim lastid As Integer = 0
    Dim qrcodedata As String = Nothing

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        With dgv1
            If dateisproper(dtp1.Value, dtp2.Value) Then
                MsgBox("Improper date, 'From date' must be less than the 'To date'", 48, "Improper Date")
                Exit Sub
            End If
            If dgv1.RowCount > 0 Then


                If checkifnotempty() Then


                    condb()


                    Dim d1 As String = Nothing
                    Dim d2 As String = Nothing
                    Dim d3 As String = Nothing
                    Dim d4 As String = Nothing


                    Dim d5 As String = Nothing
                    Dim d6 As Date
                    Dim d7 As Date
                    Dim d8 As Date



                    Dim cmd As MySqlCommand
                    Dim qrcode As String = Nothing
                    Dim sql As String = Nothing
                    Dim vpcode As String = Nothing


                    qrcode = GenerateRandomString(5) & gettime2(4)


                    d1 = qrcode
                    d2 = tb1.Text
                    d3 = tb2.Text
                    d4 = tb3.Text
                    d5 = tb4.Text

                    d6 = Format(dtp1.Value, "yyyy-MM-dd")
                    d7 = Format(dtp2.Value, "yyyy-MM-dd")
                    d8 = gettime2(3)


                    dtb = Nothing
                    vpcode = qrcode
                    dtb = New DataTable
                    dgv1.EndEdit(True)
                    sql = "SELECT vispasscode FROM visitor_passes001 WHERE vispasscode=@vpc"
                    cmd = New MySqlCommand(sql, cdb)
                    cmd.Parameters.AddWithValue("@vpc", vpcode)
                    cmd.ExecuteNonQuery()
                    dtb = retrieve_data_from_command(cmd)
                    cmd.Dispose()
                    If dtb.Rows.Count = 0 Then

                        sql = "INSERT INTO visitor_passes001(vispasscode,vi_trava,vi_noop,vi_apa,vi_inc,vi_chkin,vi_chkout,vi_date) " & _
                                           "VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
                        cmd = New MySqlCommand(sql, cdb)
                        cmd.Parameters.AddWithValue("@d1", d1)
                        cmd.Parameters.AddWithValue("@d2", d2)
                        cmd.Parameters.AddWithValue("@d3", d3)
                        cmd.Parameters.AddWithValue("@d4", d4)
                        cmd.Parameters.AddWithValue("@d5", d5)
                        cmd.Parameters.AddWithValue("@d6", d6)
                        cmd.Parameters.AddWithValue("@d7", d7)
                        cmd.Parameters.AddWithValue("@d8", d8)
                        '  cmd.ExecuteNonQuery()
                        cmd.ExecuteScalar()
                        lastid = CInt(cmd.LastInsertedId)
                        cmd.Dispose()

                        d1 = Nothing
                        d2 = Nothing
                        d3 = Nothing
                        d4 = Nothing

                        If .RowCount > 0 Then
                            d1 = lastid
                            qrcodedata = vpcode & vbNewLine
                            ''qrcodeGen(qrcodedata)
                            Dim x As Integer = 0
                            For i = 0 To .RowCount - 1

                                If .Item(0, i).Value.ToString.Trim <> Nothing Or .Item(0, i).Value <> "" Then
                                    d2 = .Item(0, i).Value.ToString.Trim
                                    d3 = .Item(1, i).Value.ToString.Trim
                                    d4 = .Item(2, i).Value.ToString.Trim
                                    sql = "INSERT INTO vistab_001(vispassid,viscpname,visctno,visnat) " & _
                                    "VALUES(@d1,@d2,@d3,@d4)"
                                    cmd = New MySqlCommand(sql, cdb)
                                    cmd.Parameters.AddWithValue("@d1", d1)
                                    cmd.Parameters.AddWithValue("@d2", d2)
                                    cmd.Parameters.AddWithValue("@d3", d3)
                                    cmd.Parameters.AddWithValue("@d4", d4)
                                    cmd.ExecuteNonQuery()
                                    cmd.Dispose()
                                End If
                                If x > 0 Then
                                    qrcodedata &= vbNewLine & d2
                                Else
                                    qrcodedata &= d2
                                End If
                                x += 1

                            Next
                        End If



                        ' print_voucher(lastid, 1, qrcodedata)
                        tsprint.Enabled = True
                        passgenerated = 1
                        clear_fields()
                        ' MsgBox(qrcodedata)
                        loadautosuggest(1, tb1, autos1)
                        loadautosuggest(2, tb3, autos2)
                        loadautosuggest(3, tb4, autos3)

                    End If



                    condb_close(cdb)
                Else
                    MsgBox("Please input visitor/s before saving", 48, "No visitor entry FOUND!")
                End If
            End If
        End With
    End Sub
    Function print_voucher(lastid As String, tvid As String, qdata As String)
        With dgv1

            tvhed1.Rows.Clear()
            tvdet1.Rows.Clear()

            Dim dtb1 As New DataTable
            Dim dtb2 As New DataTable
            '  Dim prep As New ReportDocument
            Dim chkflag As Boolean = False

            Dim cntr As Integer = 0
            Dim grid As Integer = 1
            Dim mmax As Integer = 0

            tvhed1.Rows.Clear()
            tvdet1.Rows.Clear()
            Dim grpno As Integer = 0
            grpno = 10


            pbar1.Visible = True
            pbar1.Value = 0

            Dim Sqly As String = Nothing
            Dim hloG
            Dim nsiG
            Dim qdaT
            Dim deT1 As String = Nothing
            Dim deT2 As String = Nothing
            Dim notE As String = Nothing
            Dim notB As String = Nothing
            qdaT = qrcodeGen(qdata)
            condb()
            Sqly = "SELECT * FROM travel_agency_detail001 WHERE travid=@tv"
            Using cmd As New MySqlCommand(Sqly, cdb)
                cmd.Parameters.AddWithValue("@tv", tvid)
                cmd.ExecuteNonQuery()
                dtb1 = retrieve_data_from_command(cmd)
                If dtb1.Rows.Count > 0 Then
                    For Each r As DataRow In dtb1.Rows
                        hloG = r("headerlogo")
                        nsiG = r("notedbysig")
                        deT1 = r("detail1").ToString
                        deT2 = r("detail2").ToString
                        notE = r("note").ToString
                        notB = r("notedBy").ToString
                    Next
                End If
            End Using
            dtb1 = Nothing


            Sqly = "SELECT * FROM visitor_passes001 WHERE vispassid=@vid"
            Using cmd As New MySqlCommand(Sqly, cdb)
                cmd.Parameters.AddWithValue("@vid", lastid)
                cmd.ExecuteNonQuery()
                dtb2 = retrieve_data_from_command(cmd)

                mmax = dtb2.Rows.Count
                pbar1.Maximum = dtb2.Rows.Count
                If dtb2.Rows.Count > 0 Then
                    For Each r As DataRow In dtb2.Rows
                        r1 = tvhed1.NewRow()

                        r1("travheaderimg") = hloG
                        r1("travnotsig") = nsiG
                        r1("travdet1") = deT1
                        r1("travdet2") = deT2
                        r1("travnote") = notE
                        r1("travnotb") = notB

                        Dim mylogo As System.Drawing.Image
                        Dim bmp As Bitmap = qdaT
                        mylogo = System.Drawing.Image.FromFile(Application.StartupPath + "/qimages/handumlogoheader.bmp")

                        Dim left As Integer = (qdaT.Width / 2) - (mylogo.Width / 8)
                        Dim top As Integer = (qdaT.Height / 2) - (mylogo.Height / 8)
                        Dim g As Graphics = Graphics.FromImage(qdaT)
                        g.DrawImage(mylogo, New Point(left + 8, top + 8))
                        ' bmp.Save(Application.StartupPath + "/qimages/img.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        Dim tmpstream As MemoryStream = New MemoryStream()
                        bmp.Save(tmpstream, System.Drawing.Imaging.ImageFormat.Jpeg)


                        r1("travqr") = tmpstream.ToArray() 'imgToByteConverter(qDat)
                        r1("travqrcod") = r("vispasscode").ToString
                        r1("vpassid") = lastid
                        r1("vinc") = r("vi_inc").ToString
                        r1("trava") = r("vi_trava").ToString
                        r1("travapa") = r("vi_apa").ToString
                        r1("nop") = r("vi_noop").ToString
                        r1("ckin") = r("vi_chkin").ToString
                        r1("cko") = r("vi_chkout").ToString
                        r1("travdencod") = r("vi_date").ToString


                        Dim Sqly2 As String = Nothing
                        Sqly2 = "SELECT viscpname,visctno,visnat FROM vistab_001 WHERE vispassid=@vid2"
                        Using cmd2 As New MySqlCommand(Sqly2, cdb)
                            cmd2.Parameters.AddWithValue("@vid2", lastid)
                            cmd2.ExecuteNonQuery()
                            dtb1 = retrieve_data_from_command(cmd2)
                            For Each r3 As DataRow In dtb1.Rows
                                cntr += 1
                                r2 = tvdet1.NewRow()
                                r2("vpassid") = lastid
                                r2("vs_names") = r3("viscpname").ToString
                                r2("vs_ctno") = r3("visctno").ToString
                                r2("vs_nat") = r3("visnat").ToString
                                r2("grpno") = grid

                                If cntr = grpno Then
                                    grid += 1
                                    cntr = 0
                                End If
                                tvdet1.Rows.Add(r2)
                            Next

                        End Using

                        pbar1.Refresh()
                        pbar1.Value += 1
                        tvhed1.Rows.Add(r1)
                    Next
                End If

            End Using
            condb_close(cdb)


            'r1("sdate") = sDate.Value.ToString("MM/dd/yyyy")






            dtb1 = Nothing
            dtb2 = Nothing
            'pbar1.Visible = False
            '  prep = New Tourvoucher
            '  prep.SetDataSource(ds1)
            'frmreport.crvw1.ReportSource = prep
            'frmreport.crvw1.Refresh()
            frmreport.Dock = DockStyle.Fill
            frmreport.ShowDialog()
            pbar1.Visible = False
        End With

        Return True
    End Function
    Function checkifnotempty()

        With dgv1
            Dim x As Integer = 0
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    If .Item(0, i).Value = Nothing Then
                        x = 1
                    End If
                Next
            End If

            If x = 1 Then
                Return False
            Else
                Return True
            End If
        End With

    End Function
    Function dateisproper(d1 As Date, d2 As Date)
        If CDate(d1) > CDate(d2) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub tsssadd_Click(sender As Object, e As EventArgs) Handles tsssadd.Click
        tsprint.Enabled = False
        clear_fields()
        loadautosuggest(1, tb1, autos1)
        loadautosuggest(2, tb3, autos2)
        loadautosuggest(3, tb4, autos3)
    End Sub

    Sub clear_fields()
        tb1.Clear()
        tb2.Clear()
        tb3.Clear()
        tb4.Clear()
        With dgv1
            .Rows.Clear()

        End With
        tb1.Focus()
    End Sub
    Public curcol, currow As Integer
    Private Sub tb2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb2.KeyPress
        If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or Asc(e.KeyChar) = 49 Or Asc(e.KeyChar) = 48 Or e.KeyChar = ChrW(Keys.Back)) Then e.Handled = True
    End Sub

    Private Sub dgv1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellEndEdit
        With dgv1
            Try
                If .RowCount > 0 Then
                    curcol = .CurrentCell.ColumnIndex
                    currow = .CurrentCell.RowIndex


                    Dim iCol = .CurrentCell.ColumnIndex
                    Dim iRow = .CurrentCell.RowIndex
                    If iCol = .Columns.Count - 1 Then
                        If iRow < .Rows.Count - 1 Then
                            .CurrentCell = dgv1(0, iRow + 1)
                        End If
                    Else
                        If iRow < .Rows.Count - 1 Then
                            SendKeys.Send("{up}")
                        End If
                        .CurrentCell = dgv1(iCol + 1, iRow)
                    End If
                End If
            Catch ex As Exception

            End Try
         
        End With
    End Sub
   
    Private Sub dgv1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgv1.EditingControlShowing
        With dgv1

            If .CurrentCell.ColumnIndex = 0 Then
                Dim titleText As String = .Columns(0).Name
                If titleText.Equals("gname") Then
                    Dim autoText As TextBox = TryCast(e.Control, TextBox)
                    If autoText IsNot Nothing Then
                        loadautosuggest(5, autoText, autos5)
                    End If
                End If
                DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            ElseIf .CurrentCell.ColumnIndex = 1 Then
                Dim titleText As String = .Columns(1).Name
                If titleText.Equals("cno") Then
                    Dim autoText As TextBox = TryCast(e.Control, TextBox)
                    If autoText IsNot Nothing Then
                        loadautosuggest(6, autoText, autos6)
                    End If
                End If
                DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            ElseIf .CurrentCell.ColumnIndex = 2 Then
                Dim titleText As String = .Columns(2).Name
                If titleText.Equals("nationalt") Then
                    Dim autoText As TextBox = TryCast(e.Control, TextBox)
                    If autoText IsNot Nothing Then
                        loadautosuggest(4, autoText, autos4)
                    End If
                End If
                DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            End If

        End With
    End Sub

    Private Sub tb2_Leave(sender As Object, e As EventArgs) Handles tb2.Leave
        'If tb2.Text <> Nothing And tb1.Text <> Nothing Then

        '    With dgv1
        '        If .RowCount > 0 Then
        '            Dim cntrow As Integer = 0
        '            cntrow = Decimal.Parse(tb2.Text)
        '            Dim addrow As Integer = 0
        '            If cntrow > .RowCount Then

        '                addrow = cntrow - .RowCount
        '                Dim j As Integer = 0
        '                For j = 0 To addrow
        '                    .RowCount += 1
        '                Next
        '            ElseIf cntrow = .RowCount Then
        '            Else

        '                addrow = .RowCount - cntrow
        '                Dim j As Integer = 0
        '                For j = 0 To addrow
        '                    .RowCount -= 1
        '                Next
        '            End If
        '        Else
        '            Dim j As Integer = 0
        '            For j = 0 To tb2.Text
        '                .RowCount += 1
        '            Next
        '            .RowCount -= 1
        '        End If

        '    End With
        'Else
        '    '  MsgBox("Please input all needed information", 48, "Incomplete entry")
        'End If
    End Sub

    Private Sub tb2_LostFocus(sender As Object, e As EventArgs) Handles tb2.LostFocus
        If tb2.Text <> Nothing And tb1.Text <> Nothing Then

            With dgv1
                If .RowCount > 0 Then
                    Dim cntrow As Integer = 0
                    cntrow = Decimal.Parse(tb2.Text)
                    Dim addrow As Integer = 0
                    If cntrow > .RowCount Then

                        addrow = cntrow - .RowCount
                        Dim j As Integer = 0
                        For j = 0 To addrow
                            .RowCount += 1
                        Next
                        .RowCount -= 1
                    ElseIf cntrow = .RowCount Then
                    Else

                        addrow = .RowCount - cntrow
                        Dim j As Integer = 0
                        For j = 1 To addrow
                            .RowCount -= 1
                        Next
                    End If

                Else
                    Dim j As Integer = 0
                    For j = 0 To tb2.Text
                        .RowCount += 1
                    Next
                    .RowCount -= 1
                End If

            End With
        Else
            '  MsgBox("Please input all needed information", 48, "Incomplete entry")
        End If
    End Sub

    Private Sub tb2_MouseLeave(sender As Object, e As EventArgs) Handles tb2.MouseLeave

    End Sub

    Private Sub tb2_TextChanged(sender As Object, e As EventArgs) Handles tb2.TextChanged

    End Sub

    Private Sub tsref_Click(sender As Object, e As EventArgs) Handles tsref.Click
        tsprint.Enabled = False
        loadautosuggest(1, tb1, autos1)
        loadautosuggest(2, tb3, autos2)
        loadautosuggest(3, tb4, autos3)
        print_voucher(27, 1, "H187b2330")
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub

    Private Sub dgv1_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv1.KeyDown
        With dgv1
            If .RowCount > 0 Then
               If e.KeyCode = Keys.Enter Then
                    e.SuppressKeyPress = True
                    SendKeys.Send(Chr(Keys.Tab))
                End If
            End If
        End With

    End Sub

    Private Sub dgv1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv1.CurrentCellChanged
        With dgv1
            If .RowCount > 0 Then
                Try
                    curcol = .CurrentCell.ColumnIndex
                    currow = .CurrentCell.RowIndex
                Catch ex As Exception
                    curcol = 0
                    currow = 0
                End Try
            End If
        End With

    End Sub

    Private Sub tsprint_Click(sender As Object, e As EventArgs) Handles tsprint.Click
        If passgenerated = 1 Then
            print_voucher(lastid, 1, qrcodedata)
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class