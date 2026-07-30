Public Class Commander
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBoxCommandBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True



            'If Environment.CommandLine.Contains("/DisableSandboxingForCommander") = True Then
            '    RichTextBoxCommandBox.Text = RichTextBoxCommandBox.Text & "
            '" & UI.RunCommands(jj, Form1.User, Me)
            'Else
            '    RichTextBoxCommandBox.Text = RichTextBoxCommandBox.Text & "
            '" & UI.RunCommands(jj, Form1.SandboxedUser, Me)
            'End If

            If Environment.CommandLine.Contains("/DisableSandboxingForCommander") = True Then
                If RichTextBoxCommandHistory.Text = "" Then
                    RichTextBoxCommandHistory.AppendText(RichTextBoxCommandBox.Text)
                Else
                    RichTextBoxCommandHistory.AppendText(vbNewLine & RichTextBoxCommandBox.Text)
                End If

                Try
                    RichTextBoxCommandHistory.AppendText(vbNewLine & UI.RunCommands(RichTextBoxCommandBox.Text, Form1.User, Me))
                Catch ex As Exception
                    If Environment.CommandLine.Contains("/DevMode") = True Then
                        Debug.WriteLine(ex.Message)
                    End If
                End Try
            Else
                If RichTextBoxCommandHistory.Text = "" Then
                    RichTextBoxCommandHistory.AppendText(RichTextBoxCommandBox.Text)
                Else
                    RichTextBoxCommandHistory.AppendText(vbNewLine & RichTextBoxCommandBox.Text)
                End If

                Try
                    RichTextBoxCommandHistory.AppendText(vbNewLine & UI.RunCommands(RichTextBoxCommandBox.Text, Form1.SandboxedUser, Me))
                Catch ex As Exception
                    If Environment.CommandLine.Contains("/DevMode") = True Then
                        Debug.WriteLine(ex.Message)
                    End If
                End Try
            End If
            RichTextBoxCommandBox.Text = "Console>"
        End If
    End Sub

    Private Sub Commander_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        OpenFramework_Data.OpenFramework.AppName = ""
    End Sub

    Private Sub RichTextBoxCommandHistory_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBoxCommandHistory.KeyDown
        RichTextBoxCommandBox.Select()
    End Sub
End Class