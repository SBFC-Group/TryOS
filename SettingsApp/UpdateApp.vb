Imports System.Net

Public Class UpdateApp
    Private IsDevBuild As Boolean = True

    Public Branch As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Function GetLatestVersion() As String
        Dim client As New WebClient()
        If IsDevBuild = True Then
            Return client.DownloadString("https://raw.githubusercontent.com/sebastian2007bro/TryOS/refs/heads/" & Branch & "/Z_DevVersion.txt").Trim()
        Else
            Return client.DownloadString("https://raw.githubusercontent.com/sebastian2007bro/TryOS/refs/heads/" & Branch & "/Z_NonDevVersion.txt").Trim()
        End If
    End Function

    Function IsUpdateAvailable(currentVersion As String, latestVersion As String) As Boolean
        Return New Version(latestVersion) > New Version(currentVersion)
    End Function

    Private Sub UpdateApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Branch = Main.Controller.RunCommand("GetBranch")
    End Sub
End Class
