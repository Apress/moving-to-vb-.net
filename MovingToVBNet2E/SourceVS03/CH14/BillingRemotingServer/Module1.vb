' Remoting Example
' Copyright ©2003 by Desaware Inc.
Imports System.Runtime.Remoting

Public Class RemoteBillingObject
    Inherits MarshalByRefObject

    Dim BillInfo As MovingToVBNet.Billing.BillingComponent

    Public Sub AddBillingRecord(ByVal Name As String, ByVal hours As Double, ByVal Description As String)
        BillInfo = New MovingToVBNet.Billing.BillingComponent()
        BillInfo.AddRecord(Name, hours, Description)
        BillInfo.Dispose()
    End Sub

    Public Function GetBillingInfo() As DataSet
        BillInfo = New MovingToVBNet.Billing.BillingComponent()
        Return (BillInfo.Info)
    End Function

End Class

Module Module1

    Sub Main()
        Dim LoadingDirectory As String
        ' Config file for this example is in the parent above the bin directory
        ' That's because we aren't including bin directories in the install
        ' In practice you can put it in the exe directory
        LoadingDirectory = AppDomain.CurrentDomain.BaseDirectory
        LoadingDirectory = LoadingDirectory.Remove(Len(LoadingDirectory) - 1, 1)
        LoadingDirectory = IO.Directory.GetParent(LoadingDirectory).ToString
        Console.WriteLine("Loading remoting configuration file: " & LoadingDirectory & "\BillingRemotingServer.config")
        RemotingConfiguration.Configure(LoadingDirectory & "\BillingRemotingServer.config")
        Console.WriteLine("Press any key to close the server")
        Console.ReadLine()
    End Sub

End Module
