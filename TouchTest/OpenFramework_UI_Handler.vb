Public Interface OpenFramework_UI_Handler
    Sub EnableFullscreen(IsEnabled As Boolean)
    Function RunCommand(Command As String, Optional TheForm As Object = Nothing)
    Sub ShowError()
    Sub ShowError(Text As String)
    Sub ShowError(Text As String, Alert As ErrorMSGBox.Alerts)
    Function GetProgramVersion() As String
    Function GetOpenFrameworkVersion() As String
    Function GetOSVersion(Optional GetVersionNumber As Boolean = False) As String
    Function GetUsername() As String
    Function GetUserFolder() As String
    Function GetRole() As TryController.Roles
    Function IsDarkMode() As Boolean
    Function ShowColorDialog() As Color
    Sub ClearArguments()
    Function SetOrGetArguments() As String
    Function SetOrGetArguments(Arg As String) As String
    Function GetAppPath() As String
    Sub StartCMD(Optional GG As String = "New")
    Sub CloseApp(form As Form)
End Interface
