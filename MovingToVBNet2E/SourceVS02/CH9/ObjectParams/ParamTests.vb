' Parameter Tests sample program
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Module Module1

    Class MyObject
        Public X As Integer
    End Class

    Structure MyStruct
        Public X As Integer
    End Structure


    Public Sub FObjByRef1(ByRef Y As MyObject)
        Y.X = 5
    End Sub

    Public Sub FObjByRef2(ByRef Y As MyObject)
        Y = New MyObject()
        Y.X = 5
    End Sub

    Public Sub FObjByVal1(ByVal Y As MyObject)
        Y.X = 5
    End Sub

    Public Sub FObjByVal2(ByVal Y As MyObject)
        Y = New MyObject()
        Y.X = 5
    End Sub

    Public Sub ObjectTests()
        Dim A As New MyObject()
        Dim B As MyObject = A
        A.X = 1
        Console.WriteLine("Initial state")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())
        FObjByRef1(B)
        Console.WriteLine("After FobjByRef1")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())
        A.X = 1
        B = A
        FObjByRef2(B)
        Console.WriteLine("After FobjByRef2")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())
        A.X = 1
        B = A
        FObjByVal1(B)
        Console.WriteLine("After FobjByVal1")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())
        A.X = 1
        B = A
        FObjByVal2(B)
        Console.WriteLine("After FobjByVal2")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())

    End Sub

    Public Sub FStructByRef1(ByRef Y As MyStruct)
        Y.X = 5
    End Sub

    Public Sub FStructByRef2(ByRef Y As MyStruct)
        Y = New MyStruct()
        Y.X = 5
    End Sub

    Public Sub FStructByVal1(ByVal Y As MyStruct)
        Y.X = 5
    End Sub

    Public Sub FStructByVal2(ByVal Y As MyStruct)
        Y = New MyStruct()
        Y.X = 5
    End Sub

    Public Sub StructTests()
        Dim A As MyStruct
        Dim B As MyStruct
        A.X = 1
        B = A
        Console.WriteLine("Initial state StructTests")
        Console.WriteLine("Are A and B the same? " + (A.Equals(B)).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())
        FStructByRef1(B)
        Console.WriteLine("After FStructByRef1")
        Console.WriteLine("Are A and B the same? " + (A.Equals(B)).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())
        A.X = 1
        B = A
        FStructByRef2(B)
        Console.WriteLine("After FStructByRef2")
        Console.WriteLine("Are A and B the same? " + (A.Equals(B)).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())
        A.X = 1
        B = A
        FStructByVal1(B)
        Console.WriteLine("After FStructByVal1")
        Console.WriteLine("Are A and B the same? " + (A.Equals(B)).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())
        A.X = 1
        B = A
        FStructByVal2(B)
        Console.WriteLine("After FStructByVal2")
        Console.WriteLine("Are A and B the same? " + (A.Equals(B)).ToString())
        Console.WriteLine("A.x: " + A.X.ToString() + " B.x " + B.X.ToString())


    End Sub


    Public Sub FStringByRef1(ByRef Y As String)
        Mid$(Y, 1, 1) = "A"
    End Sub

    Public Sub FStringByRef2(ByRef Y As String)
        Y = "Hello"
    End Sub

    Public Sub FStringByRef3(ByRef Y As String)
        Mid$(Y, 1, 1) = "H"
    End Sub

    Public Sub FStringByVal1(ByVal Y As String)
        Mid$(Y, 1, 1) = "A"
    End Sub

    Public Sub FStringByVal2(ByVal Y As String)
        Y = "Hello"
    End Sub

    Public Sub StringTests()
        Dim A As String = "Hello"
        Dim B As String
        B = A
        Console.WriteLine(Chr(10) + "Initial state StringTests")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A: " + A + " B: " + B)
        FStringByRef1(B)
        Console.WriteLine("After FStringByRef1")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A: " + A + " B: " + B)
        A = "Hello"
        B = A
        FStringByRef2(B)
        Console.WriteLine("After FStringByRef2")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A: " + A + " B: " + B)
        A = "Hello"
        B = A
        FStringByRef3(B)
        Console.WriteLine("After FStringByRef3")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("Are A and B equal? " + (A = B).ToString())
        Console.WriteLine("A: " + A + " B: " + B)
        A = "Hello"
        B = A
        FStringByVal1(B)
        Console.WriteLine("After FStringByVal1")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A: " + A + " B: " + B)
        A = "Hello"
        B = A
        FStringByVal2(B)
        Console.WriteLine("After FStringByVal2")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("A: " + A + " B: " + B)


    End Sub


    Public Sub FArrayByRef1(ByRef Y As Integer())
        Y(0) = 5
    End Sub

    Public Sub FArrayByRef2(ByRef Y As Integer())
        Dim NewArray As Integer() = {2, 3, 4, 5, 6}
        Y = NewArray
    End Sub

    Public Sub FArrayByVal1(ByVal Y As Integer())
        Y(0) = 5
    End Sub

    Public Sub FArrayByVal2(ByVal Y As Integer())
        Dim NewArray As Integer() = {2, 3, 4, 5, 6}
        Y = NewArray
    End Sub

    Public Sub DisplayArray(ByVal Y As Integer())
        Dim X As Integer
        For X = 0 To UBound(Y)
            Console.Write(Y(X).ToString)
            If X <> UBound(Y) Then
                Console.Write(", ")
            Else
                Console.WriteLine()
            End If

        Next
    End Sub

    Public Sub ArrayTests()
        Dim A As Integer() = {1, 2, 3, 4, 5}
        Dim B As Integer()
        B = A
        Console.WriteLine("Initial state ArrayTests")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("Array A:")
        DisplayArray(A)
        Console.WriteLine("Array B")
        DisplayArray(B)

        FArrayByRef1(B)
        Console.WriteLine("After FArrayByRef1")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("Array A:")
        DisplayArray(A)
        Console.WriteLine("Array B")
        DisplayArray(B)

        A(0) = 1
        B = A
        FArrayByRef2(B)
        Console.WriteLine("After FArrayByRef2")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("Array A:")
        DisplayArray(A)
        Console.WriteLine("Array B")
        DisplayArray(B)

        A(0) = 1
        B = A
        FArrayByVal1(B)
        Console.WriteLine("After FArrayByVal1")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("Array A:")
        DisplayArray(A)
        Console.WriteLine("Array B")
        DisplayArray(B)

        A(0) = 1
        B = A
        FArrayByVal2(B)
        Console.WriteLine("After FArrayByVal2")
        Console.WriteLine("Are A and B the same? " + (A Is B).ToString())
        Console.WriteLine("Array A:")
        DisplayArray(A)
        Console.WriteLine("Array B")
        DisplayArray(B)


    End Sub

    Public Sub ParamArrayTest1(ByVal ParamArray A() As Integer)
        Dim x As Integer
        For x = 0 To UBound(A)
            Console.WriteLine(A(x))
        Next
    End Sub

    Sub Main()
        ObjectTests()
        StructTests()
        StringTests()
        ArrayTests()

        Console.WriteLine("ParamArrayTest1()")
        ParamArrayTest1()

        Console.WriteLine("ParamArrayTest1(15,17)")
        ParamArrayTest1(15, 17)
        Console.ReadLine()
    End Sub

End Module

