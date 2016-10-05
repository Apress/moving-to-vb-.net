' LinkList .Net example using inheritance
' Copyright © 2001-2003 by Desaware Inc. All Rights Reserved

' We can't implement a class - only an interface.
' so here's the interface    
Public Interface ILinkList
    WriteOnly Property Container() As Object

    Property NextItem() As ILinkList

    ReadOnly Property PreviousItem(ByVal Root As ILinkList) As ILinkList

    Sub Remove(ByRef Root As ILinkList)

    Sub Append(ByRef Root As ILinkList)
End Interface

Public Class LinkList
    Implements ILinkList

    ' This version is designed to be embedded, so it links to the container object
    Private m_Next As ILinkList
    ' When adding to the list, it needs to know its container
    Private m_Container As Object

    ' Container is set during initialization
    ' Would need to be public if you decided to componentize the class
    Friend WriteOnly Property Container() As Object Implements ILinkList.Container
        Set(ByVal Value As Object)
            m_Container = Value
        End Set
    End Property

    ' Next is easy - just the next link.
    ' Note the syntax change. See text for discussion of the Implements
    ' statement as used here
    Public Property NextItem() As ILinkList Implements ILinkList.NextItem
        Get
            NextItem = m_Next
        End Get
        Set(ByVal Value As ILinkList)
            m_Next = Value
        End Set
    End Property

    ' In a single linked list, Previous has to search forward from the root
    Public ReadOnly Property PreviousItem(ByVal Root As ILinkList) As ILinkList Implements ILinkList.PreviousItem
        Get
            Dim currentitem As ILinkList
            ' Remember, all references are to the container object
            If (Root Is m_Container) Or (Root Is Nothing) Then
                Exit Property
            End If
            currentitem = Root
            Do
                If currentitem.NextItem Is m_Container Then
                    PreviousItem = currentitem
                    Exit Property
                Else
                    currentitem = currentitem.NextItem
                End If
            Loop While Not currentitem Is Nothing
        End Get
    End Property

    ' Remove has to search from root to find the previous node.
    ' Root must be by reference so it can be cleared if this
    ' is the last object, or reset if the first object
    Public Sub Remove(ByRef Root As ILinkList) Implements ILinkList.Remove
        Dim previtem As ILinkList

        previtem = PreviousItem(Root)
        If previtem Is Nothing Then
            Root = m_Next
        Else
            previtem.NextItem = m_Next
        End If
    End Sub

    ' Append searches from Root to the end of the list.
    Public Sub Append(ByRef Root As ILinkList) Implements ILinkList.Append
        Dim currentitem As ILinkList
        currentitem = Root
        If Root Is Nothing Then
            Root = CType(m_Container, ILinkList)
        Else
            While Not currentitem.NextItem Is Nothing
                currentitem = currentitem.NextItem
            End While
            currentitem.NextItem = CType(m_Container, ILinkList)
        End If
    End Sub

End Class
