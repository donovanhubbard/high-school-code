using System;

namespace Example_2_7
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
			int number1 = 35;
			int number2 = number1 +number1;
			Console.WriteLine("The number is {0} and twice it is {1}.", number1, number2);

			Console.WriteLine("{0} is the number and {1} is its double.", number1, number2);

			Console.WriteLine("Twice the number is {1} and the number is {0}.", number1,number2);

			Console.WriteLine("The first is {0:C} and twice it is  {1:C}.", number1, number2);


		}
	}
}
