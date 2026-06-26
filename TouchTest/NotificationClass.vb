Public Class NotificationClass
    Public ReadOnly Name As String
    Public ReadOnly Text As String
    Public ReadOnly Notification As NotificationType

    Public Shared Function CreateNotification(Title As String, Text As String, NotificationType As NotificationType) As NotificationClass
        Return New NotificationClass(TryController.CoreID, Title, Text, NotificationType)
    End Function

    Public Sub New(ID As Int64, Name As String, Text As String, Notification As NotificationType)
        If Not TryController.CoreID = ID Then
            Return
        End If

        Me.Name = Name
        Me.Text = Text
        Me.Notification = Notification
    End Sub

    Public Enum NotificationType
        Information = 1
        Warring = 2
        Alert = 3
        SomethingElse = 4
    End Enum
End Class
