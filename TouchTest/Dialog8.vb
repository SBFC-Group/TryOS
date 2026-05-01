Public Class Dialog8
    Private SelectedColor As Color = Nothing

    Public Color As Color = Nothing

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Color = SelectedColor
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ColorButtons_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click, PictureBox8.Click, PictureBox7.Click, PictureBox6.Click, PictureBox5.Click, PictureBox48.Click, PictureBox47.Click, PictureBox46.Click, PictureBox45.Click, PictureBox44.Click, PictureBox43.Click, PictureBox42.Click, PictureBox41.Click, PictureBox40.Click, PictureBox4.Click, PictureBox39.Click, PictureBox38.Click, PictureBox37.Click, PictureBox36.Click, PictureBox35.Click, PictureBox34.Click, PictureBox33.Click, PictureBox32.Click, PictureBox31.Click, PictureBox30.Click, PictureBox3.Click, PictureBox29.Click, PictureBox28.Click, PictureBox27.Click, PictureBox26.Click, PictureBox25.Click, PictureBox24.Click, PictureBox23.Click, PictureBox22.Click, PictureBox21.Click, PictureBox20.Click, PictureBox2.Click, PictureBox19.Click, PictureBox18.Click, PictureBox17.Click, PictureBox16.Click, PictureBox15.Click, PictureBox14.Click, PictureBox13.Click, PictureBox12.Click, PictureBox11.Click, PictureBox10.Click, PictureBox1.Click
        PictureBox49.BackColor = sender.BackColor
        SelectedColor = sender.BackColor
    End Sub

    Private Sub ResetSelectedColorButton_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SelectedColor = Nothing
        PictureBox49.BackColor = Color.White
    End Sub
End Class
