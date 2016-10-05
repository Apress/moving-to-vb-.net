' Undead1 sample program
' Copyright © 2001 by Desaware Inc.

Public Class Undying

    Protected Overrides Sub Finalize()
        Debug.WriteLine("I have been finalized")
    End Sub

End Class

