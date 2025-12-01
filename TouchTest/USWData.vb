Namespace USWThings
    Module USWData
        Public HasBeenOpened As Boolean = False

        Public Sub SetupUSWUser()
            If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\Program") Then
            ElseIf My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\Dev") Then
                'MsgBox("This User is not allowed.")
                UI.ShowError("This User is not allowed.")
            Else
                If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder) Then
                Else
                    My.Computer.FileSystem.CreateDirectory(UI.UsersFolder)
                End If
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program")
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program\Apps")
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program\Settings")
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program\Downloads")
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program\Pictures")
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program\Temp")

                Dim ReaderForPassword As String = ""

                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\Program\Settings\Password.swfiles", ReaderForPassword, False)
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\Program\Settings\Role.swfiles", "VkRCU1RrNUZNVFpXV0hCUVZrVnJPUT09", False)
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\Program\Settings\Wallpaper.swfiles", "jpg=1", False)
            End If


        End Sub

        Public Sub RemoveUSWUser()
            My.Computer.FileSystem.DeleteDirectory(UI.UsersFolder & "\Program", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End Sub

        Public Sub OpenUSW()
            If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\Program\Temp\USW.mp4") Then
            Else
                My.Computer.FileSystem.WriteAllBytes(UI.UsersFolder & "\Program\Temp\USW.mp4", My.Resources.TryOS_USW, False)
            End If
            Form1.AllowNewerLoader = False
            UI.DisableOpenFramework = True
            UI.LoadShell("Program", "")
            Form1.HideTaskbar(True)
            Form1.OpenChildForm(New USWApp)
            Form1.DisableConsole = True
        End Sub

        Public Sub CloseUSW()
            Try
                If Form1.currentForm.Text = "USWApp" Then
                    Form1.currentForm.Close()
                    Form1.Close()
                    If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\ShellName.setting") Then
                        My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\ShellName.setting", "TouchTest.LogonForm", False)
                    End If
                    RemoveUSWUser()
                    Application.Restart()
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Module
End Namespace