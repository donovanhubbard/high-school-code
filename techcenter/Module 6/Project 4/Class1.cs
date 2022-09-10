using System;

namespace Project_4
{

	class Class1
	{
			//THis is a master mind program. The user will try to guess the number
		static void Main(string[] args)
		{
		
			int[] code = new int[4];
			Random r1 = new Random();

			//gets the random numbers
			int num1 = r1.Next(10);
			int num2 = r1.Next(10);
			int num3 = r1.Next(10);
			int num4 = r1.Next(10);
					
			//puts them into the array
			code[0] = num1;
			code[1] = num2;
			code[2] = num3;
			code[3] = num4;

			//the users guesses
			int guess1;
			int guess2;
			int guess3;
			int guess4;

			//the total number of guesses
			int guesses = 0;

			//the number of numbers that are correct
			int correct = 0;
			//the number of numbers that are in the right spot
			int spot = 0;						  
			
			Console.WriteLine("I am the Master Mind\nI am thinking of a 4 digit number....");

			do
			{
				guesses++;
				spot = 0;
				correct = 0;
				//gets the users guess
				Console.WriteLine("Guess the number...");
				
				Console.Write("Digit 1: ");
				guess1 = int.Parse(Console.ReadLine());
				Console.Write("Digit 2: ");
				guess2 = int.Parse(Console.ReadLine());
				Console.Write("Digit 3: ");
				guess3 = int.Parse(Console.ReadLine());
				Console.Write("Digit 4: ");
				guess4 = int.Parse(Console.ReadLine());
				
				
				#region Right Spot
				if(code[0] == guess1)
				{
					spot++;
				}
				if(code[1] == guess2)
				{
					spot++;
				}
				if(code[2] == guess3)
				{
					spot++;
				}
				if(code[3] == guess4)
				{
					spot++;
				}
				#endregion

				#region Correct number
				if(code[0] == guess1 || code[0] == guess2 || code[0] == guess3 || code[0] == guess4)
					correct++;

				if(code[1] == guess1 || code[1] == guess2 || code[1] == guess3 || code[1] == guess4)
					correct++;
				
				if(code[2] == guess1 || code[2] == guess2 || code[2] == guess3 || code[2] == guess4)
					correct++;

				if(code[3] == guess1 || code[3] == guess2 || code[3] == guess3 || code[3] == guess4)
					correct++;
				#endregion

				//tells the user how well they guessed
				Console.WriteLine("{0} number(s) are correct, and {1} number(s) are in the right spot.\n\t\tPress Enter to Continue", correct, spot);
				Console.ReadLine();



											  }
				while(spot != 4);

			Console.WriteLine("Hey, you guessed my number. Great job!");
			Console.WriteLine("It took you {0} guesses", guesses);
		}
	}
}
