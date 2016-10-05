' Enumeration example
' Copyright ©2001-2003 by Desaware Inc.
' All Rights Reserved

Module Module1

    Enum E
        A = 5
        B
        C = 6   ' B and C will both be 6
    End Enum

    <Flags()> Enum B
        A = &H1
        B = &H2
        C = &H4
    End Enum

    Enum C
        A = &H1
        B = &H2
        C = &H4
    End Enum


    Sub F(ByVal X As E)

    End Sub

    Sub FB(ByVal X As B)
    End Sub

    Sub Main()
        Dim I1, I2, I3 As Integer
        I1 = E.A : I2 = E.B : I3 = E.C
        ' We can't use ToString directly on the enumeration value because
        ' that returns the enumeration name, not the value
        Console.WriteLine(I1.ToString() + I2.ToString() + I3.ToString())
        F(E.C)
        FB(B.A Or B.C Or B.B)
        Console.WriteLine(E.Format(GetType(E), 5, "G"))
        Console.WriteLine(C.Format(GetType(C), (C.A Or C.C), "G"))
        Console.WriteLine(B.Format(GetType(B), (B.A Or B.C), "G"))
        Console.ReadLine()
    End Sub

End Module
