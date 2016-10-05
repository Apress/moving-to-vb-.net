' AssemblyScoping solution - ConsoleApplication1
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Imports MovingToVB.Ch10
Module Module1

    Sub Main()
        Dim c1 As New MovingToVB.Ch10.Scoping.Class1()
        Dim c2 As New Scoping.Class2()
        Dim c3 As New Scoping.NextLevel.Class3()
        Dim c4 As New Scoping.Class4()

        ' Can't create Scoping.PrivateClass or Scoping.FriendClass

        ' Example of shared variables
        Dim sh As New Scoping.SharingDemo()
        Dim sh2 As New Scoping.SharingDemo()
        sh.SharedVariable = 5
        Console.WriteLine("5 indicates value was shared: " & sh2.SharedVariable.ToString)
        c1.Test()
        Dim sit As New Scoping.SharedInheritedTest()
        sit.Test()
        Console.WriteLine("Access without instance: " & Scoping.SharingDemo.SharedVariable.ToString)
        Scoping.SharingDemo.ShowShared()
        console.ReadLine()


    End Sub

End Module

