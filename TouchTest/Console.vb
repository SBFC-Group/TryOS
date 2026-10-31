Public Class Console
    Private User As UserManager

    Private Sub RichTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim No As Object
            Try
                No = UI.RunCommands(sender.Text, User, Me)
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    TryController.WriteToDebuggerOutput(ex.Message)
                End If
            End Try
        End If
    End Sub

    Private Sub Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        User = TryController.Resuteg(TryController.CoreID)
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\RunCommandAtStart.setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\RunCommandAtStart.setting")
            RichTextBox2.Text = RichTextBox2.Text & Reader
            Dim No As Object
            Try
                No = UI.RunCommands(Reader, User, Me)
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    TryController.WriteToDebuggerOutput(ex.Message)
                End If
            End Try
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
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\AutorunCommands.setting") Then
            RunAutoToShell(1)
        End If
    End Sub

    Public Sub RunAutoToShell(Number As Integer)
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\AutoRun_" & Number.ToString & ".setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\AutoRun_" & Number.ToString & ".setting")
            Dim No As Object
            Try
                No = UI.RunCommands(Reader, User, Me)
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    TryController.WriteToDebuggerOutput(ex.Message)
                End If
            End Try
            Dim Number2 As Integer = Number
            Number2 = Number2 + 1
            RunAutoToShell(Number2)
        End If
    End Sub

    Public Sub WriteLine(value As String)
        TryController.DebugManager.WriteLine(value)
    End Sub

    Public Function ReadLine() As String
        Return ""
    End Function

    Public Sub Beep()
        System.Console.Beep()
    End Sub




End Class