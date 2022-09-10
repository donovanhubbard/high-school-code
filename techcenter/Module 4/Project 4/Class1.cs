using System;

namespace Example_4
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{

		//This program will have several cats walk and jump around
		static void Main(string[] args)
		{
			//Make new cats
			Cat cat1 = new Cat(5, 1, 15);
			Cat cat2 = new Cat();
			Cat cat3 = new Cat();

			//Make 'em Run!
			cat1.Walk(4,6);
			cat1.Jump(10);
			cat2.Walk(-4,7);
			cat2.Jump(-4);
			cat3.Walk(32, 43);
			cat3.Jump(2332);

			//display positions
			Console.WriteLine("\n\nThe cat's positions are:\n");
			
			Console.WriteLine("Cat 1:\t\t "+cat1.GetX()+", "+cat1.GetY()+", "+cat1.GetZ());
			Console.WriteLine("Cat 2:\t\t "+cat2.GetX()+", "+cat2.GetY()+", "+cat2.GetZ());
			Console.WriteLine("Cat 3:\t\t "+cat3.GetX()+", "+cat3.GetY()+", "+cat3.GetZ());

			Console.WriteLine();
			

		}
	}

	class Cat
	{
		//these instance variables hold the location of a cat....
		//they are the x, y, and z coordinates

		private int x;
		private int y;
		private int z;

		
		//constructor
		public Cat(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		
		public Cat()
		{
			this.x = 0;
			this.y = 0;
			this.z = 0;
		}
		
		
		//walks the cat to a different horizontal point
		public void Walk (int x, int y)
		{
			this.x += x;
			this.y += y;
		}

		//makes the cat jump. Jump cat jump!
		public void Jump (int z)
		{
			this.z += z;
		}

		//displays the cat's position
		public int GetX()
		{
			return this.x;

		}
		public int GetY()
		{
			return this.y;

		}
		public int GetZ()
		{
			return this.z;

		}
	}
}
