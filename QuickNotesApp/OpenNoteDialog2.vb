Imports System.Windows.Forms

Public Class OpenNoteDialog2

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Form15 As Form15

    Public FullFilePath As String = Nothing

    'Public FileNameWithoutExtension As String = Nothing
    'Public FileNameWithPath As String = Nothing
    'Public FileNameWithoutPath As String = Nothing

    Public Sub LoadMe(MeForm As Form15)
        Form15 = MeForm
        ShowDialog()
    End Sub

    Public Sub LoadNoteButtons()
        Dim number As Int64 = 1
        Dim UserNotesFolder = Main._host.GetUserFolder() & "\Notes"
        Dim files() As IO.FileInfo
        Dim dirinfo As New IO.DirectoryInfo(UserNotesFolder)
        files = dirinfo.GetFiles("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            If file.Extension.Contains("swnote") = True Then
                Dim NoteInfoList As List(Of String) = Form15.QuickNotesLib.OpenNote(UserNotesFolder, Main._host.GetUserFolder() & "\Temp", file.Name.Replace(".swnote", ""), Form15.AppVersion, True)

                Dim list As New List(Of String)

                list.Add(NoteInfoList.Item(1))
                list.Add(file.FullName)

                Dim NewButton As New Button
                NewButton.Name = "NoteButton" & number.ToString
                NewButton.BackColor = Cancel_Button.BackColor
                NewButton.FlatStyle = FlatStyle.Flat
                NewButton.Font = Cancel_Button.Font
                NewButton.Size = Cancel_Button.Size
                NewButton.BackColor = Cancel_Button.BackColor
                NewButton.Text = NoteInfoList.Item(0)
                NewButton.Tag = list
                AddHandler NewButton.Click, AddressOf NoteButton_Click
                FlowLayoutPanel1.Controls.Add(NewButton)
                number = number + 1
            End If
        Next
    End Sub



    Private Sub NoteButton_Click(sender As Object, e As EventArgs)
        If Form15.HasANoteBeenLoaded = False Then
            Form15.HasANoteBeenLoaded = True
        End If

        Dim list As List(Of String) = sender.Tag

        Form15.TextBox1.Text = list.Item(0)
        Form15.TextBox1old.Text = list.Item(0)
        Form15.FullFilePath = list.Item(1)
        Form15.NoteName = sender.Text
        OK_Button_Click(Me, e)
    End Sub

    Private Sub OpenNoteDialog2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadNoteButtons()
    End Sub
End Class
