Imports System.Windows.Forms
Public Class TryExplorer
    'Public CreatedTabList As New List(Of TabButton)
    Public TabThatExist As Int64 = 0


    Public Sub NewTab(Optional Path As String = "")
        Dim ANewTabButton As New TabButton
        Dim NewExplorer As New Explorer
        If Path = "" Then
            Path = Main.Controller.GetUserFolder()
        End If
        NewExplorer.CurrentPath = Path
        ANewTabButton.Tag = NewExplorer
        NewExplorer.Tag = ANewTabButton

        FlowLayoutPanel1.Controls.Add(ANewTabButton)

        TabThatExist = TabThatExist + 1

        ANewTabButton.Button2.PerformClick()
    End Sub

    Public Sub AddTabUserControl(explorer As Explorer)
        Panel2.Controls.Clear()
        Panel2.Controls.Add(explorer)
        explorer.Dock = DockStyle.Fill
        explorer.BringToFront()
    End Sub

    Private Sub NewTabButton_Click(sender As Object, e As EventArgs) Handles NewTabButton.Click
        NewTab()
    End Sub

    Private Sub TryExplorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Main.Controller.SetOrGetArguments() = "" Then
            NewTab(Main.Controller.SetOrGetArguments())
        Else
            NewTab()
        End If
        Timer1.Start()
    End Sub

    Private Sub FlowLayoutPanel1_ControlAdded(sender As Object, e As Windows.Forms.ControlEventArgs) Handles FlowLayoutPanel1.ControlAdded
        For Each Btn As Control In FlowLayoutPanel1.Controls
            If Btn.Name = "NewTabButton" Then
                FlowLayoutPanel1.Controls.SetChildIndex(NewTabButton, FlowLayoutPanel1.Controls.Count)
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TabThatExist = 0 Then

            If My.Application.Info.Version.Revision > 300 Then
                Main.Controller.CloseApp(Me)
            Else
            End If
        End If
    End Sub
End Class