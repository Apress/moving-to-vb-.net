' Initialization and Destruction example
' Copyright © 2001-2003 by Desaware Inc.

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
        If Disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(32, 40)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(88, 56)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Component Lifetime Class1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(160, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 56)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Component Lifetime Class2"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 160)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.button1})
        Me.Name = "Form1"
        Me.Text = "Component Lifetime"
        Me.ResumeLayout(False)

    End Sub


#End Region
    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click        Dim obj As New Class1()
        ' Dispose of the object when you are done with it - See text
        obj.Dispose()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim obj As New Class2()
        ' Dispose of the object when you are done with it - See text
        obj.Dispose()
    End Sub

End Class
