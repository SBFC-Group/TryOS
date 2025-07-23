<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Search_App
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HelloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuickEditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ChecksHistory = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 524)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(578, 26)
        Me.ProgressBar1.TabIndex = 11
        Me.ProgressBar1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(3, 515)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(578, 35)
        Me.TextBox1.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 463)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(153, 46)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Location = New System.Drawing.Point(-13, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(610, 408)
        Me.Panel1.TabIndex = 14
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelloToolStripMenuItem, Me.FileExplorerToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.QuickEditToolStripMenuItem, Me.ImageViewerToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(608, 165)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'HelloToolStripMenuItem
        '
        Me.HelloToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.HelloToolStripMenuItem.Name = "HelloToolStripMenuItem"
        Me.HelloToolStripMenuItem.Size = New System.Drawing.Size(601, 28)
        Me.HelloToolStripMenuItem.Text = "GCS"
        Me.HelloToolStripMenuItem.Visible = False
        '
        'FileExplorerToolStripMenuItem
        '
        Me.FileExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.FileExplorerToolStripMenuItem.Name = "FileExplorerToolStripMenuItem"
        Me.FileExplorerToolStripMenuItem.Size = New System.Drawing.Size(601, 28)
        Me.FileExplorerToolStripMenuItem.Text = "File Explorer"
        Me.FileExplorerToolStripMenuItem.Visible = False
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(601, 28)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        Me.SettingsToolStripMenuItem.Visible = False
        '
        'QuickEditToolStripMenuItem
        '
        Me.QuickEditToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.QuickEditToolStripMenuItem.Name = "QuickEditToolStripMenuItem"
        Me.QuickEditToolStripMenuItem.Size = New System.Drawing.Size(601, 28)
        Me.QuickEditToolStripMenuItem.Text = "Quick Edit"
        Me.QuickEditToolStripMenuItem.Visible = False
        '
        'ImageViewerToolStripMenuItem
        '
        Me.ImageViewerToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ImageViewerToolStripMenuItem.Name = "ImageViewerToolStripMenuItem"
        Me.ImageViewerToolStripMenuItem.Size = New System.Drawing.Size(601, 28)
        Me.ImageViewerToolStripMenuItem.Text = "Image Viewer"
        Me.ImageViewerToolStripMenuItem.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(4, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 40)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Forms"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gainsboro
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(136, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(126, 40)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Apps"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Gainsboro
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(268, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(126, 40)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "Web"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'ChecksHistory
        '
        Me.ChecksHistory.Enabled = True
        Me.ChecksHistory.Interval = 5000
        '
        'Search_App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Name = "Search_App"
        Me.Size = New System.Drawing.Size(584, 553)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ChecksHistory As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents HelloToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuickEditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageViewerToolStripMenuItem As ToolStripMenuItem
End Class
