using System;

namespace Example_2_11
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
			int a = 2;
			int b = 4;
			int x = 3;
			int y = 5;
			int z = 6;
			int w = 14;
			y -= 7;
			Console.WriteLine("y = {0}", y);
			a*= x;
			Console.WriteLine("a = {0}", a);
			x /= y;
			Console.WriteLine("x = {0}", x);
			w %= z;
			Console.WriteLine("w = {0}", w);
			b *= z + 3;
			Console.WriteLine("b = {0}", b);

		}
	}
}
