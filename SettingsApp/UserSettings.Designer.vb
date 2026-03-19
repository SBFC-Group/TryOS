<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserSettings
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NeedThisPanel = New System.Windows.Forms.Panel()
        Me.UserButton0 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NeedThisPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(369, 379)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(178, 38)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Apply Wallpaper"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 33)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(295, 46)
        Me.FlowLayoutPanel1.TabIndex = 17
        '
        'NeedThisPanel
        '
        Me.NeedThisPanel.Controls.Add(Me.UserButton0)
        Me.NeedThisPanel.Location = New System.Drawing.Point(621, 3)
        Me.NeedThisPanel.Name = "NeedThisPanel"
        Me.NeedThisPanel.Size = New System.Drawing.Size(295, 44)
        Me.NeedThisPanel.TabIndex = 18
        Me.NeedThisPanel.Visible = False
        '
        'UserButton0
        '
        Me.UserButton0.BackColor = System.Drawing.Color.Gainsboro
        Me.UserButton0.Enabled = False
        Me.UserButton0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UserButton0.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserButton0.Location = New System.Drawing.Point(3, 3)
        Me.UserButton0.Name = "UserButton0"
        Me.UserButton0.Size = New System.Drawing.Size(289, 38)
        Me.UserButton0.TabIndex = 20
        Me.UserButton0.Text = "Apply Wallpaper"
        Me.UserButton0.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(109, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 24)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Users"
        '
        'UserSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NeedThisPanel)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "UserSettings"
        Me.Size = New System.Drawing.Size(919, 633)
        Me.NeedThisPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents UserButton0 As Windows.Forms.Button
    Friend WithEvents NeedThisPanel As Windows.Forms.Panel
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
