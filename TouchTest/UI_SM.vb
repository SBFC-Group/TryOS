Public Class UI_SM
    Public IsCoreIDSet As Boolean = False
    Public LogonID As Int64
    Public DoesOldGUIWork As Boolean

    Public Overridable Overloads Sub Show()
        Return
    End Sub

    Public Overridable Overloads Sub Close()
        Return
    End Sub

    Private Sub UI_SM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class