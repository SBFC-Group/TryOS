Public Class Search_App
    Public SearchMode As String = "Form"
    Public Sub Search_Any_Form(SearchText As String)
        If SearchMode = "Form" Then
            UI.Run(SearchText)
        ElseIf SearchMode = "Apps" Then
            If SearchText = "Quick Edit" Then
                UI.Run("{C8CAFE9B-DB4C-4BDB-BECF-7A6FF4378C21}")
            ElseIf SearchText = "quick Edit" Then
                UI.Run("{C8CAFE9B-DB4C-4BDB-BECF-7A6FF4378C21}")
            ElseIf SearchText = "Quick edit" Then
                UI.Run("{C8CAFE9B-DB4C-4BDB-BECF-7A6FF4378C21}")
            ElseIf SearchText = "quick edit" Then
                UI.Run("{C8CAFE9B-DB4C-4BDB-BECF-7A6FF4378C21}")
            End If
            If SearchText = "Image Viewer" Then
                UI.Run("{52EFE40B-2FBD-4EC4-8A90-D12ACA818FD8}")
            ElseIf SearchText = "image Viewer" Then
                UI.Run("{52EFE40B-2FBD-4EC4-8A90-D12ACA818FD8}")
            ElseIf SearchText = "Image viewer" Then
                UI.Run("{52EFE40B-2FBD-4EC4-8A90-D12ACA818FD8}")
            ElseIf SearchText = "image viewer" Then
                UI.Run("{52EFE40B-2FBD-4EC4-8A90-D12ACA818FD8}")
            End If
            If SearchText = "SWStore" Then
                UI.Run("{5D5279A7-C17F-40AF-BBC3-F497DFCCA269}")
            ElseIf SearchText = "sWStore" Then
                UI.Run("{5D5279A7-C17F-40AF-BBC3-F497DFCCA269}")
            ElseIf SearchText = "SwStore" Then
                UI.Run("{5D5279A7-C17F-40AF-BBC3-F497DFCCA269}")
            ElseIf SearchText = "SWstore" Then
                UI.Run("{5D5279A7-C17F-40AF-BBC3-F497DFCCA269}")
            ElseIf SearchText = "swStore" Then
                UI.Run("{5D5279A7-C17F-40AF-BBC3-F497DFCCA269}")
            ElseIf SearchText = "Swstore" Then
                UI.Run("{5D5279A7-C17F-40AF-BBC3-F497DFCCA269}")
            ElseIf SearchText = "swstore" Then
                UI.Run("{5D5279A7-C17F-40AF-BBC3-F497DFCCA269}")
            End If
            If SearchText = "File Explorer" Then
                UI.Run("{EB9B028F-EF0E-4ADB-9E3E-53B2132F501E}")
            ElseIf SearchText = "file Explorer" Then
                UI.Run("{EB9B028F-EF0E-4ADB-9E3E-53B2132F501E}")
            ElseIf SearchText = "File explorer" Then
                UI.Run("{EB9B028F-EF0E-4ADB-9E3E-53B2132F501E}")
            ElseIf SearchText = "file explorer" Then
                UI.Run("{EB9B028F-EF0E-4ADB-9E3E-53B2132F501E}")
            End If
            If SearchText = "Settings" Then
                UI.Run("{37B42C69-B540-4D71-A1C3-D6F3FB61FAD8}")
            ElseIf SearchText = "settings" Then
                UI.Run("{37B42C69-B540-4D71-A1C3-D6F3FB61FAD8}")
            End If
            If SearchText = "GCS" Then
                UI.Run("GCS")
            ElseIf SearchText = "gCS" Then
                UI.Run("GCS")
            ElseIf SearchText = "GcS" Then
                UI.Run("GCS")
            ElseIf SearchText = "GCs" Then
                UI.Run("GCS")
            ElseIf SearchText = "gcS" Then
                UI.Run("GCS")
            ElseIf SearchText = "Gcs" Then
                UI.Run("GCS")
            ElseIf SearchText = "gcs" Then
                UI.Run("GCS")
            End If
        ElseIf SearchMode = "Web" Then
            If My.Computer.FileSystem.DirectoryExists("runtimes") Then
            Else
                Exit Sub
            End If
            Try
                Internetplusplus.Show()
                Internetplusplus.WebView21.Source = New Uri("https://www.google.com/search?q=" & SearchText)
            Catch ex As Exception
                MsgBox("Can't open Internet++ Legacy", MsgBoxStyle.Critical, "Search_App")
                'Form35.Show()
                'Form35.WebBrowser1.Navigate("https://www.google.com/search?q=" & SearchText)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SearchMode = "Form"
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        MenuStrip1.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SearchMode = "Apps"
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = True
        MenuStrip1.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If My.Computer.FileSystem.DirectoryExists("runtimes") Then
        Else
            Exit Sub
        End If
        SearchMode = "Web"
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        MenuStrip1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Search_Any_Form(TextBox1.Text)
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Search_Any_Form(TextBox1.Text)
        End If
    End Sub

    Private Sub TextBox1_TextChanged_Old()
        If TextBox1.Text.Contains("a") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = True
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("b") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("c") = True Then
            QuickEditToolStripMenuItem.Visible = True
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = True
        End If
        If TextBox1.Text.Contains("d") = True Then
            QuickEditToolStripMenuItem.Visible = True
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("e") = True Then
            QuickEditToolStripMenuItem.Visible = True
            ImageViewerToolStripMenuItem.Visible = True
            FileExplorerToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = True
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("f") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("g") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = True
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = True
            HelloToolStripMenuItem.Visible = True
        End If
        If TextBox1.Text.Contains("h") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("i") = True Then
            QuickEditToolStripMenuItem.Visible = True
            ImageViewerToolStripMenuItem.Visible = True
            FileExplorerToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = True
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("j") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("k") = True Then
            QuickEditToolStripMenuItem.Visible = True
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("l") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("m") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = True
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("n") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = True
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("o") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("p") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("q") = True Then
            QuickEditToolStripMenuItem.Visible = True
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("r") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = True
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("s") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = True
            HelloToolStripMenuItem.Visible = True
        End If
        If TextBox1.Text.Contains("t") = True Then
            QuickEditToolStripMenuItem.Visible = True
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = True
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("u") = True Then
            QuickEditToolStripMenuItem.Visible = True
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("w") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = True
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("v") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = True
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("x") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = True
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("y") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If
        If TextBox1.Text.Contains("z") = True Then
            QuickEditToolStripMenuItem.Visible = False
            ImageViewerToolStripMenuItem.Visible = False
            FileExplorerToolStripMenuItem.Visible = False
            SettingsToolStripMenuItem.Visible = False
            HelloToolStripMenuItem.Visible = False
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Search_Look(TextBox1.Text)
    End Sub

    Public Sub Search_Look(SearchText As String)

        TextBox1_TextChanged_Old()
    End Sub

    Private Sub HelloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelloToolStripMenuItem.Click
        UI.Run("GCS")
    End Sub

    Private Sub FileExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileExplorerToolStripMenuItem.Click
        UI.Run("{EB9B028F-EF0E-4ADB-9E3E-53B2132F501E}")
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        UI.Run("{37B42C69-B540-4D71-A1C3-D6F3FB61FAD8}")
    End Sub

    Private Sub QuickEditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickEditToolStripMenuItem.Click
        UI.Run("{C8CAFE9B-DB4C-4BDB-BECF-7A6FF4378C21}")
    End Sub

    Private Sub ImageViewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageViewerToolStripMenuItem.Click
        UI.Run("{52EFE40B-2FBD-4EC4-8A90-D12ACA818FD8}")
    End Sub
End Class
