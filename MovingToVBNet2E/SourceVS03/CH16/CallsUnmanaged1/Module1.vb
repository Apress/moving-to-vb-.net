' Calling unmanaged class
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Imports UnmanagedClass
Module Module1

    Sub Main()
        Dim c As New Class1()
        Dim x As Integer
        For x = 0 To 100
            Console.WriteLine(c.Ticks)
        Next
        Console.ReadLine()
    End Sub

End Module
