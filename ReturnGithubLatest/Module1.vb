Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq

Module Module1

    Async Function GetReleases() As Task
        Dim owner As String = "sebastian2007bro"
        Dim repo As String = "TryOS"

        Dim url As String = $"https://api.github.com/repos/{owner}/{repo}/releases"

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("User-Agent", "TryOS_Updater")

            Dim response As String = Await client.GetStringAsync(url)
            Dim releases As JArray = JArray.Parse(response)

            Dim latestRelease As JObject = Nothing
            Dim latestPreRelease As JObject = Nothing

            For Each release As JObject In releases
                If latestRelease Is Nothing AndAlso Not release("prerelease").Value(Of Boolean)() Then
                    latestRelease = release
                End If

                If latestPreRelease Is Nothing AndAlso release("prerelease").Value(Of Boolean)() Then
                    latestPreRelease = release
                End If

                If latestRelease IsNot Nothing AndAlso latestPreRelease IsNot Nothing Then
                    Exit For
                End If
            Next

            If latestRelease IsNot Nothing Then
                Console.WriteLine("Latest Release: " & latestRelease("tag_name").ToString())
            End If

            If latestPreRelease IsNot Nothing Then
                Console.WriteLine("Latest Pre-release: " & latestPreRelease("tag_name").ToString())
            End If
        End Using
    End Function

    Sub Main()
        'GetReleases()
    End Sub

End Module
