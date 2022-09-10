using System;

namespace Example_6_2
{
	//Illustrates String comparisons
	class Class1
	{
		//Concepts covered String Comparisons
		//This program uses string comparisons, but my alphabatise program is better.
		//What I learned: Well, I learned that .Equals is the same as ==
		//Checks ==, Equals, and CompareTo
		static void Main(string[] args)
		{
			string s = "a houseboat";
			string s1 = "house";
			string s2 = s.Substring(2,5);
			string s3 = "horse";
			string s4 = s1;
			Console.WriteLine("s1 == s2 is {0}", s1 == s2);

			Console.WriteLine("s1.Equals(s2) is {0}", s1.Equals(s2));

			string w1 = "Apple";
			string w2 = "apple";
			string w3 = "butter";
			Console.WriteLine("{0} compared o {1} is {2}", w1, w2, w1.CompareTo(w2));

			Console.WriteLine("{0} compared to {1} is {2}", w1, w3, w1.CompareTo(w3));
		}
	}
}
