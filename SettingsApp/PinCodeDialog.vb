Imports System.Windows.Forms

Public Class PinCodeDialog


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Key_Down_Here(sender As Object, e As KeyEventArgs)
        If e.KeyValue = 48 Then ' Key 0
            NumberButton0_Click()
        ElseIf e.KeyValue = 49 Then ' Key 1
            NumberButton1_Click()
        ElseIf e.KeyValue = 50 Then ' Key 2
            NumberButton2_Click()
        ElseIf e.KeyValue = 51 Then ' Key 3
            NumberButton3_Click()
        ElseIf e.KeyValue = 52 Then ' Key 4
            NumberButton4_Click()
        ElseIf e.KeyValue = 53 Then ' Key 5
            NumberButton5_Click()
        ElseIf e.KeyValue = 54 Then ' Key 6
            NumberButton6_Click()
        ElseIf e.KeyValue = 55 Then ' Key 7
            NumberButton7_Click()
        ElseIf e.KeyValue = 56 Then ' Key 8
            NumberButton8_Click()
        ElseIf e.KeyValue = 57 Then ' Key 9
            NumberButton9_Click()
        ElseIf e.KeyValue = 8 Then ' Key Backspace
            RemoveLetterButton_Click()
        ElseIf e.KeyValue = 46 Then ' Key Delete
            RemoveLetterButton_Click()
        End If
    End Sub

    Private Sub RemoveLetterButton_Click() Handles RemoveLetterButton.Click
        If TextBox3.Text.Length = 0 Or TextBox3.Text.Length < 0 Then
        Else
            TextBox3.Text = TextBox3.Text.Substring(0, TextBox3.Text.Length - 1)
        End If
    End Sub

    Private Sub NumberButton1_Click() Handles NumberButton1.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "1"
            IsTextBoxFull()
        End If
    End Sub

    Private Sub NumberButton2_Click() Handles NumberButton2.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "2"
            IsTextBoxFull()

        End If
    End Sub

    Private Sub NumberButton3_Click() Handles NumberButton3.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "3"
            IsTextBoxFull()
        End If
    End Sub

    Private Sub NumberButton4_Click() Handles NumberButton4.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "4"
            IsTextBoxFull()
        End If
    End Sub

    Private Sub NumberButton5_Click() Handles NumberButton5.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "5"
            IsTextBoxFull()
        End If
    End Sub

    Private Sub NumberButton6_Click() Handles NumberButton6.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "6"
            IsTextBoxFull()
        End If
    End Sub

    Private Sub NumberButton7_Click() Handles NumberButton7.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "7"
            IsTextBoxFull()
        End If
    End Sub

    Private Sub NumberButton8_Click() Handles NumberButton8.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "8"
            IsTextBoxFull()
        End If
    End Sub

    Private Sub NumberButton9_Click() Handles NumberButton9.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "9"
            IsTextBoxFull()
        End If
    End Sub

    Private Sub NumberButton0_Click() Handles NumberButton0.Click
        If TextBox3.Text.Length = 4 Then
        Else
            TextBox3.Text = TextBox3.Text + "0"
            IsTextBoxFull()
        End If
    End Sub

    Public PinCode As String = Nothing
    Public Username As String = Nothing

    Public Sub IsTextBoxFull()
        If TextBox3.Text.Length = 4 Then
            Dim ThePin As String
            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(TextBox3.Text)
            ThePin = Convert.ToBase64String(byt)
            byt = System.Text.Encoding.UTF8.GetBytes(ThePin)
            ThePin = Convert.ToBase64String(byt)

            PinCode = ThePin

            'My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Username & "\Settings\Pincode.swfiles", ThePin, False)

            Dim sender As New Object
            Dim e As New EventArgs

            OK_Button_Click(sender, e)
        End If
    End Sub

    Private Sub AddKeyPreviewToAll(CoreControl As Control)
        For Each c As Control In CoreControl.Controls
            AddHandler c.KeyDown, AddressOf Key_Down_Here

            If c.HasChildren Then AddKeyPreviewToAll(c)
        Next
    End Sub

    Private Sub PinCodeDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AddHandler Me.KeyDown, AddressOf Key_Down_Here

        'AddKeyPreviewToAll(Me)
    End Sub
End Class
