using System;

namespace Battleship
{

	class Class1
	{
		//This will be a lame battleship game. You can't really lose
		//It's just you firing at the enemy
		//If it doesn't run the first time, just run it a few more times, that should work

		//Concepts covered:
		//Generating random numbers
		//passing arrays to methods
		//Creating and using a multidimensional array

		//What the program does:
		//a 10 by 10 multidemnsional array is initialized and used for the map,
		//several other multidemenosional arrays are made for each ship to hold the coordinates that they are located at in the map
		//a coordinate is entered in by the user and the array is checked to see if it is a ship
		
		//What I learned:
		//By doing this program I now know how to pull up the correct spot in an
		//multidemensional array, and I better understand the logical opperators (because I got stuck for an hour and a half when i used the wrong one)

		static void Main(string[] args)
		{
			//a 10 by 10 map
			//0 means blank un hit
			//1 means blank hit
			
			//2 means destroyer un hit
			//3 means destroyer hit

			//4 means sub un hit
			//5 means sub hit

			int [,] map = new int [10, 10];

			//initalizes all locations to 0

			
			#region initalize map
			for(int x = 0; x < 10; x++)
			{
				for (int y = 0; y < 10; y++)
					map[x,y] = 0;
			}

			#endregion
										  
			//random number used for ship placement
			Random r1 = new Random();


			#region Ship Placement

			#region Destroyer Placement

			int[,] destroyer = new int[2,2];

			destroyer [0,0] = r1.Next(10);	//starting x co-ordinate
			destroyer [0,1] = r1.Next(10);  //starting y co-ordinate

			/*   array destroyer
			 *					r co-ordinate	c co-ordinate
			 * 1st, segment			0,0			1,0
			 * 2nd, segment			0,1			1,1
			 */

			//stashes the next segment of the ship
			//x co-ordinate

			//this only puts the ship in horiontaly
			destroyer [1,0] = destroyer [0,0];

			//column co-ordinate
			if(destroyer [0,1] == 9)
				destroyer [1,1] = 8;
			else
				destroyer [1,1] = destroyer [0,1] + 1;

			//now we put the coordinates into the map
			map [destroyer [0,0], destroyer [0,1]] = 2;
			map [destroyer [1,0], destroyer [1,1]] = 2;


			#endregion

			#region Submarine Placement

			int[,] submarine = new int[3,2];

			
			//this do while loop should help prevent the ships being placed on top of eachother
			do
			{
				submarine [0,0] = r1.Next(10);	//starting row co-ordinate
				submarine [0,1] = r1.Next(8);  //starting column co-ordinate
	
			} 
			while((map[submarine[0,0], submarine[0,1]] != 0) || (map[submarine[0,0], (submarine[0,1]+2)] !=0));


			/*   array submarine
			 *					r co-ordinate	c co-ordinate
			 * 1st, segment			0,0			0,1
			 * 2nd, segment			1,0			1,1
			 * 3rd, Segment			2,0			2,1
			 */

			//stashes the next segment of the ship
			//x co-ordinate

			//this only puts the ship in horiontaly
			submarine [1,0] = submarine [0,0];
			submarine [2,0] = submarine [0,0];

			//column co-ordinate

			submarine [1,1] = submarine [0,1] + 1;
			submarine [2,1] = submarine [0,1] + 2;

			//now we put the coordinates into the map
			map [submarine [0,0], submarine [0,1]] = 4;
			map [submarine [1,0], submarine [1,1]] = 4;
			map [submarine [2,0], submarine [2,1]] = 4;


			#endregion

			#region Cruiser Placement

			int[,] cruiser = new int[3,2];

			
			//this do while loop should help prevent the ships being placed on top of eachother
			do
			{
				cruiser [0,0] = r1.Next(10);	//starting row co-ordinate
				cruiser [0,1] = r1.Next(8);  //starting column co-ordinate
	
			} 
			while((map[cruiser[0,0], cruiser[0,1]] != 0) || (map[cruiser[0,0], (cruiser[0,1]+2)] !=0));


			/*   array cruiser
			 *					r co-ordinate	c co-ordinate
			 * 1st, segment			0,0			0,1
			 * 2nd, segment			1,0			1,1
			 * 3rd, Segment			2,0			2,1
			 */

			//stashes the next segment of the ship
			//x co-ordinate

			//this only puts the ship in horiontaly
			cruiser [1,0] = cruiser [0,0];
			cruiser [2,0] = cruiser [0,0];

			//column co-ordinate

			cruiser [1,1] = cruiser [0,1] + 1;
			cruiser [2,1] = cruiser [0,1] + 2;

			//now we put the coordinates into the map
			map [cruiser [0,0], cruiser [0,1]] = 6;
			map [cruiser [1,0], cruiser [1,1]] = 6;
			map [cruiser [2,0], cruiser [2,1]] = 6;


			#endregion

			#region Battleship Placement

			int[,] battleship = new int[4,2];

			
			//this do while loop should help prevent the ships being placed on top of eachother
			do
			{
				battleship [0,0] = r1.Next(10);	//starting row co-ordinate
				battleship [0,1] = r1.Next(7);  //starting column co-ordinate
	
			} 
			while((map[battleship [0,0], battleship[0,1]] != 0) || (map[battleship [0,0], (battleship [0,1]+2)] !=0) ||(map[battleship [0,0], (battleship [0,1]+4)] !=0));


			/*   array battleship
			 *					r co-ordinate	c co-ordinate
			 * 1st, segment			0,0			0,1
			 * 2nd, segment			1,0			1,1
			 * 3rd, segment			2,0			2,1
			 * 4th, segment			3,0			2,1
			 */

			//stashes the next segment of the ship
			//x co-ordinate

			//this only puts the ship in horiontaly
			battleship [1,0] = battleship [0,0];
			battleship [2,0] = battleship [0,0];
			battleship [3,0] = battleship [0,0];

			//column co-ordinate

			battleship [1,1] = battleship [0,1] + 1;
			battleship [2,1] = battleship [0,1] + 2;
			battleship [3,1] = battleship [0,1] + 3;

			//now we put the coordinates into the map
			map [battleship [0,0], battleship [0,1]] = 8;
			map [battleship [1,0], battleship [1,1]] = 8;
			map [battleship [2,0], battleship [2,1]] = 8;
			map [battleship [3,0], battleship [3,1]] = 8;


			#endregion

			#region Carrier Placement

			int[,] carrier = new int[5,2];

			
			//this do while loop should help prevent the ships being placed on top of eachother
			do
			{
				carrier [0,0] = r1.Next(10);	//starting row co-ordinate
				carrier [0,1] = r1.Next(6);  //starting column co-ordinate
	
			} 
			while((map[carrier [0,0], carrier[0,1]] != 0) || (map[carrier [0,0], (carrier [0,1]+2)] !=0) ||(map[carrier [0,0], (carrier [0,1]+4)] !=0) || (map[carrier [0,0], (carrier [0,1]+5)] !=0));


			/*   array carrier
			 *					r co-ordinate	c co-ordinate
			 * 1st, segment			0,0			0,1
			 * 2nd, segment			1,0			1,1
			 * 3rd, segment			2,0			2,1
			 * 4th, segment			3,0			3,1
			 * 5th, segment			4,0			4,1
			 */

			//stashes the next segment of the ship
			//x co-ordinate

			//this only puts the ship in horiontaly
			carrier [1,0] = carrier [0,0];
			carrier [2,0] = carrier [0,0];
			carrier [3,0] = carrier [0,0];
			carrier [4,0] = carrier [0,0];

			//column co-ordinate

			carrier [1,1] = carrier [0,1] + 1;
			carrier [2,1] = carrier [0,1] + 2;
			carrier [3,1] = carrier [0,1] + 3;
			carrier [4,1] = carrier [0,1] + 4;

			//now we put the coordinates into the map
			map [carrier [0,0], carrier [0,1]] = 10;
			map [carrier [1,0], carrier [1,1]] = 10;
			map [carrier [2,0], carrier [2,1]] = 10;
			map [carrier [3,0], carrier [3,1]] = 10;
			map [carrier [4,0], carrier [4,1]] = 10;


			#endregion

			#endregion




			
			
			
			while(CheckDestroyer(map) == true || CheckSubmarine(map) == true || CheckCruiser(map) == true || CheckBattleship(map) == true || CheckCarrier(map) == true)		//temporary infinte loop for testing
			{

				Map(map);
				Console.Write("Please enter the row you would like to shoot: ");
				int row = int.Parse(Console.ReadLine());
				Console.Write("Please enter the column you would like to shoot: ");
				int column = int.Parse(Console.ReadLine());
				Console.WriteLine("\n");

				if(row > 9 || row <0 || column > 9 || column <0)
					Console.WriteLine("You didn't put in a valid firing coordinate!");
					

				else
				{
					//now we have the users firing coordinates

					Shoot(map, row, column);
				}
				
				Console.ReadLine();
				Console.WriteLine("\n\n");

				
				

			}

			Console.WriteLine("\n\n\n\n\n\n\n\nCongratulations, you beat the game!");
			Console.WriteLine("I hope ou enjoyed playing this game.");



			

			

				


		}


		
		//shoot at the vessels
		public static void Shoot(int[,] map, int row, int column)
		{
			//hit blank
			if (map [row, column ] == 0)
			{
				Console.WriteLine("You missed you bloody loser!");
				map [row, column] = 1;
			}

				#region Hit ships codeing
			
				#region Hit Destroyer
			else if (map [row, column] == 2)
			{
				Console.WriteLine("Blimey! You hit their Destroyer!");
				map [row, column] = 3;

				//tells you if you sunk their ship
				if(CheckDestroyer(map) == false)
					Console.WriteLine("Good job matey, you sunk their destroyer!");
			}
				#endregion Destroyer

				#region Hit Submarine
			else if (map [row, column] == 4)
			{
				Console.WriteLine("Holy depth charge, you hit their submarine!");
				map [row, column] = 5;

				//tells you if you sunk their ship
				if(CheckSubmarine(map) == false)
					Console.WriteLine("Arrrrr.... the enemey submarine is sunk!");
			}
				#endregion

				#region Hit Cruiser
			else if (map [row, column] == 6)
			{
				Console.WriteLine("Blow me bagpipes you hit their Cruiser!");
				map [row, column] = 7;

				//tells you if you sunk their ship
				if(CheckCruiser(map) == false)
					Console.WriteLine("Yar, you sent their cruiser to Davey Jone's Locker!");
			}
				#endregion

				#region Hit Battleship
			else if (map [row, column] == 8)
			{
				Console.WriteLine("What Ho? You hit their battleship");
				map [row, column] = 9;

				//tells you if you sunk their ship
				if(CheckBattleship(map) == false)
					Console.WriteLine("The enemy battleship is sleeping with the fishes.");
			}
				#endregion

				#region Hit Carrier
			else if (map [row, column] == 10)
			{
				Console.WriteLine("Sweet mother of napalm! You hit the carrier!");
				map [row, column] = 11;

				//tells you if you sunk their ship
				if(CheckCarrier(map) == false)
					Console.WriteLine("Enemy Carrier sunk!");
			}
				#endregion
				
				
				#endregion
			
				
				//fire at the same spot
			else 
			{
				Console.WriteLine("Hey Captin Moron! You've already fired there!");
			}

		}
		


