Public Class HelpWindow
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Internetplusplus.WebView21.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Internetplusplus.Panel2.BringToFront()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Internetplusplus.TabControl1.BringToFront()
    End Sub
End Class