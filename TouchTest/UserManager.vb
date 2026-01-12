Public Class UserManager
    Public ReadOnly Username As String
    Public ReadOnly UserFolderPath As String
    Public ReadOnly Role As TryController.Roles

    Public Sub New(Optional TheUserName As String = "")
        If TheUserName = "" Then
            Username = Form1.Username
            UserFolderPath = UI.UsersFolder & "\" & Form1.Username
        Else
            Username = TheUserName
            UserFolderPath = UI.UsersFolder & "\" & TheUserName
        End If
        Role = GetRole()
    End Sub

    Public Enum HowWasTaskDone
        Completed = 1
        Failed = 2
        Paused = 3
        Canceled = 4
    End Enum

    Public Function LoadUserSettings() As HowWasTaskDone
        Dim usedencode As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Username & "\Settings\Software.swfiles")
        Try
            Dim b As Byte() = Convert.FromBase64String(usedencode)
            usedencode = System.Text.Encoding.UTF8.GetString(b)
        Catch ex As Exception

        End Try
        Try
            Dim b2 As Byte() = Convert.FromBase64String(usedencode)
            usedencode = System.Text.Encoding.UTF8.GetString(b2)
        Catch ex As Exception

        End Try

        Dim settingstemp As String()
        settingstemp = usedencode.Split(";"c)
        For Each setting In settingstemp

            If setting.Contains("Wallpaper=") = True Then
                setting = setting.Replace("Wallpaper=", "")

                'This is copied code ;)
                If setting.Contains("jpg=") = True Then
                    setting = setting.Replace("jpg=", "")
                    UI.RunCommands("Loadjpg " & setting)
                ElseIf setting.Contains("png=") = True Then
                    setting = setting.Replace("png=", "")
                    UI.RunCommands("Loadpng " & setting)
                ElseIf setting.Contains("gif=") = True Then
                    setting = setting.Replace("gif=", "")
                    UI.RunCommands("Loadgif " & setting)
                End If

            ElseIf setting.Contains("IsDarkModeForApps=") = True Then
                setting = setting.Replace("IsDarkModeForApps=", "")
                Form1.IsUsingDarkThemeForApps = Convert.ToBoolean(setting)
            ElseIf setting.Contains("IsDarkModeForProgram=") = True Then
                setting = setting.Replace("IsDarkModeForProgram=", "")
                Form1.IsUsingDarkThemeForPrograms = Convert.ToBoolean(setting)
            ElseIf setting.Contains("DoesHasTimeBar=") = True Then
                setting = setting.Replace("DoesHasTimeBar=", "")
                Form1.TimebarPanel.Visible = Convert.ToBoolean(setting)
                'ElseIf setting.StartsWith("") = True Then
                'ElseIf setting.StartsWith("") = True Then
                'ElseIf setting.StartsWith("") = True Then
                'ElseIf setting.StartsWith("") = True Then
                'ElseIf setting.StartsWith("") = True Then
            End If
        Next
        Return HowWasTaskDone.Completed
    End Function

    Public Function SaveUserSettings(Optional SettingsList As String = "Null") As HowWasTaskDone
        Dim Reader As String = Nothing

        If SettingsList = "Null" Then
            Reader = "Wallpaper=" & Form1.WallpaperFileFormat & "=" & Form1.LoadedWallpaper.ToString & ";" & Environment.NewLine

            Reader = Reader & "IsDarkModeForApps=" & Form1.IsUsingDarkThemeForApps.ToString & ";" & Environment.NewLine

            Reader = Reader & "IsDarkModeForProgram=" & Form1.IsUsingDarkThemeForPrograms.ToString & ";" & Environment.NewLine

            Reader = Reader & "DoesHasTimeBar=" & Form1.TimebarPanel.Visible.ToString & ";" & Environment.NewLine
        Else
            Reader = SettingsList
        End If
        Try
            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(Reader)
            Reader = Convert.ToBase64String(byt)
            Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(Reader)
            Reader = Convert.ToBase64String(byt2)
        Catch ex As Exception
        End Try

        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Software.swfiles", Reader, False)

        Return HowWasTaskDone.Completed
    End Function

    Public Function DoesSettingExist(SettingName As String) As Boolean
        'Gets Data
        Dim usedencode As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Username & "\Settings\Software.swfiles")

        'Makes it readable
        Try
            Dim b As Byte() = Convert.FromBase64String(usedencode)
            usedencode = System.Text.Encoding.UTF8.GetString(b)
        Catch ex As Exception

        End Try
        Try
            Dim b2 As Byte() = Convert.FromBase64String(usedencode)
            usedencode = System.Text.Encoding.UTF8.GetString(b2)
        Catch ex As Exception

        End Try

        'Finds out if the setting exists
        If usedencode.Contains(SettingName) = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AddSettingToUserSettings(SettingName As String) As HowWasTaskDone
        If DoesSettingExist(SettingName) = False Then
            'Gets Data
            Dim usedencode As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Username & "\Settings\Software.swfiles")

            'Makes it readable
            Try
                Dim b As Byte() = Convert.FromBase64String(usedencode)
                usedencode = System.Text.Encoding.UTF8.GetString(b)
            Catch ex As Exception

            End Try
            Try
                Dim b2 As Byte() = Convert.FromBase64String(usedencode)
                usedencode = System.Text.Encoding.UTF8.GetString(b2)
            Catch ex As Exception

            End Try

            usedencode = usedencode & "
