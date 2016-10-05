' Demonstration of boolean variables
' Copyright ©2001-2003 by Desaware Inc.
' All Rights Reserved.
Module Module1

    Sub Main()
        Dim A As Boolean
        Dim I As Integer
        A = True
        I = CInt(A)
        Console.WriteLine("Value of Boolean in Integer is: " + I.ToString())

        I = 5
        A = CBool(I)
        Console.WriteLine("Value of Boolean assigned from 5 is : " + A.ToString())
        I = CInt(A)
        Console.WriteLine("And converted back to Integer: " + I.ToString())
        Console.WriteLine("5 And 8: " + (CBool(5) And CBool(8)).ToString)
        Console.WriteLine("5 And 8: " + (5 And 8).ToString())
        Console.ReadLine()
    End Sub

End Module