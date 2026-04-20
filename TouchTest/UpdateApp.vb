Public Class UpdateApp
    Private TryRunOld As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsUpdateAvailable(TryController.GetVersion(), GetLatestVersion()) = True Then
            Button2.Visible = True
        End If


        Return

        'This code won't ever run. due to "Return"


        If TryRunOld = True Then
            Try
                Dim NewstVersion As String = ""
                Dim your_mom As New Net.WebClient
                your_mom.DownloadFile("https://raw.githubusercontent.com/sebastian2007bro/TryOSInstaller/refs/heads/main/UpdateData/NewstVersion.txt", My.Application.Info.DirectoryPath & "\Version")
                NewstVersion = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Version")
                Dim ProgramVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
                TextBox1.Text = My.Application.Info.Version.ToString
                TextBox2.Text = NewstVersion & "|" & ProgramVersion

                If NewstVersion.Contains(ProgramVersion) Then
                    Label3.Text = "Version: You're up to date"

                Else
                    Label3.Text = "Version: " & NewstVersion
                    'Dim Pointy1 As Int64 = Label3.Size.Width
                    'Pointy1 = Pointy1 + 20
                    'Button2.Location = New Point(Pointy1, Button2.Location.Y)
                    Button2.Visible = True
                End If

                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Version")
            Catch ex As Exception
                UI.ShowError("Is Internet working?")
                'MsgBox("Is Internet working?")
            End Try
        End If
    End Sub

    Private Sub UpdateApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Version: " & TryController.GetVersion
        Label3.Text = "Version: Not Checked"

        User = New UserManager(Form1.User.Username)

        If User.DoesSettingExist("ShowUpdatePopUp=True") = True Then
            ShowUpCheckbox.Checked = True
            PictureBox1.Visible = True
            TryOSBigUpdateButton.Visible = True
            TryOSBigUpdateButton.Enabled = True
        ElseIf User.DoesSettingExist("ShowUpdatePopUp=False") = True Then
            ShowUpCheckbox.Checked = False
            PictureBox1.Visible = False
            TryOSBigUpdateButton.Visible = False
            TryOSBigUpdateButton.Enabled = False
        Else
            User.AddSettingToUserSettings("ShowUpdatePopUp=True;")
            ShowUpCheckbox.Checked = True
            PictureBox1.Visible = True
            TryOSBigUpdateButton.Visible = True
            TryOSBigUpdateButton.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DownloadUpdate(GetLatestVersion()).Start()

        Return

        If TryRunOld = True Then
            Process.Start(My.Application.Info.DirectoryPath & "\TryOSUpdateWindow.exe")
            UI.RunCommands("end")
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Form1.IsUsingDarkThemeForApps = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Color.Gray
            Panel1.BackColor = Color.DarkGray
            Button1.BackColor = Color.Silver
            Button2.BackColor = Color.Silver
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray
            Panel1.BackColor = Color.Silver
            Button1.BackColor = Color.Gainsboro
            Button2.BackColor = Color.Gainsboro
        End If
    End Sub

    'Newer UpdateApp Code (from Uranium codebase)

    Private IsDevBuild As Boolean = False

    Public Branch As String

    Function IsUpdateAvailable(currentVersion As String, latestVersion As String) As Boolean
        latestVersion = latestVersion.Replace("https://github.com/sebastian2007bro/TryOS/releases/download/", "")
        latestVersion = latestVersion.Replace("Z_Dev_", "")
        latestVersion = latestVersion.Replace("TryOS_", "")
        latestVersion = latestVersion.Replace("TryOS.", "")
        Dim sl As String() = latestVersion.Split("/"c)
        Label3.Text = "Version: " & sl(0)
        Return New Version(sl(0)) > New Version(currentVersion)
    End Function

    Function GetLatestVersion() As String
        Try
            Dim client As New Net.WebClient()
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

    Async Function DownloadUpdate(url As String) As Task
        Try
            Dim client As New Net.WebClient()
            Dim zipPath As String = IO.Path.Combine(IO.Path.GetTempPath(), "update.zip")

            Await client.DownloadFileTaskAsync(New Uri(url), zipPath)

            LaunchUpdater(zipPath)

        Catch ex As Exception
            UI.ShowError("Download failed: " & ex.Message)
        End Try
    End Function

    Sub LaunchUpdater(zipFile As String)
        Dim currentApp As String = Application.ExecutablePath

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Settings\Updater.exe") = False Then
            My.Computer.FileSystem.WriteAllBytes(My.Application.Info.DirectoryPath & "\Settings\Updater.exe", My.Resources.Updater, False)
        End If

        Process.Start(My.Application.Info.DirectoryPath & "\Settings\Updater.exe", """" & currentApp & """ """ & zipFile & """")
        Application.Exit()
    End Sub

    'Post 1.1 (Uranium codebase) Update Code

    Private Sub TryOSBigUpdateButton_Click(sender As Object, e As EventArgs) Handles TryOSBigUpdateButton.Click
        Try
            Dim client As New Net.WebClient()

            DownloadUpdate(client.DownloadString("https://raw.githubusercontent.com/SBFC-Group/TryOS/refs/heads/Uranium_(1.1)/Z_NonDevVersion.txt").Trim()).Start()
        Catch ex As Exception
            If Environment.CommandLine.Contains("/DevMode") = True Then
                Debug.WriteLine(ex.Message)
            End If
        End Try
    End Sub

    Public User As UserManager

    Private Sub ShowUpCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowUpCheckbox.CheckedChanged
        If ShowUpCheckbox.Checked = True Then
            If User.DoesSettingExist("ShowUpdatePopUp=True;") = True Then
            ElseIf User.DoesSettingExist("ShowUpdatePopUp=False;") = True Then
                User.ReplaceSettingInUserSettings("ShowUpdatePopUp=False;", "ShowUpdatePopUp=True;")
            End If
            PictureBox1.Visible = True
            TryOSBigUpdateButton.Visible = True
            TryOSBigUpdateButton.Enabled = True
        ElseIf ShowUpCheckbox.Checked = False Then
            If User.DoesSettingExist("ShowUpdatePopUp=False;") = True Then
            ElseIf User.DoesSettingExist("ShowUpdatePopUp=True;") = True Then
                User.ReplaceSettingInUserSettings("ShowUpdatePopUp=True;", "ShowUpdatePopUp=False;")
            End If
            PictureBox1.Visible = False
            TryOSBigUpdateButton.Visible = False
            TryOSBigUpdateButton.Enabled = False
        End If
    End Sub
End Class
