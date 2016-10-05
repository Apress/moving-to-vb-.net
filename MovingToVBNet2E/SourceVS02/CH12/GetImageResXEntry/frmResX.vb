' GetImage for ResX
' Copyright ©2003 by Desaware Inc.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ImageFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ImageFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ImageFileDialog1
        '
        Me.ImageFileDialog1.Filter = "Bitmap files (*.bmp, *.jpg, *.gif)|*.bmp;*.jpg;*.gif|Icon files (*.ico)|*.ico|All" & _
        " files (*.*)|*.*"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(120, 24)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(280, 104)
        Me.txtData.TabIndex = 0
        Me.txtData.Text = "Data"
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(160, 160)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.TabIndex = 1
        Me.cmdLoad.Text = "Load Image"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(8, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.TabIndex = 2
        Me.txtName.Text = "Resource1"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Resource Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 205)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.txtName, Me.cmdLoad, Me.txtData})
        Me.Name = "Form1"
        Me.Text = "Image to ResX"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Dim dlgresult As Windows.Forms.DialogResult
        Dim img As Image

        ' Get the name of the image file
        dlgresult = ImageFileDialog1.ShowDialog()
        If dlgresult = DialogResult.OK Then
            Dim ios As New IO.MemoryStream()
            Dim sw As New IO.StreamWriter(ios)
            ' Write the ResX directly to a memory stream
            Dim rw As New Resources.ResXResourceWriter(sw)

            ' Load the image
            img = Image.FromFile(ImageFileDialog1.FileName)
            ' Add it to the ResX stream 
            rw.AddResource(txtName.Text, img)
            img.Dispose()
            ' Generate the ResX file
            rw.Generate()
            ' Seek back to the beginning of the stream
            ios.Seek(0, IO.SeekOrigin.Begin)
            ' Create a new XML Doc and load it from the stream
            Dim xmldoc As New Xml.XmlDocument()
            xmldoc.PreserveWhitespace = True
            xmldoc.Load(ios)

            ' Find the one data element (that contains the image)
            Dim imagedata As Xml.XmlElement
            imagedata = xmldoc.GetElementsByTagName("data").Item(0)
            ' Place the text on the text box and clipboard
            txtData.Text = imagedata.OuterXml
            Clipboard.SetDataObject(imagedata.OuterXml)
            sw.Close()
        End If
    End Sub
End Class
