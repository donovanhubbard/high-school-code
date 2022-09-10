using System;

namespace Project_3
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
		
		//Program will convert seconds into hours and minutes
		static void Main(string[] args)
		{
			
			int seconds = 0;	//The number of seconds, minutes and hours respectivly
			int minutes = 0;
			int hours = 0;
			
			Console.WriteLine("This program will convert seconds into hours, minutes, and seconds.");
			Console.Write("How many seconds do you wish to convert? ");
			seconds = int.Parse(Console.ReadLine());

			//The user now has entered in the number of seconds

			while (seconds >= 3600) //3600 is the number of seconds in an hour
			{  
				seconds -= 3600;		//totals up the hours
				hours += 1;
			}
			
			while (seconds >= 60)
			{
				seconds -= 60;		//adds up the minutes
				minutes += 1;
			}
		
			Console.WriteLine("{0} hours, {1} minutes, and {2} seconds", hours, minutes, seconds);

			}
	}
}
