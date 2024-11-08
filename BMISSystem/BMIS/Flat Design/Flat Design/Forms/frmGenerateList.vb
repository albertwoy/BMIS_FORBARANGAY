
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.DataGridViewColumnCollection

Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Public Class frmGenerateList
    Dim loaded As Integer = 0
    Dim localdtb As DataTable
    Dim localdtb2 As DataTable
    Dim localdtb3 As DataTable
    Dim curdb As String = Nothing
    Dim selectedgrid As DataGridView

    Private Sub frmGenerateList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        localdtb.Dispose()
        localdtb3.Dispose()
    End Sub
    Private Sub frmGenerateList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadsems()
    End Sub

    Sub loadsems()
        condb()
        cbosems.Items.Clear()
        cbosems.DisplayMember = "text"

        localdtb = New DataTable

        cbosems.Text = Nothing
        Dim sql2 As String

        sql2 = "Select SEMEYR,SMYEAR FROM master.semester WHERE RIGHT(SMYEAR,4) >=2023 ORDER BY semno desc"
        cm = New MySqlCommand(sql2, cdb)
        localdtb = retrieve_data_from_command(cm)
        Dim addrw As DataRow
        addrw = localdtb.NewRow
        addrw("SEMEYR") = "--"
        addrw("SMYEAR") = ""
        localdtb.Rows.InsertAt(addrw, 0)

        With cbosems
            .DisplayMember = "SEMEYR"
            .ValueMember = "SMYEAR"
            .DataSource = localdtb.DefaultView
        End With
        cm.Dispose()
        localdtb.Dispose()
        condb_close(cdb)

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        '  MainForm.Label1.Text = "Main"
        If frmloading.Visible = True Then
            frmloading.Dispose()
        End If
        Me.Dispose()
    End Sub
    Dim activetab As String = Nothing
    Sub loadforsubmission(ByVal smyr As String, ByVal st As Integer)
        If smyr <> Nothing Then

            localdtb = New DataTable
            Dim mytabacc As String = Nothing
            Dim myenrtab As String = Nothing
            Dim mysems As String = Nothing
            Dim myyr As String = Nothing


            Dim rx As Integer = 0

            frmloading.pgloading.Refresh()
            curdb = "mu" & smyr
            mytabacc = "mu" & smyr & ".acc" & smyr
            myenrtab = "mu" & smyr & ".enr" & smyr
            mysems = Strings.Left(smyr, 1)
            myyr = Strings.Right(smyr, 4)
            activetab = "mu1" & myyr
            condb()

            cm = New MySqlCommand("SELECT edp_no IDNO FROM " & activetab & ".for_insurance", cdb)
            localdtb2 = retrieve_data_from_command(cm)
            cm.Dispose()

            cm = New MySqlCommand("SELECT c.LASTNAME,c.FIRSTNAME,c.MIDDLEI,a.EDP_NO IDNO,c.B_DATE BIRTHDATE,CONCAT(a.COURSE,'-',a.`YEAR`) `COURSE-YEAR`,c.SEXCODE GENDER,a.OLDNEW STATUS FROM " & mytabacc & " a LEFT JOIN  master.mastfile c ON a.EDP_NO=c.EDP_NO  WHERE a.OLDNEW <> 'W' ORDER BY a.COURSE,a.`YEAR`, c.LASTNAME,c.FIRSTNAME", cdb)
            localdtb = retrieve_data_from_command(cm)
            cm.Dispose()
            With dgvlist1
                If localdtb2.Rows.Count > 0 Then

                    Dim common = (From r1 In localdtb.AsEnumerable()
                        Join r2 In localdtb2.AsEnumerable() On r1("IDNO") Equals r2("IDNO")
                        Select r1).ToList()
                    For Each r In common
                        localdtb.Rows.Remove(r)
                    Next
                    localdtb.AcceptChanges()
                End If

                If localdtb.Rows.Count > 0 Then

                    frmloading.pgloading.Refresh()
                    .DataSource = Nothing

                    renum(localdtb)

                    .DataSource = localdtb
                    .Columns(0).Width = 50
                    .Columns(1).Width = 250
                    .Columns(2).Width = 150
                    .Columns(5).Width = 110



                End If

            End With
            localdtb2.Dispose()


            condb_close(cdb)

        End If
    End Sub
    Sub loadsubmitted(ByVal smyr As String, ByVal st As Integer)
        If smyr <> Nothing Then

            localdtb3 = New DataTable
    
            Dim myyr As String = Nothing


            Dim rx As Integer = 0
           

            frmloading.pgloading.Refresh()
            curdb = "mu" & smyr
   
            myyr = Strings.Right(smyr, 4)
            activetab = "mu1" & myyr
            condb()


            cm = New MySqlCommand("SELECT sqno ExSeqno,s_Lname LASTNAME,s_Fname FIRSTNAME,s_Middle MIDDLENAME,edp_no IDNO,s_bdate BIRTHDATE,s_corsyer `COURSE-YEAR`,s_gender GENDER, s_status OLDNEWSTATUS,smyr SEMENROLLED,recid FROM " & activetab & ".for_insurance ", cdb)
            localdtb3 = retrieve_data_from_command(cm)
            cm.Dispose()
            With dgvlist2


                If localdtb3.Rows.Count > 0 Then

                    frmloading.pgloading.Refresh()
                    .DataSource = Nothing

                    renum(localdtb3)

                    .DataSource = localdtb3
                    Dim colType As String = .Columns(0).GetType.ToString
                    If colType <> "System.Windows.Forms.DataGridViewCheckBoxColumn" Then
                        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                        checkBoxColumn.HeaderText = ""
                        checkBoxColumn.Width = 30
                        checkBoxColumn.Name = "checkBoxColumn"
                        .Columns.Insert(0, checkBoxColumn)
                    End If
                  
                    .Columns(1).Width = 70
                    .Columns(2).Width = 75
                    .Columns(3).Width = 250
                    .Columns(4).Width = 150
                    .Columns(5).Width = 110
                    '  .Columns(12).Visible = False
                    .Columns(12).Visible = False
                End If
                For i = 1 To .Columns.Count - 1
                    .Columns(i).ReadOnly = True
                Next
            End With

            condb_close(cdb)


        End If
    End Sub
    Sub startexport2()
        btnexportdata.Enabled = False

        ' With dgvlist
        frmloading.Show(Me)
        MainForm.stst2.Visible = True
        MainForm.pgbar1.Visible = True
        MainForm.pgbar1.Maximum = dgvlist1.RowCount
        MainForm.pgbar1.Value = 0
        frmloading.pgloading.Refresh()
        System.Windows.Forms.Application.DoEvents()
       
        frmloading.Label6.Text = "Saving data please wait..."
        frmloading.Label6.Refresh()
        Dim myreportname As String = Nothing

        Dim r As Integer = 0


        Dim edpn As String = Nothing
        Dim smyr As String = Nothing
        Dim slname As String = Nothing
        Dim sfname As String = Nothing
        Dim mname As String = Nothing
        Dim sbdet As String = Nothing
        Dim scorsy As String = Nothing
        Dim syer As String = Nothing
        Dim sgen As String = Nothing
        Dim sstat As String = Nothing
        Dim sqno As Integer = 0
        smyr = cbosems.SelectedValue
        condb()
        If allowinsert = 1 Then
            For i = 0 To dgvlist1.RowCount - 1
                edpn = Nothing

                slname = Nothing
                sfname = Nothing
                mname = Nothing
                sbdet = Nothing
                scorsy = Nothing
                syer = Nothing
                sgen = Nothing
                sstat = Nothing
                sqno = 0

                sqno = dgvlist1.Item(0, i).Value
                slname = dgvlist1.Item(1, i).Value
                sfname = dgvlist1.Item(2, i).Value
                mname = dgvlist1.Item(3, i).Value
                edpn = dgvlist1.Item(4, i).Value
                If dgvlist1.Item(5, i).Value.ToString <> Nothing Then
                    sbdet = dgvlist1.Item(5, i).Value.ToString
                End If

                scorsy = dgvlist1.Item(6, i).Value
                '  syer = dgvlist1.Item(7, i).Value
                sgen = dgvlist1.Item(7, i).Value
                sstat = dgvlist1.Item(8, i).Value
                frmloading.pgloading.Refresh()

                If edpn <> Nothing Then

                    If curdb <> activetab Then

                        cm = New MySqlCommand("SELECT edp_no FROM " & curdb & ".for_insurance WHERE edp_no=@idn", cdb)
                        cm.Parameters.AddWithValue("@idn", edpn)
                        localdtb2 = retrieve_data_from_command(cm)
                        cm.Dispose()
                        If localdtb2.Rows.Count = 0 Then
                            cm = New MySqlCommand("INSERT INTO " & curdb & ".for_insurance(sqno,edp_no,s_Lname,s_Fname,s_Middle,s_bdate,s_corsyer,s_gender,s_status,smyr) VALUES(@sqn,@f1,@f2,@f3,@f4,@f5,@f6,@f8,@f9,@f10)", cdb)
                            cm.Parameters.AddWithValue("@sqn", sqno)
                            cm.Parameters.AddWithValue("@f1", edpn)
                            cm.Parameters.AddWithValue("@f2", slname)
                            cm.Parameters.AddWithValue("@f3", sfname)
                            cm.Parameters.AddWithValue("@f4", mname)
                            cm.Parameters.AddWithValue("@f5", sbdet)
                            cm.Parameters.AddWithValue("@f6", scorsy)
                            cm.Parameters.AddWithValue("@f8", sgen)
                            cm.Parameters.AddWithValue("@f9", sstat)
                            cm.Parameters.AddWithValue("@f10", smyr)
                            cm.ExecuteNonQuery()
                            cm.Dispose()

                        End If
                        localdtb2.Dispose()
                    End If


                    cm = New MySqlCommand("SELECT edp_no FROM " & activetab & ".for_insurance WHERE edp_no=@idn", cdb)
                    cm.Parameters.AddWithValue("@idn", edpn)
                    localdtb2 = retrieve_data_from_command(cm)
                    cm.Dispose()
                    If localdtb2.Rows.Count = 0 Then
                        cm = New MySqlCommand("INSERT INTO " & activetab & ".for_insurance(sqno,edp_no,s_Lname,s_Fname,s_Middle,s_bdate,s_corsyer,s_gender,s_status,smyr) VALUES(@sqn,@f1,@f2,@f3,@f4,@f5,@f6,@f8,@f9,@f10)", cdb)
                        cm.Parameters.AddWithValue("@sqn", sqno)
                        cm.Parameters.AddWithValue("@f1", edpn)
                        cm.Parameters.AddWithValue("@f2", slname)
                        cm.Parameters.AddWithValue("@f3", sfname)
                        cm.Parameters.AddWithValue("@f4", mname)
                        cm.Parameters.AddWithValue("@f5", sbdet)
                        cm.Parameters.AddWithValue("@f6", scorsy)
                        cm.Parameters.AddWithValue("@f8", sgen)
                        cm.Parameters.AddWithValue("@f9", sstat)
                        cm.Parameters.AddWithValue("@f10", smyr)
                        cm.ExecuteNonQuery()
                        cm.Dispose()

                    End If
                    localdtb2.Dispose()

                End If
                MainForm.pgbar1.Value += 1

            Next
        End If
        condb_close(cdb)
        loadsubmitted(smyr, 0)

        MainForm.stst2.Visible = False
        MainForm.pgbar1.Visible = False
        MainForm.pgbar1.Value = 0

        frmloading.Label6.Text = "Exporting data to excel..."
        frmloading.Label6.Refresh()
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        System.Windows.Forms.Application.DoEvents()
        frmloading.pgloading.Refresh()

        With xlApp
            Dim filename As String = Nothing

            .SheetsInNewWorkbook = 1
            .Workbooks.Add()
            .Worksheets(1).Select()
            .Worksheets(1).Range("B:Z").NumberFormat = "@"
            .Worksheets(1).Cells(1, 1).EntireRow.Font.Bold = True
            myreportname = "/ForSubmissionInsurance" & gettime(4) & ".xlsx"

            Dim cl As Integer = 0
            Dim exStart As Integer = 2
            Dim exStart2 As Integer = 0
           
            For i = 0 To dgvlist1.RowCount - 1
                frmloading.pgloading.Refresh()
                cl = 0
                exStart2 = 1

                For j = 0 To dgvlist1.ColumnCount - 1
                    If j <= dgvlist1.ColumnCount - 1 Then
                        cl += 1
                        If .Cells(1, cl).Value = "" Then
                            .Cells(1, cl) = dgvlist1.Columns(j).HeaderCell.Value
                        End If
                        exStart2 += 1
                        'If j = 5 Then
                        '    Dim bdate As String
                        '    bdate = dgvlist1.Rows(i).Cells(j).Value.ToString()
                        'End If
                        If Not IsDBNull(dgvlist1.Rows(i).Cells(j).Value) Then
                            '  MsgBox(.Rows(i).Cells(j).Value)
                            If dgvlist1.Rows(i).Cells(j).Value.ToString <> Nothing Then
                                Dim myval As String
                                myval = dgvlist1.Rows(i).Cells(j).Value.ToString

                                .Cells(exStart, cl).value = CStr(myval.ToString)
                            End If

                        End If

                    End If

                Next
               
                System.Windows.Forms.Application.DoEvents()
                dgvlist1.CurrentCell = dgvlist1.Rows(i).Cells(1)

                exStart += 1
            Next

            .Cells.WrapText = False

           


            frmloading.Label6.Text = "Opening exported files..."
            frmloading.pgloading.Refresh()
            filename = dsktopath & myreportname
            xlApp.DisplayAlerts = False
            .Worksheets(1).Rows.Item(1).EntireColumn.AutoFit()
            .ActiveCell.Worksheet.SaveAs(filename)
            xlApp.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
            ReleaseObject(xlApp)
            Process.Start(filename)
         
            ' xlWorkBook.SaveAs(newpath)
            '  xlWorkBook.Close(True, misValue, misValue)


            ' ReleaseObject(wSheet)

            btnexportdata.Enabled = True
            loadsubmitted(smyr, 0)
            frmloading.Dispose()
        End With


    End Sub
    Sub startexport3()

        btnexportdata.Enabled = False

        ' With dgvlist
        frmloading.Show(Me)
        MainForm.stst2.Visible = True
        MainForm.pgbar1.Visible = True
        MainForm.pgbar1.Maximum = dgvlist2.RowCount
        MainForm.pgbar1.Value = 0
        frmloading.pgloading.Refresh()
        System.Windows.Forms.Application.DoEvents()

        frmloading.Label6.Text = "Saving data please wait..."
        frmloading.Label6.Refresh()
        Dim myreportname As String = Nothing

   
        condb()


        MainForm.stst2.Visible = False
        MainForm.pgbar1.Visible = False
        MainForm.pgbar1.Value = 0

        frmloading.Label6.Text = "Exporting data to excel..."
        frmloading.Label6.Refresh()
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        System.Windows.Forms.Application.DoEvents()
        frmloading.pgloading.Refresh()
        With xlApp
            Dim filename As String = Nothing
            .SheetsInNewWorkbook = 1
            .Workbooks.Add()
            .Worksheets(1).Select()
            .Worksheets(1).Range("B:Z").NumberFormat = "@"
            myreportname = "/SubmittedListforInsurance" & gettime(4) & ".xlsx"

            Dim cl As Integer = 0
            Dim exStart As Integer = 2
            Dim exStart2 As Integer = 0

            For i = 0 To dgvlist2.RowCount - 1
                frmloading.pgloading.Refresh()
                cl = 0
                exStart2 = 1

                For j = 1 To dgvlist2.ColumnCount - 1
                    If j <= dgvlist2.ColumnCount - 1 Then
                        cl += 1
                        If .Cells(1, cl).Value = "" Then
                            .Cells(1, cl) = dgvlist2.Columns(j).HeaderCell.Value
                        End If
                        exStart2 += 1
                        If Not IsDBNull(dgvlist2.Rows(i).Cells(j).Value) Then
                            '  MsgBox(.Rows(i).Cells(j).Value)
                            If dgvlist2.Rows(i).Cells(j).Value <> Nothing Then
                                Dim myval As String
                                myval = dgvlist2.Rows(i).Cells(j).Value
                                .Cells(exStart, cl).value = CStr(myval.ToString)
                            End If

                        End If

                    End If

                Next

                System.Windows.Forms.Application.DoEvents()
                dgvlist2.CurrentCell = dgvlist2.Rows(i).Cells(1)

                exStart += 1
            Next

            .Cells.WrapText = False




            frmloading.Label6.Text = "Opening exported files..."
            frmloading.pgloading.Refresh()
            filename = dsktopath & myreportname
            xlApp.DisplayAlerts = False
            .Worksheets(1).Rows.Item(1).EntireColumn.AutoFit()
            .ActiveCell.Worksheet.SaveAs(filename)
            xlApp.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
            ReleaseObject(xlApp)
            Process.Start(filename)

           
            btnexportdata.Enabled = True
            frmloading.Dispose()
        End With
    End Sub
    Sub startexportdtb()
        With dgvlist1
            If .RowCount > 0 Then
                frmloading.Show()
                ' Dim xlApp As Excel.Application
                'Dim xc = System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
                Dim xlApp As New Microsoft.Office.Interop.Excel.Application
             
                With xlApp
                    Dim filename As String = Nothing
                    .SheetsInNewWorkbook = 1
                    .Workbooks.Add()
                    .Worksheets(1).Select()

                    Dim i As Integer = 1
                    For col = 0 To localdtb.Columns.Count - 1
                        .Cells(1, i).value = localdtb.Columns(col).ColumnName
                        .Cells(1, i).EntireRow.Font.Bold = True
                        i += 1
                    Next

                    i = 2

                    Dim k As Integer = 1
                    For col = 0 To localdtb.Columns.Count - 1
                        i = 2
                        For row = 0 To localdtb.Rows.Count - 1
                            .Cells(i, k).Value = localdtb.Rows(row).ItemArray(col)
                            '  dgvlist1.CurrentCell = dgvlist1.Item(col, row)
                            i += 1
                        Next

                        frmloading.pgloading.Refresh()
                        k += 1
                    Next

                    frmloading.Label6.Text = "Opening exported files..."
                    frmloading.pgloading.Refresh()
                    filename = dsktopath & "\File_Exported.xls"
                    .ActiveCell.Worksheet.SaveAs(filename)
                    Process.Start(filename)
                    ' xlWorkBook.SaveAs(newpath)
                    '  xlWorkBook.Close(True, misValue, misValue)
                    xlApp.Quit()

                    frmloading.Label6.Text = "This may take several minutes..."

                    frmloading.Dispose()
                End With
            End If
        End With
    End Sub
    Private Sub ForSubmissionListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForSubmissionListToolStripMenuItem.Click
        If dgvlist1.RowCount > 0 Then
            tbsearch.Enabled = False
            cbosems.Enabled = False
            Dim dt As Date
            condb()
            dt = gettime2(3)
            savetrails(_userid, "Exported List of Students for Submission" & "--" & _user, dt)
            condb_close(cdb)
            startexport2()

            tbsearch.Enabled = True
            cbosems.Enabled = True
        End If
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
    

 
    Private Sub tbsearch_TextChanged(sender As Object, e As EventArgs) Handles tbsearch.TextChanged
        If tbsearch.Text <> Nothing And cbosems.Text <> Nothing And loaded = 1 Then
            If localdtb.Rows.Count > 0 Then
                Dim srchstr As String = Nothing
                srchstr = tbsearch.Text.Trim

               
                'renum()
                If chksub.Checked = True Then
                    Dim dv As DataView = New DataView(localdtb3)
                    dv.RowFilter = String.Format("IDNO LIKE '%{0}%' or LASTNAME + FIRSTNAME LIKE '%{0}%'", srchstr)
                    ' dv.RowFilter = String.Format("IDNO + LASTNAME + FIRSTNAME LIKE '%{0}%'", srchstr)
                    dgvlist2.DataSource = dv
                    Dim a As Integer = 1
                    For i = 0 To dgvlist2.RowCount - 1
                        dgvlist2.Item(1, i).Value = a
                        a += 1
                    Next
                Else
                    Dim dv As DataView = New DataView(localdtb)
                    dv.RowFilter = String.Format("IDNO LIKE '%{0}%' or LASTNAME + FIRSTNAME LIKE '%{0}%'", srchstr)
                    ' dv.RowFilter = String.Format("IDNO + LASTNAME + FIRSTNAME LIKE '%{0}%'", srchstr)
                    dgvlist1.DataSource = dv
                    Dim a As Integer = 1
                    For i = 0 To dgvlist1.RowCount - 1
                        dgvlist1.Item(0, i).Value = a
                        a += 1
                    Next
                End If
               
            End If
        ElseIf tbsearch.Text = Nothing Then
            If chksub.Checked = True Then
                loadsubmitted(cbosems.SelectedValue, 1)
            Else
                loadforsubmission(cbosems.SelectedValue, 1)
            End If

        End If
    End Sub
    Dim allowinsert As Integer = 0


    Private Sub cbosems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosems.SelectedIndexChanged
        If cbosems.Text <> Nothing And cbosems.SelectedValue <> "" Then


            localdtb2 = New DataTable
            Dim mydb As String = Nothing
            Dim mytb As String = Nothing
            Dim sql As String = Nothing

            mydb = "mu" & cbosems.SelectedValue
            mytb = "for_insurance"

            condb()

            sql = "SELECT table_name FROM information_schema.tables WHERE table_schema =@db AND table_name = @tb"
            cm = New MySqlCommand(sql, cdb)
            cm.Parameters.AddWithValue("@db", mydb)
            cm.Parameters.AddWithValue("@tb", mytb)
            localdtb2 = retrieve_data_from_command(cm)
            cm.Dispose()

            If localdtb2.Rows.Count > 0 Then
                allowinsert = 1
            Else

                sql = "CREATE TABLE IF NOT EXISTS " & mydb & ".for_insurance LIKE pro.for_insurance; "
                cm = New MySqlCommand(sql, cdb)
                cm.ExecuteNonQuery()
                allowinsert = 1
            End If
            condb_close(cdb)
            localdtb2.Dispose()
            frmloading.Show(Me)
            loadforsubmission(cbosems.SelectedValue, 0)
            loadsubmitted(cbosems.SelectedValue, 0)

            frmloading.Dispose()
            loaded = 1

            Dim dt As Date
            condb()
            dt = gettime2(3)
            savetrails(_userid, "Viewed list of students for insurance" & "--" & _user, dt)
            condb_close(cdb)

        End If
    End Sub


    Private Sub SubmittedListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmittedListToolStripMenuItem.Click
        If dgvlist2.RowCount > 0 Then
            tbsearch.Enabled = False
            cbosems.Enabled = False
            Dim dt As Date
            condb()
            dt = gettime2(3)
            savetrails(_userid, "Exported Student Submitted List " & "--" & _user, dt)
            condb_close(cdb)
            startexport3()

            tbsearch.Enabled = True
            cbosems.Enabled = True
        End If
      
    End Sub
    Dim selrow As Integer = -1
   
    Private Sub dgvlist2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlist2.CellClick
        With dgvlist2
            If .RowCount > 0 Then

            End If
        End With

    End Sub


    Private Sub dgvlist2_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvlist2.KeyDown
        With dgvlist2
            If .RowCount > 0 Then
                If e.KeyCode = Keys.F2 Then
                    performdelete(sbrecid)
                End If
            End If
        End With
    End Sub

    Sub performdelete(ByVal recids As Integer)
        Dim c As Integer = 0
        condb()
        If MsgBox("Are you sure you want to delete this student", 4 + 32, "DELETE?") = 7 Then
            c = 1
        Else
            frmloading.Show(Me)
            frmloading.pgloading.Refresh()
            Dim dt As Date
            dt = gettime2(3)

            Dim ckstat As Integer = 0

            With dgvlist2
                For i = 0 To .RowCount - 1
                    If .Item(0, i).Value = True Or .Item(0, i).Value = 1 Then
                        ckstat = 1
                    End If
                Next

                If ckstat = 1 Then

                  
                    For i = dgvlist2.RowCount - 1 To 0 Step -1

               
                        If .Item(0, i).Value = True Or .Item(0, i).Value = 1 Then
                            frmloading.Label6.Text = "Deleting selected data as requested..."
                            frmloading.Label6.Refresh()
                            frmloading.pgloading.Refresh()

                            recids = .Item(.Columns.Count - 1, i).Value

                            cm = New MySqlCommand("DELETE FROM " & activetab & ".for_insurance WHERE recid=@rcid", cdb)
                            cm.Parameters.AddWithValue("@rcid", recids)
                            cm.ExecuteNonQuery()
                            .CurrentCell = .Item(3, i)
                            .Item(3, i).Selected = True
                            .Refresh()

                            frmloading.pgloading.Refresh()

                            sbstudname = .Item(6, i).Value & "- " & .Item(3, i).Value & " " & .Item(4, i).Value

                            savetrails(_userid, "Deleted recid " & recids & " -- Student Details : " & sbstudname & "--" & _user, dt)


                            Dim drow As DataRow = localdtb3.Select("recid = '" & recids & "'").FirstOrDefault()
                            If Not drow Is Nothing Then
                                dgvlist2.Rows.RemoveAt(i)
                                drow.Delete()
                                frmloading.pgloading.Refresh()

                            End If
                        End If
                    Next
                    localdtb3.AcceptChanges()
                    .DataSource = localdtb3
                    .Refresh()


                Else
                    cm = New MySqlCommand("DELETE FROM " & activetab & ".for_insurance WHERE recid=@rcid", cdb)
                    cm.Parameters.AddWithValue("@rcid", recids)
                    cm.ExecuteNonQuery()

                    dt = gettime2(3)
                    savetrails(_userid, "Deleted recid " & recids & " -- Student Details : " & sbstudname & "--" & _user, dt)
                    condb_close(cdb)
                    Dim row As DataRow = localdtb3.Select("recid = '" & recids & "'").FirstOrDefault()
                    If Not row Is Nothing Then
                        row.Delete()
                        localdtb3.AcceptChanges()
                        .DataSource = localdtb3
                        .Refresh()
                    End If
                End If

                If .RowCount > 0 Then
                    Dim a As Integer = 1
                    For i = 0 To .RowCount - 1
                        .Item(1, i).Value = a
                        a += 1
                    Next
                End If
                frmloading.Label6.Text = "This may take several minutes..."
                frmloading.Label6.Refresh()
                frmloading.Dispose()
            End With

            loadforsubmission(cbosems.SelectedValue, 0)

        End If

        condb_close(cdb)
    End Sub

    Private Sub dgvlist2_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvlist2.MouseDown
        With dgvlist2
            If .RowCount > 0 Then

            End If
        End With
    End Sub
    Dim sbrecid As Integer = 0
    Dim sbstudname As String = Nothing
    Private Sub dgvlist2_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvlist2.CellMouseDown
        With dgvlist2
            If .RowCount > 0 Then
                Try
                    If e.Button = Windows.Forms.MouseButtons.Right Then
                        .CurrentCell = .Rows(e.RowIndex).Cells(e.ColumnIndex)
                        .Rows(e.RowIndex).Selected = True
                        .Focus()
                        sbstudname = .Rows(e.RowIndex).Cells(6).Value & "- " & .Rows(e.RowIndex).Cells(3).Value & " " & .Rows(e.RowIndex).Cells(4).Value
                        sbrecid = Convert.ToInt32(.Rows(e.RowIndex).Cells(12).Value)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, 48, "Row Error")
                End Try
            End If

        End With
    End Sub

    Private Sub dgvlist1_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvlist2.MouseClick, dgvlist1.MouseClick
        With dgvlist2
            If .RowCount > 0 Then
                Try
                    If e.Button = Windows.Forms.MouseButtons.Right Then
                        ctxmenu1.Show(Cursor.Position.X, Cursor.Position.Y)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, 48, "Row Error")
                End Try
            End If

        End With
    End Sub

    Private Sub DeleteSelectedRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedRowToolStripMenuItem.Click
        If sbrecid > 0 Then
            performdelete(sbrecid)
        End If
    End Sub

    Private Sub checkall_CheckedChanged(sender As Object, e As EventArgs) Handles checkall.CheckedChanged
        With dgvlist2
            Dim cval As Boolean = False
            If checkall.Checked = True Then
                cval = True
            ElseIf checkall.Checked = False Then
                cval = False
            End If

            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    .Item(0, i).Value = cval
                Next
            End If
        End With
    End Sub

    Private Sub chksub_CheckedChanged(sender As Object, e As EventArgs) Handles chksub.CheckedChanged
        If chksub.Checked = False Then
            loadsubmitted(cbosems.SelectedValue, 1)
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class