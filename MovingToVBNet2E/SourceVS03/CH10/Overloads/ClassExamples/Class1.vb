' Overloads demonstration program
' Copyright ©2001-2003 by Desaware Inc.
Public Class InternalClass1
    Private m_Name As String
    Shared Sub New()
        Console.WriteLine("Shared constructor called")
    End Sub
    Private Sub New()
        m_Name = "Default"
    End Sub
    Public Sub New(ByVal NewName As String)
        m_Name = NewName
    End Sub

    Public Shared Function GetDefaultObject() As InternalClass1
        Return New InternalClass1()
    End Function

    Public Sub Test()
        Console.WriteLine("Test in InternalClass1, name is: " & m_Name)
    End Sub
End Class

Public Class InternalClass2
    Friend Sub New()
        MyBase.New()

    End Sub

    Public Overridable Sub Test()
        Console.WriteLine("InternalClass2 Test called")
    End Sub

    Public Sub Test(ByVal x As Integer)
        Console.WriteLine("InternalClass2 Test(ByVal x as integer) called")
    End Sub
End Class


Public Class InternalClass3
    Inherits InternalClass2

    Public Overloads Overrides Sub Test()
        Console.WriteLine("InternalClass3() Test called")
    End Sub
    Public Overloads Sub Test(ByVal S As String)
        Console.WriteLine("InternalClass3 Test(ByVal s as String) called")
    End Sub

End Class

Public Class Class1
    Public Function GetInternalClass2() As InternalClass2
        ' You can do additional initialization here, or
        ' even security checks
        Return New InternalClass2()
    End Function
End Class
