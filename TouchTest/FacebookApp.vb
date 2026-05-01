Public Class FacebookApp
    Public FacebookWebview2 As WebviewUserControl

    Private Sub FacebookApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.V_AllowUseOfOldInternalApps = False Then
            OpenFramework_Data.OpenFramework.AppName = ""
            Close()
        End If

        FacebookWebview2 = New WebviewUserControl
        FacebookWebview2.Dock = DockStyle.Fill

        Me.Controls.Add(FacebookWebview2)

        FacebookWebview2.WebView21.Source = New Uri("https://facebook.com")
    End Sub
End Class