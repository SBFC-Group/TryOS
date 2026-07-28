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

    ''' <summary>This will not be deprecated. Because this is used by TryOS Itself. But it's better to use the newer Contains("setting name here")</summary>
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

    ''' <summary>This is getting deprecated. Please use ChangeSetting(SettingType.Add, "setting name here")</summary>
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

    ''' <summary>This is getting deprecated. Please use ChangeSetting(SettingType.Remove, "setting name here")</summary>
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

    ''' <summary>This is getting deprecated. Please use ChangeSetting(SettingType.Replace, "setting name here"). The new sub only changes the setting name and not the value</summary>
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

    Public Sub ChangeSetting(type As SettingType, setting As String)
        'Sandboxed UserManager Objects are disallowed from changing the settings    
        If Role = TryController.Roles.StandardSandbox Then Return

        If type = SettingType.Add Then
            If My.Computer.FileSystem.FileExists(UserFolderPath & "\Settings\Software.swfiles") = False Then
                Return
            End If

            If Contains(setting) = True Then Return

            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UserFolderPath & "\Settings\Software.swfiles")

            Dim b As Byte() = Convert.FromBase64String(Reader)
            Reader = System.Text.Encoding.UTF8.GetString(b)
            b = Convert.FromBase64String(Reader)
            Reader = System.Text.Encoding.UTF8.GetString(b)

            If setting.EndsWith(";") = True Then
                Reader = Reader & "
" & setting & "="
            Else
                Reader = Reader & "
" & setting & "=;"
            End If

            SaveUserSettings(Reader)
        ElseIf type = SettingType.Remove Then
            If My.Computer.FileSystem.FileExists(UserFolderPath & "\Settings\Software.swfiles") = False Then
                Return
            End If

            If Contains(setting) = False Then Return

            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UserFolderPath & "\Settings\Software.swfiles")

            Dim b As Byte() = Convert.FromBase64String(Reader)
            Reader = System.Text.Encoding.UTF8.GetString(b)
            b = Convert.FromBase64String(Reader)
            Reader = System.Text.Encoding.UTF8.GetString(b)

            Dim newlist As New List(Of String)
            For Each str As String In Reader.Split(";"c)
                newlist.Add(str.Trim())
            Next

            Reader = Nothing

            Dim newlist2 As New List(Of String)

            For Each str As String In newlist
                Debug.WriteLine(str)
                If str.StartsWith(setting & "=") = True Then
                    newlist.Remove(str & "=")
                Else
                    newlist2.Add(str)
                End If
            Next

            For Each str As String In newlist2
                If Reader Is Nothing Then
                    Reader = str & ";"
                Else
                    Reader = Reader & "
" & str & ";"
                End If
            Next

            Reader = Reader.Replace("
;", "")

            'Debug.WriteLine(Reader)

            SaveUserSettings(Reader)
        ElseIf type = SettingType.NewSettingName Then
            Return
        ElseIf type = SettingType.ChangeValue Then
            Return
        End If
    End Sub

    Public Sub ChangeSetting(type As SettingType, setting As String, NewNameOrValue As String)
        If type = SettingType.Add Then
            ChangeSetting(type, setting)
        ElseIf type = SettingType.Remove Then
            ChangeSetting(type, setting)
        ElseIf type = SettingType.NewSettingName Then
            'This part gives the setting a new name.
            If My.Computer.FileSystem.FileExists(UserFolderPath & "\Settings\Software.swfiles") = False Then
                Return
            End If

            If Contains(setting) = False Then Return

            'Makes sure that we don't override pre-existing setting names
            If Contains(NewNameOrValue) = True Then Return

            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UserFolderPath & "\Settings\Software.swfiles")

            Dim b As Byte() = Convert.FromBase64String(Reader)
            Reader = System.Text.Encoding.UTF8.GetString(b)
            b = Convert.FromBase64String(Reader)
            Reader = System.Text.Encoding.UTF8.GetString(b)

            Dim newlist As New List(Of String)
            For Each str As String In Reader.Split(";"c)
                If str.Trim().StartsWith(setting & "=") = True Then
                    str = str.Replace(setting, NewNameOrValue)
                    newlist.Add(str.Trim())
                Else
                    newlist.Add(str.Trim())
                End If

            Next

            Dim Reader2 As String = Nothing

            For Each str As String In newlist
                If Reader2 Is Nothing Then
                    Reader2 = str & ";"
                Else
                    Reader2 = Reader2 & "
