using System;

namespace Craps
{

	class Class1
	{
		//Concept Covered: Generating random numbers
		//What the program does: This is a fully functional craps game. It uses random numbers for the
		//			dice and you can even bet on the outcome.
		//What I learned: Because of this program I figured out how to use random numbers properly.
		static void Main(string[] args)
		{
			//gives us some random numbers to work with
			Random r1 = new Random();

			bool gameOver = false; //this will be used to end the games loop
			double money = 500;
			double bet = 0;
			bool pass;

			Console.WriteLine("Welcome to craps, the game where YOU roll the die and WE take your money!\n");

			do
			{					//loops the whole program so you can play more than one round
				pass = false;
			while(pass == false)
			{
				//sets up the bet
				Console.WriteLine("You have {0:C}", money);
				Console.WriteLine("How much cash would you like to put on this game?");
				bet = double.Parse(Console.ReadLine());
				if (bet > money)
				{
					Console.WriteLine("You deadbeat get more money before you try that again!");
					pass = false;
				}
				else 
					pass = true;
			}
				pass = true;


				
				//gets the first roll
				int die1 = r1.Next(6) + 1;
				int die2 = r1.Next(6) + 1;

				//Tells the user what the roll is

				Console.WriteLine("You roll the first time...");
				Console.WriteLine("You got a {0} and a {1}. The dice total {2}", die1, die2, die1+die2);
			
				#region How to play Craps
				//Here's the shtick on craps
				//On the first roll only if you roll a 7, or 11 you win
				//if you roll a 2, 3, or 12 you lose
				//otherwise it's point
				//you keep rolling until you hit point, 7 or 11.
				//if you hit point you win, 7 or 11 is a lose
				#endregion 
			
				//builds point
				int point = die1 + die2;

				//winning roll
				if (point == 7 || point == 11)
				{
					Console.WriteLine("\nYou win good work!");
					gameOver = true;
					money += bet;
					Console.WriteLine("You get {0:C} and now have {1:C}!", bet, money);
					bet = 0;
				}

					//lossing roll
				else if (point == 2 || point == 3 || point == 12)
				{
					Console.WriteLine("\nWhat a twit! You lost!");
					gameOver = true;
					money -= bet;
					Console.WriteLine("You lose {0:C} and have {1:C}", bet, money);
					bet = 0;
				}

				int total = 0;

				if(gameOver == false)
				{
					Console.WriteLine("\t\t\tHit enter to roll the dice");
					Console.ReadLine();
					do
					{
						Console.WriteLine("The games not over so we go again!");
				
						die1 = r1.Next(6) + 1;
						die2 = r1.Next(6) + 1;
						total = die1 + die2;

						Console.WriteLine("You rolled a {0}, and a {1}. The total is {2}", die1, die2, total);
						Console.WriteLine("Point is "+ point);
				
						if ((total != 7) && (total != 11) && (total != point))
							Console.WriteLine("\t\t\tPress Enter to roll again");
				
						Console.ReadLine();
					}
					while ((total != 7) && (total != 11) && (total != point));

					if (total == 7 || total == 11)
					{
						Console.WriteLine("Hey Punk, You lost!");
						money -= bet;
						Console.WriteLine("You lose {0:C} and now have {1:C}", bet, money);
						bet = 0;

					}

					else
					{ 
						Console.WriteLine("Hey, I guess you won..");
						money += bet;
						Console.WriteLine("You got {0:C} and now have {1:C}!", bet, money);
						bet = 0;
					}
				}
				
				//resets the loop varialbe
				gameOver = false;
			}	
				while(money > 0);
			
			Console.WriteLine("HA HA HA HA! You LOST! LoL\nGame Over ya Retard!");




		}
	}
}
