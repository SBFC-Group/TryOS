Public Class YoutubeApp
    Private Sub YoutubeApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebView21.Source = New Uri("https://youtube.com")
    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            Dim TheRole As TouchTest.TryController.Roles = Main._host.GetRole()
            If TheRole = TouchTest.TryController.Roles.Developer Then
            Else
                WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
                WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
            End If

            If Main._host.IsDarkMode() = True Then
                WebView21.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Dark
            Else
                WebView21.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Light
            End If

            AddHandler WebView21.CoreWebView2.ContainsFullScreenElementChanged, AddressOf Timer1_Tick
        End If
    End Sub

    Private IsWebView2FullScreen As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        Try
            If WebView21.CoreWebView2.ContainsFullScreenElement = True Then
                Main._host.EnableFullscreen(True)
            ElseIf WebView21.CoreWebView2.ContainsFullScreenElement = False Then
                Main._host.EnableFullscreen(False)
            End If
        Catch ex As Exception
            If Environment.CommandLine.Contains("/DevMode") = True Then
                TouchTest.TryController.WriteToDebuggerOutput(ex.Message)
            End If
        End Try
    End Sub
End Class