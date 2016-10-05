' Demonstration that everything is an object.
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Module Module1

    Sub Main()
        console.WriteLine("This is a test")

        Dim i As Integer = 15
        Console.WriteLine(i.ToString())
        console.WriteLine("Hash is: " + i.GetHashCode().ToString())
        Console.WriteLine("Type is: " + i.GetType().ToString)
        console.WriteLine("Type full name is: " + i.GetType().FullName())
        console.WriteLine("Type assembly qualified name is: " + i.GetType().AssemblyQualifiedName)
        Console.WriteLine("Namespace is: " + i.GetType().Namespace)

        console.Write("Press Enter to continue")
        console.ReadLine()

    End Sub

End Module
