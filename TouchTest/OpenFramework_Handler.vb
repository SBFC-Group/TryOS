Imports TouchTest

Public Class OpenFramework_Handler
    Implements OpenFramework_UI_Handler

    Public Sub EnableFullscreen(IsEnabled As Boolean) Implements OpenFramework_UI_Handler.EnableFullscreen
        UI.EnableFullAppMode(IsEnabled)
    End Sub

    Public Function RunCommand(Command As String, Optional TheForm As Object = Nothing) Implements OpenFramework_UI_Handler.RunCommand
        Return UI.RunCommands(Command, TheForm)
    End Function

    Public Sub ShowError() Implements OpenFramework_UI_Handler.ShowError
        UI.ShowError()
    End Sub

    Public Sub ShowError(Text As String) Implements OpenFramework_UI_Handler.ShowError
        UI.ShowError(Text)
    End Sub

    Public Sub ShowError(Text As String, Alert As ErrorMSGBox.Alerts) Implements OpenFramework_UI_Handler.ShowError
        UI.ShowError(Text, Alert)
    End Sub

    Public Sub StartCMD(Optional GG As String = "New") Implements OpenFramework_UI_Handler.StartCMD
        If GG = "NotNew" Then
            UI.StartCMD()
        End If
    End Sub

    Public Function GetProgramVersion() As String Implements OpenFramework_UI_Handler.GetProgramVersion
        Return TryController.GetVersion
    End Function

    Public Function GetOSVersion(Optional GetVersionNumber As Boolean = False) As String Implements OpenFramework_UI_Handler.GetOSVersion
        Return TryController.GetOSVersion(GetVersionNumber)
    End Function

    Public Function GetUsername() As String Implements OpenFramework_UI_Handler.GetUsername
        Return Form1.User.Username
    End Function

    Public Function GetUserFolder() As String Implements OpenFramework_UI_Handler.GetUserFolder
        Return Form1.User.UserFolderPath
    End Function

    Public Function GetRole() As String Implements OpenFramework_UI_Handler.GetRole
        Return Form1.User.Role
    End Function

    Public Function IsDarkMode() As Boolean Implements OpenFramework_UI_Handler.IsDarkMode
        If Form1.IsUsingDarkThemeForApps = True Then
            Return True
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            Return False
        Else
            Return False
        End If
    End Function

    Public Function SetOrGetArguments(Optional Arguments As String = Nothing) As String Implements OpenFramework_UI_Handler.SetOrGetArguments
        If Arguments IsNot Nothing Then
            Form1.ArgData = Arguments
            Return Arguments
        Else
            Return Form1.ArgData
        End If
    End Function

    Public Sub CloseApp(form As Form) Implements OpenFramework_UI_Handler.CloseApp
        form.Close()
        OpenFramework_Data.AppName = ""
    End Sub
End Class
