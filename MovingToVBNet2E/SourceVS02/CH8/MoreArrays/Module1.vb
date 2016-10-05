' Additional array examples
Module Module1

    Sub Main()

        ' These are the same
        Dim a() As Integer = {1, 2, 3}
        Console.WriteLine(a(1))
        a = New Integer() {1, 2, 3}
        Console.WriteLine(a(1))

        ' These are the same
        Dim b(,) As Integer = {{1, 2, 3}, {1, 2, 3}}
        Console.WriteLine(b(1, 1))
        b = New Integer(,) {{1, 2, 3}, {1, 2, 3}}

        ' Here's the syntax for initializing a jagged array, one in which the length
        ' of each array differs.
        Dim c()() As Integer = {New Integer() {1, 2}, New Integer() {1, 2, 3}}
        ' You don't have to initialize them all at once
        c(1) = New Integer() {4, 5}
        Console.WriteLine(c(1)(1))
        c(1) = System.Array.CreateInstance(GetType(System.Int32), 10)
        Console.WriteLine(c(1)(1))
        Dim d() As Integer = {6, 7}
        c(1) = d
        Console.WriteLine(c(1)(1))
        Console.ReadLine()

    End Sub

End Module
