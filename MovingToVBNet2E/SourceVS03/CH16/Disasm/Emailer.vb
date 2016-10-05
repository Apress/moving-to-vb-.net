Public Class Emailer
    Public Function VerifyEmail(ByVal Email As String) As Boolean
        If InStr(Email, "@") > 0 Then Return True
    End Function

    Public Function GetMyHost() As String
        Delay()
        Return System.Net.Dns.GetHostName()
    End Function

    Private Function Delay() As Integer
        Dim x As Long
        Dim x2 As Long
        For x = 1 To 1000000
            x2 = x2 + 1
        Next
    End Function
End Class
