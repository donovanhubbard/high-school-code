using System;

namespace Project_6
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		//This program will find the amount of time needed to pay of a
		//loan with the users spefications.
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("This program will determine how many more months\nare required for your loan.");
			
			Console.Write("Please enter the principle of your loan: ");
			double principle = double.Parse(Console.ReadLine());

			Console.Write("Please enter the annual intrest on your loan: ");
			double intrest = double.Parse(Console.ReadLine());

			Console.Write("Please enter how much you will pay every month: ");
			double payment = double.Parse(Console.ReadLine());

			//The user now has entered in the principle, intrest and months
			

		
			double balance = principle;
			intrest *= .01;
			int months=0;
			double monthlyIntrest = intrest / 12.0 + 1.0;

			while (balance > 0)
			{
				balance *= monthlyIntrest;	//adds the new intrest amount
				balance -= payment;
				months++;			//keeps track of how much time has passed	
			}

				Console.WriteLine("It will take {0} months to pay off your bloody loan.", months);

			


		}
	}
}
