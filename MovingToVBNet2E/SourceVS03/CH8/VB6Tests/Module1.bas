Attribute VB_Name = "Module1"
Option Explicit


Sub Evil()
    Debug.Print 15 + "15" + "15"
    
End Sub


Sub Main()
    Dim A(2 to 5) As Integer
    A(2) = 5

    Evil
    

End Sub
