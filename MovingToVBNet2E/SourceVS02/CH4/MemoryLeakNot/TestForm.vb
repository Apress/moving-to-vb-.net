' No memory leak demonstrated
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
    Friend WithEvents button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(104, 48)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 0
        Me.button1.Text = "Test"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(275, 144)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
        Me.Name = "Form1"
        Me.Text = "Memory Leak - Not"
        Me.ResumeLayout(False)

    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click        Dim x As Integer
        Dim col As New Collection()
        Dim obj As TestClassObject
        For x = 1 To 100
            obj = New TestClassObject(col)
        Next x
        Debug.WriteLine("Collection contains " + col.Count.ToString() + " objects")

        ' This would happen when we exit the function
        ' but is done here explicitly for illustrative purposes            
        col = Nothing
        obj = Nothing

        ' Don't do this in real code
        ' It's here just to make it clear that the circular
        ' reference problem is gone.
        GC.Collect()
        GC.WaitForPendingFinalizers()

    End Sub

#End Region

End Class
