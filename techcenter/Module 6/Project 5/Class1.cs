using System;

namespace Project_5
{

	class Class1
	{
		//This program will display you party configuration
		static void Main(string[] args)
		{
			Pc Don = new Pc(10000000, "Don", "The Totaly Wicked Bad");
			Pc Data = new Pc(50, "Data", "Wimpy Android");
			Pc DonkeyKong = new Pc(80, "Donkey Kong", "Really annoyed Ape");
			Pc CheatCommando = new Pc(800, "Renold", "A Cheat Commando");



			Pc[] players = new Pc[4] {Don, Data, DonkeyKong, CheatCommando};

			Console.WriteLine("Your configuration is:");
			for(int i = 0; i<4; i++)
			{
				Console.WriteLine(players[i]);
		}


	}

	}

	class Pc
	{
		#region Instance variables
		private string name;
		private string title;
		private int health;
		#endregion

		//constructor
		public Pc(int health, string name, string title)
		{
			this.health = health;
			this.name = name;
			this.title = title;
		}

		public override string ToString()
		{
			return this.name+"-"+this.title+"-"+this.health+" HP";
		}



	}
}
