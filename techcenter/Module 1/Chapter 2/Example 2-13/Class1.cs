using System;

namespace Example_2_13
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		//Im sticking in the method here
		public static int MultiplyBy4(int aNumber) 
		{
			return 4 * aNumber;
		}
		
		
		[STAThread]
		static void Main(string[] args)
		{
			int x = 7;
			int y = 20;
			int z = -3;
			int result = 0;
			result = MultiplyBy4(x); 
			Console.WriteLine("Passing a variable, x: {0}", result);

			result = MultiplyBy4(y+2);
			Console.WriteLine("Passing an expression, y+2: {0}", result);

			result = 5 + MultiplyBy4(z);
			Console.WriteLine("Using MultiplyBy4 in an expression : {0}", result);
			
			result = MultiplyBy4(31);
			Console.WriteLine("Passing a constant, 31: {0}", result);
			Console.WriteLine("Passing an expression to WriteLine: {0}", MultiplyBy4(y));


		}
	}
}
