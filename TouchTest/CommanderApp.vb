Public Class CommanderApp
    Private commandHistory As New List(Of String)
    Private historyIndex As Integer = -1

    Private Sub ConsoleHelper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtConsole.AppendText("Console Ready..." & vbCrLf)
    End Sub

    Private Sub txtConsole_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConsole.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.SuppressKeyPress = True
                Dim lines() As String = txtConsole.Lines
                If lines.Length > 0 Then
                    Dim lastCommand As String = lines(lines.Length - 1).Trim()
                    If Not String.IsNullOrEmpty(lastCommand) Then
                        commandHistory.Add(lastCommand)
                        historyIndex = commandHistory.Count
                        UI.RunCommands(lastCommand, Form1.User, Me)
                    End If
                End If
        End Select
    End Sub

    Private Sub WriteToConsole(text As String)
        txtConsole.AppendText(vbCrLf & text & vbCrLf)
    End Sub

    Private Sub ReplaceCurrentLine(newText As String)
        Dim lines() As String = txtConsole.Lines
        If lines.Length > 0 Then
            lines(lines.Length - 1) = newText
            txtConsole.Lines = lines
            txtConsole.SelectionStart = txtConsole.Text.Length
        End If
    End Sub
End Class