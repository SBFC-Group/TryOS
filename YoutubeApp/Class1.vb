Imports TouchTest
Imports System.Windows.Forms

Public Class Class1
    Implements TouchTest.OpenFramework_Interface

    Public Shared _host As TouchTest.OpenFramework_Handler

    Public ReadOnly Property Name As String Implements OpenFramework_Interface.Name
        Get
            Return "Youtube"
        End Get
    End Property

    Public ReadOnly Property MajerVersion As Long Implements OpenFramework_Interface.MajerVersion
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property MinorVersion As Long Implements OpenFramework_Interface.MinorVersion
        Get
            Return 0
        End Get
    End Property

    Public ReadOnly Property PatchVersion As Long Implements OpenFramework_Interface.PatchVersion
        Get
            Return 0
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements OpenFramework_Interface.Icon
        Get
            Return My.Resources.Youtube_icon_icons_com_66802
        End Get
    End Property

    Public Sub Initialize(host As OpenFramework_UI_Handler) Implements OpenFramework_Interface.Initialize
        _host = host
    End Sub

    Public Function GetForm() As Windows.Forms.Form Implements OpenFramework_Interface.GetForm
        Return New YoutubeApp
    End Function
End Class
