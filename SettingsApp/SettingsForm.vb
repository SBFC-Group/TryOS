Imports System.Windows.Forms

Public Class SettingsForm
    Public ThemeApp As ThemeApp
    Public InfoApp As InfoApp
    Public UserSettingsApp As UserSettings
    Public UpdateApp As UpdateApp
    Public AdminToolsApp As AdminToolsApp
    Public DeviceInfoApp As DeviceInfoApp

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

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        'update
        If DisabledButton IsNot Nothing Then
            DisabledButton.Enabled = True
        End If
        DisabledButton = UpdateButton
        UpdateButton.Enabled = False
        SettingsPanel.Controls.Clear()
        If UpdateApp IsNot Nothing Then
        Else
            UpdateApp = New UpdateApp
        End If
        SettingsPanel.Controls.Add(UpdateApp)
        UpdateApp.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Private Sub AdministratorToolsButton_Click(sender As Object, e As EventArgs) Handles AdministratorToolsButton.Click
        'admin tools
        If Main.Controller.GetRole() = TouchTest.TryController.Roles.Administrator Then
        ElseIf Main.Controller.GetRole() = TouchTest.TryController.Roles.Program Then
        ElseIf Main.Controller.GetRole() = TouchTest.TryController.Roles.Developer Then
        Else
            Return
        End If

        If DisabledButton IsNot Nothing Then
            DisabledButton.Enabled = True
        End If
        DisabledButton = AdministratorToolsButton
        AdministratorToolsButton.Enabled = False
        SettingsPanel.Controls.Clear()
        If AdminToolsApp IsNot Nothing Then
        Else
            AdminToolsApp = New AdminToolsApp
        End If
        SettingsPanel.Controls.Add(AdminToolsApp)
        AdminToolsApp.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Private Sub DeviceInfoButton_Click(sender As Object, e As EventArgs) Handles DeviceInfoButton.Click
        'device info
        If DisabledButton IsNot Nothing Then
            DisabledButton.Enabled = True
        End If
        DisabledButton = DeviceInfoButton
        DeviceInfoButton.Enabled = False
        SettingsPanel.Controls.Clear()
        If DeviceInfoApp IsNot Nothing Then
        Else
            DeviceInfoApp = New DeviceInfoApp
        End If
        SettingsPanel.Controls.Add(DeviceInfoApp)
        DeviceInfoApp.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Main.Controller.GetRole() = TouchTest.TryController.Roles.Administrator Then
        ElseIf Main.Controller.GetRole() = TouchTest.TryController.Roles.Program Then
        ElseIf Main.Controller.GetRole() = TouchTest.TryController.Roles.Developer Then
        Else
            AdministratorToolsButton.Visible = False
        End If

        ChangeDesign(Main.Controller.IsDarkMode())

        Dim ShowButton7 As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\SBFC Group", "ShowDeviceInfoPage", Nothing)
        If ShowButton7 = "True" Then
            DeviceInfoButton.Visible = True
            DeviceInfoButton.Enabled = True
        ElseIf ShowButton7 = "False" Then
            DeviceInfoButton.Visible = False
            DeviceInfoButton.Enabled = False
        ElseIf ShowButton7 = "1" Then
            DeviceInfoButton.Visible = True
            DeviceInfoButton.Enabled = True
        ElseIf ShowButton7 = "0" Then
            DeviceInfoButton.Visible = False
            DeviceInfoButton.Enabled = False
        Else
            DeviceInfoButton.Visible = False
            DeviceInfoButton.Enabled = False
        End If
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
            FlowLayoutPanel1.BackColor = Drawing.Color.DimGray
            SettingsPanel.BackColor = Drawing.Color.Gray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            FlowLayoutPanel1.BackColor = Drawing.Color.Silver
            SettingsPanel.BackColor = Drawing.Color.DarkGray
        End If
    End Sub
End Class