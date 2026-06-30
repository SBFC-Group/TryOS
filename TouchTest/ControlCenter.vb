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

    Public Sub CreateNotificationBox(NotificationThingy As NotificationClass, Optional CreateNoSound As Boolean = False, Optional SavedID As String = Nothing)
        Dim NewNotificationBox As New NotificationBox
        Dim ran As New Random

        If SavedID = Nothing Then
            NewNotificationBox.NotificationName = "a_z" & ran.Next(10000000, 99999999).ToString()
        Else
            NewNotificationBox.NotificationName = SavedID
        End If

        NewNotificationBox.Label1.Text = NotificationThingy.Name
        NewNotificationBox.RichTextBox1.Text = NotificationThingy.Text

        If NotificationThingy.Notification = NotificationClass.NotificationType.Information Then
            NewNotificationBox.PictureBox1.Image = My.Resources.Info_2
            If CreateNoSound = False Then
                My.Computer.Audio.Play(My.Resources.Alert_1, AudioPlayMode.Background)
            End If
        ElseIf NotificationThingy.Notification = NotificationClass.NotificationType.Warring Then
            NewNotificationBox.PictureBox1.Image = My.Resources.Warning_2
            If CreateNoSound = False Then
                My.Computer.Audio.Play(My.Resources.Warning_1, AudioPlayMode.Background)
            End If
        ElseIf NotificationThingy.Notification = NotificationClass.NotificationType.Alert Then
            NewNotificationBox.PictureBox1.Image = My.Resources.Alert_2
            If CreateNoSound = False Then
                My.Computer.Audio.Play(My.Resources.Warning_1, AudioPlayMode.Background)
            End If
        ElseIf NotificationThingy.Notification = NotificationClass.NotificationType.SomethingElse Then
            NewNotificationBox.PictureBox1.Image = My.Resources.Info_2
        End If

        NewNotificationBox.NotificationInfo = NotificationThingy

        FlowLayoutPanel1.Controls.Add(NewNotificationBox)
    End Sub

    Private Sub ControlCenter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.LoadNotifications()
    End Sub
End Class
