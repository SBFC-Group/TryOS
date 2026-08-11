Public Class Form2
    Public HasBeenOpened As Boolean = False
    Public IsOpen As Boolean = False
    Public HasLostFocus As Boolean = False
    Public IsFocusOnButton As Boolean = False

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.desktop_windows_119229

        If HasBeenOpened = False Then
            HasBeenOpened = True
        End If
    End Sub

    Private Sub Form2_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        'Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Timer1.Stop()

        'hasLostFocus = True
    End Sub

    Public Sub LoadEverything()
        FlowLayoutPanel1.Controls.Clear()

        For Each f As Form In Form1.AppList
            Try
                Dim NewButton As New AppButton
                NewButton.Name = f.Name
                NewButton.TheForm = f
                NewButton.Button1.Text = f.Text
                FlowLayoutPanel1.Controls.Add(NewButton)
            Catch ex As Exception
                TryController.DebugManager.WriteLine(ex.Message)
            End Try

        Next
    End Sub
End Class