Imports System.Windows.Forms
Imports System.Drawing
Imports TouchTest

Public Class MyControllerForm
    'This will won't ever open

    Public Shared PCC As PCContentMenu_NoneApp = New PCContentMenu_NoneApp
    Public Shared PCC_TaskInteracter As PCContentMenu_NoneApp = New PCContentMenu_NoneApp
    Public Shared TaskInteracter_Panel As TaskInteracter = New TaskInteracter
    Public Bo1 As Boolean 'If true then PCC loads
    Public Bo2 As Boolean 'If true then TaskInteracter loads
    Public Bo3 As Boolean 'If true then use newer Wallpaper loader
    Public Bo4 As Boolean 'if true then PCC For TaskInteracter loads

    Public Sub LoadEverything()
        If Main.UI.LogonBool = True Then
            Return
        End If

        PCC = New PCContentMenu_NoneApp
        TaskInteracter_Panel = New TaskInteracter
        PCC_TaskInteracter = New PCContentMenu_NoneApp

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\ShellGUI.PCC.txt") Then
            Bo1 = True
        Else
            Bo1 = False
        End If

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\ShellGUI.TaskInteracter.txt") Then
            Bo2 = True
        Else
            Bo2 = False
        End If


        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\ShellGUI=TouchTest.Form1.txt") Then
            Bo3 = True
        Else
            Bo3 = False
        End If

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\ShellGUI.PCC=TaskInteracter.txt") Then
            Bo4 = True
        Else
            Bo4 = False
        End If

        'Trys to load elements inside Form1 (TryOS Shell)
        AddHandlerToAll(Main.Form1)

        'This loads PCC (Context Menu)
        If Bo1 = True Then

            PCC.IsContextMenuBase = True
            PCC.LoadProgramButtons()
            'PCC.BringToFront()

            'Main.Form1.Funnything().BringToFront()

            'BringToFront_Panel3(Main.Form1)

            PCC.BackColor = Color.FromArgb(55, Color.DarkGray)

            PCC.Visible = False
        End If

        'This loads TaskInteracter
        If Bo2 = True Then
            LoadTaskInteracter()
        End If

        'This will load the newer Wallpaper loader
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

        'This loads PCC_TaskInteracter (Context Menu for TaskInteracter)
        If Bo4 = True Then

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
        End If
    End Sub

    Public Form1_Panel2_Y As Int64 = 0
    Public Form1_Panel2_X As Int64 = 0

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

    Private Sub MouseDown_Menu_TaskInteracter_2_0(sender As Object, e As MouseEventArgs)
        PCC_TaskInteracter.Visible = False
        PCC.Visible = False
    End Sub

    Private Sub RemoveHandlerToAll(parent As Control)
        For Each c As Control In parent.Controls

            If c.Name = "Panel3" Then
                If Bo1 = True Then
                    If PCC.Visible = True Then
                        PCC.Visible = False
                    End If
                    RemoveHandler c.MouseDown, AddressOf MouseDown_Menu
                End If
            ElseIf c.Name = "Panel1" Then
                If Bo1 = True Then
                    c.Controls.Remove(PCC)
                End If
            End If

            If c.HasChildren Then AddHandlerToAll(c)
        Next
    End Sub

    Private Sub AddHandlerToAll(parent As Control)
        For Each c As Control In parent.Controls

            If c.Name = "Panel3" Then
                If Bo1 = True Then
                    Debug.WriteLine("Adding PCC Handler ")
                    AddHandler c.MouseDown, AddressOf MouseDown_Menu
                End If
            ElseIf c.Name = "Panel1" Then
                If Bo1 = True Then
                    c.Controls.Add(PCC)
                    PCC.BringToFront()
                End If
                If Bo4 = True Then
                    c.Controls.Add(PCC_TaskInteracter)
                    PCC_TaskInteracter.BringToFront()
                End If
            ElseIf c.Name = "Panel2" Then
                Form1_Panel2_Y = c.Location.Y
                Form1_Panel2_X = c.Location.X

            ElseIf c.Name = "FlowLayoutPanel1" Then
                If Bo1 Then
                    AddHandlerToAppButtons(c)
                End If
            ElseIf c.Name = "Button3" Then
                If Bo1 = True Then
                    AddHandler c.Click, Sub(sender As Object, e As EventArgs)
                                            PCC.Visible = False
                                        End Sub
                End If
                If Bo4 = True Then
                    AddHandler c.Click, Sub(sender As Object, e As EventArgs)
                                            PCC_TaskInteracter.Visible = False
                                        End Sub
                End If
            ElseIf c.Name = "Button4" Then
                If Bo1 = True Then
                    AddHandler c.Click, Sub(sender As Object, e As EventArgs)
                                            If IsPCCHere = True Then
                                                IsPCCHere = False
                                                PCC.Visible = False
                                            End If
                                        End Sub
                End If
                If Bo4 = True Then
                    AddHandler c.Click, Sub(sender As Object, e As EventArgs)
                                            If IsPCC_TaskInteracterHere = True Then
                                                IsPCC_TaskInteracterHere = False
                                                PCC_TaskInteracter.Visible = False
                                            End If
                                        End Sub
                End If
            End If

            If c.HasChildren Then AddHandlerToAll(c)
        Next
    End Sub

    Public Shared IsPCCHere As Boolean = False
    Public Shared IsPCC_TaskInteracterHere As Boolean = False

    Private Sub AddHandlerToAppButtons(parent As Control)
        For Each c As Control In parent.Controls
            If Bo1 = True Then
                AddHandler c.Click, Sub(sender As Object, e As EventArgs)
                                        PCC.Visible = False
                                    End Sub
            End If
            If Bo4 = True Then
                AddHandler c.MouseDown, AddressOf MouseDown_Menu_TaskInteracter
            End If
        Next
    End Sub

    Private Sub MyControllerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandlerToAll(Main.Form1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Public Sub LoadTaskInteracter()
        Dim P2 As Panel = Main.Form1.Funnything()

        P2.Controls.Add(TaskInteracter_Panel)
        TaskInteracter_Panel.Dock = DockStyle.Fill

        TaskInteracter_Panel.BringToFront()
    End Sub

    Public Sub UnloadTaskInteracter()
        Dim P2 As Panel = Main.Form1.Funnything()

        TaskInteracter_Panel.Dock = DockStyle.None

        P2.Controls.Remove(TaskInteracter_Panel)
    End Sub

    Public Overloads Sub Show()
        Debug.WriteLine("This would open this form")
    End Sub

    Public Overloads Sub Close()
        Debug.WriteLine("This would close this form")
    End Sub
End Class