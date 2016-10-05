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
   Begin VB.CommandButton cmdRemove 
      Caption         =   "Remove"
      Height          =   375
      Left            =   4410
      TabIndex        =   4
      Top             =   990
      Width           =   915
   End
   Begin VB.ListBox lstCustomers 
      Height          =   2010
      Left            =   720
      TabIndex        =   3
      Top             =   990
      Width           =   3165
   End
   Begin VB.CommandButton cmdAdd 
      Caption         =   "Add"
      Height          =   375
      Left            =   4320
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
' LinkList VB6 example #1
' Copyright ©2000 by Desaware Inc.  All Rights Reserved

Option Explicit

Dim m_List As LinkList

' Updates the list box
' Note the use of separate variables to access each interface
Private Sub UpdateList()
   lstCustomers.Clear
   Dim currentlist As LinkList
   Dim currentcustomer As Customer
   Set currentlist = m_List
   Do While Not currentlist Is Nothing
      Set currentcustomer = currentlist
      lstCustomers.AddItem currentcustomer.CustomerName
      Set currentlist = currentlist.NextItem
   Loop
End Sub

Private Sub cmdAdd_Click()
   Dim newEntry As New Customer
   Dim newEntryll As LinkList
   newEntry.CustomerName = txtCustomerName.Text
   Set newEntryll = newEntry
   newEntryll.Append m_List
   UpdateList
End Sub

Private Sub cmdRemove_Click()
   Dim currentlist As LinkList
   Dim currentcustomer As Customer
   
   Set currentlist = m_List
   Do While Not currentlist Is Nothing
      Set currentcustomer = currentlist
      If currentcustomer.CustomerName = lstCustomers.Text Then
         currentlist.Remove m_List
         UpdateList
         Exit Sub
      End If
      Set currentlist = currentlist.NextItem
   Loop
   UpdateList
End Sub

