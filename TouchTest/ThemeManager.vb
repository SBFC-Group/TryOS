Public Class ThemeManager
    Private AllowUserToDoAnything As Boolean = False

    Public Sub New(id As Int64)
        If id = TryController.CoreID Then AllowUserToDoAnything = True
    End Sub

    Private DarkModeAppMode As ThemeMode

    Public Enum ThemeMode
        Dark = 1
        Light = 2
        System = 3
        Custom = 4
    End Enum

    Public Sub SetThemeSetting(setting As String, arg As Object)
        If AllowUserToDoAnything = False Then Return

        If setting = "DarkThemeForApps" Then
            Try
                SetDarkThemeForApps(arg)
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    TryController.WriteToDebuggerOutput(ex.Message)
                End If
            End Try
        ElseIf setting = "DarkThemeForProgram" Then
            Try
                SetDarkThemeForProgram(arg)
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    TryController.WriteToDebuggerOutput(ex.Message)
                End If
            End Try
        End If
    End Sub

    Private Sub SetDarkThemeForApps(bool As ThemeMode)
        If bool = ThemeMode.Dark Then
            Form1.IsUsingDarkThemeForApps = True
        ElseIf bool = ThemeMode.Light Then
            Form1.IsUsingDarkThemeForApps = False
        ElseIf bool = ThemeMode.System Then
            Dim regeditlightordark As Int64 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", Nothing)
            If regeditlightordark = 0 Then
                Form1.IsUsingDarkThemeForApps = False
            ElseIf regeditlightordark = 1 Then
                Form1.IsUsingDarkThemeForApps = True
            End If
        End If

    End Sub

    Private Sub SetDarkThemeForProgram(bool As ThemeMode)
        If bool = ThemeMode.Dark Then
            Form1.IsUsingDarkThemeForPrograms = True
        ElseIf bool = ThemeMode.Light Then
            Form1.IsUsingDarkThemeForPrograms = False
        ElseIf bool = ThemeMode.System Then
            Dim regeditlightordark As Int64 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", Nothing)
            If regeditlightordark = 0 Then
                Form1.IsUsingDarkThemeForPrograms = False
            ElseIf regeditlightordark = 1 Then
                Form1.IsUsingDarkThemeForPrograms = True
            End If
        End If
    End Sub



End Class
