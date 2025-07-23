<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsoleHelper
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
        Me.txtConsole = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtConsole
        '
        Me.txtConsole.AcceptsReturn = True
        Me.txtConsole.BackColor = System.Drawing.Color.Black
        Me.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConsole.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.txtConsole.ForeColor = System.Drawing.Color.White
        Me.txtConsole.Location = New System.Drawing.Point(0, 0)
        Me.txtConsole.Multiline = True
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsole.Size = New System.Drawing.Size(800, 450)
        Me.txtConsole.TabIndex = 0
        '
        'ConsoleHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtConsole)
        Me.Name = "ConsoleHelper"
        Me.Text = "ConsoleHelper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtConsole As TextBox
End Class
