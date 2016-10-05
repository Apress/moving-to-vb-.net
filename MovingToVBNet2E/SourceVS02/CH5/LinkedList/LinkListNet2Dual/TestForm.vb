' LinkList .Net example showing dual lists
' Copyright ©2001 by Desaware Inc.  All Rights Reserved

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
    Friend WithEvents lstAtoM As System.Windows.Forms.ListBox
    Friend WithEvents label2 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdGC = New System.Windows.Forms.Button()
        Me.lstAtoM = New System.Windows.Forms.ListBox()
        Me.lstCustomers = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
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
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(24, 168)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(128, 16)
        Me.label2.TabIndex = 7
        Me.label2.Text = "A to M"
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(200, 112)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(64, 32)
        Me.cmdRemove.TabIndex = 1
        Me.cmdRemove.Text = "Remove"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(88, 24)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(136, 20)
        Me.txtCustomerName.TabIndex = 4
        Me.txtCustomerName.Text = ""
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(200, 72)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(64, 32)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "Add"
        '
        'cmdGC
        '
        Me.cmdGC.Location = New System.Drawing.Point(200, 152)
        Me.cmdGC.Name = "cmdGC"
        Me.cmdGC.Size = New System.Drawing.Size(64, 32)
        Me.cmdGC.TabIndex = 2
        Me.cmdGC.Text = "GC"
        '
        'lstAtoM
        '
        Me.lstAtoM.Location = New System.Drawing.Point(24, 184)
        Me.lstAtoM.Name = "lstAtoM"
        Me.lstAtoM.Size = New System.Drawing.Size(160, 95)
        Me.lstAtoM.TabIndex = 6
        '
        'lstCustomers
        '
        Me.lstCustomers.Location = New System.Drawing.Point(24, 72)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(160, 82)
        Me.lstCustomers.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(283, 288)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label2, Me.lstAtoM, Me.label1, Me.txtCustomerName, Me.lstCustomers, Me.cmdGC, Me.cmdRemove, Me.cmdAdd})
        Me.Name = "Form1"
        Me.Text = "Link List With Inheritance"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Note the list roots are now Customers, not LinkList objects
    Private m_List As Customer
    Private m_ListAtoM As Customer

    Protected Sub cmdGC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGC.Click
        gc.Collect()
        gc.WaitForPendingFinalizers()
    End Sub

    ' Remove from both lists
    Protected Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Dim currentcustomer As Customer

        currentcustomer = m_List
        Do While Not currentcustomer Is Nothing
            If currentcustomer.CustomerName = CStr(lstCustomers().SelectedItem) Then
                currentcustomer.Remove1(m_List)
                Exit Do
            End If
            currentcustomer = currentcustomer.NextItem1
        Loop

        currentcustomer = m_ListAtoM
        Do While Not currentcustomer Is Nothing
            If currentcustomer.CustomerName = CStr(lstCustomers().SelectedItem) Then
                currentcustomer.Remove2(m_ListAtoM)
                Exit Do
            End If
            currentcustomer = currentcustomer.NextItem2
        Loop

        UpdateList()

    End Sub

    ' In this simple example, every customer with a name >"M" is excluded
    ' from the second list
    ' Note also how there is no need to use separate Customer
    ' and LinkList variables - we're always using the Customer interface
    ' only.
    Protected Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim newEntry As New Customer()
        newEntry.CustomerName = txtCustomerName().Text
        newEntry.Append1(m_List)
        If UCase(strings.Left(newEntry.CustomerName, 1)) <= "M" Then
            newEntry.Append2(m_ListAtoM)
        End If

        UpdateList()
    End Sub

    ' Display the contents of both linked lists.
    Private Sub UpdateList()
        lstCustomers().Items.Clear()
        lstAtoM().Items.Clear()

        Dim currentcustomer As Customer
        currentcustomer = m_List
        Do While Not currentcustomer Is Nothing
            lstCustomers().Items.Add(currentcustomer.CustomerName)
            currentcustomer = currentcustomer.NextItem1
        Loop

        currentcustomer = m_ListAtoM
        Do While Not currentcustomer Is Nothing
            lstAtoM().Items.Add(currentcustomer.CustomerName)
            currentcustomer = currentcustomer.NextItem2
        Loop

    End Sub

End Class
