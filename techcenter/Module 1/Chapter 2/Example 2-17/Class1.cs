using System;

namespace Example_2_17
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
	
		public static void NoParen( int a, int b, int c) 
		{
			int expr1 = a + 7 * b;
			int expr2 = c / a + 4;
			int expr3 = c - a % b - a;
			Console.WriteLine("a+7*b = {0}", expr1);
			Console.WriteLine("c/a + 4 = {0}", expr2);
			Console.WriteLine("c-a % b-a = {0}", expr3);
			Console.WriteLine();
		}

		public static void SameParen(int a, int b, int c) 
		{
			int expr1 = a + (7 * b);
			int expr2 = (c / a) + 4;
			int expr3 = (c - (a % b)) - a;
			Console.WriteLine("a+(7*b) = {0}", expr1);
			Console.WriteLine("(c/a) + 4 = {0}", expr2);
			Console.WriteLine("(c-(a%b))-a = {0}", expr3);
			Console.WriteLine();
		}

		public static void ChangeParen(int a, int b, int c) 
		{
			int expr1 = (a + 7) * b;
			int expr2 = c / (a + 4);
			int expr3 = (c - a) % (b - a);
			Console.WriteLine("(a+7)*b = {0}", expr1);
			Console.WriteLine("c/(a+4) = {0}", expr2);
			Console.WriteLine("((c-a) % (b-a) {0}", expr3);
			Console.WriteLine();
		}
 		
		[STAThread]
		static void Main(string[] args)
		{
			NoParen(3, 4, 5);
			SameParen(3, 4, 5);
			ChangeParen(3, 4, 5);
		}
	}
}
