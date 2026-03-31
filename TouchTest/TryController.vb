Imports System.IO

Public Class TryController
    Public Function GetBranch()
        Return "Uranium_(1.1)"
    End Function

    Private Sub TryController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As String = Environment.CommandLine

        If args.Contains("/ReturnVersion") = True Then
            System.Console.WriteLine(GetVersion)
            End
        End If

        If args.Contains("/InstallApp:") = True Then
            'Does nothing right now.
        End If

        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\ShellName.setting") Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\ShellName.setting")
            'UI.OpenFormByName(Reader)

            Try
                Dim form As Form = UI.GetForm(Reader)
                form.Show()
                form.BringToFront()
            Catch ex As Exception

            End Try


            Me.WindowState = FormWindowState.Minimized

            Me.ShowInTaskbar = False
        Else
            Console.Show()

            Me.WindowState = FormWindowState.Minimized

            Me.ShowInTaskbar = False
        End If

        If args.Contains("/DevMode") = True Then
            Dev = True
        End If

        If args.Contains("/TurnOff_VerifyedShellOnly") = True Then
            Form1.AllowOnlyVerifyedShellCode = False
        End If

        If args.Contains("/ShowConsole") = True Then
            Console.Show()
            Console.WindowState = FormWindowState.Minimized
        End If

        If args.Contains("/EnableSecureMode") = True Then
            SecureModeTimer.Start()
        End If
    End Sub

    Public Function GetVersion() As String
        Return My.Application.Info.Version.ToString
    End Function

    Public Function GetOSVersion(Optional GetVersionNumber As Boolean = False) As String
        If GetVersionNumber = True Then
            Dim MajorVersion As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMajorVersionNumber", Nothing)
            Dim MinorVersion As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMinorVersionNumber", Nothing)
            Dim Build As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
            Dim UBR As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "UBR", Nothing)
            Return MajorVersion & "." & MinorVersion & "." & Build & "." & UBR
        Else
            Return My.Computer.Info.OSFullName
        End If

    End Function

    Private erehresuteg As New UserManager("SuperSecretUser")

    Public Function Resuteg()
        Return erehresuteg
    End Function

    Public Dev As Boolean = False

    Public Enum Roles
        StandardSandbox = 0
        Guest = 1
        Standard = 2
        Administrator = 3
        Program = 4
        Developer = 5
    End Enum

    Public Function ShowStopWindow(message As String)
        Dim exception As New Exception(message)
        UI.ShowStopWindow(exception)
        Return "Started Stop Window"
    End Function

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

    Public Function IsMySWFilesNew(Path As String) As Boolean
        Dim IsNewer As Boolean = IsZipFile(Path)

        If IsNewer = False Then
            Dim Writer As New SWFiles.CreateSWFiles
            Dim Reader As String = Writer.ReadOlderSWFilesFile(Path)

            My.Computer.FileSystem.DeleteFile(Path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Form1.User.Username & "\Temp\NoneS", "TryOS created file.", False)
            Writer.CreateSWFiles3File(Path, Reader, My.Application.Info.DirectoryPath & "\Users\" & Form1.User.Username & "\Temp")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub SecureModeTimer_Tick(sender As Object, e As EventArgs) Handles SecureModeTimer.Tick
        Try
            For Each form_ As Form In My.Application.OpenForms
                If form_.Name = "TryController" Then
                ElseIf form_.Name = "Form48" Then
                ElseIf form_.Name = "LogonForm" Then
                ElseIf form_.Name = "Form1" Then
                ElseIf form_.Name = "Form2" Then
                ElseIf form_.Name = "LoadingUser" Then
                ElseIf form_.Name = "StopWindow" Then
                ElseIf form_.Name = "UI" Then
                ElseIf form_.Name = "TryController" Then
                ElseIf form_.Name = "USWApp" Then
                ElseIf form_.Name = "ErrorMSGBox" Then
                Else
                    If Form1.currentForm.Name = form_.Name Then
                    Else
                        form_.Close()
                    End If
                End If
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub
End Class