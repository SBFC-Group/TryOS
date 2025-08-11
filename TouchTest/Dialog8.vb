Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class Dialog8
    Public Function ShowColorDialog() As DialogResult
        Me.ShowDialog()
        Return FormDialogResult
    End Function

    Public MainColor As Color

    Public picker_ As Object
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If picker_ Is Nothing Then
        Else
            MainColor = picker_.BackColor
            picker_ = Nothing
            'Form_1pad.TaskbarColor = picker_.BackColor
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        FormDialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private FormDialogResult As DialogResult

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        FormDialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PictureBox48_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click, PictureBox8.Click, PictureBox7.Click, PictureBox6.Click, PictureBox5.Click, PictureBox48.Click, PictureBox47.Click, PictureBox46.Click, PictureBox45.Click, PictureBox44.Click, PictureBox43.Click, PictureBox42.Click, PictureBox41.Click, PictureBox40.Click, PictureBox4.Click, PictureBox39.Click, PictureBox38.Click, PictureBox37.Click, PictureBox36.Click, PictureBox35.Click, PictureBox34.Click, PictureBox33.Click, PictureBox32.Click, PictureBox31.Click, PictureBox30.Click, PictureBox3.Click, PictureBox29.Click, PictureBox28.Click, PictureBox27.Click, PictureBox26.Click, PictureBox25.Click, PictureBox24.Click, PictureBox23.Click, PictureBox22.Click, PictureBox21.Click, PictureBox20.Click, PictureBox2.Click, PictureBox19.Click, PictureBox18.Click, PictureBox17.Click, PictureBox16.Click, PictureBox15.Click, PictureBox14.Click, PictureBox13.Click, PictureBox12.Click, PictureBox11.Click, PictureBox10.Click, PictureBox1.Click
        'sender.BorderStyle = BorderStyle.FixedSingle
        PictureBox49.BackColor = sender.BackColor
        picker_ = sender
    End Sub

    Public Sub is_selled()
        If PictureBox1.BorderStyle = BorderStyle.FixedSingle Then
            'PictureBox2
        End If
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
        'ReleaseCapture()
        'SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub Dialog8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'panel1.BackColor = Form_1pad.TaskbarColor
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Settings\TaskbarColor.swfiles")
            'Form_1pad.TaskbarColor = Color.Silver
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        OK_Button_Click(Me, e)
    End Sub
End Class
