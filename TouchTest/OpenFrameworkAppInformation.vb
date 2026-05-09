Public Class OpenFrameworkAppInformation
    Public ReadOnly AppPath As String
    Public ReadOnly Version As String
    Public ReadOnly Name As String

    Public Sub New()
        Try
            Dim asm As Reflection.Assembly = Reflection.Assembly.LoadFrom("Test")

            ' Find all types that implement OpenFramework_Interface
            For Each t In asm.GetTypes()
                If GetType(OpenFramework_Interface).IsAssignableFrom(t) AndAlso Not t.IsInterface AndAlso Not t.IsAbstract Then
                    Try
                        Dim plugin As OpenFramework_Interface = CType(Activator.CreateInstance(t), OpenFramework_Interface)


                        'plugins.Add(plugin)
                    Catch ex As Exception
                        UI.ShowError(ex.Message)
                        Debug.WriteLine(ex.Message)
                    End Try
                End If
            Next
        Catch Exceptionthing As Exception
            UI.ShowError(Exceptionthing.Message)
            Debug.WriteLine(Exceptionthing.Message)
        End Try
    End Sub


End Class
