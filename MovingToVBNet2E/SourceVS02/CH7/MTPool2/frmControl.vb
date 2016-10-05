' Thread Pool Implementation #2
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Imports System.Threading
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
        TearDown()
    End Sub

    Friend WithEvents cmdRequest As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private components As System.ComponentModel.IContainer

    'Required by the Windows Form Designer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.cmdRequest = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(16, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(192, 108)
        Me.ListBox1.TabIndex = 1
        '
        'cmdRequest
        '
        Me.cmdRequest.Location = New System.Drawing.Point(240, 8)
        Me.cmdRequest.Name = "cmdRequest"
        Me.cmdRequest.Size = New System.Drawing.Size(72, 24)
        Me.cmdRequest.TabIndex = 0
        Me.cmdRequest.Text = "Request"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 133)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.cmdRequest})
        Me.Name = "Form1"
        Me.Text = "Thread pooled simulator"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private ThreadPool(4) As Thread

    ' Queue containing all jobs
    Private OperationQueue As New Collections.Queue()

    ' JobQueued event is signaled when new job is queued
    Private JobQueued As New AutoResetEvent(False)

    Private WorkCounter As New CounterEvent()

    Private TotalServed As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ThisThread As Thread
        Dim x As Integer
        For x = 0 To UBound(ThreadPool)
            ThreadPool(x) = New Thread(AddressOf ThreadFunction)
            ThreadPool(x).Name = "ThreadPool Entry # " & CStr(x)
            ThreadPool(x).Start()
        Next
        Thread.CurrentThread.Name = "Main Form Thread"
    End Sub

    ' May be called multiple times
    Private Sub TearDown()
        Dim th As Thread
        ' Block further requests
        cmdRequest.Enabled = False
        ' Clear the queue
        SyncLock (OperationQueue.SyncRoot)
            OperationQueue.Clear()
        End SyncLock
        ' Allow up to 15 seconds for current operations to finish
        WorkCounter.WaitOne(15000, False)
        For Each th In ThreadPool
            th.Interrupt()
            th.Join()
        Next
    End Sub

    Private Sub ThreadFunction()
        Dim s As New Server()
        Dim i As Integer
        Do
            Try
                SyncLock (OperationQueue.SyncRoot)
                    i = OperationQueue.Dequeue()
                End SyncLock
                ' Keep track of # of operations in progress
                WorkCounter.AddOne()
                s.ServerOp(i * 1000)
                WorkCounter.SubtractOne()
                Interlocked.Increment(TotalServed)
            Catch SInterrupted As ThreadInterruptedException
                ' If server operation was interrupted, we exit, but this is probably bad
                Exit Sub
            Catch e As InvalidOperationException
                ' Queue was already empty
                Try
                    ' Wait to be signaled
                    JobQueued.WaitOne()
                Catch ti As ThreadInterruptedException
                    ' This is legit interruption on teardown
                    Exit Sub
                End Try
            End Try
        Loop While True

    End Sub

    Private Sub cmdRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRequest.Click
        Static RandomGenerator As New Random()
        Dim rnum As Integer
        ' Start delay from 1 to 5 seconds
        rnum = RandomGenerator.Next(1, 5)
        SyncLock (OperationQueue.SyncRoot)
            OperationQueue.Enqueue(rnum)
        End SyncLock
        JobQueued.Set()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ListBox1.Items.Clear()
        ListBox1.Items.Add("Total served: " & CStr(TotalServed))
        ListBox1.Items.Add("Total pending: " & CStr(OperationQueue.Count))
    End Sub
End Class
