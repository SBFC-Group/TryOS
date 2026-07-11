<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppUpdate
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AppIcon = New System.Windows.Forms.PictureBox()
        Me.VersonLabel = New System.Windows.Forms.Label()
        Me.AppFolderLabel = New System.Windows.Forms.Label()
        Me.AppNameLabel = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NeedThisButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.AppIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.AppIcon)
        Me.Panel1.Controls.Add(Me.VersonLabel)
        Me.Panel1.Controls.Add(Me.AppFolderLabel)
        Me.Panel1.Controls.Add(Me.AppNameLabel)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(370, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 577)
        Me.Panel1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(5, 533)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(194, 39)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Update App"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'AppIcon
        '
        Me.AppIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AppIcon.Location = New System.Drawing.Point(5, 48)
        Me.AppIcon.Name = "AppIcon"
        Me.AppIcon.Size = New System.Drawing.Size(105, 102)
        Me.AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AppIcon.TabIndex = 6
        Me.AppIcon.TabStop = False
        '
        'VersonLabel
        '
        Me.VersonLabel.AutoSize = True
        Me.VersonLabel.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersonLabel.Location = New System.Drawing.Point(5, 225)
        Me.VersonLabel.Name = "VersonLabel"
        Me.VersonLabel.Size = New System.Drawing.Size(83, 24)
        Me.VersonLabel.TabIndex = 5
        Me.VersonLabel.Text = "Version: "
        '
        'AppFolderLabel
        '
        Me.AppFolderLabel.AutoSize = True
        Me.AppFolderLabel.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppFolderLabel.Location = New System.Drawing.Point(5, 190)
        Me.AppFolderLabel.Name = "AppFolderLabel"
        Me.AppFolderLabel.Size = New System.Drawing.Size(131, 24)
        Me.AppFolderLabel.TabIndex = 4
        Me.AppFolderLabel.Text = "Folder Name: "
        '
        'AppNameLabel
        '
        Me.AppNameLabel.AutoSize = True
        Me.AppNameLabel.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppNameLabel.Location = New System.Drawing.Point(5, 156)
        Me.AppNameLabel.Name = "AppNameLabel"
        Me.AppNameLabel.Size = New System.Drawing.Size(71, 24)
        Me.AppNameLabel.TabIndex = 3
        Me.AppNameLabel.Text = "Name: "
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 39)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Reload Apps"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Silver
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.NeedThisButton)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(370, 577)
        Me.FlowLayoutPanel1.TabIndex = 4
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'NeedThisButton
        '
        Me.NeedThisButton.BackColor = System.Drawing.Color.Gainsboro
        Me.NeedThisButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NeedThisButton.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NeedThisButton.Location = New System.Drawing.Point(3, 3)
        Me.NeedThisButton.Name = "NeedThisButton"
        Me.NeedThisButton.Size = New System.Drawing.Size(361, 39)
        Me.NeedThisButton.TabIndex = 1
        Me.NeedThisButton.Text = "Test App"
        Me.NeedThisButton.UseVisualStyleBackColor = False
        Me.NeedThisButton.Visible = False
        '
        'AppUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "AppUpdate"
        Me.Size = New System.Drawing.Size(790, 577)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.AppIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents AppIcon As Windows.Forms.PictureBox
    Friend WithEvents VersonLabel As Windows.Forms.Label
    Friend WithEvents AppFolderLabel As Windows.Forms.Label
    Friend WithEvents AppNameLabel As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents NeedThisButton As Windows.Forms.Button
End Class
