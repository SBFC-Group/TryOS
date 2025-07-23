Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Namespace HH
    Module Module1
        Public Sub Test()

        End Sub

        Public Function MsgBox(Prompt As Object, Optional Buttons As MsgBoxStyle = MsgBoxStyle.OkOnly, Optional Title As Object = Nothing) As MsgBoxResult
            Dim text As String = Nothing
            Dim win32Window As IWin32Window = Nothing
            Dim vbhost As IVbHost = HostServices.VBHost
            If vbhost IsNot Nothing Then
                win32Window = vbhost.GetParentWindow()
            End If
            If (Buttons And CType(15, MsgBoxStyle)) > MsgBoxStyle.RetryCancel OrElse (Buttons And CType(240, MsgBoxStyle)) > MsgBoxStyle.Information OrElse (Buttons And CType(3840, MsgBoxStyle)) > MsgBoxStyle.DefaultButton3 Then
                Buttons = MsgBoxStyle.OkOnly
            End If
            Try
                If Prompt IsNot Nothing Then
                    text = CStr(Conversions.ChangeType(Prompt, GetType(String)))
                End If
            Catch ex As StackOverflowException
                Throw ex
            Catch ex2 As OutOfMemoryException
                Throw ex2
            Catch ex4 As Exception
                Throw New ArgumentException(Utils.GetResourceString("Argument_InvalidValueType2", New String() {"Prompt", "String"}))
            End Try
            Dim text2 As String
            Try
                If Title Is Nothing Then
                    If vbhost Is Nothing Then
                        text2 = GetTitleFromAssembly(Assembly.GetCallingAssembly())
                    Else
                        text2 = vbhost.GetWindowTitle()
                    End If
                Else
                    text2 = Conversions.ToString(Title)
                End If
            Catch ex5 As StackOverflowException
                Throw ex5
            Catch ex6 As OutOfMemoryException
                Throw ex6
            Catch ex8 As Exception
                Throw New ArgumentException(Utils.GetResourceString("Argument_InvalidValueType2", New String() {"Title", "String"}))
            End Try
            Return CType(MessageBox.Show(win32Window, text, text2, CType((Buttons And CType(15, MsgBoxStyle)), MessageBoxButtons), CType((Buttons And CType(240, MsgBoxStyle)), MessageBoxIcon), CType((Buttons And CType(3840, MsgBoxStyle)), MessageBoxDefaultButton), CType((Buttons And CType((-4096), MsgBoxStyle)), MessageBoxOptions)), MsgBoxResult)
        End Function

        Public Enum MsgBoxResult

            Ok = 1

            Cancel

            Abort

            Retry


            Ignore


            Yes

            No
        End Enum

        Public Enum MsgBoxStyle

            OkOnly = 0

            OkCancel = 1

            AbortRetryIgnore = 2

            YesNoCancel = 3

            YesNo = 4

            RetryCancel = 5

            Critical = 16

            Question = 32

            Exclamation = 48

            Information = 64

            DefaultButton1 = 0

            DefaultButton2 = 256

            DefaultButton3 = 512

            ApplicationModal = 0

            SystemModal = 4096

            MsgBoxHelp = 16384

            MsgBoxRight = 524288

            MsgBoxRtlReading = 1048576

            MsgBoxSetForeground = 65536
        End Enum

        Private Function GetTitleFromAssembly(CallingAssembly As Assembly) As String
            Dim text As String
            Try
                text = CallingAssembly.GetName().Name
            Catch ex As SecurityException
                Dim fullName As String = CallingAssembly.FullName
                Dim num As Integer = fullName.IndexOf(","c)
                If num >= 0 Then
                    text = fullName.Substring(0, num)
                Else
                    text = ""
                End If
            End Try
            Return text
        End Function
    End Module

End Namespace