Public Class ConsoleHelper
    Private commandHistory As New List(Of String)
    Private historyIndex As Integer = -1

    Private Sub ConsoleHelper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.CommandLine.Contains("/DevMode") = False Then
            Close()
        End If

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
                        HandleCommand(lastCommand)
                        'UI.RunCommands(lastCommand)
                    End If
                End If

            Case Keys.Up
                If commandHistory.Count > 0 AndAlso historyIndex > 0 Then
                    historyIndex -= 1
                    ReplaceCurrentLine(commandHistory(historyIndex))
                    e.SuppressKeyPress = True
                End If

            Case Keys.Down
                If commandHistory.Count > 0 AndAlso historyIndex < commandHistory.Count - 1 Then
                    historyIndex += 1
                    ReplaceCurrentLine(commandHistory(historyIndex))
                    e.SuppressKeyPress = True
                End If
        End Select
    End Sub

    Private Sub HandleCommand(command As String)
        ' Extract only user input (assumes prompt ends with > )
        Dim input As String = command.Trim()

        ' Example commands
        Select Case input.ToLower()
            Case "help"
                WriteToConsole("Available commands: help, clear, time, echo [text]")
            Case "clear"
                txtConsole.Clear()
            Case "time"
                WriteToConsole("Current time: " & DateTime.Now.ToString("HH:mm:ss"))
            Case Else
                If input.StartsWith("echo ") Then
                    WriteToConsole(input.Substring(5))
                Else
                    WriteToConsole("Unknown command: " & input)
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

    Private knownCommands As New List(Of String) From {"help", "clear", "time", "echo"}

    Private Sub AutoCompleteCurrentLine()
        Dim lines() As String = txtConsole.Lines
        If lines.Length = 0 Then Return

        Dim currentLine As String = lines(lines.Length - 1).Trim()
        If String.IsNullOrWhiteSpace(currentLine) Then Return

        Dim matches = knownCommands.Where(Function(c) c.StartsWith(currentLine, StringComparison.OrdinalIgnoreCase)).ToList()
        If matches.Count = 1 Then
            ReplaceCurrentLine(matches(0))
        ElseIf matches.Count > 1 Then
            WriteToConsole("Possible matches: " & String.Join(", ", matches))
        End If
    End Sub
End Class