' Resurrection example
' Copyright © 2001-2003 by Desaware Inc. All Rights Reserved
Public Class Resurrected

    Public mycontainer As Form1

    Public Sub AreYouThere()
        MsgBox("I am here")
    End Sub

    Protected Overrides Sub Finalize()
        MsgBox("I'm being finalized")
        mycontainer.PriorObject = Me
    End Sub

End Class

