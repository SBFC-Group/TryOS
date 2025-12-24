Imports System.Windows.Forms
Imports System.Drawing
Imports TouchTest

Public Class MyControllerForm
    'This will won't ever open

    Public PCC As New PCContentMenu_NoneApp
    Public P2 As Panel
    Public P3 As Panel

    Public Sub LoadEverything()


        AddHandlerToAll(Main.Form1)

        PCC.BringToFront()



        Main.Form1.Funnything().BringToFront()

        PCC.BackColor = Color.FromArgb(55, Color.DarkGray)

        PCC.Visible = False

        OpenTaskInteracter(Main.Form1.Funnything())

    End Sub

    Private Sub MouseDown_Menu(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            'MsgBox("1")
            Dim x1 = e.Location.X
            Dim y1 = e.Location.Y

            y1 = y1 + 35

            PCC.Location = New Drawing.Point(x1, y1)
            PCC.Visible = True
        ElseIf e.Button = MouseButtons.Left Then
            'MsgBox("2")
            PCC.Visible = False
        End If
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
            End If

            If c.HasChildren Then AddHandlerToAll(c)
        Next
    End Sub

    Private Sub MyControllerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandlerToAll(Main.Form1)
    End Sub

    Public currentForm As Form = Nothing
    Public Sub OpenTaskInteracter(PanelElement As Panel)
        Dim childForm As New TaskInteracter

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
End Class