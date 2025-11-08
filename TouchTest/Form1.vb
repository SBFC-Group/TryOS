Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Public Username As String = "Administrator"
    Public Password As String = ""
    Public ShutdownConsole As Boolean = True

    Public IsGuestUser As Boolean = False

    Public IsUsingDarkThemeForApps As Boolean = False
    Public IsUsingDarkThemeForPrograms As Boolean = False

    Public SizeX As Integer = 0
    Public SizeY As Integer = 0

    Public WallpaperFileFormat As String = ""
    Public LoadedWallpaper As Int64 = 0

    Public DisableFullScreenConsole As Boolean = False
    Public DisableConsole As Boolean = False

    Public AllowOnlyVerifyedShellCode As Boolean = True

    Private User As New UserManager(Username)
    Private lang As New LanguageManager()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Timer1.Start()
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LoadDebugMenu.setting") Then
            MenuStrip1.Visible = True
        End If

        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\DisableConsole.setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\DisableConsole.setting")
            Try
                Dim reader2 As Boolean = Convert.ToBoolean(Reader)
                DisableConsole = reader2
            Catch ex As Exception

            End Try
        End If

        UserManager.LoadShellColors()

        UserManager.CheckForDarkThemeFile()

        UserManager.LoadWallpaperFromUserSettings()

        'User.LoadUserSettings()

        If IsUsingDarkThemeForPrograms = True Then
            Panel2.BackColor = Color.FromArgb(55, Color.Gray)
            TimebarPanel.BackColor = Color.FromArgb(55, Color.Gray)
        ElseIf IsUsingDarkThemeForPrograms = False Then
            Panel2.BackColor = Color.FromArgb(55, Color.Silver)
            TimebarPanel.BackColor = Color.FromArgb(55, Color.Silver)
        End If

        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\Internet++.swfiles") Then

        '    InternetPlusPlus.Visible = True
        'Else
        '    InternetPlusPlus.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\QuickNotes.swfiles") Then
        '    QuickNotes.Visible = True
        'Else
        '    QuickNotes.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\YoutubeApp.swfiles") Then
        '    YoutubeButton.Visible = True
        'Else
        '    YoutubeButton.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\InstagramApp.swfiles") Then
        '    InstagramButton.Visible = True
        'Else
        '    InstagramButton.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\FacebookApp.swfiles") Then
        '    FacebookButton.Visible = True
        'Else
        '    FacebookButton.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\SpotifyApp.swfiles") Then
        '    SpotifyButton.Visible = True
        'Else
        '    SpotifyButton.Visible = False
        'End If

        If UI.DisableOpenFramework = False Then
            Dim regit As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\SBFC Group", "UseOpenFramework", Nothing)
            If regit = "1" Then
                OpenFramework_Data.LoadApps()
            End If

            UserManager.LoadTaskbarButtons()

            Dim regit2 As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\SBFC Group", "LoadCustomPls", Nothing)
            If regit2 = "1" Then
                Dim pluginPath As String = Path.Combine(Application.StartupPath, "Plugins")
                Dim plugins = Q_U_U_U_Q.LoadPlugins(pluginPath)

                For Each plugin In plugins
                    Debug.WriteLine("Loaded plugin: " & plugin.Name)
                    plugin.ExecuteDebug(Me)
                    plugin.ExecuteUISubs(UI)
                Next
            End If

            CustomController_Data.LoadCodeParts()

            If AllowOnlyVerifyedShellCode = False Then
                If Shit = 1 Then
                    UI.ShowError("Your running in an unsafe mode. Close the program if you don't know what you're doing.", ErrorMSGBox.Alerts.Information)
                End If
            End If
        End If





    End Sub

    Public Function funnything() As Panel
        Return Panel2
    End Function

    Public TestingMode As Boolean = True

    Private Sub LoadLanguage(langCode As String)
        lang.LoadLanguage(langCode)
        ApplyTranslations()
    End Sub

    Private Sub ApplyTranslations()
        'lblWelcome.Text = lang.Translate("welcome")
        'btnExit.Text = lang.Translate("exit")
        'lblGreeting.Text = lang.Translate("greeting")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenChildForm(New Internetplusplus)
    End Sub

    Public IsProgramClose As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        SizeX = Panel3.Size.Width
        SizeY = Panel3.Size.Height ' - 57
    End Sub



    Public currentForm As Form = Nothing
    Public Sub OpenChildForm(ByVal childForm As Form, Optional arg1 As String = "Null=Nothing")
        If currentForm IsNot Nothing Then currentForm.Close()
        currentForm = childForm
        childForm.TopLevel = False
        'childForm.WindowState = FormWindowState.Maximized
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        Panel3.Controls.Add(childForm)
        Panel3.Tag = childForm
        'childForm.Location = New Point(1, 1)
        childForm.Size = New Size(Me.Size.Width, Me.Size.Height - 57)
        'childForm.BringToFront()
        If arg1 = "Null=Nothing" Then
        Else
            ArgData = arg1
        End If
        Try
            childForm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Public ArgData As String = Nothing

    Public Sub LogOut()
        UI.UserFolder = UI.UsersFolder & "\"
        Try
            currentForm.Close()
        Catch ex As Exception
        End Try
        Form48.Show()
        System.Threading.Thread.Sleep(500)
        UI.DisableOpenFramework = True
        Close()
    End Sub

    Public IsSettingOpen As Boolean = False

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        UI.RunApp("Settings")
        'If IsSettingOpen = False Then
        '    OpenChildForm(New SettingsForm)
        '    IsSettingOpen = True
        'End If
        'If IsInternetOpen = True Then
        '    IsInternetOpen = False
        'End If
        'If IsQuickNotesOpen = True Then
        '    IsQuickNotesOpen = False
        'End If
        'If IsYoutubeAppOpen = True Then
        '    IsYoutubeAppOpen = False
        'End If
    End Sub

    Private Sub ApplyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyToolStripMenuItem.Click
        Username = ToolStripTextBox1.Text
    End Sub

    Private Sub EncodePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncodePasswordToolStripMenuItem.Click
        Dim Passwordencode As String = ToolStripTextBox2.Text
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(Passwordencode)
        Passwordencode = Convert.ToBase64String(byt)
        Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(Passwordencode)
        Passwordencode = Convert.ToBase64String(byt2)
        Password = Passwordencode
    End Sub

    Public Shit As Integer = 1
    Private Sub LoadConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadConsoleToolStripMenuItem.Click
        If DisableConsole = False Then
            If Shit = 1 Then
                Console.ShowInTaskbar = True
                Console.WindowState = FormWindowState.Maximized
                Console.BringToFront()
                Shit = 2
            ElseIf Shit = 2 Then
                Console.ShowInTaskbar = False
                Console.WindowState = FormWindowState.Minimized
                BringToFront()
                Shit = 1
            End If
        End If
    End Sub

    Private Sub CommanderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommanderToolStripMenuItem.Click
        If DisableConsole = False Then
            If DisableFullScreenConsole = True Then
                CommanderWindowedToolStripMenuItem_Click(sender, e)
            Else
                UI.StartCMD()
                If Panel2.Visible = False Then
                    HideTaskbar(False)
                End If
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            currentForm.Close()
        Catch ex As Exception

        End Try

        OpenFramework_Data.AppName = ""

        If IsSettingOpen = True Then
            IsSettingOpen = False
        End If
        If IsInternetOpen = True Then
            IsInternetOpen = False
        End If
        If IsQuickNotesOpen = True Then
            IsQuickNotesOpen = False
        End If
        If IsYoutubeAppOpen = True Then
            IsYoutubeAppOpen = False
        End If
        If IsInstagramAppOpen = True Then
            IsInstagramAppOpen = False
        End If
        If IsFacebookAppOpen = True Then
            IsFacebookAppOpen = False
        End If
    End Sub

    Public IsInternetOpen As Boolean = False
    Public IsQuickNotesOpen As Boolean = False
    Public IsYoutubeAppOpen As Boolean = False
    Public IsInstagramAppOpen As Boolean = False
    Public IsFacebookAppOpen As Boolean = False
    Public IsSpotifyAppOpen As Boolean = False

    Private Sub InternetPlusPlus_Click(sender As Object, e As EventArgs) Handles InternetPlusPlus.Click
        UI.RunApp("Internet++")
        'If IsInternetOpen = False Then
        '    OpenChildForm(New Internetplusplus)
        '    IsInternetOpen = True
        'End If
        'If IsSettingOpen = True Then
        '    IsSettingOpen = False
        'End If
        'If IsQuickNotesOpen = True Then
        '    IsQuickNotesOpen = False
        'End If
        'If IsYoutubeAppOpen = True Then
        '    IsYoutubeAppOpen = False
        'End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Label1.Text = Username
        'Label2.Text = Password

        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\Internet++.swfiles") Then
        '    InternetPlusPlus.Visible = True
        'Else
        '    InternetPlusPlus.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\QuickNotes.swfiles") Then
        '    QuickNotes.Visible = True
        'Else
        '    QuickNotes.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\YoutubeApp.swfiles") Then
        '    YoutubeButton.Visible = True
        'Else
        '    YoutubeButton.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\InstagramApp.swfiles") Then
        '    InstagramButton.Visible = True
        'Else
        '    InstagramButton.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\FacebookApp.swfiles") Then
        '    FacebookButton.Visible = True
        'Else
        '    FacebookButton.Visible = False
        'End If
        'If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Apps\SpotifyApp.swfiles") Then
        '    SpotifyButton.Visible = True
        'Else
        '    SpotifyButton.Visible = False
        'End If


    End Sub

    Private Sub QuickNotes_Click(sender As Object, e As EventArgs) Handles QuickNotes.Click
        UI.RunApp("QuickNotes")
        'If IsQuickNotesOpen = False Then
        '    OpenChildForm(New Form15)
        '    IsQuickNotesOpen = True
        'End If
        'If IsSettingOpen = True Then
        '    IsSettingOpen = False
        'End If
        'If IsInternetOpen = True Then
        '    IsInternetOpen = False
        'End If
        'If IsYoutubeAppOpen = True Then
        '    IsYoutubeAppOpen = False
        'End If
    End Sub

    ''' <summary>Allows an App to enter or leave Fullscreen Mode</summary>
    Public Sub EnableFullAppMode(IsAppFull As Boolean)
        If IsAppFull = True Then
            Panel2.Visible = False
            TimebarPanel.Visible = False
        ElseIf IsAppFull = False Then
            Panel2.Visible = True
            TimebarPanel.Visible = True
        End If
    End Sub

    ''' <summary>This has been replaced by "EnableFullAppMode"</summary>
    Public Sub HideTaskbar(HideTheTaskbar As Boolean)
        If HideTheTaskbar = True Then
            Panel2.Visible = False
            TimebarPanel.Visible = False
        ElseIf HideTheTaskbar = False Then
            Panel2.Visible = True
            TimebarPanel.Visible = True
        End If
    End Sub

    ''' <summary>This has been replaced by "EnableFullAppMode"</summary>
    Public Sub HideTaskbar(HideTheTaskbar As Boolean, HideOnlyTaskbar As Boolean)
        If HideOnlyTaskbar = True Then
            If HideTheTaskbar = True Then
                Panel2.Visible = False
            ElseIf HideTheTaskbar = False Then
                Panel2.Visible = True
            End If
        ElseIf HideOnlyTaskbar = False Then
            If HideTheTaskbar = True Then
                Panel2.Visible = False
                TimebarPanel.Visible = False
            ElseIf HideTheTaskbar = False Then
                Panel2.Visible = True
                TimebarPanel.Visible = True
            End If
        End If
    End Sub

    Public Function GetRole() As TryController.Roles
        If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\Role.swfiles") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\Role.swfiles")
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

    Private Sub YoutubeButton_Click(sender As Object, e As EventArgs) Handles YoutubeButton.Click
        UI.RunApp("YoutubeApp")
        'If IsYoutubeAppOpen = False Then
        '    OpenChildForm(New YoutubeApp)
        '    IsYoutubeAppOpen = True
        'End If
        'If IsSettingOpen = True Then
        '    IsSettingOpen = False
        'End If
        'If IsInternetOpen = True Then
        '    IsInternetOpen = False
        'End If
        'If IsQuickNotesOpen = True Then
        '    IsQuickNotesOpen = False
        'End If
    End Sub

    Private Sub TimeAndDate_Tick(sender As Object, e As EventArgs) Handles TimeAndDate.Tick
        TimeLabel.Text = Format(Now, "HH:mm:ss")

        If IsUsingDarkThemeForPrograms = True Then
            Panel2.BackColor = Color.FromArgb(55, Color.Gray)
            TimebarPanel.BackColor = Color.FromArgb(55, Color.Gray)
        ElseIf IsUsingDarkThemeForPrograms = False Then
            Panel2.BackColor = Color.FromArgb(55, Color.Silver)
            TimebarPanel.BackColor = Color.FromArgb(55, Color.Silver)
        End If
        'Label5.Text = Format(Now, "dd-MM-yyyy")
        'If VolumeControl.IsMute() = True Then
        '    VolumeButton.BackgroundImage = VolumeList.Images.Item(0)
        'ElseIf VolumeControl.IsMute() = False Then
        '    VolumeButton.BackgroundImage = VolumeList.Images.Item(1)
        'End If

        'Dim WifiInt As Int64 = WifiSignalStrength.GetWifiSignalStrength()
        'If WifiInt = 100 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 99 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 98 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 97 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 96 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 95 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 94 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 93 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 92 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 91 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 90 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 89 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 88 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 87 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 86 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 85 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 84 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 83 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 82 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 81 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 80 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf WifiInt = 79 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 78 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 77 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 76 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 75 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 74 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 73 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 72 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 71 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 70 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 69 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 68 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 67 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 66 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 65 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 64 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 63 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 62 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 61 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 60 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf WifiInt = 59 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 58 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 57 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 56 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 55 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 54 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 53 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 52 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 51 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 50 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 49 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 48 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 47 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 46 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 45 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 44 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 43 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 42 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 41 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 40 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf WifiInt = 39 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 38 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 37 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 36 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 35 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 34 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 33 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 32 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 31 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 30 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 29 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 28 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 27 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 26 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 25 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 24 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 23 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 22 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 21 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 20 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 19 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 18 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 17 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 16 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 15 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 14 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 13 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 12 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 11 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 10 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 9 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 8 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 7 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 6 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 5 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 4 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 3 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 2 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 1 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = 0 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'ElseIf WifiInt = -1 Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(4)
        'End If

        'If 80 < WifiInt Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'ElseIf 79 < WifiInt Or 60 > WifiInt Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(1)
        'ElseIf 59 < WifiInt Or 40 > WifiInt Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(2)
        'ElseIf 39 < WifiInt Or 0 > WifiInt Then
        '    WifiButton.BackgroundImage = InternetList.Images.Item(3)
        'End If

        'WifiButton.BackgroundImage = InternetList.Images.Item(0)
        'PowerButton.BackgroundImage = PowerList.Images.Item(0)

        UpdateBatteryStatus()

        If BatteryPower = 100 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 99 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 98 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 97 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 96 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 95 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 94 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 93 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 92 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 91 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 90 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 89 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 88 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 87 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 86 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 85 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 84 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 83 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 82 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 81 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 80 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        ElseIf BatteryPower = 79 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 78 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 77 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 76 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 75 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 74 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 73 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 72 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 71 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 70 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 69 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 68 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 67 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 66 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 65 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 64 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 63 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 62 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 61 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 60 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(1)
        ElseIf BatteryPower = 59 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 58 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 57 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 56 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 55 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 54 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 53 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 52 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 51 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 50 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 49 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 48 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 47 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 46 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 45 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 44 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 43 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 42 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 41 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 40 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(2)
        ElseIf BatteryPower = 39 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 38 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 37 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 36 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 35 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 34 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 33 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 32 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 31 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 30 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 29 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 28 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 27 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 26 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 25 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 24 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 23 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 22 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 21 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 20 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 19 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 18 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 17 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(3)
        ElseIf BatteryPower = 16 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 15 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 14 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 13 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 12 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 11 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 10 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 9 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 8 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 7 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 6 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 5 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 4 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 3 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 2 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 1 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        ElseIf BatteryPower = 0 Then
            PowerButton.BackgroundImage = PowerList.Images.Item(4)
        End If
        Dim batteryStatus As PowerStatus = SystemInformation.PowerStatus
        If batteryStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            PowerButton.BackgroundImage = PowerList.Images.Item(5)
        End If
        If HasBattery = False Then
            PowerButton.BackgroundImage = PowerList.Images.Item(0)
        End If
    End Sub

    Private Sub PowerButton_Click(sender As Object, e As EventArgs) Handles PowerButton.Click
        If IsControlCenterOpen = True Then
            CloseControlCenter()
        ElseIf IsControlCenterOpen = False Then
            ShowControlCenter()
        End If

    End Sub

    Private Sub WifiButton_Click(sender As Object, e As EventArgs) Handles WifiButton.Click
        If IsControlCenterOpen = True Then
            CloseControlCenter()
        ElseIf IsControlCenterOpen = False Then
            ShowControlCenter()
        End If

    End Sub

    Private Sub VolumeButton_Click(sender As Object, e As EventArgs) Handles VolumeButton.Click
        If IsControlCenterOpen = True Then
            CloseControlCenter()
        ElseIf IsControlCenterOpen = False Then
            ShowControlCenter()
        End If

    End Sub

    Private IsControlCenterOpen As Boolean = False
    Private ControlCenterHasBeenOpened As Boolean = False
    Public ControlCenter As PageSettings

    ''' <summary>This opens the Control Center</summary>
    Private Sub ShowControlCenter()
        IsControlCenterOpen = True
        Try
            currentForm.Hide()
        Catch ex As Exception

        End Try
        HideTaskbar(True, True)
        If ControlCenterHasBeenOpened = False Then
            ControlCenter = New PageSettings
            ControlCenterHasBeenOpened = True
        End If
        Panel3.Controls.Add(ControlCenter)
        ControlCenter.Dock = DockStyle.Fill
    End Sub

    ''' <summary>This closes the Control Center</summary>
    Private Sub CloseControlCenter()
        IsControlCenterOpen = False
        HideTaskbar(False)
        Panel3.Controls.Remove(ControlCenter)
        Try
            currentForm.Show()
        Catch ex As Exception

        End Try
        'Form1.ControlCenter.Dock = DockStyle.Fill
    End Sub

    Public BatteryPower As Int64 = 100
    Public HasBattery As Boolean = False

    Private Sub UpdateBatteryStatus()
        Dim batteryStatus As PowerStatus = SystemInformation.PowerStatus
        Dim batteryPercent As Integer = CInt(batteryStatus.BatteryLifePercent * 100)
        'Dim pbBattery As New ProgressBar
        If batteryStatus.BatteryChargeStatus = BatteryChargeStatus.NoSystemBattery Then
            HasBattery = False
        Else
            HasBattery = True
        End If
        'lblBattery.Text = "Battery: " & batteryPercent.ToString() & "%"
        BatteryPower = batteryPercent
        'pbBattery.Value = batteryPercent
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        UI.RunCommands("RunApp Form55")
        'FToL.Show()
    End Sub

    Private Sub InstagramButton_Click(sender As Object, e As EventArgs) Handles InstagramButton.Click
        UI.RunApp("InstagramApp")
    End Sub

    Private Sub FacebookButton_Click(sender As Object, e As EventArgs) Handles FacebookButton.Click
        UI.RunApp("FacebookApp")
    End Sub

    Private Sub SpotifyButton_Click(sender As Object, e As EventArgs) Handles SpotifyButton.Click
        UI.RunApp("SpotifyApp")
    End Sub

    Private Sub CommanderWindowedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommanderWindowedToolStripMenuItem.Click
        If DisableConsole = False Then
            Commander.Show()
            Commander.FormBorderStyle = FormBorderStyle.Sizable
            Commander.ShowIcon = True
            Commander.ShowInTaskbar = True
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If UI.DisableOpenFramework = False Then
            OpenFramework_Data.SaveButtonOrder()
        End If
    End Sub
End Class
