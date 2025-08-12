Imports System.Windows.Forms
Public Class UserController
    Public Shared Sub CreateUser(Username As String, Password As String)
        Dim TextBox1 As TextBox
        Dim TextBox2 As TextBox
        TextBox1.Text = Username
        TextBox2.Text = Password
        My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text)
        My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Apps")
        My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Settings")
        My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Temp")

        Dim ReaderForPassword As String = TextBox2.Text

        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
        ReaderForPassword = Convert.ToBase64String(byt)
        Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
        ReaderForPassword = Convert.ToBase64String(byt2)

        If TextBox2.Text = "" Then
            ReaderForPassword = "VkY5b1gybGZjMTlWWDNOZlpWOXlYMGhmWVY5elgwNWZiMTkwWDJoZmFWOXVYMmM9"
        End If

        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Password.swfiles", ReaderForPassword, False)
        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Role.swfiles", "Vkd0U1RrMXJNVFphZWtKUFlXdHJPUT09", False)
        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Wallpaper.swfiles", "jpg=1", False)

        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Apps\Internet++.swfiles", "", False)
    End Sub

    Public Shared Sub CreateUser(Username As String, Password As String, PinCode As String)
        Dim TextBox1 As New TextBox
        Dim TextBox2 As New TextBox
        TextBox1.Text = Username
        TextBox2.Text = Password
        My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text)
        My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Apps")
        My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Settings")
        My.Computer.FileSystem.CreateDirectory(UI.UsersFolder & "\" & TextBox1.Text & "\Temp")

        Dim ReaderForPassword As String = TextBox2.Text

        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
        ReaderForPassword = Convert.ToBase64String(byt)
        Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(ReaderForPassword)
        ReaderForPassword = Convert.ToBase64String(byt2)

        If TextBox2.Text = "" Then
            ReaderForPassword = "VkY5b1gybGZjMTlWWDNOZlpWOXlYMGhmWVY5elgwNWZiMTkwWDJoZmFWOXVYMmM9"
        End If

        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Password.swfiles", ReaderForPassword, False)
        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Role.swfiles", "Vkd0U1RrMXJNVFphZWtKUFlXdHJPUT09", False)
        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Wallpaper.swfiles", "jpg=1", False)

        My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Apps\Internet++.swfiles", "", False)

        If PinCode = "None" Then
        ElseIf PinCode = "" Then
        ElseIf PinCode.Length < 4 Then
        Else
            Dim ThePin As String = PinCode
            Dim byt3 As Byte() = System.Text.Encoding.UTF8.GetBytes(ThePin)
            ThePin = Convert.ToBase64String(byt3)
            Dim byt4 As Byte() = System.Text.Encoding.UTF8.GetBytes(ThePin)
            ThePin = Convert.ToBase64String(byt4)
            My.Computer.FileSystem.WriteAllText(UI.UsersFolder & "\" & TextBox1.Text & "\Settings\Pincode.swfiles", ThePin, False)

            My.Computer.FileSystem.WriteAllText(UI.SettingsFolder & "\AutoUser.setting", TextBox1.Text, False)
        End If
    End Sub
End Class
