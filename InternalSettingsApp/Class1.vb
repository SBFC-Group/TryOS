Imports TouchTest

Public Class Class1
    Implements TouchTest.OpenFramework_Interface

    Private host As OpenFramework_Handler

    Public ReadOnly Property Name As String Implements OpenFramework_Interface.Name
        Get
            Return "Internal Settings App"
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
            Return My.Resources.InternalSettingsApp
        End Get
    End Property

    Public Sub Initialize(host As OpenFramework_UI_Handler) Implements OpenFramework_Interface.Initialize
        Me.host = host
    End Sub

    Public Function GetForm() As Windows.Forms.Form Implements OpenFramework_Interface.GetForm
        Return New SettingsForm
    End Function
End Class
