' Threading performance example
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Module Module1

    Dim WorkerObjects(4) As WorkerThread
    Dim Threads(4) As Threading.Thread

    Sub RunTest()
        Dim x As Integer

        ' Create the threads        
        For x = 0 To 4
            Threads(x) = New Threading.Thread(AddressOf WorkerObjects(x).WorkingOperation)
        Next x

        ' Start the 5 threads
        For x = 0 To 4
            Threads(x).Start()
        Next

        ' Wait for them to finish
        For x = 0 To 4
            Threads(x).Join()
        Next

    End Sub


    Sub RunTest2()
        Dim x As Integer

        ' Create the threads        
        For x = 0 To 4
            Threads(x) = New Threading.Thread(AddressOf WorkerObjects(x).SleepingOperation)
        Next x

        ' Start the 5 threads
        For x = 0 To 4
            Threads(x).Start()
        Next

        ' Wait for them to finish
        For x = 0 To 4
            Threads(x).Join()
        Next

    End Sub


    Public Sub RunSynchronous()
        Dim x As Integer
        For x = 0 To 4
            WorkerObjects(x).SynchronousRequest()
        Next
        For x = 0 To 4
            WorkerObjects(x).SynchronousOperation()
        Next

    End Sub

    Public Sub RunSynchronous2()
        Dim x As Integer
        For x = 0 To 4
            WorkerObjects(x).SynchronousRequest()
        Next
        For x = 0 To 4
            WorkerObjects(x).SleepingSynchronous()
        Next

    End Sub


    Sub ReportResults()
        Dim x As Integer
        Dim tot As Double
        Dim ms As Double
        For x = 0 To 4
            ms = WorkerObjects(x).ElapsedTimeForCall.TotalMilliseconds
            tot = tot + ms
            Console.Write(Int(ms).ToString + " ,")
        Next
        Console.Write(" Average: " + Int(tot / 5).ToString())
        Console.WriteLine()
    End Sub


    Sub Main()
        Dim x As Integer
        For x = 0 To 4
            WorkerObjects(x) = New WorkerThread()
        Next

        Console.WriteLine("Running tests...")


        Console.WriteLine("CPU-Intensive operations")

        Console.WriteLine("Synchronous Equal length operations")
        WorkerObjects(0).LongDuration = False
        RunSynchronous()
        ReportResults()

        Console.WriteLine("Synchronous one long operation")
        WorkerObjects(0).LongDuration = True
        RunSynchronous()
        ReportResults()

        Console.WriteLine("Multithreaded Equal length operations")
        WorkerObjects(0).LongDuration = False
        RunTest()
        ReportResults()

        Console.WriteLine("Multithreaded One long operations")
        WorkerObjects(0).LongDuration = True
        RunTest()
        ReportResults()


        Console.WriteLine("Non CPU-Intensive operations")


        Console.WriteLine("Synchronous Equal length operation")
        WorkerObjects(0).LongDuration = False
        RunSynchronous2()
        ReportResults()

        Console.WriteLine("Synchronous one long operation")
        WorkerObjects(0).LongDuration = True
        RunSynchronous2()
        ReportResults()

        Console.WriteLine("Multithreaded Equal length operations")
        WorkerObjects(0).LongDuration = False
        RunTest2()
        ReportResults()

        Console.WriteLine("Multithreaded One long operations")
        WorkerObjects(0).LongDuration = True
        RunTest2()
        ReportResults()



        Console.ReadLine()

    End Sub

End Module
