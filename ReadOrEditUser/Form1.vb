Public Class Form1
    Public User As TouchTest.UserManager

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        User = New TouchTest.UserManager(Class1.Controller.GetUsername)

        Dim usedencode As String = My.Computer.FileSystem.ReadAllText(User.UserFolderPath & "\Settings\Software.swfiles")
        Try
            Dim b As Byte() = Convert.FromBase64String(usedencode)
            usedencode = System.Text.Encoding.UTF8.GetString(b)
        Catch ex As Exception

        End Try
        Try
            Dim b2 As Byte() = Convert.FromBase64String(usedencode)
            usedencode = System.Text.Encoding.UTF8.GetString(b2)
        Catch ex As Exception

        End Try

        RichTextBox1.Text = usedencode
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        User.SaveUserSettings(RichTextBox1.Text)
    End Sub
End Class