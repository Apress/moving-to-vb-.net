VERSION 5.00
Begin VB.Form frmAccounts 
   Caption         =   "Accounts Demonstration"
   ClientHeight    =   2835
   ClientLeft      =   1650
   ClientTop       =   1545
   ClientWidth     =   6210
   LinkTopic       =   "Form1"
   ScaleHeight     =   2835
   ScaleWidth      =   6210
   Begin VB.CommandButton cmdTest 
      Caption         =   "Test"
      Height          =   435
      Left            =   300
      TabIndex        =   1
      Top             =   300
      Width           =   915
   End
   Begin VB.ListBox List1 
      Height          =   1425
      Left            =   240
      TabIndex        =   0
      Top             =   1140
      Width           =   5715
   End
End
Attribute VB_Name = "frmAccounts"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Account VB6 example #3
' Copyright ©2002 by Desaware Inc.  All Rights Reserved
Private Sub cmdTest_Click()
    Dim Charge As Currency
    Dim Idx As Integer
    Dim Accounts(9) As IAccount
    For Idx = 0 To 9
        If Rnd() < 0.5 Then
            Set Accounts(Idx) = New CheckingAccount
        Else
            Set Accounts(Idx) = New SavingsAccount
        End If
        Accounts(Idx).Deposit (CCur(Rnd * 1200))
    Next Idx
    
On Error GoTo FundsError

    For Idx = 0 To 9
        Charge = Accounts(Idx).ChargeAccount()
        List1.AddItem "Amount Charged: " & Charge
    Next Idx
    Exit Sub

FundsError:
    List1.AddItem "Insufficient funds detected"
    Resume Next
End Sub

Private Sub Form_Load()
    Randomize
End Sub