" & str & ";"
                End If
            Next

            Reader2 = Reader2.Replace("
;", "")

            SaveUserSettings(Reader2)
        ElseIf type = SettingType.ChangeValue Then
            'This part changes the value.
            If My.Computer.FileSystem.FileExists(UserFolderPath & "\Settings\Software.swfiles") = False Then
                Return
            End If

            If Contains(setting) = False Then Return

            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UserFolderPath & "\Settings\Software.swfiles")

            Dim b As Byte() = Convert.FromBase64String(Reader)
            Reader = System.Text.Encoding.UTF8.GetString(b)
            b = Convert.FromBase64String(Reader)
            Reader = System.Text.Encoding.UTF8.GetString(b)

            Dim newlist As New List(Of String)
            For Each str As String In Reader.Split(";"c)
                If str.Trim().StartsWith(setting & "=") = True Then
                    Dim Name_Value As New List(Of String)
                    For Each s As String In str.Trim().Split("="c)
                        Name_Value.Add(s)
                    Next

                    Name_Value(1) = NewNameOrValue

                    str = Name_Value(0) & "=" & Name_Value(1)
                End If
                newlist.Add(str.Trim())
            Next

            Dim Reader2 As String = Nothing

            For Each str As String In newlist
                If Reader2 Is Nothing Then
                    Reader2 = str & ";"
                Else
                    Reader2 = Reader2 & "
" & str & ";"
                End If
            Next

            Reader2 = Reader2.Replace("
;", "")

            SaveUserSettings(Reader2)
        End If
    End Sub

    Public Function Contains(setting As String) As Boolean
        If My.Computer.FileSystem.FileExists(UserFolderPath & "\Settings\Software.swfiles") = False Then
            Return False
        End If

        Dim Reader As String = My.Computer.FileSystem.ReadAllText(UserFolderPath & "\Settings\Software.swfiles")

        Dim b As Byte() = Convert.FromBase64String(Reader)
        Reader = System.Text.Encoding.UTF8.GetString(b)
        b = Convert.FromBase64String(Reader)
        Reader = System.Text.Encoding.UTF8.GetString(b)

        Dim NewList As New List(Of String)

        For Each str As String In Reader.Split(";"c)
            NewList.Add(str)
        Next

        For Each str As String In NewList
            If str.Trim().StartsWith(setting & "=") = True Then
                If Environment.CommandLine().Contains("/DevMode") = True Then
                    Debug.WriteLine("Found: " & str.Trim())
                End If
                Return True
            Else
                If Environment.CommandLine().Contains("/DevMode") = True Then
                    Debug.WriteLine("Not It: " & str.Trim())
                End If
            End If
        Next

        'Returns False if doesn't find the setting.
        Return False
    End Function

    Public Function ReadSetting(setting As String) As String
        If My.Computer.FileSystem.FileExists(UserFolderPath & "\Settings\Software.swfiles") = False Then
            Return Nothing
        End If

        If Contains(setting) = False Then Return Nothing

        Dim Reader As String = My.Computer.FileSystem.ReadAllText(UserFolderPath & "\Settings\Software.swfiles")

        Dim b As Byte() = Convert.FromBase64String(Reader)
        Reader = System.Text.Encoding.UTF8.GetString(b)
        b = Convert.FromBase64String(Reader)
        Reader = System.Text.Encoding.UTF8.GetString(b)

        For Each str As String In Reader.Split(";"c)
            If str.Trim().StartsWith(setting & "=") = True Then
                Dim Name_Value As New List(Of String)
                For Each s As String In str.Trim().Split("="c)
                    Name_Value.Add(s)
                Next

                Return Name_Value(1)
            End If

        Next

        'I don't think that it can get here
        Return Nothing
    End Function

    Public Enum SettingType
        Add = 1
        Remove = 2
        NewSettingName = 3
        ChangeValue = 4
    End Enum

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

    ''' <summary>This is deprecated and no longer works.</summary>
    Public Shared Sub LoadWallpaperFromUserSettings()
    End Sub

    ''' <summary>This is deprecated and no longer works.</summary>
    Public Shared Sub CheckForDarkThemeFile()
    End Sub

    ''' <summary>This is deprecated and no longer works.</summary>
    Public Shared Sub LoadShellColors()
    End Sub

    ''' <summary>This is deprecated and no longer works.</summary>
    Public Shared Sub LoadTaskbarButtons()
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
                    Dim b As Byte() = Convert.FromBase64String(tempPassword)
                    tempPassword = System.Text.Encoding.UTF8.GetString(b)
                    b = Convert.FromBase64String(tempPassword)
                    tempPassword = System.Text.Encoding.UTF8.GetString(b)
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
