' LinkList .Net example using aggregation
' Copyright © 2001 by Desaware Inc. All Rights Reserved
Public Class Customer
    ' This version Implements the LinkList - making
    ' its methods accessable via LinkList objects
    Implements ilinklist

    Public CustomerName As String

    ' The internal LinkList object provides the functionality
    Private m_MyLinkList As LinkList

    Public Sub New()
        MyBase.New()
        m_MyLinkList = New LinkList()
        m_MyLinkList.Container = Me
    End Sub

    ' Objects will terminate in VB.Net. See text for details.
    Protected Overrides Sub Finalize()
        system.diagnostics.Debug.WriteLine("Terminating customer " + CustomerName)
    End Sub

    ' Methods & properties just map to the LinkList members & properties
    Public Sub Append(ByRef Root As ILinkList) Implements ILinkList.Append
        m_MyLinkList.Append(Root)
    End Sub

    Public Property NextItem() As ILinkList Implements ILinkList.NextItem
        Set(ByVal Value As ILinkList)
            m_MyLinkList.NextItem = Value
        End Set
        Get
            NextItem = m_MyLinkList.NextItem
        End Get
    End Property

    Friend WriteOnly Property Container() As Object Implements ILinkList.Container
        Set(ByVal Value As Object)
            m_MyLinkList.Container = value
        End Set
    End Property

    Public ReadOnly Property PreviousItem(ByVal Root As ILinkList) As ILinkList Implements ILinkList.previousitem
        Get
            PreviousItem = m_MyLinkList.PreviousItem(Root)
        End Get
    End Property

    Sub Remove(ByRef Root As ILinkList) Implements ILinkList.Remove
        m_MyLinkList.Remove(Root)
    End Sub

End Class
