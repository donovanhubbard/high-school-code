using System;

namespace Project_3
{

	class Class1
	{
		
		//this program is a math quiz. Th User enters in what type of math problem they want 
		//and then you give them that problem
		static void Main(string[] args)
		{
			int mathType;	//the math function they want to preform
			int num1;		//the first number and second number respectivly
			int num2;
			int answer;		//the users answer
			int cAnswer;	//the right answer
			Random r1 = new Random();//the random number
			
			Console.WriteLine("Welcome to Math Quiz 94!\nThe game where you do math and I insult you!");

			//this loop keeps going until they quit
			do
			{
			
				Console.WriteLine("What math function would you like to solve?\n1. Addition\n2. Subtraction\n3. Multiplication\n4. Quit");

				
				mathType = int.Parse(Console.ReadLine());
				
				//we know what function the user wants preformed
				//if they picked quit it skips to the end of the loop
				if(mathType != 4)
				{

					//gives me the random numbers
					num1 = r1.Next(100);
					num2 = r1.Next(100);

					Console.WriteLine("Solve the Problem:");
					Console.Write(num1);
					
						//adjusts the message appropriatly
					if(mathType == 1)
						Console.Write(" + ");
					else if (mathType == 2)
						Console.Write(" - ");
					else
						Console.Write(" X ");

					Console.Write(num2+"= ");

					answer = int.Parse(Console.ReadLine());
					
						//adding
					if(mathType == 1)
					{
						cAnswer = num1 + num2;
						if(answer == cAnswer)
							Console.WriteLine("Good job you got it right!");
						else
						{
							Console.WriteLine("Your wrong moron! Add better!");
							Console.WriteLine("The correct answer is {0}",num1+num2);
						}
					}
					
					//subtracting
					else if (mathType == 2)
					{
						cAnswer = num1 - num2;
						if(answer == cAnswer)
						{
							Console.WriteLine("That's right!");
						}
						else
						{
							Console.WriteLine("Hey stupid that's the wrong answer!");
							Console.WriteLine("You should have put {0}", num1 - num2);
						}
					}
							
						//multiplying	
					else
					{
						cAnswer = num1 * num2;
						if(answer == cAnswer)
						{
							Console.WriteLine("That's right!");
						}
						else 
						{
							Console.WriteLine("Ya Retard! The answer is {0}", num1 * num2);
						}
					}

					Console.WriteLine("\t\tPress Enter to Continue");
					Console.ReadLine();




				}
			}
			while(mathType != 4);

			Console.WriteLine("Thank you for playing my game!");
		}
			
	}
}
