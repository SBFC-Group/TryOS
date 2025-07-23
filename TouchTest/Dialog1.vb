Imports System.Windows.Forms

Public Class Dialog1


    Public WallpaperNumber As Integer = 1
    Public Function UploadFileToProgram(Number As Integer, Path As String, FileName As String, FileFormat As String) As String

        If My.Computer.FileSystem.FileExists(Path & "\" & FileName & Number.ToString) Then
            WallpaperNumber = Number
        Else
            Dim Number2 As Integer = Number
            Number2 = Number2 - 1
            UploadFileToProgram(Number2, Path, FileName, FileFormat)
        End If
    End Function

End Class
