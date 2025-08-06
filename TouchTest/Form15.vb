Imports System.Runtime.InteropServices

Public Class Form15
    Public opened As String = "0"
    Public FullScreen As Integer = 0
    Public S5478 As Panel
    Public Versionofapp As String = "3.2.0"
    Public PanelTing As Panel

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
        End If
    End Sub

    Private Sub OpenFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFileToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        'Form_1pad.About__ = "1"
        'About2.Show()
        'About2.LabelProductName.Text = "Product Quick Edit"
        'If Form_1pad.textedit = "New" Then
        'About2.LabelVersion.Text = "Version " & Versionofapp
        'Else
        'About2.LabelVersion.Text = "Version 3.0.0"
        'End If

        'About2.Icon = Me.Icon
        'About2.PictureBox1.Image = PictureBox1.Image
        'About2.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        'About2.Text = "About Quick Edit"
        'Form_1pad.About__ = "0"

    End Sub

    Private Sub TheWebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Form19.Show()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        TextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        TextBox1.Paste()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        TextBox1.Cut()
    End Sub

    Private Sub DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DToolStripMenuItem.Click
        TextBox1.SelectAll()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim text As New Form15
        text.Show()
    End Sub

    Private Sub FontDialog1_Apply(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontDialog1.Apply
        TextBox1.Font = FontDialog1.Font
        TextBox1.ForeColor = FontDialog1.Color
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.Font = TextBox1.Font
        FontDialog1.Color = TextBox1.ForeColor
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Font = FontDialog1.Font
            TextBox1.ForeColor = FontDialog1.Color
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'If WindowState = FormWindowState.Normal Then
        'WindowState = FormWindowState.Maximized
        'Else
        'WindowState = FormWindowState.Normal
        'End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If UI.Panel1.Visible = True Then
        'Else
        'Form37.Show()
        'Form37.TextBox1.Text = TextBox1.Text
        'Close()
        'End If
    End Sub

    Private Sub OpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpToolStripMenuItem.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub StatasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatasToolStripMenuItem.Click
        If StatusStrip1.Visible = True Then
            StatusStrip1.Visible = False
        Else
            StatusStrip1.Visible = True
        End If
    End Sub

    'Drag Form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    'New Move Form code
    Dim CanIMoveWindow As Boolean = False
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If CanIMoveWindow = True Then
            ReleaseCapture()
            SendMessage(Me.Handle, &H112, &HF012, 0)
        End If

    End Sub

    Private Sub TrueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrueToolStripMenuItem.Click
        TextBox1.ReadOnly = True
    End Sub

    Private Sub FalseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FalseToolStripMenuItem.Click
        TextBox1.ReadOnly = False
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown ', Label1.MouseDown

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Close()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Public Sub RemoveUnusedParts()
        ToolStripSeparator4.Visible = False
        AboutQuickEditToolStripMenuItem.Visible = False
        TToolStripMenuItem.Visible = False
    End Sub


    Public Path As String
    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UI.SecureAppCheck("{C8CAFE9B-DB4C-4BDB-BECF-7A6FF4378C21}", Me, Versionofapp)
        Timer1.Start()
        'If Form_1pad.BlockSebsModren = True Then
        'Close()
        'End If

        'If Form_1pad.BlockUsercontrolModren = True Then
        'Button4.Enabled = False
        'SettingsToolStripMenuItem.Enabled = False
        'End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "\Users\" & Form1.Username & "\Apps\QuickNotes.swfiles") Then
            RemoveUnusedParts()
        Else
            Close()
        End If

        ToolStripStatusLabel1.Text = "Quick Edit " & Versionofapp
        'FormatToolStripMenuItem.Visible = False
        'ViewToolStripMenuItem.Visible = False
        'ToolStripSeparator2.Visible = True
        'FontToolStripMenuItem1.Visible = True
        'StatusBarToolStripMenuItem.Visible = True

        'If Form_1pad.textedit = "New" Then
        'Button4.Visible = True
        'ToolStripSeparator4.Visible = True
        'SettingsToolStripMenuItem.Visible = True
        'End If

        'If Form_1pad.TaskbarPanel.Visible = True Then
        'Panel1.BackColor = Form_1pad.TaskbarColor
        'Panel3.BackColor = Form_1pad.TaskbarColor
        'ElseIf Form_1pad.Panel1.Visible = True Then
        'Panel1.BackColor = Form_1pad.Panel1.BackColor
        'Panel3.BackColor = Form_1pad.Panel1.BackColor
        'End If

        'If Panel1.BackColor = Color.Black Then
        'Button1.BackgroundImage = My.Resources._2920659_White
        'Button2.BackgroundImage = My.Resources._1266721_White
        'Button3.BackgroundImage = My.Resources.minimize2_White
        'Label1.ForeColor = Color.White
        'MenuStrip1.ForeColor = Color.White
        'End If

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "\ext\readonly.swfiles") Then
            Dim reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\ext\readonly.swfiles")
            If reader = "3.0.0" Then
                ReadOnlyToolStripMenuItem.Visible = True
            End If
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "\ext\endecode.swfiles") Then
            Dim reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\ext\endecode.swfiles")
            If reader = "3.0.0" Then
                EnDecodeToolStripMenuItem.Visible = True
            End If
        End If
    End Sub

    Private Sub ClearTextBoxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearTextBoxToolStripMenuItem.Click
        If MsgBox("Clear TextBox", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub FontToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem1.Click
        FontToolStripMenuItem_Click(Me, e)
    End Sub


    '1. Anna Edit
    '2. CVEdit
    '3. The Editor
    '4. Lion Edit
    '5. Quick Edit

    Private Sub StatusBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        StatasToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub TextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TextBox1.LinkClicked
        If TextBox1.Text = "http://fullconsole" Then
            Console.Show()
            Form1.IsQuickNotesOpen = False
        Else
            If TextBox1.Text = "http://shellconsole" Then
                UI.StartCMD()
                Form1.IsQuickNotesOpen = False
            Else
                'If Form_1pad.textedit = "New" Then
                'Try
                'Internetplusplus.Show()
                'Internetplusplus.WebView21.Source = New Uri(TextBox1.Text)

                'Catch ex As Exception
                'MsgBox(ex.Message)
                'End Try
                'End If
            End If
        End If
    End Sub

    Private Sub FullScreenModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullScreenModeToolStripMenuItem.Click, ToolStripMenuItem1.Click
        Panel1.Visible = False
        Panel3.Visible = False
        Windowborder1.Visible = False
        Windowborder2.Visible = False
        StatusStrip1.Visible = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ToolStripStatusLabel2.Text = TextBox1.Text.Length.ToString
        If TextBox1.CanUndo Then
            ToolStripMenuItem5.Enabled = True
        Else
            ToolStripMenuItem5.Enabled = False
        End If
        If TextBox1.CanRedo Then
            ToolStripMenuItem6.Enabled = True
        Else
            ToolStripMenuItem6.Enabled = False
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        TextBox1.Undo()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        TextBox1.Redo()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            TextBox1.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
        Catch ex As Exception
            Try
                TextBox1.SaveFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
            Catch ex2 As Exception
                SaveAsToolStripMenuItem_Click(Me, e)
            End Try
        End Try

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Button4_Click(Me, e)
    End Sub

    Private Sub EncodeTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncodeToolStripMenuItem.Click
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(TextBox1.Text)
        TextBox1.Text = Convert.ToBase64String(byt)
    End Sub

    Private Sub DecodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecodeToolStripMenuItem.Click
        Try
            Dim b As Byte() = Convert.FromBase64String(TextBox1.Text)
            TextBox1.Text = System.Text.Encoding.UTF8.GetString(b)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Quick Edit " & Versionofapp)
        End Try

    End Sub

    Private Sub SebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SebToolStripMenuItem.Click
        TextBox1.Cut()
    End Sub

    Private Sub SopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SopToolStripMenuItem.Click
        TextBox1.Copy()
    End Sub

    Private Sub HIPHOPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HIPHOPToolStripMenuItem.Click
        TextBox1.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        TextBox1.SelectAll()
    End Sub

    Private Sub AboutQuickEditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutQuickEditToolStripMenuItem.Click
        'Form_1pad.About__ = "1"
        'About2.Show()
        'About2.LabelProductName.Text = "Product: Quick Edit"
        'About2.LabelVersion.Text = "Version: " & Versionofapp
        'About2.Icon = Me.Icon
        'About2.PictureBox1.Image = PictureBox1.Image
        'About2.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        'About2.Text = "About Quick Edit"
        'Form_1pad.About__ = "0"
    End Sub

    Private Sub NewNoteButton_Click(sender As Object, e As EventArgs) Handles NewNoteButton.Click
        NewNoteDialog.Form15Text = TextBox1.Text
        NewNoteDialog.ShowDialog()
    End Sub

    Private Sub OpenNoteButton_Click(sender As Object, e As EventArgs) Handles OpenNoteButton.Click
        Dim Checker As String
        Checker = OpenNoteDialog.GetValueNow()
        If Checker = "" Then
        Else
            TextBox1.Text = Checker
        End If
    End Sub
End Class