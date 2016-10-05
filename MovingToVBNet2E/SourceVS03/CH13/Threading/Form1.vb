' Form threading example
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

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
    End Sub
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents button2 As System.Windows.Forms.Button
    Friend WithEvents button3 As System.Windows.Forms.Button
    Friend WithEvents label3 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(176, 88)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(88, 32)
        Me.button2.TabIndex = 3
        Me.button2.Text = "Bad thread call"
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(176, 128)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(88, 32)
        Me.button3.TabIndex = 4
        Me.button3.Text = "Good thread call"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(24, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(176, 24)
        Me.label1.TabIndex = 0
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(24, 120)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(136, 32)
        Me.label2.TabIndex = 2
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(24, 96)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(100, 16)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Called from thread"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(24, 56)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(176, 23)
        Me.button1.TabIndex = 1
        Me.button1.Text = "Start Other Thread"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(291, 160)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label3, Me.button3, Me.button2, Me.label2, Me.button1, Me.label1})
        Me.Name = "Form1"
        Me.Text = "Threading Example"
        Me.ResumeLayout(False)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load        label1.Text = "Thread ID: " & CStr(AppDomain.GetCurrentThreadId)
    End Sub

#End Region

    Dim OtherThread As New Thread(AddressOf OtherThreadEntryPoint)

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click        OtherThread.Start()
    End Sub

    Public Sub ThreadIdInLabel2()
        label2.Text = "Current Thread " & CStr(AppDomain.GetCurrentThreadId)
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click        If Not OtherForm1 Is Nothing Then
            OtherForm1.ThreadIdInLabel2()
        End If
    End Sub

    Delegate Sub NoParams()

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click        If Not OtherForm1 Is Nothing Then
            Dim usedel As NoParams = AddressOf OtherForm1.ThreadIdInLabel2
            OtherForm1.Invoke(usedel)
        End If
    End Sub

    Public Sub DisableButtons()
        button1.Enabled = False
        button2.Enabled = False
        button3.Enabled = False
    End Sub

End Class
Module UsedByThread
    Public OtherForm1 As Form1
    Public Sub OtherThreadEntryPoint()
        OtherForm1 = New Form1()
        OtherForm1.DisableButtons()
        Application.Run(OtherForm1)
    End Sub
End Module

