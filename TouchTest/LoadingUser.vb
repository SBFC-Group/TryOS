Public Class LoadingUser
    Public Username As String = Nothing
    Public Password As String = Nothing

    Private Sub LoadingUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim TheURL As String = "file:///" & UI.SettingsFolder & "\Page\index.html"
        TheURL = TheURL.Replace("\", "/")
        WebView21.Source = New Uri(TheURL)

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

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            If Username = "" Then
                Close()
            Else
                UI.DisableOpenFramework = False
                UI.DisableCustomCode = False
                'Form1.Username = Username
                'UI.UserFolder = UI.UsersFolder & "\" & Username
                UI.LoadShell(Username, Password)
                System.Threading.Thread.Sleep(500)
                Close()
            End If

        Else
            If ProgressBar1.Value = 30 Then
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Software.swfiles") Then
                Else
                    Dim SettingsListy As String = Nothing

                    'This is converting settings files to text
                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Wallpaper.swfiles") Then
                        Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Wallpaper.swfiles")
                        SettingsListy = SettingsListy & "Wallpaper=" & Reader & ";" & Environment.NewLine
                    End If
                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\DarkThemeForApps.swfiles") Then
                        Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\DarkThemeForApps.swfiles")
                        SettingsListy = SettingsListy & "IsDarkModeForApps=" & Reader & ";" & Environment.NewLine
                    End If
                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\DarkThemeForPrograms.swfiles") Then
                        Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\DarkThemeForPrograms.swfiles")
                        SettingsListy = SettingsListy & "IsDarkModeForProgram=" & Reader & ";" & Environment.NewLine
                    End If

                    If SettingsListy IsNot Nothing Then
                        Dim TempUser As New UserManager(Username)
                        TempUser.SaveUserSettings(SettingsListy)
                    End If

                End If
            ElseIf ProgressBar1.Value = 50 Then
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles") Then
                Else
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\UserVersion.swfiles", TryController.GetVersion(), False)

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