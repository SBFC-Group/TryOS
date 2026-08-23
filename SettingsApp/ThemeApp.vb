Imports System.Windows.Forms

Public Class ThemeApp
    ' Public User As TouchTest.UserManager

    Public FileFormat As ImageFormats

    Public NormalHeightWallpaperMenu As Int64 = 0

    Public WallpaperNumber As Int64 = 0

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

            WallpaperNumber = WallpaperNumber + 1

            NewButton.Text = "Wallpaper " & WallpaperNumber.ToString()

            'NewButton.Text = file.Name
            'NewButton.Text = NewButton.Text.Replace(".jpg", "")
            'NewButton.Text = NewButton.Text.Replace(".png", "")
            'NewButton.Text = NewButton.Text.Replace(".gif", "")
            'NewButton.Text = NewButton.Text.Replace("_", " ")
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
        WallpaperNumber = 0
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        LoadWallpapers(ImageFormats.png)
    End Sub

    Private Sub jpg_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WallpaperNumber = 0
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = True
        LoadWallpapers(ImageFormats.jpg)
    End Sub

    Private Sub gif_Click(sender As Object, e As EventArgs) Handles Button4.Click
        WallpaperNumber = 0
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        LoadWallpapers(ImageFormats.gif)
    End Sub

    Private Sub ThemeApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeDesign(Main.Controller.IsDarkMode())

        ' User = New TouchTest.UserManager(Main.Controller.GetUsername)
        If Main.Controller.ContainsSetting("IsTransparentEnabled") = True Then
            Dim boo As Boolean = True
            Try
                boo = Convert.ToBoolean(Main.Controller.GetSettingValue("IsTransparentEnabled"))
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    TouchTest.TryController.WriteToDebuggerOutput(ex.Message)
                End If
            End Try
            If boo = True Then
                TransparencyCheckBox.Checked = True
            Else
                TransparencyCheckBox.Checked = False
            End If
        Else
            TransparencyCheckBox.Checked = True
            Main.Controller.CreateNewSetting("IsTransparentEnabled")
            Main.Controller.SetNewSettingValue("IsTransparentEnabled", "True")
        End If

        AddHandler TransparencyCheckBox.CheckedChanged, AddressOf TransparencyCheckBox_CheckedChanged

        Dim bitmap1 As Drawing.Bitmap = Main.Controller.RunCommand("GetWallpaper")

        PictureBox1.Image = bitmap1

        LoadWallpapers(ImageFormats.jpg)

        IsDarkModeForAppsOn = Main.Controller.IsDarkMode()

        IsDarkModeForProgramsOn = Main.Controller.RunCommand("ThemeManager /GetResource DarkModeForPrograms")

        If IsDarkModeForProgramsOn = Nothing Then
            IsDarkModeForProgramsOn = False
        End If

        If IsDarkModeForAppsOn = True Then
            Button6.Text = "Use Dark Mode for Apps"
        Else
            Button6.Text = "Use Normal Mode for Apps"
        End If

        If IsDarkModeForProgramsOn = True Then
            Button7.Text = "Use Dark Mode for Programs"
        Else
            Button7.Text = "Use Normal Mode for Programs"
        End If
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
        If Main.Controller.ContainsSetting("IsTransparentEnabled") = True Then
            If TransparencyCheckBox.Checked = True Then
                Main.Controller.SetNewSettingValue("IsTransparentEnabled", "True")
            Else
                Main.Controller.SetNewSettingValue("IsTransparentEnabled", "False")
            End If
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Main.Controller.IsDarkMode() = True Then
            If ColorMode = "Normal" Then
                ChangeDesign(True)
            End If
        ElseIf Main.Controller.IsDarkMode() = False Then
            If ColorMode = "Dark" Then
                ChangeDesign(False)
            End If
        End If
    End Sub

    Private ColorMode As String = "Normal"

    Public Sub ChangeDesign(Dark As Boolean)
        If Dark = True Then
            ColorMode = "Dark"
            Me.BackColor = Drawing.Color.Gray
            Button1.BackColor = Drawing.Color.DarkGray
            Button2.BackColor = Drawing.Color.DarkGray
            Button3.BackColor = Drawing.Color.DarkGray
            Button4.BackColor = Drawing.Color.DarkGray
            Button5.BackColor = Drawing.Color.DarkGray
            Button6.BackColor = Drawing.Color.DarkGray
            Button7.BackColor = Drawing.Color.DarkGray

            For Each c As Control In WallpaperMenu.Controls
                c.BackColor = Drawing.Color.DarkGray
            Next
        ElseIf Dark = False Then
            ColorMode = "Normal"
            Me.BackColor = Drawing.Color.DarkGray
            Button1.BackColor = Drawing.Color.Gainsboro
            Button2.BackColor = Drawing.Color.Gainsboro
            Button3.BackColor = Drawing.Color.Gainsboro
            Button4.BackColor = Drawing.Color.Gainsboro
            Button5.BackColor = Drawing.Color.Gainsboro
            Button6.BackColor = Drawing.Color.Gainsboro
            Button7.BackColor = Drawing.Color.Gainsboro

            For Each c As Control In WallpaperMenu.Controls
                c.BackColor = Drawing.Color.Gainsboro
            Next
        End If
    End Sub

    Private IsDarkModeForAppsOn As Boolean = False
    Private IsDarkModeForProgramsOn As Boolean = False

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Main.Controller.ContainsSetting("IsDarkModeForApps") = True Then
            Dim boo As Boolean = True
            Try
                boo = Convert.ToBoolean(Main.Controller.GetSettingValue("IsDarkModeForApps"))
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    TouchTest.TryController.WriteToDebuggerOutput(ex.Message)
                End If
            End Try
            If boo = True Then
                Main.Controller.SetNewSettingValue("IsDarkModeForApps", "False")
                IsDarkModeForAppsOn = False

                Button6.Text = "Use Normal Mode for Apps"

                Main.Controller.RunCommand("ThemeManager /SetResource DarkModeForApps=False")
            Else
                Main.Controller.SetNewSettingValue("IsDarkModeForApps", "True")
                IsDarkModeForAppsOn = True

                Button6.Text = "Use Dark Mode for Apps"

                Main.Controller.RunCommand("ThemeManager /SetResource DarkModeForApps=True")
            End If
        Else
            Main.Controller.CreateNewSetting("IsDarkModeForApps")
            Main.Controller.SetNewSettingValue("IsDarkModeForApps", "False")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Main.Controller.ContainsSetting("IsDarkModeForProgram") = True Then
            Dim boo As Boolean = True
            Try
                boo = Convert.ToBoolean(Main.Controller.GetSettingValue("IsDarkModeForProgram"))
            Catch ex As Exception
                If Environment.CommandLine.Contains("/DevMode") = True Then
                    TouchTest.TryController.WriteToDebuggerOutput(ex.Message)
                End If
            End Try
            If boo = True Then
                Main.Controller.SetNewSettingValue("IsDarkModeForProgram", "False")
                IsDarkModeForProgramsOn = False

                Button7.Text = "Use Normal Mode for Programs"

                Main.Controller.RunCommand("ThemeManager /SetResource DarkModeForPrograms=False")
            Else
                Main.Controller.SetNewSettingValue("IsDarkModeForProgram", "True")
                IsDarkModeForProgramsOn = True

                Button7.Text = "Use Dark Mode for Programs"

                Main.Controller.RunCommand("ThemeManager /SetResource DarkModeForPrograms=True")
            End If
        Else
            Main.Controller.CreateNewSetting("IsDarkModeForProgram")
            Main.Controller.SetNewSettingValue("IsDarkModeForProgram", "False")
        End If
    End Sub
End Class
