using System;

namespace Example_2_16
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
	
		public static void Additive(int x, int y) 
		{
			int z = x + y;
			int w = x - y;
			int p = -y;
			Console.WriteLine("x + y = {0,3}    x - y = {1,3}     -y = {2,3}", x + y, x - y, -y);
		}

		public static void Multiplicative(int x, int y) 
		{
			int z = x * y;
			int w = x / y;
			int p = x % 7;
			Console.WriteLine("x*y = {0,3}    x/7 = {1,3}   x % 7 = {2,3}", x * y, x / y, x % y);
		}
		
		static void Main(string[] args)
		{
			int x = 25;
			int y = 14;
			Additive(x, y);
			Multiplicative(x, y);

		}
	}
}
