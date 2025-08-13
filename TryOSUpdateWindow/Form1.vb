Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class Form1
    Public InstallPath As String = "https://github.com/sebastian2007bro/TryOS/releases/download/TryOS_0.1.0.245/TryOS_0.1.0.245.zip"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Checks if "LogonWallpaper.setting" exists in Settings Folder
        If My.Computer.FileSystem.FileExists(UI.SettingsFolder & "\LogonWallpaper.setting") Then
            'Gets the data thats inside "LogonWallpaper.setting"
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(UI.SettingsFolder & "\LogonWallpaper.setting")
            Try
                My.Computer.FileSystem.CopyFile(UI.WallpaperFolder & "\" & Reader, My.Application.Info.DirectoryPath & "\Wallpaper.jpg")
                'Loads the wallpaper file name thats contained inside "LogonWallpaper.setting"
                PictureBox1.Load(My.Application.Info.DirectoryPath & "\Wallpaper.jpg")
            Catch ex As Exception
                PictureBox1.BackColor = Color.DarkGray
            End Try
        Else
            Try
                My.Computer.FileSystem.CopyFile(UI.WallpaperFolder & "\Wallpaper_1.jpg", My.Application.Info.DirectoryPath & "\Wallpaper.jpg")

                'Just loads "Wallpaper_1.jpg" thats inside Wallpapers Folder
                PictureBox1.Load(My.Application.Info.DirectoryPath & "\Wallpaper.jpg")
            Catch ex As Exception
                PictureBox1.BackColor = Color.DarkGray
            End Try
        End If

        Try
            Dim sd As String = ""
            Dim your_mom As New Net.WebClient
            your_mom.DownloadFile("https://raw.githubusercontent.com/sebastian2007bro/TryOSInstaller/refs/heads/main/UpdateData/UpdateURL.txt", My.Application.Info.DirectoryPath & "\Version")
            sd = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Version")
            If sd.Contains("https://github.com/sebastian2007bro/TryOS/releases/download") = True Then
                InstallPath = sd
            End If
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Version")
        Catch ex As Exception
            MsgBox("Is Internet working?")
        End Try
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            Label2.Text = "Info: Done. Starting TryOS in 5 seconds."
            Timer2.Start()
        Else
            ProgressBar1.Increment(1)

            If ProgressBar1.Value = 20 Then
                Label2.Text = "Info: Downloading Zip."
                Try
                    Dim your_mom As New Net.WebClient
                    your_mom.DownloadFile(InstallPath, "TryOSZip.zip")
                Catch ex As Exception

                End Try
                If My.Computer.FileSystem.FileExists("TryOSZip.zip") Then

                Else
                    Label2.Text = "Info: Trying to Download the Zip again."
                    ProgressBar1.Value = 0
                    Exit Sub
                End If

            ElseIf ProgressBar1.Value = 30 Then
                Label2.Text = "Info: Creating ""UpdateFiles"" Directory."
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\UpdateFiles")
            ElseIf ProgressBar1.Value = 40 Then
                Label2.Text = "Info: Extracting Zip To ""UpdateFiles""."
                If My.Computer.FileSystem.FileExists("TryOSZip.zip") Then
                    IO.Compression.ZipFile.ExtractToDirectory("TryOSZip.zip", My.Application.Info.DirectoryPath & "\UpdateFiles")
                Else
                    MsgBox("This Failed")
                    Exit Sub
                End If
            ElseIf ProgressBar1.Value = 50 Then
                Label2.Text = "Info: Renaming TryOS.exe to TryOS.bak"
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\TryOS.exe", "TryOS.bak")
            ElseIf ProgressBar1.Value = 52 Then
                Label2.Text = "Info: Renaming AxInterop.WMPLib.dll to AxInterop.WMPLib.bak"
                Try
                    My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\AxInterop.WMPLib.dll", "AxInterop.WMPLib.bak")
                Catch ex As Exception

                End Try
            ElseIf ProgressBar1.Value = 54 Then
                Label2.Text = "Info: Renaming Interop.WMPLib.dll to Interop.WMPLib.bak"
                Try
                    My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Interop.WMPLib.dll", "Interop.WMPLib.bak")
                Catch ex As Exception

                End Try
            ElseIf ProgressBar1.Value = 56 Then
                Label2.Text = "Info: Renaming Microsoft.Web.WebView2.Core.dll to Microsoft.Web.WebView2.Core.bak"
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.Core.dll", "Microsoft.Web.WebView2.Core.bak")
            ElseIf ProgressBar1.Value = 58 Then
                Label2.Text = "Info: Renaming Microsoft.Web.WebView2.WinForms.dll to Microsoft.Web.WebView2.WinForms.bak"
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.WinForms.dll", "Microsoft.Web.WebView2.WinForms.bak")
            ElseIf ProgressBar1.Value = 60 Then
                Label2.Text = "Info: Renaming Microsoft.Web.WebView2.Wpf.dll to Microsoft.Web.WebView2.Wpf.bak"
                My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.Wpf.dll", "Microsoft.Web.WebView2.Wpf.bak")
            ElseIf ProgressBar1.Value = 70 Then
                Label2.Text = "Info: Renaming ""Wallpapers"" folder to ""Wallpapers.bak"""
                My.Computer.FileSystem.RenameDirectory(My.Application.Info.DirectoryPath & "\Wallpapers", "Wallpapers.bak")
            ElseIf ProgressBar1.Value = 72 Then
                Label2.Text = "Info: Renaming ""runtimes"" folder to ""runtimes.bak"""
                My.Computer.FileSystem.RenameDirectory(My.Application.Info.DirectoryPath & "\runtimes", "runtimes.bak")
            ElseIf ProgressBar1.Value = 76 Then
                Label2.Text = "Info: Moving the new ""Wallpapers"" folder into main folder"
                My.Computer.FileSystem.MoveDirectory(My.Application.Info.DirectoryPath & "\UpdateFiles\Wallpapers", My.Application.Info.DirectoryPath & "\Wallpapers")
            ElseIf ProgressBar1.Value = 78 Then
                Label2.Text = "Info: Moving the new ""runtimes"" folder into main folder"
                My.Computer.FileSystem.MoveDirectory(My.Application.Info.DirectoryPath & "\UpdateFiles\runtimes", My.Application.Info.DirectoryPath & "\runtimes")
            ElseIf ProgressBar1.Value = 82 Then
                Label2.Text = "Info: Moving the new ""AxInterop.WMPLib.dll"" into main folder"
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\UpdateFiles\AxInterop.WMPLib.dll", My.Application.Info.DirectoryPath & "\AxInterop.WMPLib.dll")
            ElseIf ProgressBar1.Value = 84 Then
                Label2.Text = "Info: Moving the new ""Interop.WMPLib.dll"" into main folder"
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\UpdateFiles\Interop.WMPLib.dll", My.Application.Info.DirectoryPath & "\Interop.WMPLib.dll")
            ElseIf ProgressBar1.Value = 86 Then
                Label2.Text = "Info: Moving the new ""Microsoft.Web.WebView2.Core.dll"" into main folder"
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\UpdateFiles\Microsoft.Web.WebView2.Core.dll", My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.Core.dll")
            ElseIf ProgressBar1.Value = 88 Then
                Label2.Text = "Info: Moving the new ""Microsoft.Web.WebView2.WinForms.dll"" into main folder"
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\UpdateFiles\Microsoft.Web.WebView2.WinForms.dll", My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.WinForms.dll")
            ElseIf ProgressBar1.Value = 90 Then
                Label2.Text = "Info: Moving the new ""Microsoft.Web.WebView2.Wpf.dll"" into main folder"
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\UpdateFiles\Microsoft.Web.WebView2.Wpf.dll", My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.Wpf.dll")
            ElseIf ProgressBar1.Value = 92 Then
                Label2.Text = "Info: Moving the new ""TryOS.exe"" into main folder"
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\UpdateFiles\TryOS.exe", My.Application.Info.DirectoryPath & "\TryOS.exe")
            ElseIf ProgressBar1.Value = 94 Then
                Label2.Text = "Info: Moving older files into UpdateFiles"
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\TryOS.bak", My.Application.Info.DirectoryPath & "\UpdateFiles\TryOS.exe")
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\AxInterop.WMPLib.bak", My.Application.Info.DirectoryPath & "\UpdateFiles\AxInterop.WMPLib.dll")
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\Interop.WMPLib.bak", My.Application.Info.DirectoryPath & "\UpdateFiles\Interop.WMPLib.dll")
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.Core.bak", My.Application.Info.DirectoryPath & "\UpdateFiles\Microsoft.Web.WebView2.Core.dll")
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.WinForms.bak", My.Application.Info.DirectoryPath & "\UpdateFiles\Microsoft.Web.WebView2.WinForms.dll")
                My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath & "\Microsoft.Web.WebView2.Wpf.bak", My.Application.Info.DirectoryPath & "\UpdateFiles\Microsoft.Web.WebView2.Wpf.dll")
                My.Computer.FileSystem.MoveDirectory(My.Application.Info.DirectoryPath & "\runtimes.bak", My.Application.Info.DirectoryPath & "\UpdateFiles\runtimes")
                My.Computer.FileSystem.MoveDirectory(My.Application.Info.DirectoryPath & "\Wallpapers.bak", My.Application.Info.DirectoryPath & "\UpdateFiles\Wallpapers")
            ElseIf ProgressBar1.Value = 96 Then
                Label2.Text = "Info: Updating ""ShellName.setting"" and deleting temp files."
                'My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\ShellName.setting", "TouchTest.UUWApp", False)
                My.Computer.FileSystem.DeleteDirectory(My.Application.Info.DirectoryPath & "\UpdateFiles\Settings", FileIO.DeleteDirectoryOption.DeleteAllContents, FileIO.RecycleOption.DeletePermanently)
            ElseIf ProgressBar1.Value = 98 Then
                Label2.Text = "Info: Renaming ""UpdateFiles"" to ""TryOSBackup"""
                My.Computer.FileSystem.RenameDirectory(My.Application.Info.DirectoryPath & "\UpdateFiles", "TryOSBackup")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Number As Int64 = 5
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Number = 0 Then
            Process.Start(My.Application.Info.DirectoryPath & "\TryOS.exe")
            Form2.Show()
        Else
            Label2.Text = "Info: Done. Starting TryOS in " & Number.ToString & " seconds"
            Number = Number - 1
        End If

    End Sub
End Class
