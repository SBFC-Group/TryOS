<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ThemeButton = New System.Windows.Forms.Button()
        Me.InfoButton = New System.Windows.Forms.Button()
        Me.UserSettingsButton = New System.Windows.Forms.Button()
        Me.UpdateButton = New System.Windows.Forms.Button()
        Me.AdministratorToolsButton = New System.Windows.Forms.Button()
        Me.DeviceInfoButton = New System.Windows.Forms.Button()
        Me.SettingsPanel = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Silver
        Me.FlowLayoutPanel1.Controls.Add(Me.ThemeButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.InfoButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.UserSettingsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.UpdateButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.AdministratorToolsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.DeviceInfoButton)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(108, 659)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'ThemeButton
        '
        Me.ThemeButton.BackgroundImage = CType(resources.GetObject("ThemeButton.BackgroundImage"), System.Drawing.Image)
        Me.ThemeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ThemeButton.FlatAppearance.BorderSize = 0
        Me.ThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ThemeButton.Location = New System.Drawing.Point(3, 3)
        Me.ThemeButton.Name = "ThemeButton"
        Me.ThemeButton.Size = New System.Drawing.Size(102, 97)
        Me.ThemeButton.TabIndex = 0
        Me.ThemeButton.UseVisualStyleBackColor = True
        '
        'InfoButton
        '
        Me.InfoButton.BackgroundImage = CType(resources.GetObject("InfoButton.BackgroundImage"), System.Drawing.Image)
        Me.InfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.InfoButton.FlatAppearance.BorderSize = 0
        Me.InfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InfoButton.Location = New System.Drawing.Point(3, 106)
        Me.InfoButton.Name = "InfoButton"
        Me.InfoButton.Size = New System.Drawing.Size(102, 97)
        Me.InfoButton.TabIndex = 1
        Me.InfoButton.UseVisualStyleBackColor = True
        '
        'UserSettingsButton
        '
        Me.UserSettingsButton.BackgroundImage = CType(resources.GetObject("UserSettingsButton.BackgroundImage"), System.Drawing.Image)
        Me.UserSettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.UserSettingsButton.FlatAppearance.BorderSize = 0
        Me.UserSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UserSettingsButton.Location = New System.Drawing.Point(3, 209)
        Me.UserSettingsButton.Name = "UserSettingsButton"
        Me.UserSettingsButton.Size = New System.Drawing.Size(102, 97)
        Me.UserSettingsButton.TabIndex = 2
        Me.UserSettingsButton.UseVisualStyleBackColor = True
        '
        'UpdateButton
        '
        Me.UpdateButton.BackgroundImage = CType(resources.GetObject("UpdateButton.BackgroundImage"), System.Drawing.Image)
        Me.UpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.UpdateButton.FlatAppearance.BorderSize = 0
        Me.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpdateButton.Location = New System.Drawing.Point(3, 312)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(102, 97)
        Me.UpdateButton.TabIndex = 3
        Me.UpdateButton.UseVisualStyleBackColor = True
        '
        'AdministratorToolsButton
        '
        Me.AdministratorToolsButton.BackgroundImage = CType(resources.GetObject("AdministratorToolsButton.BackgroundImage"), System.Drawing.Image)
        Me.AdministratorToolsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AdministratorToolsButton.FlatAppearance.BorderSize = 0
        Me.AdministratorToolsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AdministratorToolsButton.Location = New System.Drawing.Point(3, 415)
        Me.AdministratorToolsButton.Name = "AdministratorToolsButton"
        Me.AdministratorToolsButton.Size = New System.Drawing.Size(102, 97)
        Me.AdministratorToolsButton.TabIndex = 4
        Me.AdministratorToolsButton.UseVisualStyleBackColor = True
        '
        'DeviceInfoButton
        '
        Me.DeviceInfoButton.BackgroundImage = CType(resources.GetObject("DeviceInfoButton.BackgroundImage"), System.Drawing.Image)
        Me.DeviceInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.DeviceInfoButton.Enabled = False
        Me.DeviceInfoButton.FlatAppearance.BorderSize = 0
        Me.DeviceInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeviceInfoButton.Location = New System.Drawing.Point(3, 518)
        Me.DeviceInfoButton.Name = "DeviceInfoButton"
        Me.DeviceInfoButton.Size = New System.Drawing.Size(102, 97)
        Me.DeviceInfoButton.TabIndex = 5
        Me.DeviceInfoButton.UseVisualStyleBackColor = True
        Me.DeviceInfoButton.Visible = False
        '
        'SettingsPanel
        '
        Me.SettingsPanel.BackColor = System.Drawing.Color.DarkGray
        Me.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingsPanel.Location = New System.Drawing.Point(108, 0)
        Me.SettingsPanel.Name = "SettingsPanel"
        Me.SettingsPanel.Size = New System.Drawing.Size(1006, 659)
        Me.SettingsPanel.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1114, 659)
        Me.Controls.Add(Me.SettingsPanel)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SettingsForm"
        Me.Text = "SettingsForm"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents ThemeButton As Windows.Forms.Button
    Friend WithEvents SettingsPanel As Windows.Forms.Panel
    Friend WithEvents InfoButton As Windows.Forms.Button
    Friend WithEvents UserSettingsButton As Windows.Forms.Button
    Friend WithEvents UpdateButton As Windows.Forms.Button
    Friend WithEvents AdministratorToolsButton As Windows.Forms.Button
    Friend WithEvents DeviceInfoButton As Windows.Forms.Button
    Friend WithEvents Timer1 As Windows.Forms.Timer
End Class
