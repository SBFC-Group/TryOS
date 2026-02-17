Public Class ControlCenter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UI.RunCommands("end", Form1.User)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Restart()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'This will contain the Log off code.
    End Sub
End Class
