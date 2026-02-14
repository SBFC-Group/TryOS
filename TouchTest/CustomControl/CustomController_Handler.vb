Namespace CustomController_Data
    Public Class CustomController_Handler
        Implements CustomController_UI_Handler

        Public Sub OpenFramework_SaveButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing) Implements CustomController_UI_Handler.OpenFramework_SaveButtonOrder
            OpenFramework_Data.OpenFramework.SaveButtonOrder(AllowCustom, ControlThing)
        End Sub

        Public Sub OpenFramework_RestoreButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing) Implements CustomController_UI_Handler.OpenFramework_RestoreButtonOrder
            OpenFramework_Data.OpenFramework.RestoreButtonOrder(AllowCustom, ControlThing)
        End Sub

        Public Sub OpenFramework_SetNewFlowLayoutPanel(FlowLayoutPanelThing As FlowLayoutPanel) Implements CustomController_UI_Handler.OpenFramework_SetNewFlowLayoutPanel
            OpenFramework_Data.OpenFramework.SetNewFlowLayoutPanel(FlowLayoutPanelThing)
        End Sub

        Public Sub OpenFramework_LoadApps() Implements CustomController_UI_Handler.OpenFramework_LoadApps
            OpenFramework_Data.OpenFramework.LoadApps(Form1.SandboxedUser)
        End Sub

        Public Sub OpenFramework_SetAppNameValue(Text As String) Implements CustomController_UI_Handler.OpenFramework_SetAppNameValue
            OpenFramework_Data.OpenFramework.AppName = Text
        End Sub

        Public Function GetFormCollection() As FormCollection Implements CustomController_UI_Handler.GetFormCollection
            Return My.Application.OpenForms
        End Function

        Public Function OpenFramework_LoadAppsDlls(User As UserManager) As List(Of OpenFramework_Interface) Implements CustomController_UI_Handler.OpenFramework_LoadAppsDlls
            Return OpenFramework_Data.OpenFramework.LoadAppsDlls(User)
        End Function

        Public Function OpenFramework_LoadPlugins_New() As List(Of OpenFramework_Interface) Implements CustomController_UI_Handler.OpenFramework_LoadPlugins_New
            Return OpenFramework_Data.OpenFramework.LoadAppsDlls(Form1.SandboxedUser)
        End Function

        Public Function OpenFramework_LoadPlugins(folder As String) As List(Of OpenFramework_Interface) Implements CustomController_UI_Handler.OpenFramework_LoadPlugins
            Return Nothing
        End Function

        Public Function OpenFramework_GetOpenFrameworkVersion() As Object Implements CustomController_UI_Handler.OpenFramework_GetOpenFrameworkVersion
            Return OpenFramework_Data.OpenFramework.GetOpenFrameworkVersion()
        End Function
    End Class
End Namespace