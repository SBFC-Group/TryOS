Public Class UUWApp
    Private Sub UUWApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UUWThings.HasBeenOpened = False Then
            UUWThings.HasBeenOpened = True
            UUWThings.SetupUUWUser()
            UUWThings.OpenUUW()
            Close()
        ElseIf UUWThings.HasBeenOpened = True Then
            UI.RunCommands("Loadjpg 1")
            Panel3.Visible = True
            Panel3.BackgroundImage = Form1.Panel1.BackgroundImage
            SetupPanel.BackColor = Color.FromArgb(55, Color.DarkGray)
            Timer1.Start()
            'If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LastVersion.setting") Then
            '    LastKnownVersionFromFile = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\LastVersion.setting")
            'Else
            '    'MsgBox("Error. File Updater doesn't know what the last known version was. Resettinging ""ShellName.setting""", MsgBoxStyle.Critical, "UUW")
            '    'MsgBox("Note From Dev: This will only show up if ""LastVersion.setting"" doesn't exist inside the main Settings Folder. But I'll allow you to continue because this is an alpha build.")
            '    'UUWThings.CloseUUW()
            'End If
        End If
    End Sub

    Public LastKnownVersionFromFile As String = ""

    Public ProgramVersion As String = My.Application.Info.Version.ToString

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Build0_1_0_282()
        'If LastKnownVersionFromFile = "0.1.0.255" Then
        'Build0_1_0_264()
        'elseIf LastKnownVersionFromFile = "" Then
        'Build0_1_0_264()
        'End If
    End Sub

    Private Sub Build0_1_0_264()

    End Sub

    Private Sub Build0_1_0_282()
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\SBFC Group", "UseOpenFramework", "1")
        If My.Computer.FileSystem.DirectoryExists(UI.AppsFolder) Then
        Else
            My.Computer.FileSystem.CreateDirectory(UI.AppsFolder)
            My.Computer.FileSystem.WriteAllBytes(My.Application.Info.DirectoryPath & "\TryOS_Store.tryapp", My.Resources.TryOS_Store, False)
            TryOS_Store_Manager.Class1.InstallTryOSApp(My.Application.Info.DirectoryPath & "\TryOS_Store.tryapp")
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\TryOS_Store.tryapp", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End If

        Dim dir1 = UI.UsersFolder
        Dim files() As System.IO.DirectoryInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            If My.Computer.FileSystem.DirectoryExists(file.FullName & "\Downloads") Then
                My.Computer.FileSystem.CreateDirectory(file.FullName & "\Downloads")
            End If
            If My.Computer.FileSystem.DirectoryExists(file.FullName & "\Pictures") Then
                My.Computer.FileSystem.CreateDirectory(file.FullName & "\Pictures")
            End If
        Next

        'Closes UUW and restarts program
        UUWThings.CloseUUW()
    End Sub
End Class