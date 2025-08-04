Public Class ErrorMSGBox
    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Public Enum Alerts
        Critical = 16

        Question = 32

        Exclamation = 48

        Information = 64
    End Enum

    Public Sub ShowError()
        ShowError("", Alerts.Information)
    End Sub

    Public Sub ShowError(Text As String)
        ShowError(Text, Alerts.Information)
    End Sub

    Public Sub ShowError(Text As String, Alert As Alerts)
        Me.ShowDialog()
        RichTextBox1.Text = Text
        If Alert = Alerts.Critical Then
        ElseIf Alert = Alerts.Exclamation Then
        ElseIf Alert = Alerts.Information Then
        ElseIf Alert = Alerts.Question Then
        End If
    End Sub

    'Public Enum MsgBoxStyle

    '    OkOnly = 0

    '    OkCancel = 1

    '    AbortRetryIgnore = 2

    '    YesNoCancel = 3

    '    YesNo = 4

    '    RetryCancel = 5

    '    Critical = 16

    '    Question = 32

    '    Exclamation = 48

    '    Information = 64

    '    DefaultButton1 = 0

    '    DefaultButton2 = 256

    '    DefaultButton3 = 512

    '    ApplicationModal = 0

    '    SystemModal = 4096

    '    MsgBoxHelp = 16384

    '    MsgBoxRight = 524288

    '    MsgBoxRtlReading = 1048576

    '    MsgBoxSetForeground = 65536
    'End Enum
End Class