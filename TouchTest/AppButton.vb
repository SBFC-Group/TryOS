Public Class AppButton
    Public TheForm As Form

    Private Sub ReOpenApp_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TheForm Is Form1.currentForm Then
            Return
        End If

        Form1.OpenAppAgain(TheForm, Form1.AppList.IndexOf(TheForm))

        HideForm2()
    End Sub

    Private Sub CloseApp_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Form1.AppList.Item(Form2.FlowLayoutPanel1.Controls)
        Form1.AppList.RemoveAt(Form2.FlowLayoutPanel1.Controls.IndexOf(Me))

        TheForm.Close()

        Me.Dispose()

        If Form1.AppList.Count = 0 Then
            HideForm2()
        End If
    End Sub

    Private Sub HideForm2()
        Form2.Hide()
        Form2.IsOpen = False
        Form2.TopMost = False
    End Sub
End Class
