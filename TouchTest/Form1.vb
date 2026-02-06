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
    Public AllowNewerLoader As Boolean = True

    Public User As UserManager
    Private lang As New LanguageManager()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LoadDebugMenu.setting") Then
            MenuStrip1.Visible = True
        End If

        AddHandler Button3.Click, AddressOf SettingsForm.PluginButton_Click

        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\DisableConsole.setting") Then
            Try
                DisableConsole = Convert.ToBoolean(My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\DisableConsole.setting"))
            Catch ex As Exception

            End Try
        End If

        If AllowNewerLoader = True Then
            If Environment.CommandLine.Contains("/UseOldLoader") Then
                UserManager.LoadShellColors()

                UserManager.CheckForDarkThemeFile()

                UserManager.LoadWallpaperFromUserSettings()
            Else
                User.LoadUserSettings()
            End If
        Else
            UserManager.LoadShellColors()

            UserManager.CheckForDarkThemeFile()

            UserManager.LoadWallpaperFromUserSettings()
        End If


        If IsUsingDarkThemeForPrograms = True Then
            Panel2.BackColor = Color.FromArgb(55, Color.Gray)
            TimebarPanel.BackColor = Color.FromArgb(55, Color.Gray)
        ElseIf IsUsingDarkThemeForPrograms = False Then
            Panel2.BackColor = Color.FromArgb(55, Color.Silver)
            TimebarPanel.BackColor = Color.FromArgb(55, Color.Silver)
        End If

        If UI.DisableOpenFramework = False Then
            OpenFramework_Data.LoadApps()

            UserManager.LoadTaskbarButtons()
        End If

        'Checks if DisableCustomCode is false
        If UI.DisableCustomCode = False Then

            'This checks if the Registry value "LoadCustomPls" exists.
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
                    UI.ShowError("Your running in an unsafe mode. Close the program if you don't know what you're doing.", ErrorMSGBox.Alerts.Exclamation)
                End If
            End If
        End If





    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function Funnything() As Panel
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
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        Panel3.Controls.Add(childForm)
        Panel3.Tag = childForm
        childForm.Size = New Size(Me.Size.Width, Me.Size.Height - 57)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs)
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
                OpenFramework_Data.AppName = ""
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

    Public I_Am_Here As Object

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

    Public IsControlCenterOpen As Boolean = False
    Public ControlCenterHasBeenOpened As Boolean = False
    Public ControlCenter As PageSettings

    ''' <summary>This opens the Control Center</summary>
    Public Sub ShowControlCenter()
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
    Public Sub CloseControlCenter()
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
