using System;

namespace Burger_Joint_Sim
{
	/*
	 * You will be in charge of a Burger joint and try to
	 * keep it stocked with employees and food stuffs
	 * you'll try to last as long as  possible, without running out
	 * 
	 * This program contains 
	 * about 400 lines of code
	 * 
	 * Concepts from chapter 4: a logical opperator (AND &&), switch statements, 
	 * if/else statements, for loops and while loops.
	 * 
	 * Concepts from chapter 5: classes and objects, instance variables, 
	 * instance methods, and constructors  
	 * 
	 * By making this program it helped me learn the way that classes and 
	 * objects work, including how methods affect them and how private 
	 * varaiables are modified. I somewhat understood the concept before
	 * but now I fully understand classes and objects and realise the 
	 * advantages of using them.
	 */
	class Class1
	{
		
		//This is just a clear screen method
		public static void CLS()
		{
			for(int i=0; i<10; i++)
				Console.WriteLine("\n");
		}
		


		static void Main(string[] args)
		{
			Console.WriteLine("\n\t\t\tBURGER JOINT SIM v1.00\n================================================================================");
			Console.WriteLine("Welcome to Burger Joint Sim!\nThe game where you run your own fast food resturant!\n");
			Console.Write("What would you like to name your new restaurant? ");
			
			//gives your place a name
			String newName = Console.ReadLine();

			BurgerJoint joint1 = new BurgerJoint(newName);


		//Of course I have to add in a cheat to my game
			if (newName == "Don's Place")
			{
				joint1.HireEmployees(150);
				joint1.StockSodas(5000);
				joint1.StockMeats(5000);
				joint1.StockFries(100000);
				Console.WriteLine("\n******** CHEAT ACCEPTED ********");
			}
		//and a cheat to make you win
			if (newName == "No Time")
			{
				for(int i = 0; i < 51; i++)
					joint1.PassTurn();
				Console.WriteLine("\n********** CHEAT ACCPETED *********");
			}
				

			
			//instructions
			Console.WriteLine("\n\nYou now own your own returant named " + joint1.GetName());
			Console.WriteLine("Make sure you keep your place stocked with foods, and employees, \nbut you can only restock one thing at a time. \nThe more employees you have the more money you will get.\nThe cost to resupply and the amount that will be added \nto your supplies are written next to the product.\nTry to last as long as possible. Good Luck!\n");
			Console.WriteLine("\n\n\t\t\tPlease press enter to start!");
			Console.ReadLine();

			//this here will provide the body of the program.
			//each time the loop has run a turn will pass
			//the supplys of your joint will be altered and you will try
			//to stay in buisness
			while (joint1.StillIn())
			{
				bool pass = false;
				//this prevents you from putting in a bad input, it will continue to loop
				while (pass == false){
				CLS();
				Console.WriteLine("\n\t\t\tBURGER JOINT SIM v1.00\n================================================================================\n\n\n\n\n\n\n");
				Console.WriteLine("\n" + joint1.GetName() + " Status\t\t\tCash = {0:C}\t\t"+ joint1.GetTurns() + " Turns\n================================================================================\n\t\t\tQuantity\tCost to resupply\tAmount Added", joint1.GetCash());
				Console.WriteLine("1. Employees\t\t" + joint1.GetEmployees()+"\t\t$600.00\t\t\t5");
				Console.WriteLine("2. Soda\t\t\t"+ joint1.GetSodas()+"\t\t$400.00\t\t\t50");
				Console.WriteLine("3. Fries\t\t"+ joint1.GetFries() +"\t\t$250.00\t\t\t100");
				Console.WriteLine("4. Meat\t\t\t"+ joint1.GetMeat() +"\t\t$400.00\t\t\t50");
				Console.WriteLine("5. Do Nothing!");
				Console.WriteLine("\n\nWhat would you like to resupply?\n");
				String answer = Console.ReadLine();

				//Now we enter a switch statement to determine what is added

					switch (answer.ToLower())
					{
						case "1":
						case "employees":
						case "employee":
							if(joint1.GetCash() >=600 ) //makes sure you have the money
							{
								joint1.HireEmployees(5);
								Console.WriteLine("You hired 5 employees, and have "+joint1.GetEmployees()+" total employees");
								pass = true;
								joint1.UseCash(-600);
							}
							else
								Console.WriteLine("You dont' have the cash for that!");
							break;
						case "2":
						case "soda":
						case "sodas":
							if (joint1.GetCash() >= 400)
							{
								joint1.StockSodas(50);
								Console.WriteLine("You got 50 more sodas, and have "+joint1.GetSodas()+" total sodas.");
								pass = true;
								joint1.UseCash(-400);
							}
							else
								Console.WriteLine("You don't have the money for that stupid!");
							break;
						case "3":
						case "fry":
						case "fries":
							if (joint1.GetCash() >= 250)
							{
								joint1.StockFries(100);
								Console.WriteLine("You got 100 more fries, and have "+joint1.GetFries()+" total fries.");
								pass = true;
								joint1.UseCash(-250);
							}
							else
								Console.WriteLine("Hey loser! You don't have the money for that!");
							break;
						case "4":
						case "meat":
						case "meats":
							if (joint1.GetCash() >= 400)
							{
								joint1.StockMeats(50);
								Console.WriteLine("You got 50 more slabs of meat, and have "+joint1.GetMeat()+" total peices of meat.");
								pass = true;
								joint1.UseCash(-400);
							}
							else
								Console.WriteLine("You don't have the money for something like that!");
							break;
						case"5":
						case"nothing":
						case"do nothing":
							Console.WriteLine("Umm... ok you do nothing!");
							pass = true;
							break;
						default:
							Console.WriteLine("Hey stupid! you didn't put in anything a machine can understand");
							break;
					}
					//this pauses so you can stop and read the text that was just printed
					if(pass == true)
					{
						Console.WriteLine("You made $"+joint1.GetEmployees()*75.00+" this turn.");
						Console.WriteLine("\t\t\t\tPress Enter to continue to next turn");
					}

					else
						Console.WriteLine("\t\t\tPress Enter to try again Moron!");
					Console.ReadLine();
					
					//this here is what happens if you win
					if (joint1.GetTurns() == 51)
					{
						CLS();
						Console.WriteLine("Wow! You made it passed 50 turns! I guess you win.... \n\n************ Congratulations!! **********\n\n\nI hope you enjoyed my game (yeah, right!)\nIf you were expecting some cool end game thing, \nthen I wouldn't want to disappoint you....\n\n\t\t\tPress enter to see endgame thing");
						Console.ReadLine();
						CLS();
						Console.WriteLine("Ha! gotcha, there isn't one. I havn't learned graphics yet,\n but you can continue to play the game from where you left off.\nWould you like to continue?");
						String end = Console.ReadLine();
						
						//now a little switch to see if the game goes on
						switch (end.ToLower())
						{
							case "yes":
							case "yeah":
							case "sure":
								Console.WriteLine("Okie Dokie, here we go again!");
								break;
							case "no":
							case "nope":
							case"no way!":
								Console.WriteLine("Ya jerk! Why wont you play my game!!! $%^&*(%!");
								Console.ReadLine();
								return;
							default: 
								Console.WriteLine("Whatever, I'll just quit for you, its a dumb game anyway!");
								Console.ReadLine();
								return;
						}
					}

				}

				joint1.EndTurn();
			}
		
		//At this point the buisness has run out of something
		//It will display your stats again, showing you what you ran out of
		CLS();
		Console.WriteLine("\n\t\t\tBURGER JOINT SIM v1.00\n================================================================================\n");
		Console.WriteLine("\n*******************  You have run out of supplies  *****************************\n****************************  Game Over  ***************************************");
		Console.WriteLine("\n" + joint1.GetName() + " Status\t\t\tCash = {0:C}\t\t" + joint1.GetTurns() + " Turns\n================================================================================\n\t\t\tQuantity\t\t", joint1.GetCash());
		
		//this here will flag the stuff you run out of
		
		if (joint1.GetEmployees() > 0)
			Console.WriteLine("1. Employees\t\t" + joint1.GetEmployees());
		else
			Console.WriteLine("1. Employees\t\t0\t\t****** None ******");
		if (joint1.GetSodas() > 0)
			Console.WriteLine("2. Soda\t\t\t"+ joint1.GetSodas());
		else
			Console.WriteLine("2. Soda\t\t\t0\t\t******Out of stock******");
		if(joint1.GetFries() > 0)
			Console.WriteLine("3. Fries\t\t"+ joint1.GetFries());
		else
			Console.WriteLine("3. Fries\t\t0\t\t******Out of stock******");
		if(joint1.GetMeat() > 0)
			Console.WriteLine("4. Meat\t\t\t"+ joint1.GetMeat());
		else
			Console.WriteLine("4. Meat\t\t\t0\t\t******Out of stock******");
		Console.WriteLine("\n");
		Console.WriteLine("You lasted a total of " + joint1.GetTurns() + " turns!");
		
		//this here is just to make fun of you for getting a bad score
		
		if (joint1.GetTurns() == 2)
			Console.WriteLine("Holy lame insult Batman! You did the absolute worst possible!");
		if (joint1.GetTurns() < 5 && joint1.GetTurns() > 2)
			Console.WriteLine("Holy Crap! You suck!");
		if (joint1.GetTurns() >= 5 && joint1.GetTurns() <10)
			Console.WriteLine("You didnt get far at all, your a loser!");
		if (joint1.GetTurns() >=10 && joint1.GetTurns() < 15)
			Console.WriteLine("Lol! You were outsmarted by MY a game!");
		if (joint1.GetTurns() >=15 && joint1.GetTurns() <35)
			Console.WriteLine("I supose you did ok...");
		if (joint1.GetTurns() >=35 && joint1.GetTurns() < 50)
			Console.WriteLine("Wow! You got pretty far!");
		if (joint1.GetTurns() ==  50)
			Console.WriteLine("Holy smokes you got far!");
		if (joint1.GetTurns() >= 51)
			Console.WriteLine("Good work you beat the game!");
		Console.ReadLine();


		}
	}

