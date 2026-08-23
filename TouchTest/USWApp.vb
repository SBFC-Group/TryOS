Public Class USWApp
    Private Sub USWApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If USWThings.HasBeenOpened = True Then
            Panel3.Visible = False
            If My.Computer.FileSystem.DirectoryExists(UI.SettingsFolder) Then
                If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LogonWallpaper.setting") Then
                    UI.RunCommands("SetWallpaper " & UI.WallpaperFolder & "\" & My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\LogonWallpaper.setting"), Form1.User)
                End If
            End If

            AxWindowsMediaPlayer1.Dock = DockStyle.Fill
            AxWindowsMediaPlayer1.uiMode = "none"
            AxWindowsMediaPlayer1.URL = UI.UsersFolder & "\Program\Temp\USW.mp4"
            StartMainTimer.Start()
        Else
            USWThings.HasBeenOpened = True
            USWThings.SetupUSWUser()
            USWThings.OpenUSW()
            Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles StartMainTimer.Tick
        StartMainTimer.Stop()
        'Hides "AxWindowsMediaPlayer1".
        AxWindowsMediaPlayer1.Visible = False

        'Configs Form layout.
        Panel3.Visible = True
        Panel3.BackgroundImage = Form1.Panel1.BackgroundImage
        SetupPanel.BackColor = Color.FromArgb(55, Color.DarkGray)
        'SetupPanel.Dock = DockStyle.Fill
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UI.RunCommands("end", Form1.User)
    End Sub

    Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick
        If CheckBox1.Checked = True Then
            If TextBox2.UseSystemPasswordChar = False Then
            Else
                TextBox2.UseSystemPasswordChar = False
            End If
        ElseIf CheckBox1.Checked = False Then
            If TextBox2.UseSystemPasswordChar = True Then
            Else
                TextBox2.UseSystemPasswordChar = True
            End If

        End If
    End Sub

    Public Pincode As String = "None"

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Remove Pincode" Then
            Pincode = "None"
            Button4.Text = "Create Pincode"
        Else
            If TextBox1.Text = "" Then
                'Pincode needs a Username
            Else
                If TextBox2.Text = "" Then
                    'Pincode needs a Password
                Else
                    TextBox3.Text = ""
                    Panel1.Enabled = False
                    Panel2.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub NumberButton1_Click(sender As Object, e As EventArgs) Handles NumberButton1.Click, NumberButton9.Click, NumberButton8.Click, NumberButton0.Click, NumberButton7.Click, NumberButton2.Click, NumberButton6.Click, NumberButton3.Click, NumberButton5.Click, NumberButton4.Click
        If TextBox3.Text.Length = 4 Then
        ElseIf TextBox3.Text.Length = 5 Then
        ElseIf TextBox3.Text.Length = 6 Then
        ElseIf TextBox3.Text.Length = 7 Then
        Else
            TextBox3.Text = TextBox3.Text & sender.Text
        End If
    End Sub

    Private Sub RemoveLetterButton_Click(sender As Object, e As EventArgs) Handles RemoveLetterButton.Click
        If TextBox3.Text.Length = 0 Or TextBox3.Text.Length < 0 Then
        Else
            TextBox3.Text = TextBox3.Text.Substring(0, TextBox3.Text.Length - 1)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Pincode = TextBox3.Text
        Panel1.Enabled = True
        Panel2.Visible = False
        Button4.Text = "Remove Pincode"
    End Sub

    Private Sub CreateUserButton_Click(sender As Object, e As EventArgs)
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Users") Then
            If My.Computer.FileSystem.DirectoryExists($"{My.Application.Info.DirectoryPath}\Users\{TextBox1.Text}") Then
                UI.ShowError("This User already exists.")
            Else
                If TextBox1.Text = "SuperSecretUser" Then
                    UI.ShowError("This Username is not allowed.")
                ElseIf TextBox1.Text = "Dev" Then
                    UI.ShowError("This Username is not allowed.")
                Else
                    Dim UserFolder As String = My.Application.Info.DirectoryPath & "\Users\" & TextBox1.Text

                    My.Computer.FileSystem.CreateDirectory(UserFolder)
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Downloads")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Pictures")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Settings")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Videos")
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Temp")
                    'More secure way of storing the webview2 data. (Currently doesn't work.)
                    My.Computer.FileSystem.CreateDirectory(UserFolder & "\Data")

                    Dim Wallpaper As String = Nothing

                    If My.Computer.FileSystem.DirectoryExists(UI.SettingsFolder) Then
                        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LogonWallpaper.setting") Then
                            Wallpaper = UI.WallpaperFolder & "\" & My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\LogonWallpaper.setting")
                        End If
                    End If

                    Dim Role As String = "Vkd0U1RrMXJNVFphZWtKUFlXdHJPUT09"
                    Dim Software_Config As String = "U1hORVlYSnJUVzlrWlVadmNrRndjSE05Um1Gc2MyVTdDa2x6UkdGeWEwMXZaR1ZHYjNKUWNtOW5jbUZ0UFVaaGJITmxPd3BKYzFWemFXNW5UbVYzWlhKWFlXeHNjR0Z3WlhKTWIyRmtaWEk5VkhKMVpUcz0==="
                    Dim UserVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Build.ToString & "." & My.Application.Info.Version.Revision.ToString
                    'Dim AppList As String = "Settings|ProgramInfo|TryOS_Store_New|Internet++"
                    Dim ReaderForPassword As String = TextBox1.Text

                    If TextBox1.Text = "" Then
                        ReaderForPassword = "VkY5b1gybGZjMTlWWDNOZlpWOXlYMGhmWVY5elgwNWZiMTkwWDJoZmFWOXVYMmM9"
                    Else
                        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
                        ReaderForPassword = Convert.ToBase64String(byt)
                        Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
                        ReaderForPassword = Convert.ToBase64String(byt2)
                    End If

                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\WallpaperImage.swfiles", Wallpaper, False)
                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\Password.swfiles", ReaderForPassword, False)
                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\Role.swfiles", Role, False)
                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\Software.swfiles", Software_Config, False)
                    My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\UserVersion.swfiles", UserVersion, False)
                    'My.Computer.FileSystem.WriteAllText(UserFolder & "\Settings\ShowedAppsList.swfiles", AppList, False)

                    'Part of the old code.
                    If Pincode = "None" Then
                    ElseIf Pincode = "" Then
                    ElseIf Pincode.Length < 4 Then
                    Else
                        Dim ThePin As String = Pincode
                        Dim byt3 As Byte() = System.Text.Encoding.UTF8.GetBytes(ThePin)
                        ThePin = Convert.ToBase64String(byt3)
                        Dim byt4 As Byte() = System.Text.Encoding.UTF8.GetBytes(ThePin)
                        ThePin = Convert.ToBase64String(byt4)
                        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Pincode.swfiles", ThePin, False)

                        My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\LastKnownUser.setting", TextBox1.Text, False)
                    End If

                    'Calls for shutdown of USW and restart of program.
                    USWThings.CloseUSW()
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CreateUserButton_Click(sender, e)

        Return

        If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\" & TextBox1.Text) Then
            'MsgBox("This User already exists.")
            UI.ShowError("This User already exists.")
        ElseIf My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\Dev") Then
            'MsgBox("This User is not allowed.")
            UI.ShowError("This User is not allowed.")
        Else
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text)
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Apps")
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Settings")
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Downloads")
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Pictures")
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
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Role.swfiles", "Vkd0U1RrMXJNVFphZWtKUFlXdHJPUT09", False)
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Wallpaper.swfiles", "jpg=1", False)

            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Apps\Internet++.swfiles", "", False)

            If Pincode = "None" Then
            ElseIf Pincode = "" Then
            ElseIf Pincode.Length < 4 Then
            Else
                Dim ThePin As String = Pincode
                Dim byt3 As Byte() = System.Text.Encoding.UTF8.GetBytes(ThePin)
                ThePin = Convert.ToBase64String(byt3)
                Dim byt4 As Byte() = System.Text.Encoding.UTF8.GetBytes(ThePin)
                ThePin = Convert.ToBase64String(byt4)
                My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Pincode.swfiles", ThePin, False)

                My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\LastKnownUser.setting", TextBox1.Text, False)
            End If

            'Calls for shutdown of USW and restart of program.
            USWThings.CloseUSW()
        End If
    End Sub
End Class