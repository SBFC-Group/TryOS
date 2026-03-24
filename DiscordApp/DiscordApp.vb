Public Class DiscordApp
    Private CoreWebview21 As Microsoft.Web.WebView2.Core.CoreWebView2
    Private IsWebView2FullScreen As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If WebView21.CoreWebView2.ContainsFullScreenElement = True Then
                Main.Controller.EnableFullscreen(True)
                IsWebView2FullScreen = True
            ElseIf WebView21.CoreWebView2.ContainsFullScreenElement = False Then
                If IsWebView2FullScreen = True Then
                    IsWebView2FullScreen = False
                    Main.Controller.EnableFullscreen(False)

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            CoreWebview21 = WebView21.CoreWebView2
        End If
    End Sub

    Private Sub DiscordApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.app
    End Sub
End Class