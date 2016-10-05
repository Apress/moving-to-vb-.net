' Example of inheritance
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Public Enum BoxSize
    Small
    Medium
    Large
End Enum

Public Class SafeDepositBox
    Implements IChargeable

    Private Shared boxcounter As Integer

    Private m_Box As Integer
    Private m_BoxSize As BoxSize

    Public Sub New(ByVal size As BoxSize)
        m_Box = Threading.Interlocked.Increment(boxcounter)
        m_BoxSize = size
    End Sub

    Public Function ChargeFee() As Decimal Implements IChargeable.ChargeFee
        ' Generate invoice here?
        Return (5 * m_BoxSize + 5)
    End Function

    Public ReadOnly Property Description() As String Implements AccountsDotNet4.IChargeable.Description
        Get
            Return ("Box #: " & CStr(m_Box))
        End Get
    End Property
End Class
