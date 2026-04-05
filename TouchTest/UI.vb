Imports System.Reflection
Imports TouchTest

Public Class UI
    Public ReadOnly ShellAppIDs As String() = {"825162", "936352", "84364983", "7384648"}

    Public AppsFolder As String = My.Application.Info.DirectoryPath & "\Apps"
    Public SettingsFolder As String = My.Application.Info.DirectoryPath & "\Settings"
    Public WallpaperFolder As String = My.Application.Info.DirectoryPath & "\Wallpapers"
    Public UsersFolder As String = My.Application.Info.DirectoryPath & "\Users"

    'The User that's logged in's Folder
    Public UserFolder As String = My.Application.Info.DirectoryPath & "\Users\"

    Public DisableOpenFramework As Boolean = False
    Public DisableCustomCode As Boolean = False

    Public Function RunCommands(Command As String, Optional TheForm As Object = Nothing)
        If Command.Contains("exit") = True Then
            Try
                TheForm.Close()
            Catch ex As Exception

            End Try
            Return Nothing
        ElseIf Command.Contains("end") = True Then
            Try
                Form1.Close()
                End
            Catch ex As Exception
                System.Threading.Thread.Sleep(1000)
            End Try
            Return Nothing
        ElseIf Command.Contains("windowmode=mini") = True Then
            Try
                TheForm.WindowState = FormWindowState.Minimized
                TheForm.ShowInTaskbar = False
            Catch ex As Exception

            End Try
            Return Nothing
        ElseIf Command.Contains("run ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("run ", "")
            RunShellPrograms(Text1)
            Return Nothing
        ElseIf Command.Contains("start ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("start ", "")
            OpenFormByName("TouchTest." & Text1)
            Return Nothing
        ElseIf Command.Contains("RunApp ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("RunApp ", "")
            Form1.OpenChildForm(GetForm("TouchTest." & Text1))
            Return Nothing
        ElseIf Command.Contains("RunOpenFrameworkApp ") = True Then
            Command = Command.Replace("Console>", "")
            Command = Command.Replace("RunOpenFrameworkApp ", "")
            Form1.OpenChildForm(GetFormFromAppDll(Command))
            Return Nothing
        ElseIf Command.Contains("GetBranch") = True Then
            Return TryController.GetBranch
        ElseIf Command.Contains("SetWallpaper ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("SetWallpaper ", "")
            Form1.Panel1.BackgroundImage = Bitmap.FromFile(Text1)
            Return $"Loaded Wallpaper from {Text1}"
        ElseIf Command.Contains("GetWallpaper") = True Then
            Return Form1.Panel1.BackgroundImage
        ElseIf Command.Contains("whoami") = True Then
            If Command.Contains("/nogui") = True Then
                Return Form1.User.Role
            Else
                Dim TheRole As TryController.Roles = Form1.User.Role
                Dim StringRole As String

                If TheRole = TryController.Roles.Guest Then
                    StringRole = "Guest"
                ElseIf TheRole = TryController.Roles.Standard Then
                    StringRole = "Standard"
                ElseIf TheRole = TryController.Roles.Administrator Then
                    StringRole = "Administrator"
                ElseIf TheRole = TryController.Roles.Program Then
                    StringRole = "Program"
                ElseIf TheRole = TryController.Roles.Developer Then
                    StringRole = "Developer"
                Else
                    StringRole = "Unknown"
                End If
                ShowError(StringRole, ErrorMSGBox.Alerts.Information)
                Return StringRole
            End If
        ElseIf Command.Contains("ThemeManager") = True Then
            If Command.Contains("/GetResource") = True Then
                If Command.Contains(" DarkModeForApps") = True Then
                    Return Form1.IsUsingDarkThemeForApps
                ElseIf Command.Contains(" DarkModeForPrograms") = True Then
                    Return Form1.IsUsingDarkThemeForPrograms
                Else
                    Return Nothing
                End If
            ElseIf Command.Contains("/SetResource") = True Then
                If Command.Contains(" DarkModeForApps") = True Then
                    Command = Command.Replace("Console>", "")
                    Command = Command.Replace("ThemeManager /SetResource DarkModeForApps=", "")
                    Try
                        Form1.IsUsingDarkThemeForApps = Convert.ToBoolean(Command)
                    Catch ex As Exception
                    End Try
                    Return Command
                ElseIf Command.Contains(" DarkModeForPrograms") = True Then
                    Command = Command.Replace("Console>", "")
                    Command = Command.Replace("ThemeManager /SetResource DarkModeForPrograms=", "")
                    Try
                        Form1.IsUsingDarkThemeForPrograms = Convert.ToBoolean(Command)
                    Catch ex As Exception
                    End Try
                    Return Command

                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        ElseIf Command.Contains("Loadjpg ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("Loadjpg ", "")
            UploadWallpaperToShell(Convert.ToInt64(Text1), "jpg")
            Return Nothing
        ElseIf Command.Contains("Loadpng ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("Loadpng ", "")
            UploadWallpaperToShell(Convert.ToInt64(Text1), "png")
            Return Nothing
        ElseIf Command.Contains("Loadgif ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("Loadgif ", "")
            UploadWallpaperToShell(Convert.ToInt64(Text1), "gif")
            Return Nothing
        ElseIf Command.Contains("RunUserControl ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("RunUserControl ", "")
            RunUserControl(Text1)
            Return Nothing
        ElseIf Command.Contains("installapp ") = True Then
            Dim Text1 As String = Command
            Text1 = Text1.Replace("Console>", "")
            Text1 = Text1.Replace("installapp ", "")
            TryOS_Store_Manager.Class1.InstallTryOSApp(Text1)
            Return Nothing
        ElseIf Command.Contains("RunTestSniper") = True Then
            Dim gg As New Sniper
            gg.ShowDialog()
            Return Nothing
        ElseIf Command.Contains("RunTestFileExplorer") = True Then
            TestFileExplorer.Show()
            Return Nothing
        ElseIf Command.Contains("RunUserTestFileExplorer") = True Then
            TestFileExplorer.rootPath = UserFolder
            TestFileExplorer.Show()
            Return Nothing
        ElseIf Command.Contains("Restore-TryOS-Store") = True Then
            If My.Computer.FileSystem.DirectoryExists(AppsFolder & "\TryOS_Store") Then
                My.Computer.FileSystem.DeleteDirectory(AppsFolder & "\TryOS_Store", FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
            My.Computer.FileSystem.WriteAllBytes(My.Application.Info.DirectoryPath & "\Store.tryapp", My.Resources.TryOS_Store, False)
            TryOS_Store_Manager.Class1.InstallTryOSApp(My.Application.Info.DirectoryPath & "\Store.tryapp")
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Store.tryapp", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Return Nothing
        Else
            Return Nothing
        End If
    End Function
    Public Sub StartCMD(Optional GG As String = "New")
        Form1.OpenChildForm(New Commander)
    End Sub

    Public LogonBool As Boolean = False

    Public Sub RunUserControl(UserControl As String)
        Dim UserControlThing = UserControl
        If UserControl = "InfoApp" Then
            Dim WindowThing As New Form
            Dim UserControlThing2 As New InfoApp
            WindowThing.Dock = DockStyle.None
            WindowThing.Controls.Add(UserControlThing2)
            WindowThing.Size = UserControlThing2.Size
            WindowThing.Text = UserControlThing2.Name
            WindowThing.Show()
        ElseIf UserControl = "Search_App" Then
            Dim WindowThing As New Form
            Dim UserControlThing2 As New Search_App
            WindowThing.Dock = DockStyle.None
            WindowThing.Controls.Add(UserControlThing2)
            WindowThing.Size = UserControlThing2.Size
            WindowThing.Text = UserControlThing2.Name
            WindowThing.Show()
        ElseIf UserControl = "StartMenu_GUI" Then
            Dim WindowThing As New Form
            Dim UserControlThing2 As New StartMenu_GUI
            WindowThing.Dock = DockStyle.None
            WindowThing.Controls.Add(UserControlThing2)
            WindowThing.Size = UserControlThing2.Size
            WindowThing.Text = UserControlThing2.Name
            WindowThing.Show()
        ElseIf UserControl = "SettingsApp" Then
            Dim WindowThing As New Form
            Dim UserControlThing2 As New SettingsApp
            WindowThing.Dock = DockStyle.None
            WindowThing.Controls.Add(UserControlThing2)
            WindowThing.Size = UserControlThing2.Size
            WindowThing.Text = UserControlThing2.Name
            WindowThing.Show()
        ElseIf UserControl = "Taskbar_GUI" Then
            Dim WindowThing As New Form
            Dim UserControlThing2 As New Taskbar_GUI
            WindowThing.Dock = DockStyle.None
            WindowThing.Controls.Add(UserControlThing2)
            WindowThing.Size = UserControlThing2.Size
            WindowThing.Text = UserControlThing2.Name
            WindowThing.Show()
        ElseIf UserControl = "ThemeApp" Then
            Dim WindowThing As New Form
            Dim UserControlThing2 As New ThemeApp
            WindowThing.Dock = DockStyle.None
            WindowThing.Controls.Add(UserControlThing2)
            WindowThing.Size = UserControlThing2.Size
            WindowThing.Text = UserControlThing2.Name
            WindowThing.Show()
        ElseIf UserControl = "UserSettingsApp" Then
            Dim WindowThing As New Form
            Dim UserControlThing2 As New UserSettingsApp
            WindowThing.Dock = DockStyle.None
            WindowThing.Controls.Add(UserControlThing2)
            WindowThing.Size = UserControlThing2.Size
            WindowThing.Text = UserControlThing2.Name
            WindowThing.Show()
        ElseIf UserControl = "WifiPanel" Then
            Dim WindowThing As New Form
            Dim UserControlThing2 As New WifiPanel
            WindowThing.Dock = DockStyle.None
            WindowThing.Controls.Add(UserControlThing2)
            WindowThing.Size = UserControlThing2.Size
            WindowThing.Text = UserControlThing2.Name
            WindowThing.Show()
        End If
    End Sub

    Public Sub CreateNewUser(Username As String, Password As String)

    End Sub

    Public Sub LoadShell(Optional Username As String = "", Optional Password As String = "")
        If Username = "" Then

        Else
            Form1.Username = Username
            Form1.Password = Password
        End If
        Form1.Show()
        'Form1.Panel2.BackColor = Color.FromArgb(55, Color.Silver)
        'Form1.TimebarPanel.BackColor = Color.FromArgb(55, Color.Silver)

    End Sub

    Public Sub RunShellPrograms(Run_ As String)
        If Run_ = "LogonPage" Then
            Form48.Show()
            Console.ShowInTaskbar = False
            Console.WindowState = FormWindowState.Minimized
        ElseIf Run_ = "shell" Then
            LoadShell()
            Console.ShowInTaskbar = False
            Console.WindowState = FormWindowState.Minimized
        ElseIf Run_ = "Data" Then
            Data_Formater.Show()
        End If
    End Sub

    Public Sub Run(Run_ As String)

        If Run_ = "Form1" Then
            Form1.Show()
        ElseIf Run_ = "Form15" Then
            Form15.Show()
        ElseIf Run_ = "Form48" Then
            Form48.Show()
        ElseIf Run_ = "AppRunner" Then
            AppRunner.Show()
        ElseIf Run_ = "Console" Then
            Console.Show()
        ElseIf Run_ = "Internetplusplus" Then
            Internetplusplus.Show()
        ElseIf Run_ = "load at start" Then
            load_at_start.Show()
        ElseIf Run_ = "UI" Then
            Show()
        ElseIf Run_ = "About2" Then
            About2.Show()
        ElseIf Run_ = "Data Formater" Then
            Data_Formater.Show()
        ElseIf Run_ = "SettingsForm" Then
            SettingsForm.Show()
        ElseIf Run_ = "HelpWindow" Then
            HelpWindow.Show()
        ElseIf Run_ = "DebugApp" Then
            DebugApp.Show()
        ElseIf Run_ = "YoutubeApp" Then
            YoutubeApp.Show()
        ElseIf Run_ = "UUWApp" Then
            UUWApp.Show()
        ElseIf Run_ = "USWApp" Then
            USWApp.Show()
        ElseIf Run_ = "Commander" Then
            Commander.Show()
        ElseIf Run_ = "SettingsForm" Then
            SettingsForm.Show()
        ElseIf Run_ = "TryController" Then
            TryController.Show()
        ElseIf Run_ = "About2" Then
            About2.Show()
        ElseIf Run_ = "YoutubeApp" Then
            YoutubeApp.Show()
        End If
    End Sub

    Public Sub RunApp(Run_ As String, Optional arg1 As String = "Null=Nothing")
        If Run_ = "Settings" Then
            If Form1.IsSettingOpen = False Then
                Form1.OpenChildForm(New SettingsForm)
                Form1.IsSettingOpen = True
            End If
            If Form1.IsInstagramAppOpen = True Then
                Form1.IsInstagramAppOpen = False
            End If
            If Form1.IsFacebookAppOpen = True Then
                Form1.IsFacebookAppOpen = False
            End If
            If Form1.IsInternetOpen = True Then
                Form1.IsInternetOpen = False
            End If
            If Form1.IsQuickNotesOpen = True Then
                Form1.IsQuickNotesOpen = False
            End If
            If Form1.IsYoutubeAppOpen = True Then
                Form1.IsYoutubeAppOpen = False
            End If
            If Form1.IsSpotifyAppOpen = True Then
                Form1.IsSpotifyAppOpen = False
            End If
        ElseIf Run_ = "Internet++" Then
            If Form1.IsInternetOpen = False Then
                Form1.OpenChildForm(New Internetplusplus)
                Form1.IsInternetOpen = True
            End If
            If Form1.IsInstagramAppOpen = True Then
                Form1.IsInstagramAppOpen = False
            End If
            If Form1.IsFacebookAppOpen = True Then
                Form1.IsFacebookAppOpen = False
            End If
            If Form1.IsSettingOpen = True Then
                Form1.IsSettingOpen = False
            End If
            If Form1.IsQuickNotesOpen = True Then
                Form1.IsQuickNotesOpen = False
            End If
            If Form1.IsYoutubeAppOpen = True Then
                Form1.IsYoutubeAppOpen = False
            End If
            If Form1.IsSpotifyAppOpen = True Then
                Form1.IsSpotifyAppOpen = False
            End If
        ElseIf Run_ = "QuickNotes" Then
            If Form1.IsQuickNotesOpen = False Then
                Form1.OpenChildForm(New Form15)
                If arg1 = "" Then
                ElseIf arg1 = "Null=Nothing" Then
                Else

                End If
                Form1.IsQuickNotesOpen = True
            End If
            If Form1.IsInstagramAppOpen = True Then
                Form1.IsInstagramAppOpen = False
            End If
            If Form1.IsFacebookAppOpen = True Then
                Form1.IsFacebookAppOpen = False
            End If
            If Form1.IsSettingOpen = True Then
                Form1.IsSettingOpen = False
            End If
            If Form1.IsInternetOpen = True Then
                Form1.IsInternetOpen = False
            End If
            If Form1.IsYoutubeAppOpen = True Then
                Form1.IsYoutubeAppOpen = False
            End If
            If Form1.IsSpotifyAppOpen = True Then
                Form1.IsSpotifyAppOpen = False
            End If
        ElseIf Run_ = "YoutubeApp" Then
            If Form1.IsYoutubeAppOpen = False Then
                Form1.OpenChildForm(New YoutubeApp)
                Form1.IsYoutubeAppOpen = True
            End If
            If Form1.IsInstagramAppOpen = True Then
                Form1.IsInstagramAppOpen = False
            End If
            If Form1.IsFacebookAppOpen = True Then
                Form1.IsFacebookAppOpen = False
            End If
            If Form1.IsSettingOpen = True Then
                Form1.IsSettingOpen = False
            End If
            If Form1.IsInternetOpen = True Then
                Form1.IsInternetOpen = False
            End If
            If Form1.IsQuickNotesOpen = True Then
                Form1.IsQuickNotesOpen = False
            End If
            If Form1.IsSpotifyAppOpen = True Then
                Form1.IsSpotifyAppOpen = False
            End If
        ElseIf Run_ = "InstagramApp" Then
            If Form1.IsInstagramAppOpen = False Then
                Form1.OpenChildForm(New InstagramApp)
                Form1.IsInstagramAppOpen = True
            End If
            If Form1.IsFacebookAppOpen = True Then
                Form1.IsFacebookAppOpen = False
            End If
            If Form1.IsYoutubeAppOpen = True Then
                Form1.IsYoutubeAppOpen = False
            End If
            If Form1.IsSettingOpen = True Then
                Form1.IsSettingOpen = False
            End If
            If Form1.IsInternetOpen = True Then
                Form1.IsInternetOpen = False
            End If
            If Form1.IsQuickNotesOpen = True Then
                Form1.IsQuickNotesOpen = False
            End If
            If Form1.IsSpotifyAppOpen = True Then
                Form1.IsSpotifyAppOpen = False
            End If
        ElseIf Run_ = "FacebookApp" Then
            If Form1.IsFacebookAppOpen = False Then
                Form1.OpenChildForm(New FacebookApp)
                Form1.IsFacebookAppOpen = True
            End If
            If Form1.IsInstagramAppOpen = True Then
                Form1.IsInstagramAppOpen = False
            End If
            If Form1.IsYoutubeAppOpen = True Then
                Form1.IsYoutubeAppOpen = False
            End If
            If Form1.IsSettingOpen = True Then
                Form1.IsSettingOpen = False
            End If
            If Form1.IsInternetOpen = True Then
                Form1.IsInternetOpen = False
            End If
            If Form1.IsQuickNotesOpen = True Then
                Form1.IsQuickNotesOpen = False
            End If
            If Form1.IsSpotifyAppOpen = True Then
                Form1.IsSpotifyAppOpen = False
            End If
        ElseIf Run_ = "SpotifyApp" Then
            If Form1.IsSpotifyAppOpen = False Then
                Form1.OpenChildForm(New SpotifyApp)
                Form1.IsSpotifyAppOpen = True
            End If
            If Form1.IsInstagramAppOpen = True Then
                Form1.IsInstagramAppOpen = False
            End If
            If Form1.IsFacebookAppOpen = True Then
                Form1.IsFacebookAppOpen = False
            End If
            If Form1.IsYoutubeAppOpen = True Then
                Form1.IsYoutubeAppOpen = False
            End If
            If Form1.IsSettingOpen = True Then
                Form1.IsSettingOpen = False
            End If
            If Form1.IsInternetOpen = True Then
                Form1.IsInternetOpen = False
            End If
            If Form1.IsQuickNotesOpen = True Then
                Form1.IsQuickNotesOpen = False
            End If
        End If
    End Sub

    Public GiveValuestoForm1 As Boolean = True
    Public WallpaperNumber As Integer = 1
    Public Sub UploadWallpaperToShell(Number As Integer, FileFormat As String)
        If FileFormat.StartsWith(".") Then
            FileFormat = FileFormat.Replace(".", "")
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Wallpapers\Wallpaper_" & Number.ToString & "." & FileFormat) Then
            WallpaperNumber = Number

            Dim Test As Bitmap = Bitmap.FromFile(WallpaperFolder & "\Wallpaper_" & Number.ToString & "." & FileFormat)
            'Dim sd As New PictureBox
            'sd.Load(My.Application.Info.DirectoryPath & "\Wallpapers\Wallpaper_" & Number.ToString & "." & FileFormat)
            Form1.Panel1.BackgroundImage = Test
            If GiveValuestoForm1 = True Then
                Form1.LoadedWallpaper = Number
                Form1.WallpaperFileFormat = FileFormat
            End If
        Else
            If Number = 0 Then
            Else
                Dim Number2 As Integer = Number
                Number2 = Number2 - 1
                UploadWallpaperToShell(Number2, FileFormat)
            End If
        End If
    End Sub

    Public Sub LogOut()
        Try
            Form1.currentForm.Close()
        Catch ex As Exception
        End Try
        Form1.Close()
        UserFolder = UsersFolder & "\"
        System.Threading.Thread.Sleep(500)
        LogonBool = False
        LogonForm.Show()
        System.Threading.Thread.Sleep(500)
        Close()
    End Sub

    Public IsKeyboardEnabled As Boolean = False

    Public Function GetKeyboard(Optional KeepText As String = Nothing) As DialogResult
        Keyboard.TextBox1.Text = KeepText
        If Keyboard.ShowDialog = DialogResult.OK Then
            Return DialogResult.OK
        Else
            Return DialogResult.Cancel
        End If
    End Function

    Public InfoForms_Info As String = "OnlyOkButton"

    Public Sub GetIntoToInfoForm(Optional OnlyOk As Boolean = True, Optional OKCancelOrYesNo As Boolean = False)
        If OnlyOk = True Then
            InfoForms_Info = "OnlyOkButton"
        ElseIf OnlyOk = False Then
            If OKCancelOrYesNo = True Then
                InfoForms_Info = "YesNoButton"
            ElseIf OKCancelOrYesNo = False Then
                InfoForms_Info = "OKCancelButton"
            End If
        End If
    End Sub

    ' GetIntoToInfoForm(True)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.OK Then
    '            MsgBox("This Worked!")
    '        End If
    'ElseIf CommandText.Contains("msg 2ok") = True Then
    '        GetIntoToInfoForm(False, False)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.OK Then
    '            MsgBox("This Worked!")
    '        End If
    'ElseIf CommandText.Contains("msg cal") = True Then
    '        GetIntoToInfoForm(False, False)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.Cancel Then
    '            MsgBox("This Worked!")
    '        End If
    'ElseIf CommandText.Contains("msg yes") = True Then
    '        GetIntoToInfoForm(False, True)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.Yes Then
    '            MsgBox("This Worked!")
    '        End If
    'ElseIf CommandText.Contains("msg no") = True Then
    '        GetIntoToInfoForm(False, True)
    '        InfoDialog.TextBox1.Text = "This is a test"
    '        If InfoDialog.ShowDialog = DialogResult.No Then
    '            MsgBox("This Worked!")
    '        End If

    Public Sub OpenFormByName(formName As String)
        ' Get the current assembly
        Dim asm As Assembly = Assembly.GetExecutingAssembly()

        ' Get the type from the assembly by name
        Dim formType As Type = asm.GetType(formName)

        ' Check if the type exists and is a Form
        If formType IsNot Nothing AndAlso formType.IsSubclassOf(GetType(Form)) Then
            ' Create an instance of the form dynamically
            Dim formInstance As Form = CType(Activator.CreateInstance(formType), Form)
            Try
                formInstance.Show()
            Catch ex As Exception

            End Try
        Else
            MsgBox("Form '" & formName & "' not found or is not a valid Form.")
        End If
    End Sub

    Public Function GetForm(formName As String) As Object
        ' Get the current assembly
        Dim asm As Assembly = Assembly.GetExecutingAssembly()

        ' Get the type from the assembly by name
        Dim formType As Type = asm.GetType(formName)

        ' Check if the type exists and is a Form
        If formType IsNot Nothing AndAlso formType.IsSubclassOf(GetType(Form)) Then
            ' Create an instance of the form dynamically
            Dim formInstance As Form = CType(Activator.CreateInstance(formType), Form)
            'formInstance.Show()
            Return formInstance
        Else
            MsgBox("Form '" & formName & "' not found or is not a valid Form.")
            Return Nothing
        End If
    End Function

    Public Function GetFormFromAppDll(DllPath As String) As Object
        Try
            Dim asm As Assembly = Assembly.LoadFrom(DllPath)

            ' Find all types that implement OpenFramework_Interface
            For Each t In asm.GetTypes()
                If GetType(OpenFramework_Interface).IsAssignableFrom(t) AndAlso Not t.IsInterface AndAlso Not t.IsAbstract Then
                    Try
                        Dim plugin As OpenFramework_Interface = CType(Activator.CreateInstance(t), OpenFramework_Interface)
                        Return plugin.GetForm()
                    Catch ex As Exception
                        ShowError(ex.Message)
                        Debug.WriteLine(ex.Message)

                    End Try
                End If
            Next
            Return Nothing
        Catch Exceptionthing As Exception
            ShowError(Exceptionthing.Message)
            Debug.WriteLine(Exceptionthing.Message)
            Return Nothing
        End Try
    End Function

    Public Sub ChangeObjectPropertyByName(container As Object, objectName As String, propertyName As String, value As Object)
        ' Get the field (control) from the container using reflection
        Dim objField As FieldInfo = container.GetType().GetField(objectName, BindingFlags.NonPublic Or BindingFlags.Instance)

        If objField IsNot Nothing Then
            Dim controlObj As Object = objField.GetValue(container)

            ' Get the property to change
            Dim prop As PropertyInfo = controlObj.GetType().GetProperty(propertyName)

            If prop IsNot Nothing AndAlso prop.CanWrite Then
                prop.SetValue(controlObj, value)
            Else
                MessageBox.Show("Property not found or not writable.")
            End If
        Else
            MessageBox.Show("Object not found.")
        End If
    End Sub
    'ChangeObjectPropertyByName(Me, "Button1", "Text", "Clicked!")

    Public Sub ShowStopWindow(ex As Exception)
        Dim MyForm As New StopWindow
        MyForm.RichTextBox1.Text = ex.Message & "

" & ex.Source
        MyForm.Show()
    End Sub

    Public Sub ShowStopWindow(ex As String)
        Dim MyForm As New StopWindow
        MyForm.RichTextBox1.Text = ex
        MyForm.Show()
    End Sub

    Public Sub ShowStopWindow(ex As String, source As String)
        Dim MyForm As New StopWindow
        MyForm.FullStopMessage = ex
        MyForm.RichTextBox1.Text = ex & "

" & source

        MyForm.Show()
    End Sub

    Public Sub ShowError()
        ErrorMSGBox.ShowError("", ErrorMSGBox.Alerts.Information)
    End Sub

    Public Sub ShowError(Text As String)
        ErrorMSGBox.ShowError(Text, ErrorMSGBox.Alerts.Information)
    End Sub

    Public Sub ShowError(Text As String, Alert As ErrorMSGBox.Alerts)
        ErrorMSGBox.ShowError(Text, Alert)
    End Sub

    ''' <summary>Allows an App to enter or leave Fullscreen Mode</summary>
    Public Sub EnableFullAppMode(IsAppFull As Boolean)
        Form1.EnableFullAppMode(IsAppFull)
    End Sub
End Class