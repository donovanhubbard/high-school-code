using System;

namespace GetBushism
{

	class Class1
	{

		//this program will get a bushism and print it out
		static void Main(string[] args)
		{
			string eng;
			string pig;
			while(true)
			{
				Console.WriteLine("Enter in english sentence:");
				eng = Console.ReadLine();
				pigLatin.piglatin pg = new GetBushism.pigLatin.piglatin();
				pig = pg.toPigLatin(eng);
				Console.WriteLine(pig);
			}

		}
	}
}
