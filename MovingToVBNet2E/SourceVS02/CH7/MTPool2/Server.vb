' Thread Pool Implementation #2
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Imports System.Threading
Public Class Server
    Public Sub ServerOp(ByVal Duration As Integer)
        Thread.Sleep(Duration)
    End Sub
End Class