	//This class will be what we use for each burger joint
	class BurgerJoint
	{
		// *********Instance Variables**************
		private string name;
		private int employees;
		private int soda;
		private int meat;
		private int fries;
		private int cash;
		private int turns; //this will be used for scoring

		//*************constructors*****************
		public BurgerJoint(String jointName)
		{
			name = jointName;
			employees = 5;
			soda = 20;
			meat = 25;
			fries = 50;
			cash = 750;
			turns = 0;
		}

		//I'm overloading this method by adding another constructoer
		public BurgerJoint()
		{
			name = "McNoobies";
			employees = 5;
			soda = 50;
			meat = 25;
			fries = 75;
			cash = 750;
			turns = 0;
		}

		//*********Instance Methods*********
		
		//This gives you your joints name
		public String GetName()
		{
			return this.name;
		}

		//********These Methods display store stats**********
		public int GetEmployees()
		{
			return this.employees;
		}

		public int GetSodas()
		{
			return this.soda;
		}

		public int GetMeat()
		{
			return this.meat;
		}
		
		public int GetFries()
		{
			return this.fries;
		}
		
		public int GetCash()
		{
			return this.cash;
		}

		public int GetTurns()
		{
			return this.turns;
		}

		//******These methods add supplies******//

		//Stocks sodas
		public void StockSodas(int addedSodas)
		{
			this.soda += addedSodas;
		}

