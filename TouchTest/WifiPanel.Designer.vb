<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WifiPanel
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
        Me.btnScan = New System.Windows.Forms.Button()
        Me.lstNetworks = New System.Windows.Forms.ListBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(219, 180)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(104, 23)
        Me.btnScan.TabIndex = 0
        Me.btnScan.Text = "Scan Wi-Fi"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'lstNetworks
        '
        Me.lstNetworks.FormattingEnabled = True
        Me.lstNetworks.Location = New System.Drawing.Point(445, 158)
        Me.lstNetworks.Name = "lstNetworks"
        Me.lstNetworks.Size = New System.Drawing.Size(120, 95)
        Me.lstNetworks.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(212, 326)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 2
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(209, 403)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 3
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(209, 464)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(60, 13)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "Status: Idle"
        '
        'WifiPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lstNetworks)
        Me.Controls.Add(Me.btnScan)
        Me.Name = "WifiPanel"
        Me.Size = New System.Drawing.Size(739, 540)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnScan As Button
    Friend WithEvents lstNetworks As ListBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents lblStatus As Label
End Class
