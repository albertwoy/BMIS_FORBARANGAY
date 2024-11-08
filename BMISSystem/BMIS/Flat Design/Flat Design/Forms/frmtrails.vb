
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.DataGridViewColumnCollection

Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Public Class frmtrails
    Dim traildtb As DataTable

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        '   MainForm.Label1.Text = "Main"
        Me.Dispose()
    End Sub

    Private Sub frmtrails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        traildtb.Dispose()
    End Sub

    Private Sub frmtrails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displaytrail()
        condb()
        Dim dt As Date
        dt = gettime2(3)
        savetrails(_userid, "Viewed list of students for insurance" & "--" & _user, dt)
        condb_close(cdb)
    End Sub
    Sub displaytrail()
        condb()
        traildtb = New DataTable
        With dgvlist1
            cm = New MySqlCommand("SELECT userid EMPID,trans Transactions,dsaved `DATE`,dtmp `TIMESTAMP` FROM bmis_user_trail_001 ORDER BY trailid DESC", cdb)
            traildtb = retrieve_data_from_command(cm)

            renum(traildtb)
            .DataSource = traildtb
            .Refresh()
            cm.Dispose()
            .Columns(0).Width = 70
            .Columns(1).Width = 90
            .Columns(3).Width = 120
            '  traildtb.Dispose()

        End With
        condb_close(cdb)
        
    End Sub


    Private Sub tbsearch_TextChanged(sender As Object, e As EventArgs) Handles tbsearch.TextChanged
        If traildtb.Rows.Count > 0 Then
            Dim srchstr As String = Nothing
            srchstr = tbsearch.Text.Trim

            If srchstr <> Nothing Then
                Dim dv As DataView = New DataView(traildtb)
                dv.RowFilter = String.Format("EMPID + Transactions LIKE '%{0}%'", srchstr)
                ' dv.RowFilter = String.Format("IDNO + LASTNAME + FIRSTNAME LIKE '%{0}%'", srchstr)
                dgvlist1.DataSource = dv
                Dim a As Integer = 1
                For i = 0 To dgvlist1.RowCount - 1
                    dgvlist1.Item(0, i).Value = a
                    a += 1
                Next
            Else
                displaytrail()
            End If

        End If
    End Sub

    Private Sub btnexportdata_Click(sender As Object, e As EventArgs) Handles btnexportdata.Click
        displaytrail()
    End Sub


End Class