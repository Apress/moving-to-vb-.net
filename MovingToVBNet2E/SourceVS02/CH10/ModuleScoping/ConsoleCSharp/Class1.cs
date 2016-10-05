// Acessing modules from C#
//Copyright ©2001 by Desaware Inc. All Rights Reserved
namespace ConsoleCSharp
{
	using System;
	using MovingToVB.CH10.ModuleScoping;

	/// <summary>
	///		Summary description for Class1.
	/// </summary>
	class Class1
	{
		static void Main(string[] args)
		{
			MovingToVB.CH10.ModuleScoping.Class1 c;
			MovingToVB.CH10.ModuleScoping.Module1.PublicMethod();
			Module1.PublicMethod();
			c = new MovingToVB.CH10.ModuleScoping.Class1();
			c.PublicMethod(); 
			Console.ReadLine(); 
		}
	}
}
