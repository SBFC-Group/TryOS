Imports System.Runtime.InteropServices

Public Class Keyboard
    Public toapp As String = ""
    Public opened As String = "0"
    Public SendTextToApp As String = ""
    Public SendTextFromTextbox As TextBox = Nothing
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RButton.Click, KButton.Click, LButton.Click, IButton.Click, EightButton.Click, NineButton.Click, ZeroButton.Click, PButton.Click, JButton.Click, MButton.Click, BButton.Click,
        OButton.Click, YButton.Click, SevenButton.Click, SixButton.Click, FiveButton.Click, FourButton.Click, HButton.Click, TButton.Click, GButton.Click, FButton.Click, ButtonC.Click, VButton.Click, XButton.Click, ZButton.Click, AButton.Click, SButton.Click, DButton.Click, EButton.Click, WButton.Click,
        QButton.Click, OneButton.Click, TwoButton.Click, ThreeButton.Click, UButton.Click, NButton.Click, Button21.Click
        'All buttons
        TextBox1.Text = TextBox1.Text & sender.Text

        'TextBox1.Text = TextBox1.Text & Replace(sender.text, "Btn", "")
    End Sub

    Private Sub BC1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveLetterButton.Click, SpaceButton.Click
        'If sender Is BS1 Then TextBox1.Text = TextBox1.Text & " "
        If sender Is EnterButton Then TextBox1.Text = TextBox1.Text & vbNewLine
        If sender Is RemoveLetterButton Then
            Try
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1)
            Catch ex As Exception

            End Try
        End If
        'If sender Is BC1 Then TextBox1.Clear()
    End Sub

    Public IsBigLetter As Boolean = True

    Private Sub CapsLockButton() Handles BigLetterButton.Click
        If IsBigLetter = True Then
            QButton.Text = "q"
            WButton.Text = "w"
            EButton.Text = "e"
            RButton.Text = "r"
            TButton.Text = "t"
            YButton.Text = "y"
            UButton.Text = "u"
            IButton.Text = "i"
            OButton.Text = "o"
            PButton.Text = "p"
            LButton.Text = "l"
            KButton.Text = "k"
            JButton.Text = "j"
            HButton.Text = "h"
            GButton.Text = "g"
            FButton.Text = "f"
            DButton.Text = "d"
            SButton.Text = "s"
            AButton.Text = "a"
            MButton.Text = "m"
            NButton.Text = "n"
            BButton.Text = "b"
            VButton.Text = "v"
            ButtonC.Text = "c"
            XButton.Text = "x"
            ZButton.Text = "z"
            IsBigLetter = False
        ElseIf IsBigLetter = False Then
            QButton.Text = "Q"
            WButton.Text = "W"
            EButton.Text = "E"
            RButton.Text = "R"
            TButton.Text = "T"
            YButton.Text = "Y"
            UButton.Text = "U"
            IButton.Text = "I"
            OButton.Text = "O"
            PButton.Text = "P"
            LButton.Text = "L"
            KButton.Text = "K"
            JButton.Text = "J"
            HButton.Text = "H"
            GButton.Text = "G"
            FButton.Text = "F"
            DButton.Text = "D"
            SButton.Text = "S"
            AButton.Text = "A"
            MButton.Text = "M"
            NButton.Text = "N"
            BButton.Text = "B"
            VButton.Text = "V"
            ButtonC.Text = "C"
            XButton.Text = "X"
            ZButton.Text = "Z"
            IsBigLetter = True
        End If

    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        Close()
    End Sub

    Private Sub Keyboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UICVW("PadMode")
    End Sub

    Public Sub UICVW(Optional text_ As String = "")
        'MsgBox()
        If text_ = "PadMode" Then
            Size = New Size(My.Computer.Screen.Bounds.Width, 435)
            Dim ScreenPointThing As Int64 = My.Computer.Screen.Bounds.Bottom
            ScreenPointThing = ScreenPointThing - 435
            Location = New Point(0, ScreenPointThing)
        Else
            Me.BackColor = System.Drawing.SystemColors.Control
        End If

    End Sub

    Private Sub Button38_MouseDown(sender As Object, e As KeyEventArgs) Handles RemoveLetterButton.KeyDown, MyBase.KeyDown, OButton.KeyDown, IButton.KeyDown, UButton.KeyDown, YButton.KeyDown, TButton.KeyDown, NButton.KeyDown, RButton.KeyDown, OneButton.KeyDown, TwoButton.KeyDown, ThreeButton.KeyDown, FourButton.KeyDown, FiveButton.KeyDown, SixButton.KeyDown, SevenButton.KeyDown, EightButton.KeyDown, NineButton.KeyDown, EButton.KeyDown, ZButton.KeyDown, XButton.KeyDown, ButtonC.KeyDown, VButton.KeyDown, BButton.KeyDown, MButton.KeyDown, ZeroButton.KeyDown, AButton.KeyDown, WButton.KeyDown, SButton.KeyDown, DButton.KeyDown, FButton.KeyDown, GButton.KeyDown, HButton.KeyDown, JButton.KeyDown, KButton.KeyDown, LButton.KeyDown, BigLetterButton.KeyDown, PButton.KeyDown, QButton.KeyDown, SpaceButton.KeyDown, EnterButton.KeyDown, Button21.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.KeyCode = Keys.Enter Then
            ReturnButton()
        End If
    End Sub

    Private Sub ReturnButton() Handles EnterButton.Click
        'If TextBox1.Text = "" Then
        'Exit Sub
        'Else
        Close()
        'End If
    End Sub

    Private IsFirstLetter As Boolean = True
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If IsFirstLetter = True Then
            IsFirstLetter = False
            CapsLockButton()
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class