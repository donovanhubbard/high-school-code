using System;

namespace Example_2_5
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Console.Write("Enter your name: ");
			string name = Console.ReadLine();
			Console.WriteLine("    Your name is " + name);
		}
	}
}
