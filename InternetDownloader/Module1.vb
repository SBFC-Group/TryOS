Module Module1

    Public Website As String = Nothing
    Public DownloadFolder As String = Nothing

    Sub Main()

        For Each s As String In My.Application.CommandLineArgs
            If s.Contains("/Address:") Then
                s = s.Replace("/Address:", "")
                Website = s
            ElseIf s.Contains("/fileName:") Then
                s = s.Replace("/fileName:", "")
                DownloadFolder = s
            End If
        Next

        If Website = Nothing Then
            Console.WriteLine("1")
            Return
        End If

        If DownloadFolder = Nothing Then
            Console.WriteLine("1")
            Return
        End If

        Dim Downloader As New Net.WebClient
        Downloader.DownloadFile(Website, DownloadFolder)

        Console.WriteLine("0")
    End Sub

End Module
