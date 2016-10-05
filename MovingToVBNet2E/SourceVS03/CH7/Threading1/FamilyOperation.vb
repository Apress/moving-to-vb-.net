' Threading example #1
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Public Class FamilyOperation
    Private Kids() As KidAccount
    Private Parent As ParentAccount

    Private Threads() As System.Threading.Thread

    Private m_NumberOfKids As Integer
    Private m_Stopping As Boolean

    Private m_Random As New Random()

    Property NumberOfKids() As Integer
        Get
            NumberOfKids = m_NumberOfKids
        End Get
        Set(ByVal Value As Integer)
            If Value < 1 Or Value > 50 Then
                Throw New ArgumentOutOfRangeException("Property must be between 1 and 50")
            End If
            If m_NumberOfKids <> 0 Then
                Throw New InvalidOperationException("NumberOfKids may only be set once")
            End If
            Dim Kid As Integer
            m_NumberOfKids = Value
            ReDim Kids(m_NumberOfKids - 1)
            For Kid = 0 To m_NumberOfKids - 1
                Kids(Kid) = New KidAccount()
            Next
            Parent = New ParentAccount()
        End Set
    End Property

    Private Sub KillFamily()
        m_Stopping = True
    End Sub

    Public Sub KidsSpending()
        Dim ChildIndex As Integer
        Dim Allowance As Double
        Dim thiskid As KidAccount
        Do
            ' Random kid spends some money
            ChildIndex = CInt(Int(m_Random.NextDouble() * CDbl(m_NumberOfKids)))
            thiskid = Kids(ChildIndex)

            Allowance = Parent.GiveAllowance()
            thiskid.GetAllowance(Allowance)

            thiskid.Spend()
        Loop Until m_Stopping

    End Sub



    Public Sub ParentPayday(ByVal Amount As Double)
        Parent.DepositPayroll(Amount)
    End Sub

    Public ReadOnly Property TotalDepositedToParent() As Double
        Get
            If m_NumberOfKids = 0 Then Return 0
            Return Parent.Deposited
        End Get
    End Property

    Public ReadOnly Property TotalAllocatedByParent() As Double
        Get
            If m_NumberOfKids = 0 Then Return 0
            Return Parent.Withdrawn
        End Get
    End Property

    Public ReadOnly Property ParentBalance() As Double
        Get
            If m_NumberOfKids = 0 Then Return 0
            Return Parent.Balance
        End Get
    End Property

    Public ReadOnly Property TotalSpentByKids() As Double
        Get
            If m_NumberOfKids = 0 Then Return 0
            Dim idx As Integer
            Dim Total As Double
            For idx = 0 To m_NumberOfKids - 1
                Total = Total + Kids(idx).Withdrawn
            Next
            Return Total
        End Get
    End Property

    Public ReadOnly Property TotalGivenToKids() As Double
        Get
            If m_NumberOfKids = 0 Then Return 0
            Dim idx As Integer
            Dim Total As Double
            For idx = 0 To m_NumberOfKids - 1
                Total = Total + Kids(idx).Deposited
            Next
            Return Total
        End Get
    End Property

    Public ReadOnly Property TotalKidsBalances() As Double
        Get
            If m_NumberOfKids = 0 Then Return 0
            Dim idx As Integer
            Dim Total As Double
            For idx = 0 To m_NumberOfKids - 1
                Total = Total + Kids(idx).Balance
            Next
            Return Total
        End Get
    End Property

    Public ReadOnly Property TotalFailedRequests() As Double
        Get
            If m_NumberOfKids = 0 Then Return 0
            Dim idx As Integer
            Dim Total As Double
            For idx = 0 To m_NumberOfKids - 1
                Total = Total + Kids(idx).FailedRequests
            Next
            Return Total
        End Get
    End Property


    Public Sub StartThreads(ByVal ThreadCount As Integer)
        If ThreadCount < 1 Then ThreadCount = 1
        ReDim Threads(ThreadCount - 1)
        Dim Idx As Integer
        For Idx = 0 To ThreadCount - 1
            Threads(Idx) = New Threading.Thread(AddressOf Me.KidsSpending)
            Threads(Idx).Priority = System.Threading.ThreadPriority.BelowNormal
            Threads(Idx).IsBackground = True
            Threads(Idx).Start()
        Next
    End Sub

    Public Sub StopThreads()
        Dim Idx As Integer
        Try
            KillFamily() ' Should stop all threads
            For Idx = 0 To Threads.GetUpperBound(0)
                ' Wait for thread to terminate                
                Threads(Idx).Join()
            Next
        Catch
            ' Ignore all errors
        End Try

    End Sub

End Class
