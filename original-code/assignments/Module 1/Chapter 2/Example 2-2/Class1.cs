using System;

namespace Example_2_2
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
			int max = int.MaxValue;
			int min = int.MinValue;
			Console.WriteLine("The largest int value is {0}", max);
			Console.WriteLine("The smallest int value is {0}", min);

		}
	}
}
