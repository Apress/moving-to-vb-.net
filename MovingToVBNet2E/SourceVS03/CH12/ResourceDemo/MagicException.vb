' ResourceDemo example 
' Copyright ©2003 by Desaware Inc.

<Serializable()> Public Class MagicException
    Inherits ApplicationException

    ' The constructors just call the base constructors
    Public Sub New(ByVal ErrorString As String)
        MyBase.New(ErrorString)
    End Sub

    Public Sub New(ByVal ErrorString As String, ByVal InnerException As Exception)
        MyBase.New(ErrorString, InnerException)
    End Sub

    ' The message gets the localized string if available
    Public Overrides ReadOnly Property Message() As String
        Get
            Dim trystring As String
            Dim rm As New Resources.ResourceManager("ResourceDemo.OtherResources", Me.GetType.Assembly)
            Try
                trystring = rm.GetString(MyBase.Message)
            Catch
            End Try
            If trystring <> "" Then Return (trystring)
            Return MyBase.Message
        End Get
    End Property
End Class
