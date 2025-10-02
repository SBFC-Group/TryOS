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

            ElseIf RichTextBox1.Text.Contains("TestThis") = True Then
                TryOS_Store_Manager.Class1.PackageCreator(My.Application.Info.DirectoryPath & "\Apps\2_YoutubeApp", My.Application.Info.DirectoryPath & "\YoutubeApp.tryapp", "Youtube", TryController.GetVersion, "YoutubeApp.dll")
            ElseIf RichTextBox1.Text.Contains("TestMe") = True Then
                TryOS_Store_Manager.Class1.InstallTryOSApp(My.Application.Info.DirectoryPath & "\Internet++.tryapp")
            Else
                UI.RunCommands(RichTextBox1.Text, Me)
            End If
        End If
    End Sub
End Class