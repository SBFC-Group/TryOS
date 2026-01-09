Imports System.Windows.Forms
Imports System.IO.Compression

Public Class NewNoteDialog

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Number As Int64 = 1

    Public Form15Text As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.DirectoryExists(Main._host.GetUserFolder() & "\Notes") Then
            If My.Computer.FileSystem.FileExists(Main._host.GetUserFolder() & "\Notes\quicknote_" & Number.ToString & ".swnote") Then
                Number = Number + 1
                Button1_Click(Me, e)
            Else
                ProgressBar1.Visible = True
                TextBox1.Enabled = False
                Button1.Enabled = False

                Dim TempFolder As String = Main._host.GetUserFolder() & "\Temp"
                My.Computer.FileSystem.CreateDirectory(TempFolder & "\tempfoldernote")
                My.Computer.FileSystem.WriteAllText(TempFolder & "\tempfoldernote\NoteName.swfiles", TextBox1.Text, False)
                My.Computer.FileSystem.WriteAllText(TempFolder & "\tempfoldernote\NoteText.swfiles", Form15Text, False)

                IO.Compression.ZipFile.CreateFromDirectory(TempFolder & "\tempfoldernote", TempFolder & "\quicknote_" & Number.ToString & ".swnote")

                System.Threading.Thread.Sleep(200)

                My.Computer.FileSystem.DeleteDirectory(TempFolder & "\tempfoldernote", FileIO.DeleteDirectoryOption.DeleteAllContents)

                My.Computer.FileSystem.MoveFile(TempFolder & "\quicknote_" & Number.ToString & ".swnote", Main._host.GetUserFolder() & "\Notes\quicknote_" & Number.ToString & ".swnote")

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Try
                My.Computer.FileSystem.CreateDirectory(Main._host.GetUserFolder() & "\Notes")
                Button1_Click(Me, e)
            Catch ex As UnauthorizedAccessException
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class
