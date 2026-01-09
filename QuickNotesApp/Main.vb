Imports TouchTest
Imports System.Windows.Forms

Public Class Main
    Implements TouchTest.OpenFramework_Interface

    Public Shared _host As TouchTest.OpenFramework_Handler

    Public ReadOnly Property Name As String Implements OpenFramework_Interface.Name
        Get
            Return "QuickNotes"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements OpenFramework_Interface.Icon
        Get
            Return My.Resources.PictureBox1_Image
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
        Return New Form15
    End Function
End Class
