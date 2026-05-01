Public Class Form40
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
        Return Nothing
    End Function

    Private Sub Form40_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.V_AllowUseOfOldInternalApps = False Then
            OpenFramework_Data.OpenFramework.AppName = ""
            Close()
        End If
    End Sub
End Class