Imports System.Windows.Forms

Public Class Form55
    Public StorePage As StorePage = Nothing
    Public AppList As AppList = Nothing

    Private Sub Form55_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.ic_local_grocery_store_128_28460
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
End Class