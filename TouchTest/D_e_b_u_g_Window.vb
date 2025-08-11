Imports System.Reflection
Public Class D_e_b_u_g_Window
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
        Else
            RunMethod(TextBox1.Text)
        End If
    End Sub

    Sub RunMethod(fullMethodName As String, ParamArray parameters() As Object)
        Try
            ' Split into type and method name
            Dim parts = fullMethodName.Split("."c)
            If parts.Length <> 2 Then
                Debug.WriteLine("Format must be: TypeName.MethodName")
                Exit Sub
            End If

            Dim typeName As String = parts(0)
            Dim methodName As String = parts(1)

            ' Search for the type in the current assembly
            Dim asm As Assembly = Assembly.GetExecutingAssembly()
            Dim targetType As Type = asm.GetTypes().FirstOrDefault(Function(t) t.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase))

            If targetType Is Nothing Then
                Debug.WriteLine($"Type '{typeName}' not found.")
                Exit Sub
            End If

            ' Search for the method
            Dim methodInfo As MethodInfo = targetType.GetMethod(methodName, BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Static Or BindingFlags.Instance)

            If methodInfo Is Nothing Then
                Debug.WriteLine($"Method '{methodName}' not found in type '{typeName}'.")
                Exit Sub
            End If

            ' If method is not static (Shared), create an instance
            Dim instance As Object = Nothing
            If Not methodInfo.IsStatic Then
                instance = Activator.CreateInstance(targetType)
            End If

            ' Call the method
            methodInfo.Invoke(instance, parameters)

        Catch ex As TargetParameterCountException
            Debug.WriteLine("Parameter count mismatch.")
        Catch ex As Exception
            Debug.WriteLine($"Error running method: {ex.Message}")
        End Try
    End Sub
End Class