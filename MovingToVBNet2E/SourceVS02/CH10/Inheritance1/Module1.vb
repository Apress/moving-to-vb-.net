' Inheritance1 sample project
' Copyright ©2001 by Desaware Inc.
Class A
    Class B
        Sub Test()
            Console.WriteLine("A.B.Test")
        End Sub
    End Class
    Class D
        Sub Test()
            Console.WriteLine("A.D.Test")
        End Sub
    End Class

End Class

Class C
    Inherits A
    Shadows Class B
        Sub Test()
            Console.WriteLine("C.B.Test")
        End Sub
    End Class

End Class

Module Module1

    Sub Main()
        Dim abref As New A.B()
        Dim cdref As New C.D()
        Dim cbref As New C.B()
        abref.Test()
        cdref.Test()
        cbref.Test()

        Console.ReadLine()

    End Sub

End Module
