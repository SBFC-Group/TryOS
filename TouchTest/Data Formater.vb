Public Class Data_Formater
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim Text1 As String = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            Dim Text2 As Byte() = My.Computer.FileSystem.ReadAllBytes(OpenFileDialog1.FileName)
            RichTextBox1.Text = Text1
            Dim dd As String
            dd = Convert.ToSingle(dd)
            RichTextBox2.Text = dd
            My.Computer.FileSystem.WriteAllBytes("C:\Dis_finder\HH", Text2, False)
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click

    End Sub
End Class