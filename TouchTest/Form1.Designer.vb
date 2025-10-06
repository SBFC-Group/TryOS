<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TimebarPanel = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VolumeButton = New System.Windows.Forms.Button()
        Me.WifiButton = New System.Windows.Forms.Button()
        Me.PowerButton = New System.Windows.Forms.Button()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.InternetPlusPlus = New System.Windows.Forms.Button()
        Me.QuickNotes = New System.Windows.Forms.Button()
        Me.YoutubeButton = New System.Windows.Forms.Button()
        Me.InstagramButton = New System.Windows.Forms.Button()
        Me.FacebookButton = New System.Windows.Forms.Button()
        Me.SpotifyButton = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DebugMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommanderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommanderWindowedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ApplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.EncodePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TimeAndDate = New System.Windows.Forms.Timer(Me.components)
        Me.VolumeList = New System.Windows.Forms.ImageList(Me.components)
        Me.InternetList = New System.Windows.Forms.ImageList(Me.components)
        Me.PowerList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TimebarPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.TouchTest.My.Resources.Resources.internet_world_wide_web_www_globe_communication_website_browser_network_connection_icon_1957101
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(593, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 57)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.TimebarPanel)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1243, 851)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.InternetPlusPlus)
        Me.Panel3.Controls.Add(Me.QuickNotes)
        Me.Panel3.Controls.Add(Me.SpotifyButton)
        Me.Panel3.Controls.Add(Me.YoutubeButton)
        Me.Panel3.Controls.Add(Me.FacebookButton)
        Me.Panel3.Controls.Add(Me.InstagramButton)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1243, 741)
        Me.Panel3.TabIndex = 2
        '
        'TimebarPanel
        '
        Me.TimebarPanel.BackColor = System.Drawing.Color.Silver
        Me.TimebarPanel.Controls.Add(Me.Button5)
        Me.TimebarPanel.Controls.Add(Me.Label1)
        Me.TimebarPanel.Controls.Add(Me.VolumeButton)
        Me.TimebarPanel.Controls.Add(Me.WifiButton)
        Me.TimebarPanel.Controls.Add(Me.PowerButton)
        Me.TimebarPanel.Controls.Add(Me.TimeLabel)
        Me.TimebarPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TimebarPanel.Location = New System.Drawing.Point(0, 0)
        Me.TimebarPanel.Name = "TimebarPanel"
        Me.TimebarPanel.Size = New System.Drawing.Size(1243, 36)
        Me.TimebarPanel.TabIndex = 6
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(118, 10)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(115, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Start TryOS Store"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1064, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'VolumeButton
        '
        Me.VolumeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VolumeButton.BackColor = System.Drawing.Color.Transparent
        Me.VolumeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.VolumeButton.FlatAppearance.BorderSize = 0
        Me.VolumeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.VolumeButton.Location = New System.Drawing.Point(1162, 0)
        Me.VolumeButton.Name = "VolumeButton"
        Me.VolumeButton.Size = New System.Drawing.Size(36, 36)
        Me.VolumeButton.TabIndex = 3
        Me.VolumeButton.UseVisualStyleBackColor = False
        Me.VolumeButton.Visible = False
        '
        'WifiButton
        '
        Me.WifiButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WifiButton.BackColor = System.Drawing.Color.Transparent
        Me.WifiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.WifiButton.FlatAppearance.BorderSize = 0
        Me.WifiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WifiButton.Location = New System.Drawing.Point(1120, 0)
        Me.WifiButton.Name = "WifiButton"
        Me.WifiButton.Size = New System.Drawing.Size(36, 36)
        Me.WifiButton.TabIndex = 2
        Me.WifiButton.UseVisualStyleBackColor = False
        Me.WifiButton.Visible = False
        '
        'PowerButton
        '
        Me.PowerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PowerButton.BackColor = System.Drawing.Color.Transparent
        Me.PowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PowerButton.FlatAppearance.BorderSize = 0
        Me.PowerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PowerButton.Location = New System.Drawing.Point(1204, 0)
        Me.PowerButton.Name = "PowerButton"
        Me.PowerButton.Size = New System.Drawing.Size(36, 36)
        Me.PowerButton.TabIndex = 1
        Me.PowerButton.UseVisualStyleBackColor = False
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.BackColor = System.Drawing.Color.Transparent
        Me.TimeLabel.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLabel.Location = New System.Drawing.Point(3, 4)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(109, 29)
        Me.TimeLabel.TabIndex = 0
        Me.TimeLabel.Text = "00:00:00"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Panel2.Location = New System.Drawing.Point(0, 777)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1243, 74)
        Me.Panel2.TabIndex = 1
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(1169, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(74, 74)
        Me.Button4.TabIndex = 3
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel4.Location = New System.Drawing.Point(76, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1091, 74)
        Me.Panel4.TabIndex = 3
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1091, 74)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'InternetPlusPlus
        '
        Me.InternetPlusPlus.BackColor = System.Drawing.Color.Transparent
        Me.InternetPlusPlus.BackgroundImage = CType(resources.GetObject("InternetPlusPlus.BackgroundImage"), System.Drawing.Image)
        Me.InternetPlusPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.InternetPlusPlus.FlatAppearance.BorderSize = 0
        Me.InternetPlusPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InternetPlusPlus.Location = New System.Drawing.Point(3, 665)
        Me.InternetPlusPlus.Name = "InternetPlusPlus"
        Me.InternetPlusPlus.Size = New System.Drawing.Size(74, 70)
        Me.InternetPlusPlus.TabIndex = 3
        Me.InternetPlusPlus.UseVisualStyleBackColor = False
        Me.InternetPlusPlus.Visible = False
        '
        'QuickNotes
        '
        Me.QuickNotes.BackColor = System.Drawing.Color.Transparent
        Me.QuickNotes.BackgroundImage = CType(resources.GetObject("QuickNotes.BackgroundImage"), System.Drawing.Image)
        Me.QuickNotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.QuickNotes.FlatAppearance.BorderSize = 0
        Me.QuickNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QuickNotes.Location = New System.Drawing.Point(83, 665)
        Me.QuickNotes.Name = "QuickNotes"
        Me.QuickNotes.Size = New System.Drawing.Size(74, 70)
        Me.QuickNotes.TabIndex = 4
        Me.QuickNotes.UseVisualStyleBackColor = False
        Me.QuickNotes.Visible = False
        '
        'YoutubeButton
        '
        Me.YoutubeButton.BackColor = System.Drawing.Color.Transparent
        Me.YoutubeButton.BackgroundImage = CType(resources.GetObject("YoutubeButton.BackgroundImage"), System.Drawing.Image)
        Me.YoutubeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.YoutubeButton.FlatAppearance.BorderSize = 0
        Me.YoutubeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.YoutubeButton.Location = New System.Drawing.Point(163, 665)
        Me.YoutubeButton.Name = "YoutubeButton"
        Me.YoutubeButton.Size = New System.Drawing.Size(74, 70)
        Me.YoutubeButton.TabIndex = 5
        Me.YoutubeButton.UseVisualStyleBackColor = False
        Me.YoutubeButton.Visible = False
        '
        'InstagramButton
        '
        Me.InstagramButton.BackColor = System.Drawing.Color.Transparent
        Me.InstagramButton.BackgroundImage = CType(resources.GetObject("InstagramButton.BackgroundImage"), System.Drawing.Image)
        Me.InstagramButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.InstagramButton.FlatAppearance.BorderSize = 0
        Me.InstagramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InstagramButton.Location = New System.Drawing.Point(243, 665)
        Me.InstagramButton.Name = "InstagramButton"
        Me.InstagramButton.Size = New System.Drawing.Size(74, 70)
        Me.InstagramButton.TabIndex = 6
        Me.InstagramButton.UseVisualStyleBackColor = False
        Me.InstagramButton.Visible = False
        '
        'FacebookButton
        '
        Me.FacebookButton.BackColor = System.Drawing.Color.Transparent
        Me.FacebookButton.BackgroundImage = CType(resources.GetObject("FacebookButton.BackgroundImage"), System.Drawing.Image)
        Me.FacebookButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FacebookButton.FlatAppearance.BorderSize = 0
        Me.FacebookButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FacebookButton.Location = New System.Drawing.Point(323, 665)
        Me.FacebookButton.Name = "FacebookButton"
        Me.FacebookButton.Size = New System.Drawing.Size(74, 70)
        Me.FacebookButton.TabIndex = 7
        Me.FacebookButton.UseVisualStyleBackColor = False
        Me.FacebookButton.Visible = False
        '
        'SpotifyButton
        '
        Me.SpotifyButton.BackColor = System.Drawing.Color.Transparent
        Me.SpotifyButton.BackgroundImage = CType(resources.GetObject("SpotifyButton.BackgroundImage"), System.Drawing.Image)
        Me.SpotifyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SpotifyButton.FlatAppearance.BorderSize = 0
        Me.SpotifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SpotifyButton.Location = New System.Drawing.Point(403, 665)
        Me.SpotifyButton.Name = "SpotifyButton"
        Me.SpotifyButton.Size = New System.Drawing.Size(74, 70)
        Me.SpotifyButton.TabIndex = 8
        Me.SpotifyButton.UseVisualStyleBackColor = False
        Me.SpotifyButton.Visible = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(3, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(71, 68)
        Me.Button3.TabIndex = 2
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.TouchTest.My.Resources.Resources.internet_world_wide_web_www_globe_communication_website_browser_network_connection_icon_1957101
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(657, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(58, 57)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DebugMenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1243, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'DebugMenuToolStripMenuItem
        '
        Me.DebugMenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommanderToolStripMenuItem, Me.CommanderWindowedToolStripMenuItem, Me.LoadConsoleToolStripMenuItem, Me.UserNameToolStripMenuItem, Me.PasswordToolStripMenuItem})
        Me.DebugMenuToolStripMenuItem.Name = "DebugMenuToolStripMenuItem"
        Me.DebugMenuToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.DebugMenuToolStripMenuItem.Text = "Debug Menu"
        '
        'CommanderToolStripMenuItem
        '
        Me.CommanderToolStripMenuItem.Name = "CommanderToolStripMenuItem"
        Me.CommanderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F10), System.Windows.Forms.Keys)
        Me.CommanderToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.CommanderToolStripMenuItem.Text = "Commander"
        '
        'CommanderWindowedToolStripMenuItem
        '
        Me.CommanderWindowedToolStripMenuItem.Name = "CommanderWindowedToolStripMenuItem"
        Me.CommanderWindowedToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.F10), System.Windows.Forms.Keys)
        Me.CommanderWindowedToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.CommanderWindowedToolStripMenuItem.Text = "Commander Windowed"
        '
        'LoadConsoleToolStripMenuItem
        '
        Me.LoadConsoleToolStripMenuItem.Name = "LoadConsoleToolStripMenuItem"
        Me.LoadConsoleToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.LoadConsoleToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.LoadConsoleToolStripMenuItem.Text = "Load Console"
        '
        'UserNameToolStripMenuItem
        '
        Me.UserNameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.ApplyToolStripMenuItem})
        Me.UserNameToolStripMenuItem.Name = "UserNameToolStripMenuItem"
        Me.UserNameToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.UserNameToolStripMenuItem.Text = "Username"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(200, 23)
        '
        'ApplyToolStripMenuItem
        '
        Me.ApplyToolStripMenuItem.Name = "ApplyToolStripMenuItem"
        Me.ApplyToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ApplyToolStripMenuItem.Text = "Apply"
        '
        'PasswordToolStripMenuItem
        '
        Me.PasswordToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox2, Me.EncodePasswordToolStripMenuItem})
        Me.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem"
        Me.PasswordToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.PasswordToolStripMenuItem.Text = "Password"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(200, 23)
        '
        'EncodePasswordToolStripMenuItem
        '
        Me.EncodePasswordToolStripMenuItem.Name = "EncodePasswordToolStripMenuItem"
        Me.EncodePasswordToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.EncodePasswordToolStripMenuItem.Text = "Encode Password and Apply"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 5000
        '
        'TimeAndDate
        '
        Me.TimeAndDate.Enabled = True
        '
        'VolumeList
        '
        Me.VolumeList.ImageStream = CType(resources.GetObject("VolumeList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.VolumeList.TransparentColor = System.Drawing.Color.Transparent
        Me.VolumeList.Images.SetKeyName(0, "volume_muted.png")
        Me.VolumeList.Images.SetKeyName(1, "volume_unmuted.png")
        '
        'InternetList
        '
        Me.InternetList.ImageStream = CType(resources.GetObject("InternetList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.InternetList.TransparentColor = System.Drawing.Color.Transparent
        Me.InternetList.Images.SetKeyName(0, "wifi_High.png")
        Me.InternetList.Images.SetKeyName(1, "wifi_Abit_High.png")
        Me.InternetList.Images.SetKeyName(2, "wifi_Bad.png")
        Me.InternetList.Images.SetKeyName(3, "wifi_Really_Bad.png")
        Me.InternetList.Images.SetKeyName(4, "wifi_none.png")
        Me.InternetList.Images.SetKeyName(5, "wifi_error.png")
        '
        'PowerList
        '
        Me.PowerList.ImageStream = CType(resources.GetObject("PowerList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.PowerList.TransparentColor = System.Drawing.Color.Transparent
        Me.PowerList.Images.SetKeyName(0, "gui_battery_full.png")
        Me.PowerList.Images.SetKeyName(1, "gui_battery_three_quarters.png")
        Me.PowerList.Images.SetKeyName(2, "gui_battery_half.png")
        Me.PowerList.Images.SetKeyName(3, "gui_battery_quarter.png")
        Me.PowerList.Images.SetKeyName(4, "gui_battery_empty.png")
        Me.PowerList.Images.SetKeyName(5, "battery_charging.png")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1243, 851)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TimebarPanel.ResumeLayout(False)
        Me.TimebarPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DebugMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommanderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ApplyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox2 As ToolStripTextBox
    Friend WithEvents EncodePasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents InternetPlusPlus As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents QuickNotes As Button
    Friend WithEvents YoutubeButton As Button
    Friend WithEvents TimebarPanel As Panel
    Friend WithEvents TimeLabel As Label
    Friend WithEvents TimeAndDate As Timer
    Friend WithEvents VolumeList As ImageList
    Friend WithEvents VolumeButton As Button
    Friend WithEvents WifiButton As Button
    Friend WithEvents PowerButton As Button
    Friend WithEvents InternetList As ImageList
    Friend WithEvents PowerList As ImageList
    Friend WithEvents Label1 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents InstagramButton As Button
    Friend WithEvents FacebookButton As Button
    Friend WithEvents SpotifyButton As Button
    Friend WithEvents CommanderWindowedToolStripMenuItem As ToolStripMenuItem
End Class
