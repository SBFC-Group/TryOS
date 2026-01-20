Imports System
Imports System.Windows.Forms

Public Class Explorer
    Public PathHistory As New List(Of String)
    Public CurrentPlaceInHistory As Int64 = 0

    Public CurrentPath As String = My.Application.Info.DirectoryPath

    Private hiddenFolders As New List(Of String) From {
        "runtimes", "Settings", "Languages", "TouchTest.exe.WebView2"
    }

    Private Sub Explorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConfig()
    End Sub

    'Private DoesTryExplorerConfigFolderExist As Boolean = False

    Public Sub LoadConfig()
        If My.Computer.FileSystem.DirectoryExists(Main.Controller.GetUserFolder & "\Settings\TryExplorer") = False Then
            Try
                My.Computer.FileSystem.CreateDirectory(Main.Controller.GetUserFolder & "\Settings\TryExplorer")
                LoadConfig()
            Catch ex As System.IO.PathTooLongException
                Main.Controller.ShowError("The current path is too long for TryOS/Windows [IO.PathTooLongException]", TouchTest.ErrorMSGBox.Alerts.Exclamation)
                Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
            Catch ex As UnauthorizedAccessException
                Main.Controller.ShowError("Do you own root folder? [UnauthorizedAccessException]")
                Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
            Catch ex As Exception
                Main.Controller.ShowError(ex.Message)
                Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
            End Try
        Else
            'Loads Config from here
            Dim ConfigFolder As String = Main.Controller.GetUserFolder & "\Settings\TryExplorer"

            If My.Computer.FileSystem.FileExists(ConfigFolder & "\ViewMode.swfiles") Then

            End If

            If My.Computer.FileSystem.FileExists(ConfigFolder & "\ViewMode.swfiles") Then
                Dim Reader As String = My.Computer.FileSystem.ReadAllText(ConfigFolder & "\ViewMode.swfiles")
                If Reader = "0" Then
                    ListView1.View = Windows.Forms.View.LargeIcon
                ElseIf Reader = "1" Then
                    ListView1.View = Windows.Forms.View.Details
                ElseIf Reader = "2" Then
                    ListView1.View = Windows.Forms.View.SmallIcon
                ElseIf Reader = "3" Then
                    ListView1.View = Windows.Forms.View.List
                ElseIf Reader = "4" Then
                    ListView1.View = Windows.Forms.View.Tile
                End If
            Else
                Try
                    My.Computer.FileSystem.WriteAllText(ConfigFolder & "\ViewMode.swfiles", "0", False)
                Catch ex As System.IO.PathTooLongException
                    Main.Controller.ShowError("The current path is too long for TryOS/Windows [IO.PathTooLongException]", TouchTest.ErrorMSGBox.Alerts.Exclamation)
                    Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
                Catch ex As UnauthorizedAccessException
                    Main.Controller.ShowError("Do you own root folder? [UnauthorizedAccessException]")
                    Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
                Catch ex As Exception
                    Main.Controller.ShowError(ex.Message)
                    Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
                End Try
            End If


            If My.Computer.FileSystem.FileExists(ConfigFolder & "\ListedFolders.swfiles") Then
                LoadListedFolders(ConfigFolder & "\ListedFolders.swfiles")
            Else
                Try

                    My.Computer.FileSystem.WriteAllText(ConfigFolder & "\ListedFolders.swfiles", $"0={Main.Controller.GetUserFolder()};
1={Main.Controller.GetUserFolder()}\Downloads;
2={Main.Controller.GetUserFolder()}\Pictures;", False)
                    LoadListedFolders(ConfigFolder & "\ListedFolders.swfiles")
                Catch ex As System.IO.PathTooLongException
                    Main.Controller.ShowError("The current path is too long for TryOS/Windows [IO.PathTooLongException]", TouchTest.ErrorMSGBox.Alerts.Exclamation)
                    Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
                Catch ex As UnauthorizedAccessException
                    Main.Controller.ShowError("Do you own root folder? [UnauthorizedAccessException]")
                    Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
                Catch ex As Exception
                    Main.Controller.ShowError(ex.Message)
                    Debug.WriteLine(ex.Message & " <-> Happen in TryExplorer -> Explorer -> LoadConfig")
                End Try
            End If
            'Will make settings file for them soon. 16-01-2026
            ListView1.Columns.Add("Name", 250)
            ListView1.Columns.Add("Type", 100)
            ListView1.Columns.Add("Size", 100)

            ' Create root node
            'Dim rootNode As New TreeNode(IO.Path.GetFileName(CurrentPath))
            'rootNode.Tag = CurrentPath
            'TreeView1.Nodes.Add(rootNode)

            'Dim dirNode1 As New TreeNode("Apps")
            'dirNode1.Tag = Main.Controller.GetUserFolder() & "\Apps"
            'TreeView1.Nodes.Add(dirNode1)

            'Dim dirNode2 As New TreeNode("Downloads")
            'dirNode2.Tag = Main.Controller.GetUserFolder() & "\Downloads"
            'TreeView1.Nodes.Add(dirNode2)

            'Dim dirNode3 As New TreeNode("Pictures")
            'dirNode3.Tag = Main.Controller.GetUserFolder() & "\Pictures"
            'TreeView1.Nodes.Add(dirNode3)

            'Dim dirNode4 As New TreeNode("Settings")
            'dirNode4.Tag = Main.Controller.GetUserFolder() & "\Settings"
            'TreeView1.Nodes.Add(dirNode4)

            'Dim dirNode5 As New TreeNode("Temp")
            'dirNode5.Tag = Main.Controller.GetUserFolder() & "\Temp"
            'TreeView1.Nodes.Add(dirNode5)

            ' Load everything but hide restricted folders
            'LoadAllDirectories(rootNode)
        End If


    End Sub

    Public Sub LoadListedFolders(ConfigPath As String)
        Dim TempTextBox As New TextBox
        If My.Computer.FileSystem.FileExists(ConfigPath) Then
            TempTextBox.Text = My.Computer.FileSystem.ReadAllText(ConfigPath)
        End If
        Dim StringList As New List(Of String)

        For Each s In TempTextBox.Lines
            Dim NewText As String = s
            NewText = NewText.Remove(0, 2)
            NewText = NewText.Remove(NewText.Length - 1, 1)
            'Debug.WriteLine(s)
            CreateButton(NewText)

        Next

    End Sub

    Private Sub CreateButton(Path As String)
        Dim folderinfo As New IO.DirectoryInfo(Path)
        Dim NewButton As New Button
        NewButton.Name = folderinfo.Name
        NewButton.BackColor = Button4.BackColor
        NewButton.FlatStyle = FlatStyle.Flat
        NewButton.Size = Button4.Size
        NewButton.Font = Button4.Font
        'NewButton.Anchor = Button4.Anchor
        NewButton.Tag = Path
        NewButton.Text = folderinfo.Name
        FlowLayoutPanel1.Controls.Add(NewButton)
        AddHandler NewButton.Click, AddressOf ClickSubForListedFolders
    End Sub

    Private Sub ClickSubForListedFolders(sender As Object, e As EventArgs)
        PathHistory.Add(CurrentPath)
        Dim btn As Button = CType(sender, Button)
        TextBox1.Text = btn.Tag
        CurrentPath = btn.Tag
        LoadFiles()
    End Sub

    Private Sub LoadAllDirectories(parentNode As TreeNode)
        Dim folderPath As String = parentNode.Tag.ToString()



        Try
            For Each dir As String In IO.Directory.GetDirectories(folderPath)
                Dim folderName As String = IO.Path.GetFileName(dir)

                ' Skip hidden folders
                'If hiddenFolders.Any(Function(h) h.Equals(folderName, StringComparison.OrdinalIgnoreCase)) Then
                '    Continue For
                'End If

                Dim dirNode As New TreeNode(folderName)
                dirNode.Tag = dir
                'TreeView1.Nodes.Add(dirNode)

                ' Recursively load subfolders
                'LoadAllDirectories(dirNode)
            Next
        Catch ex As Exception
            ' Ignore folders we can't access
        End Try
    End Sub

    Public Sub LoadFiles()
        ListView1.Items.Clear()
        Dim dir1 = CurrentPath
        Dim files() As System.IO.FileInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        files = dirinfo.GetFiles("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            Dim lvi As New ListViewItem(file.Name)
            lvi.SubItems.Add("File")
            lvi.SubItems.Add(file.Length.ToString())
            lvi.Tag = file.FullName ' store full path
            ListView1.Items.Add(lvi)
        Next
    End Sub

    Private Sub LoadFiles_Old(folderPath As String)
        ListView1.Items.Clear()
        Try
            For Each file As String In IO.Directory.GetFiles(folderPath)
                Dim fi As New IO.FileInfo(file)
                Dim lvi As New ListViewItem(fi.Name)

                lvi.SubItems.Add("File")
                lvi.SubItems.Add(fi.Length.ToString())
                lvi.Tag = fi.FullName ' store full path
                ListView1.Items.Add(lvi)
            Next
        Catch ex As Exception
            ' Ignore access errors
        End Try
    End Sub
End Class
