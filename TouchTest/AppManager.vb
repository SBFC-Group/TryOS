Public Class AppManager
    Private Sub AppManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim plugins = OpenFramework_Data.LoadPlugins_New()

        For Each p In plugins
            Debug.WriteLine("Loaded " & p.Name)
            Dim Btn As New Button
            'btn.Text = p.Name
            Btn.BackgroundImage = p.Icon
            'btn.TextImageRelation = TextImageRelation.ImageAboveText
            Btn.FlatStyle = FlatStyle.Flat
            Btn.FlatAppearance.BorderSize = 0
            Btn.BackgroundImageLayout = ImageLayout.Stretch
            Btn.Tag = p
            Btn.Size = New Size(74, 70)
            'btn.AutoSize = True
            'btn.AutoSizeMode = AutoSizeMode.GrowAndShrink
            'btn.Padding = New Padding(5)
            AddHandler Btn.Click, AddressOf PluginButton_Click
            FlowLayoutPanel1.Controls.Add(Btn)
        Next

        OpenFramework_Data.RestoreButtonOrder(True, FlowLayoutPanel1)
    End Sub

    Private ButtonPressed As Button

    Private Sub PluginButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim plugin As OpenFramework_Interface = CType(btn.Tag, OpenFramework_Interface)
        Try
            ButtonPressed.Enabled = True
        Catch ex As Exception

        End Try

        btn.Enabled = False
        PictureBox1.Image = btn.BackgroundImage

        ButtonPressed = btn
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
End Class
