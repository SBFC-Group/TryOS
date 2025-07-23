Public Class StopWindow
    Private Sub StopWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CloseEveryForm()
    End Sub

    Private Sub CloseEveryForm()
        Me.BeginInvoke(Sub()
                           For Each frm As Form In Application.OpenForms.OfType(Of Form)().ToList()
                               If frm IsNot Me Then
                                   frm.Close()
                               End If
                               Commander.Show()
                           Next
                       End Sub)
    End Sub
End Class