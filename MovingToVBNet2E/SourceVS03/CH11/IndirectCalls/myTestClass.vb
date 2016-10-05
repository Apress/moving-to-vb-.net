' Indirect call example
' Copyright ©2001-2003 by Desaware Inc.
Public Class myTestClass
    Public Function A(ByVal InputValue As Integer) As Integer
        Return InputValue * 2
    End Function
    Public Function B(ByVal InputValue As Integer) As Integer
        Return InputValue * 3
    End Function
    Public Function C(ByVal InputValue As Integer) As Integer
        Return InputValue * 4
    End Function

End Class
