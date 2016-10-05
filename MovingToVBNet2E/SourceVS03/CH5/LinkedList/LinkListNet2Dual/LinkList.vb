' LinkList .Net example showing dual lists
' Copyright ©2001-2003 by Desaware Inc.  All Rights Reserved
Public Interface ILinkList

    ' This version is designed to link to the internal LinkList
    ' objects, using the public Container property to find the container
    Property NextItem() As ilinklist

    ' In this version all nodes are LinkList objects, so
    ' we need a public Container property to access the
    ' actual object
    Property Container() As Object

    ReadOnly Property PreviousItem(ByVal Root As ILinkList) As ILinkList

    Sub Remove(ByRef Root As ILinkList)

    Sub Append(ByRef Root As ILinkList)
End Interface

Public Class LinkList
    Implements ILinkList

    ' This version is designed to link to the internal LinkList
    ' objects, using the public Container property to find the container
    Private m_Next As ILinkList

    ' We need to be able to navigate to the container
    Private m_Container As Object

    Friend Property Container() As Object Implements ILinkList.Container
        Get
            Container = m_Container
        End Get
        Set(ByVal Value As Object)
            m_Container = Value
        End Set
    End Property

    ' Next is easy - just the next link.
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
            If (Root Is Me) Or (Root Is Nothing) Then
                Exit Property
            End If
            currentitem = Root
            Do
                If currentitem.NextItem Is Me Then
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
            Root = Me
        Else
            While Not currentitem.NextItem Is Nothing
                currentitem = currentitem.NextItem
            End While
            currentitem.NextItem = Me
        End If
    End Sub

End Class
