Public Class Commander
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            Dim lines() As String = RichTextBox1.Lines
            Dim jj As String = lines.GetValue(0)
            RichTextBox1.Text = RichTextBox1.Text & "
" & UI.RunCommands(jj, Form1.User, Me)

        End If
    End Sub
End Class