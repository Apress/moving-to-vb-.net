' ADO Example
' Copyright ©2001-2003 by Desaware Inc.
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
    Friend WithEvents dataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents cmdXML As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents cmdXML2 As System.Windows.Forms.Button
    Friend WithEvents cmdCreateDB As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdXML = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.cmdCreateDB = New System.Windows.Forms.Button()
        Me.cmdXML2 = New System.Windows.Forms.Button()
        Me.dataGrid1 = New System.Windows.Forms.DataGrid()
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdXML
        '
        Me.cmdXML.Location = New System.Drawing.Point(128, 120)
        Me.cmdXML.Name = "cmdXML"
        Me.cmdXML.Size = New System.Drawing.Size(75, 32)
        Me.cmdXML.TabIndex = 2
        Me.cmdXML.Text = "ShowXML Schema"
        '
        'txtResult
        '
        Me.txtResult.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtResult.Location = New System.Drawing.Point(24, 160)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResult.Size = New System.Drawing.Size(464, 136)
        Me.txtResult.TabIndex = 3
        Me.txtResult.Text = ""
        '
        'cmdCreateDB
        '
        Me.cmdCreateDB.Location = New System.Drawing.Point(24, 120)
        Me.cmdCreateDB.Name = "cmdCreateDB"
        Me.cmdCreateDB.Size = New System.Drawing.Size(80, 32)
        Me.cmdCreateDB.TabIndex = 0
        Me.cmdCreateDB.Text = "Create DB"
        '
        'cmdXML2
        '
        Me.cmdXML2.Location = New System.Drawing.Point(216, 120)
        Me.cmdXML2.Name = "cmdXML2"
        Me.cmdXML2.Size = New System.Drawing.Size(72, 32)
        Me.cmdXML2.TabIndex = 4
        Me.cmdXML2.Text = "Show XML"
        '
        'dataGrid1
        '
        Me.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dataGrid1.DataMember = ""
        Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dataGrid1.Location = New System.Drawing.Point(16, 16)
        Me.dataGrid1.Name = "dataGrid1"
        Me.dataGrid1.Size = New System.Drawing.Size(472, 88)
        Me.dataGrid1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(507, 312)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdXML2, Me.txtResult, Me.cmdXML, Me.dataGrid1, Me.cmdCreateDB})
        Me.Name = "Form1"
        Me.Text = "Database Example"
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub



#End Region
    Private Sub cmdCreateDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateDB.Click        Dim tv As New TVListingDB()
        tv.LoadInitialData()
        dataGrid1.DataSource = tv.TVTable
    End Sub

    Private Sub cmdXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXML.Click        Dim tv As New TVListingDB()
        Dim sr As New StringWriter()
        tv.LoadInitialData()
        txtResult.Text = ""
        tv.GetDataSet.WriteXmlSchema(sr)
        txtResult.Text = sr.ToString

    End Sub

    Private Sub cmdXML2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXML2.Click        Dim tv As New TVListingDB()
        Dim sr As New StringWriter()
        tv.LoadInitialData()
        txtResult.Text = ""
        tv.GetDataSet.WriteXml(sr)
        txtResult.Text = sr.ToString

    End Sub

End Class
