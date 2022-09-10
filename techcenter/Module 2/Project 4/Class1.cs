using System;

namespace Project_4
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
		
		//This program will tell you what coins you need to use for change
		static void Main(string[] args)
		{
			Console.WriteLine("This program will tell you how many coins you get, \nif you pay a dollar for the item you purchase.");
			double coin = 0.0;
			do
			{
				  Console.Write("How much does your product cost? (Enter 17 cents as .17): ");
				  coin = double.Parse(Console.ReadLine());
				  if (coin >= 1 || coin <.01)	//this screens having too little or too much change
								Console.WriteLine("You must have at least one cent or less than a dollar");
			 }
			while(coin >= 1 || coin <.01);

			int change = (int)(coin * 100);
			change = 100 - change;
			int unchangedChange = change;

			//By now the user has told you how much change to convert

			int quarter = 0;
			int nickel = 0;
			int dime = 0;
			int penny = 0;
			//int fifty-cent peice = we dont use these anymore;

			while (change >= 25)
			{
				change -= 25;			//finds quarters
				quarter++;
			}
			
			while (change >= 10)
			{
				change -= 10;		//finds dimes
				dime++;
			}
			
			while (change >= 5)
			{
				change -= 5;		//finds nickels
				nickel += 1;
			}

			while (change >= 1)
			{
				change = change - 1;		//finds the pennies
				penny++;
			}

			Console.WriteLine("You have {0} quarters, {1} dimes, {2} nickels, and {3} pennies in change,\nfor a grand total of {4} cents", quarter, dime, nickel, penny, unchangedChange);


		}
	}
}
