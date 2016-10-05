' Example of MDI forms and ownership
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim f2 As New Form2()

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        f2.Visible = True
        Me.AddOwnedForm(f2)
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MdiClient1 As System.Windows.Forms.MdiClient

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Me.MdiClient1 = New System.Windows.Forms.MdiClient()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MdiClient1
        '
        Me.MdiClient1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MdiClient1.Name = "MdiClient1"
        Me.MdiClient1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(168, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 24)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Turn to MDI"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 191)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(299, 32)
        Me.Panel1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(299, 223)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.MdiClient1})
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


#End Region

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click        f2.SetParent(Me)
        f2.Top = 0        f2.Left = 0    End Sub

End Class
