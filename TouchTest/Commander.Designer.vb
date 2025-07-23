<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Commander
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Commander))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MiniButton = New System.Windows.Forms.Button()
        Me.MaxiButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SegToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.MiniButton)
        Me.Panel1.Controls.Add(Me.MaxiButton)
        Me.Panel1.Controls.Add(Me.CloseButton)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 59)
        Me.Panel1.TabIndex = 2
        Me.Panel1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 49)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'MiniButton
        '
        Me.MiniButton.BackgroundImage = Global.TouchTest.My.Resources.Resources.minimize2
        Me.MiniButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MiniButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.MiniButton.Enabled = False
        Me.MiniButton.FlatAppearance.BorderSize = 0
        Me.MiniButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MiniButton.Location = New System.Drawing.Point(621, 0)
        Me.MiniButton.Name = "MiniButton"
        Me.MiniButton.Size = New System.Drawing.Size(59, 57)
        Me.MiniButton.TabIndex = 3
        Me.MiniButton.UseVisualStyleBackColor = True
        '
        'MaxiButton
        '
        Me.MaxiButton.BackgroundImage = Global.TouchTest.My.Resources.Resources._1266721
        Me.MaxiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MaxiButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.MaxiButton.Enabled = False
        Me.MaxiButton.FlatAppearance.BorderSize = 0
        Me.MaxiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MaxiButton.Location = New System.Drawing.Point(680, 0)
        Me.MaxiButton.Name = "MaxiButton"
        Me.MaxiButton.Size = New System.Drawing.Size(59, 57)
        Me.MaxiButton.TabIndex = 2
        Me.MaxiButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.BackgroundImage = Global.TouchTest.My.Resources.Resources._2920659_2
        Me.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.CloseButton.FlatAppearance.BorderSize = 0
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseButton.Location = New System.Drawing.Point(739, 0)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(59, 57)
        Me.CloseButton.TabIndex = 1
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SegToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(185, 9)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(45, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'SegToolStripMenuItem
        '
        Me.SegToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2})
        Me.SegToolStripMenuItem.Name = "SegToolStripMenuItem"
        Me.SegToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.SegToolStripMenuItem.Text = "seg"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(121, 22)
        Me.ToolStripMenuItem2.Text = "1-"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.RichTextBox1.ForeColor = System.Drawing.Color.White
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 59)
        Me.RichTextBox1.Multiline = False
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(800, 391)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = "Console>"
        '
        'Commander
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Commander"
        Me.Text = "Commander"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MiniButton As Button
    Friend WithEvents MaxiButton As Button
    Friend WithEvents CloseButton As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SegToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
