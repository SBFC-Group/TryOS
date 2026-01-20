Imports System.IO
Imports System.Reflection

Namespace OpenFramework_Data
    Module OpenFramework

        Public Function GetOpenFrameworkVersion()
            Return "0.35.4"
        End Function

        Public FlowLayoutPanelUse As FlowLayoutPanel = Form1.FlowLayoutPanel1

        Public Sub SetNewFlowLayoutPanel(FlowLayoutPanelThing As FlowLayoutPanel)
            FlowLayoutPanelUse = FlowLayoutPanelThing
        End Sub

        Dim host As New OpenFramework_Handler()

        Public Sub LoadApps(User As UserManager)
            If My.Computer.FileSystem.DirectoryExists(User.UserFolderPath & "\Apps") Then


                Try
                    Dim plugins = LoadAppsDlls(User)

                    For Each p In plugins
                        Try
                            Debug.WriteLine("Loaded App: " & p.Name)
                            p.Initialize(host)
                            Dim btn As New Button()
                            btn.Name = p.Name
                            btn.BackgroundImage = p.Icon
                            btn.FlatStyle = FlatStyle.Flat
                            btn.FlatAppearance.BorderSize = 0
                            btn.BackgroundImageLayout = ImageLayout.Stretch
                            btn.Tag = p
                            btn.Size = Form1.Button3.Size
                            AddHandler btn.Click, AddressOf PluginButton_Click
                            FlowLayoutPanelUse.Controls.Add(btn)
                        Catch ex As Exception
                            UI.ShowError("Error Loading App.")
                        End Try
                    Next
                Catch ex As Exception
                    UI.ShowError("Someting has changed to make your app not work.")
                End Try
            Else
                UI.ShowError("Apps Folder does not exist.")
            End If
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

        Public Sub SaveButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing)
            Dim order As New List(Of String)
            If AllowCustom = True Then
                For Each ctrl As Control In ControlThing.Controls
                    order.Add(ctrl.Tag.ToString())
                Next
            Else
                For Each ctrl As Control In Form1.FlowLayoutPanel1.Controls
                    order.Add(ctrl.Tag.ToString())
                Next
            End If
            IO.File.WriteAllText(Form1.User.UserFolderPath & "\Settings\Taskbar_Order.json", Newtonsoft.Json.JsonConvert.SerializeObject(order))
        End Sub

        Public Sub RestoreButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing)
            If AllowCustom = False Then
                ControlThing = Form1.FlowLayoutPanel1
            End If

            Dim path As String = Form1.User.UserFolderPath & "\Settings\Taskbar_Order.json"
            If IO.File.Exists(path) Then
                Dim order = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(IO.File.ReadAllText(path))
                Dim sortedButtons As New List(Of Control)

                For Each id In order
                    Dim match = ControlThing.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Tag.ToString() = id)
                    If match IsNot Nothing Then
                        sortedButtons.Add(match)
                    End If
                Next

                ' Add any new buttons not in saved list
                For Each c In ControlThing.Controls.Cast(Of Control)()
                    If Not sortedButtons.Contains(c) Then
                        sortedButtons.Add(c)
                    End If
                Next

                ControlThing.Controls.Clear()
                ControlThing.Controls.AddRange(sortedButtons.ToArray())
            End If
        End Sub

        Public Function LoadAppsDlls(User As UserManager) As List(Of OpenFramework_Interface)

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
                    Dim ContinueThis As Boolean = False

                    If My.Computer.FileSystem.FileExists(Path & "\DllPath.txt") = True Then
                        DllPath = My.Computer.FileSystem.ReadAllText(Path & "\DllPath.txt")
                        If My.Computer.FileSystem.FileExists(DllPath) = True Then
                            ContinueThis = True
                        Else
                            UI.ShowError("Can't find this app due to no existing dll to load.")
                            ContinueThis = False
                        End If
                    Else
                        If My.Computer.FileSystem.FileExists(Path & "\Main.dll") = True Then
                            DllPath = Path & "\Main.dll"
                            ContinueThis = True
                        Else
                            UI.ShowError("Can't find this app due to no existing dll to load.")
                            ContinueThis = False
                        End If

                    End If


                    If ContinueThis = True Then
                        'For Each dll In IO.Directory.GetFiles(folder, "*.dll")
                        Dim asm As Assembly = Assembly.LoadFrom(DllPath)

                        ' Find all types that implement OpenFramework_Interface
                        For Each t In asm.GetTypes()
                            If GetType(OpenFramework_Interface).IsAssignableFrom(t) AndAlso Not t.IsInterface AndAlso Not t.IsAbstract Then
                                Dim plugin As OpenFramework_Interface = CType(Activator.CreateInstance(t), OpenFramework_Interface)
                                plugins.Add(plugin)
                            End If
                        Next
                    End If
                End If

            Next

            Return plugins
        End Function
    End Module
End Namespace
