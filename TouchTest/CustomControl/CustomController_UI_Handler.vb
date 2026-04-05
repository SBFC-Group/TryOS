Namespace CustomController_Data
    Public Interface CustomController_UI_Handler
        Function GetFormCollection() As FormCollection
        Function OpenFramework_LoadAppsDlls(User As UserManager) As List(Of OpenFramework_Interface)
        Function OpenFramework_LoadPlugins_New() As List(Of OpenFramework_Interface)
        Function OpenFramework_LoadPlugins(folder As String) As List(Of OpenFramework_Interface)
        Function OpenFramework_GetOpenFrameworkVersion()
        Sub OpenFramework_SetNewFlowLayoutPanel(FlowLayoutPanelThing As FlowLayoutPanel)
        Sub OpenFramework_LoadApps()
        Sub OpenFramework_SaveButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing)
        Sub OpenFramework_RestoreButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing)
        Sub OpenFramework_SetAppNameValue(Text As String)
    End Interface
End Namespace