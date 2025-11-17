Namespace LogonFormThings
    Module Form48Data
        Public LogonUser As UserManager

        Public Sub SetupProgramUser()
            LogonUser = New UserManager("SuperSecretUser")
        End Sub

        Public Sub OpenLogonForm()
            'If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\Program\Temp\USW.mp4") Then
            'Else
            '    My.Computer.FileSystem.WriteAllBytes(UI.UsersFolder & "\Program\Temp\USW.mp4", My.Resources.TryOS_USW, False)
            'End If
            UI.DisableOpenFramework = True
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