VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "CheckingAccount"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
' Account VB6 example #2
' Copyright ©2002 by Desaware Inc.  All Rights Reserved
Option Explicit

Public m_Account As New Account

Public Sub Deposit(ByVal Amount As Currency)
    m_Account.Deposit Amount
End Sub

Public Sub Withdraw(ByVal Amount As Currency)
    m_Account.Withdraw Amount
End Sub

Public Function ChargeAccount() As Currency
    Dim AmountToCharge As Currency
    If m_Account.AccountBalance < 1000 Then AmountToCharge = 20
    Withdraw AmountToCharge
    ChargeAccount = AmountToCharge
End Function

Private Sub Class_Initialize()
    Set m_Account.MyContainer = Me
End Sub
