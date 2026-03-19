Public Class AppButton
    Public TheForm As Form

    Private Sub ReOpenApp_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.OpenAppAgain(TheForm, Form1.AppList.IndexOf(TheForm))

    End Sub

    Private Sub CloseApp_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Form1.AppList.Item(Form2.FlowLayoutPanel1.Controls)
        Form1.AppList.RemoveAt(Form2.FlowLayoutPanel1.Controls.IndexOf(Me))

        TheForm.Close()

        Me.Dispose()
    End Sub
End Class
