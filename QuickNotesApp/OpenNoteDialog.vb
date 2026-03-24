Imports System.Windows.Forms
Imports QuickNotesLib

Public Class OpenNoteDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Number As Int64 = 1

    Private Sub LoadMe()
        If My.Computer.FileSystem.FileExists(Main._host.GetUserFolder() & "\Notes\quicknote_" & Number & ".swnote") Then
            If My.Computer.FileSystem.DirectoryExists(Main._host.GetUserFolder() & "\Temp\notesreader") Then
                My.Computer.FileSystem.CreateDirectory(Main._host.GetUserFolder() & "\Temp\notesreader")
            End If

            IO.Compression.ZipFile.ExtractToDirectory(Main._host.GetUserFolder() & "\Notes\quicknote_" & Number.ToString & ".swnote", Main._host.GetUserFolder() & "\Temp\notesreader")

            System.Threading.Thread.Sleep(100)

            Dim Reader As String = My.Computer.FileSystem.ReadAllText(Main._host.GetUserFolder() & "\Temp\notesreader\NoteName.swfiles")

            If Number = 1 Then
                Button1.Visible = True
                Button1.Text = Reader
            ElseIf Number = 2 Then
                Button2.Visible = True
                Button2.Text = Reader
            ElseIf Number = 3 Then
                Button3.Visible = True
                Button3.Text = Reader
            ElseIf Number = 4 Then
                Button4.Visible = True
                Button4.Text = Reader
            ElseIf Number = 5 Then
                Button5.Visible = True
                Button5.Text = Reader
            ElseIf Number = 6 Then
                Button6.Visible = True
                Button6.Text = Reader
            ElseIf Number = 7 Then
                Button7.Visible = True
                Button7.Text = Reader
            ElseIf Number = 8 Then
                Button8.Visible = True
                Button8.Text = Reader
            ElseIf Number = 9 Then
                Button9.Visible = True
                Button9.Text = Reader
            ElseIf Number = 10 Then
                Button10.Visible = True
                Button10.Text = Reader
            ElseIf Number = 11 Then
                Button11.Visible = True
                Button11.Text = Reader
            ElseIf Number = 12 Then
                Button12.Visible = True
                Button12.Text = Reader
            ElseIf Number = 13 Then
                Button13.Visible = True
                Button13.Text = Reader
            ElseIf Number = 14 Then
                Button14.Visible = True
                Button14.Text = Reader
            ElseIf Number = 15 Then
                Button15.Visible = True
                Button15.Text = Reader
            ElseIf Number = 16 Then
                Button16.Visible = True
                Button16.Text = Reader
            ElseIf Number = 17 Then
                Button17.Visible = True
                Button17.Text = Reader
            ElseIf Number = 18 Then
                Button18.Visible = True
                Button18.Text = Reader
            ElseIf Number = 19 Then
                Button19.Visible = True
                Button19.Text = Reader
            ElseIf Number = 20 Then
                Button20.Visible = True
                Button20.Text = Reader
            ElseIf Number = 21 Then
                Button21.Visible = True
                Button21.Text = Reader
            ElseIf Number = 22 Then
                Button22.Visible = True
                Button22.Text = Reader
            ElseIf Number = 23 Then
                Button23.Visible = True
                Button23.Text = Reader
            ElseIf Number = 24 Then
                Button24.Visible = True
                Button24.Text = Reader
            ElseIf Number = 25 Then
                Button25.Visible = True
                Button25.Text = Reader
            ElseIf Number = 26 Then
                Button26.Visible = True
                Button26.Text = Reader
            ElseIf Number = 27 Then
                Button27.Visible = True
                Button27.Text = Reader
            ElseIf Number = 28 Then
                Button28.Visible = True
                Button28.Text = Reader
            ElseIf Number = 29 Then
                Button29.Visible = True
                Button29.Text = Reader
            ElseIf Number = 30 Then
                Button30.Visible = True
                Button30.Text = Reader
            ElseIf Number = 31 Then
                Button31.Visible = True
                Button31.Text = Reader
            ElseIf Number = 32 Then
                Button32.Visible = True
                Button32.Text = Reader
            ElseIf Number = 33 Then
                Button33.Visible = True
                Button33.Text = Reader
            ElseIf Number = 34 Then
                Button34.Visible = True
                Button34.Text = Reader
            ElseIf Number = 35 Then
                Button35.Visible = True
                Button35.Text = Reader
            ElseIf Number = 36 Then
                Button36.Visible = True
                Button36.Text = Reader
            ElseIf Number = 37 Then
                Button37.Visible = True
                Button37.Text = Reader
            ElseIf Number = 38 Then
                Button38.Visible = True
                Button38.Text = Reader
            ElseIf Number = 39 Then
                Button39.Visible = True
                Button39.Text = Reader
            ElseIf Number = 40 Then
                Button40.Visible = True
                Button40.Text = Reader
            ElseIf Number = 41 Then
                Button41.Visible = True
                Button41.Text = Reader
            ElseIf Number = 42 Then
                Button42.Visible = True
                Button42.Text = Reader
            ElseIf Number = 43 Then
                Button43.Visible = True
                Button43.Text = Reader
            ElseIf Number = 44 Then
                Button44.Visible = True
                Button44.Text = Reader
            ElseIf Number = 45 Then
                Button45.Visible = True
                Button45.Text = Reader
            ElseIf Number = 46 Then
                Button46.Visible = True
                Button46.Text = Reader
            ElseIf Number = 47 Then
                Button47.Visible = True
                Button47.Text = Reader
            ElseIf Number = 48 Then
                Button48.Visible = True
                Button48.Text = Reader
            ElseIf Number = 49 Then
                Button49.Visible = True
                Button49.Text = Reader
            ElseIf Number = 50 Then
                Button50.Visible = True
                Button50.Text = Reader
            ElseIf Number = 51 Then
                Button51.Visible = True
                Button51.Text = Reader
            ElseIf Number = 52 Then
                Button52.Visible = True
                Button52.Text = Reader
            ElseIf Number = 53 Then
                Button53.Visible = True
                Button53.Text = Reader
            ElseIf Number = 54 Then
                Button54.Visible = True
                Button54.Text = Reader
            ElseIf Number = 55 Then
                Button55.Visible = True
                Button55.Text = Reader
            ElseIf Number = 56 Then
                Button56.Visible = True
                Button56.Text = Reader
            Else

            End If

            System.Threading.Thread.Sleep(100)

            My.Computer.FileSystem.DeleteDirectory(Main._host.GetUserFolder() & "\Temp\notesreader", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Number = Number + 1
            LoadMe()
        End If

    End Sub

    Public Function GetValueNow() As String
        ShowDialog()
        Return ButtonWasPressed
    End Function

    Private Sub OpenNoteDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMe()
    End Sub

    Private ButtonWasPressed As String

    Private Sub NoteButton1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button13.Click, Button14.Click, Button15.Click,
 Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click,
  Button38.Click, Button39.Click, Button40.Click, Button41.Click, Button42.Click, Button43.Click, Button44.Click, Button45.Click, Button46.Click, Button47.Click, Button48.Click, Button49.Click, Button50.Click, Button51.Click, Button52.Click, Button53.Click, Button54.Click, Button55.Click, Button56.Click
        '-------------------------------------------------------------------------------------------------------------------------------
        Dim Isold As Boolean = True
        If Isold = False Then

            Dim WriteOINew As String = sender.Name

            WriteOINew = WriteOINew.Replace("Button", "")

            'This opens the note
            'ButtonWasPressed = Form15.QuickNotesLib.OpenNote(Main._host.GetUserFolder() & "\Notes", Main._host.GetUserFolder() & "\Temp", Main._host.GetUserFolder() & "\Notes\quicknote_" & WriteOINew & ".swnote")



            Exit Sub
        End If

        Dim WriteOI As String = sender.Name

        WriteOI = WriteOI.Replace("Button", "")

        If My.Computer.FileSystem.DirectoryExists(Main._host.GetUserFolder() & "\Temp\notesreader") Then
            My.Computer.FileSystem.CreateDirectory(Main._host.GetUserFolder() & "\Temp\notesreader")
        End If

        IO.Compression.ZipFile.ExtractToDirectory(Main._host.GetUserFolder() & "\Notes\quicknote_" & WriteOI & ".swnote", Main._host.GetUserFolder() & "\Temp\notesreader")

        ButtonWasPressed = My.Computer.FileSystem.ReadAllText(Main._host.GetUserFolder() & "\Temp\notesreader\NoteText.swfiles")

        System.Threading.Thread.Sleep(100)

        My.Computer.FileSystem.DeleteDirectory(Main._host.GetUserFolder() & "\Temp\notesreader", FileIO.DeleteDirectoryOption.DeleteAllContents)

        Close()
    End Sub

    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click
        Close()
    End Sub
End Class
