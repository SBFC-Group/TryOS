Imports System.Windows.Forms

Public Class TaskInteracter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Main.Form1.UseNewerAppViewer = True Then
            Dim AppInt As Int64 = Main.UI.RunCommands("GetAppIndex", Main.TryController.Resuteg(Main.TryController.CoreID))

            If Environment.CommandLine.Contains("/DevMode") = True Then
                Main.TryController.DebugManager.WriteLine("Closing App Index: " & AppInt)
            End If

            Dim tempapplist As List(Of Form) = Main.UI.RunCommands("GetAppList", Main.TryController.Resuteg(Main.TryController.CoreID))

            Dim tempform As Form

            Try
                tempform = tempapplist.Item(AppInt)
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    Main.TryController.DebugManager.WriteLine(ex.Message)
                End If
                Return
            End Try

            If tempform.Equals(Main.Form1.currentForm) = False Then
                Return
            End If

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
            Main.Controller.OpenFramework_SetNewFlowLayoutPanel(FlowLayoutPanel1)

            Main.Controller.OpenFramework_SetAppNameValue("")

            Main.Controller.OpenFramework_LoadApps()

            Main.Controller.OpenFramework_RestoreButtonOrder(True, FlowLayoutPanel1)
        End If

        ResetHandlersOrAddHandlers()
    End Sub

    Private Sub UpdateAppList_Tick(sender As Object, e As EventArgs) Handles UpdateAppList.Tick

    End Sub
End Class
