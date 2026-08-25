Public Class LoadingUser
    Public User As UserManager

    Public Username As String = Nothing
    Public Password As String = Nothing

    Private Sub LoadingUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Username = User.Username
        Catch ex As Exception
        End Try

        Dim TheURL As String = "file:///" & UI.SettingsFolder & "\Page\index.html"
        TheURL = TheURL.Replace("\", "/")

        WebView21.Source = New Uri(TheURL)

        If Environment.CommandLine.Contains("/DevMode") = True Then
            ProgressBar1.Visible = True
        End If
    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            'WebView21.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Light
            WebView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = False
            If Environment.CommandLine.Contains("/DevMode") Then
            Else
                WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
                WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
                WebView21.CoreWebView2.Settings.IsZoomControlEnabled = False
                WebView21.CoreWebView2.Settings.IsStatusBarEnabled = False
                WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
            End If
            'If Not WebView21.CoreWebView2.Profile.DefaultDownloadFolderPath = User.UserFolderPath & "\Downloads\" Then
            '    WebView21.CoreWebView2.Profile.DefaultDownloadFolderPath = User.UserFolderPath & "\Downloads\"
            'End If


        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            If Username = "" Then
                Close()
            Else
                UI.DisableOpenFramework = False
                UI.DisableCustomCode = False
                UI.LoadShell(Username, Password)
                Close()
            End If
        Else
            If ProgressBar1.Value = 10 Then
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles") = False Then
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles", TryController.GetVersion(), False)
                Else
                    Dim tempreader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles")
                    Dim VersionOB As New Version(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles"))

                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles", TryController.GetVersion(), False)

                    If VersionOB.Revision < 600 Then
                        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles", TryController.GetVersion(), False)

                        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Temp") Then
                            My.Computer.FileSystem.DeleteDirectory(My.Application.Info.DirectoryPath & "\Temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
                            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Temp")

                            My.Computer.FileSystem.WriteAllBytes(My.Application.Info.DirectoryPath & "\Temp\NewLogonPage.zip", My.Resources.NewLogonPage, False)

                            If My.Computer.FileSystem.DirectoryExists(UI.SettingsFolder & "\Page") Then
                                My.Computer.FileSystem.DeleteDirectory(UI.SettingsFolder & "\Page", FileIO.DeleteDirectoryOption.DeleteAllContents)
                            End If

                            My.Computer.FileSystem.CreateDirectory(UI.SettingsFolder & "\Page")
                            IO.Compression.ZipFile.ExtractToDirectory(My.Application.Info.DirectoryPath & "\Temp\NewLogonPage.zip", My.Application.Info.DirectoryPath & "\Temp\Page")

                            Dim TheURL As String = "file:///" & UI.SettingsFolder & "\Page\index.html"
                            TheURL = TheURL.Replace("\", "/")

                            WebView21.Source = New Uri(TheURL)
                        End If

                        If My.Computer.FileSystem.DirectoryExists(User.UserFolderPath & "\Settings\PastNotifications") = False Then
                            My.Computer.FileSystem.CreateDirectory(User.UserFolderPath & "\Settings\PastNotifications")
                        End If

                        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Apps\Settings") Then
                            My.Computer.FileSystem.DeleteDirectory(My.Application.Info.DirectoryPath & "\Apps\Settings", FileIO.DeleteDirectoryOption.DeleteAllContents)
                        End If

                        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\TempApp.tryapp") Then
                            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\TempApp.tryapp")
                        End If

                        My.Computer.FileSystem.WriteAllBytes(My.Application.Info.DirectoryPath & "\TempApp.tryapp", My.Resources.SettingsApp, False)
                        TryOS_Store_Manager.Class1.InstallTryOSApp(My.Application.Info.DirectoryPath & "\TempApp.tryapp")

                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\TempApp.tryapp")

                        If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & Username & "\Settings\WallpaperImage.swfiles") = False Then
                            If My.Computer.FileSystem.FileExists(UI.UsersFolder & "\" & Username & "\Settings\Software.swfiles") Then
                                Dim tempusersetting As String = My.Computer.FileSystem.ReadAllText(UI.UsersFolder & "\" & Username & "\Settings\Software.swfiles")
                                Dim b As Byte() = Convert.FromBase64String(tempusersetting)
                                tempusersetting = System.Text.Encoding.UTF8.GetString(b)
                                b = Convert.FromBase64String(tempusersetting)
                                tempusersetting = System.Text.Encoding.UTF8.GetString(b)

                                tempusersetting = tempusersetting.Replace("Wallpaper=jpg", "Wallpaper_jpg")
                                tempusersetting = tempusersetting.Replace("Wallpaper=png", "Wallpaper_png")
                                tempusersetting = tempusersetting.Replace("Wallpaper=gif", "Wallpaper_gif")

                                User.SaveUserSettings(tempusersetting)
                                '1 = jpg
                                '2 = png
                                '3 = gif
                                Dim tempformat As String = Nothing
                                If User.Contains("Wallpaper_jpg") = True Then
                                    Dim reader As String = User.ReadSetting("Wallpaper_jpg")
                                    Dim data As String = UI.WallpaperFolder & "\Wallpaper_" & reader & ".jpg"

                                    Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(data)
                                    data = Convert.ToBase64String(byt)
                                    byt = System.Text.Encoding.UTF8.GetBytes(data)
                                    data = Convert.ToBase64String(byt)

                                    My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & Username & "\Settings\WallpaperImage.swfiles", data, False)
                                    tempformat = "Wallpaper_jpg"
                                ElseIf User.Contains("Wallpaper_png") = True Then
                                    Dim reader As String = User.ReadSetting("Wallpaper_png")
                                    Dim data As String = UI.WallpaperFolder & "\Wallpaper_" & reader & ".png"

                                    Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(data)
                                    data = Convert.ToBase64String(byt)
                                    byt = System.Text.Encoding.UTF8.GetBytes(data)
                                    data = Convert.ToBase64String(byt)

                                    My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & Username & "\Settings\WallpaperImage.swfiles", data, False)
                                    tempformat = "Wallpaper_png"
                                ElseIf User.Contains("Wallpaper_gif") = True Then
                                    Dim reader As String = User.ReadSetting("Wallpaper_gif")
                                    Dim data As String = UI.WallpaperFolder & "\Wallpaper_" & reader & ".gif"

                                    Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(data)
                                    data = Convert.ToBase64String(byt)
                                    byt = System.Text.Encoding.UTF8.GetBytes(data)
                                    data = Convert.ToBase64String(byt)

                                    My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & Username & "\Settings\WallpaperImage.swfiles", data, False)
                                    tempformat = "Wallpaper_gif"
                                End If

                                User.ChangeSetting(UserManager.SettingType.Remove, tempformat)
                            End If
                        End If

                        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Wallpaper.zip") = False Then
                            My.Computer.FileSystem.WriteAllBytes(My.Application.Info.DirectoryPath & "\Wallpaper.zip", My.Resources.WallpaperNew, False)
                        End If

                        IO.Compression.ZipFile.ExtractToDirectory(My.Application.Info.DirectoryPath & "\Wallpaper.zip", UI.WallpaperFolder)

                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Wallpaper.zip")
                    End If
                End If
            ElseIf ProgressBar1.Value = 20 Then
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\UpdateTryOS_Store.setting") Then
                    My.Computer.FileSystem.DeleteDirectory(My.Application.Info.DirectoryPath & "\Apps\TryOS_Store", FileIO.DeleteDirectoryOption.DeleteAllContents)

                    Dim NewTryOS_StoreVersion As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Settings\UpdateTryOS_Store.setting")

                    TryOS_Store_Manager.Class1.InstallTryOSApp(NewTryOS_StoreVersion, TryController.GetVersion())

                    My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Settings\UpdateTryOS_Store.setting")
                    My.Computer.FileSystem.DeleteFile(NewTryOS_StoreVersion)
                End If
            ElseIf ProgressBar1.Value = 40 Then
                If Environment.CommandLine.Contains("/KeepDllPathTryOS_Store") = False Then
                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Apps\TryOS_Store\Main.dll") Then
                    ElseIf My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Apps\TryOS_Store\TryOS_Store.dll") Then
                        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Apps\TryOS_Store\DllPath.txt") = False Then
                            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Apps\TryOS_Store\DllPath.txt", My.Application.Info.DirectoryPath & "\Apps\TryOS_Store\TryOS_Store.dll", False)
                        End If
                    End If
                End If
            ElseIf ProgressBar1.Value = 50 Then

            ElseIf ProgressBar1.Value = 60 Then
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Taskbar_Order.json") Then
                    My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Taskbar_Order.json", "TaskInteracter_Order.json")
                    Try
                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Taskbar_Order.json")
                    Catch ex As Exception
                        If Environment.CommandLine.Contains("/DevMode") = True Then
                            TryController.DebugManager.WriteLine(ex.Message)
                        End If
                    End Try
                End If
            ElseIf ProgressBar1.Value = 70 Then
                Dim CloseFormQ As Boolean = False
                For Each Formthing As Form In My.Application.OpenForms
                    If Formthing.Name = "Form1" Then
                        CloseFormQ = True
                    End If
                Next
                If CloseFormQ = True Then
                    UI.DisableOpenFramework = True
                    Form1.Close()
                    UI.DisableOpenFramework = False
                    Form1.User = User
                    'Form1.User = New UserManager(Username)
                Else
                    Form1.User = User
                    'Form1.User = New UserManager(Username)
                End If

            End If

            ProgressBar1.Increment(1)
        End If
    End Sub
End Class