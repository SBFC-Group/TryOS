Imports System.Windows.Forms
Imports System.Drawing
Imports TouchTest

Public Class MyControllerForm
    'This won't ever open

    Public Shared PCC As PCContentMenu_NoneApp
    Public Shared PCC_TaskInteracter As PCContentMenu_NoneApp
    Public Shared TaskInteracter_Panel As TaskInteracter = New TaskInteracter
    Public Bo1 As Boolean 'If true then PCC loads
    Public Bo2 As Boolean 'If true then TaskInteracter loads
    Public Bo3 As Boolean 'If true then use newer Wallpaper loader
    Public Bo4 As Boolean 'if true then PCC For TaskInteracter loads

    Public Sub LoadEverything()
        'Stops ShellGUI from Loading when on Login Screen
        If Main.UI.LogonBool = True Then
            Return
        End If

        'This is Main Context Menu.
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\ShellGUI.PCC.txt") Then
            Bo1 = True
        Else
            Bo1 = False
        End If

        'This is the TaskInteractor.
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\ShellGUI.TaskInteracter.txt") Then
            Bo2 = True
        Else
            Bo2 = False
        End If

        'This part loads the wallpaper the newer way.
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\ShellGUI=TouchTest.Form1.txt") Then
            Bo3 = True
        Else
            Bo3 = False
        End If

        'This is the Context Menu that used on the TaskInteractor
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\ShellGUI.PCC=TaskInteracter.txt") Then
            Bo4 = True
        Else
            Bo4 = False
        End If

        '----------------------------------------------------------------


        If Bo1 = True Then
            LoadMainContextMenu()
        End If

        If Bo2 = True Then
            LoadTaskInteracter()
        End If

        If Bo3 = True Then
            If Main.Form1.User.DoesSettingExist("IsUsingNewerWallpaperLoader=True") = True Then
                If My.Computer.FileSystem.FileExists(Main.Form1.User.UserFolderPath & "\Settings\WallpaperImage.swfiles") Then
                    Dim WallpaperImagePath As String = My.Computer.FileSystem.ReadAllText(Main.Form1.User.UserFolderPath & "\Settings\WallpaperImage.swfiles")
                    Try
                        Dim b As Byte() = Convert.FromBase64String(WallpaperImagePath)
                        WallpaperImagePath = System.Text.Encoding.UTF8.GetString(b)
                        Dim b2 As Byte() = Convert.FromBase64String(WallpaperImagePath)
                        WallpaperImagePath = System.Text.Encoding.UTF8.GetString(b2)
                    Catch ex As Exception
                        Main.UI.ShowError(ex.Message)
                    End Try
                    Main.UI.RunCommands("SetWallpaper " & WallpaperImagePath, Main.Form1.User)

                End If
            End If
        End If

        If Bo4 = True Then
            LoadContextMenuTaskInteractor()
        End If
    End Sub

    Public Overloads Sub Show()
        Debug.WriteLine("This would open this form")
    End Sub

    Public Overloads Sub Close()
        Debug.WriteLine("This would close this form")
    End Sub

    'Newer Code (1.2)

