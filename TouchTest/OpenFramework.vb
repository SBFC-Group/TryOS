Imports System.IO
Imports System.Reflection

Namespace OpenFramework_Data
    Module OpenFramework

        Public Function GetOpenFrameworkVersion()
            Return "0.35.0"
        End Function

        Dim host As New OpenFramework_Handler()

        Public Sub LoadApps()

            Try
                Dim plugins = LoadPlugins_New()

                For Each p In plugins
                    Debug.WriteLine("Loaded " & p.Name)
                    p.Initialize(host)
                    Dim btn As New Button()
                    'btn.Text = p.Name
                    btn.BackgroundImage = p.Icon
                    'btn.TextImageRelation = TextImageRelation.ImageAboveText
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.BackgroundImageLayout = ImageLayout.Stretch
                    btn.Tag = p
                    btn.Size = New Size(74, 70)
                    'btn.AutoSize = True
                    'btn.AutoSizeMode = AutoSizeMode.GrowAndShrink
                    'btn.Padding = New Padding(5)
                    AddHandler btn.Click, AddressOf PluginButton_Click
                    Form1.FlowLayoutPanel1.Controls.Add(btn)
                Next
            Catch ex As Exception
                UI.ShowError("Is this App updated to this version of OpenFramework.")
            End Try


        End Sub

        Public AppName As String

        Private Sub PluginButton_Click(sender As Object, e As EventArgs)
            Dim btn As Button = CType(sender, Button)
            Dim plugin As OpenFramework_Interface = CType(btn.Tag, OpenFramework_Interface)

            Dim frm As Form = plugin.GetForm()
            If Form1.currentForm IsNot Nothing Then
                If frm.Text = AppName Then
                    Exit Sub
                End If
            End If
            AppName = frm.Text
            frm.Text = plugin.Name
            Form1.OpenChildForm(frm)

        End Sub

        Public Function LoadPlugins_New() As List(Of OpenFramework_Interface)

            Dim plugins As New List(Of OpenFramework_Interface)()

            Dim dir1 = My.Application.Info.DirectoryPath & "\Apps"
            Dim files() As System.IO.DirectoryInfo
            Dim dirinfo As New System.IO.DirectoryInfo(dir1)
            files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)
            For Each file In files

                Dim Path As String = ""

                Path = file.FullName

                If Not IO.Directory.Exists(Path) Then
                Else
                    Dim DllPath As String = ""

                    If My.Computer.FileSystem.FileExists(Path & "\DllPath.txt") = True Then
                        DllPath = My.Computer.FileSystem.ReadAllText(Path & "\DllPath.txt")
                    Else
                        DllPath = Path & "\Main.dll"
                    End If



                    'For Each dll In IO.Directory.GetFiles(folder, "*.dll")
                    Dim asm As Assembly = Assembly.LoadFrom(DllPath)

                    ' Find all types that implement IPluginForm
                    For Each t In asm.GetTypes()
                        If GetType(OpenFramework_Interface).IsAssignableFrom(t) AndAlso Not t.IsInterface AndAlso Not t.IsAbstract Then
                            Dim plugin As OpenFramework_Interface = CType(Activator.CreateInstance(t), OpenFramework_Interface)
                            plugins.Add(plugin)
                        End If
                    Next
                End If




            Next

            Return plugins

            'Next


        End Function

        Public Function LoadPlugins(folder As String) As List(Of OpenFramework_Interface)
            Dim plugins As New List(Of OpenFramework_Interface)()

            If Not IO.Directory.Exists(folder) Then Return plugins

            For Each dll In IO.Directory.GetFiles(folder, "*.dll")
                Dim asm As Assembly = Assembly.LoadFrom(dll)

                ' Find all types that implement IPluginForm
                For Each t In asm.GetTypes()
                    If GetType(OpenFramework_Interface).IsAssignableFrom(t) AndAlso Not t.IsInterface AndAlso Not t.IsAbstract Then
                        Dim plugin As OpenFramework_Interface = CType(Activator.CreateInstance(t), OpenFramework_Interface)
                        plugins.Add(plugin)
                    End If
                Next
            Next

            Return plugins
        End Function
    End Module
End Namespace
