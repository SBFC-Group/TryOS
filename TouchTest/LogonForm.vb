Public Class LogonForm
    Private Sub LogonForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UI.LogonBool = False Then
            UI.LogonBool = True
            LogonFormThings.SetupProgramUser()
            LogonFormThings.OpenLogonForm()
            Close()
        Else
            UI.RunCommands("Loadjpg 1")

            'Loads the Logon Wallpaper
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

            If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LastKnownUser.setting") Then
                Dim ReadMyUserData As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\LastKnownUser.setting")

                Dim UserMode As String = Nothing
                If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & ReadMyUserData & "\Settings\UserMode.swfiles") Then
                    UserMode = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & ReadMyUserData & "\Settings\UserMode.swfiles")
                End If

                If UserMode = "UserMode=Disabled" Then
                Else
                    TextBox1.Text = ReadMyUserData
                    If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & ReadMyUserData & "\Settings\Password.swfiles") Then
                        Dim SecondReader As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & ReadMyUserData & "\Settings\Password.swfiles")
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
                            'Login()
                        Else
                            If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & ReadMyUserData & "\Settings\PinCode.swfiles") Then
                                ActivatePincodeLayout()
                                'NumberButton1.Select()  
                            Else
                            End If
                        End If


                    End If
                End If


            Else
            End If

            If Environment.CommandLine.Contains("/DevMode") Then
                Dim dir1 = UI.UsersFolder
                Dim files() As System.IO.DirectoryInfo
                Dim dirinfo As New System.IO.DirectoryInfo(dir1)
                files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)
                For Each file In files
                    Dim UserMode As String = Nothing
                    If My.Computer.FileSystem.FileExists(file.FullName & "\Settings\UserMode.swfiles") Then
                        UserMode = My.Computer.FileSystem.ReadAllText(file.FullName & "\Settings\UserMode.swfiles")
                    End If
                    If UserMode = "UserMode=Disabled" Then
                    Else
                        'Creates a new button with the name of a user.
                        Dim btn As New Button()
                        btn.Text = file.Name
                        btn.FlatStyle = FlatStyle.Flat
                        btn.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        btn.BackColor = Color.Gainsboro
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                        btn.Size = New Size(209, 45)
                        AddHandler btn.Click, AddressOf OpenUserButton_Click
                        FlowLayoutPanel1.Controls.Add(btn)
                    End If
                Next
            Else
                FlowLayoutPanel1.Visible = False
            End If
        End If
    End Sub

    Private HasOpenUserButton_ClickBeenOpened As Boolean = False

    Private Sub OpenUserButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)

        TextBox1.Text = btn.Text

        Panel3.Visible = True


        If HasOpenUserButton_ClickBeenOpened = False Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False

            Label5.Text = "Password"
            NumberButton0.Visible = False
            NumberButton1.Visible = False
            NumberButton2.Visible = False
            NumberButton3.Visible = False
            NumberButton4.Visible = False
            NumberButton5.Visible = False
            NumberButton6.Visible = False
            NumberButton7.Visible = False
            NumberButton8.Visible = False
            NumberButton9.Visible = False
            RemoveLetterButton.Visible = False

            TextBox3.Enabled = True
            TextBox3.UseSystemPasswordChar = True

            AddHandler TextBox3.KeyDown, AddressOf MayNeedThis

            Dim NewPoint1 As Int64 = Label5.Location.Y
            Dim NewPoint2 As Int64 = Label5.Location.X

            Dim NewPoint3 As Int64 = TextBox3.Location.Y
            Dim NewPoint4 As Int64 = TextBox3.Location.X

            NewPoint1 = NewPoint1 + 30

            NewPoint3 = NewPoint3 + 30

            Label5.Location = New Point(NewPoint2, NewPoint1)

            TextBox3.Location = New Point(NewPoint4, NewPoint3)
            HasOpenUserButton_ClickBeenOpened = True
        End If


    End Sub

    Private Sub MayNeedThis(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TextBox2.Text = TextBox3.Text
            Login()
        End If
    End Sub

    Public PinEncoded As String
    Private PincodeBoolean As Boolean = False

    'Older Sub
    Private Sub ActivatePincodeLayout()
        PincodeBoolean = True
        Panel3.Visible = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        PinEncoded = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\PinCode.swfiles")
        Me.KeyPreview = True
        FlowLayoutPanel1.Visible = False
        Me.Activate()
    End Sub

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

                    If Password = "T_h_i_s_U_s_e_r_H_a_s_N_o_t_h_i_n_g" Then
                        Password = ""
                    ElseIf Password = "" Then
                        UI.ShowError("The password is not supported.", ErrorMSGBox.Alerts.Critical)
                        Exit Sub
                    End If

                    If Password = TextBox2.Text Then

                        Dim LogonLoadingUser As New LoadingUser
                        LogonLoadingUser.Show()

                        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LastKnownUser.setting") Then
                            Dim ReadMyUserData As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\LastKnownUser.setting")
                            If TextBox1.Text = ReadMyUserData Then
                            Else
                                My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\LastKnownUser.setting", TextBox1.Text, False)
                            End If
                        Else
                            My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\LastKnownUser.setting", TextBox1.Text, False)
                        End If

                        LogonLoadingUser.Username = TextBox1.Text
                        LogonLoadingUser.Password = TextBox2.Text

                        LogonFormThings.CloseLogonForm()

                    Else
                        UI.ShowError("Can't find an user with that password.")
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
                UI.ShowError("Can't find an user with that username.")
            End If
        Catch ex As Exception
            UI.ShowError(ex.Message, ErrorMSGBox.Alerts.Critical)
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit")
        End Try

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
        PincodeBoolean = False
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
        RemoveLetterButton.Enabled = False
        TextBox1.Enabled = True
        TextBox1.Text = ""
        TextBox2.Enabled = True
        If Environment.CommandLine.Contains("/DevMode") Then
            FlowLayoutPanel1.Visible = True
        End If
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

    Private Sub NumberButton1_KeyDown(sender As Object, e As KeyEventArgs) Handles NumberButton1.KeyDown, NumberButton2.KeyDown, NumberButton3.KeyDown, NumberButton4.KeyDown, NumberButton5.KeyDown, NumberButton6.KeyDown, NumberButton7.KeyDown, NumberButton8.KeyDown, NumberButton9.KeyDown, NumberButton0.KeyDown, RemoveLetterButton.KeyDown, Button2.KeyDown, MyBase.KeyDown
        If PincodeBoolean = True Then
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
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2_Click()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub LogonButton2_Click(sender As Object, e As EventArgs) Handles LogonButton2.Click
        TextBox2.Text = TextBox3.Text
        Login()
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Login()
        End If
    End Sub
End Class