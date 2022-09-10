using System;

namespace Project_2
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
		
			//returns the remainder of a number divided by seven.
		public static int FindRemainder(int number)
		{
			return number%7;
		}
		
		
		//Divides 3 numbers by seven and displays the remainder
		static void Main(string[] args)
		{
			Console.WriteLine("This program will find the remainders of 3 differnet numbers\nwhen divided by seven");
			
			//Initailzing and Declaring variables
			int x = 73;
			int y = 16;

			Console.WriteLine("Remainder of 73 is "+FindRemainder(x));
			Console.WriteLine("Remainder of 16 is "+FindRemainder(y));
			Console.WriteLine("Remainder of 16+73 is "+FindRemainder(x+y));
		}
	}
}
