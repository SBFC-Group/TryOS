Public Class Main
    Private Number As Int64 = 1

    Public Sub NewNote(NotesFolderPath As String, TempFolderPath As String, Name As String, Text As String, Optional EncodeText As Boolean = False)
        If My.Computer.FileSystem.DirectoryExists(NotesFolderPath) Then
            If My.Computer.FileSystem.FileExists(NotesFolderPath & "\quicknote_" & Number.ToString & ".swnote") Then
                Number = Number + 1
                NewNote(NotesFolderPath, TempFolderPath, Name, Text)
            Else


                Dim TempFolder As String = TempFolderPath
                My.Computer.FileSystem.CreateDirectory(TempFolder & "\tempfoldernote")
                My.Computer.FileSystem.WriteAllText(TempFolder & "\tempfoldernote\NoteName.swfiles", Name, False)
                My.Computer.FileSystem.WriteAllText(TempFolder & "\tempfoldernote\NoteText.swfiles", Text, False)

                IO.Compression.ZipFile.CreateFromDirectory(TempFolder & "\tempfoldernote", TempFolder & "\quicknote_" & Number.ToString & ".swnote")

                System.Threading.Thread.Sleep(200)

                My.Computer.FileSystem.DeleteDirectory(TempFolder & "\tempfoldernote", FileIO.DeleteDirectoryOption.DeleteAllContents)

                My.Computer.FileSystem.MoveFile(TempFolder & "\quicknote_" & Number.ToString & ".swnote", NotesFolderPath & "\quicknote_" & Number.ToString & ".swnote")


            End If
        Else
            Try
                My.Computer.FileSystem.CreateDirectory(NotesFolderPath)
                NewNote(NotesFolderPath, TempFolderPath, Name, Text)
            Catch ex As UnauthorizedAccessException
                MsgBox(ex.Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function OpenNote(NotesFolderPath As String, TempFolderPath As String, FileNameWithoutExtension As String, Optional IsEncoded As Boolean = False)
        Dim ReturnTextOI As String = Nothing
        Dim WriteOI As String = NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote"

        If My.Computer.FileSystem.DirectoryExists(TempFolderPath & "\notesreader") Then
            My.Computer.FileSystem.CreateDirectory(TempFolderPath & "\notesreader")
        End If

        IO.Compression.ZipFile.ExtractToDirectory(NotesFolderPath & "\" & WriteOI & ".swnote", TempFolderPath & "\notesreader")

        ReturnTextOI = My.Computer.FileSystem.ReadAllText(TempFolderPath & "\notesreader\NoteText.swfiles")

        If IsEncoded = True Then
            Try
                Dim b As Byte() = Convert.FromBase64String(ReturnTextOI)
                ReturnTextOI = System.Text.Encoding.UTF8.GetString(b)
                Dim b2 As Byte() = Convert.FromBase64String(ReturnTextOI)
                ReturnTextOI = System.Text.Encoding.UTF8.GetString(b2)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Failed to Decode")
            End Try
        End If

        System.Threading.Thread.Sleep(100)

        My.Computer.FileSystem.DeleteDirectory(TempFolderPath & "\notesreader", FileIO.DeleteDirectoryOption.DeleteAllContents)

        Return ReturnTextOI
    End Function
End Class
