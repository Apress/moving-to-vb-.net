' Example of resolving interface name conflicts
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Interface MyFirstInterface
    Sub UniqueFunction()
    Sub CommonFunction()
End Interface

Interface MySecondInterface
    Sub SecondUniqueFunction()
    Sub CommonFunction()
End Interface

Public Class Class1
    Implements MyFirstInterface
    Implements MySecondInterface

    Sub UniqueFunction() Implements MyFirstInterface.UniqueFunction

    End Sub

    Sub SecondUniqueFunction() Implements MySecondInterface.SecondUniqueFunction

    End Sub

    ' These could be made private to avoid confusion
    Sub CommonFunction() Implements MyFirstInterface.CommonFunction
        Console.WriteLine("Common Function on first interface")
    End Sub

    Sub CommonFunctionSecondInterface() Implements MySecondInterface.CommonFunction
        Console.WriteLine("Common function on second interface")
    End Sub

End Class
