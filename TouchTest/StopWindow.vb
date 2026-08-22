Public Class StopWindow
    Public FullStopMessage As String = ""
    Public MessageSource As String = ""

    Public Sub Crash(e As Exception)
        Me.Show()

        CloseEveryForm()
        RichTextBox1.Text = "The Program Crashed and will restart in 10 seconds. Everything here will be copied to your clipboard." & "
" & e.Message & "
" & e.Source & "

" & e.StackTrace

        My.Computer.Clipboard.SetText(RichTextBox1.Text)
    End Sub

    Private Sub StopWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CloseEveryForm()
        Me.BeginInvoke(Sub()
                           For Each frm As Form In Application.OpenForms.OfType(Of Form)().ToList()
                               If frm Is Me Then
                               ElseIf frm Is TryController Then
                               ElseIf frm Is DebugManagerWindow Then
                               Else
                                   frm.Close()
                               End If
                           Next
                       End Sub)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
End Class