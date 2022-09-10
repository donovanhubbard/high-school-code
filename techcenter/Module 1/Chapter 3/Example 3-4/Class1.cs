using System;

namespace Example_3_4
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
			double five3rds = 5.0/3.0;
			Console.WriteLine("Default precision		{0}", five3rds);

			double threeHalves = 3.0/2.0;
			Console.WriteLine("No trailing zeros		{0}", threeHalves);

			Console.WriteLine("Default				{0}", 1234567890.987);
			
			Console.WriteLine("Fixed, two places		{0:F2}", 1234567890.987);

			Console.WriteLine("Exponent			{0:E}", 1234567890.987);

			Console.WriteLine("Exponent, two places		{0:E2}", 1234567890.987);

			Console.WriteLine("General				{0:G}", 1234567890.987);

			Console.WriteLine("Changes to fixed		{0}", 1234567.89987E2);

			Console.WriteLine("Changes to scientific		{0}", .0000123456789);


		}
	}
}
