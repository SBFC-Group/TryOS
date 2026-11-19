Imports System.IO

Public Class TryController
    Public ReadOnly CoreID As Int64
    Private HasBeenOpened As Boolean = False
    Private StartSafe As Boolean = False

    Public DebugManager As DebugManager

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If UI_SM.IsCoreIDSet = False Then
            UI_SM.IsCoreIDSet = True

            Dim random As New Random
            CoreID = random.Next(10000, 99999)
        Else
            StartSafe = True
        End If

    End Sub

    Public Function GetBranch()
        Return "Helium_(1.3)"
    End Function

    Private Sub TryController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As String = Environment.CommandLine

        If args.Contains("/InstallApp:") = True Then

            Dim strlist As String() = Environment.GetCommandLineArgs()

            For Each str As String In strlist
                If str.StartsWith("/InstallApp:") = True And str.Contains(":\") = True And str.EndsWith(".tryapp") = True Then
                    str = str.Remove(0, 12)
                    TryOS_Store_Manager.Class1.InstallTryOSApp(str)
                End If
            Next

            If args.Contains("/DevMode") = True Then
                If MsgBox("Want to run TryOS?", MsgBoxStyle.YesNo, "TryOS") = MsgBoxResult.No Then
                    End
                End If
            Else
                End
            End If


        End If

        If args.Contains("/DevMode") = True Then
            DebugManager = New DebugManager
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

            UI_SM.DoesOldGUIWork = False
        Else
            Console.Show()

            Me.WindowState = FormWindowState.Minimized

            Me.ShowInTaskbar = False

            UI_SM.DoesOldGUIWork = True
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

    Public Shared Sub WriteToDebuggerOutput(ob As String)
        If TryController.DebugManager IsNot Nothing Then
            TryController.DebugManager.WriteLine(ob)
        End If
    End Sub

    Public Shared Sub WriteToDebuggerOutput(ob As Object)
        If TryController.DebugManager IsNot Nothing Then
            TryController.DebugManager.WriteLine(ob)
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

    Public Function Resuteg(Optional ID As Int64 = 0)
        If StartSafe = True Then
            Return Nothing
        End If

        If ID = CoreID Then
            Return erehresuteg
        Else
            Return Nothing
        End If
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

    Public Enum HowWasTaskCompleted
        Successfully = 1
        Failed = 2
        Canceled = 3
        Faulted = 4
    End Enum

    Public Function ShowStopWindow(message As String)
        Dim exception As New Exception(message)
        UI.ShowStopWindow(exception)
        Return "Started Stop Window"
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
                        If Form1.AppList.Contains(form_) = False Then
                            form_.Close()
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            DebugManager.WriteLine(ex.Message)
        End Try

    End Sub

    Private Shared Function IsZipFile(filePath As String) As Boolean
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


    Public Enum SWFilesVersion
        Other = 0
        SWFiles_1_0 = 1
        SWFiles_1_1 = 2
        SWFiles_2_0 = 3
        SWFiles_3_0 = 4
    End Enum

    ''' <summary>This checks if the swfiles file is version 1.0/1.1/2.0 (text file based) or 3.0 (zip based)</summary>
    Public Shared Function IsSWFilesVersionTheNewst(Path As String) As SWFilesVersion
        If My.Computer.FileSystem.FileExists(Path) = False Then Return Nothing

        If Path.EndsWith(".swfiles") = False Then Return SWFilesVersion.Other

        If IsZipFile(Path) = False Then
            Dim reader As String = My.Computer.FileSystem.ReadAllText(Path)

            Try
                Dim b As Byte() = Convert.FromBase64String(reader)
                reader = System.Text.Encoding.UTF8.GetString(b)
            Catch ex As Exception
                Return SWFilesVersion.SWFiles_1_0
            End Try

            Try
                Dim b As Byte() = Convert.FromBase64String(reader)
                reader = System.Text.Encoding.UTF8.GetString(b)
                Return SWFilesVersion.SWFiles_2_0
            Catch ex As Exception
                Return SWFilesVersion.SWFiles_1_1
            End Try
        Else
            Return SWFilesVersion.SWFiles_3_0
        End If
    End Function
End Class