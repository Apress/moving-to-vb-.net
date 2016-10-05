' Fragile Class Demo #1
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

' Add reference to the ClassLibrary3 DLL !!!!

' Fragile Class Demo 
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

' Add reference to the ClassLibrary3 DLL !!!!
Module Module1

    Sub Main()

        Dim store As New Commercial
        store.Name = "Worst buys"
        store.DisplayName()
        store.DisplayTerms()
        Console.Write("Press enter to continue:")
        Console.ReadLine()
        Dim Person As New Individual
        Person.Name = "Jim Smith"
        Person.DisplayName()
        Person.DisplayTerms()
        Console.Write("Press enter to continue:")
        Console.ReadLine()
        Dim USA As New Government
        USA.Name = "U.S.A."
        USA.DisplayName()
        USA.DisplayTerms()
        USA.BranchInfo()
        Console.Write("Press enter to continue:")
        Console.ReadLine()

    End Sub


End Module
