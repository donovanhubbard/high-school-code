using System;

namespace Example_3_2
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
			Console.Write("Enter the number of hours that you worked this week: ");
			int hours = int.Parse(Console.ReadLine());

			if (hours > 40)
				Console.WriteLine("You worked overtime this week!");
			Console.WriteLine("You worked {0} hours this week", hours);

		}
	}
}
