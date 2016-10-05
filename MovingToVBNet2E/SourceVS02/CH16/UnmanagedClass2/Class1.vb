Imports System.Security.Permissions
Imports System.Security.Principal
Imports System.Security

Public Class Class1
    Private Declare Auto Function GetTickCount Lib "kernel32" () As Integer

    <SecurityPermission(SecurityAction.Assert, Flags:=SecurityPermissionFlag.UnmanagedCode)> Private Function GetTickCountSpecial() As Integer
        Return GetTickCount()
    End Function

    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> Public Function Ticks() As Integer
        Return GetTickCount()
    End Function

    Public Function Ticks2() As TimeSpan
        Dim x As Integer
        Dim l As Long
        Dim t As New DateTime()
        Dim ts As TimeSpan

        Dim sec As New SecurityPermission(SecurityPermissionFlag.UnmanagedCode)

        sec.Assert()

        t = DateTime.Now
        For x = 0 To 50000
            l += Ticks()
        Next
        ts = DateTime.Now.Subtract(t)
        CodeAccessPermission.RevertAssert()

        Try
            Ticks()
        Catch e As Security.SecurityException
            MsgBox("Caught the security exception after revert!", MsgBoxStyle.OKOnly, "Security violation")
        End Try
        Return ts
    End Function

    Public Function Ticks3() As TimeSpan
        Dim x As Integer
        Dim l As Long
        Dim t As New DateTime()
        Dim ts As TimeSpan

        ' Only allow administrators to override here - not really needed in this
        ' example, as you can read in the text
        Dim sec2 As New SecurityPermission(SecurityPermissionFlag.ControlPrincipal)
        sec2.Assert()
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
        Dim roleSec As New PrincipalPermission(Nothing, "BUILTIN\Administrators")
        roleSec.Demand()

        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal)
        CodeAccessPermission.RevertAssert()

        t = DateTime.Now
        For x = 0 To 50000
            l += GetTickCountSpecial()
        Next
        ts = DateTime.Now.Subtract(t)

        Try
            GetTickCountSpecial()
        Catch e As Security.SecurityException
            MsgBox("Caught the security exception after revert!", MsgBoxStyle.OKOnly, "Security violiaton")
        End Try
        Return ts
    End Function


    Public Function Ticks4() As TimeSpan
        Dim x As Integer
        Dim l As Long
        Dim t As New DateTime()
        Dim ts As TimeSpan

        t = DateTime.Now
        For x = 0 To 50000
            l += Ticks()
        Next
        ts = DateTime.Now.Subtract(t)

        Ticks()
        Return ts
    End Function



End Class

