Imports System.Windows.Forms
Imports System.Drawing

Public Class PCContentMenu_NoneApp

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Public Sub AddItemToMenu(NameItem As String, TextItem As String)
        Dim NewButton As New Button
        NewButton.Name = NameItem
        NewButton.FlatStyle = FlatStyle.Flat
        NewButton.BackColor = Color.DarkGray
        NewButton.Text = TextItem
        FlowLayoutPanel1.Controls.Add(NewButton)
        NewButton.Font = Button1.Font
        NewButton.Size = Button1.Size
        'NewButton.Font = New Font("Trebuchet MS", "14,25pt")
        'AddHandler NewButton.Click, Med
    End Sub



    Private Sub PCContentMenu_NoneApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddItemToMenu("MyName", "TestingButton")
    End Sub
End Class
