' Reflection and Attributes example II
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Public Class Class1
    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Property Or _
      AttributeTargets.Class Or AttributeTargets.Field, AllowMultiple:=True)> Public Class ModifiedAttribute
        Inherits System.Attribute
        Public Author As String
        Public ModDate As String
        Public Sub New(ByVal SetAuthor As String, ByVal SetModDate As String)
            MyBase.New()
            Author = SetAuthor
            ModDate = SetModDate
        End Sub
        Public Overrides Function ToString() As String
            Return ("Modified by " + Author + " on " + ModDate)
        End Function
        Public SomeIntValue As Integer
    End Class

    <Modified("Dan", "1/10/2001")> Public Class TestClass
        <Modified("Dan", "1/13/2001"), Modified("Joe", "1/25/2001", SomeIntValue:=5)> Public X As Integer
        Private Y As Integer
    End Class

    Public Enum TestEnum
        FirstMember = 1
        SecondMember = 2
    End Enum
End Class

