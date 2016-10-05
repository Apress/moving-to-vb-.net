' PropByRef sample program
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Class PropClass
    Private m_Member As String
    ' Overloads keyword is options in this example
    Overloads Property Member() As String
        Get
            Return m_Member
        End Get
        Set(ByVal Value As String)
            m_Member = Value
        End Set
    End Property

    Overloads Property Member(ByVal x As Integer) As String
        Get
            Return (m_Member)
        End Get
        Set(ByVal Value As String)
            m_Member = Value & " called with " & x.ToString()
        End Set
    End Property


End Class


Module Module1

    Sub FunctionSetsString(ByRef s As String)
        s = "Hello"
    End Sub


    Sub Main()
        Dim obj As New PropClass()
        FunctionSetsString(obj.Member)
        Console.WriteLine(obj.Member)
        FunctionSetsString(obj.Member(5))
        Console.WriteLine(obj.Member)
        Console.ReadLine()
    End Sub

End Module
