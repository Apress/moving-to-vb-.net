' Graphic Demo
' Copyright ©2001 by Desaware Inc.

Friend Module APIDeclarations
    Friend Const SRCCOPY As Integer = &HCC0020&
    Friend Declare Ansi Function BitBlt Lib "gdi32" (ByVal hDestDC As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As IntPtr, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal dwRop As Integer) As Integer
End Module
