' No memory leak demonstrated
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Public Class TestClassObject
    Shared m_classcount As Integer
    Dim m_ClassId As Integer
    Dim m_Collection As Collection
    Public Sub New(ByVal mycontainer As Collection)
        MyBase.New()
        mycontainer.Add(Me)
        m_Collection = mycontainer
        m_ClassId = m_classcount
        m_classcount = m_classcount + 1
    End Sub


    Protected Overrides Sub Finalize()
        System.Diagnostics.Debug.WriteLine("Destructed " & m_ClassId.ToString())
    End Sub

End Class
