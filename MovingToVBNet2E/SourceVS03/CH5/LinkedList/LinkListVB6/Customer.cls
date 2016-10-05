VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Customer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
' LinkList VB6 example #1
' Copyright ©2000 by Desaware Inc.  All Rights Reserved

Option Explicit

' This version Implements the LinkList - making
' its methods accessable via LinkList objects
Implements LinkList

Public CustomerName As String

' The internal LinkList object provides the functionality
Private m_MyLinkList As LinkList

Private Sub Class_Initialize()
   Set m_MyLinkList = New LinkList
   Set m_MyLinkList.Container = Me
End Sub

' This will never be called. Read text for how
' to get around this problem
Private Sub Class_Terminate()
   Debug.Print "Terminating customer " & CustomerName
End Sub

' Methods & properties just map to the LinkList members & properties
Private Sub LinkList_Append(Root As LinkList)
   m_MyLinkList.Append Root
End Sub


Private Property Set LinkList_NextItem(ByVal nextobject As LinkList)
   Set m_MyLinkList.NextItem = nextobject
End Property

Private Property Get LinkList_NextItem() As LinkList
   Set LinkList_NextItem = m_MyLinkList.NextItem
End Property

Private Property Get LinkList_PreviousItem(Root As LinkList) As LinkList
   Set LinkList_PreviousItem = m_MyLinkList.PreviousItem(Root)
End Property

Private Sub LinkList_Remove(Root As LinkList)
   m_MyLinkList.Remove Root
End Sub
