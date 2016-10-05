' I/O Demo
' Copyright ©2001-2003 by Desaware Inc.
Imports System.IO

Module Module1
    Const StringToReadFrom As String = "This is a string to read with a string reader"

    Private Sub ShowTheStream(ByVal tr As TextReader)
        Dim i As Integer
        Do
            i = tr.Read()
            If i >= 0 Then
                Console.Write(Chr(i))
            End If

        Loop While i >= 0

    End Sub


    Sub Main()
        Dim sr As New StringReader(StringToReadFrom)
        Dim i As Integer
        ShowTheStream(sr)
        Console.WriteLine()

        Dim fs As New FileStream("..\demo.txt", FileMode.Open)
        Dim strread As New StreamReader(fs)
        ShowTheStream(strread)
        fs.Close()
        strread.Close()

        Console.ReadLine()
    End Sub

End Module
