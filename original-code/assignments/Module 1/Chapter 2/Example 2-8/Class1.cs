using System;

namespace Example_2_8
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
			Console.WriteLine("{0,-10}{1,10}", "Names", "Numbers");
			Console.WriteLine("{0,-10}{1,10}", "Sheila", 12345);
			Console.WriteLine("{0,-10}{1,10}", "Frances", 241);
			Console.WriteLine("{0,-10}{1,10}", "Michael", 4141);
		}
	}
}
