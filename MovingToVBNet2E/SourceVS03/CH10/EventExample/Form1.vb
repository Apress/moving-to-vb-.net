' Event example program
' Copyright ©2001-2003 by Desaware Inc All Rights Reserved

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private ec As New EventClass()
    Private WithEvents button3 As System.Windows.Forms.Button

    Private WithEvents ec2 As EventClass
    Friend WithEvents radioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents radioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents radioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents button4 As System.Windows.Forms.Button

    Private WithEvents dec As DerivedEventClass


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        AddHandler ec.FirstEvent, AddressOf EventClass_FirstEvent
        ec2 = New EventClass()
        dec = New DerivedEventClass()
        AddHandler ec2.SecondEvent, AddressOf AnotherSecondEventHandler
        AddHandler dec.SecondEvent, AddressOf AnotherSecondEventHandler

        AddHandler DerivedEventClass.ASharedEvent, AddressOf SharedEventHandler

        dec.SpecialEventHandler = AddressOf FirstSpecialEventHandler
        Dim EventToCombine As EventTemplate = AddressOf SecondSpecialEventHandler
        dec.SpecialEventHandler = CType(dec.SpecialEventHandler.Combine(dec.SpecialEventHandler, EventToCombine), EventTemplate)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
        RemoveHandler ec.FirstEvent, AddressOf EventClass_FirstEvent
        RemoveHandler ec2.SecondEvent, AddressOf AnotherSecondEventHandler
        RemoveHandler DerivedEventClass.ASharedEvent, AddressOf SharedEventHandler
        RemoveHandler dec.SecondEvent, AddressOf AnotherSecondEventHandler
    End Sub
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button4 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.radioButton1 = New System.Windows.Forms.RadioButton()
        Me.radioButton3 = New System.Windows.Forms.RadioButton()
        Me.radioButton2 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(152, 128)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(96, 32)
        Me.button4.TabIndex = 4
        Me.button4.Text = "Special"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(16, 24)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(88, 32)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Simple Event"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(152, 24)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(96, 32)
        Me.button2.TabIndex = 1
        Me.button2.Text = "Other Approaches"
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(152, 80)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(96, 32)
        Me.button3.TabIndex = 2
        Me.button3.Text = "Derived"
        '
        'radioButton1
        '
        Me.radioButton1.Location = New System.Drawing.Point(16, 88)
        Me.radioButton1.Name = "radioButton1"
        Me.radioButton1.Size = New System.Drawing.Size(64, 16)
        Me.radioButton1.TabIndex = 3
        Me.radioButton1.Text = "option1"
        '
        'radioButton3
        '
        Me.radioButton3.Checked = True
        Me.radioButton3.Location = New System.Drawing.Point(16, 136)
        Me.radioButton3.Name = "radioButton3"
        Me.radioButton3.Size = New System.Drawing.Size(64, 16)
        Me.radioButton3.TabIndex = 3
        Me.radioButton3.TabStop = True
        Me.radioButton3.Text = "option3"
        '
        'radioButton2
        '
        Me.radioButton2.Location = New System.Drawing.Point(16, 112)
        Me.radioButton2.Name = "radioButton2"
        Me.radioButton2.Size = New System.Drawing.Size(64, 16)
        Me.radioButton2.TabIndex = 3
        Me.radioButton2.Text = "option2"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(259, 192)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button4, Me.radioButton3, Me.radioButton2, Me.radioButton1, Me.button3, Me.button2, Me.button1})
        Me.Name = "Form1"
        Me.Text = "Event example"
        Me.ResumeLayout(False)

    End Sub


#End Region
    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click        MsgBox("Simple Event Clicked", MsgBoxStyle.Information, "Event arrived")
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click        ec.Test1()
        ec2.Test2()
    End Sub

    Private Sub EventClass_FirstEvent(ByVal i As Integer)
        MsgBox("EventClass_FirstEvent called", MsgBoxStyle.Information, "Event arrived")
    End Sub

    Private Sub EventClass_SecondEvent(ByVal obj As Object, ByVal i As Integer) Handles ec2.SecondEvent
        MsgBox("EventClass_SecondEvent called", MsgBoxStyle.Information, "Event arrived")
    End Sub

    Private Sub AnotherSecondEventHandler(ByVal obj As Object, ByVal i As Integer)
        MsgBox("AnotherSecondEventHandler called", MsgBoxStyle.Information, "Event arrived")
    End Sub

    Private Sub DerivedEventHandler(ByVal obj As Object, ByVal i As Integer) Handles dec.DerivedEvent        MsgBox("DerivedEventHandler called", MsgBoxStyle.Information, "Event arrived")
    End Sub    Private Sub SharedEventHandler()        MsgBox("Shared event handler", MsgBoxStyle.Information, "Event arrived")
    End Sub    Private Sub FirstSpecialEventHandler(ByVal obj As Object, ByVal i As Integer)        MsgBox("FirstSpecial event handler", MsgBoxStyle.Information, "Event arrived")
    End Sub    Private Sub SecondSpecialEventHandler(ByVal obj As Object, ByVal i As Integer)        MsgBox("SecondSpecial event handler", MsgBoxStyle.Information, "Event arrived")
    End Sub    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click        dec.Test2()
    End Sub

    Private Sub Options_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioButton3.CheckedChanged, radioButton2.CheckedChanged, radioButton1.CheckedChanged        Dim params() As Object
        Dim NameValue As Object
        NameValue = sender.GetType.InvokeMember("Text", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.GetProperty, Nothing, sender, params)
        Debug.WriteLine(CStr(NameValue))

        Dim rb As RadioButton
        rb = CType(sender, RadioButton)
        Debug.WriteLine(rb.Name & " " & rb.Text)

    End Sub

    Private Sub button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click        dec.TestSpecialEvents()
    End Sub


End Class
