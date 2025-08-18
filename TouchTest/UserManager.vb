Public Class UserManager
    Public ReadOnly Username As String

    Public Sub New(TheUserName As String)
        Username = TheUserName
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
End Class
