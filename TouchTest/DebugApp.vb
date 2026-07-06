Public Class DebugApp
    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If RichTextBox1.Text.Contains("help") = True Then
                RichTextBox2.Text = "exit - closes current app
end - Closes the program itself
run <shell object name> - Opens a shell program
start <form> - Starts a form
RunApp <form> - Starts a form inside the Shell Window
RunOpenFrameworkApp <filepath> - Opens a OpenFramework App from it's dll
Loadjpg <number> - Loads a wallpaper with the jpg format (don't work anymore)
Loadpng <number> - Loads a wallpaper with the png format (don't work anymore)
Loadgif <number> - Loads a wallpaper with the gif format (don't work anymore)
RunUserControl <usercontrol> - Opens a form that will contain the UserControl
windowmode=<normal/maxi/mini> - changes the WindowState of form that's currently connected to Command
installapp <filepath> - Installs an app from "".tryapp""
GetVersionObject - Gets the current version of the program
RefreshTaskInteracter - Refreshs the button point on TaskInteractor
ReloadTaskInteracter - Reloads the App buttons on the TaskInteractor
GetBranch - Gets the current branch
SetAppIndex <number> - Sets the AppIndex
GetAppIndex - Get the AppIndex value
GetAppList - Gets the AppList Object
SetWallpaper <filepath> - Sets the wallpaper from a image file (replaces Loadjpg, Loadpng and Loadgif)
GetWallpaper - Gets the current wallpaper image
Restore-TryOS-Store - Restores TryOS Store from internal .tryapp file"
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
            ElseIf RichTextBox1.Text.Contains("CreateProgramUser") = True Then
                Form1.User = New UserManager("Program")
                Form1.SandboxedUser = New UserManager("Program", True)
                Form1.User.LoadUserSettings()
            ElseIf RichTextBox1.Text.Contains("UImini-close=false") = True Then
                UI.MinimizeOrCloseCurrentOpenFrameworkApp(False)
            ElseIf RichTextBox1.Text.Contains("UImini-close=true") = True Then
                UI.MinimizeOrCloseCurrentOpenFrameworkApp(True)
            ElseIf RichTextBox1.Text.Contains("Noti1") = True Then
                UI.SaveCurrentNotifications()
            ElseIf RichTextBox1.Text.Contains("Noti2") = True Then
                UI.LoadNotifications()
            Else
                UI.RunCommands(RichTextBox1.Text, Form1.User, Me)
            End If
        End If
    End Sub
End Class