Imports System.Windows.Forms

Public Class DeleteUserDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub DeleteUserDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeDesign(Main.Controller.IsDarkMode())
    End Sub

    Private ColorMode As String = "Normal"

    Private Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Panel1.BackColor = Drawing.Color.Gray
            OK_Button.BackColor = Drawing.Color.DarkGray
            Cancel_Button.BackColor = Drawing.Color.DarkGray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Panel1.BackColor = Drawing.Color.DarkGray
            OK_Button.BackColor = Drawing.Color.Gainsboro
            Cancel_Button.BackColor = Drawing.Color.Gainsboro
        End If
    End Sub
End Class
