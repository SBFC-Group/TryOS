Public Class UserInfoHelper
    Public Shared Function GetUserInfo(Username As String, UserData As UserDataTypes, Optional Password As String = "Null")
        If UserData = UserDataTypes.Password Then

        ElseIf UserData = UserDataTypes.Pincode Then
            'Password is only needed for this.

        ElseIf UserData = UserDataTypes.Path Then

        End If
    End Function

    Public Enum UserDataTypes
        Username = 1
        Password = 2
        Pincode = 3
        Path = 4
    End Enum

    Public Function CreateNewUser(Username As String, Password As String, Pincode As String, Optional Role As TryController.Roles = TryController.Roles.Standard) As Boolean
        If My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\" & Username) Then
            MsgBox("This User already exists.")
        ElseIf My.Computer.FileSystem.DirectoryExists(UI.UsersFolder & "\Dev") Then
            MsgBox("This User is not allowed.")
        Else
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & Username)
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & Username & "\Apps")
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & Username & "\Settings")
            My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & Username & "\Temp")

            Dim ReaderForPassword As String = Password



            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
            ReaderForPassword = Convert.ToBase64String(byt)
            Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
            ReaderForPassword = Convert.ToBase64String(byt2)

            If Password = "" Then
                ReaderForPassword = "VkY5b1gybGZjMTlWWDNOZlpWOXlYMGhmWVY5elgwNWZiMTkwWDJoZmFWOXVYMmM9"
            End If

            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & Username & "\Settings\Password.swfiles", ReaderForPassword, False)
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & Username & "\Settings\Role.swfiles", "VkRCU1RrNUZNVFpXV0hCUVZrVnJPUT09", False)
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & Username & "\Settings\Wallpaper.swfiles", "jpg=1", False)

            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & Username & "\Apps\Internet++.swfiles", "", False)
        End If
    End Function
End Class
