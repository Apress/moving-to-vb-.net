' AssemblyScoping solution - Assembly3
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Namespace MovingToVB.Ch10.Scoping
    Public Class Class4

        ' After setting a reference to Assembly1, the following works
        Dim c1 As Scoping.Class1

        Sub TestSub()
            ' Even though namespace is the same, only public methods in
            ' public modules (or classes) can be used
            MovingToVB.Ch10.Scoping.PublicSubInPublicModule()
        End Sub


    End Class

End Namespace
