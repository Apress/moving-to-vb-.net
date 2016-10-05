' Initialization and Destruction example
' Copyright ©2001-2003 by Desaware Inc.

Public Class Class1
    Implements IDisposable
    Shared Sub New()
        MsgBox("Shared class initializer called")
    End Sub
    Protected Overrides Sub Finalize()
        MsgBox("My component finalizer called")
    End Sub

    Public Overridable Overloads Sub Dispose() Implements IDisposable.Dispose
        MsgBox("I've been disposed")
        ' Try with and without this line
        GC.SuppressFinalize(Me)
    End Sub

End Class

Public Class Class2
    Implements IDisposable
    Private m_Disposed As Boolean

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    ' Derived class can override this, but should always call MyBase.Dispose(disposing)
    ' when done with type specific cleanup
    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If m_Disposed Then Exit Sub ' Or raise an error

        If disposing Then
            ' Ok to Dispose contained objects
            ' Ok to raise events
            GC.SuppressFinalize(Me)
        Else
            ' Finalization here should not reference any other
            ' objects. If you have any unmanaged resources (API handles)
            ' they can be freed
        End If
        m_Disposed = True
        MsgBox("Dispose(" & disposing.ToString & ") called")
    End Sub

    ' Derived class does not implement Dispose
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub

End Class
