' Example of inheritance
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Public Class Individual
    Implements IAccountHolder
    Private m_FirstName As String
    Private m_LastName As String
    Private m_Address As String

    Public Sub New(ByVal FirstName As String, ByVal LastName As String)
        m_FirstName = FirstName
        m_LastName = LastName
    End Sub

    ReadOnly Property Name() As String Implements IAccountHolder.Name
        Get
            Return m_FirstName & " " & m_LastName
        End Get
    End Property
End Class

Public Class Corporation
    Implements IAccountHolder
    Private m_Name As String
    Public m_CorporateAddress As String
    Public m_MailingAddress As String
    Public m_Officers() As Individual

    Public Sub New(ByVal CorporateName As String)
        m_Name = CorporateName
    End Sub

    ReadOnly Property Name() As String Implements IAccountHolder.Name
        Get
            Return m_Name
        End Get
    End Property

End Class

Public Class Country
    Implements IAccountHolder
    Private m_Name As String
    Public m_Contacts() As String

    Public Sub New(ByVal CountryName As String)
        m_Name = CountryName
    End Sub

    ReadOnly Property Name() As String Implements IAccountHolder.Name
        Get
            Return m_Name
        End Get
    End Property


End Class