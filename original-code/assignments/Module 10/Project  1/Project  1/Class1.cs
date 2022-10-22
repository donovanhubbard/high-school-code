using System;

namespace Project__1
{

	//Concepts Covered: a. Create and use an inherited Class
	//					b. Use abstraction in a class
	//					c. Use all access modifiers
	//What does the program do: The program has created to derived classes from the food
	//	parent class. These derived classes then each add a new variable to the pot. Then
	//	the program displays all the atributes
	//What did I learn: I now know how inheritence works, expecially the constructors. 
	//	I also learned about the different acsess modifiers.
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//Build the objects
			Fruit Cherry = new Fruit(54.2, "Cherry", 48);
			Candy SugarStyx = new Candy(99.9, "Sugar Styx", 844845);

			//Inital Fruit
			Console.WriteLine("Your Fruit is called a "+Cherry.GetName());
			Console.WriteLine("It has {0} calories and {1}% of your daily requirement of Vitamin C", Cherry.GetCalories(), Cherry.GetVitamin()); 

			//Alter fruit
			Cherry.ChangeName("Uber Cherry");
			Cherry.AddVitamin(73);
			Cherry.AddCalories(87);

			//Display fruit again
			Console.WriteLine("We added some Vitamin C, now the fruit is called an {0}", Cherry.GetName());
			Console.WriteLine("Now {0} has {1} calories \nand contains {2}% of your daily requirement of Vitamin C\n\n", Cherry.GetName(), Cherry.GetCalories(), Cherry .GetVitamin());

			//Display Candy
			Console.WriteLine("Your Candy is named "+SugarStyx.GetName());
			Console.WriteLine("It has {0} calories and {1}% of your daily requirement of Sugar", SugarStyx.GetCalories(), SugarStyx.GetSugar()); 

			//Alter the Candy
			SugarStyx.ChangeName("Supa-Sugar Styx");
			SugarStyx.AddSugar(157);
			SugarStyx.AddCalories(648445);

			//Display Candy again
			Console.WriteLine("We added some sugar, now they are called "+SugarStyx.GetName());
			Console.WriteLine("They have {0} calories and contains {1}% of your daily requriment of sugar", SugarStyx.GetCalories(), SugarStyx.GetSugar());
		}
	}

	public abstract class Food
	{
		protected string name;
		protected int calories;

		public Food(string name, int calories)
		{
			this.name = name;
			this.calories = calories;
		}
		
		public string GetName()
		{
			return this.name;
		}

		public int GetCalories()
		{
			return this.calories;
		}

		public void AddCalories(int addCalories)
		{
			this.calories += addCalories;
		}

		public void ChangeName(string name)
		{
			this.name = name;
		}
	}

	public class Fruit : Food
	{
		private double vitaminC;

		public Fruit(double vitaminC, string name, int calories) : base(name, calories)
		{
			this.vitaminC = vitaminC;
		}

		public void AddVitamin(double addVitamin)
		{
			this.vitaminC += addVitamin;
		}

		public double GetVitamin()
		{
			return this.vitaminC;
		}
	}
	public class Candy : Food
	{
		private double sugar;

		public Candy(double sugar, string name, int calories) : base(name, calories)
		{
			this.sugar = sugar;
		}

		public double GetSugar()
		{
			return this.sugar;
		}

		public void AddSugar(double sugar)
		{
			this.sugar += sugar;
		}
	}
}
