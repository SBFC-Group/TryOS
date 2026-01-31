Imports System.Windows.Forms

Public Class Form55
    Private Sub Form55_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.ic_local_grocery_store_128_28460


        WebView21.Source = New Uri("http://127.0.0.1:5500/TryOS_Store/index.html")
        'WebView21.Source = New Uri("https://app-web-cv.netlify.app/tryos_store/")

        'WebView21Control.PostWebMessageAsString("")

    End Sub

    Private WebView21Control As Microsoft.Web.WebView2.Core.CoreWebView2

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            'Sets the UserAgent to TryOS Store's Version (Allows The TryOS Store webpage to find what version of app is used)
            WebView21.CoreWebView2.Settings.UserAgent = "TryOS-Store=" & Main.VersionThing.Major.ToString & "." & Main.VersionThing.Minor.ToString & "." & Main.VersionThing.Build.ToString

            'This SHOULD disable the DefaultScriptDialog and use the custom one
            WebView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = False
            AddHandler WebView21.CoreWebView2.ScriptDialogOpening, AddressOf CoreWebView2_ScriptDialogOpening

            WebView21Control = WebView21.CoreWebView2

            'Does some role crap
            Dim TheRole As TouchTest.TryController.Roles = Main.Controller.RunCommand("whoami /nogui")
            If TheRole = TouchTest.TryController.Roles.Developer Then
            Else
                WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
                WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
                WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
                WebView21.CoreWebView2.Settings.IsStatusBarEnabled = False
            End If
        End If
    End Sub

    Private Sub CoreWebView2_ScriptDialogOpening(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2ScriptDialogOpeningEventArgs)

        ' Only handle alert()
        If e.Kind = Microsoft.Web.WebView2.Core.CoreWebView2ScriptDialogKind.Alert Then

            ' Get the alert text
            Dim message As String = e.Message

            WebView21_WebMessageReceived(message)
        End If
    End Sub

    Private Sub WebView21_WebMessageReceived(Message As String)
        'MsgBox("osjosdghnopishpoiggshiogsiohgsdihojsdgijogsdiojgsdijosgdijogsdjogisdgsijodgsdjiogsdiojgsdijosgdjoigsdjiogsdijogsdijosgdgjsiodgsdijogsdiojgsjiogsdjoisgdijod")
        Debug.WriteLine("Debug: " & Message)
        If Message.StartsWith("Net>Command=") = True Then
            Debug.WriteLine("Debug: Entered If")
            Dim DownloadApp As New DownloadingApp
            DownloadApp.WindowState = Windows.Forms.FormWindowState.Maximized
            DownloadApp.Show()
            Dim Command As String = Message
            Command = Command.Replace("Net>Command=DownloadFile:", "")
            Dim thread As New Threading.Thread(New Threading.ThreadStart(Sub() DownloadTryOSAppPackage(Command, DownloadApp)))
            thread.IsBackground = True

        Else
            Main.Controller.ShowError(Message, TouchTest.ErrorMSGBox.Alerts.Information)
        End If

    End Sub

    Public Sub DownloadTryOSAppPackage(Package As String, DownloadForm As DownloadingApp)
        Debug.WriteLine("Debug: Should be running inside a Thread now.")

        Dim FileDownloader As New Net.WebClient
        Dim DonePath As String = Main.Controller.GetUserFolder & "\Downloads\App.try"
        FileDownloader.DownloadFile(Package, DonePath)

        TryOS_Store_Manager.Class1.InstallTryOSApp(Package, Main.Controller.GetProgramVersion())

        DownloadForm.Close()

        Return
    End Sub
End Class