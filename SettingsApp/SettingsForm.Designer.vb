<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ThemeButton = New System.Windows.Forms.Button()
        Me.InfoButton = New System.Windows.Forms.Button()
        Me.SettingsPanel = New System.Windows.Forms.Panel()
        Me.UsreSettingsButton = New System.Windows.Forms.Button()
        Me.UpdateButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Silver
        Me.FlowLayoutPanel1.Controls.Add(Me.ThemeButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.InfoButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.UsreSettingsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.UpdateButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
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
        'SettingsPanel
        '
        Me.SettingsPanel.BackColor = System.Drawing.Color.DarkGray
        Me.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingsPanel.Location = New System.Drawing.Point(108, 0)
        Me.SettingsPanel.Name = "SettingsPanel"
        Me.SettingsPanel.Size = New System.Drawing.Size(1006, 659)
        Me.SettingsPanel.TabIndex = 1
        '
        'UsreSettingsButton
        '
        Me.UsreSettingsButton.BackgroundImage = CType(resources.GetObject("UsreSettingsButton.BackgroundImage"), System.Drawing.Image)
        Me.UsreSettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.UsreSettingsButton.FlatAppearance.BorderSize = 0
        Me.UsreSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UsreSettingsButton.Location = New System.Drawing.Point(3, 209)
        Me.UsreSettingsButton.Name = "UsreSettingsButton"
        Me.UsreSettingsButton.Size = New System.Drawing.Size(102, 97)
        Me.UsreSettingsButton.TabIndex = 2
        Me.UsreSettingsButton.UseVisualStyleBackColor = True
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
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(3, 415)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 97)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(3, 518)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 97)
        Me.Button2.TabIndex = 5
        Me.Button2.UseVisualStyleBackColor = True
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
    Friend WithEvents UsreSettingsButton As Windows.Forms.Button
    Friend WithEvents UpdateButton As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
End Class
