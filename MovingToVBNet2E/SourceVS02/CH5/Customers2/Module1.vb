' Fragile Class Demo #1
' Copyright ©2001 by Desaware Inc. All Rights Reserved

' Add reference to the ClassLibrary2 DLL !!!!

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

    End Sub


End Module
