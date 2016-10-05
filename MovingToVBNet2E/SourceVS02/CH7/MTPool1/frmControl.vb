' MTPool1 sample application
' Copyright ©2001-2003 by Desaware Inc.
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

    Private TotalServed As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ThisThread As Thread
        Dim x As Integer
        For x = 0 To UBound(ThreadPool)
            ThreadPool(x) = New Thread(AddressOf ThreadFunction)
            ThreadPool(x).Start()
        Next
    End Sub

    Private Sub TearDown()
        Dim th As Thread
        ' Block further requests
        cmdRequest.Enabled = False
        ' Clear the queue
        OperationQueue.Clear()

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
                i = OperationQueue.Dequeue()
                s.ServerOp(i * 1000)
                TotalServed += 1
            Catch e As InvalidOperationException
                Try
                    JobQueued.WaitOne()
                Catch ti As ThreadInterruptedException
                    Exit Sub
                End Try
            End Try
        Loop While True

    End Sub

    Private Sub cmdRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRequest.Click
        Static RandomGenerator As New Random()
        Dim rnum As Integer
        rnum = RandomGenerator.Next(1, 5)
        OperationQueue.Enqueue(rnum)
        JobQueued.Set()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ListBox1.Items.Clear()
        ListBox1.Items.Add("Total served: " & CStr(TotalServed))
        ListBox1.Items.Add("Total pending: " & CStr(OperationQueue.Count))
    End Sub
End Class
