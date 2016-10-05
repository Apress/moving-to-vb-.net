Imports System.IO
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
    Friend WithEvents menuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents menuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents textBox1 As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.menuItem1 = New System.Windows.Forms.MenuItem()
        Me.menuItem2 = New System.Windows.Forms.MenuItem()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'menuItem1
        '
        Me.menuItem1.Index = 0
        Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem2})
        Me.menuItem1.Text = "File"
        '
        'menuItem2
        '
        Me.menuItem2.Index = 0
        Me.menuItem2.Text = "Open"
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem1})
        '
        'textBox1
        '
        Me.textBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(312, 144)
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = ""
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(307, 140)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1})
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Text file reader"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub menuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItem2.Click        openFileDialog1() = New OpenFileDialog()


        openFileDialog1().InitialDirectory = "c:\"
        openFileDialog1().Filter = "txt files (*.txt)|*.txt"
        openFileDialog1().FilterIndex = 1
        openFileDialog1().RestoreDirectory = True
        If openFileDialog1().ShowDialog() = DialogResult().OK Then
            Dim fs As Stream
            fs = openFileDialog1().OpenFile()
            Dim sr As New StreamReader(fs)
            textBox1().Text = sr.ReadToEnd()
            textBox1().SelectionLength = 0
        End If

    End Sub

End Class
