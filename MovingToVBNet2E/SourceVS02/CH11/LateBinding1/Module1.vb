' Late binding example #1
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Option Strict Off

Interface ITestInterface1
    Sub Test()

End Interface

Interface ITestInterface2
    Sub Test()

End Interface

Class A
    Implements ITestInterface1
    Implements ITestInterface2
    Sub Test1() Implements ITestInterface1.Test
        Console.WriteLine("Test1 called")
    End Sub
    Sub Test2() Implements ITestInterface2.Test
        Console.WriteLine("Test2 called")
    End Sub
End Class

Module Module1

    Sub Main()
        Dim obj As Object
        Dim Aclass As New A()
        Dim it1 As ITestInterface1
        Dim it2 As ITestInterface2

        Aclass.Test1()
        Aclass.Test2()
        obj = Aclass
        obj.Test1()
        obj.Test2()
        Try
            obj.Test3()
        Catch e As Exception
            console.WriteLine("Late binding error: " & e.Message)
        End Try
        it1 = Aclass
        it1.Test()
        obj = it1
        Try
            obj.Test()
        Catch e As Exception
            Console.WriteLine("Can't late bind to implemented interface")
        End Try

        obj.Test1()
        Console.ReadLine()
    End Sub

End Module

