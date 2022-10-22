using System;

namespace Example_3_1
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
			int i = 3;
			bool result;
			result = (32 > 87);			//I tinkered around with the bool type
			Console.WriteLine("(32 > 87) is {0}", result);  //I put variables in and had it display the bools value

			result = (-20 == -20);
			Console.WriteLine(" (-20 == -20) is "+result);

			Console.WriteLine(" -20 == -10 -10 is {0}", result);
			Console.WriteLine(" 16 <= 54 is {0}", 16<=54);
			Console.WriteLine(" i != 3 is {0}", i !=3);
		}
	}
}
