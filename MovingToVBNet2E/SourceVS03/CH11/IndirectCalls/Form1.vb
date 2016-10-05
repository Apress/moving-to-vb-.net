' Indirect call example
' Copyright ©2001-2003 by Desaware Inc.

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
    Friend WithEvents cmdCallIt As System.Windows.Forms.Button
    Friend WithEvents txtFunction As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents txtParameter As System.Windows.Forms.TextBox
    Friend WithEvents lblResult As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Me.txtFunction = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.txtParameter = New System.Windows.Forms.TextBox()
        Me.cmdCallIt = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtFunction
        '
        Me.txtFunction.Location = New System.Drawing.Point(136, 32)
        Me.txtFunction.Name = "txtFunction"
        Me.txtFunction.Size = New System.Drawing.Size(104, 20)
        Me.txtFunction.TabIndex = 0
        Me.txtFunction.Text = "A"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(48, 64)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(80, 16)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Parameter:"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(80, 144)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(144, 16)
        Me.lblResult.TabIndex = 5
        '
        'txtParameter
        '
        Me.txtParameter.Location = New System.Drawing.Point(136, 64)
        Me.txtParameter.Name = "txtParameter"
        Me.txtParameter.Size = New System.Drawing.Size(104, 20)
        Me.txtParameter.TabIndex = 2
        Me.txtParameter.Text = "1"
        '
        'cmdCallIt
        '
        Me.cmdCallIt.Location = New System.Drawing.Point(112, 104)
        Me.cmdCallIt.Name = "cmdCallIt"
        Me.cmdCallIt.Size = New System.Drawing.Size(64, 24)
        Me.cmdCallIt.TabIndex = 4
        Me.cmdCallIt.Text = "Call It"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(48, 32)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(80, 16)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Function:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 184)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblResult, Me.cmdCallIt, Me.label2, Me.txtParameter, Me.label1, Me.txtFunction})
        Me.Name = "Form1"
        Me.Text = "Late Binding - Indirection"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub cmdCallIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCallIt.Click        Dim obj As New myTestClass()
        Dim T As Type
        Dim Params(0) As Object
        Dim result As Integer
        ' Note we box the integer here
        Try
            Params(0) = CInt(txtParameter().Text)
        Catch ex As Exception
            MsgBox("Must enter a number")
            Exit Sub
        End Try
        T = obj.GetType()
        Try
            result = CInt(T.InvokeMember(txtFunction().Text, Reflection.BindingFlags.Default Or Reflection.BindingFlags.InvokeMethod, Nothing, obj, Params))
            lblResult().Text = "Result is " + result.ToString()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub

 
End Class


