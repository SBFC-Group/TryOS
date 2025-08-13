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
                If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & Reader & "\Settings\Password.swfiles") Then
                    Dim SecondReader As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Reader & "\Settings\Password.swfiles")
                    Try
                        Dim b As Byte() = Convert.FromBase64String(SecondReader)
                        SecondReader = System.Text.Encoding.UTF8.GetString(b)
                    Catch ex As Exception
                        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit ")
                        UI.ShowError(ex.Message, ErrorMSGBox.Alerts.Critical)
                    End Try
                    Try
                        Dim b As Byte() = Convert.FromBase64String(SecondReader)
                        SecondReader = System.Text.Encoding.UTF8.GetString(b)
                    Catch ex As Exception
                        UI.ShowError(ex.Message, ErrorMSGBox.Alerts.Critical)
                        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit ")
                    End Try
                    If SecondReader = "T_h_i_s_U_s_e_r_H_a_s_N_o_t_h_i_n_g" Then
                        Login()
                    Else
                        If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & Reader & "\Settings\PinCode.swfiles") Then
                            Panel3.Visible = True
                            TextBox1.Enabled = False
                            TextBox2.Enabled = False
                            PinEncoded = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Reader & "\Settings\PinCode.swfiles")
                            Me.KeyPreview = True
                            Me.Activate()
                            'NumberButton1.Select()
                        End If
                    End If


                End If
            End If
        End If

        If TestingMode = True Then
            LoadLanguage()
        End If

    End Sub
    Public TestingMode As Boolean = False
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
                    If Password = """Password.swfiles"" can't be nothing." Then
                        UI.ShowError("", ErrorMSGBox.Alerts.Critical)
                    End If
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

    Private Sub RemoveLetterButton_Click() Handles RemoveLetterButton.Click
        If TextBox3.Text.Length = 0 Or TextBox3.Text.Length < 0 Then
        Else
            TextBox3.Text = TextBox3.Text.Substring(0, TextBox3.Text.Length - 1)
        End If

    End Sub

    Private Sub NumberButton1_Click() Handles NumberButton1.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "1"
            Timer1_Tick()
        End If

    End Sub

    Private Sub NumberButton2_Click() Handles NumberButton2.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "2"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton3_Click() Handles NumberButton3.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "3"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton4_Click() Handles NumberButton4.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "4"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton5_Click() Handles NumberButton5.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "5"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton6_Click() Handles NumberButton6.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "6"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton7_Click() Handles NumberButton7.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "7"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton8_Click() Handles NumberButton8.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "8"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton9_Click() Handles NumberButton9.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "9"
            Timer1_Tick()
        End If
    End Sub

    Private Sub NumberButton0_Click() Handles NumberButton0.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text & "0"
            Timer1_Tick()
        End If
    End Sub

    Private Sub Button2_Click() Handles Button2.Click
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
        Dim args As String = Environment.CommandLine

        If args.Contains("/DevMode") = True Then
            Commander.Show()
            Commander.FormBorderStyle = FormBorderStyle.Sizable
            Commander.ShowIcon = True
            Commander.ShowInTaskbar = True
        End If
    End Sub

    Private PincodeBoolean As Boolean = False

    Private Sub NumberButton1_KeyDown(sender As Object, e As KeyEventArgs) Handles NumberButton1.KeyDown, NumberButton2.KeyDown, NumberButton3.KeyDown, NumberButton4.KeyDown, NumberButton5.KeyDown, NumberButton6.KeyDown, NumberButton7.KeyDown, NumberButton8.KeyDown, NumberButton9.KeyDown, NumberButton0.KeyDown, RemoveLetterButton.KeyDown, Button2.KeyDown, MyBase.KeyDown
        If e.KeyValue = 48 Then ' Key 0
            NumberButton0_Click()
        ElseIf e.KeyValue = 49 Then ' Key 1
            NumberButton1_Click()
        ElseIf e.KeyValue = 50 Then ' Key 2
            NumberButton2_Click()
        ElseIf e.KeyValue = 51 Then ' Key 3
            NumberButton3_Click()
        ElseIf e.KeyValue = 52 Then ' Key 4
            NumberButton4_Click()
        ElseIf e.KeyValue = 53 Then ' Key 5
            NumberButton5_Click()
        ElseIf e.KeyValue = 54 Then ' Key 6
            NumberButton6_Click()
        ElseIf e.KeyValue = 55 Then ' Key 7
            NumberButton7_Click()
        ElseIf e.KeyValue = 56 Then ' Key 8
            NumberButton8_Click()
        ElseIf e.KeyValue = 57 Then ' Key 9
            NumberButton9_Click()
        ElseIf e.KeyValue = 8 Then ' Key Backspace
            RemoveLetterButton_Click()
        ElseIf e.KeyValue = 46 Then ' Key Delete
            RemoveLetterButton_Click()
        End If
    End Sub


End Class