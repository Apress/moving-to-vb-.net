' Fragile Class Demo #1
' Copyright �2001 by Desaware Inc. All Rights Reserved

' Add reference to the ClassLibrary1 DLL !!!!

Imports MigratingBook.Chapter5.ClassLibrary2

Public Class Commercial
    Inherits Customer
    Public Overrides Function DefaultNet() As Integer
        Return (30)
    End Function
End Class
Public Class Individual
    Inherits Customer
    Public Overrides Function DefaultNet() As Integer
        Return (0)
    End Function
    Public Overrides Function DisplayTerms() As String
        DisplayName()
        Console.WriteLine("... must pay immediately")
    End Function

End Class
Public Class Government
    Inherits Customer
    Public Overrides Function DefaultNet() As Integer
        Return (120)
    End Function
    Public Overrides Function DisplayTerms() As String
        DisplayName()
        Console.WriteLine("... will pay someday we hope")
    End Function
    Sub BranchInfo()
        Console.WriteLine("Legislative")
    End Sub

End Class
