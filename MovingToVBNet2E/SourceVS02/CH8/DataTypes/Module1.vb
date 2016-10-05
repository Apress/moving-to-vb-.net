' Datatypes example program
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Module Module1

    Sub Main()
        Dim o As Object
        o = 5
        console.WriteLine(o)
        console.WriteLine(o.GetType.FullName)
        o = "Hello"
        console.WriteLine(o)
        console.WriteLine(o.GetType.FullName)
        Console.WriteLine(o.GetType.Name)
        Console.WriteLine(TypeName(o))
        console.ReadLine()
    End Sub

End Module

