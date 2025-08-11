Imports System.Windows.Input

Public Class DeviceInto
    Private Function GetOSVersion() As String
        Dim OSVersion As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMajorVersionNumber", Nothing)
        OSVersion = OSVersion & "." & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMinorVersionNumber", Nothing)
        OSVersion = OSVersion & "." & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        OSVersion = OSVersion & "." & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "UBR", Nothing)
        Return OSVersion
    End Function

    Private Sub DeviceInto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "OS Name: " & My.Computer.Info.OSFullName
        Label2.Text = "OS Version: " & GetOSVersion()
        If HasTouchSupport() = True Then
            Label3.Text = "Has Touch Support: Yes"
        ElseIf HasTouchSupport() = False Then
            Label3.Text = "Has Touch Support: No"
        End If
        Label4.Text = "Computer Name: " & Environment.MachineName
    End Sub

    Private Function HasTouchSupport() As Boolean
        Dim hasTouch As Boolean = Tablet.TabletDevices.Cast(Of TabletDevice)().
                                  Any(Function(td) td.Type = TabletDeviceType.Touch)

        If hasTouch Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Form1.IsUsingDarkThemeForApps = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Color.Gray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray
        End If
    End Sub
End Class
