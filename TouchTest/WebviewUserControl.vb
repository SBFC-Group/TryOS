Public Class WebviewUserControl
    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            Dim UserRole As TryController.Roles = Form1.GetRole()
            If UserRole = TryController.Roles.Developer Then
            Else
                WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
                WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
            End If
            WebView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = False

        End If
    End Sub

    Private Sub WebView21_WebMessageReceived(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs) Handles WebView21.WebMessageReceived
        If e.WebMessageAsJson.StartsWith("TryOS>UI>RunApp(") = True And e.WebMessageAsJson.EndsWith(")") = True Then
            Dim MyMessage As String = e.WebMessageAsJson
            MyMessage = MyMessage.Replace("TryOS>UI>RunApp(", "")
            MyMessage = MyMessage.Replace(")", "")
            UI.RunApp(MyMessage)
        End If
    End Sub
End Class
