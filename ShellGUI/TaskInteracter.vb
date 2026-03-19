Imports System.Windows.Forms

Public Class TaskInteracter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Main.Form1.UseNewerAppViewer = True Then
            Dim AppInt As Int64 = Main.UI.RunCommands("GetAppIndex", Main.TryController.Resuteg())

            Debug.WriteLine("Closing App Index: " & AppInt)

            Dim tempapplist As List(Of Form) = Main.UI.RunCommands("GetAppList", Main.TryController.Resuteg())

            Dim tempform As Form = tempapplist.Item(AppInt)

            tempapplist.RemoveAt(AppInt)

            tempform.Close()

            If Main.Form1.OpenNewstAppAfterClosingAnApp = True Then
                Main.Form1.OpenAppAgain(tempapplist.Item(tempapplist.Count), tempapplist.Count)
            End If

            If MyControllerForm.IsPCCHere = True Then
                MyControllerForm.PCC.Visible = True
            End If
            If Main.Form1.IsSettingOpen = True Then
                Main.Form1.IsSettingOpen = False
            End If
            Main.Controller.OpenFramework_SetAppNameValue("")

            'Main.UI.ShowError("Currently this is disabled when the AppViewer is enabled.", TouchTest.ErrorMSGBox.Alerts.Information)
        Else
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
        End If

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
        If Main.UI.DisableOpenFramework = False Then

        End If
        Main.Controller.OpenFramework_SetNewFlowLayoutPanel(FlowLayoutPanel1)

        Main.Controller.OpenFramework_SetAppNameValue("")

        Main.Controller.OpenFramework_LoadApps()

        Main.Controller.OpenFramework_RestoreButtonOrder(True, FlowLayoutPanel1)

        ResetHandlersOrAddHandlers()
    End Sub

    Private Sub UpdateAppList_Tick(sender As Object, e As EventArgs) Handles UpdateAppList.Tick

    End Sub
End Class
