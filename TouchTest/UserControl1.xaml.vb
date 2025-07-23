Public Class UserControl1
    Private Sub Button_Click(sender As Object, e As Windows.RoutedEventArgs)
        Dim shittest As String = "file:///" & My.Application.Info.DirectoryPath & "\Note\USW.mp4"
        shittest = shittest.Replace("\", "/")

        MediaThingy.Source = New Uri(shittest)
    End Sub
End Class
