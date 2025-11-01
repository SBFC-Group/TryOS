Imports TouchTest

Public Class Class1
    Implements TouchTest.Q_U_U_U_Q_I

    Public ReadOnly Property Name As String Implements Q_U_U_U_Q_I.Name
        Get
            Return "ShitTo2_And_ShitTo1"
        End Get
    End Property

    Public Fl As Form1

    Public Sub ExecuteDebug(mainForm As Form1) Implements Q_U_U_U_Q_I.ExecuteDebug
        Fl = mainForm
        mainForm.Shit = 2
    End Sub

    Public Sub ExecuteUISubs(mainForm As UI) Implements Q_U_U_U_Q_I.ExecuteUISubs
        Dim ItTimer As New System.Windows.Forms.Timer

        ItTimer.Interval = 5000
        ItTimer.Enabled = True
        AddHandler ItTimer.Tick, AddressOf TimerIt_Tick

    End Sub

    Private Sub TimerIt_Tick(sender As Object, e As EventArgs)
        If Fl.Shit = 2 Then
            Fl.Shit = 1
        End If
        sender.Stop
    End Sub
End Class
