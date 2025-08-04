Public Class Console
    Private Sub RichTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            UI.RunCommands(sender.Text, Me)
        End If
    End Sub

    Private Sub Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\RunCommandAtStart.setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\RunCommandAtStart.setting")
            RichTextBox2.Text = RichTextBox2.Text & Reader
            UI.RunCommands(RichTextBox2.Text, Me)
            If Reader = "run shell" Then
                WindowState = FormWindowState.Minimized
            ElseIf Reader = "run LogonPage" Then
                WindowState = FormWindowState.Minimized

                Me.ShowInTaskbar = False
                Form48.BringToFront()
                Hide()
                'Me.WindowState = FormWindowState.Minimized
            End If
        End If
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\UseKeyboard.setting") Then
            UI.IsKeyboardEnabled = True
        End If
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\AutorunCommands.setting") Then
            RunAutoToShell(1)
        End If
    End Sub

    Public Sub RunAutoToShell(Number As Integer)
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\AutoRun_" & Number.ToString & ".setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\AutoRun_" & Number.ToString & ".setting")
            UI.RunCommands(Reader, Me)
            Dim Number2 As Integer = Number
            Number2 = Number2 + 1
            RunAutoToShell(Number2)
        End If
    End Sub
End Class