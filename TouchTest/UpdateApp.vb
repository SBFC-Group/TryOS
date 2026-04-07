Public Class UpdateApp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    End Sub

    Private Sub UpdateApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Version: " & My.Application.Info.Version.ToString
        Label3.Text = "Version: Not Checked"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UI.ShowError("This updater is no longer used.")

        'Process.Start(My.Application.Info.DirectoryPath & "\TryOSUpdateWindow.exe")
        'UI.RunCommands("end", Form1.User)
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
End Class
