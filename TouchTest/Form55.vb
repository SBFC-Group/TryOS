Public Class Form55
    Public HomePage As HomePageUserControl

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Controls.Clear()
        Panel2.Controls.Add(HomePage)
    End Sub

    Private Sub Form55_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HomePage = New HomePageUserControl
    End Sub
End Class