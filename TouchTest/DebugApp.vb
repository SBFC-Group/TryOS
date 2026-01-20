Public Class DebugApp
    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If RichTextBox1.Text.Contains("help") = True Then
                RichTextBox2.Text = "windowmode=mini - Trys to Minimize current app
exit - closes current app
end - Closes the program itself
run <shell object name> - Opens a shell program
start <form> - Starts a form
RunApp <form> - Starts a form inside the Shell Window
Loadjpg <number> - Loads a wallpaper with the jpg format
Loadpng <number> - Loads a wallpaper with the png format
Loadgif <number> - Loads a wallpaper with the gif format
RunUserControl <usercontrol> - Opens a form that will contain the UserControl"
            ElseIf RichTextBox1.Text.Contains("TestErrorBox") = True Then
                UI.ShowError("Hello World")
            ElseIf RichTextBox1.Text.Contains("TestStopWindow") = True Then
                UI.ShowStopWindow("Hello World")
            ElseIf RichTextBox1.Text.Contains("ShowProgramVersion") = True Then
                RichTextBox2.Text = My.Application.Info.Version.ToString
            ElseIf RichTextBox1.Text.Contains("TestThis") = True Then
                TryOS_Store_Manager.Class1.PackageCreator(My.Application.Info.DirectoryPath & "\app", My.Application.Info.DirectoryPath & "\App.tryapp", "App", TryController.GetVersion)
            ElseIf RichTextBox1.Text.Contains("TestMe") = True Then
                TryOS_Store_Manager.Class1.InstallTryOSApp(My.Application.Info.DirectoryPath & "\App.tryapp")
            ElseIf RichTextBox1.Text.Contains("Debug") = True Then
                D_e_b_u_g_Window.Show()
            Else
                UI.RunCommands(RichTextBox1.Text, Form1.User, Me)
            End If
        End If
    End Sub
End Class