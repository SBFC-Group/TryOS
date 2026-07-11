Imports System.IO.Compression

Public Class Class1
    Private Number As Int64 = 1

    Private Shared Form15Text As String = ""

    Public Shared Function PackageCreator(FolderPath As String, FileName As String, PackageName As String, TryOSVersion As String, Optional DllName As String = "Null", Optional TryOSStoreOnlineURL As String = Nothing)
        'Checks if the package file aready exists.
        If My.Computer.FileSystem.DirectoryExists(FileName) Then
        Else
            Dim TempFolder As String = My.Application.Info.DirectoryPath & "\Temp"

            'Creates the folder "Temp" inside the programs root directory.
            My.Computer.FileSystem.CreateDirectory(TempFolder)

            My.Computer.FileSystem.CopyDirectory(FolderPath, TempFolder, False)
            My.Computer.FileSystem.WriteAllText(TempFolder & "\Name.swfiles", PackageName, False)
            My.Computer.FileSystem.WriteAllText(TempFolder & "\Version.swfiles", TryOSVersion, False)
            If TryOSStoreOnlineURL IsNot Nothing Then
                My.Computer.FileSystem.WriteAllText(TempFolder & "\StoreVersionURL.txt", TryOSVersion, False)
            End If


            If DllName = "Null" Then
                If My.Computer.FileSystem.FileExists(TempFolder & "\DllPath.txt") Then
                    My.Computer.FileSystem.DeleteFile(TempFolder & "\DllPath.txt")
                End If
            Else
                If My.Computer.FileSystem.FileExists(TempFolder & "\DllPath.txt") Then
                    My.Computer.FileSystem.DeleteFile(TempFolder & "\DllPath.txt")
                End If
                My.Computer.FileSystem.WriteAllText(TempFolder & "\DllPath.txt", DllName, False)
            End If

            IO.Compression.ZipFile.CreateFromDirectory(TempFolder, FileName)

            System.Threading.Thread.Sleep(200)

            My.Computer.FileSystem.DeleteDirectory(TempFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        Return Nothing
    End Function

    Public Shared Function InstallTryOSApp(FileName As String, Optional TryOSVersion As String = "Null")
        Dim TempFolder As String = My.Application.Info.DirectoryPath & "\Temp"

        'Creates the folder "Temp" inside the programs root directory.
        My.Computer.FileSystem.CreateDirectory(TempFolder)

        IO.Compression.ZipFile.ExtractToDirectory(FileName, TempFolder)

        'If TryOSVersion = "Null" Then
        '    TryOSVersion = My.Application.Info.Version.ToString
        'End If

        'Dim ReaderVersion As String = My.Computer.FileSystem.ReadAllText(TempFolder & "\Version.swfiles")

        'If ReaderVersion.Contains(TryOSVersion) Then
        'Else
        '    Exit Function
        'End If

        Dim Reader As String = My.Computer.FileSystem.ReadAllText(TempFolder & "\Name.swfiles")

        Dim dir1 = My.Application.Info.DirectoryPath & "\Apps"
        Dim files() As System.IO.DirectoryInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)

        Dim exists As Boolean = False

        For Each file In files

            If file.FullName = Reader Then
                exists = True

                Exit For
            Else
                exists = False
            End If

        Next


        If exists = True Then

            Return False
        ElseIf exists = False Then
        End If


        Dim AppFolderName As String = Reader



        My.Computer.FileSystem.DeleteFile(TempFolder & "\Name.swfiles")
        My.Computer.FileSystem.DeleteFile(TempFolder & "\Version.swfiles")

        My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Apps\" & AppFolderName)

        If My.Computer.FileSystem.FileExists(TempFolder & "\DllPath.txt") Then
            Dim DllPathWriter As String = My.Computer.FileSystem.ReadAllText(TempFolder & "\DllPath.txt")
            System.Threading.Thread.Sleep(200)
            My.Computer.FileSystem.DeleteFile(TempFolder & "\DllPath.txt")
            My.Computer.FileSystem.WriteAllText(TempFolder & "\DllPath.txt", My.Application.Info.DirectoryPath & "\Apps\" & AppFolderName & "\" & DllPathWriter, False)
        End If

        My.Computer.FileSystem.CopyDirectory(TempFolder, My.Application.Info.DirectoryPath & "\Apps\" & AppFolderName)

        My.Computer.FileSystem.DeleteDirectory(TempFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
        Return Nothing
    End Function

    Private Shared Function GetAppNumber() As Int64
        Dim dir1 = My.Application.Info.DirectoryPath & "\Apps"
        Dim files() As System.IO.DirectoryInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)

        'Sets "MyNumber" to 922337203685477806 (64 bit integer limit)
        Dim MyNumber As Int64 = 922337203685477806
        Dim myfile As String = ""
        For Each file In files
            'Sets "myfile" to the current folder's path 
            myfile = file.FullName

            'Does some math and lots else to get nummber out of the folder's path
            myfile = myfile.Replace(My.Application.Info.DirectoryPath & "\Apps\", "")

            Dim Number2 As Int64 = myfile.Length

            Number2 = Number2 - 1

            myfile = myfile.Remove(1, Number2)

            'Just here for debugging
            Debug.WriteLine(myfile)
        Next

        Try
            MyNumber = Convert.ToInt64(myfile)
        Catch ex As Exception

        End Try

        If MyNumber = 922337203685477806 Then
        Else
            Return MyNumber
        End If
        Return Nothing
    End Function

    Public Shared Function UpdateTryOSApp(FileName As String, TryOSVersion As String, Optional HasOpenFrameworkUpdated As Boolean = False)
        Dim TempFolder As String = My.Application.Info.DirectoryPath & "\Temp"

        'Creates the folder "Temp" inside the programs root directory.
        My.Computer.FileSystem.CreateDirectory(TempFolder)

        IO.Compression.ZipFile.ExtractToDirectory(FileName, TempFolder)

        Dim ReaderVersion As String = My.Computer.FileSystem.ReadAllText(TempFolder & "\Version.swfiles")
        If HasOpenFrameworkUpdated = True Then
            ReaderVersion = ReaderVersion & "
" & TryOSVersion
        ElseIf HasOpenFrameworkUpdated = False Then
            ReaderVersion = TryOSVersion
        End If

        My.Computer.FileSystem.DeleteFile(TempFolder & "\Version.swfiles")

        My.Computer.FileSystem.WriteAllText(TempFolder & "\Version.swfiles", ReaderVersion, False)

        My.Computer.FileSystem.DeleteFile(FileName)

        IO.Compression.ZipFile.CreateFromDirectory(TempFolder, FileName)

        System.Threading.Thread.Sleep(200)

        My.Computer.FileSystem.DeleteDirectory(TempFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)

        Return Nothing
    End Function
End Class
