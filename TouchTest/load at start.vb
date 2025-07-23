Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class load_at_start
    Private Sub load_at_start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\load1.tabsetting") Then
            Dim web As String = ""
            web = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\load1.tabsetting")
            CheckBox1.Checked = True
            TextBox1.Text = web
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\load2.tabsetting") Then
            Dim web As String = ""
            web = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\load2.tabsetting")
            CheckBox2.Checked = True
            TextBox2.Text = web
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\load3.tabsetting") Then
            Dim web As String = ""
            web = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\load3.tabsetting")
            CheckBox3.Checked = True
            TextBox3.Text = web
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\load4.tabsetting") Then
            Dim web As String = ""
            web = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\load4.tabsetting")
            CheckBox4.Checked = True
            TextBox4.Text = web
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\load5.tabsetting") Then
            Dim web As String = ""
            web = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\load5.tabsetting")
            CheckBox5.Checked = True
            TextBox5.Text = web
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\load6.tabsetting") Then
            Dim web As String = ""
            web = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\load6.tabsetting")
            CheckBox6.Checked = True
            TextBox6.Text = web
        End If
        'Panel1.BackColor = Form_1pad.TaskbarColor
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If CheckBox1.CheckState = CheckState.Checked Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\load1.tabsetting", TextBox1.Text, False)
        End If
        If CheckBox2.CheckState = CheckState.Checked Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\load2.tabsetting", TextBox2.Text, False)
        End If
        If CheckBox3.CheckState = CheckState.Checked Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\load3.tabsetting", TextBox3.Text, False)
        End If
        If CheckBox4.CheckState = CheckState.Checked Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\load4.tabsetting", TextBox4.Text, False)
        End If
        If CheckBox5.CheckState = CheckState.Checked Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\load5.tabsetting", TextBox5.Text, False)
        End If
        If CheckBox6.CheckState = CheckState.Checked Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\load6.tabsetting", TextBox6.Text, False)
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
    'Drag Form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
