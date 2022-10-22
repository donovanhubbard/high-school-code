using System;

namespace Example_2_14
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		public static void PrintBlurb() 
		{
			Console.WriteLine("This method has no arguments, " + "and it has no return value.");
		}
		
		[STAThread]
		static void Main(string[] args)
		{
			PrintBlurb();
		}
	}
}
