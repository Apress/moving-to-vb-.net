' Strings example
' Copyright ©2001-2003 by Desaware Inc.
' All Rights Reserved
Module Module1

    Sub Main()
        Dim A As String
        Dim B As String
        A = "Hello"
        B = "Hel" + "lo"
        console.WriteLine(A = B)
        console.WriteLine(A Is B)

        Mid(A, 1, 1) = "X"
        Mid(B, 1, 1) = "X"
        console.WriteLine(A = B)
        console.WriteLine(A Is B)
        console.WriteLine(A)
        Console.ReadLine()
    End Sub

End Module

