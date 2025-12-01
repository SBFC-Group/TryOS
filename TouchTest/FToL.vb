Imports System.IO

Public Class FToL
    Private Sub FToL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.CommandLine.Contains("/DevMode") = True Then
        Else
            Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UI.OpenFormByName("TouchTest." & TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pluginPath As String = Path.Combine(Application.StartupPath, "Plugins")
        Dim plugins = PluginLoader.LoadPlugins(pluginPath)

        For Each plugin In plugins
            MsgBox("Loaded plugin: " & plugin.Name)
            plugin.Execute()
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Form1.IsUsingDarkThemeForApps = True Then
            Form1.IsUsingDarkThemeForApps = False
        ElseIf Form1.IsUsingDarkThemeForApps = False Then
            Form1.IsUsingDarkThemeForApps = True
        End If
    End Sub
End Class