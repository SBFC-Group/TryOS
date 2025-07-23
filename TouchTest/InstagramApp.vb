Public Class InstagramApp
    Public InstagramWebview2 As WebviewUserControl

    Private Sub InstagramApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'https://www.instagram.com/

        InstagramWebview2 = New WebviewUserControl
        InstagramWebview2.Dock = DockStyle.Fill

        Me.Controls.Add(InstagramWebview2)

        InstagramWebview2.WebView21.Source = New Uri("https://www.instagram.com/")
    End Sub
End Class