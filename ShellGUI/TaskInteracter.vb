Imports System.Windows.Forms

Public Class TaskInteracter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Main.Form1.currentForm.Close()
        Catch ex As Exception

        End Try
        If MyControllerForm.IsPCCHere = True Then
            MyControllerForm.PCC.Visible = True
        End If
        If Main.Form1.IsSettingOpen = True Then
            Main.Form1.IsSettingOpen = False
        End If
        Main.Controller.OpenFramework_SetAppNameValue("")
    End Sub

    Private Sub ResetHandlersOrAddHandlers()
        For Each c As Control In FlowLayoutPanel1.Controls
            RemoveHandler c.Click, AddressOf CloseContextMenuForButtons

            AddHandler c.Click, AddressOf CloseContextMenuForButtons
        Next
    End Sub

    Private Sub CloseContextMenuForButtons(sender As Object, e As EventArgs)
        MyControllerForm.PCC.Visible = False
    End Sub

    Private Sub TaskInteracter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main.Controller.OpenFramework_SetNewFlowLayoutPanel(FlowLayoutPanel1)

        Main.Controller.OpenFramework_SetAppNameValue("")

        Main.Controller.OpenFramework_LoadApps()

        Main.Controller.OpenFramework_RestoreButtonOrder(True, FlowLayoutPanel1)

        ResetHandlersOrAddHandlers()
    End Sub
End Class
