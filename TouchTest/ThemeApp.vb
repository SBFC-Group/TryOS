Public Class ThemeApp
    Public FileFormat As String = "jpg"

    Private Sub ThemeApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadWallpaperPicker()
    End Sub

    Public Sub LoadWallpaperPicker()
        'Resets All the buttons
        ReSetButtons()

        'Configs Buttons
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_1." & FileFormat) Then
            WallpaperButton1.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_2." & FileFormat) Then
            WallpaperButton2.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_3." & FileFormat) Then
            WallpaperButton3.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_4." & FileFormat) Then
            WallpaperButton4.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_5." & FileFormat) Then
            WallpaperButton5.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_6." & FileFormat) Then
            WallpaperButton6.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_7." & FileFormat) Then
            WallpaperButton7.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_8." & FileFormat) Then
            WallpaperButton8.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_9." & FileFormat) Then
            WallpaperButton9.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_10." & FileFormat) Then
            WallpaperButton10.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_11." & FileFormat) Then
            WallpaperButton11.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_12." & FileFormat) Then
            WallpaperButton12.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_13." & FileFormat) Then
            WallpaperButton13.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_14." & FileFormat) Then
            WallpaperButton14.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_15." & FileFormat) Then
            WallpaperButton15.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_16." & FileFormat) Then
            WallpaperButton16.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_17." & FileFormat) Then
            WallpaperButton17.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_18." & FileFormat) Then
            WallpaperButton18.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_19." & FileFormat) Then
            WallpaperButton19.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_20." & FileFormat) Then
            WallpaperButton20.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_21." & FileFormat) Then
            WallpaperButton21.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_22." & FileFormat) Then
            WallpaperButton22.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_23." & FileFormat) Then
            WallpaperButton23.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_24." & FileFormat) Then
            WallpaperButton24.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_25." & FileFormat) Then
            WallpaperButton25.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_26." & FileFormat) Then
            WallpaperButton26.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_27." & FileFormat) Then
            WallpaperButton27.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_28." & FileFormat) Then
            WallpaperButton28.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_29." & FileFormat) Then
            WallpaperButton29.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_30." & FileFormat) Then
            WallpaperButton30.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_31." & FileFormat) Then
            WallpaperButton31.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_32." & FileFormat) Then
            WallpaperButton32.Visible = True
        End If
        If My.Computer.FileSystem.FileExists(UI.WallpaperFolder & "\Wallpaper_33." & FileFormat) Then
            WallpaperButton33.Visible = True
        End If
    End Sub

    Public Sub ReSetButtons()
        WallpaperButton1.Visible = False
        WallpaperButton2.Visible = False
        WallpaperButton3.Visible = False
        WallpaperButton4.Visible = False
        WallpaperButton5.Visible = False
        WallpaperButton6.Visible = False
        WallpaperButton7.Visible = False
        WallpaperButton8.Visible = False
        WallpaperButton9.Visible = False
        WallpaperButton10.Visible = False
        WallpaperButton11.Visible = False
        WallpaperButton12.Visible = False
        WallpaperButton13.Visible = False
        WallpaperButton14.Visible = False
        WallpaperButton15.Visible = False
        WallpaperButton16.Visible = False
        WallpaperButton17.Visible = False
        WallpaperButton18.Visible = False
        WallpaperButton19.Visible = False
        WallpaperButton20.Visible = False
        WallpaperButton21.Visible = False
        WallpaperButton22.Visible = False
        WallpaperButton23.Visible = False
        WallpaperButton24.Visible = False
        WallpaperButton25.Visible = False
        WallpaperButton26.Visible = False
        WallpaperButton27.Visible = False
        WallpaperButton28.Visible = False
        WallpaperButton29.Visible = False
        WallpaperButton30.Visible = False
        WallpaperButton31.Visible = False
        WallpaperButton32.Visible = False
        WallpaperButton33.Visible = False
    End Sub
    ' 62
    Public Sub LoadWallpaperPicker_Old()
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
            Button1.BackColor = Color.DarkGray
            Button2.BackColor = Color.DarkGray
            Button3.BackColor = Color.DarkGray
            Button4.BackColor = Color.DarkGray
            Button5.BackColor = Color.DarkGray
            Button6.BackColor = Color.DarkGray
            WallpaperButton1.BackColor = Color.DarkGray
            WallpaperButton2.BackColor = Color.DarkGray
            WallpaperButton3.BackColor = Color.DarkGray
            WallpaperButton4.BackColor = Color.DarkGray
            WallpaperButton5.BackColor = Color.DarkGray
            WallpaperButton6.BackColor = Color.DarkGray
            WallpaperButton7.BackColor = Color.DarkGray
            WallpaperButton8.BackColor = Color.DarkGray
            WallpaperButton9.BackColor = Color.DarkGray
            WallpaperButton10.BackColor = Color.DarkGray
            WallpaperButton11.BackColor = Color.DarkGray
            WallpaperButton12.BackColor = Color.DarkGray
            WallpaperButton13.BackColor = Color.DarkGray
            WallpaperButton14.BackColor = Color.DarkGray
            WallpaperButton15.BackColor = Color.DarkGray
            WallpaperButton16.BackColor = Color.DarkGray
            WallpaperButton17.BackColor = Color.DarkGray
            WallpaperButton18.BackColor = Color.DarkGray
            WallpaperButton19.BackColor = Color.DarkGray
            WallpaperButton20.BackColor = Color.DarkGray
            WallpaperButton21.BackColor = Color.DarkGray
            WallpaperButton22.BackColor = Color.DarkGray
            WallpaperButton23.BackColor = Color.DarkGray
            WallpaperButton24.BackColor = Color.DarkGray
            WallpaperButton25.BackColor = Color.DarkGray
            WallpaperButton26.BackColor = Color.DarkGray
            WallpaperButton27.BackColor = Color.DarkGray
            WallpaperButton28.BackColor = Color.DarkGray
            WallpaperButton29.BackColor = Color.DarkGray
            WallpaperButton30.BackColor = Color.DarkGray
            WallpaperButton31.BackColor = Color.DarkGray
            WallpaperButton32.BackColor = Color.DarkGray
            WallpaperButton33.BackColor = Color.DarkGray
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Color.DarkGray
            Button1.BackColor = Color.Gainsboro
            Button2.BackColor = Color.Gainsboro
            Button3.BackColor = Color.Gainsboro
            Button4.BackColor = Color.Gainsboro
            Button5.BackColor = Color.Gainsboro
            Button6.BackColor = Color.Gainsboro
            WallpaperButton1.BackColor = Color.Gainsboro
            WallpaperButton2.BackColor = Color.Gainsboro
            WallpaperButton3.BackColor = Color.Gainsboro
            WallpaperButton4.BackColor = Color.Gainsboro
            WallpaperButton5.BackColor = Color.Gainsboro
            WallpaperButton6.BackColor = Color.Gainsboro
            WallpaperButton7.BackColor = Color.Gainsboro
            WallpaperButton8.BackColor = Color.Gainsboro
            WallpaperButton9.BackColor = Color.Gainsboro
            WallpaperButton10.BackColor = Color.Gainsboro
            WallpaperButton11.BackColor = Color.Gainsboro
            WallpaperButton12.BackColor = Color.Gainsboro
            WallpaperButton13.BackColor = Color.Gainsboro
            WallpaperButton14.BackColor = Color.Gainsboro
            WallpaperButton15.BackColor = Color.Gainsboro
            WallpaperButton16.BackColor = Color.Gainsboro
            WallpaperButton17.BackColor = Color.Gainsboro
            WallpaperButton18.BackColor = Color.Gainsboro
            WallpaperButton19.BackColor = Color.Gainsboro
            WallpaperButton20.BackColor = Color.Gainsboro
            WallpaperButton21.BackColor = Color.Gainsboro
            WallpaperButton22.BackColor = Color.Gainsboro
            WallpaperButton23.BackColor = Color.Gainsboro
            WallpaperButton24.BackColor = Color.Gainsboro
            WallpaperButton25.BackColor = Color.Gainsboro
            WallpaperButton26.BackColor = Color.Gainsboro
            WallpaperButton27.BackColor = Color.Gainsboro
            WallpaperButton28.BackColor = Color.Gainsboro
            WallpaperButton29.BackColor = Color.Gainsboro
            WallpaperButton30.BackColor = Color.Gainsboro
            WallpaperButton31.BackColor = Color.Gainsboro
            WallpaperButton32.BackColor = Color.Gainsboro
            WallpaperButton33.BackColor = Color.Gainsboro
        End If
    End Sub

    Private CurrentButtonName As String

    Private Sub WallpaperButton1_Click(sender As Object, e As EventArgs) Handles WallpaperButton1.Click, WallpaperButton2.Click, WallpaperButton3.Click, WallpaperButton4.Click, WallpaperButton5.Click, WallpaperButton6.Click, WallpaperButton7.Click, WallpaperButton8.Click, WallpaperButton9.Click, WallpaperButton10.Click, WallpaperButton11.Click, WallpaperButton12.Click, WallpaperButton13.Click, WallpaperButton14.Click, WallpaperButton15.Click, WallpaperButton16.Click, WallpaperButton17.Click, WallpaperButton18.Click, WallpaperButton19.Click, WallpaperButton20.Click, WallpaperButton21.Click, WallpaperButton22.Click, WallpaperButton23.Click, WallpaperButton24.Click, WallpaperButton25.Click, WallpaperButton26.Click, WallpaperButton27.Click, WallpaperButton28.Click, WallpaperButton29.Click, WallpaperButton30.Click, WallpaperButton31.Click, WallpaperButton32.Click, WallpaperButton33.Click
        CurrentButtonName = sender.Name
        Dim WallpaperText As String = sender.Name
        'Removes "WallpaperButton" text from WallpaperText
        WallpaperText = WallpaperText.Replace("WallpaperButton", "")

        Dim IntTest As Int64 = Convert.ToInt64(WallpaperText)

        UploadWallpaperToPictureBox(IntTest, FileFormat)

        Button1.Enabled = True
        'Sets the wallpaper and saves it
        'If FileFormat = "jpg" Then
        '    UI.RunCommands("Loadjpg " & WallpaperText)
        '    SaveWallpaper(IntTest, PictureFormat.jpg)
        'ElseIf FileFormat = "png" Then
        '    UI.RunCommands("Loadpng " & WallpaperText)
        '    SaveWallpaper(IntTest, PictureFormat.png)
        'ElseIf FileFormat = "gif" Then
        '    UI.RunCommands("Loadgif " & WallpaperText)
        '    SaveWallpaper(IntTest, PictureFormat.gif)
        'End If
    End Sub

    '--- Taken from UI
    Public WallpaperNumber As Integer = 1
    Public Sub UploadWallpaperToPictureBox(Number As Integer, FileFormat As String)
        If FileFormat.StartsWith(".") Then
            FileFormat = FileFormat.Replace(".", "")
        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Wallpapers\Wallpaper_" & Number.ToString & "." & FileFormat) Then
            WallpaperNumber = Number
            Dim sd As New PictureBox
            sd.Load(My.Application.Info.DirectoryPath & "\Wallpapers\Wallpaper_" & Number.ToString & "." & FileFormat)
            PictureBox1.Image = sd.Image
        Else
            Dim Number2 As Integer = Number
            Number2 = Number2 - 1
            UploadWallpaperToPictureBox(Number2, FileFormat)
        End If
    End Sub
    '--- Taken from UI

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim WallpaperText As String = CurrentButtonName
        'Removes "WallpaperButton" text from WallpaperText
        WallpaperText = WallpaperText.Replace("WallpaperButton", "")

        Dim IntTest As Int64 = Convert.ToInt64(WallpaperText)

        'Sets the wallpaper and saves it
        If FileFormat = "jpg" Then
            UI.RunCommands("Loadjpg " & WallpaperText)
            SaveWallpaper(IntTest, PictureFormat.jpg)
        ElseIf FileFormat = "png" Then
            UI.RunCommands("Loadpng " & WallpaperText)
            SaveWallpaper(IntTest, PictureFormat.png)
        ElseIf FileFormat = "gif" Then
            UI.RunCommands("Loadgif " & WallpaperText)
            SaveWallpaper(IntTest, PictureFormat.gif)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            My.Computer.FileSystem.WriteAllText(UI.UserFolder & "\Settings\DarkThemeForApps.swfiles", "False", False)
        Catch ex As Exception
            UI.ShowError(ex.Message)
        End Try
        Form1.IsUsingDarkThemeForApps = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            My.Computer.FileSystem.WriteAllText(UI.UserFolder & "\Settings\DarkThemeForApps.swfiles", "True", False)
        Catch ex As Exception
            UI.ShowError(ex.Message)
        End Try
        Form1.IsUsingDarkThemeForApps = True
    End Sub
End Class
