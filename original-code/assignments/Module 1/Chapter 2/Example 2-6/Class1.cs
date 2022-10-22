using System;

namespace Example_2_6
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
			Console.Write("Enter an integer: ");
			int number1 = int.Parse(Console.ReadLine());

			int number2 = number1 + number1;
			Console.WriteLine("    Twice the number is {0}", number2);

		}
	}
}
