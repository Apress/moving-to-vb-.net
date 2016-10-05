' Value type examples
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Public Structure mystruct
    Public AString As String
    Public Sub SetString(ByVal newstring As String)
        AString = newstring
    End Sub
    Public Sub New(ByVal InitialString As String)
        AString = InitialString
    End Sub
End Structure

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private Class myclass1
        Public AString As String
        Public Sub SetString(ByVal newstring As String)
            AString = newstring
        End Sub
        Public Sub New(ByVal InitialString As String)
            AString = InitialString
        End Sub
    End Class

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
    Friend WithEvents button2 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(24, 16)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(112, 32)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Value Types"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(152, 16)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(120, 32)
        Me.button2.TabIndex = 1
        Me.button2.Text = "Compare Types"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 88)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.button1})
        Me.Name = "Form1"
        Me.Text = "Value Types"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button2.Click
        Dim S1 As New mystruct("Hello")
        Dim S2 As mystruct
        Dim c1 As New myclass1("Hello")
        Dim c2 As myclass1
        S2 = S1
        c2 = c1
        S2.SetString("Modified")
        c2.SetString("Modified")
        Debug.WriteLine("Struct: " + S1.AString)
        Debug.WriteLine("Class: " + c1.AString)
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim a As mystruct
        a.SetString("Hello")
        Dim b As mystruct = a
        Debug.WriteLine("B's String: " + b.AString)
        Dim c As New mystruct("Another string")
        Debug.WriteLine("C's String: " + c.AString)
        Debug.WriteLine("C's ToString: " + c.ToString())

        Dim obj As Object
        obj = c
        ' Boxed into an object        
        Debug.WriteLine(obj.ToString())

    End Sub


End Class
