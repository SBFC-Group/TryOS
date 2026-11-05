<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Explorer
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyAsPathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenWithToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 42)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(798, 340)
        Me.SplitContainer1.SplitterDistance = 156
        Me.SplitContainer1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Silver
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(156, 340)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Gainsboro
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(3, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(148, 38)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Text Here"
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.ListView1.BackColor = System.Drawing.Color.Silver
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(638, 340)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.LightGray
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ToolStripSeparator4, Me.CopyAsPathToolStripMenuItem, Me.OpenWithToolStripMenuItem, Me.ToolStripSeparator3, Me.SettingsToolStripMenuItem, Me.ToolStripSeparator1, Me.FToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator2, Me.DeleteToolStripMenuItem, Me.RenameToolStripMenuItem, Me.ToolStripSeparator5})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(166, 308)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(162, 6)
        '
        'CopyAsPathToolStripMenuItem
        '
        Me.CopyAsPathToolStripMenuItem.Name = "CopyAsPathToolStripMenuItem"
        Me.CopyAsPathToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.CopyAsPathToolStripMenuItem.Text = "Copy as path"
        '
        'OpenWithToolStripMenuItem
        '
        Me.OpenWithToolStripMenuItem.Name = "OpenWithToolStripMenuItem"
        Me.OpenWithToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.OpenWithToolStripMenuItem.Text = "Open with"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(162, 6)
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.BackColor = System.Drawing.Color.Gray
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(162, 6)
        '
        'FToolStripMenuItem
        '
        Me.FToolStripMenuItem.Name = "FToolStripMenuItem"
        Me.FToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.FToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(162, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(798, 42)
        Me.Panel1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.LightGray
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Trebuchet MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(541, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ShortcutsEnabled = False
        Me.TextBox2.Size = New System.Drawing.Size(255, 39)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.WordWrap = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.LightGray
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Trebuchet MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(123, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ShortcutsEnabled = False
        Me.TextBox1.Size = New System.Drawing.Size(417, 39)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.WordWrap = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gainsboro
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Segoe MDL2 Assets", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(82, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 42)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = ""
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(41, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 42)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 42)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "<"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(162, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(165, 28)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'Explorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Explorer"
        Me.Size = New System.Drawing.Size(798, 382)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents ListView1 As Windows.Forms.ListView
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button4 As Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyAsPathToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenWithToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents FToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As Windows.Forms.ToolStripSeparator
End Class
