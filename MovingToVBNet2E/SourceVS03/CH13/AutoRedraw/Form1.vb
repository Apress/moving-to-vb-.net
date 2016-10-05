' AutoRedraw example
' Copyright ©2001-2003 by Desaware Inc. - All Rights Reserved

Imports System.Drawing
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
    Friend WithEvents cmdDrawStuff As System.Windows.Forms.Button
    Friend WithEvents cmdInvalidate As System.Windows.Forms.Button
    Friend WithEvents cmdOtherForm As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdOtherForm = New System.Windows.Forms.Button()
        Me.cmdDrawStuff = New System.Windows.Forms.Button()
        Me.cmdInvalidate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdOtherForm
        '
        Me.cmdOtherForm.Location = New System.Drawing.Point(184, 136)
        Me.cmdOtherForm.Name = "cmdOtherForm"
        Me.cmdOtherForm.Size = New System.Drawing.Size(96, 32)
        Me.cmdOtherForm.TabIndex = 2
        Me.cmdOtherForm.Text = "Other Form"
        '
        'cmdDrawStuff
        '
        Me.cmdDrawStuff.Location = New System.Drawing.Point(184, 80)
        Me.cmdDrawStuff.Name = "cmdDrawStuff"
        Me.cmdDrawStuff.Size = New System.Drawing.Size(96, 32)
        Me.cmdDrawStuff.TabIndex = 1
        Me.cmdDrawStuff.Text = "Draw Stuff"
        '
        'cmdInvalidate
        '
        Me.cmdInvalidate.Location = New System.Drawing.Point(184, 24)
        Me.cmdInvalidate.Name = "cmdInvalidate"
        Me.cmdInvalidate.Size = New System.Drawing.Size(96, 32)
        Me.cmdInvalidate.TabIndex = 0
        Me.cmdInvalidate.Text = "Invalidate"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdOtherForm, Me.cmdDrawStuff, Me.cmdInvalidate})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim backgroundbitmap As Bitmap

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)        If Not Me.ClientRectangle.IsEmpty Then            If Not Me.ClientSize.Equals(New Size(backgroundbitmap.Width, backgroundbitmap.Height)) Then                Dim newbitmap As Bitmap                newbitmap = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)                If Not backgroundbitmap Is Nothing Then                    Dim g As Graphics = graphics.FromImage(newbitmap)
                    g.DrawImage(backgroundbitmap, 0, 0)
                End If                backgroundbitmap = newbitmap            End If        End If    End Sub


    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e) ' What happens if you leave this out?
        If backgroundbitmap Is Nothing Then
        ' May get bitmap before Resize - especially first time
        backgroundbitmap = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)        End If        e.Graphics.DrawImage(backgroundbitmap, 0, 0)
        'RaiseEvent Paint(Me, e)
    End Sub

    Private Sub cmdInvalidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvalidate.Click        Me.Invalidate()
    End Sub

    Private Sub cmdDrawStuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDrawStuff.Click        Dim g As Graphics = graphics.FromImage(backgroundbitmap)
        g.DrawLine(pens.Black, 0, 0, 200, 200)
        g.DrawLine(pens.Red, 0, 200, 200, 0)
        cmdInvalidate_Click(Me, Nothing)
    End Sub

    ' Here's code that lets you do your own paint event
    'Shadows Event Paint(ByVal sender As Object, ByVal args As PaintEventArgs)

    Private Sub OtherFormPaint(ByVal sender As Object, ByVal args As PaintEventArgs)        Debug.WriteLine("Other paint arrived")
    End Sub    Private Sub cmdOtherForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOtherForm.Click        Dim f As New Form1()
        f.Visible = True
        AddHandler f.Paint, AddressOf Me.OtherFormPaint
    End Sub
End Class
