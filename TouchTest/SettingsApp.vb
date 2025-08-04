Public Class SettingsApp


    Public ThemePanel As New ThemeApp
    Public UpdatePanel As New UpdateApp
    Public InfoPanel As New InfoApp
    Public UserPanel As New UserSettingsApp
    Public AdminPanel As New AdminSettings

    Public RoleLevel As TryController.Roles = Form1.GetRole()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Controls.Add(ThemePanel)
        ThemePanel.Dock = DockStyle.Fill
        Panel2.Controls.Remove(InfoPanel)
        Panel2.Controls.Remove(UserPanel)
        Panel2.Controls.Remove(UpdatePanel)
        Panel2.Controls.Remove(AdminPanel)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Controls.Add(InfoPanel)
        InfoPanel.Dock = DockStyle.Fill
        Panel2.Controls.Remove(ThemePanel)
        Panel2.Controls.Remove(UserPanel)
        Panel2.Controls.Remove(UpdatePanel)
        Panel2.Controls.Remove(AdminPanel)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Controls.Add(UserPanel)
        UserPanel.Dock = DockStyle.Fill
        Panel2.Controls.Remove(ThemePanel)
        Panel2.Controls.Remove(InfoPanel)
        Panel2.Controls.Remove(UpdatePanel)
        Panel2.Controls.Remove(AdminPanel)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        UI.RunCommands("Console>end")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If RoleLevel = TryController.Roles.Administrator Then
        ElseIf RoleLevel = TryController.Roles.Program Then
        ElseIf RoleLevel = TryController.Roles.Developer Then
        Else
            Exit Sub
        End If
        Panel2.Controls.Add(AdminPanel)
        AdminPanel.Dock = DockStyle.Fill
        Panel2.Controls.Remove(ThemePanel)
        Panel2.Controls.Remove(InfoPanel)
        Panel2.Controls.Remove(UserPanel)
        Panel2.Controls.Remove(UpdatePanel)
        'MsgBox("This Settings Page doesn't exist yet.", MsgBoxStyle.Information, "TryOS")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2.Controls.Add(UpdatePanel)
        UpdatePanel.Dock = DockStyle.Fill
        Panel2.Controls.Remove(ThemePanel)
        Panel2.Controls.Remove(InfoPanel)
        Panel2.Controls.Remove(UserPanel)
        Panel2.Controls.Remove(AdminPanel)
    End Sub

    Private IsHasChanged As Boolean = False
    Private ColorMode As String = "Normal"


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Form1.IsUsingDarkThemeForApps = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Panel1.BackColor = Color.DimGray
            Button1.BackColor = Color.DarkGray
            Button2.BackColor = Color.DarkGray
            Button3.BackColor = Color.DarkGray
            Button4.BackColor = Color.DarkGray
            Button5.BackColor = Color.DarkGray
            Button6.BackColor = Color.DarkGray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Panel1.BackColor = Color.Silver
            Button1.BackColor = Color.Gainsboro
            Button2.BackColor = Color.Gainsboro
            Button3.BackColor = Color.Gainsboro
            Button4.BackColor = Color.Gainsboro
            Button5.BackColor = Color.Gainsboro
            Button6.BackColor = Color.Gainsboro

        End If
    End Sub
End Class
