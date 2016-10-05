' ModuleScoping example program
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Public Module Module1
    Public X As Integer
    Public Sub PublicMethod()
        Console.WriteLine("MovingToVB.CH10.ModuleScoping.Module1.PublicMethod called")
    End Sub

    Private Sub PrivateMethod()
        Console.WriteLine("MovingToVB.CH10.ModuleScoping.Module1.PrivateMethod called")
    End Sub

End Module

Friend Module Module2
    Public X As Integer
    Public Sub PublicMethod()
        Console.WriteLine("MovingToVB.CH10.ModuleScoping.Module2.PublicMethod called")
    End Sub

    Private Sub PrivateMethod()
        Console.WriteLine("MovingToVB.CH10.ModuleScoping.Module2.PrivateMethod called")

    End Sub


End Module

Public Class Class1
    Public Sub PublicMethod()
        Console.WriteLine("MovingToVB.CH10.ModuleScoping.Class1.PublicMethod called")
        Module2.PublicMethod()
        Module1.PublicMethod()
    End Sub

End Class
