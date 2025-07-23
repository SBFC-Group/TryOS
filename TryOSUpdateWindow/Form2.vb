Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Close()
        My.Computer.FileSystem.DeleteFile("TryOSZip.zip")
        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Wallpaper.jpg")
        Close()
    End Sub
End Class