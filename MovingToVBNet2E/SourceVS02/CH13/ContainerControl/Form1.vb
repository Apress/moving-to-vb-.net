' Example of container class
' Copyright �2001 by Desaware Inc. - All Rights Reserved
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
    Friend WithEvents ctl1 As System.Windows.Forms.ContainerControl
    Friend WithEvents textBox2 As System.Windows.Forms.TextBox
    Friend WithEvents textBox1 As System.Windows.Forms.TextBox
    Friend WithEvents textBox3 As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.ctl1 = New System.Windows.Forms.ContainerControl()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.textBox3 = New System.Windows.Forms.TextBox()
        Me.ctl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(128, 24)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(136, 20)
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = "textBox1"
        '
        'ctl1
        '
        Me.ctl1.AutoScroll = True
        Me.ctl1.BackColor = System.Drawing.Color.DarkBlue
        Me.ctl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox2, Me.textBox1})
        Me.ctl1.Location = New System.Drawing.Point(24, 32)
        Me.ctl1.Name = "ctl1"
        Me.ctl1.Size = New System.Drawing.Size(216, 104)
        Me.ctl1.TabIndex = 0
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(32, 24)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(64, 20)
        Me.textBox2.TabIndex = 1
        Me.textBox2.Text = "textBox2"
        '
        'textBox3
        '
        Me.textBox3.Location = New System.Drawing.Point(176, 168)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.Size = New System.Drawing.Size(72, 20)
        Me.textBox3.TabIndex = 1
        Me.textBox3.Text = "textBox3"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox3, Me.ctl1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ctl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
