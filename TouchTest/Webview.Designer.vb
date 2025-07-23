<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Webview
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
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebView21.Location = New System.Drawing.Point(0, 45)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(901, 474)
        Me.WebView21.Source = New System.Uri("https://sebs-sw-b.netlify.app/news-sebs-sw.html", System.UriKind.Absolute)
        Me.WebView21.TabIndex = 1
        Me.WebView21.ZoomFactor = 1.0R
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(901, 45)
        Me.Panel1.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(105, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(57, 38)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Refresh"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(54, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(45, 38)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "→"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 38)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "←"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Webview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WebView21)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Webview"
        Me.Size = New System.Drawing.Size(901, 519)
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
