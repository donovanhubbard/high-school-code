using System;

namespace Interface_Thing
{

	//Concept Covered: Interfac class
	//What the program does: It uses an instrument interface to make two instruments which
	//			preform various functions
	//What I learned: This simple program taught me the advantages of using an interface
	class Class1
	{
	
		static void Main(string[] args)
		{
			Sax s1 = new Sax();
			Trumpet t1 = new Trumpet();

			s1.Play();
			s1.Clean();
			s1.BreakIntoBankWith();

			t1.Play();
			t1.Clean();
			t1.BreakIntoBankWith();
		}
	}

	public interface IInstrument
	{
		void Play();
		void Clean();
		void BreakIntoBankWith();
	}

	public class Trumpet :IInstrument
	{
		#region IInstrument Members

		public void Play()
		{
			Console.WriteLine("You rock out on your trumpet.");
		}

		public void Clean()
		{
			Console.WriteLine("You open up your spit valve and spray it on the people next to you.");
		}

		public void BreakIntoBankWith()
		{
			Console.WriteLine("You try to rob a bank with trumpet.\nYour a moron!\nYou get shot and die!");
		}

		#endregion

	}

	public class Sax : IInstrument
	{
		#region IInstrument Members

		public void Play()
		{
			Console.WriteLine("You play a wicked bad melody on your sax.");
		}

		public void Clean()
		{
			Console.WriteLine("You dump all the spit out onto your shoe,\nthat's kind of gross.");
		}

		public void BreakIntoBankWith()
		{
			Console.WriteLine("You hit the guard over the head with your sax and clean the place out.");
		}

		#endregion

	}


}
