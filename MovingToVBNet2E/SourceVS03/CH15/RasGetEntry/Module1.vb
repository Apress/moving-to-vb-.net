' RasGetEntry example
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Imports System.Runtime.InteropServices

Module Module1

    Const PhoneBookEntryToGet As String = "Your Phonebook Entry"

    Public Declare Auto Function RasGetEntryProperties Lib "rasapi32.dll" (ByVal _
    lpszPhoneBook As String, ByVal lpszEntry As String, ByRef lpRasEntry As RASENTRY, ByRef lpdwEntryInfoSize As Integer, _
    ByVal devinfo As Integer, ByVal devinfosize As Integer) As Integer

    Public Declare Auto Function RasGetEntryProperties2 Lib "rasapi32.dll" Alias "RasGetEntryProperties" (ByVal _
    lpszPhoneBook As String, ByVal lpszEntry As String, ByVal lpRasEntry As IntPtr, ByRef lpdwEntryInfoSize As Integer, _
    ByVal devinfo As Integer, ByVal devinfosize As Integer) As Integer

    <StructLayout(LayoutKind.Sequential, Pack:=4, CharSet:=charset.Auto)> Structure RASENTRY
        Public dwSize As Integer
        Public dwfOptions As Integer
        Public dwCountryID As Integer
        Public dwCountryCode As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=11)> Public szAreayCode As String     '11 chars
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=129)> Public szLocalPhoneNumber As String
        Public dwAlternateOffset As Integer
        Public ipaddr As Integer
        Public ipaddrDns As Integer
        Public ipaddrDnsAlt As Integer
        Public ipaddrWins As Integer
        Public ipaddrWinsAlt As Integer

        Public dwFrameSize As Integer
        Public dwfNetProtocols As Integer
        Public dwFramingProtocol As Integer

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szScript As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szAutodialDll As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szAutodialFunc As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=17)> Public szDeviceType As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=129)> Public szDeviceName As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=33)> Public szX25PadType As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=201)> Public szX25Address As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=201)> Public szFacilities As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=201)> Public szUserData As String
        Public dwChannels As Integer

        Public dwReserved1 As Integer
        Public dwReserved2 As Integer
    End Structure


    Sub Main()
        Dim res As Integer
        Dim re As RASENTRY
        Dim bufsize As Integer
        re.dwSize = Marshal.SizeOf(re)
        bufsize = re.dwSize
        res = RasGetEntryProperties(Nothing, PhoneBookEntryToGet, re, bufsize, 0, 0)
        If res = 623 Then
            Console.WriteLine("Can't find specified dial-up entry")
        End If
        If res = 603 Then
            Dim iptr As IntPtr
            iptr = Marshal.AllocHGlobal(bufsize)
            Marshal.StructureToPtr(re, iptr, False)
            res = RasGetEntryProperties2(Nothing, PhoneBookEntryToGet, iptr, bufsize, 0, 0)
            re = CType(Marshal.PtrToStructure(iptr, GetType(RASENTRY)), RASENTRY)
            Marshal.FreeHGlobal(iptr)
        End If
        Console.WriteLine(re.szLocalPhoneNumber)
        Console.ReadLine()
    End Sub

End Module
