Public Interface OpenFramework_Interface
    ReadOnly Property Name As String
    ReadOnly Property MajerVersion As Int64
    ReadOnly Property MinorVersion As Int64
    ReadOnly Property PatchVersion As Int64
    ReadOnly Property Icon As Image
    Function GetForm() As Form
    Sub Initialize(host As OpenFramework_UI_Handler)
End Interface
