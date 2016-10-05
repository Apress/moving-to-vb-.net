Attribute VB_Name = "modMath"
Option Explicit

Sub Main()
   Randomize
   Debug.Print Rnd()
   Debug.Print Sqr(4)
   Debug.Print Round(1.4), Round(1.6)
   Debug.Print Sgn(-1), Sgn(0), Sgn(1)
   Debug.Print Atn(0)
End Sub
