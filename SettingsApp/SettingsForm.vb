Public Class SettingsForm
    Private UserControlName As String = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SettingsPanel.Tag IsNot Nothing Then

            If UserControlName = SettingsPanel.Tag.Name Then
                Return
            Else
                SettingsPanel.Tag = Nothing
                SettingsPanel.Controls.Clear()
            End If
        End If

        SettingsPanel.Tag = New ThemeApp
        UserControlName = SettingsPanel.Tag.Name
        SettingsPanel.Controls.Add(SettingsPanel.Tag)
    End Sub
End Class