Imports System.Drawing
Imports System.Windows.Forms
Imports TouchTest

Public Class Main
    Implements TouchTest.OpenFramework_Interface

    Public Shared Controller As OpenFramework_Handler

    Public ReadOnly Property Name As String Implements OpenFramework_Interface.Name
        Get
            Return "TryOS_Store"
        End Get
    End Property

    Public ReadOnly Property MajerVersion As Long Implements OpenFramework_Interface.MajerVersion
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property MinorVersion As Long Implements OpenFramework_Interface.MinorVersion
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property PatchVersion As Long Implements OpenFramework_Interface.PatchVersion
        Get
            Return 0
        End Get
    End Property

    Public ReadOnly Property Icon As Image Implements OpenFramework_Interface.Icon
        Get
            Return My.Resources.ic_local_grocery_store_128_284601
        End Get
    End Property

    Public Sub Initialize(host As OpenFramework_UI_Handler) Implements OpenFramework_Interface.Initialize
        Controller = host
    End Sub

    Public Function GetForm() As Form Implements OpenFramework_Interface.GetForm
        SetValueToVersion()
        Return New Form55
    End Function

    Public Shared VersionThing As Version

    Public Sub SetValueToVersion()
        VersionThing = New Version(MajerVersion, MinorVersion, PatchVersion, 0)
    End Sub
End Class
