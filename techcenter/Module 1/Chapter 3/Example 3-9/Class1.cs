using System;

namespace Example_3_9
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
				Console.WriteLine("Sum is {0}", sum);
			}
			Console.WriteLine("The sum fo the first {0} squares is {1}", high, sum);
		}
	}
}
