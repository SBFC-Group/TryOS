Public Class FacebookApp

    Private IsWebView2FullScreen As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If WebView21.CoreWebView2.ContainsFullScreenElement = True Then
                Main._host.EnableFullscreen(True)
                IsWebView2FullScreen = True
            ElseIf WebView21.CoreWebView2.ContainsFullScreenElement = False Then
                If IsWebView2FullScreen = True Then
                    IsWebView2FullScreen = False
                    Main._host.EnableFullscreen(False)

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            Dim TheRole As TouchTest.TryController.Roles = Main._host.GetRole()
            If TheRole = TouchTest.TryController.Roles.Developer Then
            Else
                WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
                WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
                WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
            End If

            If Main._host.IsDarkMode() = True Then
                WebView21.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Dark
            Else
                WebView21.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Light
            End If
        End If
    End Sub

    Private Sub FacebookApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebView21.Source = New Uri("https://www.facebook.com/")
    End Sub
End Class