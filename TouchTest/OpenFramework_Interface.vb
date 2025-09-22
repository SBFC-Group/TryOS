Public Interface OpenFramework_Interface
    ReadOnly Property Name As String
    ReadOnly Property Icon As Image
    Function GetForm() As Form
    Sub Initialize(host As OpenFramework_UI_Handler)

End Interface
