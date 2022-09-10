using System;

namespace Alphabetize
{
	
	class Class1
	{
		//this program will just take 5 strings and alphabatise them

		//Concepts Covered:Array of objects, One dimensional Array

		//What the program does: It uses array.sort to alpahabatise the array

		//What I learned: Array.Sort is very good to use in circumstances like this.
		static void Main(string[] args)
		{

			
			Console.WriteLine("This program will alphabatize 5 words.");

			
			#region get the words
			Console.Write("Please enter in the first word: ");
			string word1 = Console.ReadLine();

			Console.Write("Please enter in the second word: ");
			string word2 = Console.ReadLine();

			Console.Write("Please enter in the third word: ");
			string word3 = Console.ReadLine();

			Console.Write("Please enter in the fourth word: ");
			string word4 = Console.ReadLine();

			Console.Write("Please enter in the last word: ");
			string word5 = Console.ReadLine();
			#endregion

			

			string [] words = new string[5] {word1, word2, word3, word4, word5};

			Array.Sort(words);

			Console.WriteLine("The words in alphabetical order are:");

			for(int i=0; i<words.Length; i++)
			{
				Console.WriteLine(words[i]);
			}

			//As you know I had trouble writting this program. When you showed me 
			//the new way to alphabatise with Array.Sort it made all my old code obsolete
			//It felt like a shame to delete all 200 lines of old code so I just kept it in
			//it doesnt do anything and is all in comments but im still keeping it.
			#region Old Code
			/*
			string firstWord = "error";
			string secondWord = "error";
			string thirdWord = "error";
			string fourthWord = "error";
			string fifthWord = "error";
			*/
			
			/*
						Console.WriteLine(word1.CompareTo(word2));
						Console.WriteLine(word1.CompareTo(word3));
						Console.WriteLine(word1.CompareTo(word4));
						Console.WriteLine(word1.CompareTo(word5));

						int total = (word1.CompareTo(word2) + word1.CompareTo(word3) + word1.CompareTo(word4) + word1.CompareTo(word5));
						Console.WriteLine(total);
						Console.ReadLine();
						*/
			
			//gets the indexes of the strings when compared to eachother
			
			/*
			int total1 = word1.CompareTo(word2) + word1.CompareTo(word3) + word1.CompareTo(word4) + word1.CompareTo(word5);
			int total2 = word2.CompareTo(word1) + word2.CompareTo(word3) + word2.CompareTo(word4) + word2.CompareTo(word5);
			int total3 = (word3.CompareTo(word1) + word3.CompareTo(word2) + word3.CompareTo(word4) + word3.CompareTo(word5));
			int total4 = (word4.CompareTo(word1) + word4.CompareTo(word2) + word4.CompareTo(word3) + word4.CompareTo(word5));
			int total5 = (word5.CompareTo(word1) + word5.CompareTo(word2) + word5.CompareTo(word3) + word5.CompareTo(word4));
			*/


	/*
		
			#region puts word 1 into place


			//first word
			if (total1 == -4 || total1 == -3)
			{
				 firstWord = word1;
			}
			//second word
			if (total1 == -2 || total1 == -1)
			{
				secondWord = word1;
			}
			//third word
			if (total1 == 0 || total1 == 1)
			{
				thirdWord = word1;
			}

			//fourth word
			if (total1 == 2 || total1 == 3)
			{
				fourthWord = word1;
			}
			//fifth word
			if (total1 == 3 || total1 == 4)
			{
				fifthWord = word1;
			}
			#endregion

			#region puts word 2 into place

			
			//first word
			if (total2 == -4 || total2 == -3)
			{
				firstWord = word2;
			}
				//second word
			if (total2 == -2 || total2 == -1)
			{
				secondWord = word2;
			}
				//third word
			if (total2 == 0 || total2 == 1)
			{
				thirdWord = word2;
			}

				//fourth word
			if (total2 == 2 || total2 == 3)
			{
				fourthWord = word2;
			}
				//fifth word
			if (total2 == 3 || total2 ==4)
			{
				fifthWord = word2;
			}
			#endregion

			#region puts word 3 into place

			
			//first word
			if (total3 == -4 || total3 == -3)
			{
				firstWord = word3;
			}
				//second word
			if (total3 == -2 || total3 == -1)
			{
				secondWord = word3;
			}
				//third word
			if (total3 == 0 || total3 == 1)
			{
				thirdWord = word3;
			}

				//fourth word
			if (total3 == 2 || total3 ==3)
			{
				fourthWord = word3;
			}
				//fifth word
			if (total3 == 3 || total3 == 4)
			{
				fifthWord = word3;
			}
			#endregion

			#region puts word 4 into place

			
			//first word
			if (total4 == -4 || total4 == -3)
			{
				firstWord = word4;
			}
				//second word
			if (total4 == -2 || total4 == -1)
			{
				secondWord = word4;
			}
				//third word
			if (total4 == 0 || total4 == 1)
			{
				thirdWord = word4;
			}

				//fourth word
			if (total4 == 2 || total4 == 3)
			{
				fourthWord = word4;
			}
				//fifth word
			if (total4 == 3 || total4 == 4)
			{
				fifthWord = word4;
			}
			#endregion

			#region puts word 5 into place

			
			//first word
			if (total5 == -4 || total5 == -3)
			{
				firstWord = word5;
			}
				//second word
			if (total5 == -2 || total5 == -1)
			{
				secondWord = word5;
			}
				//third word
			if (total5 == 0 || total5 == 1)
			{
				thirdWord = word5;
			}

				//fourth word
			if (total5 == 2 || total5 == 3)
			{
				fourthWord = word5;
			}
				//fifth word
			if (total5 == 3 || total5 == 4)
			{
				fifthWord = word5;
			}
			#endregion
			
	*/


			
			//Console.WriteLine("\n\nThe words in alphabetical order are:\n"+firstWord+"\n"+secondWord+"\n"+thirdWord+"\n"+fourthWord+"\n"+fifthWord);

			#endregion


			
		}
	}
}
