<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class USWApp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(USWApp))
        Me.SetupPanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RemoveLetterButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumberButton0 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.NumberButton9 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.NumberButton8 = New System.Windows.Forms.Button()
        Me.NumberButton1 = New System.Windows.Forms.Button()
        Me.NumberButton7 = New System.Windows.Forms.Button()
        Me.NumberButton2 = New System.Windows.Forms.Button()
        Me.NumberButton6 = New System.Windows.Forms.Button()
        Me.NumberButton3 = New System.Windows.Forms.Button()
        Me.NumberButton5 = New System.Windows.Forms.Button()
        Me.NumberButton4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.StartMainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SetupPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'SetupPanel
        '
        Me.SetupPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SetupPanel.BackColor = System.Drawing.Color.DarkGray
        Me.SetupPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SetupPanel.Controls.Add(Me.Panel2)
        Me.SetupPanel.Controls.Add(Me.Panel1)
        Me.SetupPanel.Location = New System.Drawing.Point(21, 26)
        Me.SetupPanel.Name = "SetupPanel"
        Me.SetupPanel.Size = New System.Drawing.Size(955, 564)
        Me.SetupPanel.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RemoveLetterButton)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.NumberButton0)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.NumberButton9)
        Me.Panel2.Controls.Add(Me.TextBox3)
        Me.Panel2.Controls.Add(Me.NumberButton8)
        Me.Panel2.Controls.Add(Me.NumberButton1)
        Me.Panel2.Controls.Add(Me.NumberButton7)
        Me.Panel2.Controls.Add(Me.NumberButton2)
        Me.Panel2.Controls.Add(Me.NumberButton6)
        Me.Panel2.Controls.Add(Me.NumberButton3)
        Me.Panel2.Controls.Add(Me.NumberButton5)
        Me.Panel2.Controls.Add(Me.NumberButton4)
        Me.Panel2.Location = New System.Drawing.Point(654, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(264, 341)
        Me.Panel2.TabIndex = 3
        Me.Panel2.Visible = False
        '
        'RemoveLetterButton
        '
        Me.RemoveLetterButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.RemoveLetterButton.BackColor = System.Drawing.Color.LightGray
        Me.RemoveLetterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.RemoveLetterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.RemoveLetterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RemoveLetterButton.Font = New System.Drawing.Font("Segoe MDL2 Assets", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveLetterButton.Location = New System.Drawing.Point(160, 233)
        Me.RemoveLetterButton.Name = "RemoveLetterButton"
        Me.RemoveLetterButton.Size = New System.Drawing.Size(55, 48)
        Me.RemoveLetterButton.TabIndex = 85
        Me.RemoveLetterButton.Text = ""
        Me.RemoveLetterButton.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(84, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 27)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Pincode"
        '
        'NumberButton0
        '
        Me.NumberButton0.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton0.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton0.Location = New System.Drawing.Point(99, 233)
        Me.NumberButton0.Name = "NumberButton0"
        Me.NumberButton0.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton0.TabIndex = 84
        Me.NumberButton0.Text = "0"
        Me.NumberButton0.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.BackColor = System.Drawing.Color.Gainsboro
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(38, 287)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(183, 49)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Use This Pincode"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'NumberButton9
        '
        Me.NumberButton9.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton9.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton9.Location = New System.Drawing.Point(160, 181)
        Me.NumberButton9.Name = "NumberButton9"
        Me.NumberButton9.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton9.TabIndex = 83
        Me.NumberButton9.Text = "9"
        Me.NumberButton9.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox3.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(38, 41)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.ShortcutsEnabled = False
        Me.TextBox3.Size = New System.Drawing.Size(177, 26)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.UseSystemPasswordChar = True
        '
        'NumberButton8
        '
        Me.NumberButton8.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton8.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton8.Location = New System.Drawing.Point(99, 181)
        Me.NumberButton8.Name = "NumberButton8"
        Me.NumberButton8.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton8.TabIndex = 82
        Me.NumberButton8.Text = "8"
        Me.NumberButton8.UseVisualStyleBackColor = False
        '
        'NumberButton1
        '
        Me.NumberButton1.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton1.Location = New System.Drawing.Point(38, 73)
        Me.NumberButton1.Name = "NumberButton1"
        Me.NumberButton1.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton1.TabIndex = 75
        Me.NumberButton1.Text = "1"
        Me.NumberButton1.UseVisualStyleBackColor = False
        '
        'NumberButton7
        '
        Me.NumberButton7.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton7.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton7.Location = New System.Drawing.Point(38, 181)
        Me.NumberButton7.Name = "NumberButton7"
        Me.NumberButton7.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton7.TabIndex = 81
        Me.NumberButton7.Text = "7"
        Me.NumberButton7.UseVisualStyleBackColor = False
        '
        'NumberButton2
        '
        Me.NumberButton2.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton2.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton2.Location = New System.Drawing.Point(99, 73)
        Me.NumberButton2.Name = "NumberButton2"
        Me.NumberButton2.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton2.TabIndex = 76
        Me.NumberButton2.Text = "2"
        Me.NumberButton2.UseVisualStyleBackColor = False
        '
        'NumberButton6
        '
        Me.NumberButton6.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton6.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton6.Location = New System.Drawing.Point(160, 127)
        Me.NumberButton6.Name = "NumberButton6"
        Me.NumberButton6.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton6.TabIndex = 80
        Me.NumberButton6.Text = "6"
        Me.NumberButton6.UseVisualStyleBackColor = False
        '
        'NumberButton3
        '
        Me.NumberButton3.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton3.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton3.Location = New System.Drawing.Point(160, 73)
        Me.NumberButton3.Name = "NumberButton3"
        Me.NumberButton3.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton3.TabIndex = 77
        Me.NumberButton3.Text = "3"
        Me.NumberButton3.UseVisualStyleBackColor = False
        '
        'NumberButton5
        '
        Me.NumberButton5.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton5.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton5.Location = New System.Drawing.Point(99, 127)
        Me.NumberButton5.Name = "NumberButton5"
        Me.NumberButton5.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton5.TabIndex = 79
        Me.NumberButton5.Text = "5"
        Me.NumberButton5.UseVisualStyleBackColor = False
        '
        'NumberButton4
        '
        Me.NumberButton4.BackColor = System.Drawing.Color.Gainsboro
        Me.NumberButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumberButton4.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberButton4.Location = New System.Drawing.Point(38, 127)
        Me.NumberButton4.Name = "NumberButton4"
        Me.NumberButton4.Size = New System.Drawing.Size(55, 48)
        Me.NumberButton4.TabIndex = 78
        Me.NumberButton4.Text = "4"
        Me.NumberButton4.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(40, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(607, 341)
        Me.Panel1.TabIndex = 2
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(22, 135)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(159, 28)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Show Password"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button4.BackColor = System.Drawing.Color.Gainsboro
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(352, 133)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(177, 49)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Create Pincode"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(205, 133)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(141, 49)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Create User"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(3, 103)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(601, 26)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-2, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 27)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Password"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(3, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(601, 26)
        Me.TextBox1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-2, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 27)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Username"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(220, 287)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(174, 47)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Close Program"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(36, 45)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(882, 381)
        Me.AxWindowsMediaPlayer1.TabIndex = 2
        '
        'StartMainTimer
        '
        Me.StartMainTimer.Interval = 6000
        '
        'MainTimer
        '
        Me.MainTimer.Enabled = True
        '
        'Panel3
        '
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.SetupPanel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1000, 623)
        Me.Panel3.TabIndex = 3
        Me.Panel3.Visible = False
        '
        'USWApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 623)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "USWApp"
        Me.Text = "USWApp"
        Me.SetupPanel.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SetupPanel As Panel
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents StartMainTimer As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MainTimer As Timer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents RemoveLetterButton As Button
    Friend WithEvents NumberButton0 As Button
    Friend WithEvents NumberButton9 As Button
    Friend WithEvents NumberButton8 As Button
    Friend WithEvents NumberButton1 As Button
    Friend WithEvents NumberButton7 As Button
    Friend WithEvents NumberButton2 As Button
    Friend WithEvents NumberButton6 As Button
    Friend WithEvents NumberButton3 As Button
    Friend WithEvents NumberButton5 As Button
    Friend WithEvents NumberButton4 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Panel3 As Panel
End Class
