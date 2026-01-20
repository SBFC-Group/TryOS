Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim TheRole As TouchTest.TryController.Roles

        If My.Application.Info.Version.Revision < 300 Or My.Application.Info.Version.Revision = 300 Then
            TheRole = Main.ProgramData.GetRole()
        Else
            TheRole = Main.ProgramData.RunCommand("whoami /nogui")
        End If


        Dim StringRole As String

        If TheRole = TouchTest.TryController.Roles.StandardSandbox Then
            StringRole = "StandardSandbox"
        ElseIf TheRole = TouchTest.TryController.Roles.Guest Then
            StringRole = "Guest"
        ElseIf TheRole = TouchTest.TryController.Roles.Standard Then
            StringRole = "Standard"
        ElseIf TheRole = TouchTest.TryController.Roles.Administrator Then
            StringRole = "Administrator"
        ElseIf TheRole = TouchTest.TryController.Roles.Program Then
            StringRole = "Program"
        ElseIf TheRole = TouchTest.TryController.Roles.Developer Then
            StringRole = "Developer"
        Else
            StringRole = "Unknown"
        End If

        Label1.Text = "OS Name: " & Main.ProgramData.GetOSVersion() & "
OS Version: " & Main.ProgramData.GetOSVersion(True) & "
Program Version: " & Main.ProgramData.GetProgramVersion() & "
Username: " & Main.ProgramData.GetUsername() & "
Username Folder: " & Main.ProgramData.GetUserFolder() & "
Role: " & StringRole



    End Sub
End Class