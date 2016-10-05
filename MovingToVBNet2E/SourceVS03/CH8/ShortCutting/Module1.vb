' Illustration of shortcutting operators
' Copyright ©2001-2002 by Desaware Inc. All Rights Reserved
Module Module1

    Class A
        Public ReadOnly Property IsTrue() As Boolean
            Get
                Console.WriteLine("IsTrue was called")
                Return True
            End Get
        End Property

        Public ReadOnly Property IsFalse() As Boolean
            Get
                Console.WriteLine("IsFalse was called")
                Return False
            End Get
        End Property

    End Class


    Sub Main()
        Dim testvar As New A()
        Console.WriteLine("Before IsFalse And IsFalse")
        If testvar.IsFalse And testvar.IsFalse Then
        End If
        Console.WriteLine("Before IsFalse AndAlso IsFalse")
        If testvar.IsFalse AndAlso testvar.IsFalse Then
        End If

        Console.WriteLine("Before IsTrue Or IsTrue")
        If testvar.IsTrue Or testvar.IsTrue Then
        End If
        Console.WriteLine("Before IsTrue OrElse IsTrue")
        If testvar.IsTrue OrElse testvar.IsTrue Then
        End If
        Console.ReadLine()
    End Sub

End Module
