' "Subclassing" example
' Copyright ©2001 by Desaware Inc. All Rights Reserved
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
    Friend WithEvents listBox1 As System.Windows.Forms.ListBox
    Friend WithEvents button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'listBox1
        '
        Me.listBox1.Location = New System.Drawing.Point(8, 8)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(272, 212)
        Me.listBox1.TabIndex = 0
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(184, 232)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(96, 32)
        Me.button1.TabIndex = 1
        Me.button1.Text = "Clear"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.listBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click        listBox1().Items.Clear()
    End Sub


    Protected Overrides Sub wndproc(ByRef m As Message)
        Select Case m.Msg

            Case &H20, &H84
                ' Ignore WM_SETCURSOR, WM_NCHITTEST
                ' Because there are so many of them
            Case Else
                listBox1().Items.Add(m.ToString)

        End Select
        MyBase.WndProc(m)
    End Sub
#End Region

End Class
