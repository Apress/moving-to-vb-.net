' For...Each collection demonstration
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Module Module1
    Enum MyFish
        OneFish
        TwoFish
        RedFish
        BlueFish
    End Enum


    Public Class FishCollection
        Inherits CollectionBase
        Public Function Add(ByVal Value As MyFish) As Integer
            MyBase.List.Add(Value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As MyFish)
            List.Insert(index, value)
        End Sub

        Public Function IndexOf(ByVal value As MyFish) As Integer
            Return List.IndexOf(value)
        End Function

        Public Function Contains(ByVal value As MyFish) As Boolean
            Return List.Contains(value)
        End Function

        Public Sub Remove(ByVal value As MyFish)
            List.Remove(value)
        End Sub

        Public Sub CopyTo(ByVal array() As MyFish, ByVal index As Integer)
            List.CopyTo(array, index)
        End Sub

        Default Property Item(ByVal index As Integer) As MyFish
            Get
                Return CType(MyBase.List.Item(index), MyFish)
            End Get
            Set(ByVal Value As MyFish)
                MyBase.List.Item(index) = Value
            End Set
        End Property

        Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As Object)
            If Not TypeOf (value) Is MyFish Then
                Throw New ArgumentException("Invalid type")
            End If
        End Sub

        Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As Object, _
        ByVal newValue As Object)
            If Not TypeOf (newValue) Is MyFish Then
                Throw New ArgumentException("Invalid type")
            End If
        End Sub

        Protected Overrides Sub OnValidate(ByVal value As Object)
            If Not TypeOf (value) Is MyFish Then
                Throw New ArgumentException("Invalid type")
            End If
        End Sub
    End Class


    Sub Main()
        Dim col As New Collection()
        Console.WriteLine("VB Collection  Type is: " & col.GetType.FullName)

        Dim F As New FishCollection()

        Dim il As IList
        F.Add(MyFish.OneFish)
        F.Add(MyFish.TwoFish)
        F.Add(MyFish.RedFish)
        F.Add(MyFish.BlueFish)
        il = F
        Try
            il.Add("Something not a fish")
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Dim afish As MyFish
        For Each afish In F
            Console.WriteLine(afish.ToString)
        Next

        afish = F(1)

        Console.WriteLine(afish.ToString)

        Console.ReadLine()

    End Sub

End Module
