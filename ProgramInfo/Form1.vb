Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = "OS Name: " & Main.ProgramData.GetOSVersion() & "
OS Version: " & Main.ProgramData.GetOSVersion(True) & "
Program Version: " & Main.ProgramData.GetProgramVersion() & "
Username: " & Main.ProgramData.GetUsername() & "
Username Folder: " & Main.ProgramData.GetUserFolder()

    End Sub
End Class