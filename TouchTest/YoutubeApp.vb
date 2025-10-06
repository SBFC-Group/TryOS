Public Class YoutubeApp
    Private Sub YoutubeApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess Then
            Dim UserRole As TryController.Roles = Form1.GetRole()
            If UserRole = TryController.Roles.Developer Then
            Else
                WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
                WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
                WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
            End If
        Else
            MessageBox.Show("WebView2 initialization failed: " & e.InitializationException.Message)
        End If
    End Sub
    Private IsWebView2FullScreen As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If WebView21.CoreWebView2.ContainsFullScreenElement = True Then
                Form1.EnableFullAppMode(True)
                IsWebView2FullScreen = True
            ElseIf WebView21.CoreWebView2.ContainsFullScreenElement = False Then
                If IsWebView2FullScreen = True Then
                    IsWebView2FullScreen = False
                    Form1.EnableFullAppMode(False)

                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub WebView21_WebMessageReceived(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs) Handles WebView21.WebMessageReceived
        MsgBox(e.TryGetWebMessageAsString, MsgBoxStyle.Information, e.Source)
    End Sub
End Class