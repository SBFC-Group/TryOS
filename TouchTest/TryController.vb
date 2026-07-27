Imports System.IO

Public Class TryController
    Public ReadOnly CoreID As Int64
    Private HasBeenOpened As Boolean = False
    Private StartSafe As Boolean = False

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
        Return "Plutonium_(1.2)"
    End Function

    Private Sub TryController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As String = Environment.CommandLine

        'If args.Contains("/ReturnVersion") = True Then
        '    System.Console.WriteLine(GetVersion)
        '    End
        'End If

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
            Debug.WriteLine(ex.Message)
        End Try

    End Sub
End Class