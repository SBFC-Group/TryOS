Imports System.Windows.Forms

Public Class UserSettings
    Public UserList As New List(Of String)

    Public SelectedUser As TouchTest.UserManager

    Public Sub LoadUsers()
        Dim FirstUserButtonWasCreated As Boolean = False
        Dim UsersFolder = My.Application.Info.DirectoryPath & "\Users"
        Dim files() As System.IO.DirectoryInfo
        Dim dirinfo As New System.IO.DirectoryInfo(UsersFolder)
        files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            'Checks if the user is disabled
            Dim UserMode As String = Nothing
            If My.Computer.FileSystem.FileExists(UsersFolder & "\" & file.Name & "\Settings\UserMode.swfiles") Then
                UserMode = My.Computer.FileSystem.ReadAllText(UsersFolder & "\" & file.Name & "\Settings\UserMode.swfiles")
            End If
            If UserMode = "UserMode=Disabled" Then
            Else

                Dim NewUserButton As New Button
                NewUserButton.FlatStyle = FlatStyle.Flat
                NewUserButton.Size = UserButton0.Size
                NewUserButton.Font = UserButton0.Font
                NewUserButton.BackColor = UserButton0.BackColor
                NewUserButton.Text = file.Name
                NewUserButton.Tag = New TouchTest.UserManager(file.Name, False)
                AddHandler NewUserButton.Click, AddressOf UserButton_Click
                If FirstUserButtonWasCreated = True Then
                    FlowLayoutPanel1.Size = New Drawing.Size(FlowLayoutPanel1.Width, FlowLayoutPanel1.Height + NeedThisPanel.Height)
                Else
                    FirstUserButtonWasCreated = True
                End If
                FlowLayoutPanel1.Controls.Add(NewUserButton)
            End If

        Next
    End Sub

    Private Sub UserSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    Public Sub UserButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim Usermanager As TouchTest.UserManager = CType(btn.Tag, TouchTest.UserManager)

        Dim TheRole As TouchTest.TryController.Roles = Main.Controller.GetRole()

        If Main.Controller.GetUsername = Usermanager.Username Then
        Else
            If TheRole = TouchTest.TryController.Roles.Developer Then
            ElseIf TheRole = TouchTest.TryController.Roles.Program Then
            ElseIf TheRole = TouchTest.TryController.Roles.Administrator Then
            Else
                Exit Sub
            End If
        End If

        If TheRole = TouchTest.TryController.Roles.Developer Then
        ElseIf TheRole = TouchTest.TryController.Roles.Program Then
        ElseIf TheRole = TouchTest.TryController.Roles.Administrator Then
        Else
            Panel5.Visible = False
        End If

        'Will Show the user change page
        Panel3.Visible = True

        Label7.Text = "User: " & Usermanager.Username
        TextBox4.Text = Usermanager.Username
        TextBox3.Text = My.Computer.FileSystem.ReadAllText(Usermanager.UserFolderPath & "\Settings\Password.swfiles")


        Dim TheRole2 As TouchTest.TryController.Roles = GetRole(Usermanager.Username)
        If TheRole2 = TouchTest.TryController.Roles.Guest Then
            Label8.Text = "Role: Guest"

            If TheRole = TouchTest.TryController.Roles.Guest Then
                Button11.Enabled = False
                Button12.Enabled = False
            ElseIf TheRole = TouchTest.TryController.Roles.Standard Then
                Button11.Enabled = False
                Button12.Enabled = False
            Else
                Button11.Enabled = False
                Button12.Enabled = True
            End If
        ElseIf TheRole2 = TouchTest.TryController.Roles.Standard Then
            Label8.Text = "Role: Standard"
            If TheRole = TouchTest.TryController.Roles.Guest Then
                Button11.Enabled = False
                Button12.Enabled = False
            ElseIf TheRole = TouchTest.TryController.Roles.Standard Then
                Button11.Enabled = False
                Button12.Enabled = False
            Else
                Button11.Enabled = False
                Button12.Enabled = True
            End If

        ElseIf TheRole2 = TouchTest.TryController.Roles.Administrator Then

            Label8.Text = "Role: Administrator"
            Button11.Enabled = True
            Button12.Enabled = False
        ElseIf TheRole2 = TouchTest.TryController.Roles.Program Then
            Label8.Text = "Role: Program"
            Button11.Enabled = True
            Button12.Enabled = False
        ElseIf TheRole2 = TouchTest.TryController.Roles.Developer Then
            Label8.Text = "Role: Developer"
            Button11.Enabled = True
            Button12.Enabled = False
        End If

        Try
            Dim b As Byte() = Convert.FromBase64String(TextBox3.Text)
            TextBox3.Text = System.Text.Encoding.UTF8.GetString(b)
        Catch ex As Exception
            Main.Controller.ShowError(ex.Message, TouchTest.ErrorMSGBox.Alerts.Critical)
        End Try
        Try
            Dim b As Byte() = Convert.FromBase64String(TextBox3.Text)
            TextBox3.Text = System.Text.Encoding.UTF8.GetString(b)
        Catch ex As Exception
            Main.Controller.ShowError(ex.Message, TouchTest.ErrorMSGBox.Alerts.Critical)
        End Try
        If TextBox3.Text = "T_h_i_s_U_s_e_r_H_a_s_N_o_t_h_i_n_g" Then
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub CreateUserButton_Click(sender As Object, e As EventArgs) Handles CreateUserButton.Click
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users") Then
            If My.Computer.FileSystem.DirectoryExists($"{My.Application.Info.DirectoryPath}\Users\{CreateUserNameTextBox.Text}") Then
                Main.Controller.ShowError("This User already exists.")
            ElseIf My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users\Dev") Then
                If CreateUserNameTextBox.Text = "SuperSecretUser" Then
                    Main.Controller.ShowError("This Username is not allowed.")
                ElseIf CreateUserNameTextBox.Text = "Dev" Then
                    Main.Controller.ShowError("This Username is not allowed.")
                Else
                    Dim UserFolder As String = My.Application.Info.DirectoryPath & "\Users\" & CreateUserNameTextBox.Text

                    My.Computer.FileSystem.CreateDirectory(UserFolder)
                    'No need for Apps Folder anymore. But users with the Apps folder will still have it.
                    'My.Computer.FileSystem.CreateDirectory(UserFolder & "\Apps")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Downloads")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Pictures")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Settings")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Videos")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Temp")
                    'More secure way of storing the webview2 data. (Currently doesn't work.)
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Data")

                    Dim Role As String = "VkRCU1RrNUZNVFpXV0hCUVZrVnJPUT09"
                    Dim Software_Config As String = "VjJGc2JIQmhjR1Z5UFdwd1p6MHhPd3BKYzBSaGNtdE5iMlJsUm05eVFYQndjejFHWVd4elpUc0tTWE5WYzJsdVowNWxkMlZ5VjJGc2JIQmhjR1Z5VEc5aFpHVnlQVlJ5ZFdVNw=="
                    Dim UserVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Build.ToString & "." & My.Application.Info.Version.Revision.ToString
                    Dim AppList As String = "Settings|ProgramInfo|TryOS_Store_New|Internet++"
                    Dim ReaderForPassword As String = CreatePasswordTextBox.Text

                    If CreatePasswordTextBox.Text = "" Then
                        ReaderForPassword = "VkY5b1gybGZjMTlWWDNOZlpWOXlYMGhmWVY5elgwNWZiMTkwWDJoZmFWOXVYMmM9"
                    Else
                        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
                        ReaderForPassword = Convert.ToBase64String(byt)
                        Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
                        ReaderForPassword = Convert.ToBase64String(byt2)
                    End If

                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\Password.swfiles", ReaderForPassword, False)
                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\Role.swfiles", Role, False)
                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\Software.swfiles", Software_Config, False)
                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\UserVersion.swfiles", UserVersion, False)
                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\ShowedAppsList.swfiles", AppList, False)

                End If
            End If
        End If
    End Sub

    Public Function GetRole(UserName As String) As TouchTest.TryController.Roles
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & UserName & "\Settings\Role.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Users\" & UserName & "\Settings\Role.swfiles")
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
                Return TouchTest.TryController.Roles.Guest
            ElseIf Reader = "83835392" Then
                Return TouchTest.TryController.Roles.Standard
            ElseIf Reader = "43638462" Then
                Return TouchTest.TryController.Roles.Administrator
            ElseIf Reader = "39456543" Then
                Return TouchTest.TryController.Roles.Program
            ElseIf Reader = "19563469" Then
                Return TouchTest.TryController.Roles.Developer
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function
End Class
