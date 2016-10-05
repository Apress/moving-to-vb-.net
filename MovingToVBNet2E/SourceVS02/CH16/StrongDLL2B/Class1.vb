Imports System.Reflection
Imports StrongDLL2A
Public Class Class1
    Public Function MyVersion() As String
        Return Reflection.Assembly.GetExecutingAssembly.FullName()
    End Function
    Public Function MyDependentsVersion() As String
        Dim c As New StrongDLL2A.Class1()
        Return c.MyVersion
    End Function
End Class
