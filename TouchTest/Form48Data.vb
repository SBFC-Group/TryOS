Namespace LogonFormThings
    Module Form48Data
        Public LogonUser As UserManager

        Public Sub SetupProgramUser()
            If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\SuperSecretUser") = False Then
                UserInfoHelper.CreateNewUser("SuperSecretUser", "", "")
                System.Threading.Thread.Sleep(500)
                My.Computer.FileSystem.DeleteFile(UI.UsersFolder & "\SuperSecretUser\Settings\Role.swfiles")
                My.Computer.FileSystem.DeleteFile(UI.UsersFolder & "\SuperSecretUser\Settings\Password.swfiles")
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\SuperSecretUser\Settings\Role.swfiles", "VkZod2NrMUZOVlZYVkVaUFVrVXdPUT09", False)
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\SuperSecretUser\Settings\Password.swfiles", "VG05UVlYTnpkMjl5WkE9PQ==", False)
            End If
            Form1.User = New UserManager("SuperSecretUser")
            LogonUser = New UserManager("SuperSecretUser")
        End Sub

        Public Sub OpenLogonForm()
            UI.DisableOpenFramework = True
            If My.Computer.FileSystem.FileExists(LogonUser.UserFolderPath & "\Settings\AllowCustom.swfiles") Then
                UI.DisableCustomCode = False
            Else
                UI.DisableCustomCode = True
            End If
            Form1.AllowNewerLoader = False
            UI.LoadShell("SuperSecretUser", "")
            Form1.HideTaskbar(True)
            Form1.OpenChildForm(New LogonForm)
            Form1.DisableConsole = True

        End Sub

        Public Sub CloseLogonForm()
            Try
                If Form1.currentForm.Text = "LogonForm" Then
                    Form1.currentForm.Close()
                    Form1.Close()

                    If Environment.CommandLine.Contains("/TurnOff_VerifyedShellOnly") = True Then
                        Form1.AllowOnlyVerifyedShellCode = False
                    End If

                    UI.LogonBool = False
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Module
End Namespace