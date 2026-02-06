Imports System.Reflection

Public Class AppInfo
    Public ReadOnly FolderName As String
    Public ReadOnly Name As String
    Public ReadOnly Icon As Drawing.Bitmap
    Public ReadOnly Version As Version

    Public Sub New(FullAppName As String)
        Dim file As New IO.DirectoryInfo(FullAppName)
        FolderName = file.Name

        Dim DllPath As String

        If My.Computer.FileSystem.FileExists(FullAppName & "\DllPath.txt") Then
            DllPath = My.Computer.FileSystem.ReadAllText(FullAppName & "\DllPath.txt")
        Else
            DllPath = FullAppName & "\Main.dll"
        End If

        Try


            Dim asm As Assembly = Assembly.LoadFrom(DllPath)

            ' Find all types that implement OpenFramework_Interface
            For Each t In asm.GetTypes()
                If GetType(TouchTest.OpenFramework_Interface).IsAssignableFrom(t) AndAlso Not t.IsInterface AndAlso Not t.IsAbstract Then
                    Try
                        Dim plugin As TouchTest.OpenFramework_Interface = CType(Activator.CreateInstance(t), TouchTest.OpenFramework_Interface)
                        Icon = plugin.Icon
                        Version = New Version(plugin.MajerVersion, plugin.MinorVersion, plugin.PatchVersion, 0)
                        Name = plugin.Name
                    Catch ex As Exception
                        Main.Controller.ShowError(ex.Message)
                    End Try
                End If
            Next

        Catch Exceptionthing As Exception
            Main.Controller.ShowError(Exceptionthing.Message)
        End Try
    End Sub

    Public Sub N()
        Me.Finalize()
    End Sub
End Class
