' Resurrection example
' Copyright ©2001 by Desaware Inc. All Rights Reserved
'
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
    Friend WithEvents cmdRefinalize As System.Windows.Forms.Button
    Friend WithEvents cmdGC As System.Windows.Forms.Button
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents cmdPrior As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdPrior = New System.Windows.Forms.Button()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.cmdGC = New System.Windows.Forms.Button()
        Me.cmdRefinalize = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdPrior
        '
        Me.cmdPrior.Location = New System.Drawing.Point(56, 136)
        Me.cmdPrior.Name = "cmdPrior"
        Me.cmdPrior.Size = New System.Drawing.Size(168, 32)
        Me.cmdPrior.TabIndex = 0
        Me.cmdPrior.Text = "Check Prior Object"
        '
        'cmdCreate
        '
        Me.cmdCreate.Location = New System.Drawing.Point(56, 24)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(168, 32)
        Me.cmdCreate.TabIndex = 1
        Me.cmdCreate.Text = "Create and Destroy"
        '
        'cmdGC
        '
        Me.cmdGC.Location = New System.Drawing.Point(56, 80)
        Me.cmdGC.Name = "cmdGC"
        Me.cmdGC.Size = New System.Drawing.Size(168, 32)
        Me.cmdGC.TabIndex = 2
        Me.cmdGC.Text = "Force GC"
        '
        'cmdRefinalize
        '
        Me.cmdRefinalize.Location = New System.Drawing.Point(56, 192)
        Me.cmdRefinalize.Name = "cmdRefinalize"
        Me.cmdRefinalize.Size = New System.Drawing.Size(168, 32)
        Me.cmdRefinalize.TabIndex = 3
        Me.cmdRefinalize.Text = "Turn Finalizer Back On"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRefinalize, Me.cmdGC, Me.cmdCreate, Me.cmdPrior})
        Me.Name = "Form1"
        Me.Text = "Resurrection"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public PriorObject As Resurrected

    Private Sub cmdRefinalize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRefinalize.Click
        If Not PriorObject Is Nothing Then
            GC.ReRegisterForFinalize(PriorObject)
        End If
        PriorObject = Nothing
    End Sub

    Private Sub cmdPrior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrior.Click
        If Not PriorObject Is Nothing Then
            ' Proof that the finalized object still exists!
            PriorObject.AreYouThere()
        End If
    End Sub

    Private Sub cmdCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        Dim obj As New Resurrected()

        ' The object has a way to reference back to the form
        obj.mycontainer = Me
    End Sub

    Private Sub cmdGC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGC.Click
        ' Force a garbage collection here.
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

End Class
