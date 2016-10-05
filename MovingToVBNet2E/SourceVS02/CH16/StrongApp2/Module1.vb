Imports StrongDLL2A
Imports StrongDLL2B
Module Module1

    Sub Main()
        Dim c1 As New StrongDLL2A.Class1()
        Console.WriteLine(c1.MyVersion)
        Dim c2 As New StrongDLL2B.Class1()
        Console.WriteLine(c2.MyVersion)
        Console.WriteLine(c2.MyDependentsVersion)
        Console.ReadLine()

    End Sub

End Module
