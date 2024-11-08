Public Class MenuClass
    Function btnremove_spaces()
        For Each ctl As Control In MainForm.Panel1.Controls
            If ctl.GetType.ToString = "System.Windows.Forms.Button" Then
                If ctl.Tag = "click" Then
                    ctl.Text = Strings.Mid(ctl.Text, 6, Len(ctl.Text))
                    ctl.Tag = Nothing
                End If
            End If
        Next
        Return True
    End Function

    Function changebtnbackcolor_default(btn As Button)
        For Each ctl As Control In MainForm.Panel1.Controls
            If ctl.GetType.ToString = "System.Windows.Forms.Button" Then
                ctl.BackColor = System.Drawing.Color.FromArgb(178, 34, 34)
            End If
        Next
        btn.BackColor = System.Drawing.Color.FromArgb(64, 64, 64)

        Return True
    End Function
End Class
