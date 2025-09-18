Imports System.IO
Imports System.Reflection

Namespace OpenFramework_Data
    Module OpenFramework
        Public Sub LoadApps()
            Dim pluginPath As String = Path.Combine(Application.StartupPath, "Apps")
            Dim plugins = LoadPlugins(pluginPath)

            For Each plugin In plugins
                plugin.UISubs(UI)
                Debug.WriteLine("Loaded " & plugin.Name)
            Next
        End Sub


        Public Function LoadPlugins(folderPath As String) As List(Of OpenFramework_Interface)
            Dim plugins As New List(Of OpenFramework_Interface)()

            If Directory.Exists(folderPath) Then
                Dim dllFiles = Directory.GetFiles(folderPath, "*.dll")

                For Each dll In dllFiles
                    Dim asm = Assembly.LoadFrom(dll)

                    For Each type In asm.GetTypes()
                        If GetType(OpenFramework_Interface).IsAssignableFrom(type) AndAlso Not type.IsInterface AndAlso Not type.IsAbstract Then
                            Dim pluginInstance = CType(Activator.CreateInstance(type), OpenFramework_Interface)
                            plugins.Add(pluginInstance)
                        End If
                    Next
                Next
            End If

            Return plugins
        End Function
    End Module
End Namespace
