Public Class DeviceInfoApp
    Private Sub DeviceInto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeDesign(Main.Controller.IsDarkMode())

        Label1.Text = "OS Name: " & Main.Controller.GetOSVersion(False)
        Label2.Text = "OS Version: " & Main.Controller.GetOSVersion(True)
        Label4.Text = "Computer Name: " & Environment.MachineName
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Main.Controller.IsDarkMode() = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Main.Controller.IsDarkMode() = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Drawing.Color.Gray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Drawing.Color.DarkGray
        End If
    End Sub
End Class
