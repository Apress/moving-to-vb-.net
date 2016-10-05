// CSharp Or VB example
// Copyright ©2001 by Desaware Inc.
using Microsoft.VisualBasic;
namespace CSharpOrVB
{
	using System;

	/// <summary>
	///		Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			String s = "This is a test";
			Console.WriteLine(Strings.Mid(s, 6, 4));
			Console.ReadLine();

		}
	}
}
