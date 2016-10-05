Public Class Class1
    Private Declare Auto Function GetTickCount Lib "kernel32" () As Integer
    Public Function Ticks() As Integer
        Return GetTickCount()
    End Function
End Class
