Namespace CustomController_Data
    Public Class CustomController_Handler
        Implements CustomController_UI_Handler

        Public Sub OpenFramework_SaveButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing) Implements CustomController_UI_Handler.OpenFramework_SaveButtonOrder
            OpenFramework_Data.SaveButtonOrder(AllowCustom, ControlThing)
        End Sub

        Public Sub OpenFramework_RestoreButtonOrder(Optional AllowCustom As Boolean = False, Optional ControlThing As Control = Nothing) Implements CustomController_UI_Handler.OpenFramework_RestoreButtonOrder
            OpenFramework_Data.RestoreButtonOrder(AllowCustom, ControlThing)
        End Sub

        Public Function GetFormCollection() As FormCollection Implements CustomController_UI_Handler.GetFormCollection
            Return My.Application.OpenForms
        End Function
    End Class
End Namespace