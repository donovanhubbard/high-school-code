using System;

namespace Example_2_12
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
			int x = 5;
			int y = 5;
			int a = 3;
			int b = 3;
			int j = 7;
			int k = 7;
			int result=0;
			j++;
			++k;
			Console.WriteLine("j = {0} and k = {1}", j, k);
			j--;
			--k;
			Console.WriteLine("j = {0} and k = {1}", j, k);
			result = 3 + x++;
			Console.WriteLine("result = {0} and x = {1}", result, x);
			result = 3 + y++;
			Console.WriteLine("result = {0} and y = {1}", result, y);
			result = 2 + a--;
			Console.WriteLine("result = {0} and a = {1}", result, a);;
			result = 2 + --b;
			Console.WriteLine("result = {0} and b = {1}", result, b);



		}
	}
}
