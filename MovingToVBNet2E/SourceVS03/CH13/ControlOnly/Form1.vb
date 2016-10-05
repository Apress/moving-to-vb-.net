' ControlOnly example
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
    Friend WithEvents ctl1 As System.Windows.Forms.Control
    Friend WithEvents textBox1 As System.Windows.Forms.TextBox
    Friend WithEvents textBox2 As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ctl1 = New System.Windows.Forms.Control
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.textBox2 = New System.Windows.Forms.TextBox
        Me.ctl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctl1
        '
        Me.ctl1.BackColor = System.Drawing.Color.Bisque
        Me.ctl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1})
        Me.ctl1.Name = "ctl1"
        Me.ctl1.Size = New System.Drawing.Size(128, 112)
        Me.ctl1.TabIndex = 0
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(32, 48)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(72, 20)
        Me.textBox1.TabIndex = 1
        Me.textBox1.Text = "textBox1"
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(24, 128)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(96, 20)
        Me.textBox2.TabIndex = 1
        Me.textBox2.Text = "textBox2"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox2, Me.ctl1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ctl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

#End Region

    Private Sub Form1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click        Debug.WriteLine(ctl1().ClientRectangle.ToString)    End Sub

    Private Sub ctl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctl1.Click
    End Sub

End Class
