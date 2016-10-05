' Delegates example
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Class CalledClass
    Shared Sub SharedMessage(ByVal s As String)
        Console.WriteLine("Called CalledClass.SharedMessage with parameter: " & s)
    End Sub

    Public Sub WriteMessage(ByVal s As String)
        Console.WriteLine("Called CalledClass WriteMessage method with parameter: " & s)
    End Sub
End Class

Class OtherCalledClass
    Sub WriteMessage(ByVal s As String)
        Console.WriteLine("Called OtherCalledClass WriteMessage method with parameter: " & s)
    End Sub
End Class

Class ObjectWithNoWriteMessage
    Sub BadWriteMessage()

    End Sub
End Class

Delegate Function EnumWindowsCallback(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer

Module StdModule
    Public Declare Ansi Function EnumWindows Lib "User32" (ByVal proc As EnumWindowsCallback, ByVal pval As Integer) As Integer
    Public Declare Ansi Function GetWindowText Lib "User32" Alias "GetWindowTextA" (ByVal hWnd As Integer, ByVal WindowName As String, ByVal BufferLength As Integer) As Integer
    Sub ModuleWriteMessage(ByVal s As String)
        Console.WriteLine("AddresssOf works in standard module too")
    End Sub

    Public Function ShowWindowNamesCallback(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer
        Dim windowname As New String(Chr(32), 255)
        Dim TrimmedName As String
        GetWindowText(hWnd, windowname, 254)
        TrimmedName = Left$(windowname, InStr(windowname, Chr(0)) - 1)
        If TrimmedName <> "" Then Console.WriteLine(TrimmedName)
        Return (1)
    End Function

    Public Sub ShowWindowNames()
        EnumWindows(AddressOf ShowWindowNamesCallback, 0)
    End Sub

    Public Sub LateBoundCaller(ByVal d As [Delegate])
        Dim params() As Object = {"Test"}
        Try
            d.DynamicInvoke(params)
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub


End Module

Class WindowHandles
    Private col As New Collection()
    Public Sub New()
        MyBase.New()
        EnumWindows(AddressOf GetWindowHandlesCallback, 0)
    End Sub

    Private Function GetWindowHandlesCallback(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer
        col.Add(hWnd)
        Return (1)
    End Function

    Public Sub ShowAllWindows()
        Dim hwnd As Integer
        For Each hwnd In col
            Console.Write(Hex$(hwnd))
            Console.Write(", ")
        Next
        Console.WriteLine()
    End Sub


End Class




Delegate Sub DelegateWithStringSignature(ByVal S As String)
Delegate Sub DelegateWithNoParam()


Module Module1


    Sub Main()
        Dim c As New CalledClass()
        Dim o As New OtherCalledClass()
        Dim BadObject As New ObjectWithNoWriteMessage()
        Dim d1 As DelegateWithStringSignature
        Dim obj As Object
        Dim Params() As Object = {"DynamicParam"}

        ' The two following lines are identical
        d1 = New DelegateWithStringSignature(AddressOf c.WriteMessage)
        'd1 = AddressOf c.WriteMessage

        d1.Invoke("Test")
        d1.DynamicInvoke(Params)
        Dim d2 As DelegateWithStringSignature = AddressOf CalledClass.SharedMessage
        Dim d3 As DelegateWithStringSignature = AddressOf o.WriteMessage
        Dim d4 As DelegateWithStringSignature = AddressOf StdModule.ModuleWriteMessage



        d2.Invoke("Test2")
        d3.Invoke("Test3")
        d4.Invoke("Test4")

        Console.WriteLine(ControlChars.CrLf & "Late binding example 1")

        Dim d5 As DelegateWithStringSignature
        d5 = CType(System.Delegate.CreateDelegate(GetType(DelegateWithStringSignature), c, "WriteMessage"), DelegateWithStringSignature)
        d5.Invoke("Test")
        Try
            d5 = CType(System.Delegate.CreateDelegate(GetType(DelegateWithStringSignature), BadObject, "WriteMessage"), DelegateWithStringSignature)
            d5.Invoke("Test")
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Console.WriteLine(ControlChars.CrLf & "Late binding example 2")

        Dim d6 As DelegateWithNoParam = AddressOf BadObject.BadWriteMessage
        LateBoundCaller(CType(d1, System.Delegate))
        LateBoundCaller(CType(d6, System.Delegate))

        Console.WriteLine("Press Enter for next test")
        Console.ReadLine()
        ShowWindowNames()
        Dim w As New WindowHandles()
        w.ShowAllWindows()

        Console.ReadLine()
    End Sub

End Module
