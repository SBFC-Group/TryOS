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
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\Program\Settings\Software.swfiles", "U1hORVlYSnJUVzlrWlVadmNrRndjSE05Um1Gc2MyVTdDa2x6UkdGeWEwMXZaR1ZHYjNKUWNtOW5jbUZ0UFVaaGJITmxPd3BKYzFWemFXNW5UbVYzWlhKWFlXeHNjR0Z3WlhKTWIyRmtaWEk5VkhKMVpUc0tSRzlsYzBoaGMxUnBiV1ZDWVhJOVJtRnNjMlU3Q2tselZISmhibk53WVhKbGJuUkZibUZpYkdWa1BVWmhiSE5sT3c9PQ==", False)
            End If

            If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\SuperSecretUser\Settings\Software.swfiles") = False Then
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\SuperSecretUser\Settings\Software.swfiles", "U1hORVlYSnJUVzlrWlVadmNrRndjSE05Um1Gc2MyVTdDa2x6UkdGeWEwMXZaR1ZHYjNKUWNtOW5jbUZ0UFVaaGJITmxPd3BKYzFWemFXNW5UbVYzWlhKWFlXeHNjR0Z3WlhKTWIyRmtaWEk5VkhKMVpUc0tSRzlsYzBoaGMxUnBiV1ZDWVhJOVJtRnNjMlU3Q2tselZISmhibk53WVhKbGJuUkZibUZpYkdWa1BVWmhiSE5sT3c9PQ==", False)
            End If

            Form1.User = TryController.Resuteg(TryController.CoreID)
            LogonUser = TryController.Resuteg(TryController.CoreID)
        End Sub

        Public Sub OpenLogonForm()
            UI.DisableOpenFramework = True
            If My.Computer.FileSystem.FileExists(LogonUser.UserFolderPath & "\Settings\AllowCustom.swfiles") = True Then
                UI.DisableCustomCode = False
            Else
                UI.DisableCustomCode = True
            End If
            'Form1.AllowNewerLoader = False
            UI.LoadShell("SuperSecretUser", "")
            Form1.EnableFullAppMode(True)
            Form1.UseNewerAppViewer = False
            Form1.OpenChildForm(New LogonForm)
            Form1.DisableConsole = True

            Form2.Close()

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
                If Environment.CommandLine.Contains("/DevMode") Then
                    Debug.WriteLine(ex.Message)
                End If
            End Try

        End Sub
    End Module
End Namespace