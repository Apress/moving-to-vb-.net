' Misc chapter 12 examples
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Class WillClone
    Implements ICloneable
    Public X As Integer
    Public Y As String
    Public Function Clone() As Object Implements ICloneable.Clone
        Dim n As New WillClone()
        n.X = X
        ' When you're cloning, you'll usually want to clone internal objects as well
        n.Y = String.Copy(Y)
        Return n
    End Function
End Class


Module Module1

    Sub BitConverterDemo()
        Dim d As Double = 1.5E+64
        Dim BitArray() As Byte = BitConverter.GetBytes(d)
        Console.WriteLine(BitConverter.ToString(BitArray))
        Console.WriteLine(BitConverter.ToDouble(BitArray, 0))
        Console.WriteLine()
    End Sub

    Sub EnvironmentDemo()
        Console.WriteLine(Environment.CurrentDirectory)
        Console.WriteLine(Environment.OSVersion.ToString)
        Console.WriteLine(Environment.SystemDirectory)
        Console.WriteLine()
    End Sub


    Public Sub WillCloneDemo()
        Dim obj1 As New WillClone()
        obj1.Y = "Test"
        Dim obj2 As WillClone = obj1
        If obj1 Is obj2 And obj1.Y Is obj2.Y Then
            Console.WriteLine("Objects are the same")
        End If
        obj2 = CType(obj1.Clone(), WillClone)
        If (Not obj1 Is obj2) And (Not obj1.Y Is obj2.Y) And (obj1.Y = obj2.Y) Then
            Console.WriteLine("Objects are not the same but strings are equal")
        End If
        Console.WriteLine()
    End Sub

    Sub ArrayDemo()
        Dim A() As Integer = {5, 4, 10, 2, 1}
        Array.Sort(A)
        Dim i As Integer
        Console.WriteLine("Array Tests")
        For Each i In A
            Console.WriteLine(i)
        Next
        Console.WriteLine()
    End Sub

    Public Sub StringSprintDemo()
        Dim S As String = "a,b,c,d,e,f"
        ' This slightly bizzare syntax takes the string "," and extracts the first character
        Dim Separators() As Char = {",".Chars(0)}
        Dim SArray() As String
        SArray = S.Split(Separators)
        For Each S In SArray
            Console.WriteLine(S)
        Next
    End Sub

    Public Sub RegExDemo()
        Dim rg As New Text.RegularExpressions.Regex("\w+@(\w+\.)+\w+$")
        Dim Emails() As String = {"joe@@nospam..com", "joe@nospam.com.", "joe@nospam.com"}
        Dim testEmail As String
        For Each testEmail In Emails
            Console.Write("Email address " & testEmail)
            If rg.IsMatch(testEmail) Then
                Console.WriteLine(" is valid")
            Else
                Console.WriteLine(" is not valid")
            End If
        Next
    End Sub

    Public Sub URIDemo()
        Dim u As New Uri("http://www.desaware.com")
        Console.WriteLine(u.Host)
        Console.WriteLine(u.Port)
        Console.WriteLine(u.Scheme)
    End Sub

    Sub Main()
        ArrayDemo()
        BitConverterDemo()
        EnvironmentDemo()
        WillCloneDemo()
        StringSprintDemo()
        RegExDemo()
        URIDemo()
        Console.ReadLine()
    End Sub

End Module
