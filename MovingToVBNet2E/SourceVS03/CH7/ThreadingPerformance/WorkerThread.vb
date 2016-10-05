' Threading performance example
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Imports System.Threading

Public Class WorkerThread
    Private myTimeSpan As TimeSpan
    Public ReadOnly Property ElapsedTimeForCall() As TimeSpan
        Get
            Return myTimeSpan
        End Get
    End Property
    
    Public LongDuration As Boolean
    
    Public Sub WorkingOperation()
        Dim counter As Long
        Dim upperlimit As Long
        Dim temp As Long
        myTimespan = TimeSpan.FromTicks(DateTime.Now.Ticks)
        upperlimit = 50000000
        If LongDuration Then upperlimit = 5 * upperlimit
        For counter = 1 To upperlimit
            temp = 5
        Next
        myTimespan = TimeSpan.FromTicks(DateTime.Now.Ticks).Subtract(myTimespan)
    End Sub
    
    Public Sub SynchronousRequest()
        myTimespan = TimeSpan.FromTicks(DateTime.Now.Ticks)
    End Sub
    
    Public Sub SynchronousOperation()
        Dim counter As Long
        Dim upperlimit As Long
        Dim temp As Long
        upperlimit = 50000000
        If LongDuration Then upperlimit = 5 * upperlimit
        For counter = 1 To upperlimit
            temp = 5
        Next
        myTimespan = TimeSpan.FromTicks(DateTime.Now.Ticks).Subtract(myTimespan)
    End Sub
    
    
    
    Public Sub SleepingOperation()
        Dim sleepspan As Integer
        sleepspan = 1000
        If longduration Then sleepspan = sleepspan * 5
        myTimespan = TimeSpan.FromTicks(DateTime.Now.Ticks)
        Thread.CurrentThread.Sleep(sleepspan)
        myTimespan = TimeSpan.FromTicks(DateTime.Now.Ticks).Subtract(myTimespan)
    End Sub
    
    Public Sub SleepingSynchronous()
        Dim sleepspan As Integer
        sleepspan = 1000
        If longduration Then sleepspan = sleepspan * 5
        Thread.CurrentThread.Sleep(sleepspan)
        myTimespan = TimeSpan.FromTicks(DateTime.Now.Ticks).Subtract(myTimespan)
    End Sub
    
End Class
