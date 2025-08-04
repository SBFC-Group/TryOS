Public Class ThemeApp
    Public FileFormat As String = "jpg"

    Private Sub ThemeApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DevParts As TryController.Roles = Form1.GetRole()
        If DevParts = TryController.Roles.Developer Then
            Panel3.Visible = True
        End If
        LoadWallpaperPicker()
    End Sub
    ' 62
    Public Sub LoadWallpaperPicker()
        Panel1.Size = New Size(Panel1.Size.Width, 62)
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_1." & FileFormat) Then
            Panel1.Size = New Size(Panel1.Size.Width, 62)
            Wallpaper1ToolStripMenuItem.Visible = True
        Else
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_2." & FileFormat) Then
            Panel1.Size = New Size(Panel1.Size.Width, 92)
            Wallpaper2ToolStripMenuItem.Visible = True
        Else
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_3." & FileFormat) Then
            Panel1.Size = New Size(Panel1.Size.Width, 122)
            Wallpaper3ToolStripMenuItem.Visible = True
        Else
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_4." & FileFormat) Then
            Panel1.Size = New Size(Panel1.Size.Width, 152)
            Wallpaper4ToolStripMenuItem.Visible = True
        Else
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_5." & FileFormat) Then
            Panel1.Size = New Size(Panel1.Size.Width, 182)
            Wallpaper5ToolStripMenuItem.Visible = True
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FileFormat = "png"
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        LoadWallpaperPicker()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FileFormat = "jpg"
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = True
        LoadWallpaperPicker()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FileFormat = "gif"
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        LoadWallpaperPicker()
    End Sub

    Private Sub Wallpaper1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper1ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 1")
            SaveWallpaper(1, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 1")
            SaveWallpaper(1, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 1")
            SaveWallpaper(1, PictureFormat.gif)
        End If

    End Sub
    Private Sub Wallpaper2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper2ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 2")
            SaveWallpaper(2, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 2")
            SaveWallpaper(2, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 2")
            SaveWallpaper(2, PictureFormat.gif)
        End If
    End Sub
    Private Sub Wallpaper3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper3ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 3")
            SaveWallpaper(3, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 3")
            SaveWallpaper(3, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 3")
            SaveWallpaper(3, PictureFormat.gif)
        End If
    End Sub
    Private Sub Wallpaper4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper4ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 4")
            SaveWallpaper(4, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 4")
            SaveWallpaper(4, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 4")
            SaveWallpaper(4, PictureFormat.gif)
        End If
    End Sub
    Private Sub Wallpaper5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper5ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 5")
            SaveWallpaper(5, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 5")
            SaveWallpaper(5, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 5")
            SaveWallpaper(5, PictureFormat.gif)
        End If
    End Sub
    Private Sub Wallpaper6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper6ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 6")
            SaveWallpaper(6, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 6")
            SaveWallpaper(6, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 6")
            SaveWallpaper(6, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper7ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper7ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 7")
            SaveWallpaper(7, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 7")
            SaveWallpaper(7, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 7")
            SaveWallpaper(7, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper8ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper8ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 8")
            SaveWallpaper(8, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 8")
            SaveWallpaper(8, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 8")
            SaveWallpaper(8, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper9ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper9ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 9")
            SaveWallpaper(9, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 9")
            SaveWallpaper(9, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 9")
            SaveWallpaper(9, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper10ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper10ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 10")
            SaveWallpaper(10, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 10")
            SaveWallpaper(10, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 10")
            SaveWallpaper(10, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper11ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper11ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 11")
            SaveWallpaper(11, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 11")
            SaveWallpaper(11, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 11")
            SaveWallpaper(11, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper12ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper12ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 12")
            SaveWallpaper(12, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 12")
            SaveWallpaper(12, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 12")
            SaveWallpaper(12, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper13ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper13ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 13")
            SaveWallpaper(13, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 13")
            SaveWallpaper(13, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 13")
            SaveWallpaper(13, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper14ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper14ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 14")
            SaveWallpaper(14, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 14")
            SaveWallpaper(14, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 14")
            SaveWallpaper(14, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper15ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper15ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 15")
            SaveWallpaper(15, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 15")
            SaveWallpaper(15, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 15")
            SaveWallpaper(15, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper16ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper16ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 16")
            SaveWallpaper(16, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 16")
            SaveWallpaper(16, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 16")
            SaveWallpaper(16, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper17ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper17ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 17")
            SaveWallpaper(17, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 17")
            SaveWallpaper(17, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 17")
            SaveWallpaper(17, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper18ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper18ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 18")
            SaveWallpaper(18, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 18")
            SaveWallpaper(18, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 18")
            SaveWallpaper(18, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper19ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper19ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 19")
            SaveWallpaper(19, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 19")
            SaveWallpaper(19, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 19")
            SaveWallpaper(19, PictureFormat.gif)
        End If
    End Sub

    Private Sub Wallpaper20ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wallpaper20ToolStripMenuItem.Click
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg 20")
            SaveWallpaper(20, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng 20")
            SaveWallpaper(20, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif 20")
            SaveWallpaper(20, PictureFormat.gif)
        End If
    End Sub

    Private Sub SaveWallpaper(Number As Int64, Format As PictureFormat)
        Dim FileFormat As String = ""
        If Format = PictureFormat.jpg Then
            FileFormat = "jpg"
        ElseIf Format = PictureFormat.png Then
            FileFormat = "png"
        ElseIf Format = PictureFormat.gif Then
            FileFormat = "gif"
        End If

        Dim TheNumber As String = Number.ToString

        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Users\" & Form1.Username & "\Settings\Wallpaper.swfiles", FileFormat & "=" & TheNumber, False)
    End Sub

    Private Enum PictureFormat
        jpg = 1
        png = 2
        gif = 3
    End Enum

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Form1.IsUsingDarkThemeForApps = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Color.Gray
            Button2.BackColor = Color.DarkGray
            Button3.BackColor = Color.DarkGray
            Button4.BackColor = Color.DarkGray
            Button5.BackColor = Color.DarkGray
            Button6.BackColor = Color.DarkGray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray
            Button2.BackColor = Color.Gainsboro
            Button3.BackColor = Color.Gainsboro
            Button4.BackColor = Color.Gainsboro
            Button5.BackColor = Color.Gainsboro
            Button6.BackColor = Color.Gainsboro

        End If
    End Sub

    Private Sub WallpaperButton1_Click(sender As Object, e As EventArgs) Handles WallpaperButton1.Click, WallpaperButton2.Click, WallpaperButton3.Click, WallpaperButton4.Click, WallpaperButton5.Click, WallpaperButton6.Click, WallpaperButton7.Click, WallpaperButton8.Click, WallpaperButton9.Click, WallpaperButton10.Click, WallpaperButton11.Click, WallpaperButton12.Click, WallpaperButton13.Click, WallpaperButton14.Click, WallpaperButton15.Click, WallpaperButton16.Click, WallpaperButton17.Click, WallpaperButton18.Click, WallpaperButton19.Click, WallpaperButton20.Click, WallpaperButton21.Click, WallpaperButton22.Click, WallpaperButton23.Click, WallpaperButton24.Click, WallpaperButton25.Click, WallpaperButton26.Click, WallpaperButton27.Click, WallpaperButton28.Click, WallpaperButton29.Click, WallpaperButton30.Click, WallpaperButton31.Click, WallpaperButton32.Click, WallpaperButton33.Click
        Dim WallpaperText As String = sender.Name
        MsgBox(WallpaperText)
    End Sub
End Class
