Namespace LogonFormThings
    Module Form48Data
        Public LogonUser As UserManager

        Public Sub SetupProgramUser()
            If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\SuperSecretUser") Then
            Else
                UserInfoHelper.CreateNewUser("SuperSecretUser", "", "")
                System.Threading.Thread.Sleep(500)
                My.Computer.FileSystem.DeleteFile(UI.UsersFolder & "\SuperSecretUser\Settings\Role.swfiles")
                My.Computer.FileSystem.DeleteFile(UI.UsersFolder & "\SuperSecretUser\Settings\Password.swfiles")
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\SuperSecretUser\Settings\Role.swfiles", "VkZod2NrMUZOVlZYVkVaUFVrVXdPUT09", False)
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\SuperSecretUser\Settings\Password.swfiles", "VG05UVlYTnpkMjl5WkE9PQ==", False)
            End If
            LogonUser = New UserManager("SuperSecretUser")
        End Sub

        Public Sub OpenLogonForm()
            UI.DisableOpenFramework = True
            UI.DisableCustomCode = True
            Form1.AllowNewerLoader = False
            UI.UserFolder = UI.UsersFolder & "\SuperSecretUser"
            Form1.Username = "SuperSecretUser"
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
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Module
End Namespace