' Toggling list box state
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
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
    Friend WithEvents chkMulti As System.Windows.Forms.CheckBox
    Friend WithEvents lblWindow As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.chkMulti = New System.Windows.Forms.CheckBox()
        Me.lblWindow = New System.Windows.Forms.Label()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'chkMulti
        '
        Me.chkMulti.Location = New System.Drawing.Point(192, 64)
        Me.chkMulti.Name = "chkMulti"
        Me.chkMulti.Size = New System.Drawing.Size(80, 16)
        Me.chkMulti.TabIndex = 1
        Me.chkMulti.Text = "MultiSelect"
        '
        'lblWindow
        '
        Me.lblWindow.Location = New System.Drawing.Point(32, 192)
        Me.lblWindow.Name = "lblWindow"
        Me.lblWindow.Size = New System.Drawing.Size(232, 16)
        Me.lblWindow.TabIndex = 2
        '
        'listBox1
        '
        Me.listBox1.Location = New System.Drawing.Point(24, 24)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(144, 160)
        Me.listBox1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 216)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWindow, Me.chkMulti, Me.listBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub


#End Region
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load        Dim x As Integer
        For x = 1 To 20
            listBox1().Items.Add("Entry # " & CStr(x))
        Next
        lblWindow().Text = "hWnd = " & listBox1().Handle.ToString
    End Sub

    Private Sub chkMulti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMulti.CheckedChanged        If chkMulti().CheckState = CheckState.Checked Then
            listBox1().SelectionMode = SelectionMode.MultiExtended
        Else
            listBox1().SelectionMode = SelectionMode.One
        End If
        lblWindow().Text = "hWnd = " & listBox1().Handle.ToString

    End Sub

End Class
