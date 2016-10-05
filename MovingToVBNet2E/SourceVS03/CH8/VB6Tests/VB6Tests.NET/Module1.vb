Option Strict Off
Option Explicit On
Module Module1
	
	
	Sub Evil()
		System.Diagnostics.Debug.WriteLine(15 + CDbl("15") + CDbl("15"))
		
	End Sub
	
	
	'UPGRADE_WARNING: Application will terminate when Sub Main() finishes. Click for more: ms-help://MS.MSDNVS/vbcon/html/vbup1047.htm
	Public Sub Main()
		'UPGRADE_WARNING: Lower bound of array A was changed from 2 to 0. Click for more: ms-help://MS.MSDNVS/vbcon/html/vbup1033.htm
		Dim A(5) As Short
		A(2) = 5
		
		Evil()
		
		
	End Sub
End Module