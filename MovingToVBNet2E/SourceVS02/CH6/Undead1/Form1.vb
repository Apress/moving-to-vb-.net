' Undead1 sample program
' Copyright © 2001 by Desaware Inc.
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
    Friend WithEvents button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(64, 24)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(152, 32)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Create && Destroy"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 96)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
        Me.Name = "Form1"
        Me.Text = "Finalizers"
        Me.ResumeLayout(False)

    End Sub


#End Region

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click        ' Note: unlike VB6, this does create the object
        Dim obj As New Undying()

    End Sub

End Class
