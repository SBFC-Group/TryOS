Public Class SpotifyApp
    Public WebViewUserControl As New WebviewUserControl
    Private Sub SpotifyApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.V_AllowUseOfOldInternalApps = False Then
            OpenFramework_Data.OpenFramework.AppName = ""
            Close()
        End If

        WebViewUserControl.Dock = DockStyle.Fill
        Me.Controls.Add(WebViewUserControl)
        WebViewUserControl.WebView21.Source = New Uri("https://open.spotify.com/")
    End Sub
End Class