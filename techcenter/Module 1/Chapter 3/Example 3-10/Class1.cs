using System;

namespace Example_3_10
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
			int sum = 0;
			int count = 1;
			Console.Write("Enter the number of squares to sum: ");
			int high = int.Parse(Console.ReadLine());
			while (count <= high)
			{
				sum += count*count;
				count++;
			}
			Console.WriteLine("The sum for the first {0} squares is {1}", high, sum);
		}
	}
}
