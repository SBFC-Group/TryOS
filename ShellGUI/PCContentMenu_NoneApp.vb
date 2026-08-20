Imports System.Windows.Forms
Imports System.Drawing

Public Class PCContentMenu_NoneApp
    Public IsContextMenuBase As Boolean = False

    Public Sub AddItemToMenu(NameItem As String, TextItem As String, YourCode As Action)
        Dim NewButton As New Button
        NewButton.Name = NameItem
        NewButton.FlatStyle = FlatStyle.Flat
        NewButton.BackColor = Color.DarkGray
        NewButton.Text = TextItem

        If FlowLayoutPanel1.Controls.Count = 1 Then
        Else
            Me.Size = New Size(Me.Size.Width, Me.Size.Height + 47)
        End If

        FlowLayoutPanel1.Controls.Add(NewButton)
        NewButton.Font = Button1.Font
        NewButton.Size = Button1.Size

        NewButton.Tag = YourCode

        AddHandler NewButton.Click, AddressOf PluginButton_Click
    End Sub

    Private Sub PluginButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim action As Action = CType(btn.Tag, Action)
        Try
            action?.Invoke()
            Me.Visible = False
            If IsContextMenuBase = True Then
                MyControllerForm.IsPCCHere = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadProgramButtons()
        AddItemToMenu("SettingsButton", "Settings", Sub()
                                                        Main.Form1.OpenChildForm(Main.UI.GetFormFromAppDll(Main.UI.AppsFolder & "\Settings\Main.dll"))
                                                    End Sub)

        AddItemToMenu("TryOS_StoreButton", "TryOS Store", Sub()
                                                              If My.Computer.FileSystem.DirectoryExists(Main.UI.AppsFolder & "\TryOS_Store_New") = True Then
                                                                  Main.Form1.OpenChildForm(Main.UI.GetFormFromAppDll(Main.UI.AppsFolder & "\TryOS_Store_New\TryOS_Store.dll"))
                                                              Else
                                                                  If My.Computer.FileSystem.FileExists(Main.UI.AppsFolder & "\TryOS_Store\TryOS_Store.dll") = True Then
                                                                      Main.Form1.OpenChildForm(Main.UI.GetFormFromAppDll(Main.UI.AppsFolder & "\TryOS_Store\TryOS_Store.dll"))
                                                                  Else
                                                                      Main.Form1.OpenChildForm(Main.UI.GetFormFromAppDll(Main.UI.AppsFolder & "\TryOS_Store\Main.dll"))
                                                                  End If
                                                              End If
                                                          End Sub)
        If My.Computer.FileSystem.DirectoryExists(Main.UI.AppsFolder & "\Internet++") = True Then
            AddItemToMenu("InternetPlusPlusButton", "Internet++", Sub()
                                                                      Main.Form1.OpenChildForm(Main.UI.GetFormFromAppDll(My.Computer.FileSystem.ReadAllText(Main.UI.AppsFolder & "\Internet++\DllPath.txt")))
                                                                  End Sub)
        End If
        If Environment.CommandLine.Contains("/ShowCommanderOnContextMenu") = True Then
            AddItemToMenu("CommanderButton", "Commander", Sub()
                                                              Main.UI.StartCMD()
                                                          End Sub)
        End If

    End Sub


End Class
