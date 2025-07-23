Imports System.Runtime.InteropServices
'Taken From LanaOS
Public Class InfoDialog
    'OK Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AllowClosing = True
        Close()
    End Sub

    'Cancel Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AllowClosing = True
        Close()
    End Sub

    'Yes Button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AllowClosing = True
        Close()
    End Sub

    'No Button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AllowClosing = True
        Close()
    End Sub

    'Close Button
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Close()
    End Sub


    '---------------------------------------------------------------------------------------


    Private AllowClosing As Boolean = False

    Private Sub InfoDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UI.InfoForms_Info = Nothing Then
            AllowClosing = True
            Close()
        ElseIf UI.InfoForms_Info = "OnlyOkButton" Then
            Button1.Visible = True
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False

            'Close Button
            Button5.Enabled = True

            'Resets Info
            UI.InfoForms_Info = "OnlyOkButton"

            'Allows the form to close
            AllowClosing = True
        ElseIf UI.InfoForms_Info = "YesNoButton" Then
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = True
            Button4.Visible = True

            'Close Button
            Button5.Enabled = False

            'Resets Info
            UI.InfoForms_Info = "OnlyOkButton"

            'Disallows the form to close
            AllowClosing = False
        ElseIf UI.InfoForms_Info = "OKCancelButton" Then
            Button1.Visible = True
            Button2.Visible = True
            Button3.Visible = False
            Button4.Visible = False

            'Close Button
            Button5.Enabled = False

            'Resets Info
            UI.InfoForms_Info = "OnlyOkButton"

            'Disallows the form to close
            AllowClosing = False
        End If
    End Sub

    Private Sub InfoDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If AllowClosing = False Then
            e.Cancel = True
        Else

        End If
    End Sub

    Private Sub Button5_MouseEnter(sender As Object, e As EventArgs) Handles Button5.MouseEnter
        Button5.ForeColor = Color.White
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.ForeColor = Color.Black
    End Sub

    'Drag Form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    'New Move Form code
    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub
End Class