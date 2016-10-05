' For...Each collection demonstration
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Module Module1

 

 
    Public Class PseudoCollection
        Implements IEnumerable
        Private DummyData() As String = {"One Fish", "Two Fish", "Red Fish", "Blue Fish"}

        Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Dim myEnumerator As New EnumeratorClass()
            ReDim myEnumerator.Snapshot(UBound(DummyData))
            DummyData.CopyTo(myEnumerator.Snapshot, 0)
            Return myEnumerator
        End Function

        Public Class EnumeratorClass
            Implements IEnumerator

            Dim CurrentIndex As Integer = -1
            Public Snapshot() As String


            ' Set current state before first entry            
            Sub Reset() Implements IEnumerator.Reset
                CurrentIndex = -1
            End Sub

            ReadOnly Property Current() As Object Implements IEnumerator.Current
                Get
                    Return (Snapshot(CurrentIndex))
                End Get
            End Property

            Function MoveNext() As Boolean Implements IEnumerator.MoveNext
                CurrentIndex += 1
                Return (CurrentIndex <= UBound(Snapshot))
            End Function

        End Class

    End Class

    Sub Main()
        Dim I() As Integer = {3, 8, 4, 6, 10, 7, 9}
        Dim C As New Collections.SortedList()
        Dim P As New PseudoCollection()
 
 
        Dim x As Integer
        For x = 0 To UBound(I)
            C.Add(I(x), I(x))
        Next

        Dim IntegerIterator As Object

        Console.WriteLine("Array iteration")
        For Each IntegerIterator In I
            Console.Write(IntegerIterator.ToString & ", ")
        Next
        Console.WriteLine(ControlChars.CrLf & "Collection iteration")

        Dim DictIterator As DictionaryEntry
        For Each DictIterator In C
            Console.Write(DictIterator.Value.ToString & ", ")
        Next

        Dim StringIterator As String
        Console.WriteLine(ControlChars.CrLf & "Custom enumerable object")
        For Each StringIterator In P
            Console.Write(StringIterator.ToString & ", ")
        Next

        Console.ReadLine()
    End Sub

End Module

