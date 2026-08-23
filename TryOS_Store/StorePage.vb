Public Class StorePage
    Private Sub StorePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WebView21.Source = New Uri("http://127.0.0.1:5500/TryOS_Store/index.html")
        WebView21.Source = New Uri("https://app-web-cv.netlify.app/tryos_store/")

        'WebView21Control.PostWebMessageAsString("")
    End Sub

    Private WebView21Control As Microsoft.Web.WebView2.Core.CoreWebView2

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            Try
                'Sets the UserAgent to TryOS Store's Version (Allows The TryOS Store webpage to find what version of app is used)
                WebView21.CoreWebView2.Settings.UserAgent = "TryOS-Store=" & Main.VersionThing.Major.ToString & "." & Main.VersionThing.Minor.ToString & "." & Main.VersionThing.Build.ToString

                'This SHOULD disable the DefaultScriptDialog and use the custom one
                WebView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = False
                AddHandler WebView21.CoreWebView2.ScriptDialogOpening, AddressOf CoreWebView2_ScriptDialogOpening

                WebView21Control = WebView21.CoreWebView2

                'Does some role crap
                Dim TheRole As TouchTest.TryController.Roles = Main.Controller.GetRole()
                If TheRole = TouchTest.TryController.Roles.Developer Then
                Else
                    WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
                    WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
                    WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
                    WebView21.CoreWebView2.Settings.IsStatusBarEnabled = False
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message & " More: " & ex.ToString)
            End Try

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
        If Message.Contains("Net>Command=") = True Then
            Debug.WriteLine("Debug: Entered If")
            Dim DownloadApp As New DownloadingApp
            DownloadApp.WindowState = Windows.Forms.FormWindowState.Maximized
            DownloadApp.Show()
            Dim Command As String = Message
            Command = Command.Replace("Net>Command=DownloadFile:", "")
            Debug.WriteLine("Debug: Clean Text only with the url. == " & Command)

            If My.Computer.FileSystem.FileExists(WebView21Control.Profile.DefaultDownloadFolderPath & "\App.tryapp") Then
                My.Computer.FileSystem.DeleteFile(WebView21Control.Profile.DefaultDownloadFolderPath & "\App.tryapp")
            End If

            Dim psi As New ProcessStartInfo(My.Application.Info.DirectoryPath & "\InternetDownloader.exe", "/Address:" & Command & " /fileName:" & WebView21Control.Profile.DefaultDownloadFolderPath & "\App.tryapp")
            psi.RedirectStandardOutput = True
            psi.UseShellExecute = False
            psi.CreateNoWindow = True


            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\InternetDownloader.exe") = False Then
                My.Computer.FileSystem.WriteAllBytes(My.Application.Info.DirectoryPath & "\InternetDownloader.exe", My.Resources.InternetDownloader, False)
            End If

            Dim process As Process = Process.Start(psi)

            Dim output As String = process.StandardOutput.ReadToEnd()
            process.WaitForExit()

            If output.Contains("1") Then
            Else

                TryOS_Store_Manager.Class1.InstallTryOSApp(WebView21Control.Profile.DefaultDownloadFolderPath & "\App.tryapp", Main.Controller.GetProgramVersion())
            End If

            DownloadApp.Close()
        Else
            Main.Controller.ShowError(Message, TouchTest.ErrorMSGBox.Alerts.Information)
        End If
    End Sub
End Class
