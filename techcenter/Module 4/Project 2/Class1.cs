using System;

namespace Project_2
{
	
	class Class1
	{
		
		
		//This Program will preform specific geometric calculations
		static void Main(string[] args)
		{
			//provides information for the program
			Console.WriteLine("This program will execute geometric calculations");

			int answer;		//determines which calculation to preform
			double radius;	//the radius of the object
			double height;	//the height of the cylinder

			do
			{
				//prompts the user on what action will be preformed
				Console.WriteLine("\nWhat action would you like preformed?\n\n1:Find the area of a circle\n2:Find the circumference of a cirlce\n3:Find the volume of a cylinder\n4:Quit");
				answer = int.Parse(Console.ReadLine());

				//find the area of a circle
				if (answer == 1)
				{
					Console.Write("\nPlease enter the size of the radius: ");
					radius = double.Parse(Console.ReadLine());
					Console.WriteLine("\nThe area of the circle is {0:F4}.\n\n\t\tPress enter to continue.", Math.PI*(radius * radius));
					Console.ReadLine();
				}

					//finds the circumference
				else if (answer == 2)
				{
					Console.Write("\nPlease enter the size of the radius: ");
					radius = double.Parse(Console.ReadLine());
					Console.WriteLine("\nThe circumference of the circle is {0:F4}.\n\n\t\tPress enter to continue.", Math.PI*(radius * 2));
					Console.ReadLine();
				}

					//finds the volume of a cylinder
				else if (answer == 3)
				{
					Console.Write("\nPlease enter the size of the radius: ");
					radius = double.Parse(Console.ReadLine());
					Console.WriteLine("\nPlease enter the height of the circle");
					height = double.Parse(Console.ReadLine());
					Console.WriteLine("\nThe area of the cylinder is {0:F4}.\n\n\t\tPress enter to continue.", (Math.PI*(radius * radius)) * height);
					Console.ReadLine();
				}

				else if (answer == 4)
				{
					Console.WriteLine("Thank you for using my program!");
					return;
				}

					//the default
				else
					Console.WriteLine("*******DOES NOT COMPUTE*******");
			}
				while(answer != 1 || answer != 2);
		}
	}
}
