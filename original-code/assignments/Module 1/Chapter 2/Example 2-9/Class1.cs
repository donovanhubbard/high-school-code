using System;

namespace Example_2_9
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
			// Illustrates +,-, *, /, and %

			int x = 25;
			int y = 14;
			int z = x + y;
			int w = x - y;
			int p = -y;
			Console.WriteLine(" x + y = {0}		x - y = {1}		-y = {2}", z, w, p);

			z = x * y;
			w = x / 7;
			p= x % y;

			Console.WriteLine("x * y = {0}		x / 7 = {1}		x % 7 = {2}", z, w, p);

		}
	}
}
