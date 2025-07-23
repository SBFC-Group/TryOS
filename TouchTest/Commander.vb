Public Class Commander
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            UI.RunCommands(RichTextBox1.Text, Me)
        End If
    End Sub
End Class