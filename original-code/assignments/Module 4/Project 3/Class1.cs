using System;

namespace Project_3
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{


		//Ok, I think this program will compute some weird math equation
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("This program will compute a mathmatical equation");

			Console.Write("Enter the value of x: ");
			double x = double.Parse(Console.ReadLine());
			Console.WriteLine("e to the {0} power is...", x);

			//the actual equation, e will be the running total
			//value 1 was picked because it was the first term
			double power = 1;
			double total = 1;
			double fac = 1;

			while((Math.Pow(x, power))/Factorial(fac) >= 1.0E-6)
			{
				total += (Math.Pow(x, power))/Factorial(fac);
				power++;
				fac++;
			}
			
			Console.WriteLine("{0:F6}", total);

			Console.WriteLine("The computer's method calculated it to be {0:F6}.", Math.Exp(x));

			
		}

		//preforms the Facotrial Command
		public static double Factorial(double n)
		{
			//this is what the actual value of the answer is
			double total = 1;

			//loop multilpys the running total and subtracts the n
			//n(n-1)(n-2)(n-3).... etc.
			while ( n > 0)
			{
				total *= n;
				n--;
			}

			return total;
			
		}

		
	}
	}

