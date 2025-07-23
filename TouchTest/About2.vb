Imports System.Runtime.InteropServices

Public Class About2
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Dim hh As Boolean = True
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If hh = True Then
            ReleaseCapture()
            SendMessage(Me.Handle, &H112, &HF012, 0)
        End If
    End Sub
    Private Sub About2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "Version: " & My.Application.Info.Version.ToString
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub
End Class
