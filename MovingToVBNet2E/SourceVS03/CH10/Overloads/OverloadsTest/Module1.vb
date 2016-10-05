' Overloads demonstration program
' Copyright ©2001-2003 by Desaware Inc.
Module Module1

    Sub Main()
        ' Can't create with private constructor
        'Dim c As New ClassExamples.InternalClass1()

        ' Can create with public constructor
        Dim c As New ClassExamples.InternalClass1("MyTestName")
        c.Test()

        ' Can access private constructor via public method
        Dim c2 As ClassExamples.InternalClass1 = ClassExamples.InternalClass1.GetDefaultObject

        ' Can never create InternalClass2 directly
        'Dim c2 As New ClassExamples.InternalClass2()

        ' But can using other class and Friend constructor
        Dim cls1 As New ClassExamples.Class1()
        Dim c3 As ClassExamples.InternalClass2 = cls1.GetInternalClass2
        c3.Test()
        Console.WriteLine(ControlChars.CrLf & "InternalClass3")
        Dim cls3 As New ClassExamples.InternalClass3()
        cls3.Test("hello")
        cls3.Test(5)
        cls3.Test()
        Console.ReadLine()
    End Sub

End Module
