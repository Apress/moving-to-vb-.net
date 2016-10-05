namespace ScopingCSharp
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
			short counter;
			//short x;
			//x = 50;  // Variable not defined at this point
			for(counter = 1;counter<=3;counter++) 
			{
				if (true) 
				{
					short x=0;	// C# requires initialization
					Console.WriteLine(x);	
					x= counter;
				}
			}
			//Console.WriteLine("Outside of block: " + x.ToString());
			Console.ReadLine();
		}
	}
}
