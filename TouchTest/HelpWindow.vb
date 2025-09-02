Public Class HelpWindow
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Panel2.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Panel2.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Public Sub LoadTaskband()
        Form1.Panel2.Visible = True
    End Sub

    Public Sub UnLoadTaskband()
        Form1.Panel2.Visible = False
    End Sub
End Class