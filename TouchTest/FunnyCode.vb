Namespace FunnyCode
    Public Class FunnyCode
        Public Shared Function _1()
            'Form1.Panel1
            Return Form1.Panel1
        End Function

        Public Shared Function _2()
            'Form1.Panel2
            Return Form1.Panel2
        End Function

        Public Shared Function _3()
            'Form1.Panel3
            Return Form1.Panel3
        End Function

        Public Shared Function _4()
            'Form1.FlowLayoutPanel1
            Return Form1.FlowLayoutPanel1
        End Function

        Public Shared Function _5()
            'Form1.Button4
            Return Form1.Button4
        End Function

        Public Shared Function _6()
            'Form1.Button3
            Return My.Application.OpenForms
        End Function

        Public Shared Sub _7(Optional User As UserManager = Nothing)
            If User IsNot Nothing Then
                OpenFramework_Data.OpenFramework.LoadApps(User)
            Else
                OpenFramework_Data.OpenFramework.LoadApps(Form1.SandboxedUser)
            End If

        End Sub

        Public Shared Sub _8(folderpath As String)

        End Sub

        Public Shared Sub _9()
            OpenFramework_Data.OpenFramework.LoadAppsDlls(Form1.SandboxedUser)
        End Sub

        Public Shared Function _10()
            'Form1.Button3
            Return Form1.Button3
        End Function
    End Class
End Namespace