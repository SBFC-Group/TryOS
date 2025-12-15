Imports TouchTest
Imports System.Windows.Forms

Public Class Class1
    Implements TouchTest.OpenFramework_Interface

    Public Shared _host As TouchTest.OpenFramework_Handler

    Public ReadOnly Property Name As String Implements OpenFramework_Interface.Name
        Get
            Return "Internet++"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements OpenFramework_Interface.Icon
        Get
            Return My.Resources.internet_world_wide_web_www_globe_communication_website_browser_network_connection_icon_195710
        End Get
    End Property

    Public ReadOnly Property MajerVersion As Int64 Implements OpenFramework_Interface.MajerVersion
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property MinorVersion As Int64 Implements OpenFramework_Interface.MinorVersion
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property PatchVersion As Int64 Implements OpenFramework_Interface.PatchVersion
        Get
            Return 0
        End Get
    End Property

    Public Sub Initialize(host As OpenFramework_UI_Handler) Implements OpenFramework_Interface.Initialize
        _host = host
    End Sub

    Public Function GetForm() As Windows.Forms.Form Implements OpenFramework_Interface.GetForm
        Return New TouchTest.Internetplusplus
    End Function
End Class
