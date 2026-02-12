Imports System.IO
Imports System.Reflection

Namespace CustomController_Data
    Module CustomController
        Public Host As New CustomController_Handler()

        Public Sub LoadCodeParts()
            Dim pluginPath As String = Path.Combine(Application.StartupPath, "ShellApps")
            Dim plugins = LoadPlugins(pluginPath)

            For Each plugin In plugins
                Dim IsShellCodeVerifyed As Boolean = False

                For Each ShellID As String In UI.ShellAppIDs
                    If ShellID = plugin.VerifyedCode_ID Then
                        IsShellCodeVerifyed = True
                    End If
                Next
                If Environment.CommandLine.Contains(" /TurnOff_VerifyedShellOnly") = True Then
                    IsShellCodeVerifyed = True
                End If
                If Form1.AllowOnlyVerifyedShellCode = False Then
                    IsShellCodeVerifyed = True
                End If
                If IsShellCodeVerifyed = False Then
                    Debug.WriteLine("Verifyed Shell Code Only! Found unverifyed code.")
                Else
                    Debug.WriteLine("Loaded Shell Code by the name of: " & plugin.Name)
                    plugin.Initialize(Host)
                    plugin.ExecuteForm1Subs(Form1)
                    plugin.ExecuteUISubs(UI)
                    plugin.ExecuteTryControllerSubs(TryController)
                    plugin.ConfigFormCollection(My.Application.OpenForms)
                    If plugin.RemoveTaskbar = True Then
                        UI.EnableFullAppMode(True)
                    End If
                End If
            Next
        End Sub

        Public Function LoadPlugins(folderPath As String) As List(Of CustomController_Interface)
            Dim plugins As New List(Of CustomController_Interface)()

            If Directory.Exists(folderPath) Then
                Dim dllFiles = Directory.GetFiles(folderPath, "*.dll")

                For Each dll In dllFiles
                    Dim DontReturn As Boolean = False
                    If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\SBFC Group\CustomController", "DisableShellGUI", Nothing) = "true" Then
                        If dll.Contains("ShellGUI.dll") = True Then
                            DontReturn = True
                        End If
                    End If
                    Dim asm = Assembly.LoadFrom(dll)

                    For Each type In asm.GetTypes()
                        If GetType(CustomController_Interface).IsAssignableFrom(type) AndAlso Not type.IsInterface AndAlso Not type.IsAbstract Then
                            If DontReturn = False Then
                                Dim pluginInstance = CType(Activator.CreateInstance(type), CustomController_Interface)
                                plugins.Add(pluginInstance)
                            End If
                        End If
                    Next
                Next
            End If

            Return plugins
        End Function
    End Module
End Namespace