#Region "Main Context Menu"

    Public Shared IsPCCHere As Boolean = False

    Public Sub LoadMainContextMenu()
        PCC = New PCContentMenu_NoneApp

        PCC.IsContextMenuBase = True
        PCC.LoadProgramButtons()

        For Each c As Control In TaskInteracter_Panel.FlowLayoutPanel1.Controls
            AddHandler c.MouseDown, AddressOf MouseDown_Menu_TaskInteracter_3_0
        Next

        AddHandler TaskInteracter_Panel.FlowLayoutPanel1.MouseDown, AddressOf MouseDown_Menu_TaskInteracter_3_0

        PCC.BackColor = Color.FromArgb(55, Color.DarkGray)

        PCC.Visible = False

        ConfigformForMainContextMenu(Main.Form1)
    End Sub

    Private Sub MouseDown_Menu_TaskInteracter_3_0(sender As Object, e As MouseEventArgs)
        'PCC_TaskInteracter.Visible = False
        PCC.Visible = False
    End Sub

    Private Sub ConfigformForMainContextMenu(parent As Control)
        For Each c As Control In parent.Controls
            If c.Name = "Panel1" Then
                c.Controls.Add(PCC)
                PCC.BringToFront()
                ConfigformForMainContextMenu(c)
            ElseIf c.Name = "Panel3" Then
                AddHandler c.MouseDown, AddressOf MouseDown_Menu
            End If
        Next
    End Sub

    'PCC Controls this
    Private Sub MouseDown_Menu(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            IsPCCHere = True

            PCC.Location = New Drawing.Point(e.Location.X, e.Location.Y + 35)
            PCC.Visible = True

            If PCC_TaskInteracter.Visible = True Then
                IsPCC_TaskInteracterHere = False
                PCC_TaskInteracter.Visible = False
            End If
        ElseIf e.Button = MouseButtons.Left Then
            IsPCCHere = False

            PCC.Visible = False

            If PCC_TaskInteracter.Visible = True Then
                IsPCC_TaskInteracterHere = False
                PCC_TaskInteracter.Visible = False
            End If
        End If
    End Sub
#End Region

#Region "Context Menu TaskInteractor"

    Public Shared IsPCC_TaskInteracterHere As Boolean = False

    Public Form1_Panel2_Y As Int64 = 0
    Public Form1_Panel2_X As Int64 = 0

    Public Sub LoadContextMenuTaskInteractor()
        PCC_TaskInteracter = New PCContentMenu_NoneApp

        ConfigformForContextMenuTaskInteractor(Main.Form1)

        SetsInfo(Main.Form1)

        PCC_TaskInteracter.IsContextMenuBase = False

        PCC_TaskInteracter.AddItemToMenu("MoveBackItem", "Refresh", Sub()
                                                                        Main.Controller.OpenFramework_RestoreButtonOrder(False)
                                                                    End Sub)

        PCC_TaskInteracter.AddItemToMenu("MoveBackItem", "< Move Back", Sub()
                                                                            Try
                                                                                Dim btn As Button = CType(PCC_TaskInteracter.Tag, Button)
                                                                                If TaskInteracter_Panel.FlowLayoutPanel1.Controls.IndexOf(btn) - 1 = -1 Then
                                                                                    Return
                                                                                End If
                                                                                TaskInteracter_Panel.FlowLayoutPanel1.Controls.SetChildIndex(btn, TaskInteracter_Panel.FlowLayoutPanel1.Controls.IndexOf(btn) - 1)
                                                                            Catch ex As Exception
                                                                            End Try
                                                                        End Sub)
        PCC_TaskInteracter.AddItemToMenu("MoveForwardItem", "Move Forward >", Sub()
                                                                                  Try
                                                                                      Dim btn As Button = CType(PCC_TaskInteracter.Tag, Button)
                                                                                      If TaskInteracter_Panel.FlowLayoutPanel1.Controls.IndexOf(btn) + 1 = TaskInteracter_Panel.FlowLayoutPanel1.Controls.Count Then
                                                                                          Return
                                                                                      End If
                                                                                      TaskInteracter_Panel.FlowLayoutPanel1.Controls.SetChildIndex(btn, TaskInteracter_Panel.FlowLayoutPanel1.Controls.IndexOf(btn) + 1)
                                                                                  Catch ex As Exception
                                                                                  End Try
                                                                              End Sub)

        For Each c As Control In TaskInteracter_Panel.FlowLayoutPanel1.Controls
            AddHandler c.MouseDown, AddressOf MouseDown_Menu_TaskInteracter
        Next

        AddHandler TaskInteracter_Panel.FlowLayoutPanel1.MouseDown, AddressOf MouseDown_Menu_TaskInteracter_2_0

        PCC_TaskInteracter.BackColor = Color.FromArgb(55, Color.DarkGray)

        PCC_TaskInteracter.Visible = False
    End Sub

    Private Sub MouseDown_Menu_TaskInteracter_2_0(sender As Object, e As MouseEventArgs)
        PCC_TaskInteracter.Visible = False
        'PCC.Visible = False
    End Sub

    Private Sub ConfigformForContextMenuTaskInteractor(parent As Control)
        For Each c As Control In parent.Controls
            If c.Name = "Panel1" Then
                c.Controls.Add(PCC_TaskInteracter)
                PCC_TaskInteracter.BringToFront()

                ConfigformForContextMenuTaskInteractor(c)
            ElseIf c.Name = "Panel3" Then
                AddHandler c.MouseDown, AddressOf MouseDown_Menu_TaskInteracter_2_0
            End If
        Next
    End Sub

    'PCC_TaskInteracter Controls this
    Private Sub MouseDown_Menu_TaskInteracter(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            'bool that i need to check if PCC_TaskInteracter is open or closed
            IsPCC_TaskInteracterHere = True

            'This does some math that puts the context menu in the right place
            Dim x1 = sender.Location.X - sender.Size.Width
            Dim y1 = Form1_Panel2_Y - PCC_TaskInteracter.Size.Height

            'This stops the Context menu Point X from going lower then 0
            If x1 < -1 Then
                x1 = 0
            End If

            PCC_TaskInteracter.Location = New Drawing.Point(x1, y1)
            PCC_TaskInteracter.Visible = True
            PCC_TaskInteracter.Tag = sender

            If PCC.Visible = True Then
                IsPCCHere = False
                PCC.Visible = False
            End If
        ElseIf e.Button = MouseButtons.Left Then
            IsPCC_TaskInteracterHere = False

            PCC_TaskInteracter.Visible = False

            If PCC.Visible = True Then
                IsPCCHere = False
                PCC.Visible = False
            End If
        End If
    End Sub

    Public Sub SetsInfo(p As Control)
        For Each c As Control In p.Controls
            If c.Name = "Panel2" Then
                Form1_Panel2_Y = c.Location.Y
                Form1_Panel2_X = c.Location.X
            End If
            If c.HasChildren Then SetsInfo(c)
        Next
    End Sub

#End Region

#Region "TaskInteractor"
    Public Shared Sub LoadTaskInteracter()
        Dim P2 As Panel = Main.Form1.Funnything()

        P2.Controls.Add(TaskInteracter_Panel)
        TaskInteracter_Panel.Dock = DockStyle.Fill

        TaskInteracter_Panel.BringToFront()
    End Sub

    Public Shared Sub UnloadTaskInteracter()
        Dim P2 As Panel = Main.Form1.Funnything()

        TaskInteracter_Panel.Dock = DockStyle.None

        P2.Controls.Remove(TaskInteracter_Panel)
    End Sub
#End Region

End Class