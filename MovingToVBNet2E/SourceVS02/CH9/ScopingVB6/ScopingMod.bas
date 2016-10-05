Attribute VB_Name = "ScopingMod"
Option Explicit

Sub Main()
   Dim Counter As Integer
   ' X = 3  ' Variable not defined at this point
   For Counter = 1 To 3
      If True Then   ' Always enter this block
         Dim X As Integer
         Debug.Print X
         X = Counter
      End If
   Next Counter
   Debug.Print "Outside of block: " & X
End Sub
