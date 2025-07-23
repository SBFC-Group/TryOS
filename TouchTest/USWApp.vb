Public Class USWApp
    Private Sub USWApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If USWThings.HasBeenOpened = False Then
            USWThings.HasBeenOpened = True
            USWThings.SetupUSWUser()
            USWThings.OpenUSW()
            Close()
        ElseIf USWThings.HasBeenOpened = True Then
            Panel3.Visible = False
            UI.RunCommands("Loadjpg 1")
            AxWindowsMediaPlayer1.Dock = DockStyle.Fill
            AxWindowsMediaPlayer1.uiMode = "none"
            AxWindowsMediaPlayer1.URL = UI.UsersFolder & "\Program\Temp\USW.mp4"
            StartMainTimer.Start()


        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles StartMainTimer.Tick
        'Hides "AxWindowsMediaPlayer1".
        AxWindowsMediaPlayer1.Visible = False

        'Configs Form layout.
        Panel3.Visible = True
        Panel3.BackgroundImage = Form1.Panel1.BackgroundImage
        SetupPanel.BackColor = Color.FromArgb(55, Color.DarkGray)
        'SetupPanel.Dock = DockStyle.Fill
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UI.RunCommands("end")
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

                My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\AutoUser.setting", TextBox1.Text, False)
            End If

            'Calls for shutdown of USW and restart of program.
            USWThings.CloseUSW()
        End If
    End Sub
End Class