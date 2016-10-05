' Scoping example in VB.NET
' Copyright ©2001-2003 by Desaware Inc.
Module ScopingMod

    Sub Main()
        Dim Counter As Short
        ' X = 3  ' Variable not defined at this point
        For Counter = 1 To 3
            If True Then '  Always enter this block
                Dim X As Short
                Console.WriteLine(X)
                X = Counter
            End If
        Next Counter
        ' Console.WriteLine("Outside of block: " & X)
        Console.ReadLine()
    End Sub
End Module
