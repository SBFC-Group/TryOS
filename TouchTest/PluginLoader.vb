Imports System.IO
Imports System.Reflection
Imports Test

Public Class PluginLoader
    Public Shared Function LoadPlugins(folderPath As String) As List(Of IPlugin)
        Dim plugins As New List(Of IPlugin)()

        If Directory.Exists(folderPath) Then
            Dim dllFiles = Directory.GetFiles(folderPath, "*.dll")

            For Each dll In dllFiles
                Dim asm = Assembly.LoadFrom(dll)

                For Each type In asm.GetTypes()
                    If GetType(IPlugin).IsAssignableFrom(type) AndAlso Not type.IsInterface AndAlso Not type.IsAbstract Then
                        Dim pluginInstance = CType(Activator.CreateInstance(type), IPlugin)
                        plugins.Add(pluginInstance)
                    End If
                Next
            Next
        End If

        Return plugins
    End Function
End Class
