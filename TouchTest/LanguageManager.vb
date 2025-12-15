Imports System.IO
Imports System.Reflection
Imports System.Collections.Generic
Imports Newtonsoft.Json

Public Class LanguageManager
    Private translations As Dictionary(Of String, String)
    Public LanguageFolder As String = ""

    Public Sub New(Optional LanguagePath As String = "")
        If LanguagePath = "" Then
            LanguageFolder = IO.Path.Combine(Application.StartupPath, "Languages")
        Else
            LanguageFolder = LanguagePath
        End If
    End Sub

    Public Sub LoadLanguage(langCode As String)
        Dim path As String = IO.Path.Combine(LanguageFolder, langCode & ".json")
        If File.Exists(path) Then
            Dim json As String = File.ReadAllText(path)
            translations = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
        Else
            MessageBox.Show("Language file not found: " & path)
            translations = New Dictionary(Of String, String)()
        End If
    End Sub

    Public Function Translate(key As String) As String
        If translations.ContainsKey(key) Then
            Return translations(key)
        Else
            Return "[!" & key & "]"
        End If
    End Function
End Class
