' AssemblyScoping solution - Assembly1
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Public Class Class1B
    ' Can't see Private class in this file
    Dim c1 As MovingToVB.Ch10.Scoping.FriendClass
    Dim c2 As MovingToVB.Ch10.Scoping.Class1

    Sub AMethod()
        FriendSubInFriendModule()
        FriendSubInPublicModule()
        PublicSubInPublicModule()
        PublicSubInFriendModule()
    End Sub

End Class
