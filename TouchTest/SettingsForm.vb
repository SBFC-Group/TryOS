Imports System.Runtime.InteropServices

Public Class SettingsForm
    Public SettingsPanel As SettingsApp
    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SettingsPanel = New SettingsApp
        SettingsPanel.Dock = DockStyle.Fill

        Panel2.Controls.Add(SettingsPanel)

    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Form1.IsSettingOpen = False
        Close()
    End Sub

    Private Sub MaxiButton_Click(sender As Object, e As EventArgs) Handles MaxiButton.Click
        'If WindowState = FormWindowState.Maximized Then
        'WindowState = FormWindowState.Normal
        'Else
        'WindowState = FormWindowState.Maximized
        'End If
    End Sub

    Private Sub MiniButton_Click(sender As Object, e As EventArgs) Handles MiniButton.Click
        'WindowState = FormWindowState.Minimized
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Dim hh As Boolean = False
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If hh = True Then
            ReleaseCapture()
            SendMessage(Me.Handle, &H112, &HF012, 0)
        End If
    End Sub

    Public Sub PluginButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim plugin As OpenFramework_Interface = CType(btn.Tag, OpenFramework_Interface)

        Dim frm As Form = New SettingsForm
        If Form1.currentForm IsNot Nothing Then
            If frm.Text = OpenFramework_Data.AppName Then
                Exit Sub
            End If
        End If
        OpenFramework_Data.AppName = frm.Text
        frm.Text = "SettingsForm"
        Form1.OpenChildForm(frm)

    End Sub
End Class