' LinkList .Net example using inheritance
' Copyright © 2001 by Desaware Inc. All Rights Reserved

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
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents lstCustomers As System.Windows.Forms.ListBox
    Friend WithEvents cmdGC As System.Windows.Forms.Button
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents label1 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.cmdGC = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.lstCustomers = New System.Windows.Forms.ListBox()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(88, 24)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(136, 20)
        Me.txtCustomerName.TabIndex = 4
        Me.txtCustomerName.Text = ""
        '
        'cmdGC
        '
        Me.cmdGC.Location = New System.Drawing.Point(200, 152)
        Me.cmdGC.Name = "cmdGC"
        Me.cmdGC.Size = New System.Drawing.Size(64, 32)
        Me.cmdGC.TabIndex = 2
        Me.cmdGC.Text = "GC"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 16)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Customer:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(200, 72)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(64, 32)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "Add"
        '
        'lstCustomers
        '
        Me.lstCustomers.Location = New System.Drawing.Point(24, 72)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(160, 108)
        Me.lstCustomers.TabIndex = 3
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(200, 112)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(64, 32)
        Me.cmdRemove.TabIndex = 1
        Me.cmdRemove.Text = "Remove"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 216)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label1, Me.txtCustomerName, Me.lstCustomers, Me.cmdGC, Me.cmdRemove, Me.cmdAdd})
        Me.Name = "Form1"
        Me.Text = "Link List With Inheritance"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private m_List As ILinkList

    ' Updates the list box
    ' Note that there is no need for separate variables - the
    ' ILinkList interface is seemlessly added to the object
    Private Sub UpdateList()
        lstCustomers.Items.Clear()
        Dim currentcustomer As customer
        currentcustomer = CType(m_List, Customer)
        Do While Not currentcustomer Is Nothing
            lstCustomers.Items.Add(currentcustomer.CustomerName)
            currentcustomer = CType(currentcustomer.NextItem, customer)
        Loop
    End Sub

    Protected Sub cmdGC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGC.Click
        gc.Collect()
        gc.WaitForPendingFinalizers()
    End Sub


    Protected Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Dim currentcustomer As Customer

        currentcustomer = CType(m_List, Customer)

        Do While Not currentcustomer Is Nothing
            If currentcustomer.CustomerName = CStr(lstCustomers().SelectedItem) Then
                currentcustomer.Remove(m_List)
                UpdateList()
                Exit Sub
            End If
            currentcustomer = CType(currentcustomer.NextItem, Customer)
        Loop
        UpdateList()

    End Sub

    Protected Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim newEntry As New Customer()
        newEntry.CustomerName = txtCustomerName().Text
        newEntry.Append(m_List)
        UpdateList()
    End Sub




End Class
