Public Class DebugManager
    Private DebugWindow As DebugManagerWindow

    Private IsUsingVSDebugger As Boolean = False

    Public Sub New()
        If Environment.CommandLine.Contains("/VS_Debug") = True Then
            IsUsingVSDebugger = True
        Else
            DebugWindow = New DebugManagerWindow
            DebugWindow.Show()
        End If
    End Sub

    Public Sub WriteLine(text As String)
        If IsUsingVSDebugger = True Then
            Debug.WriteLine(text)
        Else
            WriteToDebugWindow(text)
        End If

    End Sub

    Public Sub WriteLine(bool As Boolean)
        If IsUsingVSDebugger = True Then
            Debug.WriteLine(bool)
        Else
            If bool = True Then
                WriteToDebugWindow("True")
            ElseIf bool = False Then
                WriteToDebugWindow("False")
            End If
        End If
    End Sub

    Public Sub WriteLine(int As Int16)
        If IsUsingVSDebugger = True Then
            Debug.WriteLine(int)
        Else
            WriteToDebugWindow(int.ToString)
        End If
    End Sub

    Public Sub WriteLine(int As Int32)
        If IsUsingVSDebugger = True Then
            Debug.WriteLine(int)
        Else
            WriteToDebugWindow(int.ToString)
        End If
    End Sub

    Public Sub WriteLine(int As Int64)
        If IsUsingVSDebugger = True Then
            Debug.WriteLine(int)
        Else
            WriteToDebugWindow(int.ToString)
        End If
    End Sub

    Public Sub WriteLine(charactor As Char)
        If IsUsingVSDebugger = True Then
            Debug.WriteLine(charactor)
        Else
            WriteToDebugWindow(charactor.ToString)
        End If
    End Sub

    Private Sub WriteToDebugWindow(text As String)
        If DebugWindow.TextBox1.Text = "" Then
            DebugWindow.TextBox1.AppendText(text)
        Else
            DebugWindow.TextBox1.AppendText(vbNewLine & text)
        End If
    End Sub
End Class
