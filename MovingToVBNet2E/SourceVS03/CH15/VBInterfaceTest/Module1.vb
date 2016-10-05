' Test program for VBInterface DLL
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Imports System.Runtime.InteropServices

Module Module1
    Public Declare Auto Function ReceivesInteger Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal s As Integer) As Integer
    Public Declare Auto Function ReceivesShort Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal s As Short) As Short
    Public Declare Auto Function ReceivesBytes Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal a As Byte, ByVal B As Byte) As Byte
    Public Declare Auto Function ReceivesLong Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal a As Long) As Long
    Public Declare Auto Function ReceivesSingle Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal a As Single) As Single
    Public Declare Auto Function ReceivesDouble Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal a As Double) As Double
    Public Declare Auto Sub Add5ToShort Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByRef i As Short)
    Public Declare Auto Sub Add5ToLong Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByRef l As Long)
    Public Declare Auto Sub Add5ToSingle Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByRef fs As Single)
    Public Declare Auto Sub Add5ToDouble Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByRef fd As Double)
    Public Declare Ansi Sub ReceivesANSIString Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal s As String)
    Public Declare Unicode Sub ReceivesUnicodeString Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal s As String)
    Public Declare Auto Sub ReceivesAutoString Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal s As String, ByVal chars As Integer)
    Public Declare Sub ReceivesNoInfoString Lib "..\..\VBInterface\Debug\VBInterface.dll" Alias "ReceivesAutoString" (ByVal s As String, ByVal chars As Integer)
    Public Declare Auto Sub ChangesString Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByVal s As String)
    Public Declare Auto Sub ChangesByRefString Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByRef s As String)
    Public Declare Unicode Sub ChangesBSTRString Lib "..\..\VBInterface\Debug\VBInterface.dll" (<MarshalAs(UnmanagedType.BStr)> ByRef s As String)
    Public Declare Unicode Function ReturnsVBString Lib "..\..\VBInterface\Debug\VBInterface.dll" () As <MarshalAs(UnmanagedType.BStr)> String
    Public Declare Sub ReceivesShortArray1 Lib "..\..\VBInterface\Debug\VBInterface.dll" Alias "ReceivesShortArray" (ByRef i As Short)
    Public Declare Sub ReceivesShortArray2 Lib "..\..\VBInterface\Debug\VBInterface.dll" Alias "ReceivesShortArray" (ByVal i() As Short)
    Public Declare Sub ReceivesShortRefArray Lib "..\..\VBInterface\Debug\VBInterface.dll" (ByRef i() As Short)

    Public Declare Sub ReturnsSafeArray Lib "..\..\VBInterface\Debug\VBInterface.dll" (<MarshalAs(UnmanagedType.SafeArray)> ByRef i() As Short)

    Public Declare Ansi Sub ReceivesUserType1 Lib "..\..\VBInterface\Debug\VBInterface.dll" Alias "ReceivesUserType" (ByRef bstruct As GoodStruct)

    <StructLayout(LayoutKind.Sequential, Pack:=1)> Public Structure GoodStruct
        Public A As Byte
        Public B As Short
        Public C As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public D() As Byte
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)> Public E As String

        Public Sub InitStruct()
            A = 1
            B = 2
            C = 3
            ReDim D(3)
            D(0) = 4
            D(1) = 5
            D(2) = 6
            D(3) = 7
            E = "16 char string "   ' with null
        End Sub
    End Structure




    Sub Numbers()
        Dim i As Integer
        Dim b As Byte
        Dim l As Long
        Dim s As Short
        Dim fs As Single
        Dim fd As Double
        i = ReceivesShort(4)
        Console.WriteLine(i)
        i = ReceivesInteger(5)
        Console.WriteLine(i)
        s = 8
        Add5ToShort(s)
        console.WriteLine(s)

        b = ReceivesBytes(CByte(Asc("A")), CByte(Asc("B")))
        Console.WriteLine(b)
        l = ReceivesLong(&H1000200030004000)
        Console.WriteLine(Hex$(l))
        Add5ToLong(l)
        Console.WriteLine(Hex$(l))
        fs = ReceivesSingle(123.4)
        Console.WriteLine(fs)
        Add5ToSingle(fs)
        Console.WriteLine(fs)
        fd = ReceivesDouble(234.5)
        Console.WriteLine(fd)
        Add5ToDouble(fd)
        Console.WriteLine(fd)

    End Sub

    Sub Strings()
        Dim s As String = "Test string"
        Dim s2 As String
        console.WriteLine("Strings examples")
        ReceivesANSIString(s)
        ReceivesUnicodeString(s)
        s2 = s
        ReceivesAutoString(s, Len(s))
        If Not s2 Is s Then
            Console.WriteLine("s and s2 are no longer the same after after ReceivesAutoString")
        End If
        ReceivesNoInfoString(s, Len(s))
        s2 = s
        ChangesString(s)
        If Not s2 Is s Then
            Console.WriteLine("s and s2 are no longer the same after ChangesString")
        End If
        Console.WriteLine("Changed String: " & s)
        ChangesByRefString(s)
        Console.WriteLine("Changed ByRef String: " & s)
        ChangesBSTRString(s)
        Console.WriteLine("Changed BSTR String: " & s)
        s = ReturnsVBString()
        Console.WriteLine("Returned String: " & s)
    End Sub

    Sub Arrays()
        Dim i() As Short = {1, 2, 3, 4}
        Dim x As Integer

        ReceivesShortArray1(i(0))
        For x = 0 To 3
            Console.Write(Str(i(x)) & ", ")
        Next x
        console.WriteLine()

        ReceivesShortArray2(i)
        For x = 0 To 3
            Console.Write(Str(i(x)) & ", ")
        Next x
        console.WriteLine()

        ReceivesShortRefArray(i)
        Console.WriteLine("Array bound is now: " & UBound(i))
        console.WriteLine()

        ReturnsSafeArray(i)
        For x = 0 To UBound(i)
            Console.Write(Str(i(x)) & ", ")
        Next
        console.WriteLine()

    End Sub

    Sub Structs()
        Dim g As GoodStruct
        g.InitStruct()
        ReceivesUserType1(g)
        Console.WriteLine("E after function call: " & g.E & "  D(0) = " & Str(g.D(0)))
    End Sub

    Sub Main()
        Numbers()
        Console.ReadLine()
        Strings()
        Console.ReadLine()
        Arrays()
        Console.ReadLine()
        Structs()
        Console.ReadLine()

    End Sub

End Module
