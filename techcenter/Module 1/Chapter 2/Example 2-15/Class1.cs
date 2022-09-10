using System;

namespace Example_2_15
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		public static int Cube(int aNumber)
		{
			int result = aNumber*aNumber*aNumber;
			aNumber += 5;
			return result;
		}
		
		[STAThread]
		static void Main(string[] args)
		{
			int x = 12;
			int value = Cube(x);
			Console.WriteLine("The cube of {0} is {1}", x, value);
		}
	}
}
