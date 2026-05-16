Public Class UserManager
    Public ReadOnly Username As String
    Public ReadOnly UserFolderPath As String
    Public ReadOnly Role As TryController.Roles
    Public ReadOnly SandboxedUser As Boolean
    Public ReadOnly LockedMode As Boolean

    Public Shared DoesSuperSecretUserExist As Boolean = False

    Public Sub New(Optional TheUserName As String = "", Optional IsSandboxed As Boolean = False)
        'If TheUserName = "SuperSecretUser" Then
        '    If DoesSuperSecretUserExist = False Then DoesSuperSecretUserExist = True
        'End If

        'If TheUserName = "SuperSecretUser" Then
        '    If DoesSuperSecretUserExist = True Then

        '    End If
        'End If

        If TheUserName = "" Then
            Username = Form1.Username
            UserFolderPath = UI.UsersFolder & "\" & Form1.Username
        Else
            Username = TheUserName
            UserFolderPath = UI.UsersFolder & "\" & TheUserName
            'If TheUserName = "SuperSecretUser" Then
            '    If DoesSuperSecretUserExist = False Then
            '        Username = TheUserName
            '        UserFolderPath = UI.UsersFolder & "\" & TheUserName
            '    End If
            'End If
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\SBFC Group\Edomdekcol", "Edomdekcol", Nothing) = "True" Then
            LockedMode = True
        ElseIf My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LockedMode.setting") Then
            Try
                LockedMode = Convert.ToBoolean(My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\LockedMode.setting"))
            Catch ex As Exception
            End Try
        End If

        SandboxedUser = IsSandboxed
        If IsSandboxed = True Then
            Role = TryController.Roles.StandardSandbox
        Else
            Role = GetRole()
        End If

    End Sub

    Public Enum HowWasTaskDone
        Completed = 1
        Failed = 2
        Paused = 3
        Canceled = 4
    End Enum

    Public Function LoadUserSettings() As HowWasTaskDone
        If Role = TryController.Roles.StandardSandbox Then
            Return HowWasTaskDone.Canceled
        Else
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
                If setting.Contains("IsTransparentEnabled=") = True Then
                    setting = setting.Replace("IsTransparentEnabled=", "")
                    Form1.IsTransparentEnabled = Convert.ToBoolean(setting)
                ElseIf setting.Contains("AllowOpenFrameworkToLoadApps=") = True Then
                    setting = setting.Replace("AllowOpenFrameworkToLoadApps=", "")
                    UI.DisableOpenFramework = Convert.ToBoolean(setting)
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
        End If
    End Function

    Public Function SaveUserSettings(Optional SettingsList As String = "Null") As HowWasTaskDone
        If Role = TryController.Roles.StandardSandbox Then
            Return HowWasTaskDone.Canceled
        Else
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
        End If
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

            If SettingName.EndsWith(";") = True Then
                usedencode = usedencode & "
" & SettingName
            Else
                usedencode = usedencode & "
" & SettingName & ";"
            End If

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
        If My.Computer.FileSystem.FileExists(Form1.User.UserFolderPath & "\Settings\Wallpaper.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(Form1.User.UserFolderPath & "\Settings\Wallpaper.swfiles")
            If Reader.StartsWith("jpg=") Then
                Reader = Reader.Replace("jpg=", "")
                UI.RunCommands("Loadjpg " & Reader, Form1.User)
            ElseIf Reader.StartsWith("png=") Then
                Reader = Reader.Replace("png=", "")
                UI.RunCommands("Loadpng " & Reader, Form1.User)
            ElseIf Reader.StartsWith("gif=") Then
                Reader = Reader.Replace("gif=", "")
                UI.RunCommands("Loadgif " & Reader, Form1.User)
            End If
        End If
    End Sub

    Public Shared Sub CheckForDarkThemeFile()
        If My.Computer.FileSystem.FileExists(Form1.User.UserFolderPath & "\Settings\DarkThemeForApps.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(Form1.User.UserFolderPath & "\Settings\DarkThemeForApps.swfiles")
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
        If My.Computer.FileSystem.FileExists(Form1.User.UserFolderPath & "\Settings\DarkThemeForPrograms.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(Form1.User.UserFolderPath & "\Settings\DarkThemeForApps.swfiles")
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
        OpenFramework_Data.OpenFramework.RestoreButtonOrder(False)
    End Sub

    Public Shared Function Login(Username As String, Password As String, Optional ShowErrors As Boolean = False) As TryController.HowWasTaskCompleted
        If Form1.User.Role = TryController.Roles.Program Then
        ElseIf Form1.User.Role = TryController.Roles.Developer Then
        Else
            Return TryController.HowWasTaskCompleted.Canceled
        End If

        If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\" & Username) = True Then
            If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & Username & "\Settings\Password.swfiles") = True Then

                Dim tempPassword As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Username & "\Settings\Password.swfiles")
                If tempPassword = "" Then
                    If ShowErrors = True Then
                        UI.ShowError("""Password.swfiles"" can't be nothing.", ErrorMSGBox.Alerts.Critical)
                    End If
                    Return TryController.HowWasTaskCompleted.Failed
                End If
                Try
                    Dim b As Byte() = Convert.FromBase64String(Password)
                    Password = System.Text.Encoding.UTF8.GetString(b)
                    b = Convert.FromBase64String(Password)
                    Password = System.Text.Encoding.UTF8.GetString(b)
                Catch ex As Exception
                    If ShowErrors = True Then
                        UI.ShowError(ex.Message, ErrorMSGBox.Alerts.Critical)
                    End If
                    Return TryController.HowWasTaskCompleted.Failed
                End Try
                If tempPassword = "T_h_i_s_U_s_e_r_H_a_s_N_o_t_h_i_n_g" Then
                    tempPassword = ""
                End If

                Dim UserMode As String = Nothing
                If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & Username & "\Settings\UserMode.swfiles") Then
                    UserMode = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Username & "\Settings\UserMode.swfiles")
                End If

                If UserMode = "UserMode=Disabled" Then
                    If ShowErrors = True Then
                        UI.ShowError("Can't find an user with that password.", ErrorMSGBox.Alerts.Information)
                    End If
                    Return TryController.HowWasTaskCompleted.Failed
                Else
                    If tempPassword = Password Then
                        Return TryController.HowWasTaskCompleted.Successfully
                    Else
                        If ShowErrors = True Then
                            UI.ShowError("Can't find an user with that password.")
                        End If
                        Return TryController.HowWasTaskCompleted.Failed
                    End If
                End If
            Else
                If ShowErrors = True Then
                    UI.ShowError("Can't find an Password.", ErrorMSGBox.Alerts.Critical)
                End If
                Return TryController.HowWasTaskCompleted.Failed
            End If
        Else
            If ShowErrors = True Then
                UI.ShowError("Can't find an user with that password.", ErrorMSGBox.Alerts.Information)
            End If
            Return TryController.HowWasTaskCompleted.Failed
        End If
    End Function
End Class
