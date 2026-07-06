Imports System.Runtime.InteropServices

Public Class Internetplusplus
    Public InternetSettings As InternetSettingsUserControl

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            'Tab 1
            If WebView21.CoreWebView2.DocumentTitle = Nothing Then
                TabPage1.Text = "Tab 1"
            Else
                TabPage1.Text = WebView21.CoreWebView2.DocumentTitle
                If TabPage1.Text = "News about Sebs SW and new projects" Then
                    TabPage1.Text = "News.."
                End If
            End If
            'Tab 2
            If WebView22.CoreWebView2.DocumentTitle = Nothing Then
                TabPage2.Text = "Tab 2"
            Else
                TabPage2.Text = WebView22.CoreWebView2.DocumentTitle
                If TabPage2.Text = "News about Sebs SW and new projects" Then
                    TabPage2.Text = "News.."
                End If
            End If
            'Tab 3
            If WebView23.CoreWebView2.DocumentTitle = Nothing Then
                TabPage3.Text = "Tab 3"
            Else
                TabPage3.Text = WebView23.CoreWebView2.DocumentTitle
                If TabPage3.Text = "News about Sebs SW and new projects" Then
                    TabPage3.Text = "News.."
                End If
            End If
            'Tab 4
            If WebView24.CoreWebView2.DocumentTitle = Nothing Then
                TabPage4.Text = "Tab 4"
            Else
                TabPage4.Text = WebView24.CoreWebView2.DocumentTitle
                If TabPage4.Text = "News about Sebs SW and new projects" Then
                    TabPage4.Text = "News.."
                End If
            End If
            'Tab 5
            If WebView25.CoreWebView2.DocumentTitle = Nothing Then
                TabPage5.Text = "Tab 5"
            Else
                TabPage5.Text = WebView25.CoreWebView2.DocumentTitle
                If TabPage5.Text = "News about Sebs SW and new projects" Then
                    TabPage5.Text = "News.."
                End If
            End If
            'Tab 6
            If WebView26.CoreWebView2.DocumentTitle = Nothing Then
                TabPage6.Text = "Tab 6"
            Else
                TabPage6.Text = WebView26.CoreWebView2.DocumentTitle
                If TabPage6.Text = "News about Sebs SW and new projects" Then
                    TabPage6.Text = "News.."
                End If
            End If
        Catch ex As Exception

        End Try


        'TabPage1.Text = WebView21.CoreWebView2.DocumentTitle
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebView21.GoBack()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebView21.GoForward()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WebView21.Refresh()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Form1.IsInternetOpen = False
        Close()
    End Sub

    Private Sub MaxiButton_Click(sender As Object, e As EventArgs) Handles MaxiButton.Click
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        Else
            WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub MiniButton_Click(sender As Object, e As EventArgs) Handles MiniButton.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
        Else
            If TextBox1.Text = "cmd" Then
                UI.StartCMD("New")
                Form1.IsInternetOpen = False
                'CMD STRING'
            Else
                If TextBox1.Text.StartsWith("https://") = True Then
                    WebView21.Source = New Uri(TextBox1.Text)
                Else
                    If TextBox1.Text.StartsWith("http://") = True Then
                        WebView21.Source = New Uri(TextBox1.Text)
                    Else
                        If TextBox1.Text.StartsWith("file:///") = True Then
                            WebView21.Source = New Uri(TextBox1.Text)
                        Else
                            WebView21.Source = New Uri("https://" & TextBox1.Text)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Dim hh As Boolean = False
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If hh = True Then
            ReleaseCapture()
            SendMessage(Me.Handle, &H112, &HF012, 0)
        End If
    End Sub

    Private Sub Internetplusplus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.internet_world_wide_web_www_globe_communication_website_browser_network_connection_icon_195710
        If My.Application.Info.ProductName = "Sebs SW CV" Then
            Panel1.Visible = True
            loadweb("1")
            FormBorderStyle = FormBorderStyle.None
        ElseIf My.Application.Info.ProductName = "Internet++" Then
            FormBorderStyle = FormBorderStyle.Sizable
            Panel1.Visible = False
            loadweb("1")
        Else

            FormBorderStyle = FormBorderStyle.None
            Panel1.Visible = False
            MaxiButton.Enabled = False
            MiniButton.Enabled = False
            loadweb("1")
            'Me.Location = New Point(1, 1)
            'Me.Size = New Size(Form1.SizeX, Form1.SizeY)
        End If
        'Panel1.Visible = True
        'FormBorderStyle = FormBorderStyle.None
        If Environment.CommandLine.Contains("/NoInternet++4.0Update") = False Then
            Dim temptimer As New Timer
            temptimer.Interval = 1000
            AddHandler temptimer.Tick, Sub()
                                           temptimer.Stop()
                                           UI.ShowError("Internal Internet++ 4.0 is no-longer supported.
Please uninstall this version and go to the TryOS Store. Install the newer Internet++ 5.0.")
                                       End Sub
            temptimer.Start()
        End If
    End Sub

    Public Sub Loadweb(ss As String)
        If ss = "0" Then
        Else

            'Tab 1
            If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\load1.tabsetting") Then
                Dim ToWeb = TextBox1.Text
                ToWeb = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\load1.tabsetting")
                Try
                    WebView21.Source = New Uri(ToWeb)
                Catch ex As Exception

                End Try
            End If

            'Tab 2
            If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\load2.tabsetting") Then
                Dim ToWeb = TextBox2.Text
                ToWeb = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\load2.tabsetting")
                Try
                    WebView22.Source = New Uri(ToWeb)
                Catch ex As Exception

                End Try
            End If

            'Tab 3
            If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\load3.tabsetting") Then
                Dim ToWeb = TextBox3.Text
                ToWeb = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\load3.tabsetting")
                Try
                    WebView23.Source = New Uri(ToWeb)
                Catch ex As Exception

                End Try
            End If

            'Tab 4
            If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\load4.tabsetting") Then
                Dim ToWeb = TextBox4.Text
                ToWeb = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\load4.tabsetting")
                Try
                    WebView24.Source = New Uri(ToWeb)
                Catch ex As Exception

                End Try
            End If

            'Tab 5
            If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\load5.tabsetting") Then
                Dim ToWeb = TextBox5.Text
                ToWeb = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\load5.tabsetting")
                Try
                    WebView25.Source = New Uri(ToWeb)
                Catch ex As Exception

                End Try
            End If

            'Tab 6
            If My.Computer.FileSystem.FileExists(UI.UserFolder & "\Settings\load6.tabsetting") Then
                Dim ToWeb = TextBox6.Text
                ToWeb = My.Computer.FileSystem.ReadAllText(UI.UserFolder & "\Settings\load6.tabsetting")
                Try
                    WebView26.Source = New Uri(ToWeb)
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        WebView22.GoBack()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        WebView22.GoForward()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        WebView22.Refresh()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox2.Text = "" Then
        Else
            If TextBox2.Text = "cmd" Then
                UI.StartCMD("New")
                Form1.IsInternetOpen = False
                'CMD STRING'
            Else
                If TextBox2.Text.StartsWith("https://") = True Then
                    WebView22.Source = New Uri(TextBox2.Text)
                Else
                    If TextBox2.Text.StartsWith("http://") = True Then
                        WebView22.Source = New Uri(TextBox2.Text)
                    Else
                        If TextBox2.Text.StartsWith("file:///") = True Then
                            WebView22.Source = New Uri(TextBox2.Text)
                        Else
                            WebView22.Source = New Uri("https://" & TextBox2.Text)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text = "" Then
            Else
                If TextBox1.Text = "cmd" Then
                    UI.StartCMD("New")
                    Form1.IsInternetOpen = False
                    'CMD STRING'
                Else
                    If TextBox1.Text.StartsWith("https://") = True Then
                        WebView21.Source = New Uri(TextBox1.Text)
                    Else
                        If TextBox1.Text.StartsWith("http://") = True Then
                            WebView21.Source = New Uri(TextBox1.Text)
                        Else
                            If TextBox1.Text.StartsWith("file:///") = True Then
                                WebView21.Source = New Uri(TextBox1.Text)
                            Else
                                WebView21.Source = New Uri("https://" & TextBox1.Text)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            If WebView21.CoreWebView2.ContainsFullScreenElement = True Then
                TabControl1.Visible = False
                Form1.HideTaskbar(True)
                Me.Controls.Add(WebView21)
            ElseIf WebView21.CoreWebView2.ContainsFullScreenElement = False Then
                If Me.Controls.Contains(WebView21) = True Then
                    TabControl1.Visible = True
                    Form1.HideTaskbar(False)
                    TabPage1.Controls.Add(WebView21)
                    WebView21.BringToFront()
                    WebView21.Select()
                End If
            End If

            If WebView22.CoreWebView2.ContainsFullScreenElement = True Then
                TabControl1.Visible = False
                Form1.HideTaskbar(True)
                Me.Controls.Add(WebView22)
            ElseIf WebView22.CoreWebView2.ContainsFullScreenElement = False Then
                If Me.Controls.Contains(WebView22) = True Then
                    TabControl1.Visible = True
                    Form1.HideTaskbar(False)
                    TabPage2.Controls.Add(WebView22)
                    WebView22.BringToFront()
                    WebView22.Select()
                End If
            End If

            If WebView23.CoreWebView2.ContainsFullScreenElement = True Then
                TabControl1.Visible = False
                Form1.HideTaskbar(True)
                Me.Controls.Add(WebView23)
            ElseIf WebView23.CoreWebView2.ContainsFullScreenElement = False Then
                If Me.Controls.Contains(WebView23) = True Then
                    TabControl1.Visible = True
                    Form1.HideTaskbar(False)
                    TabPage3.Controls.Add(WebView23)
                    WebView23.BringToFront()
                    WebView23.Select()
                End If
            End If

            If WebView24.CoreWebView2.ContainsFullScreenElement = True Then
                TabControl1.Visible = False
                Form1.HideTaskbar(True)
                Me.Controls.Add(WebView24)
            ElseIf WebView24.CoreWebView2.ContainsFullScreenElement = False Then
                If Me.Controls.Contains(WebView24) = True Then
                    TabControl1.Visible = True
                    Form1.HideTaskbar(False)
                    TabPage4.Controls.Add(WebView24)
                    WebView24.BringToFront()
                    WebView24.Select()
                End If
            End If

            If WebView25.CoreWebView2.ContainsFullScreenElement = True Then
                TabControl1.Visible = False
                Form1.HideTaskbar(True)
                Me.Controls.Add(WebView25)
            ElseIf WebView25.CoreWebView2.ContainsFullScreenElement = False Then
                If Me.Controls.Contains(WebView25) = True Then
                    TabControl1.Visible = True
                    Form1.HideTaskbar(False)
                    TabPage5.Controls.Add(WebView25)
                    WebView25.BringToFront()
                    WebView25.Select()
                End If
            End If

            If WebView26.CoreWebView2.ContainsFullScreenElement = True Then
                TabControl1.Visible = False
                Form1.HideTaskbar(True)
                Me.Controls.Add(WebView26)
            ElseIf WebView26.CoreWebView2.ContainsFullScreenElement = False Then
                If Me.Controls.Contains(WebView26) = True Then
                    TabControl1.Visible = True
                    Form1.HideTaskbar(False)
                    TabPage6.Controls.Add(WebView26)
                    WebView26.BringToFront()
                    WebView26.Select()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox2.Text = "" Then
            Else
                If TextBox2.Text.StartsWith("cmd://") = True Then
                    UI.StartCMD("New")
                    Form1.IsInternetOpen = False
                    'CMD STRING'
                Else
                    If TextBox2.Text.StartsWith("https://") = True Then
                        WebView22.Source = New Uri(TextBox2.Text)
                    Else
                        If TextBox2.Text.StartsWith("http://") = True Then
                            WebView22.Source = New Uri(TextBox2.Text)
                        Else
                            If TextBox2.Text.StartsWith("file:///") = True Then
                                WebView22.Source = New Uri(TextBox2.Text)
                            Else
                                Try
                                    WebView22.Source = New Uri("https://" & TextBox2.Text)
                                Catch ex As Exception

                                End Try

                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        WebView23.GoBack()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        WebView23.GoForward()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        WebView23.Refresh()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If TextBox3.Text = "" Then
        Else
            If TextBox3.Text = "cmd" Then
                UI.StartCMD("New")
                Form1.IsInternetOpen = False
                'CMD STRING'
            Else
                If TextBox3.Text.StartsWith("https://") = True Then
                    WebView23.Source = New Uri(TextBox3.Text)
                Else
                    If TextBox3.Text.StartsWith("http://") = True Then
                        WebView23.Source = New Uri(TextBox3.Text)
                    Else
                        If TextBox3.Text.StartsWith("file:///") = True Then
                            WebView23.Source = New Uri(TextBox3.Text)
                        Else
                            WebView23.Source = New Uri("https://" & TextBox3.Text)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox3.Text = "" Then
            Else
                If TextBox3.Text = "cmd" Then
                    UI.StartCMD("New")
                    Form1.IsInternetOpen = False
                    'CMD STRING'
                Else
                    If TextBox3.Text.StartsWith("https://") = True Then
                        WebView23.Source = New Uri(TextBox3.Text)
                    Else
                        If TextBox3.Text.StartsWith("http://") = True Then
                            WebView23.Source = New Uri(TextBox3.Text)
                        Else
                            If TextBox3.Text.StartsWith("file://") = True Then
                                WebView23.Source = New Uri(TextBox3.Text)
                            Else
                                WebView23.Source = New Uri("https://" & TextBox3.Text)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        WebView24.GoBack()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        WebView24.GoForward()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        WebView24.Refresh()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If TextBox4.Text = "" Then
        Else
            If TextBox4.Text = "cmd" Then
                UI.StartCMD("New")
                Form1.IsInternetOpen = False
                'CMD STRING'
            Else
                If TextBox4.Text.StartsWith("https://") = True Then
                    WebView24.Source = New Uri(TextBox4.Text)
                Else
                    If TextBox4.Text.StartsWith("http://") = True Then
                        WebView24.Source = New Uri(TextBox4.Text)
                    Else
                        If TextBox4.Text.StartsWith("file:///") = True Then
                            WebView24.Source = New Uri(TextBox4.Text)
                        Else
                            WebView24.Source = New Uri("https://" & TextBox4.Text)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox4.Text = "" Then
            Else
                If TextBox4.Text = "cmd" Then
                    UI.StartCMD("New")
                    Form1.IsInternetOpen = False
                    'CMD STRING'
                Else
                    If TextBox4.Text.StartsWith("https://") = True Then
                        WebView24.Source = New Uri(TextBox4.Text)
                    Else
                        If TextBox4.Text.StartsWith("http://") = True Then
                            WebView24.Source = New Uri(TextBox4.Text)
                        Else
                            If TextBox4.Text.StartsWith("file:///") = True Then
                                WebView24.Source = New Uri(TextBox4.Text)
                            Else
                                WebView24.Source = New Uri("https://" & TextBox4.Text)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        WebView25.GoBack()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        WebView25.GoForward()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        WebView25.Refresh()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If TextBox5.Text = "" Then
        Else
            If TextBox5.Text = "cmd" Then
                UI.StartCMD("New")
                Form1.IsInternetOpen = False
                'CMD STRING'
            Else
                If TextBox5.Text.StartsWith("https://") = True Then
                    WebView25.Source = New Uri(TextBox5.Text)
                Else
                    If TextBox5.Text.StartsWith("http://") = True Then
                        WebView25.Source = New Uri(TextBox5.Text)
                    Else
                        If TextBox5.Text.StartsWith("file:///") = True Then
                            WebView25.Source = New Uri(TextBox5.Text)
                        Else
                            WebView25.Source = New Uri("https://" & TextBox5.Text)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox5.Text = "" Then
            Else
                If TextBox5.Text = "cmd" Then
                    UI.StartCMD("New")
                    Form1.IsInternetOpen = False
                    'CMD STRING'
                Else
                    If TextBox5.Text.StartsWith("https://") = True Then
                        WebView25.Source = New Uri(TextBox5.Text)
                    Else
                        If TextBox5.Text.StartsWith("http://") = True Then
                            WebView25.Source = New Uri(TextBox5.Text)
                        Else
                            If TextBox5.Text.StartsWith("file:///") = True Then
                                WebView25.Source = New Uri(TextBox5.Text)
                            Else
                                WebView25.Source = New Uri("https://" & TextBox5.Text)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        WebView26.GoBack()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        WebView26.GoForward()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        WebView26.Refresh()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If TextBox6.Text = "" Then
        Else
            If TextBox6.Text = "cmd" Then
                UI.StartCMD("New")
                Form1.IsInternetOpen = False
                'CMD STRING'
            Else
                If TextBox6.Text.StartsWith("https://") = True Then
                    WebView26.Source = New Uri(TextBox6.Text)
                Else
                    If TextBox6.Text.StartsWith("http://") = True Then
                        WebView26.Source = New Uri(TextBox6.Text)
                    Else
                        If TextBox6.Text.StartsWith("file:///") = True Then
                            WebView26.Source = New Uri(TextBox6.Text)
                        Else
                            WebView26.Source = New Uri("https://" & TextBox6.Text)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox6.Text = "" Then
            Else
                If TextBox6.Text = "cmd" Then
                    UI.StartCMD("New")
                    Form1.IsInternetOpen = False
                    'CMD STRING'
                Else
                    If TextBox6.Text.StartsWith("https://") = True Then
                        WebView26.Source = New Uri(TextBox6.Text)
                    Else
                        If TextBox6.Text.StartsWith("http://") = True Then
                            WebView26.Source = New Uri(TextBox6.Text)
                        Else
                            If TextBox6.Text.StartsWith("file:///") = True Then
                                WebView26.Source = New Uri(TextBox6.Text)
                            Else
                                WebView26.Source = New Uri("https://" & TextBox6.Text)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Internetplusplus_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F11 Then
            load_at_start.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        load_at_start.Show()
    End Sub

    Private Sub WebView21_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        TextBox1.Text = WebView21.Source.AbsoluteUri
    End Sub

    Private Sub WebView22_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView22.NavigationCompleted
        TextBox2.Text = WebView22.Source.AbsoluteUri
    End Sub

    Private Sub WebView23_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView23.NavigationCompleted
        TextBox3.Text = WebView23.Source.AbsoluteUri
    End Sub

    Private Sub WebView24_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView24.NavigationCompleted
        TextBox4.Text = WebView24.Source.AbsoluteUri
    End Sub

    Private Sub WebView25_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView25.NavigationCompleted
        TextBox5.Text = WebView25.Source.AbsoluteUri
    End Sub

    Private Sub WebView26_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView26.NavigationCompleted
        TextBox6.Text = WebView26.Source.AbsoluteUri
    End Sub

    Private IsOpenUserControl As Boolean = False
    Private Sub SettingsButtons_Click(sender As Object, e As EventArgs) Handles SettingsButton1.Click, SettingsButton2.Click, SettingsButton3.Click, SettingsButton4.Click, SettingsButton5.Click, SettingsButton6.Click
        TabControl1.Visible = False
        If IsOpenUserControl = False Then
            InternetSettings = New InternetSettingsUserControl
            IsOpenUserControl = True
        End If
        SettingsPanel.Visible = True
        SettingsPanel.Dock = DockStyle.Fill
        SettingsPanel.Controls.Add(InternetSettings)
        InternetSettings.Dock = DockStyle.Fill
        InternetSettings.Controls.Add(SettingsBackButton)
        SettingsBackButton.Visible = True

        InternetSettings.TextBox1.Text = TextBox1.Text
        InternetSettings.TextBox2.Text = TextBox2.Text
        InternetSettings.TextBox3.Text = TextBox3.Text
        InternetSettings.TextBox4.Text = TextBox4.Text
        InternetSettings.TextBox5.Text = TextBox5.Text
        InternetSettings.TextBox6.Text = TextBox6.Text
    End Sub

    Private Sub SettingsBackButton_Click(sender As Object, e As EventArgs) Handles SettingsBackButton.Click
        SettingsPanel.Visible = False
        SettingsPanel.Dock = DockStyle.Top
        SettingsPanel.Controls.Remove(InternetSettings)
        InternetSettings.Controls.Add(SettingsBackButton)
        SettingsBackButton.Visible = False
        TabControl1.Visible = True
    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        If e.IsSuccess = True Then
            Dim webviewy As Microsoft.Web.WebView2.WinForms.WebView2 = CType(sender, Microsoft.Web.WebView2.WinForms.WebView2)
            If Form1.IsUsingDarkThemeForApps = True Then
                webviewy.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Dark
            ElseIf Form1.IsUsingDarkThemeForApps = False Then
                webviewy.CoreWebView2.Profile.PreferredColorScheme = Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Light
            End If
        End If

    End Sub
End Class
