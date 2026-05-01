Public Class PageSettings
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CloseControlCenter()
    End Sub

    Private Sub CloseControlCenter()
        Form1.HideTaskbar(False)
        Form1.Panel3.Controls.Remove(Form1.ControlCenter)
        Try
            Form1.currentForm.Show()
        Catch ex As Exception

        End Try
        'Form1.ControlCenter.Dock = DockStyle.Fill
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Label1.Text = Form1.BatteryPower.ToString & "%"

        'If Form1.BatteryPower = 100 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 99 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 98 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 97 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 96 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 95 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 94 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 93 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 92 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 91 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 90 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 89 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 88 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 87 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 86 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 85 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 84 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 83 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 82 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 81 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 80 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(0)
        'ElseIf Form1.BatteryPower = 79 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 78 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 77 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 76 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 75 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 74 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 73 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 72 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 71 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 70 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 69 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 68 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 67 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 66 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 65 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 64 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 63 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 62 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 61 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 60 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(1)
        'ElseIf Form1.BatteryPower = 59 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 58 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 57 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 56 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 55 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 54 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 53 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 52 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 51 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 50 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 49 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 48 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 47 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 46 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 45 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 44 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 43 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 42 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 41 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 40 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(2)
        'ElseIf Form1.BatteryPower = 39 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 38 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 37 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 36 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 35 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 34 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 33 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 32 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 31 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 30 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 29 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 28 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 27 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 26 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 25 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 24 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 23 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 22 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 21 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 20 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 19 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 18 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 17 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(3)
        'ElseIf Form1.BatteryPower = 16 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 15 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 14 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 13 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 12 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 11 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 10 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 9 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 8 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 7 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 6 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 5 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 4 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 3 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 2 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 1 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'ElseIf Form1.BatteryPower = 0 Then
        '    PictureBox1.Image = Form1.PowerList.Images.Item(4)
        'End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Me.BackColor = Color.FromArgb(55, Color.Silver)
        Panel3.BackColor = Color.FromArgb(55, Color.DarkGray)
    End Sub
End Class
