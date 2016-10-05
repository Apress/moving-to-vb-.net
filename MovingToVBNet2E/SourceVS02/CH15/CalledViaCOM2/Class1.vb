Imports System.Runtime.InteropServices
<Guid("fda97dca-bb0b-4987-961b-8383741cfa8f")> Public Interface _CallFromCOM2
    <DispId(1)> Function TimesTwo(ByVal i As Integer) As Integer
    <DispId(2)> Function TimesThree(ByVal i As Integer) As Integer
    <DispId(3)> Function TimesFour(ByVal i As Integer) As Integer
    <DispId(4)> Function BadWay(ByVal i As Integer) As Object
End Interface

<Guid("72d7e45a-3b76-4a12-bb7e-c096cd97709a"), ClassInterface(ClassInterfaceType.None)> Public Class CallFromCOM2
    Implements _CallFromCOM2



    <DispId(1)> Public Function TimesTwo(ByVal i As Integer) As Integer Implements _CallFromCOM2.TimesTwo
        Return i * 2
    End Function

    <DispId(2)> Public Function TimesThree(ByVal i As Integer) As Integer Implements _CallFromCOM2.TimesThree
        Return i * 3
    End Function

    <DispId(3)> Public Function TimesFour(ByVal i As Integer) As Integer Implements _CallFromCOM2.TimesFour
        Return i * 4
    End Function

    <DispId(4)> Public Function BadWay(ByVal i As Integer) As Object Implements _CallFromCOM2.BadWay
        Return i * 2
    End Function

    <ComRegisterFunction()> Public Shared Sub OnRegistration(ByVal T As Type)
        Trace.WriteLine("I'm being registered!!! :" & T.FullName)
    End Sub

End Class


<ClassInterface(ClassInterfaceType.AutoDual), Guid("2474B444-A15A-4fb8-A8E2-7578A442FD77")> Public Class CallFromCOM2Dual

    <DispId(1)> Public Function TimesTwo(ByVal i As Integer) As Integer
        Return i * 2
    End Function


    'Uncomment this after rebuild to see error
    '<DispId(5)> Public Function x(ByVal i As Integer) As Integer
    '    Return i * 10
    'End Function

    <DispId(2)> Public Function TimesThree(ByVal i As Integer) As Integer
        Return i * 3
    End Function

    <DispId(3)> Public Function TimesFour(ByVal i As Integer) As Integer
        Return i * 4
    End Function


End Class
