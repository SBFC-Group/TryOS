Namespace CustomController_Data
    Public Interface CustomController_UI_Handler
        Function GetFormCollection() As FormCollection
        Sub OpenFramework_SaveButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing)
        Sub OpenFramework_RestoreButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing)
    End Interface
End Namespace