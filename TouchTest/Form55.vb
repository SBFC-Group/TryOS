Public Class Form55

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            Dim TheRole As TryController.Roles = Form1.GetRole()
            If TheRole = TryController.Roles.Developer Then
            Else
                WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
                WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
                WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
                WebView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = False
            End If
            WebView21.CoreWebView2.Profile.DefaultDownloadFolderPath = Form1.User.UserFolderPath & "\Downloads\"
            WebView21.CoreWebView2.Settings.IsStatusBarEnabled = False
            AddHandler WebView21.CoreWebView2.DownloadStarting, AddressOf DD

        End If
    End Sub

    Private Sub DD(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2DownloadStartingEventArgs)

        If e.ResultFilePath.EndsWith(".tryapp") Then
            e.Handled = True

            Dim MyTimer As New Timer
            MyTimer.Interval = 5000
            MyTimer.Enabled = True
            MyTimer.Tag = e.ResultFilePath
            AddHandler MyTimer.Tick, AddressOf MyTimer_Tick
        End If
    End Sub



    Private Testing As String = ""

    Private Sub MyTimer_Tick(sender As Object, e As EventArgs)
        sender.Stop()
        My.Computer.FileSystem.MoveFile(sender.Tag, Form1.User.UserFolderPath & "\Temp\App.tryapp")
        TryOS_Store_Manager.Class1.InstallTryOSApp(Form1.User.UserFolderPath & "\Temp\App.tryapp")
        My.Computer.FileSystem.DeleteFile(Form1.User.UserFolderPath & "\Temp\App.tryapp")
        OpenFramework_Data.OpenFramework.RestoreButtonOrder(False)
        'sender.Stop()
    End Sub


    Private Sub WebView21_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted

    End Sub

    Private Sub WebView21_WebMessageReceived(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs) Handles WebView21.WebMessageReceived

    End Sub

    Private Sub Form55_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.CommandLine.Contains("/NoTryOSStoreUpdate1_0") = False Then
            If TryOSStoreDialogNewVersion.ShowDialog = DialogResult.Yes Then

            End If
        End If

    End Sub
End Class