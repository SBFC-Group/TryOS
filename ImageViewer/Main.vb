Imports System.Drawing
Imports System.Windows.Forms
Imports TouchTest

Public Class Main
    Implements TouchTest.OpenFramework_Interface

    Public Shared Controller As New OpenFramework_Handler

    Public ReadOnly Property Name As String Implements OpenFramework_Interface.Name
        Get
            Return "Image Viewer"
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

    Public ReadOnly Property Icon As Image Implements OpenFramework_Interface.Icon
        Get
            Return My.Resources.Image_Viewer1
        End Get
    End Property

    Public Sub Initialize(host As OpenFramework_UI_Handler) Implements OpenFramework_Interface.Initialize
        Controller = host
    End Sub

    Public Function GetForm() As Form Implements OpenFramework_Interface.GetForm
        Return New Form40
    End Function
End Class
