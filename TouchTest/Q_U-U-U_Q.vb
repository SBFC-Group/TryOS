Imports System.IO
Imports System.Reflection

Public Class Q_U_U_U_Q
    Public Sub C_load_Q()
        Dim pluginPath As String = Path.Combine(Application.StartupPath, "Plugins")
        Dim plugins = LoadPlugins(pluginPath)

        For Each plugin In plugins
            MsgBox("Loaded plugin: " & plugin.Name)
            plugin.ExecuteDebug(Form1)
        Next
    End Sub


    Public Shared Function LoadPlugins(folderPath As String) As List(Of Q_U_U_U_Q_I)
        Dim plugins As New List(Of Q_U_U_U_Q_I)()

        If Directory.Exists(folderPath) Then
            Dim dllFiles = Directory.GetFiles(folderPath, "*.dll")

            For Each dll In dllFiles
                Dim asm = Assembly.LoadFrom(dll)

                For Each type In asm.GetTypes()
                    If GetType(Q_U_U_U_Q_I).IsAssignableFrom(type) AndAlso Not type.IsInterface AndAlso Not type.IsAbstract Then
                        Dim pluginInstance = CType(Activator.CreateInstance(type), Q_U_U_U_Q_I)
                        plugins.Add(pluginInstance)
                    End If
                Next
            Next
        End If

        Return plugins
    End Function

End Class
