' Printing demo
' Copyright ©2001 by Desaware Inc.

Imports System.Drawing

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
    Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents cmdPreview As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdPreview = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtText
        '
        Me.txtText.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtText.Location = New System.Drawing.Point(16, 8)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtText.Size = New System.Drawing.Size(296, 80)
        Me.txtText.TabIndex = 0
        Me.txtText.Text = "Enter the sample text you wish to print here."
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(352, 16)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(64, 32)
        Me.cmdPrint.TabIndex = 1
        Me.cmdPrint.Text = "Print"
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Bitmap)
        Me.pictureBox1.Location = New System.Drawing.Point(352, 64)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(168, 128)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 2
        Me.pictureBox1.TabStop = False
        '
        'cmdPreview
        '
        Me.cmdPreview.Location = New System.Drawing.Point(448, 16)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.Size = New System.Drawing.Size(64, 32)
        Me.cmdPreview.TabIndex = 3
        Me.cmdPreview.Text = "Preview"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(547, 208)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdPreview, Me.pictureBox1, Me.cmdPrint, Me.txtText})
        Me.Name = "Form1"
        Me.Text = "Printing Demo"
        Me.ResumeLayout(False)

    End Sub



#End Region

    Public Sub PagePrintFunction(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
        Dim LineHeight, LineNumber As Single
        LineHeight = txtText().Font.GetHeight(e.Graphics)

        Dim TextRect As New RectangleF(0, LineHeight * LineNumber, e.PageBounds.Width, e.PageBounds.Height - LineHeight * LineNumber)
        Dim SF As New StringFormat(StringFormatFlags.LineLimit)

        e.Graphics.DrawString(e.PageSettings.Margins.ToString, txtText().Font, brushes.Black, TextRect)
        LineNumber += 2
        e.Graphics.DrawString(txtText().Text, txtText().Font, Brushes.Black, 0, LineHeight * LineNumber)
        LineNumber += 1
        e.Graphics.DrawImage(pictureBox1().Image, 0, LineNumber * LineHeight, e.PageBounds.Width, e.PageBounds.Height - LineNumber * LineHeight)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click        Dim prDialog As New PrintDialog()
        Dim prDoc As New Drawing.Printing.PrintDocument()
        prDoc.DocumentName = "My new printed document"
        prDialog.Document = prDoc
        prDialog.ShowDialog()

        ' Wire up the event to be called for each page
        AddHandler prDoc.PrintPage, AddressOf Me.PagePrintFunction
        prDoc.Print()
        prDoc.Dispose()
        prDialog.Dispose()
    End Sub

    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click        Dim previewDialog As New PrintPreviewDialog()
        Dim prDoc As New Drawing.Printing.PrintDocument()
        prDoc.DocumentName = "My new printed document"
        ' Wire up the event to be called for each page
        AddHandler prDoc.PrintPage, AddressOf Me.PagePrintFunction
        previewDialog.Document = prDoc
        previewDialog.ShowDialog()
        prDoc.Dispose()
        previewDialog.Dispose()
    End Sub

End Class
