' AssemblyScoping solution - Assembly2
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Public Class SharedInheritedTest
    Inherits Scoping.SharingDemo
    Public Sub Test()
        console.WriteLine("5 indicates sharing when derived: " & Me.SharedVariable.ToString)
    End Sub
End Class

Public Class Class2

End Class

Namespace NextLevel
    Public Class Class3

    End Class
End Namespace