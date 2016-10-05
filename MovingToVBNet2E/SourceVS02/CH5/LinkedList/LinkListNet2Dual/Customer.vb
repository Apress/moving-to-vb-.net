' LinkList .Net example showing dual lists
' Copyright ©2001 by Desaware Inc.  All Rights Reserved
Public Class Customer
    Public CustomerName As String

    ' This version shows how a node can be in two lists at once.
    ' Note that the object does NOT Implement the LinkList interface
    ' Even though the links are done internally between LinkList objects,
    ' the outside world sees only Customer objects - thus all parameters
    ' and return values on link methods are Customer and not LinkList
    Private m_MyLinkList1 As ILinkList
    Private m_MyLinkList2 As ILinkList

    Public Sub New()
        MyBase.New()
        m_MyLinkList1 = New LinkList()
        m_MyLinkList1.Container = Me
        m_MyLinkList2 = New LinkList()
        m_MyLinkList2.Container = Me
    End Sub

    Protected Overrides Sub Finalize()
        system.diagnostics.Debug.WriteLine("Terminating customer " + CustomerName)
    End Sub

    ' Because we link into the contained object, we need
    ' a way to get access to the contained object in other nodes
    Friend ReadOnly Property LinkList1() As ILinkList
        Get
            LinkList1 = m_MyLinkList1
        End Get
    End Property

    Friend ReadOnly Property LinkList2() As ILinkList
        Get
            LinkList2 = m_MyLinkList2
        End Get
    End Property


    ' Functions require a bit more work to detect
    ' boundary conditions such as an empty list.
    Public Sub Append1(ByRef Root As Customer)
        If root Is Nothing Then
            root = Me
        Else
            ' This line would fail if Root is Nothing
            m_MyLinkList1.Append(Root.m_MyLinkList1)
        End If
    End Sub

    Public Sub Append2(ByRef Root As Customer)
        If root Is Nothing Then
            root = Me
        Else
            m_MyLinkList2.Append(Root.m_MyLinkList2)
        End If
    End Sub

    ' Again note how the implementation uses the ILinkList interface,
    ' but people using the Customer object only see references to
    ' Customer objects
    Public ReadOnly Property NextItem1() As Customer
        Get
            Dim nextref As ILinkList
            nextref = m_MyLinkList1.NextItem
            ' We have to check the Nothing condition explicitly,
            ' otherwise the call to nextref.Container will fail.
            If nextref Is Nothing Then
                nextitem1 = Nothing
            Else
                ' nextref.container is of type Object. We need to convert explicitly
                nextitem1 = CType(nextref.container, Customer)
            End If

        End Get
    End Property

    Public ReadOnly Property NextItem2() As Customer
        Get
            Dim nextref As ILinkList
            nextref = m_MyLinkList2.NextItem
            If nextref Is Nothing Then
                nextitem2 = Nothing
            Else
                nextitem2 = CType(nextref.container, Customer)
            End If
        End Get
    End Property


    Public ReadOnly Property PreviousItem1(ByVal Root As Customer) As Customer
        Get
            PreviousItem1 = CType(m_MyLinkList1.PreviousItem(Root.LinkList1), Customer)
        End Get
    End Property

    Public ReadOnly Property PreviousItem2(ByVal Root As Customer) As Customer
        Get
            PreviousItem2 = CType(m_MyLinkList2.PreviousItem(Root.LinkList2), Customer)
        End Get
    End Property


    Sub Remove1(ByRef Root As Customer)
        Dim llroot As ILinkList
        llroot = Root.LinkList1
        ' Why not just use m_MyLinkList.Remove Root.LinkList1?
        ' Because Root.LinkList1 will be placed in a temporary variable
        ' which is then called by reference. Changes to that temporary
        ' variable will not be magically reflected back to the Root.LinkList1 reference
        ' So we need to use our own temporary variable so that we can
        ' detect changes to that variable on this ByRef call.
        m_MyLinkList1.Remove(llroot)
        If llroot Is Nothing Then
            Root = Nothing
        Else
            Root = CType(llroot.Container, Customer)
        End If
    End Sub

    Sub Remove2(ByRef Root As Customer)
        Dim llroot As ILinkList
        llroot = Root.LinkList2
        m_MyLinkList2.Remove(llroot)
        If llroot Is Nothing Then
            Root = Nothing
        Else
            Root = CType(llroot.Container, Customer)
        End If
    End Sub

End Class
