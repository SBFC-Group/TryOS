Imports System.Runtime.InteropServices
Imports System.Text

Public Class WifiPanel
    '1

    ' WLAN API declarations
    Private Const WLAN_API_VERSION As UInteger = 2
    Private wlanHandle As IntPtr

    <DllImport("Wlanapi.dll")>
    Private Shared Function WlanOpenHandle(
        ByVal dwClientVersion As UInteger,
        ByVal pReserved As IntPtr,
        ByRef pdwNegotiatedVersion As UInteger,
        ByRef phClientHandle As IntPtr
    ) As UInteger
    End Function

    <DllImport("Wlanapi.dll")>
    Private Shared Function WlanCloseHandle(
        ByVal hClientHandle As IntPtr,
        ByVal pReserved As IntPtr
    ) As UInteger
    End Function

    <DllImport("Wlanapi.dll")>
    Private Shared Function WlanEnumInterfaces(
        ByVal hClientHandle As IntPtr,
        ByVal pReserved As IntPtr,
        ByRef ppInterfaceList As IntPtr
    ) As UInteger
    End Function

    <DllImport("Wlanapi.dll")>
    Private Shared Function WlanGetAvailableNetworkList(
        ByVal hClientHandle As IntPtr,
        ByRef pInterfaceGuid As Guid,
        ByVal dwFlags As UInteger,
        ByVal pReserved As IntPtr,
        ByRef ppAvailableNetworkList As IntPtr
    ) As UInteger
    End Function

    '2

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure WLAN_INTERFACE_INFO
        Public InterfaceGuid As Guid
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
        Public strInterfaceDescription As String
        Public isState As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure WLAN_INTERFACE_INFO_LIST
        Public dwNumberOfItems As Integer
        Public dwIndex As Integer
        Public InterfaceInfo As WLAN_INTERFACE_INFO
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure WLAN_AVAILABLE_NETWORK
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)>
        Public strProfileName As String
        Public dot11Ssid As DOT11_SSID
        Public dot11BssType As Integer
        Public uNumberOfBssids As UInteger
        Public bNetworkConnectable As Boolean
        Public wlanNotConnectableReason As UInteger
        Public uNumberOfPhyTypes As UInteger
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)>
        Public dot11PhyTypes As Integer()
        Public bMorePhyTypes As Boolean
        Public wlanSignalQuality As UInteger
        Public bSecurityEnabled As Boolean
        Public dot11DefaultAuthAlgorithm As Integer
        Public dot11DefaultCipherAlgorithm As Integer
        Public dwFlags As UInteger
        Public dwReserved As UInteger
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure DOT11_SSID
        Public uSSIDLength As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
        Public ucSSID As Byte()
    End Structure

    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        lstNetworks.Items.Clear()
        lblStatus.Text = "Status: Scanning..."

        Dim version As UInteger = 0
        If WlanOpenHandle(WLAN_API_VERSION, IntPtr.Zero, version, wlanHandle) = 0 Then
            Dim pIfList As IntPtr = IntPtr.Zero
            If WlanEnumInterfaces(wlanHandle, IntPtr.Zero, pIfList) = 0 Then
                Dim ifaceList As WLAN_INTERFACE_INFO_LIST = Marshal.PtrToStructure(Of WLAN_INTERFACE_INFO_LIST)(pIfList)
                Dim iface As WLAN_INTERFACE_INFO = ifaceList.InterfaceInfo

                Dim pNetList As IntPtr = IntPtr.Zero
                If WlanGetAvailableNetworkList(wlanHandle, iface.InterfaceGuid, 0, IntPtr.Zero, pNetList) = 0 Then
                    Dim netListHeader As Integer = Marshal.ReadInt32(pNetList)
                    Dim itemCount As Integer = Marshal.ReadInt32(pNetList, 4)
                    Dim ptr As IntPtr = pNetList + 8

                    For i As Integer = 0 To itemCount - 1
                        Dim net As WLAN_AVAILABLE_NETWORK = Marshal.PtrToStructure(Of WLAN_AVAILABLE_NETWORK)(ptr)
                        Dim ssid As String = Encoding.ASCII.GetString(net.dot11Ssid.ucSSID, 0, net.dot11Ssid.uSSIDLength)
                        lstNetworks.Items.Add($"{ssid} ({net.wlanSignalQuality}%)")
                        ptr += Marshal.SizeOf(GetType(WLAN_AVAILABLE_NETWORK))
                    Next

                    lblStatus.Text = "Status: Scan complete"
                Else
                    lblStatus.Text = "Error getting network list"
                End If
            End If
        End If
    End Sub

    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If lstNetworks.SelectedItem Is Nothing Then
            MsgBox("Please select a Wi-Fi network.")
            Return
        End If

        Dim ssid As String = lstNetworks.SelectedItem.ToString().Split("("c)(0).Trim()
        Dim password As String = txtPassword.Text.Trim()

        lblStatus.Text = $"Connecting to {ssid}..."

        Dim profileXml As String =
            $"<?xml version=""1.0""?>
        <WLANProfile xmlns=""http://www.microsoft.com/networking/WLAN/profile/v1"">
            <name>{ssid}</name>
            <SSIDConfig>
                <SSID>
                    <name>{ssid}</name>
                </SSID>
            </SSIDConfig>
            <connectionType>ESS</connectionType>
            <connectionMode>auto</connectionMode>
            <MSM>
                <security>
                    <authEncryption>
                        <authentication>WPA2PSK</authentication>
                        <encryption>AES</encryption>
                        <useOneX>false</useOneX>
                    </authEncryption>
                    <sharedKey>
                        <keyType>passPhrase</keyType>
                        <protected>false</protected>
                        <keyMaterial>{password}</keyMaterial>
                    </sharedKey>
                </security>
            </MSM>
        </WLANProfile>"

        Dim tempPath = IO.Path.Combine(IO.Path.GetTempPath(), $"{ssid}.xml")
        IO.File.WriteAllText(tempPath, profileXml)

        Dim addProfileCmd = $"netsh wlan add profile filename=""{tempPath}"""
        Dim connectCmd = $"netsh wlan connect name=""{ssid}"" ssid=""{ssid}"""

        Shell(addProfileCmd, AppWinStyle.Hide, True)
        Shell(connectCmd, AppWinStyle.Hide, True)

        lblStatus.Text = $"Connected to {ssid}"
    End Sub

    '3

End Class
