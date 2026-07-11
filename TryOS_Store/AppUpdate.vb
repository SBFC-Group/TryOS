Imports System.Windows.Forms

Public Class AppUpdate
    Public Sub LoadApps(FolderPath As String)
        Dim dir1 = FolderPath
        Dim files() As System.IO.DirectoryInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            Dim NewButton As New Button
            NewButton.Name = "App_" & file.Name
            NewButton.Size = NeedThisButton.Size
            NewButton.FlatStyle = FlatStyle.Flat
            NewButton.Font = NeedThisButton.Font
            NewButton.BackColor = NeedThisButton.BackColor
            NewButton.Text = file.Name
            NewButton.Tag = New AppInfo(file.FullName)
            'AddHandler NewButton.Click, AddressOf N_Click
            FlowLayoutPanel1.Controls.Add(NewButton)
        Next
    End Sub

    Private Sub AppUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadApps(My.Application.Info.DirectoryPath & "\Apps")
    End Sub
End Class
