' Bounded array example
' Copyright ©2001 by Desaware Inc.
' All Rights Reserved
Module Module1

    Sub Main()
        Dim X As Array
        Dim I As Integer
        Dim Lengths(0) As Integer
        Dim LowerBounds(0) As Integer

        Lengths(0) = 10
        LowerBounds(0) = 1

        X = Array.CreateInstance(GetType(System.Int32), Lengths, LowerBounds)

        Try
            X.SetValue(5, 0)
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        X.SetValue(6, 1)
        Console.WriteLine(X.GetValue(1))

        Console.ReadLine()


    End Sub

End Module
