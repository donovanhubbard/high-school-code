using System;

namespace Project_5
{

	class Class1
	{


		//This program will be a vending machine for Hot chocolate not coffee
		static void Main(string[] args)
		{
			//Makes some new machines
			Machine mach1 = new Machine(2,.90);
			Machine mach2 = new Machine();
			Machine mach3 = new Machine();

			string again;
			int quarters = 0;
			int dimes = 0;
			int nickels = 0;
				
			//identifies which machine to use and a pass variable
			int machine = 0;


			Console.WriteLine("Welcome to the vending machine place!");
			
			//Asks the user which machine to use
			do
			{
			
				do
				{
					Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nWhich machine would you like to use?\n 1: Machine 1\n 2: Machine 2\n 3: Machine 3\n 4: None, I want to quit!");
					string answer = Console.ReadLine();

					switch (answer.ToLower())
					{
						case "1":
						case "machine 1":
							machine = 1;
							break;
						case "2":
						case"machine 2":
							machine = 2;
							break;
						case "3":
						case "machine 3":
							machine = 3;
							break;
						case "4":
						case "none":
						case "quit":
							Console.WriteLine("Fine! Be that way!");
							return;
						default:
							Console.WriteLine("Hey loser that's not an acceptable answer!");
							break;
					}
				}
				while (machine == 0);

			
				//Now we break into three very large if statements
				if (machine == 1)
				{
					mach1.Menu();
				
					Console.WriteLine("Put exact change only! Otherwise it WILL eat your money");

					//puts in coins
					Console.Write("Please insert the number of quarters you're putting in: ");
					quarters = int.Parse(Console.ReadLine());
					Console.Write("Please insert the number of nickels you're putting in: ");
					nickels = int.Parse(Console.ReadLine());
					Console.Write("Please insert the number of dimes you're putting in: ");
					dimes = int.Parse(Console.ReadLine());

					if (mach1.GetCups() > 0)
					{
						mach1.Insert(quarters, dimes, nickels);
						mach1.Select();
					}

					else
					{
						Console.WriteLine("\nThe machine is out of cups!\n");
					}
				}

				if (machine == 2)
				{
					mach2.Menu();
				
					Console.WriteLine("Put exact change only! Otherwise it WILL eat your money");

					//puts in coins
					Console.Write("Please insert the number of quarters you're putting in: ");
					quarters = int.Parse(Console.ReadLine());
					Console.Write("Please insert the number of nickels you're putting in: ");
					nickels = int.Parse(Console.ReadLine());
					Console.Write("Please insert the number of dimes you're putting in: ");
					dimes = int.Parse(Console.ReadLine());

					
					if (mach2.GetCups() > 0)
					{
						mach2.Insert(quarters, dimes, nickels);
						mach2.Select();
					}

					else
					{
						Console.WriteLine("\nThe machine is out of cups!\n");
					}

				}

				if (machine == 3)
				{
					mach3.Menu();
				
					Console.WriteLine("Put exact change only! Otherwise it WILL eat your money");

					//puts in coins
					Console.Write("Please insert the number of quarters you're putting in: ");
					quarters = int.Parse(Console.ReadLine());
					Console.Write("Please insert the number of nickels you're putting in: ");
					nickels = int.Parse(Console.ReadLine());
					Console.Write("Please insert the number of dimes you're putting in: ");
					dimes = int.Parse(Console.ReadLine());

					if (mach3.GetCups() > 0)
					{
						mach3.Insert(quarters, dimes, nickels);
						mach3.Select();
					}

					else
					{
						Console.WriteLine("\nThe machine is out of cups!\n");
					}
				}
					//just a pause
					Console.WriteLine("\tPress enter to continue, or type quit to quit");
					again = Console.ReadLine();
					
					//ends this bloody program
					if (again == "quit")
						return;
					

			}
				while(true);
		}
				
	}

	//This is the Machine's class

	class Machine
	{
		//instance variables
		private int cups;		//the number of cups
		private double cost;		//cost of a cup
		private double money;	//the amount of money input by the user

		//Now some wicked bad constructors
		//quantity is the number of cups, cost is how much they cost
		public Machine( int quantity, double cost)
		{
			this.cups = quantity;
			this.cost = cost;

		}

		public Machine ()
		{
			this.cups = 10;
			this.cost = .50;
		}

		//Now the instance Methods

		//this one displays the amount and price of hot chocolate
		public void Menu()
		{
			Console.WriteLine("\t\t\t\tMenu\n=================================================================\n\t\t\t\tPrice\tCups Available\nHot Chocolate\t\t\t"+this.GetCost()+"\t"+this.GetCups()+"\n");

		}

		//these just give you the stats
		public double GetCost()
		{
			return this.cost;
		}

		public int GetCups()
		{
			return this.cups;
		}

		public double GetMoney()
		{
			return this.money;
		}
		
		//puts money into the machine
		public void Insert(int quarters, int dimes, int nickels)
		{
			double cash;
			cash = quarters * .25;
			cash += dimes * .10;
			cash += nickels *.05;

			this.money = cash;
		}

		//dispenses a cup of hot chocolate if there is enough dough
		//and chocolate are available
		//otherwise the thing yells at you
		public void Select()
		{
			
			//if you put in the right amount it gives you your stuff
			if (this.GetMoney() == this.GetCost())
			{
				this.money -= this.cost;
				Console.WriteLine("You got 1 cup of Hot chocolate, congratulations!\n");
				this.cups--;

			}

			//yells at you if you put in too much
			else if( this.GetMoney() > this.GetCost())
			{
				Console.WriteLine("\nI told you EXACT CHANGE ONLY! I'm keeping your extra money!");
				this.money -= this.cost;
				Console.WriteLine("You got 1 cup of Hot chocolate, congratulations!\n");
				this.cups--;
			}
			else
			{
				Console.WriteLine("\nYou deadbeat! You didn't pay enough cash!");
				this.Refund();
			}
		}

		//This method gives you back your money
		public void Refund()
		{
			Console.WriteLine("Here's your money back you loser!");
			this.money = 0;
			Console.WriteLine("***You get your money back***\n");
		}


			
		}

	

	

	}

