VERSION 5.00
Begin VB.Form frmLinkListTest 
   Caption         =   "Link List Test Form"
   ClientHeight    =   3540
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6000
   LinkTopic       =   "Form1"
   ScaleHeight     =   3540
   ScaleWidth      =   6000
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox lstAToM 
      Height          =   1620
      Left            =   3960
      TabIndex        =   5
      Top             =   1440
      Width           =   1905
   End
   Begin VB.CommandButton cmdRemove 
      Caption         =   "Remove"
      Height          =   375
      Left            =   2430
      TabIndex        =   4
      Top             =   990
      Width           =   1005
   End
   Begin VB.ListBox lstCustomers 
      Height          =   2010
      Left            =   360
      TabIndex        =   3
      Top             =   990
      Width           =   1995
   End
   Begin VB.CommandButton cmdAdd 
      Caption         =   "Add"
      Height          =   375
      Left            =   4590
      TabIndex        =   2
      Top             =   270
      Width           =   1005
   End
   Begin VB.TextBox txtCustomerName 
      Height          =   285
      Left            =   1350
      TabIndex        =   0
      Top             =   270
      Width           =   2715
   End
   Begin VB.Label Label2 
      Caption         =   "Secondary List"
      Height          =   195
      Left            =   3960
      TabIndex        =   6
      Top             =   1080
      Width           =   1815
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "Customer:"
      Height          =   285
      Left            =   360
      TabIndex        =   1
      Top             =   270
      Width           =   825
   End
End
Attribute VB_Name = "frmLinkListTest"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' LinkList VB6 example #2
' Copyright ©2000 by Desaware Inc.  All Rights Reserved
Option Explicit

' Note the list roots are now Customers, not LinkList objects
Dim m_List1 As Customer
Dim m_List2 As Customer

' Display the contents of both linked lists.
Private Sub UpdateList()
   Dim currentcustomer As Customer
   
   lstCustomers.Clear
   lstAToM.Clear
   
   Set currentcustomer = m_List1
   Do While Not currentcustomer Is Nothing
      lstCustomers.AddItem currentcustomer.CustomerName
      Set currentcustomer = currentcustomer.NextItem1
   Loop

   Set currentcustomer = m_List2
   Do While Not currentcustomer Is Nothing
      lstAToM.AddItem currentcustomer.CustomerName
      Set currentcustomer = currentcustomer.NextItem2
   Loop

End Sub

' In this simple example, every customer with a name >"M is excluded
' from the second list
' Not also how there is no need to use separate Customer
' and LinkList variables - we're always using the Customer interface
' only.
Private Sub cmdAdd_Click()
   Dim newEntry As New Customer
   newEntry.CustomerName = txtCustomerName.Text
   newEntry.AppendList1 m_List1
   If UCase(Left$(newEntry.CustomerName, 1)) <= "M" Then
      newEntry.AppendList2 m_List2
   End If
   UpdateList
End Sub

' Again, we don't use the LinkList type variable for
' the removal.
Private Sub cmdRemove_Click()
   Dim currentcustomer As Customer
   
   Set currentcustomer = m_List1
   Do While Not currentcustomer Is Nothing
      If currentcustomer.CustomerName = lstCustomers.Text Then
         currentcustomer.Remove1 m_List1
         Exit Do
      End If
      Set currentcustomer = currentcustomer.NextItem1
   Loop
   
   Set currentcustomer = m_List2
   Do While Not currentcustomer Is Nothing
      If currentcustomer.CustomerName = lstCustomers.Text Then
         currentcustomer.Remove2 m_List2
         Exit Do
      End If
      Set currentcustomer = currentcustomer.NextItem2
   Loop
   
   UpdateList
End Sub

