' Example of inheritance
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Module Module1

    Sub ChargeAllAccounts(ByVal Accounts() As Account)
        Dim Idx As Integer
        Dim Charge As Decimal

        For Idx = 0 To Accounts.Length - 1
            Try
                Charge = Accounts(Idx).ChargeAccount()
                Console.WriteLine(String.Format("Account charged: {0}", Charge.ToString))
            Catch ex As Exception
                Console.WriteLine("Insufficient funds")
            End Try
        Next Idx

    End Sub

    Sub Main()
        Randomize()
        Dim Idx As Integer
        Dim Accounts(99) As Account
        For Idx = 0 To Accounts.Length - 1
            If Rnd() < 0.5 Then
                Accounts(Idx) = New CheckingAccount
            Else
                Accounts(Idx) = New SavingsAccount
            End If
            Accounts(Idx).Deposit(CDec(Rnd() * 1200))
        Next Idx

        ChargeAllAccounts(Accounts)

        Console.ReadLine()
    End Sub

End Module