		//checks to see if the destroyer is alive
		//true means it's alive, false means its dead

		#region Check Ships Coding
		
		#region CheckDestroyer
		public static bool CheckDestroyer(int[,] map)
		{
			int destroyerHitCount = 0;
			
			//for loop to travel through the whole map adding things
			for(int i=0; i<10; i++)
			{
				for(int g=0; g<10; g++)
				{
					if( map [i,g] == 3)
						destroyerHitCount++;
				}	
			}

			if (destroyerHitCount == 2)
				return false;
			else 
				return true;
		}
		#endregion

		#region CheckSubmarine
		public static bool CheckSubmarine(int[,] map)
		{
			int submarineHitCount = 0;
			
			//for loop to travel through the whole map adding things
			for(int i=0; i<10; i++)
			{
				for(int g=0; g<10; g++)
				{
					if( map [i,g] == 5)
						submarineHitCount++;
				}	
			}

			if (submarineHitCount == 3)
				return false;
			else 
				return true;
		}
		#endregion

		#region CheckCruiser
		public static bool CheckCruiser(int[,] map)
		{
			int cruiserHitCount = 0;
			
			//for loop to travel through the whole map adding things
			for(int i=0; i<10; i++)
			{
				for(int g=0; g<10; g++)
				{
					if( map [i,g] == 7)
						cruiserHitCount++;
				}	
			}

			if (cruiserHitCount == 3)
				return false;
			else 
				return true;
		}
		#endregion

