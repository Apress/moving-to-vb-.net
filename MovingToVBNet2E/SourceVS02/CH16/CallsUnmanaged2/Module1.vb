' Calling unmanaged class
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Imports UnmanagedClass2
Module Module1

    Sub Main()
        Dim c As New Class1()
        Dim x As Integer
        Dim t As TimeSpan
        t = c.Ticks2
        Console.WriteLine("Ticks2: " & t.ToString() & " ms")
        t = c.Ticks3
        Console.WriteLine("Ticks3: " & t.ToString() & " ms")
        Console.ReadLine()
    End Sub

End Module
