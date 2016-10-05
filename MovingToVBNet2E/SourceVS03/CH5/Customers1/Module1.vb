' Customers sample application
' Copyright ©2001-2003 by Desaware inc. All Rights Reserved
Module Module1

    Sub Main()
        Dim store As New Commercial()
        store.Name = "Worst buys"
        store.DisplayName()
        store.DisplayTerms()
        console.Write("Press enter to continue:")
        console.ReadLine()
        Dim Person As New Individual()
        Person.Name = "Jim Smith"
        Person.DisplayName()
        Person.DisplayTerms()
        console.Write("Press enter to continue:")
        console.ReadLine()
        Dim USA As New Government()
        USA.Name = "U.S.A."
        USA.DisplayName()
        USA.DisplayTerms()
        USA.BranchInfo()
        console.Write("Press enter to continue:")
        console.ReadLine()
        Dim BaseObject As Customer
        BaseObject = USA
        BaseObject.DisplayName()
        BaseObject.DisplayTerms()
        ' BaseObject.BranchInfo()
        console.ReadLine()

    End Sub

End Module
