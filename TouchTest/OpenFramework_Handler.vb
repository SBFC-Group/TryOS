Imports TouchTest

Public Class OpenFramework_Handler
    Implements OpenFramework_UI_Handler

    Public Sub EnableFullscreen(IsEnabled As Boolean) Implements OpenFramework_UI_Handler.EnableFullscreen
        UI.EnableFullAppMode(IsEnabled)
    End Sub

    Public Function RunCommand(Command As String, Optional TheForm As Object = Nothing) Implements OpenFramework_UI_Handler.RunCommand
        Return UI.RunCommands(Command, Form1.SandboxedUser, TheForm)
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

    Public Function GetOpenFrameworkVersion() As String Implements OpenFramework_UI_Handler.GetOpenFrameworkVersion
        Return OpenFramework_Data.OpenFramework.GetOpenFrameworkVersion()
    End Function

    Public Function GetOSVersion(Optional GetVersionNumber As Boolean = False) As String Implements OpenFramework_UI_Handler.GetOSVersion
        Return TryController.GetOSVersion(GetVersionNumber)
    End Function

    Public Function GetUsername() As String Implements OpenFramework_UI_Handler.GetUsername
        Return Form1.SandboxedUser.Username
    End Function

    Public Function GetUserFolder() As String Implements OpenFramework_UI_Handler.GetUserFolder
        Return Form1.SandboxedUser.UserFolderPath
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

    Public Sub ClearArguments() Implements OpenFramework_UI_Handler.ClearArguments
        Form1.ArgData = ""
    End Sub

    Public Function SetOrGetArguments() As String Implements OpenFramework_UI_Handler.SetOrGetArguments
        Return Form1.ArgData
    End Function

    Public Function SetOrGetArguments(Arguments As String) As String Implements OpenFramework_UI_Handler.SetOrGetArguments
        Form1.ArgData = Arguments
        Return Arguments
    End Function

    Public Sub CloseApp(form As Form) Implements OpenFramework_UI_Handler.CloseApp
        form.Close()
        OpenFramework_Data.OpenFramework.AppName = ""
        Try
            Form1.AppList.RemoveAt(Form1.AppList.IndexOf(form))
        Catch ex As Exception
            If Environment.CommandLine.Contains("/DevMode") = True Then
                Debug.WriteLine(ex.Message)
            End If
        End Try
    End Sub

    ''' <summary>This is here to allow newer apps to start on 1.1. But It doesn't do anything.</summary>
    Public Sub SendNotification(Title As String, Text As String, NotificationType As NotificationClass.NotificationType) Implements OpenFramework_UI_Handler.SendNotification
    End Sub

    ''' <summary>This is here to allow newer apps to start on 1.1. But It doesn't do anything.</summary>
    Public Sub CreateNewSetting(setting As String) Implements OpenFramework_UI_Handler.CreateNewSetting
    End Sub

    ''' <summary>This is here to allow newer apps to start on 1.1. But It doesn't do anything.</summary>
    Public Sub DeleteSetting(setting As String) Implements OpenFramework_UI_Handler.DeleteSetting
    End Sub

    ''' <summary>This is here to allow newer apps to start on 1.1. But It doesn't do anything.</summary>
    Public Sub RenameSetting(setting As String, NewName As String) Implements OpenFramework_UI_Handler.RenameSetting
    End Sub

    ''' <summary>This is here to allow newer apps to start on 1.1. But It doesn't do anything.</summary>
    Public Sub SetNewSettingValue(setting As String, value As String) Implements OpenFramework_UI_Handler.SetNewSettingValue
    End Sub

    ''' <summary>This is here to allow newer apps to start on 1.1. But It doesn't do anything.</summary>
    Public Function GetSettingValue(setting As String) As String Implements OpenFramework_UI_Handler.GetSettingValue
        Return Nothing
    End Function

    ''' <summary>This is here to allow newer apps to start on 1.1. But It doesn't do anything.</summary>
    Public Function ContainsSetting(setting As String) As Boolean Implements OpenFramework_UI_Handler.ContainsSetting
        Return Nothing
    End Function

    ''' <summary>This is here to allow newer apps to start on 1.1. But It doesn't do anything.</summary>
    Public Function GetAppPath() As String Implements OpenFramework_UI_Handler.GetAppPath
        Return Nothing
    End Function
End Class
