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

        Public Shared Sub _7()
            OpenFramework_Data.LoadApps()
        End Sub

        Public Shared Sub _8(folderpath As String)
            OpenFramework_Data.LoadPlugins(folderpath)
        End Sub

        Public Shared Sub _9()
            OpenFramework_Data.LoadPlugins_New()
        End Sub

        Public Shared Function _10()
            'Form1.Button3
            Return Form1.Button3
        End Function
    End Class
End Namespace