Imports System.ComponentModel
Public Class OpenFrameworkAppInformation
    Implements IDisposable

    Public ReadOnly Name As String
    Public ReadOnly AppPath As String
    Private OpenFramework_Button As Button
    Public ReadOnly OpenFramework_Interface As OpenFramework_Interface
    Public ReadOnly Version As Version

    Public Sub New(Name As String, AppPath As String, Version As Version, OpenFramework_Interface As OpenFramework_Interface)
        Me.Name = Name
        Me.AppPath = AppPath
        Me.Version = Version
        Me.OpenFramework_Interface = OpenFramework_Interface
    End Sub

    Public Sub SetButtonObject(b As Button, ProgramID As Int64)
        Dim user As UserManager = TryController.Resuteg(ProgramID)
        If user Is Nothing Then
            Return
        End If

        If user.Role = TryController.Roles.Program Then
            OpenFramework_Button = b
        End If
    End Sub

    Public Function GetButtonObject(ProgramID As Int64)
        Dim user As UserManager = TryController.Resuteg(ProgramID)
        If user Is Nothing Then
            Return Nothing
        End If

        If user.Role = TryController.Roles.Program Then
            Return OpenFramework_Button
        Else
            Return Nothing
        End If
    End Function

    Public Function GetForm() As Form
        Return OpenFramework_Interface.GetForm
    End Function

    Public Function GetIcon() As Image
        Return OpenFramework_Interface.Icon
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
