Public Class Webview
    Private Sub Back_Button() Handles Button1.Click
        WebView21.GoBack()
    End Sub

    Private Sub Forward_Button() Handles Button2.Click
        WebView21.GoForward()
    End Sub

    Private Sub Refresh_Button() Handles Button3.Click
        WebView21.Refresh()
    End Sub
End Class
