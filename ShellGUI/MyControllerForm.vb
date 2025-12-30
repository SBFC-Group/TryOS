Imports System.Windows.Forms
Imports System.Drawing
Imports TouchTest

Public Class MyControllerForm
    'This will won't ever open

    Public Shared PCC As New PCContentMenu_NoneApp
    Public Shared TaskInteracter_Panel As New TaskInteracter
    Public Bo1 As Boolean 'If true then PCC loads
    Public Bo2 As Boolean 'If true then TaskInteracter loads

    Public Sub LoadEverything()
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

        'Trys to load elements inside Form1 (Main Window)
        AddHandlerToAll(Main.Form1)

        If Bo1 = True Then
            PCC.BringToFront()

            'Main.Form1.Funnything().BringToFront()

            'BringToFront_Panel3(Main.Form1)

            PCC.BackColor = Color.FromArgb(55, Color.DarkGray)

            PCC.Visible = False
        End If

        If Bo2 = True Then
            LoadTaskInteracter()
        End If

        'OpenTaskInteracter(Main.Form1.Funnything())

    End Sub

    Private Sub MouseDown_Menu(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            IsPCCHere = True
            'MsgBox("1")
            Dim x1 = e.Location.X
            Dim y1 = e.Location.Y

            y1 = y1 + 35

            PCC.Location = New Drawing.Point(x1, y1)
            PCC.Visible = True


        ElseIf e.Button = MouseButtons.Left Then
            IsPCCHere = False
            'MsgBox("2")
            PCC.Visible = False
        End If
    End Sub

    Private Sub BringToFront_Panel3(parent As Control)
        For Each c As Control In parent.Controls
            If c.Name = "Panel3" Then
                c.BringToFront()
            End If
        Next
    End Sub

    Private Sub MyControllerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadEverything()

    End Sub

    Private Sub RemoveHandlerToAll(parent As Control)
        For Each c As Control In parent.Controls

            If c.Name = "Panel3" Then
                If PCC.Visible = True Then
                    PCC.Visible = False
                End If
                RemoveHandler c.MouseDown, AddressOf MouseDown_Menu
            ElseIf c.Name = "Panel1" Then
                c.Controls.Remove(PCC)
            End If

            If c.HasChildren Then AddHandlerToAll(c)
        Next
    End Sub

    Private Sub AddHandlerToAll(parent As Control)
        For Each c As Control In parent.Controls

            If c.Name = "Panel3" Then
                Debug.WriteLine("Adding Handler")
                AddHandler c.MouseDown, AddressOf MouseDown_Menu
            ElseIf c.Name = "Panel1" Then
                c.Controls.Add(PCC)
            ElseIf c.Name = "FlowLayoutPanel1" Then
                AddHandlerToAppButtons(c)
            ElseIf c.Name = "Button3" Then
                AddHandler c.Click, Sub(sender As Object, e As EventArgs)
                                        PCC.Visible = False
                                    End Sub
            ElseIf c.Name = "Button4" Then
                AddHandler c.Click, Sub(sender As Object, e As EventArgs)
                                        If IsPCCHere = True Then
                                            PCC.Visible = True
                                        End If
                                    End Sub
            End If

            If c.HasChildren Then AddHandlerToAll(c)
        Next
    End Sub

    Public Shared IsPCCHere As Boolean = False

    Private Sub AddHandlerToAppButtons(parent As Control)
        For Each c As Control In parent.Controls
            AddHandler c.Click, Sub(sender As Object, e As EventArgs)
                                    PCC.Visible = False
                                End Sub
            If c.HasChildren Then AddHandlerToAll(c)
        Next
    End Sub

    Private Sub MyControllerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandlerToAll(Main.Form1)
    End Sub

    Public currentForm As Form = Nothing
    Public Sub OpenTaskInteracter(PanelElement As Panel)
        Dim childForm As New TaskInteracter_F

        If currentForm IsNot Nothing Then currentForm.Close()
        currentForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        PanelElement.Controls.Add(childForm)
        PanelElement.Tag = childForm
        Try
            childForm.Show()
            childForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

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
End Class