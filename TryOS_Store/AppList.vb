Imports System.Windows.Forms

Public Class AppList
    Private LocalAppInfo As AppInfo

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
            AddHandler NewButton.Click, AddressOf N_Click
            FlowLayoutPanel1.Controls.Add(NewButton)
        Next
    End Sub

    Private Sub LoadApp(AppInfo As AppInfo)
        If AppInfo.Name = "SettingsForm" Then
            Button2.Enabled = False
        ElseIf AppInfo.Name = "TryOS_Store" Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If

        AppNameLabel.Text = "Name: " & AppInfo.Name
        AppFolderLabel.Text = "Folder Name: " & AppInfo.FolderName
        VersonLabel.Text = $"Version: {AppInfo.Version.Major.ToString}.{AppInfo.Version.Minor.ToString}.{AppInfo.Version.Build.ToString}"
        AppIcon.Image = AppInfo.Icon

        LocalAppInfo = AppInfo
    End Sub

    Private Sub N_Click(sender As Object, e As EventArgs)
        LoadApp(sender.Tag)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FlowLayoutPanel1.Controls.Clear()
        LoadApps(My.Application.Info.DirectoryPath & "\Apps")
    End Sub

    Private Sub AppList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadApps(My.Application.Info.DirectoryPath & "\Apps")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AppNameLabel.Text = "Name: "
        AppFolderLabel.Text = "Folder Name: "
        VersonLabel.Text = "Version: "
        AppIcon.Image = Nothing
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Apps\" & LocalAppInfo.FolderName) = True Then
            My.Computer.FileSystem.DeleteDirectory(My.Application.Info.DirectoryPath & "\Apps\" & LocalAppInfo.FolderName, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
    End Sub
End Class
