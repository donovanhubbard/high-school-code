using System;

namespace Example_2_4
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
			const int BIG = int.MaxValue - 10;
			int number1 = BIG;
			int number2 = number1 + number1;
			Console.WriteLine("Twice the large number is " + number2);
		}
	}
}
