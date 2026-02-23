Imports System.Drawing

Public Class InfoApp
    Private Sub InfoApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "Version: " & My.Application.Info.Version.ToString
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
            Me.BackColor = Color.Gray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray

        End If
    End Sub
End Class
