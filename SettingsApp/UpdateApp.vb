Imports System.Net
Imports System.Windows.Forms

Public Class UpdateApp
    Private IsDevBuild As Boolean = True



    Public Branch As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsUpdateAvailable(Main.Controller.GetProgramVersion(), GetLatestVersion()) = True Then
            Button2.Visible = True
        Else

        End If

    End Sub

    Function GetLatestVersion() As String
        Try
            Dim client As New WebClient()
            If IsDevBuild = True Then
                Return client.DownloadString("https://raw.githubusercontent.com/SBFC-Group/TryOS/refs/heads/" & Branch & "/Z_DevVersion.txt").Trim()
            Else
                Return client.DownloadString("https://raw.githubusercontent.com/SBFC-Group/TryOS/refs/heads/" & Branch & "/Z_NonDevVersion.txt").Trim()
            End If
        Catch ex As Exception
            If Environment.CommandLine.Contains("/DevMode") = True Then
                Debug.WriteLine(ex.Message)
            End If
            Return Nothing
        End Try
    End Function

    Function IsUpdateAvailable(currentVersion As String, latestVersion As String) As Boolean
        latestVersion = latestVersion.Replace("https://github.com/sebastian2007bro/TryOS/releases/download/", "")
        latestVersion = latestVersion.Replace("Z_Dev_", "")
        latestVersion = latestVersion.Replace("TryOS_", "")
        latestVersion = latestVersion.Replace("TryOS.", "")
        Dim sl As String() = latestVersion.Split("/"c)
        Label3.Text = "Version: " & sl(0)
        Return New Version(sl(0)) > New Version(currentVersion)
    End Function

    Private Sub UpdateApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Version: " & Main.Controller.GetProgramVersion()

        Branch = Main.Controller.RunCommand("GetBranch")
        Debug.WriteLine(Branch)
    End Sub

    Async Function DownloadUpdate(url As String) As Task
        Try
            Dim client As New WebClient()
            Dim zipPath As String = IO.Path.Combine(IO.Path.GetTempPath(), "update.zip")

            Await client.DownloadFileTaskAsync(New Uri(url), zipPath)

            LaunchUpdater(zipPath)

        Catch ex As Exception
            Main.Controller.ShowError("Download failed: " & ex.Message)
        End Try
    End Function

    Sub LaunchUpdater(zipFile As String)
        Dim currentApp As String = Application.ExecutablePath



        Process.Start(My.Application.Info.DirectoryPath & "\Settings\Updater.exe", """" & currentApp & """ """ & zipFile & """")
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DownloadUpdate(GetLatestVersion()).Start()
    End Sub
End Class
