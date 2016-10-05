' Demonstration of conversions
' Copyright ©2001-2003 by Desaware Inc.
' All Rights Reserved
Module Module1


    Sub Main()
        Dim I As Integer, L As Long
        I = 50
        L = I
        Console.WriteLine(L)
        L = 50
        I = CInt(L) ' Explicit cast needed here
        Console.WriteLine(I)
        L = &H100000000
        Try
            I = CType(L, Integer)
        Catch E As Exception
            Console.WriteLine(E.Message)
        End Try

        Console.WriteLine(I)
        Console.ReadLine()

    End Sub

End Module
