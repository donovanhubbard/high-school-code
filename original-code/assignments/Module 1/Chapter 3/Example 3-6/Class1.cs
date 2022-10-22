using System;

namespace Example_3_6
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		public static int GetScore(String prompt)
		{
			Console.Write(prompt);
			return int.Parse(Console.ReadLine());
		}

		public static int UpdateTotal(int newValue, int subTotal)
		{
			subTotal += newValue;
			return subTotal;
		}


		[STAThread]
		static void Main(string[] args)
		{
			int total = 0;
			int score = GetScore("Enter the first score, -1 to quit: ");
			while (score >= 0)
			{
				total = UpdateTotal( score, total);
				score = GetScore("Enter the next score, -1 to quit: ");
			}
			Console.WriteLine("The total is {0}", total);
		}
	}
}
