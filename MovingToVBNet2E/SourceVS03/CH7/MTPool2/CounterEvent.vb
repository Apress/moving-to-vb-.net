' Thread Pool Implementation #2
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Imports System.Threading
Public Class CounterEvent
    Inherits WaitHandle
    Private InternalEvent As New ManualResetEvent(True)
    Private m_Counter As Integer

    Public Sub New()
        MyBase.New()
        MyBase.Handle = InternalEvent.Handle
    End Sub

    Public Sub AddOne()
        SyncLock InternalEvent
            m_Counter += 1
            If m_Counter = 0 Then
                InternalEvent.Set()
            Else
                InternalEvent.Reset()
            End If
        End SyncLock
    End Sub

    Public Sub SubtractOne()
        SyncLock InternalEvent
            m_Counter -= 1
            If m_Counter = 0 Then
                InternalEvent.Set()
            Else
                InternalEvent.Reset()
            End If
        End SyncLock
    End Sub

End Class
