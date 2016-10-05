' Example of inheritance
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Module Module1

    Sub ChargeAllFees(ByVal Products() As IChargeable)
        Dim Idx As Integer
        Dim Charge As Decimal

        For Idx = 0 To Products.Length - 1
            Try
                Charge = Products(Idx).ChargeFee()
                Console.WriteLine(String.Format("{0} was charged: {1}", Products(Idx).Description, Charge.ToString))
            Catch ex As Exception
                Console.WriteLine(String.Format("{0} had insufficient funds", Products(Idx).Description))
            End Try
        Next Idx

    End Sub

    Sub Main()
        Randomize()
        Dim Idx As Integer
        Dim Accounts(99) As Account
        Dim SafetyBoxes(10) As SafeDepositBox
        For Idx = 0 To Accounts.Length - 1
            If Rnd() < 0.5 Then
                Accounts(Idx) = New CheckingAccount
            Else
                Accounts(Idx) = New SavingsAccount
            End If
            Accounts(Idx).Deposit(CDec(Rnd() * 1200))

            Select Case Rnd()
                Case 0 To 0.333
                    Accounts(Idx).AccountHolder = New Individual("Joe", CStr(Idx))
                Case 0.333 To 0.666
                    Accounts(Idx).AccountHolder = New Corporation("Company # " & CStr(Idx) & " inc.")
                Case Else
                    Accounts(Idx).AccountHolder = New Country("Republic of " & CStr(Idx))
            End Select
        Next Idx

        For Idx = 0 To SafetyBoxes.Length - 1
            SafetyBoxes(Idx) = New SafeDepositBox(DirectCast(System.Enum.ToObject(GetType(BoxSize), CInt(Int(Rnd() * 3))), BoxSize))
        Next
        ChargeAllFees(Accounts)
        ChargeAllFees(SafetyBoxes)

        Console.ReadLine()
    End Sub

End Module
