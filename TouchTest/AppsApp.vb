Public Class AppsApp
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Form1.IsUsingDarkThemeForApps = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Color.Gray

        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray

        End If
    End Sub

    Private Sub AppsApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim plugins = LoadPlugins_New()

        For Each p In plugins
            Debug.WriteLine("Loaded " & p.Name)
            p.Initialize(host)
            Dim btn As New Button()
            'btn.Text = p.Name
            btn.BackgroundImage = p.Icon
            'btn.TextImageRelation = TextImageRelation.ImageAboveText
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.BackgroundImageLayout = ImageLayout.Stretch
            btn.Tag = p
            btn.Size = New Size(74, 70)
            'btn.AutoSize = True
            'btn.AutoSizeMode = AutoSizeMode.GrowAndShrink
            'btn.Padding = New Padding(5)
            AddHandler btn.Click, AddressOf PluginButton_Click
            Form1.FlowLayoutPanel1.Controls.Add(btn)
        Next
    End Sub

    Private Sub PluginButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim plugin As OpenFramework_Interface = CType(btn.Tag, OpenFramework_Interface)


        Form1.FlowLayoutPanel1.Controls.
        'Dim frm As Form = plugin.GetForm()
        'If Form1.currentForm IsNot Nothing Then
        '    If frm.Text = AppName Then
        '        Exit Sub
        '    End If
        'End If
        'AppName = frm.Text
        'frm.Text = plugin.Name
        'Form1.OpenChildForm(frm)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
