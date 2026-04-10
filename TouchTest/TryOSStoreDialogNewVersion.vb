Public Class TryOSStoreDialogNewVersion
    Private Sub YesButton_Click(sender As Object, e As EventArgs) Handles YesButton.Click
        DialogResult = DialogResult.Yes
        Close()
    End Sub

    Private Sub NoButton_Click(sender As Object, e As EventArgs) Handles NoButton.Click
        DialogResult = DialogResult.No
        Close()
    End Sub
End Class