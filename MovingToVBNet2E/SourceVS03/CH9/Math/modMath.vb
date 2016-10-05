Option Strict Off
Option Explicit On
Module modMath
	
	Public Sub Main()
		Randomize()
        Console.WriteLine(Rnd())
        Console.WriteLine(System.Math.Sqrt(4))
        Console.WriteLine(VB6.TabLayout(System.Math.Round(1.4), System.Math.Round(1.6)))
        Console.WriteLine(VB6.TabLayout(System.Math.Sign(-1), System.Math.Sign(0), System.Math.Sign(1)))
        Console.WriteLine(System.Math.Atan(0))
        Console.ReadLine()
	End Sub
End Module