Public Class PageSettings
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CloseControlCenter()
    End Sub

    Private Sub CloseControlCenter()
        Form1.HideTaskbar(False)
        Form1.Panel3.Controls.Remove(Form1.ControlCenter)
        Try
            Form1.currentForm.Show()
        Catch ex As Exception

        End Try
        'Form1.ControlCenter.Dock = DockStyle.Fill
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Me.BackColor = Color.FromArgb(55, Color.Silver)
        Panel3.BackColor = Color.FromArgb(55, Color.DarkGray)
    End Sub
End Class
