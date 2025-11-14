Namespace Form48_Things
    Module Form48Data
        Public HasBeenOpened As Boolean = False

        Public Sub OpenLogonPage()
            UI.DisableOpenFramework = True
            UI.LoadShell("SuperSecretUser", "")
            Form1.HideTaskbar(True)
            Form1.OpenChildForm(New Form48)
            Form1.DisableFullScreenConsole = True
        End Sub

        Public Sub CloseUSW()
            Try
                If Form1.currentForm.Text = "LogonScreen" Then
                    Form1.currentForm.Close()
                    Form1.Close()
                    UI.UserFolder = UI.UsersFolder & "\"
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Module
End Namespace