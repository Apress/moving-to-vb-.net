Imports System.Reflection
Public Class Class1
    Public Function MyVersion() As String
        Return Reflection.Assembly.GetExecutingAssembly.FullName()
    End Function

End Class
