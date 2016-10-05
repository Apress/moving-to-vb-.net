Imports BillingRemotingServer
Imports System.Runtime.Remoting
Public Class BillingViaRemoting
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtHours As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdAdd As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtHours = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 80)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(368, 120)
        Me.DataGrid1.TabIndex = 0
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(328, 48)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(48, 24)
        Me.cmdAdd.TabIndex = 7
        Me.cmdAdd.Text = "Add"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(256, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Hours:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Description:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(88, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(136, 20)
        Me.txtName.TabIndex = 2
        Me.txtName.Text = ""
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(88, 48)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(224, 20)
        Me.txtDescription.TabIndex = 1
        Me.txtDescription.Text = ""
        '
        'txtHours
        '
        Me.txtHours.Location = New System.Drawing.Point(312, 16)
        Me.txtHours.Name = "txtHours"
        Me.txtHours.Size = New System.Drawing.Size(64, 20)
        Me.txtHours.TabIndex = 3
        Me.txtHours.Text = "1"
        '
        'BillingViaRemoting
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 213)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHours)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "BillingViaRemoting"
        Me.Text = "Billing Via Remoting"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private b As RemoteBillingObject

    Private Sub BillingViaWeb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim LoadingDirectory As String
        ' Config file for this example is in the parent above the bin directory
        ' That's because we aren't including bin directories in the install
        ' In practice you can put it in the exe directory
        LoadingDirectory = AppDomain.CurrentDomain.BaseDirectory
        LoadingDirectory = LoadingDirectory.Remove(Len(LoadingDirectory) - 1, 1)
        LoadingDirectory = IO.Directory.GetParent(LoadingDirectory).ToString
        RemotingConfiguration.Configure(LoadingDirectory & "\BillingWinAppRemoting.config")

        b = New RemoteBillingObject
        DataGrid1.DataSource = b.GetBillingInfo
        DataGrid1.NavigateTo(0, "BillingTable")
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim b As New RemoteBillingObject
        b.AddBillingRecord(txtName.Text, CInt(txtHours.Text), txtDescription.Text)
        DataGrid1.DataSource = b.GetBillingInfo
    End Sub
End Class
