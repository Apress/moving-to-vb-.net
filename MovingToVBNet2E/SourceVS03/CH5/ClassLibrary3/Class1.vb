' ClassLibrary3 example (chapter 5)
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Namespace MigratingBook.Chapter5.ClassLibrary3
    Public MustInherit Class Customer
        Public Name As String
        Public MustOverride Function DefaultNet() As Integer
        Public Overridable Function DisplayTerms() As String
            DisplayName()
            Console.WriteLine("... is net " + CStr(DefaultNet()))
            Console.Write(" Branch is: ")
            BranchInfo()
        End Function
        Sub DisplayName()
            Console.WriteLine("Customer is " + Name)
        End Sub
        Public Overridable Sub BranchInfo()
            Console.WriteLine("New Branchinfo Function")
        End Sub
    End Class
End Namespace
