Imports System.Windows.Forms

Public Class SettingsForm
    Public ThemeApp As ThemeApp
    Public InfoApp As InfoApp
    Public UserSettingsApp As UserSettings

    Public DisabledButton As Button

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ThemeButton.Click
        'theme
        If DisabledButton IsNot Nothing Then
            DisabledButton.Enabled = True
        End If
        DisabledButton = ThemeButton
        ThemeButton.Enabled = False
        SettingsPanel.Controls.Clear()
        If ThemeApp IsNot Nothing Then
        Else
            ThemeApp = New ThemeApp
        End If
        SettingsPanel.Controls.Add(ThemeApp)
        ThemeApp.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles InfoButton.Click
        'info
        If DisabledButton IsNot Nothing Then
            DisabledButton.Enabled = True
        End If
        DisabledButton = InfoButton
        InfoButton.Enabled = False
        SettingsPanel.Controls.Clear()
        If InfoApp IsNot Nothing Then
        Else
            InfoApp = New InfoApp
        End If
        SettingsPanel.Controls.Add(InfoApp)
        InfoApp.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Private Sub UserSettingsButton_Click(sender As Object, e As EventArgs) Handles UserSettingsButton.Click
        'user settings
        If DisabledButton IsNot Nothing Then
            DisabledButton.Enabled = True
        End If
        DisabledButton = UserSettingsButton
        UserSettingsButton.Enabled = False
        SettingsPanel.Controls.Clear()
        If UserSettingsApp IsNot Nothing Then
        Else
            UserSettingsApp = New UserSettings
        End If
        SettingsPanel.Controls.Add(UserSettingsApp)
        UserSettingsApp.Dock = Windows.Forms.DockStyle.Fill
    End Sub
End Class