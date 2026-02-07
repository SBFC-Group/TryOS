Public Class InstallTryOSApp
    Private Path As String = Nothing

    Public Sub New(Optional InstallerFilePath As String = Nothing)
        Path = InstallerFilePath

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Controller.RunCommand("installapp " & Path)
        Close()
    End Sub
End Class