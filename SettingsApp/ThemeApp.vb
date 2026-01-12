Imports System.Windows.Forms

Public Class ThemeApp
    Public FileFormat As ImageFormats

    Public Sub LoadWallpapers(Format As ImageFormats)
        WallpaperMenu.Controls.Clear()

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
            WallpaperMenu.Controls.Add(NewButton)
            AddHandler NewButton.Click, AddressOf SetWallpaper
        Next
    End Sub

    Private Sub SetWallpaper(sender As Object, e As EventArgs)

    End Sub

    Public Enum ImageFormats
        jpg = 1
        png = 2
        gif = 3
    End Enum

    Private Sub png_Click(sender As Object, e As EventArgs) Handles Button2.Click


        LoadWallpapers(ImageFormats.png)
    End Sub

    Private Sub jpg_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadWallpapers(ImageFormats.jpg)
    End Sub

    Private Sub gif_Click(sender As Object, e As EventArgs) Handles Button4.Click

        LoadWallpapers(ImageFormats.gif)
    End Sub

    Private Sub ThemeApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadWallpapers(ImageFormats.jpg)
    End Sub
End Class
