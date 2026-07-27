Public Class DefaultAppClass
    Public ReadOnly FileExplorer As String
    Public ReadOnly WebBrowser As String
    Public ReadOnly TextEditor As String
    Public ReadOnly ImageViewer As String
    Public ReadOnly Notes As String

    Public Sub New(User As UserManager)
        If User.Contains("DefaultFileExplorer") = True Then
            FileExplorer = User.ReadSetting("DefaultFileExplorer")
        Else
            User.ChangeSetting(UserManager.SettingType.Add, "DefaultFileExplorer")
        End If
        If User.Contains("DefaultWebBrowser") = True Then
            WebBrowser = User.ReadSetting("DefaultWebBrowser")
        Else
            User.ChangeSetting(UserManager.SettingType.Add, "DefaultWebBrowser")
            Dim TempWebPath As String = Nothing
            If My.Computer.FileSystem.DirectoryExists(UI.AppsFolder & "\Internet++") Then
                If My.Computer.FileSystem.FileExists(UI.AppsFolder & "\Internet++\DllPath.txt") Then
                    TempWebPath = My.Computer.FileSystem.ReadAllText(UI.AppsFolder & "\Internet++\DllPath.txt")
                ElseIf My.Computer.FileSystem.FileExists(UI.AppsFolder & "\Internet++\Main.dll") Then
                    TempWebPath = UI.AppsFolder & "\Internet++\Main.dll"
                End If
            End If
            User.ChangeSetting(UserManager.SettingType.ChangeValue, "DefaultWebBrowser", TempWebPath)
        End If
        If User.Contains("DefaultTextEditor") = True Then
            FileExplorer = User.ReadSetting("DefaultTextEditor")
        Else
            User.ChangeSetting(UserManager.SettingType.Add, "DefaultTextEditor")
        End If
        If User.Contains("DefaultImageViewer") = True Then
            FileExplorer = User.ReadSetting("DefaultImageViewer")
        Else
            User.ChangeSetting(UserManager.SettingType.Add, "DefaultImageViewer")
        End If
        If User.Contains("DefaultNotes") = True Then
            FileExplorer = User.ReadSetting("DefaultNotes")
        Else
            User.ChangeSetting(UserManager.SettingType.Add, "DefaultNotes")
        End If
    End Sub
End Class
