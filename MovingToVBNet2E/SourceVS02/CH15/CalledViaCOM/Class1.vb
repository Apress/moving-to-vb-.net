Imports System.Runtime.InteropServices
<InterfaceType(ComInterfaceType.InterfaceIsDual)> Public Interface _CallFromCOM
    Function TimesTwo(ByVal i As Integer) As Integer
    Function TimesThree(ByVal i As Integer) As Integer
    Function TimesFour(ByVal i As Integer) As Integer
End Interface

<ClassInterface(ClassInterfaceType.None)> Public Class CallFromCOM
    Implements _CallFromCOM

    Public Function TimesTwo(ByVal i As Integer) As Integer Implements _CallFromCOM.TimesTwo
        Return i * 2
    End Function

    Public Function TimesThree(ByVal i As Integer) As Integer Implements _CallFromCOM.TimesThree
        Return i * 3
    End Function

    Public Function TimesFour(ByVal i As Integer) As Integer Implements _CallFromCOM.TimesFour
        Return i * 4
    End Function

    <ComRegisterFunction()> Public Shared Sub OnRegistration(ByVal T As Type)
        Trace.WriteLine("I'm being registered!!! :" & T.FullName)
    End Sub
End Class

<ClassInterface(ClassInterfaceType.AutoDispatch)> Public Class CallFromCOMDispatch

    Public Function TimesTwo(ByVal i As Integer) As Integer
        Return i * 2
    End Function

    Public Function TimesThree(ByVal i As Integer) As Integer
        Return i * 3
    End Function

    Public Function TimesFour(ByVal i As Integer) As Integer
        Return i * 4
    End Function

End Class

<ClassInterface(ClassInterfaceType.AutoDual)> Public Class CallFromCOMDual

    Public Function TimesTwo(ByVal i As Integer) As Integer
        Return i * 2
    End Function

    Public Function TimesThree(ByVal i As Integer) As Integer
        Return i * 3
    End Function

    Public Function TimesFour(ByVal i As Integer) As Integer
        Return i * 4
    End Function

End Class

