using System;

namespace Project_1
{

	class Class1
	{
		
		
		//This program is desinged to convert Brittish Pounds and 
		//American Dollars
		static void Main(string[] args)
		{
			Console.WriteLine("This program will convert English Pounds and American Dollars.");
			
			//this will ensure that the user puts in a valid answer
			bool pass = false;

			//these two variables will tell the computer what is being converted
			bool poundsToDollars = false;
			bool dollarsToPounds = false;

			//this here is the actual currecny variables
			double pounds;
			double dollars;
		
			//this do while loop will run the whole program again
			
			do
			{

			while (pass == false)
			{

				Console.WriteLine("\nWhat currency are you converting?\n1:Pounds to Dollars\n2:Dollars to Pounds");
				string answer = Console.ReadLine();
				//By now the user knows what the program does, and what he will be doing with it.
				//we then use a switch statement to handle the responses.

				//determines what we are converting
				switch (answer.ToLower())
				{
					case "1":
					case "pounds to dollars":
						pass = true;
						poundsToDollars = true;
						break;

					case "2":
					case "dollars to pounds":
						pass = true;
						dollarsToPounds = true;
						break;

					
					default:
						Console.WriteLine("You didn't enter anthing the computer can understand");
						break;
				}
			}
				//reseting this so it will run again
				pass = false;
				if (poundsToDollars == true)
				{
				
					Console.Write("\n\n\nPlease enter the number of pounds: ");
					pounds = double.Parse(Console.ReadLine());

					//the conversion rate is 1.6595 dollars equals a pound
					dollars = pounds * 1.6595;
					Console.WriteLine("\nYou have {0:C} American.", dollars);
				
					//I reset everything here so it can be run again
					pounds = 0;
					dollars = 0;
					poundsToDollars = false;
				}

				if (dollarsToPounds == true)
				{
				
					Console.Write("\n\n\nPlease enter the number of dollars: ");
					dollars = double.Parse(Console.ReadLine());

					//the conversion rate is 1.6595 dollars equals a pound
					pounds = dollars / 1.6595;
					Console.WriteLine("\nYou have {0:C} in Brittish Pounds.", pounds);
				
					//I reset everything here so it can be run again
					pounds = 0;
					dollars = 0;
					dollarsToPounds = false;
				}
			
				bool go = true;
				//asks if the user wants to go again
				do
				{
					Console.WriteLine("You you like to run the program again?");
					string again = Console.ReadLine();
					switch (again)
					{
						case "yes":
						case "y":
							Console.WriteLine("Ok, I'll run the progam again");
							go = true;
							break;
						case "no":
						case "n":
							return;
						default:
							Console.WriteLine("Wrong answer! Try again!");
							go = false;
							break;
					}
				}

				//once again making sure the user puts in valid input
				while (go == false);
				//the only way to end this do while loop is to run the 
				//return command somewhere inside
			}while (true);











		}
	}
}
