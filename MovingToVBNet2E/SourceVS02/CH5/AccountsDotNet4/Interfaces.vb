' Example of inheritance
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Interface IAccountHolder
    ReadOnly Property Name() As String
End Interface

Interface IChargeable
    Function ChargeFee() As Decimal
    ReadOnly Property Description() As String
End Interface