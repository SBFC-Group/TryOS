Imports System.IO

Public Class TryController
    Private Sub TryController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As String = Environment.CommandLine

        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\ShellName.setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\ShellName.setting")
            'UI.OpenFormByName(Reader)

            Dim form As Form = UI.GetForm(Reader)
            form.Show()
            form.BringToFront()

            Me.WindowState = FormWindowState.Minimized

            Me.ShowInTaskbar = False
        Else
            Console.Show()
        End If

        If args.Contains("/DevMode") = True Then
            Dev = True
        End If

        If args.Contains("/ShowConsole") = True Then
            Console.Show()
            Console.WindowState = FormWindowState.Minimized
        End If

        If args.Contains("/AllowDebugWindow") = True Then

        End If


    End Sub

    Public Dev As Boolean = False

    Public Enum Roles
        Guest = 1
        Standard = 2
        Administrator = 3
        Program = 4
        Developer = 5
    End Enum

    Public Function IsZipFile(filePath As String) As Boolean
        ' ZIP files start with "PK" (50 4B in hex)
        Dim buffer(3) As Byte
        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            fs.Read(buffer, 0, buffer.Length)
        End Using

        ' Check first 4 bytes
        Return buffer(0) = &H50 AndAlso buffer(1) = &H4B AndAlso
               (buffer(2) = &H3 OrElse buffer(2) = &H5 OrElse buffer(2) = &H7) AndAlso
               (buffer(3) = &H4 OrElse buffer(3) = &H6 OrElse buffer(3) = &H8)
    End Function

    Public Function IsTextFile(filePath As String) As Boolean
        ' Try reading a few bytes and see if they are mostly text
        Dim buffer(1023) As Byte
        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim bytesRead = fs.Read(buffer, 0, buffer.Length)
            For i As Integer = 0 To bytesRead - 1
                ' Allow basic text characters: tab, linefeed, carriage return
                If buffer(i) < 9 OrElse (buffer(i) > 13 AndAlso buffer(i) < 32) Then
                    Return False ' Found binary character
                End If
            Next
        End Using
        Return True
    End Function

    Public Function IsMySWFilesNew(Path As String)
        Dim IsNewer As Boolean = IsZipFile(Path)

        If IsNewer = False Then
            Dim Writer As New SWFiles.CreateSWFiles
            Dim Reader As String = Writer.ReadOlderSWFilesFile(Path)

            My.Computer.FileSystem.DeleteFile(Path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Form1.Username & "\Temp\NoneS", "TryOS created file.", False)
            Writer.CreateSWFiles3File(Path, Reader, My.Application.Info.DirectoryPath & "\Users\" & Form1.Username & "\Temp")
        End If
    End Function
End Class