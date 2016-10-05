' Later Binding example
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved.
Imports System.Reflection
Module Module1

    Sub Main()
        Dim A As Reflection.Assembly
        Dim LaterBindingDLL As String
        Dim obj As Object
        Dim Params() As Object

        ' Navigate to the other DLL
        LaterBindingDLL = CurDir() & "\..\..\laterbinding\bin\laterbinding.dll"
        A = A.LoadFrom(LaterBindingDLL)

        obj = A.CreateInstance("MovingToVB.LaterBinding.LoadItDynamically")
        obj.GetType().InvokeMember("Test", BindingFlags.Default Or BindingFlags.InvokeMethod, Nothing, obj, Params)
    End Sub

End Module
