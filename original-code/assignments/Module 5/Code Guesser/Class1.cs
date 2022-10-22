using System;

namespace Code_Guesser
{

	class Class1
	{
		//Concepts covered: String Comparisons
		//What the program does: It generates random letters and you try and guess it
		//it will tell you where each letter is respective to its position in the alpahbet

		//What I learned: I figured out how to type cast, and how .ToString and .CompareTo work

		static void Main(string[] args)
		{
			string guess;		//the useres guess
			string guess1;
			string guess2;
			string guess3;
			string code1;		//code letter 1
			string code2;
			string code3;
			
			#region Random Code
			Random ran = new Random();

			//Letter 1
			int r1 = ran.Next(26);

			if(r1 == 0)
				code1 = "a";
			else if(r1 == 1)
				code1 = "b";
			else if(r1 == 2)
				code1  = "c";
			else if(r1 == 3)
				code1  = "d";
			else if(r1 == 4)
				code1  = "e";
			else if(r1 == 5)
				code1  = "f";
			else if(r1 == 6)
				code1  = "g";
			else if(r1 == 7)
				code1  = "h";
			else if(r1 == 8)
				code1  = "i";
			else if(r1 == 9)
				code1  = "j";
			else if(r1 == 10)
				code1  = "k";
			else if(r1 == 11)
				code1  = "l";
			else if(r1 == 12)
				code1  = "m";
			else if(r1 == 13)
				code1  = "n";
			else if(r1 == 14)
				code1  = "o";
			else if(r1 == 15)
				code1  = "p";
			else if(r1 == 16)
				code1  = "q";
			else if(r1 == 17)
				code1  = "r";
			else if(r1 == 18)
				code1  = "s";
			else if(r1 == 19)
				code1  = "t";
			else if(r1 == 20)
				code1  = "u";
			else if(r1 == 21)
				code1  = "v";
			else if(r1 == 22)
				code1  = "w";
			else if(r1 == 23)
				code1  = "x";
			else if(r1 == 24)
				code1  = "y";
			else if(r1 == 25)
				code1  = "z";
			else 
				code1 = "ERROR";


			//Letter 2
			int r2 = ran.Next(26);

			if(r2 == 0)
				code2 = "a";
			else if(r2 == 1)
				code2 = "b";
			else if(r2 == 2)
				code2  = "c";
			else if(r2 == 3)
				code2  = "d";
			else if(r2 == 4)
				code2  = "e";
			else if(r2 == 5)
				code2  = "f";
			else if(r2 == 6)
				code2  = "g";
			else if(r2 == 7)
				code2  = "h";
			else if(r2 == 8)
				code2  = "i";
			else if(r2 == 9)
				code2  = "j";
			else if(r2 == 10)
				code2  = "k";
			else if(r2 == 11)
				code2  = "l";
			else if(r2 == 12)
				code2  = "m";
			else if(r2 == 13)
				code2  = "n";
			else if(r2 == 14)
				code2  = "o";
			else if(r2 == 15)
				code2  = "p";
			else if(r2 == 16)
				code2  = "q";
			else if(r2 == 17)
				code2  = "r";
			else if(r2 == 18)
				code2  = "s";
			else if(r2 == 19)
				code2  = "t";
			else if(r2 == 20)
				code2  = "u";
			else if(r2 == 21)
				code2  = "v";
			else if(r2 == 22)
				code2  = "w";
			else if(r2 == 23)
				code2  = "x";
			else if(r2 == 24)
				code2  = "y";
			else if(r2 == 25)
				code2  = "z";
			else
				code2 = "ERROR";

			//Letter 1
			int r3 = ran.Next(26);

			if(r3 == 0)
				code3 = "a";
			else if(r3 == 1)
				code3 = "b";
			else if(r3 == 2)
				code3  = "c";
			else if(r3 == 3)
				code3  = "d";
			else if(r3 == 4)
				code3  = "e";
			else if(r3 == 5)
				code3  = "f";
			else if(r3 == 6)
				code3  = "g";
			else if(r3 == 7)
				code3  = "h";
			else if(r3 == 8)
				code3  = "i";
			else if(r3 == 9)
				code3  = "j";
			else if(r3 == 10)
				code3  = "k";
			else if(r3 == 11)
				code3  = "l";
			else if(r3 == 12)
				code3  = "m";
			else if(r3 == 13)
				code3  = "n";
			else if(r3 == 14)
				code3  = "o";
			else if(r3 == 15)
				code3  = "p";
			else if(r3 == 16)
				code3  = "q";
			else if(r3 == 17)
				code3  = "r";
			else if(r3 == 18)
				code3  = "s";
			else if(r3 == 19)
				code3  = "t";
			else if(r3 == 20)
				code3  = "u";
			else if(r3 == 21)
				code3  = "v";
			else if(r3 == 22)
				code3  = "w";
			else if(r3 == 23)
				code3  = "x";
			else if(r3 == 24)
				code3  = "y";
			else if(r3 == 25)
				code3  = "z";
			else 
				code3 = "ERROR";

			
			#endregion



			Console.WriteLine("I am the code master\nI am thinking of a password consisting of 3 letters\nI will tell you how your guess relates to my answer alphabeticly.");
			
			do
			{
			
				Console.Write("Guess the password:");

				guess = Console.ReadLine();

				Console.WriteLine("\n");

				guess1 = guess[0].ToString();
				guess2 = guess[1].ToString();
				guess3 = guess[2].ToString();

			

				//letter 0:


				if (guess[0].CompareTo(code1[0]) == 0)
					Console.WriteLine("The first letter is correct");
				else if (guess[0].CompareTo(code1[0]) > -1)
					Console.WriteLine("The first letter of the code comes before the first letter you entered");
				else if (guess[0].CompareTo(code1[0]) < 1) 
					Console.WriteLine("The first letter of the code comes after the first letter you entered");
					
			 
				//letter 1:
			


				if (guess[1].CompareTo(code2[0]) == 0)
					Console.WriteLine("The second letter is correct");
				else if (guess[1].CompareTo(code2[0]) > -1)
					Console.WriteLine("The second  letter of the code comes before the second  letter you entered");
				else if (guess[1].CompareTo(code2[0]) < 1) 
					Console.WriteLine("The second  letter of the code comes after the second  letter you entered");
			 
				//letter 2:

				if (guess[2].CompareTo(code3[0]) == 0)
					Console.WriteLine("The third letter is correct");
				else if (guess[2].CompareTo(code3[0]) > -1)
					Console.WriteLine("The third letter of the code comes before the third letter you entered");
				else if (guess[2].CompareTo(code3[0]) < 1) 
					Console.WriteLine("The third letter of the code comes after the third letter you entered");
					

				Console.WriteLine("\n");
				

			}
				while(guess1 != code1 || guess2 != code2 || guess3 != code3);
			 
			Console.WriteLine("Congratulations! You guessed me code. Good work!");
		}
	}
}
