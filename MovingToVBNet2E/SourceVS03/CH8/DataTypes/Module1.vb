' Datatypes example program
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Module Module1

    Sub Main()
        Dim o As Object
        o = 5
        console.WriteLine(o)
        console.WriteLine(o.GetType.FullName)
        o = "Hello"
        console.WriteLine(o)
        Console.WriteLine(o.GetType.FullName)
        Console.WriteLine(o.GetType.Name)
        Console.WriteLine(TypeName(o))
        Console.ReadLine()
    End Sub

End Module

