Public Class AdminToolsApp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath & "\Wallpapers"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If OpenFileDialog1.FileName.StartsWith(My.Application.Info.DirectoryPath & "\Wallpapers") = True Then
                PictureBox1.Load(OpenFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\ShellName.setting") Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\ShellName.setting", TextBox1.Text, False)
        End If
    End Sub

    Private Sub AdminSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeDesign(Main.Controller.IsDarkMode())

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\ShellName.setting") Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Settings\ShellName.setting")
        End If

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\LastKnownUser.setting") Then
            TextBox2.Text = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Settings\LastKnownUser.setting")
        End If

        If Main.Controller.GetRole() = TouchTest.TryController.Roles.Administrator Then
            CheckBox1.Visible = True
            CheckBox2.Visible = True
            CheckBox3.Visible = True
            DebugAppButton.Visible = True
        ElseIf Main.Controller.GetRole() = TouchTest.TryController.Roles.Program Then
            CheckBox1.Visible = True
            CheckBox2.Visible = True
            CheckBox3.Visible = True
            DebugAppButton.Visible = True
        ElseIf Main.Controller.GetRole() = TouchTest.TryController.Roles.Developer Then
            CheckBox1.Visible = True
            CheckBox2.Visible = True
            CheckBox3.Visible = True
            DebugAppButton.Visible = True
        Else
            CheckBox1.Visible = False
            CheckBox2.Visible = False
            CheckBox3.Visible = False
            DebugAppButton.Visible = False
        End If
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.CheckState = Windows.Forms.CheckState.Checked Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\LoadDebugMenu_.setting") Then
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Settings\LoadDebugMenu_.setting", "LoadDebugMenu.setting")
            Else
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\LoadDebugMenu.setting", TextBox1.Text, False)
            End If
        ElseIf CheckBox1.CheckState = Windows.Forms.CheckState.Unchecked Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\LoadDebugMenu.setting") Then
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Settings\LoadDebugMenu.setting", "LoadDebugMenu_.setting")
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckStateChanged
        If CheckBox2.CheckState = Windows.Forms.CheckState.Checked Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\DisableConsole_.setting") Then
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Settings\DisableConsole_.setting", "DisableConsole.setting")
            Else
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\DisableConsole.setting", "True", False)
            End If
        ElseIf CheckBox2.CheckState = Windows.Forms.CheckState.Unchecked Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\DisableConsole.setting") Then
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Settings\DisableConsole.setting", "DisableConsole_.setting")
            End If
        End If
    End Sub

    Private Sub CheckBox3_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckStateChanged
        If CheckBox3.CheckState = Windows.Forms.CheckState.Checked Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\UserList_.setting") Then
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Settings\UserList_.setting", "UserList.setting")
            Else
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\UserList.setting", "True", False)
            End If
        ElseIf CheckBox3.CheckState = Windows.Forms.CheckState.Unchecked Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\UserList.setting") Then
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Settings\UserList.setting", "UserList_.setting")
            End If
        End If
    End Sub

    Private Sub DebugAppButton_Click(sender As Object, e As EventArgs) Handles DebugAppButton.Click
        Dim DebugApp As New TouchTest.DebugApp
        DebugApp.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Main.Controller.IsDarkMode() = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Main.Controller.IsDarkMode() = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Drawing.Color.Gray
            Button1.BackColor = Drawing.Color.DarkGray
            Button2.BackColor = Drawing.Color.DarkGray
            DebugAppButton.BackColor = Drawing.Color.DarkGray
            TextBox1.BackColor = Drawing.Color.DarkGray
            PictureBox1.BackColor = Drawing.Color.DarkGray
            Button3.BackColor = Drawing.Color.DarkGray
            TextBox2.BackColor = Drawing.Color.DarkGray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Drawing.Color.DarkGray
            Button1.BackColor = Drawing.Color.Gainsboro
            Button2.BackColor = Drawing.Color.Gainsboro
            DebugAppButton.BackColor = Drawing.Color.Gainsboro
            TextBox1.BackColor = Drawing.Color.Gainsboro
            PictureBox1.BackColor = Drawing.Color.Gainsboro
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\LastKnownUser.setting") Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\LastKnownUser.setting", TextBox2.Text, False)
        End If
    End Sub
End Class
