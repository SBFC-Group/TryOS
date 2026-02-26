Imports System.Windows.Forms

Public Class ThemeApp
    Public User As TouchTest.UserManager

    Public FileFormat As ImageFormats

    Public NormalHeightWallpaperMenu As Int64 = 0

    Public Sub LoadWallpapers(Format As ImageFormats)
        WallpaperMenu.Controls.Clear()

        WallpaperMenu.Size = New Drawing.Size(WallpaperMenu.Size.Width, NormalHeightWallpaperMenu)

        Dim dir1 = My.Application.Info.DirectoryPath & "\Wallpapers"
        Dim files() As System.IO.FileInfo
        Dim dirinfo As New System.IO.DirectoryInfo(dir1)
        If Format = ImageFormats.jpg Then
            files = dirinfo.GetFiles("*.jpg", IO.SearchOption.TopDirectoryOnly)
        ElseIf Format = ImageFormats.png Then
            files = dirinfo.GetFiles("*.png", IO.SearchOption.TopDirectoryOnly)
        ElseIf Format = ImageFormats.gif Then
            files = dirinfo.GetFiles("*.gif", IO.SearchOption.TopDirectoryOnly)
        Else
            files = dirinfo.GetFiles("*", IO.SearchOption.TopDirectoryOnly)
        End If
        For Each file In files
            Dim NewButton As New Button
            NewButton.FlatStyle = FlatStyle.Flat
            NewButton.Size = Button5.Size
            NewButton.BackColor = Button5.BackColor
            NewButton.Font = Button5.Font
            NewButton.ForeColor = Button5.ForeColor
            NewButton.Tag = file.FullName
            NewButton.Text = file.Name
            NewButton.Text = NewButton.Text.Replace(".jpg", "")
            NewButton.Text = NewButton.Text.Replace(".png", "")
            NewButton.Text = NewButton.Text.Replace(".gif", "")
            NewButton.Text = NewButton.Text.Replace("_", " ")
            WallpaperMenu.Size = New Drawing.Size(WallpaperMenu.Size.Width, WallpaperMenu.Size.Height + 45)
            WallpaperMenu.Controls.Add(NewButton)
            AddHandler NewButton.Click, AddressOf SetWallpaper
        Next
    End Sub

    Private WallpaperPath As String = Nothing

    Private Sub SetWallpaper(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim WallpaperPath As String = btn.Tag

        PictureBox1.Image = Drawing.Bitmap.FromFile(WallpaperPath)
        Button1.Enabled = True
        Me.WallpaperPath = WallpaperPath
    End Sub

    Public Enum ImageFormats
        any = 0
        jpg = 1
        png = 2
        gif = 3
    End Enum

    Private Sub png_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        LoadWallpapers(ImageFormats.png)
    End Sub

    Private Sub jpg_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = True
        LoadWallpapers(ImageFormats.jpg)
    End Sub

    Private Sub gif_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        LoadWallpapers(ImageFormats.gif)
    End Sub

    Private Sub ThemeApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        User = New TouchTest.UserManager(Main.Controller.GetUsername)

        If User.DoesSettingExist("IsTransparentEnabled=True") = True Then
            TransparencyCheckBox.Checked = True
        ElseIf User.DoesSettingExist("IsTransparentEnabled=False") = True Then
            TransparencyCheckBox.Checked = False
        Else
            TransparencyCheckBox.Checked = True
            User.AddSettingToUserSettings("IsTransparentEnabled=True")
        End If

        AddHandler TransparencyCheckBox.CheckedChanged, AddressOf TransparencyCheckBox_CheckedChanged

        'NormalHeightWallpaperMenu = WallpaperMenu.Size.Height
        Dim bitmap1 As Drawing.Bitmap = Main.Controller.RunCommand("GetWallpaper")

        PictureBox1.Image = bitmap1

        LoadWallpapers(ImageFormats.jpg)
    End Sub

    Private WallpaperEncoder As String = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If WallpaperPath IsNot Nothing Then
            Main.Controller.RunCommand("SetWallpaper " & WallpaperPath)

            WallpaperEncoder = WallpaperPath

            Dim byt1 As Byte() = System.Text.Encoding.UTF8.GetBytes(WallpaperEncoder)
            WallpaperEncoder = Convert.ToBase64String(byt1)

            Dim byt2 As Byte() = System.Text.Encoding.UTF8.GetBytes(WallpaperEncoder)
            WallpaperEncoder = Convert.ToBase64String(byt2)

            My.Computer.FileSystem.WriteAllText(Main.Controller.GetUserFolder & "\Settings\WallpaperImage.swfiles", WallpaperEncoder, False)
        End If
    End Sub

    Private Sub TransparencyCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        If TransparencyCheckBox.Checked = True Then
            User.ReplaceSettingInUserSettings("IsTransparentEnabled=False", "IsTransparentEnabled=True")
        Else
            User.ReplaceSettingInUserSettings("IsTransparentEnabled=True", "IsTransparentEnabled=False")
        End If
    End Sub
End Class
