Imports System.Windows.Forms

Public Class Form55
    Public StorePage As StorePage = Nothing
    Public AppList As AppList = Nothing

    Private Sub Form55_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.shopping_icon_2377731
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If StorePage IsNot Nothing Then
        Else
            StorePage = New StorePage
        End If
        StorePanel.Controls.Remove(AppList)
        StorePanel.Controls.Add(StorePage)
        StorePage.Dock = DockStyle.Fill
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If AppList IsNot Nothing Then
        Else
            AppList = New AppList
        End If
        StorePanel.Controls.Remove(StorePage)
        StorePanel.Controls.Add(AppList)
        AppList.Dock = DockStyle.Fill
    End Sub

    Private ColorMode As String = "Normal"

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Main.Controller.IsDarkMode() = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Main.Controller.IsDarkMode() = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            FlowLayoutPanel1.BackColor = Drawing.Color.Gray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            FlowLayoutPanel1.BackColor = Drawing.Color.Silver
        End If
    End Sub
End Class