		#region CheckBattleship
		public static bool CheckBattleship(int[,] map)
		{
			int battleshipHitCount = 0;
			
			//for loop to travel through the whole map adding things
			for(int i=0; i<10; i++)
			{
				for(int g=0; g<10; g++)
				{
					if( map [i,g] == 9)
						battleshipHitCount++;
				}	
			}

			if (battleshipHitCount == 4)
				return false;
			else 
				return true;
		}
		#endregion

		#region CheckCarrier
		public static bool CheckCarrier(int[,] map)
		{
			int carrierHitCount = 0;
			
			//for loop to travel through the whole map adding things
			for(int i=0; i<10; i++)
			{
				for(int g=0; g<10; g++)
				{
					if( map [i,g] == 11)
						carrierHitCount++;
				}	
			}

			if (carrierHitCount == 5)
				return false;
			else 
				return true;
		}
		#endregion


		#endregion


		//Displays the map for your coneinence
		public static void Map(int[,]map)
		{
			int row = 0;
			Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("  -------------------");
			for(int x = 0; x < 10; x++)
			{
				
				Console.Write(row+"|");		

				for (int y = 0; y < 10; y++)
				{
	

					if(map[x,y] == 0 || map[x,y] == 2 || map[x,y] == 4 || map[x,y] == 6 || map[x,y] == 8 || map[x,y] == 10)
						Console.Write(" ");
					else if(map[x,y] == 1)
						Console.Write("-");
					else
						Console.Write("X");

					Console.Write("|");


				}
				row++;
				Console.WriteLine();
					
			}
		}

		
										 
	}
	}