		//Stocks meat
		public void StockMeats(int addedMeats)
		{
			this.meat += addedMeats;
		}

		//Stocks Sodas
		public void StockFries(int addedFries)
		{
			this.fries += addedFries;
		}

		//Hires employees
		public void HireEmployees(int hiredEmployees)
		{
			this.employees += hiredEmployees;
		}

		//adds a turn to the tally
		public void PassTurn()
		{
			this.turns += 1;
		}

		//adjusts money acordingly
		public void UseCash(int expense)
		{
			this.cash += expense;
		}


		//this method cycles your turn by changing your stores properties
		public void EndTurn()
		{
			this.UseCash(this.GetEmployees()*75); //pays you $75 for each employee
			this.HireEmployees(-1);
			this.StockMeats(-10);
			this.StockSodas(-12);
			this.StockFries(-20);
			this.PassTurn();
			CLS();
		}

		//checks to see if you are bankrupt
		public bool StillIn()
		{
			if ( this.GetEmployees() <= 0 || this.GetFries() <= 0 || this.GetMeat() <= 0 || this.GetSodas() <= 0)
				return false;

			else
				return true;
			
		}

		//This is just a clear screen method
		public static void CLS()
		{
			for(int i=0; i<50; i++)
				Console.WriteLine("\n");
		}

 
	}



}


