Imports System
Imports System.IO
Imports System.Data

Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Text
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Linq
Imports System.Configuration
Imports System.Xml
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmDashBoard
    Dim mcmd As MySqlCommand
    Sub loadcharts()
        'Try
        '    DatabaseConnect()
        '    Sql = "Select ShipCity, Total, Count, OrderId From orders"
        '    cmd = New OleDbCommand(Sql, connmdb)
        '    dr = cmd.ExecuteReader()
        '    dt = New DataTable
        '    dt.Load(dr)
        '    Chart1.Series.Add("Orders")
        '    Chart1.Series("Order").XValueMember = "ShipCity"
        '    Chart1.Series("Order").YValueMembers = "Total"
        '    Chart1.Series("Orders").XValueMember = "Count"
        '    Chart1.Series("Orders").YValueMembers = "OrderId"
        '    Chart1.DataSource = dt
        '    Chart1.DataBind()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    connmdb.Close()
        'End Try
    End Sub
    Sub display_chart1()
        'Me.Chart1.DataSource = GetData()
        'Me.Chart1.Series.Clear()
        'Chart1.ChartAreas.Clear()
        'Chart1.ChartAreas.Add("Area0")
        'Me.Chart1.Series.Add("Passes")
        'Me.Chart1.Series.Add("Visitors")

        'Chart1.Series(0).XValueMember = "Name"
        'Chart1.Series(0).YValueMembers = "Passes"
        'Chart1.Series(0).IsValueShownAsLabel = True
        'Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90

        'Chart1.Series(1).XValueMember = "Name"
        'Chart1.Series(1).YValueMembers = "Visitors"
        'Chart1.Series(1).IsValueShownAsLabel = True


    End Sub
    Sub display_chart2()
        'Me.Chart2.DataSource = GetData2()
        'Me.Chart2.Series.Clear()
        'Chart2.ChartAreas.Clear()
        'Chart2.ChartAreas.Add("Area0")
        'Me.Chart2.Series.Add("Visitors")
        '  Me.Chart2.Series.Add("Physics")

        'Chart2.Series(0).XValueMember = "Months"
        'Chart2.Series(0).YValueMembers = "Visitors"
        'Chart2.Series(0).IsValueShownAsLabel = True
        'Chart2.ChartAreas(0).AxisX.LabelStyle.Angle = -90



    End Sub
    Public Function GetData() As DataTable
        Dim dt = New DataTable()
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Passes", GetType(Integer))
        dt.Columns.Add("Visitors", GetType(Integer))
        dt.Rows.Add("VIP", 12, 17)
        dt.Rows.Add("Domestic", 19, 20)
        dt.Rows.Add("Foreigner", 14, 16)
        Return dt
    End Function

    Public Function GetData2() As DataTable
        Dim dt2 = New DataTable()
        dt2.Columns.Add("Months", GetType(String))
        dt2.Columns.Add("Visitors", GetType(Integer))
        dt2.Rows.Add("January", 102)
        dt2.Rows.Add("February", 167)
        dt2.Rows.Add("March", 220)
        Return dt2
    End Function


    Private Sub frmdashboard_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Get_Dashboard()

        'display_chart1()
        'display_chart2()
        'If condb() Then







        'Dim dtb As DataTable

        'dtb = New DataTable
        'Dim totqnum As Integer = 0
        'Using mcmd As MySqlCommand = New MySqlCommand("SELECT COUNT(DISTINCT(vispasscode)) cnt FROM visitor_passes001", cdb)
        '    dtb = retrieve_data_from_command(mcmd)
        '    If dtb.Rows.Count > 0 Then
        '        Dim rw As DataRow = dtb.Rows(0)
        '        totqnum = rw("cnt").ToString
        '        Label6.Text = totqnum
        '    End If
        'End Using


        'dtb.Rows.Clear()
        'totqnum = 0
        'Using mcmd As MySqlCommand = New MySqlCommand("SELECT COUNT(DISTINCT(vi_trava)) cnt FROM visitor_passes001 WHERE vi_trava IS NOT NULL AND vi_trava<>''", cdb)
        '    dtb = retrieve_data_from_command(mcmd)
        '    If dtb.Rows.Count > 0 Then
        '        Dim rw As DataRow = dtb.Rows(0)
        '        totqnum = rw("cnt").ToString
        '        Label5.Text = totqnum
        '    End If
        'End Using


        'dtb.Rows.Clear()
        'totqnum = 0
        'Using mcmd As MySqlCommand = New MySqlCommand("SELECT COUNT(DISTINCT(viscpname)) cnt FROM vistab_001 WHERE viscpname IS NOT NULL AND viscpname<>''", cdb)
        '    dtb = retrieve_data_from_command(mcmd)
        '    If dtb.Rows.Count > 0 Then
        '        Dim rw As DataRow = dtb.Rows(0)
        '        totqnum = rw("cnt").ToString
        '        Label4.Text = totqnum
        '    End If
        'End Using

        condb_close(cdb)
        'End If

    End Sub

    Sub Get_Dashboard()
        condb()
        cmd = New MySqlCommand("select count(*) from residents where category like 'MEMBER'", cdb)
        lblTotalMembers.Text = Format(CLng(cmd.ExecuteScalar), "N0")
        cmd.Dispose()


        cmd = New MySqlCommand("select count(*) from residents where category like 'HEAD OF THE FAMILY'", cdb)
        lblTotalHouseHold.Text = Format(CLng(cmd.ExecuteScalar), "N0")
        cmd.Dispose()


        cmd = New MySqlCommand("select count(*) from residents WHERE status='ACTIVE'", cdb)
        lblTotalPopulation.Text = Format(CLng(cmd.ExecuteScalar), "N0")
        cmd.Dispose()


        cmd = New MySqlCommand("select count(*) from residents where gender like 'MALE'", cdb)
        lblMale.Text = Format(CLng(cmd.ExecuteScalar), "N0")
        cmd.Dispose()


        cmd = New MySqlCommand("select count(*) from residents where gender like 'FEMALE'", cdb)
        lblFemale.Text = Format(CLng(cmd.ExecuteScalar), "N0")
        cmd.Dispose()


        cmd = New MySqlCommand("select count(*) from residents where voters like 'YES'", cdb)
        lblVoters.Text = Format(CLng(cmd.ExecuteScalar), "N0")
        cmd.Dispose()
        condb_close(cdb)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        'Dim savefiledialog2 As SaveFileDialog
        'savefiledialog2 = New SaveFileDialog
        'savefiledialog2.Filter = "PNG Image (*.png*)|*.png|JPEG Image (*.jpg*)|*.jpg|Bitmap Image (*.bmp*)|*.bmp|TIFF Image (*.tiff*)|*.tiff"
        'If savefiledialog2.ShowDialog = DialogResult.OK Then
        '    Select Case Path.GetExtension(savefiledialog2.FileName)
        '        Case ".png"
        '            Chart1.SaveImage(savefiledialog2.FileName, ChartImageFormat.Png)
        '        Case ".jpg"
        '            Chart1.SaveImage(savefiledialog2.FileName, ChartImageFormat.Jpeg)
        '        Case ".bmp"
        '            Chart1.SaveImage(savefiledialog2.FileName, ChartImageFormat.Bmp)
        '        Case ".tiff"
        '            Chart1.SaveImage(savefiledialog2.FileName, ChartImageFormat.Tiff)
        '    End Select
        'End If
    End Sub


    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        MainForm.Label1.Text = "Main"
        Me.Dispose()
    End Sub
End Class