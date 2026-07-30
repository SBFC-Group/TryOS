Imports System.Drawing
Imports System.Windows.Forms
Imports TouchTest

Public Class Main
    Implements TouchTest.OpenFramework_Interface

    Public Shared Controller As OpenFramework_Handler

    Public ReadOnly Property Name As String Implements OpenFramework_Interface.Name
        Get
            Return "SettingsForm"
        End Get
    End Property

    Public ReadOnly Property MajerVersion As Long Implements OpenFramework_Interface.MajerVersion
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property MinorVersion As Long Implements OpenFramework_Interface.MinorVersion
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property PatchVersion As Long Implements OpenFramework_Interface.PatchVersion
        Get
            Return 0
        End Get
    End Property

    Public ReadOnly Property Icon As Image Implements OpenFramework_Interface.Icon
        Get
            Return My.Resources.settings_configuration_icon_225724
        End Get
    End Property

    Public Sub Initialize(host As OpenFramework_UI_Handler) Implements OpenFramework_Interface.Initialize
        Controller = host
    End Sub

    Public Function GetForm() As Form Implements OpenFramework_Interface.GetForm

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\ShellApps\ShellGUI\SettingsApp.SettingsForm.txt") Then
            If Controller.ContainsSetting("DisableNewSettings") = True Then
                Dim bool As Boolean = False
                Try
                    bool = Convert.ToBoolean(Controller.GetSettingValue("DisableNewSettings"))
                Catch ex As Exception
                End Try

                If bool = True Then
                    Return New TouchTest.SettingsForm
                Else
                    Return New SettingsForm
                End If
            Else
                Return New SettingsForm
            End If

        Else
                Return New TouchTest.SettingsForm
        End If


    End Function
End Class
