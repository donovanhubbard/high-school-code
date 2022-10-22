using System;

namespace Example_2_10
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
			/* Computes expressions three ways
			 *	Without Parentheses --- uses precedence rules
			 *	With parentheses the same a s precedence rules
			 *	With parentheses differnt than precedence rules
			 */

			//declare and initialize

			int a = 3;
			int b = 4;
			int c = 5;
			int noParen = a + 7 * b;		
			int sameParen = a + (7 * b);	
			int changeParen = (a + 7) * b;	


			//Now we display the answers

			System.Console.WriteLine("noParen = {0,3} sameParen = {1,3} changeParen = " + "{2,3}", noParen, sameParen, changeParen);
			
			noParen = c / a + 4;
			sameParen = (c / a ) + 4;
			changeParen = c / (a + 4);

			System.Console.WriteLine("noParen = {0,3} sameParen = {1,3} changeParen = " + "{2,3}", noParen, sameParen, changeParen);

			noParen = c - a % b - a;
			sameParen = (c- (a % b)) - a;
			changeParen = (c - a) % (b - a);
			
			Console.WriteLine("noParen = {0,3} sameParen = {1,3} changeParen = " + "{2,3}", noParen, sameParen, changeParen);


		}
	}
}
