' Threading example #5
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Public Class Account
    Protected m_Account As Double
    Protected m_Spent As Double
    Protected m_Deposited As Double
    Private Shared m_Random As New Random()
    
    Protected myMutex As New Threading.Mutex(False)
    Protected Shared MoneyAvailable As New Threading.ManualResetEvent(False)
    
    ' Returns a random amount from 0 to $1.00
    Protected Shared Function GetRandomAmount() As Double
        Dim amount As Double
        amount = int(m_Random.NextDouble * 100)
        GetRandomAmount = amount / 100
    End Function
    
    Property Withdrawn() As Double
        Get
            Withdrawn = m_Spent
        End Get
        Set
            m_Spent = Value
        End Set
    End Property
    
    Property Balance() As Double
        Get
            Balance = m_Account
        End Get
        Set
            m_Account = Value
        End Set
    End Property
    
    Property Deposited() As Double
        Get
            Deposited = m_Deposited
        End Get
        Set
            m_Deposited = Value
        End Set
    End Property
    
    ' Attempt to spend a requested amount of money, return
    ' the amount spent
    Protected Function Withdraw(ByVal amount As Double) As Double
        Try
            myMutex.WaitOne()
        Catch e As Threading.ThreadInterruptedException
            Return 0
        End Try

        If amount > m_Account Then
            amount = m_Account
        End If
        m_Account = m_Account - amount
        m_Spent = m_Spent + amount
        myMutex.ReleaseMutex()
        Return amount
    End Function
    
    Protected Sub Deposit(ByVal amount As Double)
        Try
            myMutex.WaitOne()
        Catch e As Threading.ThreadInterruptedException
            Return
        End Try
        m_Account = m_Account + amount
        m_Deposited = m_Deposited + amount
        myMutex.ReleaseMutex()
    End Sub
    
    Public Overridable Sub Clear()
        m_Account = 0
        m_Deposited = 0
        m_Spent = 0
    End Sub
    
End Class

' Make the KidAccount synchronized to solve the access problem
Public Class KidAccount
    Inherits Account
    
    Private m_FailedRequests As Double
    ReadOnly Property FailedRequests() As Double
        Get
            FailedRequests = m_FailedRequests
        End Get
    End Property
    
    ' Gets an allowance from the parent
    Public Sub GetAllowance(ByVal amount As Double)
        Deposit(amount)
    End Sub
    
    ' Tries to spend a random amount of money
    Public Sub Spend()
        Dim amount As Double
        
        ' Always wait until money is available
        ' What would happen if we held the mutex here?
        Try
            If m_Account = 0 Then MoneyAvailable.WaitOne()
        Catch
            ' Interrupt on termination
            Exit Sub
        End Try
        
        amount = GetRandomAmount()
        If amount > m_Account Then amount = m_Account
        If amount = 0 Then
            m_FailedRequests = m_FailedRequests + 1
        Else
            Withdraw(amount)
        End If
    End Sub
    
    ' Clear the object and base class
    Overrides Sub Clear()
        m_FailedRequests = 0
        MyBase.Clear()
    End Sub
End Class

Public Class ParentAccount
    Inherits Account
    
    ' When called, the Parent Account picks a random allowance
    ' and gives it. 
    Public Function GiveAllowance() As Double
        Dim amount As Double
        amount = GetRandomAmount()
        amount = Withdraw(amount)
        ' Return amount actually withdrawn (may be 0)
        ' If no money is left, stop the process
        ' Note there is still a subtle synchronization bug - 
        ' do you see it?
        If m_Account = 0 Then MoneyAvailable.Reset()
        Return (amount)
    End Function
    
    
    Public Sub DepositPayroll(ByVal amount As Double)
        deposit(amount)
        ' Set event - let kids know money is available
        MoneyAvailable.Set()
    End Sub
End Class