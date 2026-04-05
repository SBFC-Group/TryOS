Namespace CustomController_Data
    Public Class CustomController_Handler
        Implements CustomController_UI_Handler

        Public Sub OpenFramework_SaveButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing) Implements CustomController_UI_Handler.OpenFramework_SaveButtonOrder
            OpenFramework_Data.SaveButtonOrder(AllowCustom, ControlThing)
        End Sub

        Public Sub OpenFramework_RestoreButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing) Implements CustomController_UI_Handler.OpenFramework_RestoreButtonOrder
            OpenFramework_Data.RestoreButtonOrder(AllowCustom, ControlThing)
        End Sub

        Public Sub OpenFramework_SetNewFlowLayoutPanel(FlowLayoutPanelThing As FlowLayoutPanel) Implements CustomController_UI_Handler.OpenFramework_SetNewFlowLayoutPanel
            OpenFramework_Data.SetNewFlowLayoutPanel(FlowLayoutPanelThing)
        End Sub

        Public Sub OpenFramework_LoadApps() Implements CustomController_UI_Handler.OpenFramework_LoadApps
            OpenFramework_Data.LoadApps()
        End Sub

        Public Sub OpenFramework_SetAppNameValue(Text As String) Implements CustomController_UI_Handler.OpenFramework_SetAppNameValue
            OpenFramework_Data.AppName = Text
        End Sub

        Public Function GetFormCollection() As FormCollection Implements CustomController_UI_Handler.GetFormCollection
            Return My.Application.OpenForms
        End Function

        Public Function OpenFramework_LoadAppsDlls(User As UserManager) As List(Of OpenFramework_Interface) Implements CustomController_UI_Handler.OpenFramework_LoadAppsDlls
            Return OpenFramework_Data.LoadPlugins_New()
        End Function

        Public Function OpenFramework_LoadPlugins_New() As List(Of OpenFramework_Interface) Implements CustomController_UI_Handler.OpenFramework_LoadPlugins_New
            Return OpenFramework_Data.LoadPlugins_New()
        End Function

        Public Function OpenFramework_LoadPlugins(folder As String) As List(Of OpenFramework_Interface) Implements CustomController_UI_Handler.OpenFramework_LoadPlugins
            Return OpenFramework_Data.LoadPlugins(folder)
        End Function

        Public Function OpenFramework_GetOpenFrameworkVersion() As Object Implements CustomController_UI_Handler.OpenFramework_GetOpenFrameworkVersion
            Return OpenFramework_Data.GetOpenFrameworkVersion()
        End Function
    End Class
End Namespace