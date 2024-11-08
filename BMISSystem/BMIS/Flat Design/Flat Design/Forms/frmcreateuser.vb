Imports System
Imports System.IO
Imports System.Windows.Forms

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
Imports MySql.Data.MySqlClient
Public Class frmcreateuser
    Dim cm As MySqlCommand
    Dim dr As MySqlDataReader


    Private Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub frmcreatenewuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        clearer()
        LoadUsers()
        tbusernm.Tag = Nothing
        tbpasswd.PasswordChar = Chr(149)
        ' txtConfirm.PasswordChar = Chr(149)
        tbusernm.Focus()

        cboutyp.Items.Clear()
        cboutyp.DisplayMember = "text"
        cboutyp.Items.Add(New With {.Text = "Administrator", .Value = "A"})
        cboutyp.Items.Add(New With {.Text = "Staff", .Value = "S"})
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If IS_EMPTY(tbusernm) = True Then Return
            If IS_EMPTY(tbpasswd) = True Then Return

            If IS_EMPTY(cboutyp) = True Then Return
            If IS_EMPTY(tbcp_unem) = True Then Return
            Dim fnd As Boolean = False
            Dim dt As Date
            dt = gettime2(3)
            condb()
            If MsgBox("Are you sure you want to save this user information?", vbYesNo + vbQuestion) = vbYes Then
                Dim ustch As String = Nothing
                'ustch = Mainform.ttssuser.Text & " " & Mainform.ttssuser.Tag
                If tbusernm.Tag <> Nothing Then


                    cm = New MySqlCommand("UPDATE bmis_useraccout001 SET usernem=@username, pwd=@password, cpname=@name, " & _
                                          " usertyp= @usertype,cinitial=@ut,usertouch=@utc,dupd=@dtc,dupdt=@dtt WHERE userid=@rd" & _
                                          " ", cdb)
                    cm.Parameters.AddWithValue("@username", tbusernm.Text.Trim)
                    cm.Parameters.AddWithValue("@password", EncryptNew(tbpasswd.Text.Trim))
                    cm.Parameters.AddWithValue("@name", tbcp_unem.Text.Trim)
                    Dim cbv As String = Nothing
                    If cboutyp.Text <> Nothing Then
                        cbv = cboutyp.SelectedItem.value
                    Else
                        cbv = "A"
                        cboutyp.SelectedIndex = 0
                    End If
                    cm.Parameters.AddWithValue("@usertype", cbv)
                    cm.Parameters.AddWithValue("@ut", tbuinitial.Text.Trim)
                    cm.Parameters.AddWithValue("@dtc", gettime(3))
                    cm.Parameters.AddWithValue("@dtt", gettime(1))
                    cm.Parameters.AddWithValue("@rd", tbusernm.Tag)
                    cm.Parameters.AddWithValue("@utc", ustch)
                    cm.ExecuteNonQuery()
                    trs = "Updated user information userID" & tbusernm.Tag & " Username " & tbusernm.Text.Trim & " " & tbpasswd.Text.Trim
                    'savetrails(Mainform.ttssuser.Tag, trs, dt)
                    MsgBox("User informaion has been successfully updated.", 64, "User information successfully updated")
                    cm.Dispose()
                Else

                    cm = New MySqlCommand("SELECT * FROM bmis_useraccout001 WHERE usernem=@username", cdb)
                    cm.Parameters.AddWithValue("@username", tbusernm.Text.Trim)


                    Using rd As MySqlDataReader = cm.ExecuteReader
                        If rd.HasRows Then
                            fnd = True
                        End If
                    End Using
                    cm.Dispose()

                    If fnd = False Then
                        'cm = New MySqlCommand("insert into users (username, password, name, usertype) values(@username, @password, @name, @usertype)", cn)
                        cm = New MySqlCommand("INSERT INTO bmis_useraccout001 (usernem, pwd, cpname, usertyp,cinitial,usertouch,dsaved,dtime) " & _
                                              "VALUES(@username, @password, @name, @usertype, @ut,@utc, @dtc, @dtt)", cdb)
                        cm.Parameters.AddWithValue("@username", tbusernm.Text.Trim)
                        cm.Parameters.AddWithValue("@password", EncryptNew(tbpasswd.Text.Trim))
                        cm.Parameters.AddWithValue("@name", tbcp_unem.Text.Trim)
                        If cboutyp.Text <> Nothing Then
                            cm.Parameters.AddWithValue("@usertype", cboutyp.SelectedItem.value)
                        Else
                            cm.Parameters.AddWithValue("@usertype", Nothing)
                        End If

                        cm.Parameters.AddWithValue("@ut", tbuinitial.Text.Trim)
                        cm.Parameters.AddWithValue("@utc", ustch)
                        cm.Parameters.AddWithValue("@dtc", gettime(3))
                        cm.Parameters.AddWithValue("@dtt", gettime(1))
                        cm.ExecuteNonQuery()
                        trs = "Added new user information " & " Username " & tbusernm.Text.Trim & " Password " & tbpasswd.Text.Trim
                        'savetrails(Mainform.ttssuser.Tag, trs, dt)
                        MsgBox("New user informaion has been successfully saved.", 64, "User information successfully saved")
                    Else
                        MsgBox("Username already exists, please select other username", 48, "Username already exists")
                    End If
                End If
                If fnd = False Then
                    clearer()
                End If
                condb_close(cdb)
                LoadUsers()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Sub clearer()
        tbusernm.Clear()
        tbpasswd.Clear()
        tbcp_unem.Clear()
        cboutyp.Text = Nothing
        tbuinitial.Clear()
        tbusernm.Tag = Nothing
    End Sub
    Sub LoadUsers()
        condb()
        With dg1
            .Rows.Clear()
            Dim i As Integer = 0
            Dim cm As MySqlCommand
            cm = New MySqlCommand("select * FROM bmis_useraccout001 ORDER BY c_user,usernem", cdb)
            ' cm = New MySqlCommand("select * from users", cn)
            Using dr As MySqlDataReader = cm.ExecuteReader
                While dr.Read
                    .Rows.Add(dr.Item("userid").ToString, dr.Item("usernem").ToString, _
                    DecryptNew(dr.Item("pwd").ToString), _
                     dr.Item("cpname").ToString, dr.Item("usertyp").ToString, dr.Item("cinitial").ToString, _
                    dr.Item("usertouch").ToString, dr.Item("dsaved").ToString, "Edit")
                End While
                dr.Close()
            End Using

        End With
        condb_close(cdb)

    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick
        With dg1
            If .RowCount > 0 Then
                If e.ColumnIndex = 8 Then
                    Dim rcid As String = Nothing
                    rcid = .Item(0, e.RowIndex).Value
                    tbusernm.Tag = rcid

                    retrieve_user(rcid)
                End If
            End If
        End With
    End Sub
    Sub retrieve_user(ByVal rd As String)
        condb()
        cm = New MySqlCommand("select * from bmis_useraccout001 WHERE userid=@rid order by cpname, usernem", cdb)
        cm.Parameters.AddWithValue("@rid", rd)
        Using dr As MySqlDataReader = cm.ExecuteReader
            dr.Read()
            tbusernm.Tag = dr("userid").ToString
            tbusernm.Text = dr("usernem").ToString
            tbpasswd.Text = DecryptNew(dr.Item("pwd").ToString)
            tbcp_unem.Text = dr("cpname").ToString

            Dim cbv As String = Nothing
            If dr("usertyp").ToString <> Nothing Then
                cbv = dr("usertyp").ToString
            Else
                cbv = "A"
            End If


            cboutyp.SelectedIndex = setselindex(cboutyp, cbv)

            tbuinitial.Text = dr("cinitial").ToString

            dr.Close()
        End Using
        cm.Dispose()
        condb_close(cdb)
    End Sub


    Private Sub cboUserType_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub dgvuser_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs)
        Dim colName As String = dg1.Columns(e.ColumnIndex).Name
        If colName = "uedit" Then
            If dg1.RowCount > 0 Then
                If MsgBox("Delete this User? Click Yes to Confirm", vbYesNo + vbQuestion) = vbYes Then
                    condb()
                    cm = New MySqlCommand("Delete from users where username like '" & dg1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cdb)
                    cm.ExecuteNonQuery()
                    condb_close(cdb)
                    MsgBox("User has been Successfully Deleted!", vbInformation)
                    LoadUsers()
                End If
            End If

        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
        Me.Close()
        MainForm.btnDashboard.PerformClick()
    End Sub



    Private Sub tsref_Click(sender As Object, e As EventArgs) Handles tsref.Click
        LoadUsers()
    End Sub


End Class