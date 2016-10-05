' Calling unmanaged class
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Imports UnmanagedClass2
Module Module1

    Sub Main()
        Dim c As New Class1()
        Dim x As Integer
        Dim t As TimeSpan
        t = c.Ticks2
        Console.WriteLine("Ticks2: " & t.TotalMilliseconds & " ms")
        t = c.Ticks3
        Console.WriteLine("Ticks3: " & t.TotalMilliseconds & " ms")
        t = c.Ticks4
        Console.WriteLine("Ticks4: " & t.TotalMilliseconds & " ms")
        Console.ReadLine()
    End Sub

End Module
