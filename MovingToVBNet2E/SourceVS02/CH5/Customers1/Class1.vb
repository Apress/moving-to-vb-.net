' Customers sample application
' Copyright ©2001 by Desaware inc. All Rights Reserved
Public MustInherit Class Customer
    Public Name As String
    Public MustOverride Function DefaultNet() As Integer
    Public Overridable Function DisplayTerms() As String
        DisplayName()
        Console.WriteLine("... is net " + CStr(DefaultNet()))
    End Function
    Sub DisplayName()
        Console.WriteLine("Customer is " + Name)
    End Sub

End Class

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
