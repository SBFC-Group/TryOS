Public Class YoutubeApp
    'Public WithEvents Webview21 As Microsoft.Web.WebView2.WinForms.WebView2
    Private Sub YoutubeApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'tartProfile()





        Webview21.Source = New Uri("https://youtube.com")
    End Sub

    Private Async Sub StartProfile()
        Dim eb As New Microsoft.Web.WebView2.Core.CoreWebView2EnvironmentOptions

        eb.ScrollBarStyle = Microsoft.Web.WebView2.Core.CoreWebView2ScrollbarStyle.Default
        eb.ReleaseChannels = Microsoft.Web.WebView2.Core.CoreWebView2ReleaseChannels.Stable
        eb.AreBrowserExtensionsEnabled = True
        eb.ExclusiveUserDataFolderAccess = False
        eb.EnableTrackingPrevention = True
        eb.IsCustomCrashReportingEnabled = True
        eb.AllowSingleSignOnUsingOSPrimaryAccount = False

        Dim profilePath

        If My.Computer.FileSystem.DirectoryExists(Class1._host.GetUserFolder & "\WebviewData") Then
        Else
            My.Computer.FileSystem.CreateDirectory(Class1._host.GetUserFolder & "\WebviewData")
        End If

        profilePath = Class1._host.GetUserFolder & "\WebviewData"

        Dim env = Await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(Nothing, profilePath, eb)

        Webview21 = New Microsoft.Web.WebView2.WinForms.WebView2

        Me.Controls.Add(Webview21)



        Webview21.BringToFront()

        Webview21.EnsureCoreWebView2Async(env)
    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles Webview21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then


            Dim TheRole As TouchTest.TryController.Roles = Class1._host.GetRole()
            If TheRole = TouchTest.TryController.Roles.Developer Then
            Else
                Webview21.CoreWebView2.Settings.AreDevToolsEnabled = False
                Webview21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
            End If

            If Class1._host.IsDarkMode() = True Then
                WebView21.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Dark
            Else
                WebView21.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Light
            End If
        End If
    End Sub

    Private IsWebView2FullScreen As Boolean = False

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If WebView21.CoreWebView2.ContainsFullScreenElement = True Then
                Class1._host.EnableFullscreen(True)
                IsWebView2FullScreen = True
            ElseIf WebView21.CoreWebView2.ContainsFullScreenElement = False Then
                If IsWebView2FullScreen = True Then
                    IsWebView2FullScreen = False
                    Class1._host.EnableFullscreen(False)

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class