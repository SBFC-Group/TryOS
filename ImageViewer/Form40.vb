Public Class Form40
    Public stringlist As New List(Of String)

    Public Sub LoadMediaViewer()
        LoadMediaViewer("Null")
    End Sub

    Public Sub LoadMediaViewer(fileName As String)
        If fileName = "Null" Then
            Show()
        Else
            stringlist.Add(fileName)
            PictureBox1.Image = Drawing.Bitmap.FromFile(fileName)
        End If
    End Sub

    'Public Sub LoadMediaViewer(fileName As String, FileFormat As MediaFormats)

    'End Sub

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


        Dim dir1 = Main.Controller.GetUserFolder & "\Pictures"
        Dim files() As System.IO.FileInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        files = dirinfo.GetFiles("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            stringlist.Add(file.FullName)
        Next
    End Sub

    Private Sub Form40_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Argument As String = Main.Controller.SetOrGetArguments()
        If Argument = "" Then
        ElseIf Argument = " " Then
        Else
            If My.Computer.FileSystem.FileExists(Argument) Then
                LoadMediaViewer(Argument)
            Else
                Return
            End If
        End If
    End Sub
End Class