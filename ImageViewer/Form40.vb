Public Class Form40
    Public stringlist As New List(Of String)

    Public Sub LoadMediaViewer()
        LoadMediaViewer("Null")
    End Sub

    Public Sub LoadMediaViewer(fileName As String)
        If fileName = "Null" Then
            Show()
        Else

        End If
    End Sub

    Public Sub LoadMediaViewer(fileName As String, FileFormat As MediaFormats)

    End Sub

    Public Enum MediaFormats
        png = 1
        jpg = 2
        gif = 3
        mp4 = 4
        wmv = 5
        mov = 6
        mkv = 7
    End Enum

    Public Function LoadPicture(FilePath As String)

    End Function

    Private Sub GoBackButton_Click(sender As Object, e As EventArgs) Handles GoBackButton.Click
        LoadImages()
    End Sub

    Private Sub GoForwardButton_Click(sender As Object, e As EventArgs) Handles GoForwardButton.Click

    End Sub

    Public Sub LoadImages()


        Dim dir1 = MainCode.TheManager.GetUserFolder & "\Pictures"
        Dim files() As System.IO.FileInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        files = dirinfo.GetFiles("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            stringlist.Add(file.FullName)
        Next
    End Sub
End Class