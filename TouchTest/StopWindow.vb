Public Class StopWindow
    Public FullStopMessage As String = ""
    Public MessageSource As String = ""

    Public Sub Crash(e As Exception)
        Me.BackColor = Color.Black
        Me.RichTextBox1.BackColor = Color.Black
        Me.Show()
        Me.BackColor = Color.Black
        Me.RichTextBox1.BackColor = Color.Black
        CloseEveryForm()
        RichTextBox1.Text = "The Program Crashed and will restart soon." & "
" & e.Message & "
" & e.Source & "

" & e.StackTrace
    End Sub

    Private Sub StopWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CloseEveryForm()
        Me.BeginInvoke(Sub()
                           For Each frm As Form In Application.OpenForms.OfType(Of Form)().ToList()
                               If frm IsNot Me Then
                                   frm.Close()
                               End If
                           Next
                       End Sub)
    End Sub
End Class