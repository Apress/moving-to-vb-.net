' LinkList .Net example using inheritance
' Copyright © 2001-2003 by Desaware Inc. All Rights Reserved
Public Class Customer
    Inherits LinkList

    Public CustomerName As String

    Public Sub New()
        MyBase.New()
        Me.Container = Me
    End Sub

    Protected Overrides Sub Finalize()
        system.diagnostics.Debug.WriteLine("Terminating customer " + CustomerName)
    End Sub
    ' There is no need to create a contained "LinkList" object -
    ' The customer object is a LinkList object as well.
    ' There is no need to implement the ILinkList interface, it's
    ' methods and properties are already implemented by the base class.

End Class
