' Event example program
' Copyright ©2001-2003 by Desaware Inc All Rights Reserved
Public Class EventClass
    Public Event FirstEvent(ByVal myData As Integer)

    Public Event SecondEvent(ByVal Sender As Object, ByVal myData As Integer)

    Public Sub Test1()
        RaiseEvent FirstEvent(5)
    End Sub

    Public Sub Test2()
        RaiseEvent SecondEvent(Me, 5)
    End Sub

End Class

Public Delegate Sub EventTemplate(ByVal Obj As Object, ByVal i As Integer)

Public Class DerivedEventClass
    Inherits EventClass
    Shared Event ASharedEvent()

    ' Note alternate form of declaration - These are identical
    'Event DerivedEvent(ByVal obj As Object, ByVal i As Integer)
    Event DerivedEvent As EventTemplate

    Private Shadows Event FirstEvent(ByVal Mydata As Integer)

    Public Sub InternalHandler(ByVal obj As Object, ByVal i As Integer) Handles MyBase.SecondEvent
        RaiseEvent DerivedEvent(Me, i * 2)
    End Sub

    Public Shadows Sub Test2()
        MyBase.Test2()
        RaiseEvent ASharedEvent()
    End Sub


    Public SpecialEventHandler As EventTemplate

    Public Sub TestSpecialEvents()
        SpecialEventHandler.Invoke(Me, 6)
    End Sub

End Class
