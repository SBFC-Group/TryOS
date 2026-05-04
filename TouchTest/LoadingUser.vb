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
            If Not WebView21.CoreWebView2.Profile.DefaultDownloadFolderPath = User.UserFolderPath & "\Downloads\" Then
                WebView21.CoreWebView2.Profile.DefaultDownloadFolderPath = User.UserFolderPath & "\Downloads\"
            End If
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
            If ProgressBar1.Value = 20 Then
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
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles") = False Then
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles", TryController.GetVersion(), False)
                End If
            ElseIf ProgressBar1.Value = 60 Then
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Taskbar_Order.json") Then
                    My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Taskbar_Order.json", "TaskInteracter_Order.json")
                    Try
                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Taskbar_Order.json")
                    Catch ex As Exception
                        If Environment.CommandLine.Contains("/DevMode") = True Then
                            Debug.WriteLine(ex.Message)
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
                    Form1.User = New UserManager(Username)
                Else
                    Form1.User = New UserManager(Username)
                End If

            End If

            ProgressBar1.Increment(1)
        End If
    End Sub
End Class