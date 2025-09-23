Imports TouchTest

Public Class OpenFramework_Handler
    Implements OpenFramework_UI_Handler

    Public Sub EnableFullscreen(IsEnabled As Boolean) Implements OpenFramework_UI_Handler.EnableFullscreen
        UI.EnableFullAppMode(IsEnabled)
    End Sub

    Public Sub RunCommand(Command As String, Optional TheForm As Object = Nothing) Implements OpenFramework_UI_Handler.RunCommand
        UI.RunCommands(Command, TheForm)
    End Sub

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
        Return Form1.Username
    End Function

    Public Function GetUserFolder() As String Implements OpenFramework_UI_Handler.GetUserFolder
        Return UI.UserFolder
    End Function

    Public Function GetRole() As String Implements OpenFramework_UI_Handler.GetRole
        Return Form1.GetRole()
    End Function
End Class
