using System;

namespace Project_2
{


	//Concepts Covered:		d. Pass arguments to the program at the command line
	//						e. Use a try-catch block to handle exceptions
	//What the program does: It takes in a value that is passed in from the command line.
	//	The program then takes that number are finds the square root.
	//What did I learn: I figured out how the program arguments work and how exception handling is
	class Class1
	{

		
		static void Main(string[] args)
		{
			
			double number;
			double result;
			try
			{

				if(args.Length > 0)
				{
					number = double.Parse(args[0]);
				}
				else
				{
					Console.WriteLine("You did not enter a valid number.\nPlease enter in a positive number.");
					number = int.Parse(Console.ReadLine());
				}
				
				if(number < 0)
				{
					throw new ApplicationException("You must enter a positive number");
				}
				
				result = Math.Sqrt(number);
				Console.WriteLine("The square root of "+number+" equals "+result);
			}
			
			catch(FormatException e)
			{
				Console.WriteLine("The input must be a number");
				result = 0;
			}

			catch(System.IndexOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
			}

			catch(ApplicationException e)
			{
				Console.WriteLine(e.Message);
			}
			
			finally
			{
				Console.ReadLine();
			}
			
			
		}
	}
}
