using System;

namespace Example_2_3
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
			int number1 = 25;
			int number2 = 12;
			number2 = number1 + 15;
			System.Console.WriteLine("Number2 is now {0}", number2);

		}
	}
}
