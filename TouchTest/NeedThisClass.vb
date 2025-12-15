Imports System.ComponentModel
Public Class NeedThisClass
    <Description("This is the Path to the Apps Folder.")>
    Public Property AppsFolder() As String
        Get
            Return UI.AppsFolder
        End Get
        Set(ByVal value As String)
            UI.AppsFolder = value
        End Set
    End Property

    <Description("This is the Path to the Settings Folder.")>
    Public Property SettingsFolder() As String
        Get
            Return UI.SettingsFolder
        End Get
        Set(ByVal value As String)
            UI.SettingsFolder = value
        End Set
    End Property

    <Description("This is the Path to the Wallpaper Folder.")>
    Public Property WallpaperFolder() As String
        Get
            Return UI.WallpaperFolder
        End Get
        Set(ByVal value As String)
            UI.WallpaperFolder = value
        End Set
    End Property

    <Description("This is the Path to the Users Folder.")>
    Public Property UsersFolder() As String
        Get
            Return UI.UsersFolder
        End Get
        Set(ByVal value As String)
            UI.UsersFolder = value
        End Set
    End Property

    <Description("This is the Path to the current User's Folder.")>
    Public Property UserFolder() As String
        Get
            Return UI.UserFolder
        End Get
        Set(ByVal value As String)
            UI.UserFolder = value
        End Set
    End Property

    <Description("This can disable OpenFramework")>
    Public Property DisableOpenFramework() As Boolean
        Get
            Return UI.DisableOpenFramework
        End Get
        Set(ByVal value As Boolean)
            UI.DisableOpenFramework = value
        End Set
    End Property

    <Description("This can disable CustomCode")>
    Public Property DisableCustomCode() As Boolean
        Get
            Return UI.DisableCustomCode
        End Get
        Set(ByVal value As Boolean)
            UI.DisableCustomCode = value
        End Set
    End Property

    <Description("This is used in LogonForm")>
    Public Property LogonBool() As Boolean
        Get
            Return UI.LogonBool
        End Get
        Set(ByVal value As Boolean)
            UI.LogonBool = value
        End Set
    End Property

    <Description("Used For Wallpaper")>
    Public Property GiveValuestoForm1() As Boolean
        Get
            Return UI.GiveValuestoForm1
        End Get
        Set(ByVal value As Boolean)
            UI.GiveValuestoForm1 = value
        End Set
    End Property

    <Description("Used For Wallpaper")>
    Public Property WallpaperNumber() As Integer
        Get
            Return UI.WallpaperNumber
        End Get
        Set(ByVal value As Integer)
            UI.WallpaperNumber = value
        End Set
    End Property

    <Description("Used For WIP Keyboard")>
    Public Property IsKeyboardEnabled() As Boolean
        Get
            Return UI.IsKeyboardEnabled
        End Get
        Set(ByVal value As Boolean)
            UI.IsKeyboardEnabled = value
        End Set
    End Property

    <Description("Was used for msgbox")>
    Public Property InfoForms_Info() As String
        Get
            Return UI.InfoForms_Info
        End Get
        Set(ByVal value As String)
            UI.InfoForms_Info = value
        End Set
    End Property
End Class
