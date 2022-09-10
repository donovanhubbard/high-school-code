using System;

namespace Example_3_5
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
			double hotC, coldC;
			double hotF, coldF;
			Console.Write("Enter a hot temperature in Celsius: ");
			String input = Console.ReadLine();
			hotC = double.Parse(input);
			hotF = 9.0 * hotC / 5.0 + 32.0;
			Console.WriteLine("The Fahrenheit temperature is {0:F1}", hotF);
			Console.Write("Enter a cold temperature in Celsius: ");
			input = Console.ReadLine();
			coldC = double.Parse(input);
			coldF = 9.0 * coldC / 5.0 + 32.0;
			Console.WriteLine("The Fahrenheit temperature is {0:F1}", coldF);
		}
	}
}
