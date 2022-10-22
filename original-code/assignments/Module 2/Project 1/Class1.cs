using System;

namespace Project_1
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
		
		//This program will have the user input three ints int
		//Then the program will multiply them together and add the sum
		//after acomplishing this the program will send the info back to the user

		static void Main(string[] args)
		{
			//Obtain 3 integers named num1, num2, and num3 respectivly
			
			Console.Write("Please enter in an integer: ");
			int num1 = int.Parse(Console.ReadLine());
			Console.Write("Pleas enter a second integer: ");
			int num2 = int.Parse(Console.ReadLine());
			Console.Write("Now enter the final integer: ");
			int num3 = int.Parse(Console.ReadLine());

			//gets the product and sum
			int product = num1 * num2 * num3;
			int sum = num1 + num2 + num3;

			//prints the finished project to the screen
			Console.WriteLine("The sum of the integers is {0}", sum);
			Console.WriteLine("The product of the integers is {0}", product);
		}
	}
}