" & SettingName

            SaveUserSettings(usedencode)

            Return HowWasTaskDone.Completed
        Else
            Return HowWasTaskDone.Canceled
        End If
    End Function

    Public Function RemoveSettingFromUserSettings(SettingName As String) As HowWasTaskDone
        If DoesSettingExist(SettingName) = True Then
            'Gets Data
            Dim usedencode As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Username & "\Settings\Software.swfiles")

            'Makes it readable
            Try
                Dim b As Byte() = Convert.FromBase64String(usedencode)
                usedencode = System.Text.Encoding.UTF8.GetString(b)
            Catch ex As Exception

            End Try
            Try
                Dim b2 As Byte() = Convert.FromBase64String(usedencode)
                usedencode = System.Text.Encoding.UTF8.GetString(b2)
            Catch ex As Exception

            End Try

            If SettingName.EndsWith(";") = True Then
                usedencode = usedencode.Replace(SettingName, "")
            Else
                usedencode = usedencode.Replace(SettingName & ";", "")
            End If

            SaveUserSettings(usedencode)

            Return HowWasTaskDone.Completed
        Else
            Return HowWasTaskDone.Canceled
        End If
    End Function

    Public Function ReplaceSettingInUserSettings(SettingName As String, NewName As String) As HowWasTaskDone
        If DoesSettingExist(SettingName) = True Then
            'Gets Data
            Dim usedencode As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Username & "\Settings\Software.swfiles")

            'Makes it readable
            Try
                Dim b As Byte() = Convert.FromBase64String(usedencode)
                usedencode = System.Text.Encoding.UTF8.GetString(b)
            Catch ex As Exception

            End Try
            Try
                Dim b2 As Byte() = Convert.FromBase64String(usedencode)
                usedencode = System.Text.Encoding.UTF8.GetString(b2)
            Catch ex As Exception

            End Try

            If SettingName.EndsWith(";") = True Then
                usedencode = usedencode.Replace(SettingName, NewName)
            Else
                usedencode = usedencode.Replace(SettingName & ";", NewName & ";")
            End If

            SaveUserSettings(usedencode)

            Return HowWasTaskDone.Completed
        Else
            Return HowWasTaskDone.Canceled
        End If
    End Function

    Private Function GetRole() As TryController.Roles
        If My.Computer.FileSystem.FileExists(UserFolderPath & "\Settings\Role.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UserFolderPath & "\Settings\Role.swfiles")
            Try
                Dim b As Byte() = Convert.FromBase64String(Reader)
                Reader = System.Text.Encoding.UTF8.GetString(b)
            Catch ex As Exception

            End Try
            Try
                Dim b2 As Byte() = Convert.FromBase64String(Reader)
                Reader = System.Text.Encoding.UTF8.GetString(b2)
            Catch ex As Exception

            End Try
            Try
                Dim b3 As Byte() = Convert.FromBase64String(Reader)
                Reader = System.Text.Encoding.UTF8.GetString(b3)
            Catch ex As Exception

            End Try
            Try
                Dim b4 As Byte() = Convert.FromBase64String(Reader)
                Reader = System.Text.Encoding.UTF8.GetString(b4)
            Catch ex As Exception

            End Try

            If Reader = "73593736" Then
                Return TryController.Roles.Guest
            ElseIf Reader = "83835392" Then
                Return TryController.Roles.Standard
            ElseIf Reader = "43638462" Then
                Return TryController.Roles.Administrator
            ElseIf Reader = "39456543" Then
                Return TryController.Roles.Program
            ElseIf Reader = "19563469" Then
                Return TryController.Roles.Developer
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

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
