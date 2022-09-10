using System;

namespace Project_1
{

	class Class1
	{
		//This program will add up the number of vowels in the sentence the user gives me
		static void Main(string[] args)
		{
							//the number of times each vowel appears
			int a = 0;
			int e = 0;
			int i = 0;
			int o = 0;
			int u = 0;
			int length;
			
				//gets the sentence from the user
			Console.WriteLine("Please enter a sentence: ");
			string sentence = Console.ReadLine();
			//gives me the length
			length = sentence.Length;

			//each for loop goes in and checks individually each index for the vowel

			
			//the letter a
			for(int j=0; j<length; j++)
			{
				if(sentence[j].ToString() == "a")
					a++;
			}
			//the letter e
			for(int j=0; j<length; j++)
			{
				if(sentence[j].ToString() == "e")
					e++;
			}
			//letter i
			for(int j=0; j<length; j++)
			{
				if(sentence[j].ToString() == "i")
					i++;
			}

			//letter o
			for(int j=0; j<length; j++)
			{
				if(sentence[j].ToString() == "o")
					o++;
			}

			//letter u
			for(int j=0; j<length; j++)
			{
				if(sentence[j].ToString() == "u")
					u++;
			}
			Console.WriteLine("The sentence contains:\na-{0}\ne-{1}\ni-{2}\no-{3}\nu-{4}",a,e,i,o,u);
		}
	}
}
