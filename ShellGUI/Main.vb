Imports System.Windows.Forms
Imports TouchTest
Imports TouchTest.CustomController_Data

Public Class Main
    Implements TouchTest.CustomController_Data.CustomController_Interface

    Public Shared Controller As CustomController_Handler
    Public Shared TheCollection As FormCollection

    Public Shared Form1 As Form1
    Public Shared UI As UI
    Public Shared TryController As TryController



    Public ReadOnly Property Name As String Implements CustomController_Interface.Name
        Get
            Return "ShellGUI"
        End Get
    End Property

    Public ReadOnly Property VerifyedCode_ID As String Implements CustomController_Interface.VerifyedCode_ID
        Get
            Return "7384648"
        End Get
    End Property

    Public ReadOnly Property RemoveTaskbar As Boolean Implements CustomController_Interface.RemoveTaskbar
        Get
            Return False
        End Get
    End Property

    Public Sub ExecuteForm1Subs(Form1_Form As Form1) Implements CustomController_Interface.ExecuteForm1Subs
        Form1 = Form1_Form
    End Sub

    Public Sub ExecuteUISubs(UI_Form As UI) Implements CustomController_Interface.ExecuteUISubs
        UI = UI_Form

        Dim ThisForm As New MyControllerForm
        ThisForm.Show()
    End Sub

    Public Sub ExecuteTryControllerSubs(TryController_Form As TryController) Implements CustomController_Interface.ExecuteTryControllerSubs
        TryController = TryController_Form
    End Sub

    Public Sub ConfigFormCollection(Collection As Windows.Forms.FormCollection) Implements CustomController_Interface.ConfigFormCollection
        TheCollection = Collection
    End Sub

    Public Sub Initialize(host As CustomController_UI_Handler) Implements CustomController_Interface.Initialize
        Controller = host
    End Sub
End Class
