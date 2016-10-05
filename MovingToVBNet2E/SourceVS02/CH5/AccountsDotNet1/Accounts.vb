' Example of inheritance
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Class Account
    Protected m_AccountBalance As Decimal

    Public Sub Deposit(ByVal Amount As Decimal)
        m_AccountBalance = m_AccountBalance + Amount
    End Sub

    Public Sub Withdraw(ByVal Amount As Decimal)
        If Amount > m_AccountBalance Then
            Throw New Exception("Insufficient Funds")
        End If
        m_AccountBalance = m_AccountBalance - Amount
    End Sub

    Public Overridable Function ChargeAccount() As Decimal
        Dim AmountToCharge As Decimal
        If m_AccountBalance < 1000 Then AmountToCharge = 20
        Withdraw(AmountToCharge)
        Return (AmountToCharge)
    End Function

End Class

Class CheckingAccount
    Inherits Account
End Class

Class SavingsAccount
    Inherits Account

    Public Overrides Function ChargeAccount() As Decimal
        Dim AmountToCharge As Decimal
        If m_AccountBalance < 500 Then AmountToCharge = 5
        Withdraw(AmountToCharge)
        Return (AmountToCharge)

    End Function
End Class
