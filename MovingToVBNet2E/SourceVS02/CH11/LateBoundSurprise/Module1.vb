' LateBoundSurprise example
' Copyright ©2003 by Desaware Inc.
Public Class myTestClass
    Private m_PrivateProperty As Integer

    Public Sub New(ByVal InitialValue As Integer)
        m_PrivateProperty = InitialValue
    End Sub

    Public ReadOnly Property AProperty() As Integer
        Get
            Return m_PrivateProperty
        End Get
    End Property
End Class


Module Module1

    Sub Main()
        Dim testclass As New myTestClass(5)
        Console.WriteLine(testclass.AProperty)

        Dim T As Type
        T = testclass.GetType
        T.InvokeMember("m_PrivateProperty", Reflection.BindingFlags.SetField Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance, Nothing, testclass, New Object() {10})
        Console.WriteLine(testclass.AProperty)

        Console.ReadLine()
    End Sub

End Module
