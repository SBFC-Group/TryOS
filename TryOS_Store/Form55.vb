Public Class Form55
    Private Sub Form55_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.ic_local_grocery_store_128_28460

        WebView21.Source = New Uri("https://app-web-cv.netlify.app/tryos_store/")

        'WebView21Control.PostWebMessageAsString("")
    End Sub

    Private WebView21Control As Microsoft.Web.WebView2.Core.CoreWebView2

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            'WebView21.CoreWebView2.Settings.UserAgent = "TryOS-Store=1.1.0"
            WebView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = False
            WebView21Control = WebView21.CoreWebView2
            If Main.Controller.GetRole() = TouchTest.TryController.Roles.Developer Then
            Else
                WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
                WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
                WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
                WebView21.CoreWebView2.Settings.IsStatusBarEnabled = False
            End If

        End If
    End Sub

    Private Sub WebView21_WebMessageReceived(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs) Handles WebView21.WebMessageReceived
        If e.TryGetWebMessageAsString().StartsWith("Net>Command=") Then
        Else
            Main.Controller.ShowError(e.TryGetWebMessageAsString(), TouchTest.ErrorMSGBox.Alerts.Information)
        End If
    End Sub
End Class