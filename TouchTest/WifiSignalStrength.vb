Public Class WifiSignalStrength
    Private Sub Button1_Click()
        Dim signalStrength As Integer = GetWifiSignalStrength()
        MessageBox.Show("WiFi Signal Strength: " & signalStrength & "%")
    End Sub

    Public Shared Function GetWifiSignalStrength() As Integer
        Try
            Dim psi As New ProcessStartInfo("netsh", "wlan show interfaces")
            psi.RedirectStandardOutput = True
            psi.UseShellExecute = False
            psi.CreateNoWindow = True

            Dim process As Process = Process.Start(psi)
            Dim output As String = process.StandardOutput.ReadToEnd()
            process.WaitForExit()

            Dim lines As String() = output.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In lines
                If line.Trim().ToLower().StartsWith("signal") Then
                    Dim parts() As String = line.Split(":"c)
                    If parts.Length > 1 Then
                        Dim signalStr As String = parts(1).Trim().Replace("%", "")
                        Return Integer.Parse(signalStr)
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        Return -1
    End Function
End Class
