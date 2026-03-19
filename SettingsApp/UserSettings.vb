Imports System.Windows.Forms

Public Class UserSettings
    Public UserList As New List(Of String)

    Public SelectedUser As TouchTest.UserManager

    Public Sub LoadUsers()
        Dim FirstUserButtonWasCreated As Boolean = False
        Dim UsersFolder = My.Application.Info.DirectoryPath & "\Users"
        Dim files() As System.IO.DirectoryInfo
        Dim dirinfo As New System.IO.DirectoryInfo(UsersFolder)
        files = dirinfo.GetDirectories("*", IO.SearchOption.TopDirectoryOnly)
        For Each file In files
            'Checks if the user is disabled
            Dim UserMode As String = Nothing
            If My.Computer.FileSystem.FileExists(UsersFolder & "\" & file.Name & "\Settings\UserMode.swfiles") Then
                UserMode = My.Computer.FileSystem.ReadAllText(UsersFolder & "\" & file.Name & "\Settings\UserMode.swfiles")
            End If
            If UserMode = "UserMode=Disabled" Then
            Else

                Dim NewUserButton As New Button
                NewUserButton.FlatStyle = FlatStyle.Flat
                NewUserButton.Size = UserButton0.Size
                NewUserButton.Font = UserButton0.Font
                NewUserButton.BackColor = UserButton0.BackColor
                NewUserButton.Text = file.Name
                NewUserButton.Tag = New TouchTest.UserManager(file.Name, False)
                If FirstUserButtonWasCreated = True Then
                    FlowLayoutPanel1.Size = New Drawing.Size(FlowLayoutPanel1.Width, FlowLayoutPanel1.Height + NeedThisPanel.Height)
                Else
                    FirstUserButtonWasCreated = True
                End If
                FlowLayoutPanel1.Controls.Add(NewUserButton)
                End If

        Next
    End Sub

    Private Sub UserSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub
End Class
