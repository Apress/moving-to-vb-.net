' Operators example
' Copyright ©2001-2003 by Desaware Inc.
' All Rights Reserved
Module Module1

    Sub Evil()
        'Console.WriteLine(15 + "15" + "15") ' Compile error
        Console.WriteLine("Evil Typing")
        Console.WriteLine(15.ToString + "15" + "15")
    End Sub

    Sub Concatenators()
        Dim S As String
        Dim A As Integer
        S = "Hello"
        S += " Everybody"
        A = 5
        A += 10
        Console.WriteLine("Concatenators")
        Console.WriteLine(S)
        Console.WriteLine(A)
    End Sub

    Public Sub Strings()
        Dim A As String = "ABCD"
        Console.WriteLine("String Characters")
        Console.WriteLine(InStr(A, "C"))
        Console.WriteLine(A.IndexOf("C"))
    End Sub

    Sub Main()
        Evil()

        Concatenators()

        Strings()

        Console.ReadLine()
    End Sub


End Module

