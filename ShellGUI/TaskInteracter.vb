Public Class TaskInteracter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Controller.OpenFramework_SetAppNameValue("")
        Try
            Main.Form1.currentForm.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TaskInteracter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main.Controller.OpenFramework_SetNewFlowLayoutPanel(FlowLayoutPanel1)
        Main.Controller.OpenFramework_LoadApps()
        Main.Controller.OpenFramework_RestoreButtonOrder()
    End Sub
End Class