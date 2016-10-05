' Multithreading example #1
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim myFamily As FamilyOperation

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
        ' Clean up threads here
        If Not myFamily Is Nothing Then
            myFamily.StopThreads()
        End If
    End Sub
    Private components As System.ComponentModel.IContainer
    Friend WithEvents cmdDeposit As System.Windows.Forms.Button
    Friend WithEvents txtDeposit As System.Windows.Forms.TextBox
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents txtThreads As System.Windows.Forms.TextBox
    Friend WithEvents txtKids As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label

    'Required by the Windows Form Designer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtKids = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdDeposit = New System.Windows.Forms.Button()
        Me.txtThreads = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.txtDeposit = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtKids
        '
        Me.txtKids.Location = New System.Drawing.Point(64, 24)
        Me.txtKids.Name = "txtKids"
        Me.txtKids.Size = New System.Drawing.Size(56, 20)
        Me.txtKids.TabIndex = 2
        Me.txtKids.Text = "10"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(136, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Threads:"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Results"
        '
        'cmdDeposit
        '
        Me.cmdDeposit.Location = New System.Drawing.Point(216, 144)
        Me.cmdDeposit.Name = "cmdDeposit"
        Me.cmdDeposit.Size = New System.Drawing.Size(64, 24)
        Me.cmdDeposit.TabIndex = 9
        Me.cmdDeposit.Text = "Deposit"
        '
        'txtThreads
        '
        Me.txtThreads.Location = New System.Drawing.Point(184, 24)
        Me.txtThreads.Name = "txtThreads"
        Me.txtThreads.Size = New System.Drawing.Size(48, 20)
        Me.txtThreads.TabIndex = 3
        Me.txtThreads.Text = "10"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kids:"
        '
        'timer1
        '
        Me.timer1.Interval = 2000
        '
        'lstResults
        '
        Me.lstResults.Location = New System.Drawing.Point(16, 72)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(176, 186)
        Me.lstResults.TabIndex = 4
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(216, 72)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(64, 24)
        Me.cmdStart.TabIndex = 6
        Me.cmdStart.Text = "Start"
        '
        'cmdStop
        '
        Me.cmdStop.Enabled = False
        Me.cmdStop.Location = New System.Drawing.Point(216, 200)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(64, 24)
        Me.cmdStop.TabIndex = 7
        Me.cmdStop.Text = "Stop"
        '
        'txtDeposit
        '
        Me.txtDeposit.Location = New System.Drawing.Point(216, 120)
        Me.txtDeposit.Name = "txtDeposit"
        Me.txtDeposit.Size = New System.Drawing.Size(64, 20)
        Me.txtDeposit.TabIndex = 8
        Me.txtDeposit.Text = "100000"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDeposit, Me.cmdDeposit, Me.cmdStart, Me.cmdStop, Me.Label3, Me.Label2, Me.Label1, Me.lstResults, Me.txtThreads, Me.txtKids})
        Me.Name = "Form1"
        Me.Text = "Multithreading Test 1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        UpdateResults()
    End Sub

    Protected Sub cmdDeposit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeposit.Click
        Dim Amount As Double
        Amount = Val(txtDeposit().Text)
        myFamily.ParentPayday(Amount)
    End Sub

    Private Sub UpdateResults()
        lstResults.Items.Clear()
        lstResults.Items.Add("Parent:")
        lstResults.Items.Add("- Total Deposited: " + Format(myFamily.TotalDepositedToParent, "0.00"))
        lstResults.Items.Add("- Total Withdrawn: " + Format(myFamily.TotalAllocatedByParent, "0.00"))
        lstResults.Items.Add("- Expected Balance: " + Format(myFamily.TotalDepositedToParent - myFamily.TotalAllocatedByParent, "0.00"))
        lstResults.Items.Add("- Actual Balance: " + Format(myFamily.ParentBalance, "0.00"))
        lstResults.Items.Add("Kids:")
        lstResults.Items.Add("- Total Deposited: " + Format(myFamily.TotalGivenToKids, "0.00"))
        lstResults.Items.Add("- Total Withdrawn: " + Format(myFamily.TotalSpentByKids, "0.00"))
        lstResults.Items.Add("- Expected Balance: " + Format(myFamily.TotalGivenToKids - myFamily.TotalSpentByKids, "0.00"))
        lstResults.Items.Add("- Actual Balance: " + Format(myFamily.TotalKidsBalances, "0.00"))
    End Sub

    Protected Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        myFamily.StopThreads()
        cmdStop.Enabled = False
        cmdStart.Enabled = True
        cmdDeposit.Enabled = False
        UpdateResults()
    End Sub



    Protected Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        myFamily = New FamilyOperation()
        Dim Kids As Integer
        Dim Threads As Integer

        Kids = CInt(Val(txtKids().Text))
        Threads = CInt(Val(txtThreads().Text))
        myFamily.NumberOfKids = Kids
        myFamily.StartThreads(Threads)
        lstResults.Items.Clear()
        timer1.Enabled = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True
        cmdDeposit.Enabled = True
    End Sub



End Class
