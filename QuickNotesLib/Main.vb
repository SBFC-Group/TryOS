Public Class Main
    Private Number As Int64 = 1

    Public Sub NewNote(NotesFolderPath As String, TempFolderPath As String, Name As String, Text As String, Version As Version, Optional EncodeText As Boolean = False)
        If My.Computer.FileSystem.DirectoryExists(NotesFolderPath) Then

            If My.Computer.FileSystem.FileExists(NotesFolderPath & "\quicknote_" & Number.ToString & ".swnote") Then
                Number = Number + 1
                NewNote(NotesFolderPath, TempFolderPath, Name, Text, Version, EncodeText)
            Else
                If EncodeText = True Then

                    'It securely encodes the name and text making harder for people to read.
                    Try
                        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(Name)
                        Name = Convert.ToBase64String(byt)
                        byt = System.Text.Encoding.UTF8.GetBytes(Name)
                        Name = Convert.ToBase64String(byt)
                    Catch ex As Exception
                    End Try

                    Try
                        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(Text)
                        Text = Convert.ToBase64String(byt)
                        byt = System.Text.Encoding.UTF8.GetBytes(Text)
                        Text = Convert.ToBase64String(byt)
                    Catch ex As Exception
                    End Try
                End If

                'Creates a temp folder for creating the note file
                My.Computer.FileSystem.CreateDirectory(TempFolderPath & "\tempfoldernote")
                My.Computer.FileSystem.WriteAllText(TempFolderPath & "\tempfoldernote\Name.swfiles", Name, False)
                My.Computer.FileSystem.WriteAllText(TempFolderPath & "\tempfoldernote\Text.swfiles", Text, False)
                My.Computer.FileSystem.WriteAllText(TempFolderPath & "\tempfoldernote\Version.swfiles", $"{Version.Major.ToString}.{Version.Minor.ToString}.{Version.Build.ToString}", False)

                'Creates the note file (.swnote)
                System.IO.Compression.ZipFile.CreateFromDirectory(TempFolderPath & "\tempfoldernote", NotesFolderPath & "\quicknote_" & Number.ToString & ".swnote")

                'Creates a timer that will check if the temp folder still exists. if it does then deletes it and timer will stop after doing that.
                Dim NewTimerCleaner As New System.Windows.Forms.Timer
                NewTimerCleaner.Interval = 500
                AddHandler NewTimerCleaner.Tick, Sub()
                                                     If My.Computer.FileSystem.FileExists(NotesFolderPath & "\quicknote_" & Number.ToString & ".swnote") Then
                                                         If My.Computer.FileSystem.DirectoryExists(TempFolderPath & "\tempfoldernote") Then
                                                             NewTimerCleaner.Stop()
                                                             My.Computer.FileSystem.DeleteDirectory(TempFolderPath & "\tempfoldernote", FileIO.DeleteDirectoryOption.DeleteAllContents)
                                                         End If
                                                     End If
                                                 End Sub
                NewTimerCleaner.Start()
            End If
        End If
    End Sub

    Private UseOldQuickNotesVersion As Boolean = False

    Private Name As String
    Private Text As String

    Public Function OpenNote(NotesFolderPath As String, TempFolderPath As String, FileNameWithoutExtension As String, Version As Version, Optional IsEncoded As Boolean = False) As List(Of String)
        If My.Computer.FileSystem.FileExists(NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote") = False Then
            If Environment.CommandLine.Contains("/DevMode") Then
                Debug.WriteLine("This File does not exist.")
            End If
            Return Nothing
        End If

        If My.Computer.FileSystem.DirectoryExists(TempFolderPath) = False Then
            If Environment.CommandLine.Contains("/DevMode") Then
                Debug.WriteLine("This Directory does not exist.")
            End If
            Return Nothing
        End If

        If My.Computer.FileSystem.DirectoryExists(TempFolderPath & "\tempfoldernote") Then
            My.Computer.FileSystem.DeleteDirectory(TempFolderPath & "\tempfoldernote", FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(TempFolderPath & "\tempfoldernote")
        Else
            My.Computer.FileSystem.CreateDirectory(TempFolderPath & "\tempfoldernote")
        End If

        Try
            System.IO.Compression.ZipFile.ExtractToDirectory(NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote", TempFolderPath & "\tempfoldernote")
        Catch ex As Exception
            If Environment.CommandLine.Contains("/DevMode") Then
                Debug.WriteLine(ex.Message)
            End If
            Return Nothing
        End Try

        If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\Version.swfiles") Then
            UseOldQuickNotesVersion = False
        Else
            UseOldQuickNotesVersion = True
        End If

        If UseOldQuickNotesVersion = True Then
            If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\NoteName.swfiles") Then
                Name = My.Computer.FileSystem.ReadAllText(TempFolderPath & "\tempfoldernote\NoteName.swfiles")
            End If
            If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\NoteText.swfiles") Then
                Text = My.Computer.FileSystem.ReadAllText(TempFolderPath & "\tempfoldernote\NoteText.swfiles")
            End If
        Else
            If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\Name.swfiles") Then
                Name = My.Computer.FileSystem.ReadAllText(TempFolderPath & "\tempfoldernote\Name.swfiles")
                If IsEncoded = True Then
                    Dim byt As Byte() = Convert.FromBase64String(Name)
                    Name = System.Text.Encoding.UTF8.GetString(byt)
                    byt = Convert.FromBase64String(Name)
                    Name = System.Text.Encoding.UTF8.GetString(byt)
                End If
            End If
            If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\Text.swfiles") Then
                Text = My.Computer.FileSystem.ReadAllText(TempFolderPath & "\tempfoldernote\Text.swfiles")
                If IsEncoded = True Then
                    Dim byt As Byte() = Convert.FromBase64String(Text)
                    Text = System.Text.Encoding.UTF8.GetString(byt)
                    byt = Convert.FromBase64String(Text)
                    Text = System.Text.Encoding.UTF8.GetString(byt)
                End If
            End If
        End If

        Dim stringlist As New List(Of String)

        stringlist.Add(Name)
        stringlist.Add(Text)

        Name = Nothing
        Text = Nothing

        'Creates a timer that will check if the temp folder still exists. if it does then deletes it and timer will stop after doing that.
        Dim NewTimerCleaner As New System.Windows.Forms.Timer
        NewTimerCleaner.Interval = 500
        AddHandler NewTimerCleaner.Tick, Sub()
                                             If My.Computer.FileSystem.FileExists(NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote") Then
                                                 If My.Computer.FileSystem.DirectoryExists(TempFolderPath & "\tempfoldernote") Then
                                                     NewTimerCleaner.Stop()
                                                     My.Computer.FileSystem.DeleteDirectory(TempFolderPath & "\tempfoldernote", FileIO.DeleteDirectoryOption.DeleteAllContents)
                                                 End If
                                             End If
                                         End Sub
        NewTimerCleaner.Start()

        Return stringlist
    End Function

    Public Sub ChangeNote(NotesFolderPath As String, TempFolderPath As String, FileNameWithoutExtension As String, Version As Version, Optional Text As String = "!!??Null=Null+Null=Null??!!", Optional Name As String = "!!??Null=Null+Null=Null??!!", Optional IsEncoded As Boolean = False)
        If My.Computer.FileSystem.FileExists(NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote") = False Then
            If Environment.CommandLine.Contains("/DevMode") Then
                Debug.WriteLine("This File does not exist.")
            End If
            Return
        End If

        If My.Computer.FileSystem.DirectoryExists(TempFolderPath) = False Then
            If Environment.CommandLine.Contains("/DevMode") Then
                Debug.WriteLine("This Directory does not exist.")
            End If
            Return
        End If

        If My.Computer.FileSystem.DirectoryExists(TempFolderPath & "\tempfoldernote") Then
            My.Computer.FileSystem.DeleteDirectory(TempFolderPath & "\tempfoldernote", FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(TempFolderPath & "\tempfoldernote")
        Else
            My.Computer.FileSystem.CreateDirectory(TempFolderPath & "\tempfoldernote")
        End If

        Try
            System.IO.Compression.ZipFile.ExtractToDirectory(NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote", TempFolderPath & "\tempfoldernote")
        Catch ex As Exception
            If Environment.CommandLine.Contains("/DevMode") Then
                Debug.WriteLine(ex.Message)
            End If
            Return
        End Try

        If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\Version.swfiles") Then
            UseOldQuickNotesVersion = False
        Else
            UseOldQuickNotesVersion = True
        End If

        If UseOldQuickNotesVersion = True Then
            If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\NoteName.swfiles") Then
                My.Computer.FileSystem.RenameFile(TempFolderPath & "\tempfoldernote\NoteName.swfiles", "Name.swfiles")
            End If
            If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\NoteText.swfiles") Then
                My.Computer.FileSystem.RenameFile(TempFolderPath & "\tempfoldernote\NoteText.swfiles", "Text.swfiles")
            End If
            My.Computer.FileSystem.WriteAllText(TempFolderPath & "\tempfoldernote\Version.swfiles", $"{Version.Major}.{Version.Major}.{Version.Build}.{Version.Revision}", False)
        End If
        '!!??Null=Null+Null=Null??!!
        If Name = "" Then
        Else
            If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\Name.swfiles") Then
                My.Computer.FileSystem.WriteAllText(TempFolderPath & "\tempfoldernote\Name.swfiles", Name, False)
            End If
        End If

        If Text = "" Then
        Else
            If My.Computer.FileSystem.FileExists(TempFolderPath & "\tempfoldernote\Text.swfiles") Then
                My.Computer.FileSystem.WriteAllText(TempFolderPath & "\tempfoldernote\Text.swfiles", Text, False)
            End If
        End If

        Try
            My.Computer.FileSystem.DeleteFile(NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote")

            System.IO.Compression.ZipFile.CreateFromDirectory(TempFolderPath & "\tempfoldernote", NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote")
        Catch ex As Exception
        End Try

        'Creates a timer that will check if the temp folder still exists. if it does then deletes it and timer will stop after doing that.
        Dim NewTimerCleaner As New System.Windows.Forms.Timer
        NewTimerCleaner.Interval = 500
        AddHandler NewTimerCleaner.Tick, Sub()
                                             If My.Computer.FileSystem.FileExists(NotesFolderPath & "\" & FileNameWithoutExtension & ".swnote") Then
                                                 If My.Computer.FileSystem.DirectoryExists(TempFolderPath & "\tempfoldernote") Then
                                                     NewTimerCleaner.Stop()
                                                     My.Computer.FileSystem.DeleteDirectory(TempFolderPath & "\tempfoldernote", FileIO.DeleteDirectoryOption.DeleteAllContents)
                                                 End If
                                             End If
                                         End Sub
        NewTimerCleaner.Start()

    End Sub
End Class
