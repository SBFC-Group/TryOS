Public Class Commander
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If RichTextBox1.Text.Contains("JJ") Then
                MsgBox(Form1.Username)
            Else
                UI.RunCommands(RichTextBox1.Text, Me)
            End If
        End If
    End Sub
End Class