using System;

namespace Project_5
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
		
		//This program will find the average of a series of numbers
		static void Main(string[] args)
		{
			Console.WriteLine("This program will find the average to a series of non-negative numbers.");
			int counter = 0;  //the number of numbers entered
			int number = 0;	  //the number entered in by the user
			int total = 0;	  //the total of all the numbers entered
			
			do
			{
				Console.Write("Please enter in the a number (-1 to end): ");
				number = int.Parse(Console.ReadLine());	//reads a number
				if (number >=0)			//makes sure the number entered is real
				{
					total += number;	//adds the current number to the total
					counter++;			//increments counter
				}
			}
				while(number >= 0);

			if (counter > 0)
				Console.WriteLine("The average of your series of numbers is "+total/counter);
			
			else
				Console.WriteLine("Hey Moron! You didn't enter any numbers!");

				
			

		}
	}
}
