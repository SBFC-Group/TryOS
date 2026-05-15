Imports System.IO
Imports System.Reflection

Namespace OpenFramework_Data
    Public Class OpenFramework

        Public Shared Function GetOpenFrameworkVersion()
            Return "0.36.0"
        End Function

        Public Shared FlowLayoutPanelUse As FlowLayoutPanel = Form1.FlowLayoutPanel1

        Public Shared Sub SetNewFlowLayoutPanel(FlowLayoutPanelThing As FlowLayoutPanel)
            FlowLayoutPanelUse = FlowLayoutPanelThing
        End Sub

        Private Shared host As New OpenFramework_Handler()

        Public Shared Sub LoadApps(User As UserManager)
            If My.Computer.FileSystem.DirectoryExists(UI.AppsFolder) Then
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
                    UI.ShowError("Something has changed to make your app not work.")
                End Try
            Else
                UI.ShowError("Apps Folder does not exist.")
            End If
        End Sub

        Public Shared AppName As String

        Private Shared Sub PluginButton_Click(sender As Object, e As EventArgs)
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

        Public Shared Sub SaveButtonOrder(Optional ControlThing As Control = Nothing)
            If ControlThing IsNot Nothing Then
                SaveButtonOrder(True, ControlThing)
            Else
                SaveButtonOrder(False, Nothing)
            End If
        End Sub

        Public Shared Sub SaveButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing)
            Dim order As New List(Of String)
            If AllowCustom = True Then
                For Each ctrl As Control In ControlThing.Controls
                    order.Add(ctrl.Tag.ToString())
                Next
            Else
                For Each ctrl As Control In FlowLayoutPanelUse.Controls
                    order.Add(ctrl.Tag.ToString())
                Next
            End If
            If IO.File.Exists(Form1.User.UserFolderPath & "\Settings\TaskInteracter_Order.json") Then
                IO.File.WriteAllText(Form1.User.UserFolderPath & "\Settings\TaskInteracter_Order.json", Newtonsoft.Json.JsonConvert.SerializeObject(order))
            Else
                IO.File.WriteAllText(Form1.User.UserFolderPath & "\Settings\Taskbar_Order.json", Newtonsoft.Json.JsonConvert.SerializeObject(order))
            End If

        End Sub

        Public Shared Sub RestoreButtonOrder(Optional ControlThing As Control = Nothing)
            If ControlThing IsNot Nothing Then
                RestoreButtonOrder(True, ControlThing)
            Else
                RestoreButtonOrder(False, Nothing)
            End If
        End Sub

        Public Shared Sub RestoreButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing)
            If AllowCustom = False Then
                ControlThing = FlowLayoutPanelUse
            End If



            Dim path As String = Form1.User.UserFolderPath & "\Settings\Taskbar_Order.json"

            If IO.File.Exists(path) = False Then
                If IO.File.Exists(Form1.User.UserFolderPath & "\Settings\TaskInteracter_Order.json") Then
                    path = Form1.User.UserFolderPath & "\Settings\TaskInteracter_Order.json"
                End If
            End If

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



        Public Shared Function LoadAppsDlls(User As UserManager) As List(Of OpenFramework_Interface)

            Dim InDevMode As Boolean = False
            If Environment.CommandLine.Contains("/DevMode") = True Then
                InDevMode = True
                Debug.WriteLine("Function Name: LoadAppsDlls()")
            End If

            Dim plugins As New List(Of OpenFramework_Interface)()

            Dim dir1 = My.Application.Info.DirectoryPath & "\Apps"

            If My.Computer.FileSystem.DirectoryExists(dir1) = False Then
                If InDevMode = True Then
                    Debug.WriteLine(dir1 & " Does not exist or you don't own the folder.")
                End If
                Return Nothing
            End If

            Dim files() As System.IO.DirectoryInfo
            Dim dirinfo As New System.IO.DirectoryInfo(dir1)
            files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)
            For Each file In files
                If InDevMode = True Then
                    Debug.WriteLine($"Apps Folder Name: {file.Name}")
                End If

                Dim Path As String = ""

                Path = file.FullName

                If Not IO.Directory.Exists(Path) Then
                    Debug.WriteLine(Path & " Does not exist or you don't own the folder.")
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


                        Try
                            Dim asm As Assembly = Assembly.LoadFrom(DllPath)



                            ' Find all types that implement OpenFramework_Interface
                            For Each t In asm.GetTypes()


                                If GetType(OpenFramework_Interface).IsAssignableFrom(t) AndAlso Not t.IsInterface AndAlso Not t.IsAbstract Then
                                    Try
                                        Dim plugin As OpenFramework_Interface = CType(Activator.CreateInstance(t), OpenFramework_Interface)
                                        plugins.Add(plugin)
                                    Catch ex As Exception
                                        UI.ShowError(ex.Message)
                                        If Environment.CommandLine.Contains("/DevMode") = True Then
                                            Debug.WriteLine(ex.Message)
                                        End If
                                    End Try
                                End If
                            Next
                        Catch Exceptionthing As Exception
                            UI.ShowError(Exceptionthing.Message)
                            If Environment.CommandLine.Contains("/DevMode") = True Then
                                Debug.WriteLine(Exceptionthing.Message)
                            End If
                        End Try

                    End If
                End If

            Next

            Return plugins
        End Function
    End Class
End Namespace
