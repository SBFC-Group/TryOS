Public Class TaskbarOrderApp
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
            Panel1.BackColor = Color.DarkGray
            Panel2.BackColor = Color.DarkGray
            Button2.BackColor = Color.DarkGray
            Button5.BackColor = Color.DarkGray
            Button1.BackColor = Color.DarkGray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray
            Panel1.BackColor = Color.Gainsboro
            Panel2.BackColor = Color.Gainsboro
            Button2.BackColor = Color.Gainsboro
            Button5.BackColor = Color.Gainsboro
            Button1.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub AppsApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim plugins = OpenFramework_Data.OpenFramework.LoadAppsDlls(Form1.SandboxedUser)

        If plugins IsNot Nothing Then
        Else
            Return
        End If

        For Each p In plugins
            TryController.DebugManager.WriteLine("Loaded App Button """ & p.Name & """ Into TaskbarOrderApp")
            Dim Btn As New Button
            Btn.BackgroundImage = p.OpenFramework_Interface.Icon
            Btn.FlatStyle = FlatStyle.Flat
            Btn.FlatAppearance.BorderSize = 0
            Btn.BackgroundImageLayout = ImageLayout.Stretch
            Btn.Tag = p
            Btn.Size = New Size(74, 70)
            AddHandler Btn.Click, AddressOf PluginButton_Click
            FlowLayoutPanel1.Controls.Add(Btn)
        Next

        OpenFramework_Data.OpenFramework.RestoreButtonOrder(True, FlowLayoutPanel1)
    End Sub

    Private ButtonPressed As Button

    Private Sub PluginButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim plugin As OpenFramework_Interface = CType(btn.Tag, OpenFramework_Interface)

        If ButtonPressed IsNot Nothing Then
            Try
                ButtonPressed.Enabled = True
            Catch ex As Exception

            End Try
        End If


        btn.Enabled = False
        PictureBox1.Image = btn.BackgroundImage

        ButtonPressed = btn
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GoForward()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        GoBack()
    End Sub

    Public Sub GoBack()

        Dim int1 As Int64 = FlowLayoutPanel1.Controls.GetChildIndex(ButtonPressed)

        FlowLayoutPanel1.Controls.SetChildIndex(ButtonPressed, int1 - 1)
    End Sub

    Public Sub GoForward()
        Dim int1 As Int64 = FlowLayoutPanel1.Controls.GetChildIndex(ButtonPressed)

        FlowLayoutPanel1.Controls.SetChildIndex(ButtonPressed, int1 + 1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFramework_Data.OpenFramework.SaveButtonOrder(True, FlowLayoutPanel1)

        Form1.FlowLayoutPanel1.Controls.Clear()

        OpenFramework_Data.OpenFramework.LoadApps(Form1.SandboxedUser)

        OpenFramework_Data.OpenFramework.RestoreButtonOrder(False)
    End Sub
End Class
