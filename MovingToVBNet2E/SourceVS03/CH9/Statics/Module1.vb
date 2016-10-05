' Statics Test
' Copyright ©2001-2003 by Desaware Inc.
Class C
    Public Shared Sub SharedTest()
        Static x As Integer
        x = x + 1
        console.WriteLine(x)
    End Sub

    Public Sub Test()
        Static x As Integer
        x = x + 1
        console.WriteLine(x)
    End Sub
End Class

Module Module1

    Sub Main()
        Dim c1 As New C()
        Dim c2 As New C()
        c1.Test()
        c1.Test()
        c2.Test()
        c2.Test()
        c.SharedTest()
        c.SharedTest()
        console.ReadLine()


    End Sub

End Module
