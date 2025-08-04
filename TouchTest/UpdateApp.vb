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
        Process.Start(My.Application.Info.DirectoryPath & "\TryOSUpdateWindow.exe")
        UI.RunCommands("end")
    End Sub
End Class
