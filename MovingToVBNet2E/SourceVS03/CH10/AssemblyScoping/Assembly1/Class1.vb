' AssemblyScoping solution - Assembly1
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Public Module PublicModule
    Public Const PublicModuleConstant As Integer = 5
    Public Sub PublicSubInPublicModule()

    End Sub
    Friend Sub FriendSubInPublicModule()

    End Sub
    Private Sub PrivateSubInPublicModule()

    End Sub
End Module

Friend Module FriendModule
    Public Sub PublicSubInFriendModule()

    End Sub
    Friend Sub FriendSubInFriendModule()

    End Sub
    Private Sub PrivateSubInFriendModule()

    End Sub
End Module


Public Structure mystruct
    Public x As Integer
    Friend y As Integer
    Private z As Integer
End Structure

Public Enum x
    a = 1
End Enum


Friend Class FriendClass

End Class


Public Class SharingDemo
    Public Shared SharedVariable As Integer
    Public NotSharedVariable As Integer
    Shared Sub ShowShared()
        Console.WriteLine("Access using Shared Procedure: " & SharedVariable.ToString)
    End Sub
End Class


Public Class Class1
    Dim fc As FriendClass
    Dim pmc As Integer = PublicModuleConstant


    Public Sub Test()
        Dim sh As SharingDemo
        Console.WriteLine("5 indicates sharing across assemblies: " & sh.SharedVariable.ToString)

    End Sub

End Class
