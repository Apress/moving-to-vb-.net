' Properties sample application
' Copyright ©2001 by Desaware Inc.

Module Module1

    Class DefaultTest
        Implements IDisposable

        Private Shared MyClasses As New ArrayList()

        Public Name As String

        Public Sub New(ByVal myname As String)
            MyBase.New()
            MyClasses.Add(Me)
            Name = myname
        End Sub

        Default Public ReadOnly Property OtherDefaultTestObjects(ByVal idx As Integer) As DefaultTest
            Get
                Return CType(MyClasses.Item(idx), DefaultTest)
            End Get
        End Property

        Public Shared ReadOnly Property OtherObjectCount() As Integer
            Get
                Return myclasses.Count
            End Get
        End Property

        Public ReadOnly Property MyIndex() As Integer
            Get
                Return myclasses.IndexOf(Me)
            End Get
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
            MyClasses.Remove(Me)
        End Sub


    End Class

    Sub ShowOtherObjects(ByVal obj As DefaultTest)
        Dim x As Integer
        Console.WriteLine("This object is: " & obj.Name)
        Console.WriteLine("Other objects are: ")
        For x = 0 To DefaultTest.OtherObjectCount - 1
            If x <> obj.MyIndex Then
                Console.WriteLine(obj(x).Name)
            End If
        Next
        Console.WriteLine()

    End Sub

    Sub Main()
        Dim obj1 As New DefaultTest("Firstobject")
        Dim obj2 As New DefaultTest("Secondobject")
        Dim obj3 As New DefaultTest("Thirdobject")

        ShowOtherObjects(obj2)
        obj2.Dispose()
        obj2 = Nothing
        ShowOtherObjects(obj3)
        Console.ReadLine()
    End Sub

End Module
