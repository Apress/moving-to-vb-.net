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
' LinkList VB6 example #2
' Copyright ©2000 by Desaware Inc.  All Rights Reserved
Option Explicit

Public CustomerName As String

' This version shows how a node can be in two lists at once.
' Note that the object does NOT Implement the LinkList interface
' Even though the links are done internally between LinkList objects,
' the outside world sees only Customer objects - thus all parameters
' and return values on link methods are Customer and not LinkList
Private m_MyLinkList As LinkList
Private m_MyOtherLinkList As LinkList


Private Sub Class_Initialize()
   Set m_MyLinkList = New LinkList
   Set m_MyLinkList.Container = Me
   Set m_MyOtherLinkList = New LinkList
   Set m_MyOtherLinkList.Container = Me
End Sub

Private Sub Class_Terminate()
   Debug.Print "Terminating customer " & CustomerName
End Sub

' Because we link into the contained object, we need
' a way to get access to the contained object in other nodes
Friend Property Get LinkList1() As LinkList
   Set LinkList1 = m_MyLinkList
End Property

' Functions require a bit more work to detect
' boundary conditions such as an empty list.
Public Sub AppendList1(Root As Customer)
   If Root Is Nothing Then
      Set Root = Me
   Else
      ' This line would fail if Root is Nothing
      m_MyLinkList.Append Root.LinkList1
   End If
End Sub

' Again note how the implementation uses the LinkList object,
' but people using the Customer object only see references to
' Customer objects
Public Property Set NextItem1(ByVal nextobject As Customer)
   Set m_MyLinkList.NextItem = nextobject.LinkList1
End Property


Public Property Get NextItem1() As Customer
   Dim nextref As LinkList
   Set nextref = m_MyLinkList.NextItem
   ' We have to check the Nothing condition explicitely,
   ' otherwise the call to nextref.Container will fail.
   If nextref Is Nothing Then Exit Property
   Set NextItem1 = nextref.Container
End Property

Public Property Get PreviousItem1(Root As Customer) As Customer
   Set PreviousItem1 = m_MyLinkList.PreviousItem(Root.LinkList1)
End Property

' This one is subtle...
Public Sub Remove1(Root As Customer)
   Dim llroot As LinkList
   Set llroot = Root.LinkList1
   ' Why not just use m_MyLinkList.Remove Root.LinkList1?
   ' Because Root.LinkList1 will be placed in a temporary variable
   ' which is then called by reference. Changes to that temporary
   ' variable will nto be magically reflected back to the Root.LinkList1 reference
   ' So we need to use our own temporary variable so that we can
   ' detect changes to that variable on this ByRef call.
   m_MyLinkList.Remove llroot
   If llroot Is Nothing Then
      Set Root = Nothing
   Else
      Set Root = llroot.Container
   End If
End Sub

' Here's a second set of functions for the second list
Friend Property Get LinkList2() As LinkList
   Set LinkList2 = m_MyOtherLinkList
End Property

Public Sub AppendList2(Root As Customer)
   If Root Is Nothing Then
      Set Root = Me
   Else
      m_MyOtherLinkList.Append Root.LinkList2
   End If
End Sub

Public Property Set NextItem2(ByVal RHS As Customer)
   Set m_MyOtherLinkList.NextItem = RHS.LinkList2
End Property

Public Property Get NextItem2() As Customer
   Dim nextref As LinkList
   Set nextref = m_MyOtherLinkList.NextItem
   If nextref Is Nothing Then Exit Property
   Set NextItem2 = nextref.Container
End Property

Public Property Get PreviousItem2(Root As Customer) As Customer
   Set PreviousItem2 = m_MyOtherLinkList.PreviousItem(Root.LinkList2)
End Property

Public Sub Remove2(Root As Customer)
   Dim llroot As LinkList
   Set llroot = Root.LinkList2
   m_MyOtherLinkList.Remove llroot
   If llroot Is Nothing Then
      Set Root = Nothing
   Else
      Set Root = llroot.Container
   End If
End Sub

