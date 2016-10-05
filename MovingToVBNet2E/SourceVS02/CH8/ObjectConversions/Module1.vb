' Object Conversions example
' Copyright ©2001 by Desaware Inc.
' All Rights Reserved
Module Module1
    Interface I
        Sub MyInterfaceFunc()
    End Interface

    Class A
        Implements I
        Protected Overridable Sub MyFunc()

        End Sub
        Public Sub MyPublicFunc()

        End Sub
        Public Sub MyInterfaceFunc() Implements I.MyInterfaceFunc

        End Sub
    End Class

    Class B
        Inherits A

    End Class

    Sub Main()
        Dim myA As New A()
        Dim myB As New B()
        Dim myAReference As A
        Dim myBReference As B
        Dim myIReference As I

        myAReference = myA  ' Same type - ok
        myAReference = myB  ' Base type - implicit
        myIReference = myA  ' Implemented interface - implicit

        myA = CType(myIReference, A)    ' I pointer may be any object - explicit
        myA = DirectCast(myIReference, A)   ' Same functionality

        ' Can't tell until runtime if it will work

        Try
            myB = CType(myIReference, B)    ' Here it doesn't work
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        myIReference = myB  ' Implemented Interface - implicit
        ' B inherits from A, inherits I as well


        Console.ReadLine()

    End Sub

End Module
