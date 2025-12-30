Imports System.Windows.Forms
Imports System.Drawing

Public Class PCContentMenu_NoneApp

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Public Sub AddItemToMenu(NameItem As String, TextItem As String, YourCode As Action)
        Dim NewButton As New Button
        NewButton.Name = NameItem
        NewButton.FlatStyle = FlatStyle.Flat
        NewButton.BackColor = Color.DarkGray
        NewButton.Text = TextItem

        If FlowLayoutPanel1.Controls.Count = 1 Then
        Else
            MyControllerForm.PCC.Size = New Size(MyControllerForm.PCC.Size.Width, MyControllerForm.PCC.Size.Height + 47)
        End If

        FlowLayoutPanel1.Controls.Add(NewButton)
        NewButton.Font = Button1.Font
        NewButton.Size = Button1.Size

        NewButton.Tag = YourCode

        AddHandler NewButton.Click, AddressOf PluginButton_Click
        'NewButton.Font = New Font("Trebuchet MS", "14,25pt")
        'AddHandler NewButton.Click, 

    End Sub

    Private Sub PluginButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim action As Action = CType(btn.Tag, Action)
        Try
            action?.Invoke()
            MyControllerForm.PCC.Visible = False
            MyControllerForm.IsPCCHere = False
        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadProgramButtons()
        AddItemToMenu("SettingsButton", "Settings", Sub()
                                                        Main.UI.RunApp("Settings")
                                                    End Sub)

        AddItemToMenu("Test1", "1", Sub()
                                        MsgBox("1")
                                    End Sub)

        AddItemToMenu("Test2", "2", Sub()
                                        MsgBox("2")
                                    End Sub)

        AddItemToMenu("Test3", "3", Sub()
                                        MsgBox("3")
                                    End Sub)
    End Sub

    Private Sub PCContentMenu_NoneApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProgramButtons()

    End Sub


End Class
