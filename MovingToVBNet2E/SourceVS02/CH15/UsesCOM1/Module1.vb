' Example of calling COM from VB.NET
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Imports System.Threading
Module Module1
    ' The name of the component exposed to .NET includes the component name and type library 
    ' version number
    Dim ComObject As New dwComFromDotNet.SampleClass1()

    Sub FromAlternateThread()
        Dim tid As Long
        tid = ComObject.GetThisThreadId()
        Console.WriteLine("From other thread, TID = " & Str(tid))
    End Sub


    Sub Main()
        Dim newThread As New Thread(AddressOf FromAlternateThread)
        Dim tid As Long
        newThread.Start()
        tid = ComObject.GetThisThreadId()
        Console.WriteLine("From main thread, TID = " & Str(tid))
        Console.WriteLine(ComObject.TimesTwo(5))
        Console.WriteLine(ComObject.TrimString("     to trim    "))
        newThread.Join()

        Console.ReadLine()

    End Sub

End Module
