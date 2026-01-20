Public Class TabButton
    Public ExplorerUserControl As Explorer

    Private Sub TabButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExplorerUserControl = Tag
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Main.TryExplorer.AddTabUserControl(ExplorerUserControl)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Application.Info.Version.Revision > 300 Then
            Me.Dispose()
            Main.TryExplorer.TabThatExist = Main.TryExplorer.TabThatExist - 1
        End If
    End Sub
End Class
