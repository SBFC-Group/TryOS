Public Class ControlCenter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UI.RunCommands("end", Form1.User)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Restart()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        UI.LogOut()

        'This will contain the Log off code.
    End Sub

    Public Sub CreateNotificationBox(NotificationThingy As NotificationClass)
        Dim NewNotificationBox As New NotificationBox
        Dim ran As New Random

        NewNotificationBox.NotificationName = "a_z" & ran.Next(10000000, 99999999).ToString()
        NewNotificationBox.Label1.Text = NotificationThingy.Name
        NewNotificationBox.RichTextBox1.Text = NotificationThingy.Text
        If NotificationThingy.Notification = NotificationClass.NotificationType.Information Then
        ElseIf NotificationThingy.Notification = NotificationClass.NotificationType.Warring Then
        ElseIf NotificationThingy.Notification = NotificationClass.NotificationType.Alert Then
            My.Computer.Audio.Play(My.Resources.Alert_1, AudioPlayMode.Background)
        ElseIf NotificationThingy.Notification = NotificationClass.NotificationType.SomethingElse Then
        End If

        FlowLayoutPanel1.Controls.Add(NewNotificationBox)
    End Sub
End Class
