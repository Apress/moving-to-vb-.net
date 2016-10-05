' MyBaseMyClass - demonstration of MyBase and MyClass
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Module Module1

    Class A
        Overridable Sub Test()
            Console.WriteLine("A.Test called")
        End Sub
        Sub ACallsTest()
            Console.Write("A Calls Test directly: ")
            Test()
            Console.Write("A Calls MyClass.Test: ")
            MyClass.Test()
        End Sub

    End Class

    Class B
        Inherits A
        ' What happens if you use Shadows on the Test function instead of Overrides?
        Overrides Sub Test()
            Console.WriteLine("B.Test called")
        End Sub
        Sub BCallsTest()
            Console.Write("B Calls Test directly: ")
            Test()
            Console.Write("B Calls MyBase.Test: ")
            MyBase.Test()
        End Sub
    End Class


    Sub Main()
        Dim aref As New A()
        Dim bref As New B()
        Console.WriteLine("Object A")
        aref.ACallsTest()
        Console.WriteLine("Object B")
        bref.ACallsTest()
        Console.WriteLine("Object B")
        bref.BCallsTest()
        console.ReadLine()
    End Sub

End Module

