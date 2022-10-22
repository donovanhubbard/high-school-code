using System;
using System.Collections;

namespace Project_1
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]

		//concepts covered: Queues and Stacks

		//What the program does:
		//The user will enter in a string, each character is then loaded into a queue and stack
		//and compared against eachother. This will test to see if it is a palindrome. Then
		//the computer will tell you wether or no it is a palindrome

		//What I learned: I understand how to use  stacks and queues. You have to load each character
		//in individually otherwise the queue/stack will only be one element that contains a string
		static void Main(string[] args)
		{
			bool palindrome = true;	//the boolean to determine whether or not the sentecne is a palindrome
			
			Console.WriteLine("This program willl determine whether or not a given sentence is a palindrome.\nPlease enter a sentence");
			string userString = Console.ReadLine();

			Queue queue = new Queue(userString.Length);
			Stack stack = new Stack(userString.Length);

			for(int i = 0; i < userString.Length; i++)
			{
				queue.Enqueue(userString[i]);
			}
			for(int i = 0; i < userString.Length; i++)
			{
				stack.Push(userString[i]);
			}
			
			
			for (int i = 0; i < userString.Length; i++)
			{
				if(queue.Peek().ToString() != stack.Peek().ToString() && palindrome == true)
				{
					palindrome = false;
				}
			}

			if(palindrome)
			{
				Console.WriteLine("Good Job that is a palindrome");
			}

			else
				Console.WriteLine("That is not a palindrome!");
		}

	


			

		}
	}

