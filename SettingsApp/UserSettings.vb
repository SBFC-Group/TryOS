Imports System.Windows.Forms

Public Class UserSettings
    Public UserList As New List(Of String)

    Public SelectedUserButton As Button

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
        ChangeDesign(Main.Controller.IsDarkMode())

        LoadUsers()
    End Sub

    Public Sub UserButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        SelectedUserButton = btn
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
                StandardRoleButton.Enabled = False
                AdministratorRoleButton.Enabled = False
            ElseIf TheRole = TouchTest.TryController.Roles.Standard Then
                StandardRoleButton.Enabled = False
                AdministratorRoleButton.Enabled = False
            Else
                StandardRoleButton.Enabled = False
                AdministratorRoleButton.Enabled = True
            End If
        ElseIf TheRole2 = TouchTest.TryController.Roles.Standard Then
            Label8.Text = "Role: Standard"
            If TheRole = TouchTest.TryController.Roles.Guest Then
                StandardRoleButton.Enabled = False
                AdministratorRoleButton.Enabled = False
            ElseIf TheRole = TouchTest.TryController.Roles.Standard Then
                StandardRoleButton.Enabled = False
                AdministratorRoleButton.Enabled = False
            Else
                StandardRoleButton.Enabled = False
                AdministratorRoleButton.Enabled = True
            End If

        ElseIf TheRole2 = TouchTest.TryController.Roles.Administrator Then

            Label8.Text = "Role: Administrator"
            StandardRoleButton.Enabled = True
            AdministratorRoleButton.Enabled = False
        ElseIf TheRole2 = TouchTest.TryController.Roles.Program Then
            Label8.Text = "Role: Program"
            StandardRoleButton.Enabled = True
            AdministratorRoleButton.Enabled = False
        ElseIf TheRole2 = TouchTest.TryController.Roles.Developer Then
            Label8.Text = "Role: Developer"
            StandardRoleButton.Enabled = True
            AdministratorRoleButton.Enabled = False
        End If

        SelectedUser = Usermanager

        SelectedRole = TheRole2

        If My.Computer.FileSystem.DirectoryExists(SelectedUser.UserFolderPath) Then
            If My.Computer.FileSystem.DirectoryExists(SelectedUser.UserFolderPath & "\Settings") Then
                If My.Computer.FileSystem.FileExists(SelectedUser.UserFolderPath & "\Settings\PinCode.swfiles") Then
                    NewPinCode = Getpiny_cody()
                Else
                    DeletePinCodeButton.Visible = False
                    NewPinCode = Nothing
                End If
            End If
        End If



        TextBox3.Text = GetPassy_wordy()

        If TextBox3.Text = "T_h_i_s_U_s_e_r_H_a_s_N_o_t_h_i_n_g" Then
            TextBox3.Text = ""
        End If


    End Sub

    Private Sub CreateUserButton_Click(sender As Object, e As EventArgs) Handles CreateUserButton.Click
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users") Then
            If My.Computer.FileSystem.DirectoryExists($"{My.Application.Info.DirectoryPath}\Users\{CreateUserNameTextBox.Text}") Then
                Main.Controller.ShowError("This User already exists.")
                'ElseIf My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users\Dev") Then
            Else
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
                    'Dim AppList As String = "Settings|ProgramInfo|TryOS_Store_New|Internet++"
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
                    'My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\ShowedAppsList.swfiles", AppList, False)

                End If
            End If
        End If
    End Sub

    Private Function GetRole(UserName As String) As TouchTest.TryController.Roles
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

    Public NewPinCode As String = Nothing
    Public PinCodeDialog As PinCodeDialog = New PinCodeDialog

    Private Sub ChangePinCodeButton_Click(sender As Object, e As EventArgs) Handles ChangePinCodeButton.Click
        Try
            PinCodeDialog.Username = SelectedUser.Username
            PinCodeDialog.ShowDialog()
            NewPinCode = PinCodeDialog.PinCode
        Catch ex As Exception
            PinCodeDialog = New PinCodeDialog
            PinCodeDialog.Username = SelectedUser.Username
            PinCodeDialog.ShowDialog()
            NewPinCode = PinCodeDialog.PinCode
        End Try
    End Sub

    Private Function GetPassy_wordy() As String
        If My.Computer.FileSystem.DirectoryExists(SelectedUser.UserFolderPath) Then
            If My.Computer.FileSystem.DirectoryExists(SelectedUser.UserFolderPath & "\Settings") Then
                If My.Computer.FileSystem.FileExists(SelectedUser.UserFolderPath & "\Settings\Password.swfiles") Then
                    Try
                        Dim pass As String = My.Computer.FileSystem.ReadAllText(SelectedUser.UserFolderPath & "\Settings\Password.swfiles")
                        Dim b As Byte() = Convert.FromBase64String(pass)
                        pass = System.Text.Encoding.UTF8.GetString(b)
                        b = Convert.FromBase64String(pass)
                        pass = System.Text.Encoding.UTF8.GetString(b)
                        Return pass
                    Catch ex As Exception
                        If Environment.CommandLine.Contains("/DevMode") = True Then
                            Debug.WriteLine(ex.Message)
                        End If
                    End Try
                End If
            End If
        End If
        Return Nothing
    End Function

    Private Function Getpiny_cody() As String
        If My.Computer.FileSystem.DirectoryExists(SelectedUser.UserFolderPath) Then
            If My.Computer.FileSystem.DirectoryExists(SelectedUser.UserFolderPath & "\Settings") Then
                If My.Computer.FileSystem.FileExists(SelectedUser.UserFolderPath & "\Settings\PinCode.swfiles") Then
                    Try
                        Dim pass As String = My.Computer.FileSystem.ReadAllText(SelectedUser.UserFolderPath & "\Settings\PinCode.swfiles")
                        Dim b As Byte() = Convert.FromBase64String(pass)
                        pass = System.Text.Encoding.UTF8.GetString(b)
                        b = Convert.FromBase64String(pass)
                        pass = System.Text.Encoding.UTF8.GetString(b)
                        Return pass
                    Catch ex As Exception
                        If Environment.CommandLine.Contains("/DevMode") = True Then
                            Debug.WriteLine(ex.Message)
                        End If
                    End Try
                End If
            End If
        End If
        Return Nothing
    End Function

    Private Sub ChangeUserButton_Click(sender As Object, e As EventArgs) Handles ChangeUserButton.Click
        Dim ChangedUserName As Boolean
        Dim ChangedPassword As Boolean
        Dim ChangedOrAddedPinCode As Boolean
        Dim ChangedRole As Boolean

        Dim Password As String = GetPassy_wordy()
        Dim pincode As String = Getpiny_cody()
        Dim role As TouchTest.TryController.Roles = GetRole(SelectedUser.Username)


        If SelectedUser.Username = TextBox4.Text Then
            ChangedUserName = False
        Else
            ChangedUserName = True
        End If

        If Password = TextBox3.Text Then
            ChangedPassword = False
        Else
            ChangedPassword = True
        End If

        If pincode = NewPinCode Then
            ChangedOrAddedPinCode = False
        Else
            ChangedOrAddedPinCode = True
        End If

        If role = SelectedRole Then
            ChangedRole = False
        Else
            ChangedRole = True
        End If

        'Username Changer
        If ChangedUserName = True Then
            ChangeUsername(SelectedUser.Username, TextBox4.Text)
        End If

        If ChangedPassword = True Then
            ChangePassword(SelectedUser.Username, Password, TextBox3.Text)
        End If

        If ChangedOrAddedPinCode = True Then
            ChangeOrCreatePinCode(SelectedUser.Username, pincode, NewPinCode)
        End If

        If ChangedRole = True Then
            ChangeRole(SelectedUser.Username, role, SelectedRole)
        End If
    End Sub

    Private Sub DeleteUserButton_Click(sender As Object, e As EventArgs) Handles DeleteUserButton.Click
        Dim DeleteUserDialog As New DeleteUserDialog
        If DeleteUserDialog.ShowDialog = DialogResult.Yes Then
            If My.Computer.FileSystem.DirectoryExists(SelectedUser.UserFolderPath) Then
                My.Computer.FileSystem.DeleteDirectory(SelectedUser.UserFolderPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                SelectedUserButton.Dispose()
                Panel3.Visible = False
            End If
        End If


    End Sub

    Private SelectedRole As TouchTest.TryController.Roles

    Private Sub StandardRoleButton_Click(sender As Object, e As EventArgs) Handles StandardRoleButton.Click
        SelectedRole = TouchTest.TryController.Roles.Standard

        StandardRoleButton.Enabled = False
        AdministratorRoleButton.Enabled = True
    End Sub

    Private Sub AdministratorRoleButton_Click(sender As Object, e As EventArgs) Handles AdministratorRoleButton.Click
        If Main.Controller.GetRole() = TouchTest.TryController.Roles.Standard Then
            Return
        ElseIf Main.Controller.GetRole() = TouchTest.TryController.Roles.Guest Then
            Return
        ElseIf Main.Controller.GetRole() = TouchTest.TryController.Roles.StandardSandbox Then
            Return
        End If

        SelectedRole = TouchTest.TryController.Roles.Administrator

        StandardRoleButton.Enabled = True
        AdministratorRoleButton.Enabled = False
    End Sub

    Private Sub ChangeUsername(CurrentUsername As String, NewUsername As String)
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users\" & CurrentUsername) = True Then
            If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users\" & NewUsername) = False Then
                Try

                Catch ex As Exception
                    If Environment.CommandLine.Contains("/DevMode") = True Then
                        Debug.WriteLine(ex.Message)
                    End If
                End Try
                My.Computer.FileSystem.RenameDirectory(My.Application.Info.DirectoryPath & "\Users\" & CurrentUsername, NewUsername)

                Label7.Text = "User: " & NewUsername

                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\LastKnownUser.setting") Then
                    Dim tempreader1 As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Settings\LastKnownUser.setting")
                    If tempreader1 = CurrentUsername Then
                        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\LastKnownUser.setting", NewUsername, False)
                    End If
                End If

                SelectedUserButton.Text = NewUsername

                SelectedUser = New TouchTest.UserManager(NewUsername)
            Else
                Main.Controller.ShowError("Username can't be changed to " & NewUsername & ". Because another user already has it.")
            End If
        End If
    End Sub

    Private Sub ChangePassword(Username As String, CurrentPassword As String, NewPassword As String)
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users\" & Username) = True Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Password.swfiles") Then
                If CurrentPassword = NewPassword Then
                ElseIf NewPassword = "" Then
                    NewPassword = "VkY5b1gybGZjMTlWWDNOZlpWOXlYMGhmWVY5elgwNWZiMTkwWDJoZmFWOXVYMmM9"
                Else
                    Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(NewPassword)
                    NewPassword = Convert.ToBase64String(byt)
                    byt = System.Text.Encoding.UTF8.GetBytes(NewPassword)
                    NewPassword = Convert.ToBase64String(byt)
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Password.swfiles", NewPassword, False)
                End If
            End If
        End If
    End Sub

    Private Sub ChangeOrCreatePinCode(Username As String, CurrentPinCode As String, NewPinCode As String)
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users\" & Username) = True Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Pincode.swfiles") Then
                If CurrentPinCode = NewPinCode Then
                Else
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Pincode.swfiles", NewPinCode, False)
                End If
            Else
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Pincode.swfiles", NewPinCode, False)
            End If
        End If
    End Sub

    Private Sub ChangeRole(Username As String, CurrentRole As TouchTest.TryController.Roles, NewRole As TouchTest.TryController.Roles)
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users\" & Username) = True Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Role.swfiles") Then
                If CurrentRole = NewRole Then
                ElseIf NewRole = TouchTest.TryController.Roles.Standard Then
                    'Sets Role to Standard.

                    Label8.Text = "Role: Standard"

                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Role.swfiles", "VkRCU1RrNUZNVFpXV0hCUVZrVnJPUT09", False)

                    SelectedUser = New TouchTest.UserManager(Username)
                ElseIf NewRole = TouchTest.TryController.Roles.Administrator Then
                    'Sets Role to Administrator.

                    Label8.Text = "Role: Administrator"

                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Role.swfiles", "Vkd0U1RrMXJNVFphZWtKUFlXdHJPUT09", False)

                    SelectedUser = New TouchTest.UserManager(Username)
                End If
            End If
        End If
    End Sub

    Private Sub DeletePinCodeButton_Click(sender As Object, e As EventArgs) Handles DeletePinCodeButton.Click
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users\" & SelectedUser.Username) = True Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & SelectedUser.Username & "\Settings\Pincode.swfiles") Then
                Try
                    My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Users\" & SelectedUser.Username & "\Settings\Pincode.swfiles")
                    DeletePinCodeButton.Visible = False
                Catch ex As Exception
                    If Environment.CommandLine.Contains("/DevMode") = True Then
                        Debug.WriteLine(ex.Message)
                    End If
                    Return
                End Try
            End If
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Main.Controller.IsDarkMode() = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Main.Controller.IsDarkMode() = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Drawing.Color.Gray
            Button1.BackColor = Drawing.Color.DarkGray
            CreateUserButton.BackColor = Drawing.Color.DarkGray
            ChangeUserButton.BackColor = Drawing.Color.DarkGray
            DeleteUserButton.BackColor = Drawing.Color.DarkGray
            ChangePinCodeButton.BackColor = Drawing.Color.DarkGray
            DeletePinCodeButton.BackColor = Drawing.Color.DarkGray
            UserButton0.BackColor = Drawing.Color.DarkGray
            CreateUserNameTextBox.BackColor = Drawing.Color.DarkGray
            CreatePasswordTextBox.BackColor = Drawing.Color.DarkGray
            TextBox3.BackColor = Drawing.Color.DarkGray
            TextBox4.BackColor = Drawing.Color.DarkGray
            StandardRoleButton.BackColor = Drawing.Color.DarkGray
            AdministratorRoleButton.BackColor = Drawing.Color.DarkGray

            For Each c As Control In FlowLayoutPanel1.Controls
                c.BackColor = UserButton0.BackColor
            Next
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Drawing.Color.DarkGray
            Button1.BackColor = Drawing.Color.Gainsboro
            CreateUserButton.BackColor = Drawing.Color.Gainsboro
            ChangeUserButton.BackColor = Drawing.Color.Gainsboro
            DeleteUserButton.BackColor = Drawing.Color.Gainsboro
            ChangePinCodeButton.BackColor = Drawing.Color.Gainsboro
            DeletePinCodeButton.BackColor = Drawing.Color.Gainsboro
            UserButton0.BackColor = Drawing.Color.Gainsboro
            CreateUserNameTextBox.BackColor = Drawing.Color.Gainsboro
            CreatePasswordTextBox.BackColor = Drawing.Color.Gainsboro
            TextBox3.BackColor = Drawing.Color.Gainsboro
            TextBox4.BackColor = Drawing.Color.Gainsboro
            StandardRoleButton.BackColor = Drawing.Color.Gainsboro
            AdministratorRoleButton.BackColor = Drawing.Color.Gainsboro

            For Each c As Control In FlowLayoutPanel1.Controls
                c.BackColor = UserButton0.BackColor
            Next
        End If
    End Sub
End Class
