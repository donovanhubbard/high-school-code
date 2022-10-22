using System;

namespace Example_3_7_3_8
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		
		public static double UpdateMax(double newPrice, double maxSoFar)
		{
			if (newPrice > maxSoFar)
				return newPrice;
			else
				return maxSoFar;
		}

		public static double GetDouble(String prompt)
		{
			Console.Write(prompt);
			return double.Parse(Console.ReadLine());
		}

		[STAThread]
		static void Main(string[] args)
		{
			double maxSoFar = 0;
			double price = GetDouble("Enter the first price, -1 to quit: ");
			while (price >= 0) 
			{
				maxSoFar = UpdateMax(price, maxSoFar);
				price = GetDouble("Enter the next price, -1 to quit: ");
			}

			Console.WriteLine("The maximum is {0}", maxSoFar);

		}
	}
}
