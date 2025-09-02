Public Class UserSettingsApp

    Private Sub UserSettingsApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    Public UserToChange As String = ""
    Public User As Integer = 1

    Private Sub LoadUsers()
        Dim dir1 = UI.UsersFolder
        Dim files() As System.IO.DirectoryInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            Label3.Text = Label3.Text & file.Name & Environment.NewLine
            If User = 1 Then
                UserButton1.Text = file.Name
                UserButton1.Visible = True
                User = 2
            ElseIf User = 2 Then
                UserButton2.Text = file.Name
                UserButton2.Visible = True
                User = 3
            ElseIf User = 3 Then
                UserButton3.Text = file.Name
                UserButton3.Visible = True
                User = 4
            ElseIf User = 4 Then
                UserButton4.Text = file.Name
                UserButton4.Visible = True
                User = 5
            ElseIf User = 5 Then
                UserButton5.Text = file.Name
                UserButton5.Visible = True
                User = 6
            ElseIf User = 6 Then
                UserButton6.Text = file.Name
                UserButton6.Visible = True
                User = 7
            ElseIf User = 7 Then
                UserButton7.Text = file.Name
                UserButton7.Visible = True
                User = 8
            ElseIf User = 8 Then
                UserButton8.Text = file.Name
                UserButton8.Visible = True
                User = 9
            ElseIf User = 9 Then
                UserButton9.Text = file.Name
                UserButton9.Visible = True
                User = 10
            ElseIf User = 10 Then
                UserButton10.Text = file.Name
                UserButton10.Visible = True
                User = 11
            ElseIf User = 11 Then
                UserButton11.Text = file.Name
                UserButton11.Visible = True
                User = 12
            ElseIf User = 12 Then
                UserButton12.Text = file.Name
                UserButton12.Visible = True
                User = 13
            Else

            End If
        Next
        If User = 1 Then
        ElseIf User = 2 Then
            UserButton3.Visible = False
            UserButton4.Visible = False
            UserButton5.Visible = False
            UserButton6.Visible = False
            UserButton7.Visible = False
            UserButton8.Visible = False
            UserButton9.Visible = False
            UserButton10.Visible = False
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 3 Then
            UserButton4.Visible = False
            UserButton5.Visible = False
            UserButton6.Visible = False
            UserButton7.Visible = False
            UserButton8.Visible = False
            UserButton9.Visible = False
            UserButton10.Visible = False
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 4 Then
            UserButton5.Visible = False
            UserButton6.Visible = False
            UserButton7.Visible = False
            UserButton8.Visible = False
            UserButton9.Visible = False
            UserButton10.Visible = False
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 5 Then
            UserButton6.Visible = False
            UserButton7.Visible = False
            UserButton8.Visible = False
            UserButton9.Visible = False
            UserButton10.Visible = False
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 6 Then
            UserButton7.Visible = False
            UserButton8.Visible = False
            UserButton9.Visible = False
            UserButton10.Visible = False
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 7 Then
            UserButton8.Visible = False
            UserButton9.Visible = False
            UserButton10.Visible = False
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 8 Then
            UserButton9.Visible = False
            UserButton10.Visible = False
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 9 Then
            UserButton10.Visible = False
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 10 Then
            UserButton11.Visible = False
            UserButton12.Visible = False
        ElseIf User = 11 Then
            UserButton12.Visible = False
        ElseIf User = 12 Then
        End If
        User = 1
    End Sub

    Public Sub LoadUser(Text_ As String)
        If Form1.Username = Text_ Then
        Else
            Dim MyRole As TryController.Roles = Form1.GetRole()
            If MyRole = TryController.Roles.Guest Then
                Exit Sub
            ElseIf MyRole = TryController.Roles.Standard Then
                Exit Sub
            ElseIf MyRole = TryController.Roles.Administrator Then
            ElseIf MyRole = TryController.Roles.Program Then
            ElseIf MyRole = TryController.Roles.Developer Then
            End If
        End If

        Dim MyRole2 As TryController.Roles = Form1.GetRole()
        If MyRole2 = TryController.Roles.Guest Then
            Panel5.Visible = False
        ElseIf MyRole2 = TryController.Roles.Standard Then
            Panel5.Visible = False
        Else
            Panel5.Visible = True
        End If

        UserToChange = Text_
        Panel3.Visible = True
        Label7.Text = "User: " & Text_
        TextBox4.Text = UserToChange
        TextBox3.Text = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & UserToChange & "\Settings\Password.swfiles")


        Dim TheRole As TryController.Roles = GetRole(Text_)
        If TheRole = TryController.Roles.Guest Then
            Label8.Text = "Role: Guest"

            If MyRole2 = TryController.Roles.Guest Then
                Button11.Enabled = False
                Button12.Enabled = False
            ElseIf MyRole2 = TryController.Roles.Standard Then
                Button11.Enabled = False
                Button12.Enabled = False
            Else
                Button11.Enabled = False
                Button12.Enabled = True
            End If
        ElseIf TheRole = TryController.Roles.Standard Then
            Label8.Text = "Role: Standard"
            If MyRole2 = TryController.Roles.Guest Then
                Button11.Enabled = False
                Button12.Enabled = False
            ElseIf MyRole2 = TryController.Roles.Standard Then
                Button11.Enabled = False
                Button12.Enabled = False
            Else
                Button11.Enabled = False
                Button12.Enabled = True
            End If

        ElseIf TheRole = TryController.Roles.Administrator Then

            Label8.Text = "Role: Administrator"
            Button11.Enabled = True
            Button12.Enabled = False
        ElseIf TheRole = TryController.Roles.Program Then
            Label8.Text = "Role: Program"
            Button11.Enabled = True
            Button12.Enabled = False
        ElseIf TheRole = TryController.Roles.Developer Then
            Label8.Text = "Role: Developer"
            Button11.Enabled = True
            Button12.Enabled = False
        End If
        Try
            Dim b As Byte() = Convert.FromBase64String(TextBox3.Text)
            TextBox3.Text = System.Text.Encoding.UTF8.GetString(b)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit ")
        End Try
        Try
            Dim b As Byte() = Convert.FromBase64String(TextBox3.Text)
            TextBox3.Text = System.Text.Encoding.UTF8.GetString(b)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit ")
        End Try
        If TextBox3.Text = "T_h_i_s_U_s_e_r_H_a_s_N_o_t_h_i_n_g" Then
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles UserButton1.Click, UserButton2.Click, UserButton3.Click, UserButton4.Click, UserButton5.Click, UserButton6.Click, UserButton7.Click, UserButton8.Click, UserButton9.Click, UserButton10.Click, UserButton11.Click, UserButton12.Click
        LoadUser(sender.Text)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\" & TextBox4.Text) Then
            My.Computer.FileSystem.DeleteFile(UI.UsersFolder & "\" & TextBox4.Text & "\Settings\Password.swfiles")
            Dim df As String = TextBox3.Text
            'Encodes New Password
            If df = "" Then
                df = "VkY5b1gybGZjMTlWWDNOZlpWOXlYMGhmWVY5elgwNWZiMTkwWDJoZmFWOXVYMmM9"
            Else
                Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(df)
                df = Convert.ToBase64String(byt)
                Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(df)
                df = Convert.ToBase64String(byt2)
            End If

            Dim TheRole1 As TryController.Roles = GetRole(TextBox4.Text)
            If TheRole1 = TryController.Roles.Guest Then
            ElseIf TheRole1 = TryController.Roles.Standard Then
            Else
                If Button11.Enabled = False Then
                    'Sets Role to Standard.

                    My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox4.Text & "\Settings\Role.swfiles", "VkRCU1RrNUZNVFpXV0hCUVZrVnJPUT09", False)
                ElseIf Button12.Enabled = False Then
                    'Sets Role to Administrator.

                    My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox4.Text & "\Settings\Role.swfiles", "Vkd0U1RrMXJNVFphZWtKUFlXdHJPUT09", False)
                End If
            End If


            'Writes Password File
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox4.Text & "\Settings\Password.swfiles", df, False)
            UI.UserFolder = UI.UsersFolder & "\" & TextBox4.Text
        Else

            'Renames User
            My.Computer.FileSystem.RenameDirectory(UI.UsersFolder & "\" & UserToChange, TextBox4.Text)

            'Changes the string to stop errors.
            UserToChange = TextBox4.Text

            'Let's Program sleep for 2 sec's
            System.Threading.Thread.Sleep(2000)

            'Deletes old Password File
            My.Computer.FileSystem.DeleteFile(UI.UsersFolder & "\" & TextBox4.Text & "\Settings\Password.swfiles")
            Dim df As String = TextBox3.Text

            'Encodes New Password
            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(df)
            df = Convert.ToBase64String(byt)
            Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(df)
            df = Convert.ToBase64String(byt2)

            If Button11.Enabled = False Then
                'Sets Role to Standard.

                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox4.Text & "\Settings\Role.swfiles", "VkRCU1RrNUZNVFpXV0hCUVZrVnJPUT09", False)
            ElseIf Button12.Enabled = False Then
                'Sets Role to Administrator.

                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox4.Text & "\Settings\Role.swfiles", "Vkd0U1RrMXJNVFphZWtKUFlXdHJPUT09", False)
            End If

            'Writes Password File
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox4.Text & "\Settings\Password.swfiles", df, False)
            UI.UserFolder = UI.UsersFolder & "\" & TextBox4.Text
        End If
        LoadUsers()

        Dim TheRole As TryController.Roles = GetRole(TextBox4.Text)
        If TheRole = TryController.Roles.Guest Then
            Label8.Text = "Role: Guest"
            Button11.Enabled = True
            Button12.Enabled = True
        ElseIf TheRole = TryController.Roles.Standard Then
            Label8.Text = "Role: Standard"
            Button11.Enabled = False
            Button12.Enabled = True
        ElseIf TheRole = TryController.Roles.Administrator Then
            Label8.Text = "Role: Administrator"
            Button11.Enabled = True
            Button12.Enabled = False
        ElseIf TheRole = TryController.Roles.Program Then
            Label8.Text = "Role: Program"
            Button11.Enabled = True
            Button12.Enabled = False
        ElseIf TheRole = TryController.Roles.Developer Then
            Label8.Text = "Role: Developer"
            Button11.Enabled = True
            Button12.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Do you want to delete this User?", MsgBoxStyle.YesNo, "Settings") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteDirectory(UI.UsersFolder & "\" & UserToChange, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)

            Panel3.Visible = False

            LoadUsers()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\" & TextBox1.Text) Then
            MsgBox("This User already exists.")
        ElseIf My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\Dev") Then
            MsgBox("This User is not allowed.")
        Else
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text)
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Apps")
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Settings")
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Temp")

            Dim ReaderForPassword As String = TextBox2.Text



            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
            ReaderForPassword = Convert.ToBase64String(byt)
            Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
            ReaderForPassword = Convert.ToBase64String(byt2)

            If TextBox2.Text = "" Then
                ReaderForPassword = "VkY5b1gybGZjMTlWWDNOZlpWOXlYMGhmWVY5elgwNWZiMTkwWDJoZmFWOXVYMmM9"
            End If

            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Password.swfiles", ReaderForPassword, False)
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Role.swfiles", "VkRCU1RrNUZNVFpXV0hCUVZrVnJPUT09", False)
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Wallpaper.swfiles", "jpg=1", False)

            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Apps\Internet++.swfiles", "", False)
        End If

        LoadUsers()
    End Sub

    Public Function GetRole(UserName As String) As TryController.Roles
        If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & UserName & "\Settings\Role.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & UserName & "\Settings\Role.swfiles")
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

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Button11.Enabled = False
        Button12.Enabled = True
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Button11.Enabled = True
        Button12.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Form1.IsUsingDarkThemeForApps = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Color.Gray
            Button1.BackColor = Color.DarkGray
            Button2.BackColor = Color.DarkGray
            Button10.BackColor = Color.DarkGray
            Button11.BackColor = Color.DarkGray
            Button12.BackColor = Color.DarkGray
            UserButton1.BackColor = Color.DarkGray
            UserButton2.BackColor = Color.DarkGray
            UserButton3.BackColor = Color.DarkGray
            UserButton4.BackColor = Color.DarkGray
            UserButton5.BackColor = Color.DarkGray
            UserButton6.BackColor = Color.DarkGray
            UserButton7.BackColor = Color.DarkGray
            UserButton8.BackColor = Color.DarkGray
            UserButton9.BackColor = Color.DarkGray
            UserButton10.BackColor = Color.DarkGray
            UserButton11.BackColor = Color.DarkGray
            UserButton12.BackColor = Color.DarkGray
            TextBox1.BackColor = Color.DarkGray
            TextBox2.BackColor = Color.DarkGray
            TextBox3.BackColor = Color.DarkGray
            TextBox4.BackColor = Color.DarkGray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray
            Button1.BackColor = Color.Gainsboro
            Button2.BackColor = Color.Gainsboro
            Button10.BackColor = Color.Gainsboro
            Button11.BackColor = Color.Gainsboro
            Button12.BackColor = Color.Gainsboro
            UserButton1.BackColor = Color.Gainsboro
            UserButton2.BackColor = Color.Gainsboro
            UserButton3.BackColor = Color.Gainsboro
            UserButton4.BackColor = Color.Gainsboro
            UserButton5.BackColor = Color.Gainsboro
            UserButton6.BackColor = Color.Gainsboro
            UserButton7.BackColor = Color.Gainsboro
            UserButton8.BackColor = Color.Gainsboro
            UserButton9.BackColor = Color.Gainsboro
            UserButton10.BackColor = Color.Gainsboro
            UserButton11.BackColor = Color.Gainsboro
            UserButton12.BackColor = Color.Gainsboro
            TextBox1.BackColor = Color.Gainsboro
            TextBox2.BackColor = Color.Gainsboro
            TextBox3.BackColor = Color.Gainsboro
            TextBox4.BackColor = Color.Gainsboro
        End If
    End Sub
End Class
