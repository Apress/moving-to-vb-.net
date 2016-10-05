' RasEntries example
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Imports System.Runtime.InteropServices
Module Module1
    ' szEntryName is 256 characters, or a 257 character buffer
    <StructLayout(LayoutKind.Sequential, Pack:=4, CharSet:=Charset.Auto)> Structure RASENTRYNAME
        Public dwSize As Integer
        <MarshalAs(UnmanagedType.ByValTStr, sizeConst:=257)> Public szEntryName As String
        Public Sub Init()
            dwSize = Marshal.SizeOf(Me)
        End Sub
    End Structure

    Public Declare Auto Function RasEnumEntries Lib "rasapi32.dll" (ByVal reserved As Integer, _
        ByVal lpszPhoneBook As String, ByVal rasentries As IntPtr, ByRef lpcb As Integer, _
        ByRef lpcEntries As Integer) As Integer

    Sub Main()
        Dim res As Integer
        Dim cb, cbentries As Integer
        Dim idx As Integer
        Dim iptr As IntPtr
        Dim SizePerStruct As Integer
        SizePerStruct = Marshal.SizeOf(GetType(RASENTRYNAME))   ' Get size needed for each structure
        iptr = Marshal.AllocHGlobal(SizePerStruct)
        Dim rasentries(0) As RASENTRYNAME
        rasentries(0).Init()
        cb = rasentries(0).dwSize
        cbentries = 1
        Marshal.StructureToPtr(rasentries(0), iptr, False)

        ' First time through get the count
        res = RasEnumEntries(0, Nothing, iptr, cb, cbentries)

        rasentries(0) = CType(Marshal.PtrToStructure(iptr, GetType(RASENTRYNAME)), RASENTRYNAME)

        If res = 603 Then
            ReDim rasentries(cbentries - 1)
            cb = 0
            Marshal.FreeHGlobal(iptr)
            iptr = Marshal.AllocHGlobal(cbentries * SizePerStruct)

            For idx = 0 To cbentries - 1
                rasentries(idx).Init()
                Marshal.StructureToPtr(rasentries(idx), New IntPtr(iptr.ToInt32 + cb), False)
                cb = cb + rasentries(idx).dwSize
            Next
            res = RasEnumEntries(0, Nothing, iptr, cb, cbentries)
        End If

        If res = 0 Then
            cb = 0
            For idx = 0 To cbentries - 1
                rasentries(idx) = CType(Marshal.PtrToStructure(New IntPtr(iptr.ToInt32 + cb), GetType(RASENTRYNAME)), RASENTRYNAME)
                cb = cb + rasentries(idx).dwSize
                Console.WriteLine(rasentries(idx).szEntryName)
            Next
        End If
        Marshal.FreeHGlobal(iptr)

        Console.ReadLine()
    End Sub

End Module
