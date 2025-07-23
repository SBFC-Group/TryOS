Namespace UUWThings
    Module UUWData
        'User Update Window = UUW


        Public HasBeenOpened As Boolean = False

        Public Sub SetupUUWUser()
            If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\Program") Then
            ElseIf My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\Dev") Then
                MsgBox("This User is not allowed.")
            Else
                If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder) Then
                Else
                    My.Computer.FileSystem.CreateDirectory(UI.UsersFolder)
                End If
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program")
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program\Apps")
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program\Settings")
                My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\Program\Temp")

                Dim ReaderForPassword As String = ""

                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\Program\Settings\Password.swfiles", ReaderForPassword, False)
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\Program\Settings\Role.swfiles", "VkRCU1RrNUZNVFpXV0hCUVZrVnJPUT09", False)
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\Program\Settings\Wallpaper.swfiles", "jpg=1", False)

                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\Program\Apps\Internet++.swfiles", "", False)
            End If
        End Sub

        Public Sub RemoveUUWUser()
            My.Computer.FileSystem.DeleteDirectory(UI.UsersFolder & "\Program", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End Sub

        Public Sub OpenUUW()
            UI.LoadShell("Program", "")
            Form1.HideTaskbar(True)
            Form1.OpenChildForm(New UUWApp)
        End Sub

        Public Sub CloseUUW()
            Try
                If Form1.currentForm.Text = "UUWApp" Then
                    Form1.currentForm.Close()
                    Form1.Close()
                    If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\ShellName.setting") Then
                        My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\ShellName.setting", "TouchTest.Form48", False)
                    End If
                    Application.Restart()
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Module
End Namespace