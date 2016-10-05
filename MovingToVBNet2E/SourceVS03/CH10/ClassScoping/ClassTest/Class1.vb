' Class scoping test program
' Copyright ©2001-2003 by Desaware Inc.  All Rights Reserved

Public Class PublicClass
    Public Sub PCPublic()

    End Sub
    Friend Sub PCFriend()

    End Sub
    Protected Sub PCProtected()

    End Sub
    Protected Friend Sub PCProtectedFriend()

    End Sub
    Private Sub PCPrivate()

    End Sub
End Class

Friend Class FriendClass
    Public Sub FCPublic()

    End Sub
    Friend Sub FCFriend()

    End Sub
    Protected Sub FCProtected()

    End Sub
    Protected Friend Sub FCProtectedFriend()

    End Sub
    Private Sub FCPrivate()

    End Sub
End Class


Public Class PubIPub
    Inherits PublicClass
    Public Sub Test()
        Dim c As PublicClass

    End Sub
End Class

Friend Class FriendIPub
    Inherits PublicClass
End Class

Friend Class FriendIFriend
    Inherits FriendClass
    Sub Test()
        Dim f As FriendClass

    End Sub
End Class


Public Class Class1
    Dim p As New PubIPub()

    Public Sub Test()
        Dim p2 As PublicClass
        p2 = New PubIPub()
    End Sub
End Class
