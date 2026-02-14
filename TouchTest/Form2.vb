Public Class Form2
    Public HasBeenOpened As Boolean = False

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HasBeenOpened = True

    End Sub

    Private Sub Form2_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Hide()
    End Sub
End Class