VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "LinkList"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
' LinkList VB6 example #2
' Copyright ©2000 by Desaware Inc.  All Rights Reserved
Option Explicit

' This version is designed to link to the internal LinkList
' objects, using the public Container property to find the container
Private m_Next As LinkList
' When adding to the list, it needs to know its container
Private m_Container As Object

' This version all nodes are LinkList objects, so
' we need a public Container property to access the
' actual object
Public Property Set Container(ByVal ContainerObject As Object)
   Set m_Container = ContainerObject
End Property

Public Property Get Container() As Object
   Set Container = m_Container
End Property

' Next is easy - just the next link.
Public Property Get NextItem() As LinkList
   Set NextItem = m_Next
End Property

Public Property Set NextItem(ByVal nextptr As LinkList)
   Set m_Next = nextptr
End Property

' In a single linked list, Previous has to search forward from the root
Public Property Get PreviousItem(Root As LinkList) As LinkList
   Dim currentitem As LinkList
   ' Remember, all references are to the LinkList object
   If (Root Is Me) Or (Root Is Nothing) Then
      Exit Property
   End If
   Set currentitem = Root
   Do
      If currentitem.NextItem Is Me Then
         Set PreviousItem = currentitem
         Exit Property
      Else
         Set currentitem = currentitem.NextItem
      End If
   Loop While Not currentitem Is Nothing
End Property

' Remove has to search from root to find the previous node.
' Root must be by reference so it can be cleared if this
' is the last object, or reset if the first object
Public Sub Remove(Root As LinkList)
   Dim previtem As LinkList

   Set previtem = PreviousItem(Root)
   
   If previtem Is Nothing Then
      Set Root = m_Next
   Else
      Set previtem.NextItem = m_Next
   End If
End Sub

' Append searches from Root to the end of the list.
Public Sub Append(Root As LinkList)
   Dim currentitem As LinkList
   Set currentitem = Root
   If Root Is Nothing Then
      Set Root = Me
   Else
      While Not currentitem.NextItem Is Nothing
         Set currentitem = currentitem.NextItem
      Wend
      Set currentitem.NextItem = Me
   End If
End Sub
