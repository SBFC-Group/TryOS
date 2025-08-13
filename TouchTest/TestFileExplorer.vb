Imports System.IO

Public Class TestFileExplorer
    Public rootPath As String = Application.StartupPath

    ' List of folder names to hide (case-insensitive)
    Private hiddenFolders As New List(Of String) From {
        "runtimes", "Settings", "Languages", "TouchTest.exe.WebView2"
    }

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup ListView
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("Name", 250)
        ListView1.Columns.Add("Type", 100)
        ListView1.Columns.Add("Size", 100)

        ' Create root node
        Dim rootNode As New TreeNode(Path.GetFileName(rootPath))
        rootNode.Tag = rootPath
        TreeView1.Nodes.Add(rootNode)

        ' Load everything but hide restricted folders
        LoadAllDirectories(rootNode)
    End Sub

    Private Sub LoadAllDirectories(parentNode As TreeNode)
        Dim folderPath As String = parentNode.Tag.ToString()

        Try
            For Each dir As String In Directory.GetDirectories(folderPath)
                Dim folderName As String = Path.GetFileName(dir)

                ' Skip hidden folders
                If hiddenFolders.Any(Function(h) h.Equals(folderName, StringComparison.OrdinalIgnoreCase)) Then
                    Continue For
                End If

                Dim dirNode As New TreeNode(folderName)
                dirNode.Tag = dir
                parentNode.Nodes.Add(dirNode)

                ' Recursively load subfolders
                LoadAllDirectories(dirNode)
            Next
        Catch ex As Exception
            ' Ignore folders we can't access
        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim folderPath As String = e.Node.Tag.ToString()
        LoadFiles(folderPath)
    End Sub

    Private Sub LoadFiles(folderPath As String)
        ListView1.Items.Clear()
        Try
            For Each file As String In Directory.GetFiles(folderPath)
                Dim fi As New FileInfo(file)
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

    Private Sub ListView1_ItemActivate(sender As Object, e As EventArgs) Handles ListView1.ItemActivate
        ' When double-click or Enter is pressed
        If ListView1.SelectedItems.Count > 0 Then
            Dim filePath As String = ListView1.SelectedItems(0).Tag.ToString()
            If filePath.EndsWith(".swnote") Then

            Else
                Try
                    Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
                Catch ex As Exception
                    MessageBox.Show("Cannot open file: " & ex.Message)
                End Try
            End If
        End If
    End Sub
End Class