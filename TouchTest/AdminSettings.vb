Public Class AdminSettings
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = UI.WallpaperFolder
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            If OpenFileDialog1.FileName.StartsWith(UI.WallpaperFolder) = True Then
                PictureBox1.Load(OpenFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\ShellName.setting") Then
            My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\ShellName.setting", TextBox1.Text, False)
        End If
    End Sub

    Private Sub AdminSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\ShellName.setting") Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\ShellName.setting")
        End If

        If Form1.GetRole() = TryController.Roles.Administrator Then
            CheckBox1.Visible = True
            DebugAppButton.Visible = True
        ElseIf Form1.GetRole() = TryController.Roles.Program Then
            CheckBox1.Visible = True
            DebugAppButton.Visible = True
        ElseIf Form1.GetRole() = TryController.Roles.Developer Then
            CheckBox1.Visible = True
            DebugAppButton.Visible = True
        Else
            CheckBox1.Visible = False
            DebugAppButton.Visible = False
        End If
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LoadDebugMenu_.setting") Then
                My.Computer.FileSystem.RenameFile(UI.SettingsFolder & "\LoadDebugMenu_.setting", "LoadDebugMenu.setting")
            Else
                My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\LoadDebugMenu.setting", TextBox1.Text, False)
            End If
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LoadDebugMenu.setting") Then
                My.Computer.FileSystem.RenameFile(UI.SettingsFolder & "\LoadDebugMenu.setting", "LoadDebugMenu_.setting")
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles DebugAppButton.Click
        DebugApp.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Form1.IsUsingDarkThemeForApps = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Color.Gray
            Button1.BackColor = Color.DarkGray
            Button2.BackColor = Color.DarkGray
            DebugAppButton.BackColor = Color.DarkGray
            TextBox1.BackColor = Color.DarkGray
            PictureBox1.BackColor = Color.DarkGray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray
            Button1.BackColor = Color.Gainsboro
            Button2.BackColor = Color.Gainsboro
            DebugAppButton.BackColor = Color.Gainsboro
            TextBox1.BackColor = Color.Gainsboro
            PictureBox1.BackColor = Color.Gainsboro
        End If
    End Sub
End Class
