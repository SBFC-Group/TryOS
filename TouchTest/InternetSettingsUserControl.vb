Public Class InternetSettingsUserControl
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox1.Text = Internetplusplus.TextBox1.Text
        TextBox2.Text = Internetplusplus.TextBox2.Text
        TextBox3.Text = Internetplusplus.TextBox3.Text
        TextBox4.Text = Internetplusplus.TextBox4.Text
        TextBox5.Text = Internetplusplus.TextBox5.Text
        TextBox6.Text = Internetplusplus.TextBox6.Text

        Timer1.Stop()
    End Sub

    Private Sub SettingsButton1_Click(sender As Object, e As EventArgs) Handles SettingsButton1.Click, SettingsButton2.Click, SettingsButton3.Click, SettingsButton4.Click, SettingsButton5.Click, SettingsButton6.Click
        'MsgBox(sender.Name)

        Dim NameOfButton As String = sender.Name
        NameOfButton = NameOfButton.Replace("SettingsButton", "")

        If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\load" & NameOfButton & ".tabsetting") Then
            If NameOfButton = "1" Then
                My.Computer.FileSystem.WriteAllText(UI.UserFolder & "\Settings\load" & NameOfButton & ".tabsetting", TextBox1.Text, False)
            ElseIf NameOfButton = "2" Then
                My.Computer.FileSystem.WriteAllText(UI.UserFolder & "\Settings\load" & NameOfButton & ".tabsetting", TextBox2.Text, False)
            ElseIf NameOfButton = "3" Then
                My.Computer.FileSystem.WriteAllText(UI.UserFolder & "\Settings\load" & NameOfButton & ".tabsetting", TextBox3.Text, False)
            ElseIf NameOfButton = "4" Then
                My.Computer.FileSystem.WriteAllText(UI.UserFolder & "\Settings\load" & NameOfButton & ".tabsetting", TextBox4.Text, False)
            ElseIf NameOfButton = "5" Then
                My.Computer.FileSystem.WriteAllText(UI.UserFolder & "\Settings\load" & NameOfButton & ".tabsetting", TextBox5.Text, False)
            ElseIf NameOfButton = "6" Then
                My.Computer.FileSystem.WriteAllText(UI.UserFolder & "\Settings\load" & NameOfButton & ".tabsetting", TextBox6.Text, False)
            End If
        End If


    End Sub
End Class
