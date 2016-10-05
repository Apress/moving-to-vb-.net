' Example of resolving interface name conflicts
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Module Module1

    Public Sub Main()
        Dim c As New class1()
        Dim i1 As MySecondInterface
        c.CommonFunction()
        i1 = c
        i1.CommonFunction()
        Console.ReadLine()

    End Sub

End Module
