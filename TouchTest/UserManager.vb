Public Class UserManager
    Public ReadOnly Username As String
    Public ReadOnly Role As TryController.Roles

    Public Sub New(TheUserName As String)
        Username = TheUserName
        Role = Form1.GetRole()
    End Sub

    Public Sub LoadUserSettings()
        Dim settingstemp As String()
        settingstemp = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\Software.swfiles").Split(Environment.NewLine)
        For Each setting As String In settingstemp
            If setting.StartsWith("Wallpaper=") Then
                setting = setting.Replace("Wallpaper=", "")

                'This is copied code ;)
                If setting.StartsWith("jpg=") Then
                    setting = setting.Replace("jpg=", "")
                    UI.RunCommands("Loadjpg " & setting)
                ElseIf setting.StartsWith("png=") Then
                    setting = setting.Replace("png=", "")
                    UI.RunCommands("Loadpng " & setting)
                ElseIf setting.StartsWith("gif=") Then
                    setting = setting.Replace("gif=", "")
                    UI.RunCommands("Loadgif " & setting)
                End If

            ElseIf setting.StartsWith("IsDarkModeForApps=") Then
                setting = setting.Replace("IsDarkModeForApps=", "")
                Form1.IsUsingDarkThemeForApps = Convert.ToBoolean(setting)
            ElseIf setting.StartsWith("IsDarkModeForProgram=") Then
                setting = setting.Replace("IsDarkModeForProgram=", "")
                Form1.IsUsingDarkThemeForPrograms = Convert.ToBoolean(setting)
                'ElseIf setting.StartsWith("") Then
                'ElseIf setting.StartsWith("") Then
                'ElseIf setting.StartsWith("") Then
                'ElseIf setting.StartsWith("") Then
                'ElseIf setting.StartsWith("") Then
                'ElseIf setting.StartsWith("") Then
            End If
        Next

    End Sub

    Public Sub SaveUserSettings()
        Dim Reader As String = Nothing
        Reader = "Wallpaper=Load" & Form1.WallpaperFileFormat & "=" & Form1.LoadedWallpaper.ToString & Environment.NewLine

        Reader = Reader & "IsDarkModeForApps=" & Form1.IsUsingDarkThemeForApps.ToString & Environment.NewLine

        Reader = Reader & "IsDarkModeForProgram=" & Form1.IsUsingDarkThemeForPrograms.ToString & Environment.NewLine
    End Sub

    Public Shared Sub LoadWallpaperFromUserSettings()
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Form1.Username & "\Settings\Wallpaper.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Users\" & Form1.Username & "\Settings\Wallpaper.swfiles")
            If Reader.StartsWith("jpg=") Then
                Reader = Reader.Replace("jpg=", "")
                UI.RunCommands("Loadjpg " & Reader)
            ElseIf Reader.StartsWith("png=") Then
                Reader = Reader.Replace("png=", "")
                UI.RunCommands("Loadpng " & Reader)
            ElseIf Reader.StartsWith("gif=") Then
                Reader = Reader.Replace("gif=", "")
                UI.RunCommands("Loadgif " & Reader)
            End If
        End If
    End Sub

    Public Shared Sub CheckForDarkThemeFile()
        If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\DarkThemeForApps.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\DarkThemeForApps.swfiles")
            If Reader = "True" Then
                Form1.IsUsingDarkThemeForApps = True
            ElseIf Reader = "False" Then
                Form1.IsUsingDarkThemeForApps = False
            Else
                Form1.IsUsingDarkThemeForApps = False
            End If
        Else
            Form1.IsUsingDarkThemeForApps = False
        End If
    End Sub

    Public Shared Sub LoadShellColors()
        If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\DarkThemeForPrograms.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\DarkThemeForApps.swfiles")
            If Reader = "True" Then
                Form1.IsUsingDarkThemeForPrograms = True
            ElseIf Reader = "False" Then
                Form1.IsUsingDarkThemeForPrograms = False
            Else
                Form1.IsUsingDarkThemeForPrograms = False
            End If
        Else
            Form1.IsUsingDarkThemeForPrograms = False
        End If

        'Form1.Panel2.BackColor = Color.FromArgb(55, Color.Silver)
        'Form1.TimebarPanel.BackColor = Color.FromArgb(55, Color.Silver)
    End Sub

    Public Shared Sub LoadTaskbarButtons()
        OpenFramework_Data.RestoreButtonOrder()
    End Sub
End Class
