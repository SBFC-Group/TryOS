Public Class Form48
    Private lang As New LanguageManager()

    Private Sub Form48_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Checks if "LogonWallpaper.setting" exists in Settings Folder
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LogonWallpaper.setting") Then
            'Gets the data thats inside "LogonWallpaper.setting"
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\LogonWallpaper.setting")
            Try
                'Loads the wallpaper file name thats contained inside "LogonWallpaper.setting"
                PictureBox1.Load(UI.WallpaperFolder & "\" & Reader)
            Catch ex As Exception
                PictureBox1.BackColor = Color.DarkGray
            End Try
        Else
            Try
                'Just loads "Wallpaper_1.jpg" thats inside Wallpapers Folder
                PictureBox1.Load(UI.WallpaperFolder & "\Wallpaper_1.jpg")
            Catch ex As Exception
                PictureBox1.BackColor = Color.DarkGray
            End Try
        End If

        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\AutoUser.setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\AutoUser.setting")

            If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\" & Reader) Then
                TextBox1.Text = Reader

                If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & Reader & "\Settings\PinCode.swfiles") Then
                    Panel3.Visible = True
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    PinEncoded = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Reader & "\Settings\PinCode.swfiles")
                End If
            End If
        End If

        If TestingMode = True Then
            LoadLanguage()
        End If

    End Sub
    Public TestingMode As Boolean = True
    Private Sub LoadLanguage()
        Dim langCode As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\ProgramLanguage.setting")
        lang.LoadLanguage(langCode)
        ApplyTranslations()
    End Sub

    Private Sub ApplyTranslations()
        'Label1.Text = LanguageManager.WelcomeUser
        'Label2.Text = LanguageManager.Username
        'Label3.Text = LanguageManager.Password
        'Label4.Text = LanguageManager.WelcomeUser
        'Label5.Text = LanguageManager.PinCode

        Label1.Text = lang.Translate("welcomeuser")
        Label2.Text = lang.Translate("username")
        Label3.Text = lang.Translate("password")
        Label4.Text = lang.Translate("welcomeuser")
        Label5.Text = lang.Translate("pincode")

        'lblWelcome.Text = lang.Translate("welcome")
        'btnExit.Text = lang.Translate("exit")
        'lblGreeting.Text = lang.Translate("greeting")
    End Sub

    Public PinEncoded As String

    Private Sub Login() Handles Button1.Click
        Try
            If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\" & TextBox1.Text) Then
                If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Password.swfiles") Then


                    Dim Password As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Password.swfiles")
                    Try
                        Dim b As Byte() = Convert.FromBase64String(Password)
                        Password = System.Text.Encoding.UTF8.GetString(b)
                    Catch ex As Exception
                        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit ")
                        UI.ShowError(ex.Message, ErrorMSGBox.Alerts.Critical)
                    End Try
                    Try
                        Dim b As Byte() = Convert.FromBase64String(Password)
                        Password = System.Text.Encoding.UTF8.GetString(b)
                    Catch ex As Exception
                        UI.ShowError(ex.Message, ErrorMSGBox.Alerts.Critical)
                        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit ")
                    End Try
                    If Password = TextBox2.Text Then
                        'MsgBox("Welcome " & TextBox1.Text)
                        Form1.Username = TextBox1.Text
                        UI.UserFolder = UI.UsersFolder & "\" & TextBox1.Text
                        UI.LoadShell(TextBox1.Text, My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Password.swfiles"))
                        Close()
                    End If
                Else
                    If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & TextBox1.Text & "\Password.swfiles") Then
                        If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\" & TextBox1.Text & "\Settings") Then
                            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Settings")
                        End If
                        My.Computer.FileSystem.MoveFile(UI.UsersFolder & "\" & TextBox1.Text & "\Password.swfiles", UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Password.swfiles")
                    End If
                End If
            Else

            End If
        Catch ex As Exception
            UI.ShowError(ex.Message, ErrorMSGBox.Alerts.Critical)
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit")
        End Try

    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub

    Private Sub Timer1_Tick()
        If TextBox3.Text = "" Then
        Else
            Dim VGPinGV As String = PinEncoded
            Try
                Dim b As Byte() = Convert.FromBase64String(VGPinGV)
                VGPinGV = System.Text.Encoding.UTF8.GetString(b)
            Catch ex As Exception

            End Try
            Try
                Dim b As Byte() = Convert.FromBase64String(VGPinGV)
                VGPinGV = System.Text.Encoding.UTF8.GetString(b)
            Catch ex As Exception

            End Try
            If TextBox3.Text = VGPinGV Then
                Dim Password As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Password.swfiles")
                Try
                    Dim b As Byte() = Convert.FromBase64String(Password)
                    Password = System.Text.Encoding.UTF8.GetString(b)
                Catch ex As Exception

                End Try
                Try
                    Dim b As Byte() = Convert.FromBase64String(Password)
                    Password = System.Text.Encoding.UTF8.GetString(b)
                Catch ex As Exception

                End Try
                TextBox2.Text = Password
                Login()
            End If
        End If
    End Sub

    Private Sub RemoveLetterButton_Click(sender As Object, e As EventArgs) Handles RemoveLetterButton.Click
        If TextBox3.Text.Length = 0 Or TextBox3.Text.Length < 0 Then
        Else
            TextBox3.Text = TextBox3.Text.Substring(0, TextBox3.Text.Length - 1)
        End If

    End Sub

    Private Sub NumberButton1_Click(sender As Object, e As EventArgs) Handles NumberButton1.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "1"
            Timer1_Tick()
        End If

    End Sub

    Private Sub NumberButton2_Click(sender As Object, e As EventArgs) Handles NumberButton2.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "2"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton3_Click(sender As Object, e As EventArgs) Handles NumberButton3.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "3"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton4_Click(sender As Object, e As EventArgs) Handles NumberButton4.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "4"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton5_Click(sender As Object, e As EventArgs) Handles NumberButton5.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "5"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton6_Click(sender As Object, e As EventArgs) Handles NumberButton6.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "6"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton7_Click(sender As Object, e As EventArgs) Handles NumberButton7.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "7"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton8_Click(sender As Object, e As EventArgs) Handles NumberButton8.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "8"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton9_Click(sender As Object, e As EventArgs) Handles NumberButton9.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "9"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton0_Click(sender As Object, e As EventArgs) Handles NumberButton0.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "0"
            Timer1_Tick()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel3.Visible = False
        NumberButton0.Enabled = False
        NumberButton1.Enabled = False
        NumberButton2.Enabled = False
        NumberButton3.Enabled = False
        NumberButton4.Enabled = False
        NumberButton5.Enabled = False
        NumberButton6.Enabled = False
        NumberButton7.Enabled = False
        NumberButton8.Enabled = False
        NumberButton9.Enabled = False
        TextBox1.Enabled = True
        TextBox1.Text = ""
        TextBox2.Enabled = True
    End Sub

    Private Sub CommanderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommanderToolStripMenuItem.Click
        Commander.Show()
        Commander.FormBorderStyle = FormBorderStyle.Sizable
        Commander.ShowIcon = True
        Commander.ShowInTaskbar = True
    End Sub
End Class