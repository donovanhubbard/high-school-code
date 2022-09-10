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

		//concept covered : recursion

		//what the program does:
		//It takes a decimal number from user and converts it into binary using recursion

		//what I learned:
		//I now understand how recursion works and how the tasks stack
		static void Main(string[] args)
		{
			
			while(true)
			{
				Console.WriteLine("Enter a number to convert ya punk! Type -1 to quit");
				int number = int.Parse(Console.ReadLine());

				GetBinary(number);
			}
		}
		public static void GetBinary(int decNum)
		{
			if(decNum > 0)//make sure the number is positive
			{
				int biNum;//the 0 or 1
				int newNum = decNum/2; // the number that is what is left over
				biNum = decNum%2;
			
			
				if(newNum > 0)
				{
					GetBinary(newNum);
				}
				Console.WriteLine(biNum); //prints the result
			}
			else if(decNum == -1)
			{
				Console.WriteLine("Like you have anything better to do!");
				return;
			}
			else
			{
				Console.WriteLine("Enter a POSITIVE number you twit!");
			}
		}
	}
}
