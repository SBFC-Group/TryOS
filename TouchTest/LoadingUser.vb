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
            Else
                Form1.Username = Username
                UI.UserFolder = UI.UsersFolder & "\" & Username
                UI.LoadShell(Username, Password)
            End If

        Else
            ProgressBar1.Increment(1)
        End If
    End Sub
End Class