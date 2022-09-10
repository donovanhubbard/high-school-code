using System;

namespace Band_RPG
{

	/*
	 * Alright, here we go.
	 * Band RPG will be a simple text based adventure, just so I can get a feel for it.
	 * There will pretty much be about 4 rooms. You should go around the map, 
	 * get all your instrumental stuff.   Sluff and get a frosty, 
	 * poison the fish, etc. There is no real goal I guess, but you can just tink 
	 * around.
	 * 
	 * Classes, objects, control structures, input and output, and strings are found throughout
	 * the program
	 * Random numbers and arrays are used when you talk to Beau Shaw in the practice rooms
	 * Contains 1,330 lines of code and a really cool icon
	 */

	class Class1
	{

		static void Main(string[] args)
		{
			Console.WriteLine("\n\t\t\tBand RPG V. 1.00\n===============================================================================\nWritten By Donovan Hubbard\n\nBrought to you by\nMicrosoft .Net Visual Studios\n\nWelcome to the Alta High Band!\n\n");
			

			bool pass = true;		//just another pass varialbe
			int location = 0;		//keeps track of where you are
			string what = "What do you do now?";	//since i write it so many times
			string answer;			//used frequently for your answer to what to do next?
			string instrument;
			string enter = "\t\tPress Enter to Continue";

			//the Beau Shaw array
			Random  r1 = new Random();
			string [] advice = new string[7] {"Behold the power of Orange!", "Sometimes, when I lose something I find it in the trash...","When all else fails try to talk to somebody","If you don't know what to type, try the obvious.","There is lots of stuff out there, you just need to try and \"take\" it.","Maybe you should do something to show those choir kids.","If you get stuck, try looking at the readme..."};		//array of strings that beau uses to help you
			int num;



			

			#region Pick your instrument
			do
			{
				//gets your instrument
				Console.WriteLine("What instrument do you play?");
				instrument = Console.ReadLine();

				
			
				switch(instrument.ToLower())
				{
					case "sax":
					case "saxophone":
						Console.WriteLine("Ahh! The sax, a noble instrument good choice.");
						pass = true;
						break;
					case "clarinet":
						Console.WriteLine("Clarinet eh? Nothing wrong with a woodwind");
						pass = true;
						break;
					case "flute":
						Console.WriteLine("Hey! Hey! A flute, you MUST be hot!");
						pass = true;
						break;
					case "trumpet":
						Console.WriteLine("Trumpeters are cool, they can really blow their horn!");
						pass = true;
						break;
					case "tuba":
						Console.WriteLine("Tubas rock they can go lower than a jamacin limbo!");
						pass = true;
						break;
					case "trombone":
						Console.WriteLine("Trombones got it going on!");
						pass = true;
						break;
					case "french horn":
						Console.WriteLine("HA HA! What a loser! You play French Horn!");
						pass = true;
						break;
					case "oboe":
						Console.WriteLine("The oboe gots game!");
						pass = true;
						break;
					case "basson":
						Console.WriteLine("That's like a balloon with s\'s");
						pass = true;
						break;
					case "percussion":
						Console.WriteLine("Your a freak!");
						pass = true;
						break;
					default:
						Console.WriteLine("Didn't catch that.. be less specific (like try sax instead of tenor sax)");
						pass = false;
						break;
				}
			}
				while (pass == false);
			Console.WriteLine("\t\t\tPress Enter to continue\n\n");
			
			Player p1 = new Player(instrument);

			Console.ReadLine();
			pass = false;


			#endregion 

			#region Rooms


			
			//this is the loop that will continue the whole game
			//it just circles through the locations until it finds the 
			//one you are in
			while (p1.GetPoints() != 60)
			{
			
				#region 0: Outside band room, The Hall
				//location 0: Outside the band room
				while (pass == false && location == 0)
				{
			
					#region End Game Message
					if(p1.GetPoints()==60)
					{
						Tab();
						Tab();
						Console.WriteLine("Hey, you've done everything!\nYou got all 60 points!");
						Console.WriteLine("Good work! You beat my game!\nHopefully it wasn't too frustrating.\nIsn't it cool though?\nWell thanks again for playing!");
						Console.WriteLine(enter);
						Console.ReadLine();
						Tab();
						Tab();
						Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- Thank You For Playing! ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n\n\n\n\n\n\n");
						Console.ReadLine();
						return;
					}
					#endregion

					Console.WriteLine("\n\n\nYou are in the hall outside of the bandroom.\nThere are several choir kids sitting near by and your locker is right there.\nObvious exits: Bandroom, Locker, Outside");
					Tab();
					Console.WriteLine(what);
					answer = Console.ReadLine();
					//lowercases it so you can read it
					answer = answer.ToLower();
				
		
					//the move commands
					//locker
					if (answer.IndexOf("locker") > -1)
					{
						location = 1;
						pass = true;
					}
						//outside, to the parking lot
					else if (answer.IndexOf("outside") > -1)
					{
						location = 2;
						pass = true;
					}	
					
						//bandroom
					else if (answer.IndexOf("bandroom") > -1)
					{
						location = 3;
						pass = true;
					}


					else if(answer.IndexOf("talk") > -1 && answer.IndexOf("kids") < 0)
					{
						Console.WriteLine("talk to who, yourself?\n\n\n");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
				
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("kids") > -1)
					{
						Console.WriteLine("The choir folk yell at you for being a band geek.\nYou become ashamed and leave them alone.\n\n\n");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
				
						//give fish to 'em
					else if (answer.IndexOf("give") > -1 && answer.IndexOf("fish") > -1 && p1.CheckFish() == true && p1.CheckUsedFish() == false)
					{
						Console.WriteLine("The choir people get disgusted and throw up, good work");
						p1.UseFish();
						p1.AddPoints(5);
						Console.WriteLine(enter);
						Console.ReadLine();
					}
					
					else if (answer.IndexOf("look") > -1)
					{
						Console.WriteLine("Not much to see, a dirty floor with a tampico spill, the choir kids,\nand the band door.\n\n\n");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("eat frostie") > -1 && p1.CheckFrostie() == true)
					{
						Console.WriteLine("You don't want to eat that now");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("inv") > -1)
					{
						p1.GetInv();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("help") > -1)
					{
						Console.WriteLine("You could try looking at your inventory by typing inv,\nOr look around by typing look.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("play") > -1 && answer.IndexOf(instrument) > -1)
					{
						Console.WriteLine("\a\a\aYou play your instrument, you look around to see if anybody noticed.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else
					{
						Console.WriteLine("I don't understand that");
						Console.WriteLine(enter);
						Console.ReadLine();
						Console.WriteLine("\n\n\n");
					}

				} //end of while loop

				pass = false;

				#endregion

				#region 1: Your locker
				//location 1: Your locker
				while (pass == false && location == 1)
				{
			
					#region End Game Message
					if(p1.GetPoints()==60)
					{
						Tab();
						Tab();
						Console.WriteLine("Hey, you've done everything!\nYou got all 60 points!");
						Console.WriteLine("Good work! You beat my game!\nHopefully it wasn't too frustrating.\nIsn't it cool though?\nWell thanks again for playing!");
						Console.WriteLine(enter);
						Console.ReadLine();
						Tab();
						Tab();
						Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- Thank You For Playing! ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n\n\n\n\n\n\n");
						Console.ReadLine();
						return;
					}
					#endregion

					Console.WriteLine("\n\n\nYou find yourself at your locker\nIt's pretty bashed up, with scuff marks on it.\nA garbage can is nearby.\nObvious exits: Back to the hall");
					Tab();
					Console.WriteLine(what);
					answer = Console.ReadLine();
					//lowercases it so you can read it
					answer = answer.ToLower();
				
		
					//the move commands
					//hall
					if (answer.IndexOf("hall") > -1)
					{
						location = 0;
						pass = true;
					}


					else if(answer.IndexOf("talk") > -1 && answer.IndexOf("cool kids") < 0)
					{
						Console.WriteLine("talk to who, yourself?\n\n\n");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
				
				
					else if (answer.IndexOf("look") > -1 && answer.IndexOf("garbage") == -1)
					{
						Console.WriteLine("Your locker is painted black unlike the others.\nThe nearby garbage can seems to be full\n\n");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//open lock without the combo
					else if (answer.IndexOf("open locker") > -1 && p1.CheckCombo() == false)
					{
						Console.WriteLine("You fumble through the combination, but you realise that you forgot it.\nYour locker must remain closed until you remeber the combination.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//open lock with the combo
					else if(answer.IndexOf("open locker") > -1 && p1.CheckCombo() == true && (p1.CheckTape() == false && p1.CheckUsedTape() == false))
					{
						Console.WriteLine("You use your combination and open up the locker\nInside you find a roll of duct tape,\nYou take it.");
						p1.AddPoints(5);
						p1.AddTape();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//try to take tape when you already have it
					else if(answer.IndexOf("take") > -1 && answer.IndexOf("tape") > -1 && p1.CheckTape() == true)
					{
						Console.WriteLine("You already have that.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//try to take SPK again
					else if(answer.IndexOf("take") > -1 && answer.IndexOf("sour patch kids") > -1 && p1.CheckSPK() == true)
					{
						Console.WriteLine("You already have that.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//open locker again
					else if(answer.IndexOf("open locker") > -1 && p1.CheckCombo() == true && (p1.CheckTape() == true || p1.CheckUsedTape() == true))
					{
						Console.WriteLine("There is nothing usefull inside your locker");

						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("inv") > -1)
					{
						p1.GetInv();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("help") > -1)
					{
						Console.WriteLine("You could try looking at your inventory by typing inv,\nOr look around by typing look.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//gives you SPK
					else if (((answer.IndexOf("look") > -1) || answer.IndexOf("search") > -1) && (answer.IndexOf("garbage") > -1) && p1.CheckSPK() == false)
					{
						Console.WriteLine("You rumage through the garbage juice and find some Sour Patch Kids.\nYou now have Sour Patch Kids.");
						p1.AddSPK();
						p1.AddPoints(5);
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if ((answer.IndexOf("look") > -1) && (answer.IndexOf("garbage") > -1) &&( p1.CheckUseSPK() == true || p1.CheckSPK() == true))
					{
						Console.WriteLine("You find nothing of value in the garbage.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("eat frostie") > -1 && p1.CheckFrostie() == true)
					{
						Console.WriteLine("You don't want to eat that now");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("play") > -1 && answer.IndexOf(instrument) > -1)
					{
						Console.WriteLine("\a\a\aYou play your instrument, you look around to see if anybody noticed.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else
					{
						Console.WriteLine("I don't understand that");
						Console.WriteLine(enter);
						Console.ReadLine();
						Console.WriteLine("\n\n\n");
					}

				} //end of while loop
				pass = false;

				#endregion

				#region 2: Outside, The Parking Lot

				while (pass == false && location == 2)
				{
			
					#region End Game Message
					if(p1.GetPoints()==60)
					{
						Tab();
						Tab();
						Console.WriteLine("Hey, you've done everything!\nYou got all 60 points!");
						Console.WriteLine("Good work! You beat my game!\nHopefully it wasn't too frustrating.\nIsn't it cool though?\nWell thanks again for playing!");
						Console.WriteLine(enter);
						Console.ReadLine();
						Tab();
						Tab();
						Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- Thank You For Playing! ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n\n\n\n\n\n\n");
						Console.ReadLine();
						return;
					}
					#endregion

					Console.WriteLine("\n\n\nYou are now outside the school in the parking lot\nYour car is parked in the handicaped spot");
					if (p1.CheckTicket() == false)
						Console.WriteLine("and has a pink ticket in the window.");
					Console.WriteLine("Obvious exits: Hall, backdoor to the Bandroom");
					Tab();
					Console.WriteLine(what);
					answer = Console.ReadLine();
					//lowercases it so you can read it
					answer = answer.ToLower();
				
		
					//the move commands
					//hall
					if (answer.IndexOf("hall") > -1)
					{
						location = 0;
						pass = true;
					}
						//bandroom
					else if (answer.IndexOf("bandroom") > -1)
					{
						location = 3;
						pass = true;
					}

						//look around
					else if (answer.IndexOf("look") > -1 && answer.IndexOf("ticket") == -1)
					{
						Console.WriteLine("Your car is a green '93 ford explorer,\nIt's very well taken car of.\nThe lisence plate reads \"BANDO\"");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//look ticket
					else if (answer.IndexOf("look") > -1 && answer.IndexOf("ticket") > -1)
					{
						Console.WriteLine("It's a ticket for parking in the handicapped spot.\nYou need to get that taken care of somehow...");
						Console.WriteLine(enter);
						Console.ReadLine();
					}


						//unassinged take command
					else if (answer.IndexOf("take") > -1 && answer.IndexOf("ticket") == -1)
					{
						Console.WriteLine("Take what?");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//take ticket
					else if (answer.IndexOf("take") > -1 && answer.IndexOf("ticket") > -1 && p1.CheckTicket() == false)
					{
						Console.WriteLine("You take the ticket and put it in your pocket");
						p1.AddTicket();
						p1.AddPoints(5);
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//ticket is already gone
					else if (answer.IndexOf("take") > -1 && answer.IndexOf("ticket") > -1 && p1.CheckTicket() == false)
					{
						Console.WriteLine("The ticket has already been taken");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//no keys
					else if ((answer.IndexOf("open car") > -1 || answer.IndexOf("drive") > -1) && p1.CheckKeys() == false)
					{
						Console.WriteLine("The doors are locked and you cant get in.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//tells you you dont have keys
					else if ((answer.IndexOf("keys") > -1 || answer.IndexOf("open") > -1 || answer.IndexOf("unlock") > -1) && p1.CheckKeys() == false)
					{
						Console.WriteLine("You don't have any keys.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}	
					
						//gets you inside the car and get stuff
					else if((answer.IndexOf("open car") > -1 || answer.IndexOf("drive") > -1) && p1.CheckKeys() == true && p1.CheckCombo() == false)
					{
						Console.WriteLine("You get inside the car,\nInside you find the combination to your locker");
						Console.WriteLine(enter);
						Console.ReadLine();
						
						p1.AddPoints(5);
						p1.AddCombo();
					}

						//drive nowhere
					else if (answer.IndexOf("drive") > -1 && answer.IndexOf("wendy") == -1 && p1.CheckKeys() == true && (answer.IndexOf("a") == -1 && answer.IndexOf("o") == -1 && answer.IndexOf("u") == -1 && answer.IndexOf("y") == -1))
					{
						Console.WriteLine("Where would you like to drive?");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//drive anywhere else
					else if (answer.IndexOf("drive ") > -1 && answer.IndexOf("wendy") == -1 && p1.CheckKeys() == true && (answer.IndexOf("a") > -1 || answer.IndexOf("e") > -1 || answer.IndexOf("o") > -1 || answer.IndexOf("u") > -1 || answer.IndexOf("y") > -1))					
					{
						Console.WriteLine("You can't go there now.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//go to wendy's and get a frostie
					else if (answer.IndexOf("drive") > -1 && answer.IndexOf("wendy") > -1 && p1.CheckFrostie() == false && p1.CheckKeys() == true && p1.CheckUsedFrostie() == false)
					{
						Console.WriteLine("You drive off to Wendy's.\nWhile your there you find Brandon working there and laugh at him\nHe gives you a free frosty.\nYou realise there is nothing left to do at Wendy's and go back to school.");
						Console.WriteLine(enter);
						Console.ReadLine();
						p1.AddFrostie();
						p1.AddPoints(5);
					}
						//try to go to wendy's again
					else if (answer.IndexOf("drive") > -1 && answer.IndexOf("wendy") > -1 && (p1.CheckFrostie() == true || p1.CheckUsedFrostie() == true))
					{
						Console.WriteLine("You already went there once, you don't need to sluff again!");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					
						//try to eat your frostie
					else if (answer.IndexOf("eat frosty") > -1 && p1.CheckFrostie() == true)
					{
						Console.WriteLine("You don't want to eat that now");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

															



					else if (answer.IndexOf("inv") > -1)
					{
						p1.GetInv();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("help") > -1)
					{
						Console.WriteLine("You could try looking at your inventory by typing inv,\nOr look around by typing look.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
					
					else if (answer.IndexOf("play") > -1 && answer.IndexOf(instrument) > -1)
					{
						Console.WriteLine("\a\a\aYou play your instrument, you look around to see if anybody noticed.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else
					{
						Console.WriteLine("I don't understand that");
						Console.WriteLine(enter);
						Console.ReadLine();
						Console.WriteLine("\n\n\n");
					}

				} //end of while loop
				pass = false;

				#endregion

				#region 3: The Bandroom

				while (pass == false && location == 3)
				{
			
					#region End Game Message
					if(p1.GetPoints()==60)
					{
						Tab();
						Tab();
						Console.WriteLine("Hey, you've done everything!\nYou got all 60 points!");
						Console.WriteLine("Good work! You beat my game!\nHopefully it wasn't too frustrating.\nIsn't it cool though?\nWell thanks again for playing!");
						Console.WriteLine(enter);
						Console.ReadLine();
						Tab();
						Tab();
						Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- Thank You For Playing! ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n\n\n\n\n\n\n");
						Console.ReadLine();
						return;
					}
					#endregion

					Console.WriteLine("\n\n\nYou are now inside the bandroom\nMr. Brunson is not here...\nScott is dancing around a sophmore and chanting.\nWes is standing in the corner.");
					Console.WriteLine("Obvious exits: Hall, Outside, Mr. Brunson's office, Practice rooms");
					Tab();
					Console.WriteLine(what);
					answer = Console.ReadLine();
					//lowercases it so you can read it
					answer = answer.ToLower();
				
		
					//the move commands
					//hall
					if (answer.IndexOf("hall") > -1)
					{
						location = 0;
						pass = true;
					}
						//outside
					else if (answer.IndexOf("outside") > -1)
					{
						location = 2;
						pass = true;
					}

						//Brunson's office
					else if (answer.IndexOf("brunson") > -1 && answer.IndexOf("office") > -1)
					{
						location = 4;
						pass = true;
					}

						//Practice Rooms
					else if (answer.IndexOf("practice room") > -1)
					{
						location = 5;
						pass = true;
					}


					else if (answer.IndexOf("look") > -1)
					{
						Console.WriteLine("Scott (in his Scooby Doo costume),\nand the rest of the band presidency\nseem to be worshiping the band god.\nA sophmore is tied up in the middle.\nWes also seems to be busy forging documents in the corner");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//unassinged take command
					else if (answer.IndexOf("take") > -1 && answer.IndexOf("ticket") == -1)
					{
						Console.WriteLine("Take what?");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//talk to scott
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("scott") > -1 && p1.CheckUsedFrostie() == false)
					{
						Console.WriteLine("Scott tells you that he is worshiping the band god \nand needs food as a sacrifice.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//talk to scott after you have given him frosty
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("scott") > -1 && p1.CheckUsedFrostie() == true)
					{
						Console.WriteLine("Scott once again thanks you for the sacrifice");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//talk to sophmore
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("sophmore") > -1 && p1.CheckUsedFrostie() == false)
					{
						Console.WriteLine("The sophmore pleads with you to drive to Wendy's \nto get some food for the sacrifice...");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//talk to sophmore again
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("sophmore") > -1 && p1.CheckUsedFrostie() == true)
					{
						Console.WriteLine("The sophmore is happy that you got Scott a frosty \nbut he is still tied up.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//give Scott a frosty
					else if (answer.IndexOf("give") > -1 && (answer.IndexOf("frosty") > -1 || answer.IndexOf("food") > -1) && p1.CheckFrostie() == true)
					{
						Console.WriteLine("Scott gratefully accepts the frosty\nHe sacrafices it to the bandgod and everyone cheers");
						Console.WriteLine(enter);
						Console.ReadLine();
						p1.UseFrostie();
						p1.AddPoints(10);
					}

						//give Scott a frosty after you have used it
					else if (answer.IndexOf("give") > -1 && answer.IndexOf("frosty") > -1 && p1.CheckFrostie() == false)
					{
						Console.WriteLine("You don't have that");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//talk to wes
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("wes") > -1 && p1.CheckUseTicket() == false)
					{
						Console.WriteLine("Wes says, \"Hey Nerd!\nI'm trying to remove some arrests off my criminal record\nIt's a lot harder than you think it would be.\nIf you have anything that you don't want on the books come and get me.\"");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//talk to wes again
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("wes") > -1 && p1.CheckUseTicket() == true)
					{
						Console.WriteLine("Wes says, \"You don't have to worry about that ticket anymore.\nIt's been a pleasure forging for you!\nNerd!\"");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//give Wes your ticket
					else if (answer.IndexOf("give") > -1 && answer.IndexOf("ticket") > -1 && p1.CheckTicket() == true)
					{
						Console.WriteLine("Wes hastily takes down some notes...\n\"Ok, you don't have to worry about that ticket anymore!");
						Console.WriteLine(enter);
						Console.ReadLine();
						p1.UseTicket();
						p1.AddPoints(5);
					}

						//give Scott a frosty after you have used it
					else if (answer.IndexOf("give") > -1 && answer.IndexOf("frosty") > -1 && p1.CheckFrostie() == false)
					{
						Console.WriteLine("You don't have that");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					
						
						//try to eat your frosty
					else if (answer.IndexOf("eat frosty") > -1 && p1.CheckFrostie() == true)
					{
						Console.WriteLine("You don't want to eat that now");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

															
					else if (answer.IndexOf("inv") > -1)
					{
						p1.GetInv();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("help") > -1)
					{
						Console.WriteLine("You could try looking at your inventory by typing inv,\nOr look around by typing look.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("play") > -1 && answer.IndexOf(instrument) > -1)
					{
						Console.WriteLine("\a\a\aYou play your instrument, you look around to see if anybody noticed.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else
					{
						Console.WriteLine("I don't understand that");
						Console.WriteLine(enter);
						Console.ReadLine();
						Console.WriteLine("\n\n\n");
					}

				} //end of while loop
				pass = false;

				#endregion

				#region 4: Brunson's Office

				while (pass == false && location == 4)
				{
			
					#region End Game Message
					if(p1.GetPoints()==60)
					{
						Tab();
						Tab();
						Console.WriteLine("Hey, you've done everything!\nYou got all 60 points!");
						Console.WriteLine("Good work! You beat my game!\nHopefully it wasn't too frustrating.\nIsn't it cool though?\nWell thanks again for playing!");
						Console.WriteLine(enter);
						Console.ReadLine();
						Tab();
						Tab();
						Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- Thank You For Playing! ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n\n\n\n\n\n\n");
						Console.ReadLine();
						return;
					}
					#endregion

					Console.WriteLine("\n\n\nYour in Mr. Brunson's office\nMr.Brunson is sitting behind his desk, he appears very annoyed.\nObvious Exits: Bandroom");
					Tab();
					Console.WriteLine(what);
					answer = Console.ReadLine();
					//lowercases it so you can read it
					answer = answer.ToLower();
				
		
					//the move commands
					//bandroom
					if (answer.IndexOf("bandroom") > -1)
					{
						location = 3;
						pass = true;
					}

						//look
					else if (answer.IndexOf("look") > -1)
					{
						Console.WriteLine("Mr. Brunson is very ticked off.\nHe piddles around on his computer and tries to ignore you.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}


						
						
						//talk to Mr. Brunson
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("brunson") > -1 && answer.IndexOf("tape") == -1)
					{
						Console.Write("Mr. Brunson says, \"");
						if (p1.CheckUsedTape() == false)
							Console.Write("You havn't seen a roll of duct tape have you?\n I need it to fix my French Horn...\n");
						Console.WriteLine("Oh, your probably here about your grade,");
						Console.WriteLine("Your score: "+p1.GetPoints()+"/60");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//give Brunson tape
					else if(answer.IndexOf("give") >-1 && answer.IndexOf("tape") > -1)
					{
						Console.WriteLine("Mr. Brunson takes the tape and doesn't thank you for it.");
						p1.UseTape();
						p1.AddPoints(5);
						Console.WriteLine(enter);
						Console.ReadLine();

					}
					
						
						//try to eat your frostie
					else if (answer.IndexOf("eat frostie") > -1 && p1.CheckFrostie() == true)
					{
						Console.WriteLine("You don't want to eat that now");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

															
					else if (answer.IndexOf("inv") > -1)
					{
						p1.GetInv();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("help") > -1)
					{
						Console.WriteLine("You could try looking at your inventory by typing inv,\nOr look around by typing look.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("play") > -1 && answer.IndexOf(instrument) > -1)
					{
						Console.WriteLine("\a\a\aYou play your instrument, you look around to see if anybody noticed.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}


					else
					{
						Console.WriteLine("I don't understand that");
						Console.WriteLine(enter);
						Console.ReadLine();
						Console.WriteLine("\n\n\n");
					}

				} //end of while loop
				pass = false;

				#endregion

				#region 5: The Practice room

				while (pass == false && location == 5)
				{
			
					#region End Game Message
					if(p1.GetPoints()==60)
					{
						Tab();
						Tab();
						Console.WriteLine("Hey, you've done everything!\nYou got all 60 points!");
						Console.WriteLine("Good work! You beat my game!\nHopefully it wasn't too frustrating.\nIsn't it cool though?\nWell thanks again for playing!");
						Console.WriteLine(enter);
						Console.ReadLine();
						Tab();
						Tab();
						Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- Thank You For Playing! ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n\n\n\n\n\n\n");
						Console.ReadLine();
						return;
					}
					#endregion


					Console.WriteLine("\n\n\n\nYou have discovored the practice rooms\nNot much here");

					//makes sure you can't see the items if you've already taken them
					if (p1.CheckFish() == false && p1.CheckUsedFish() == false)
						Console.WriteLine("There is a fish nearby");
					
					if (p1.CheckKeys() == false)
						Console.WriteLine("You spot your instrument case");
					
					Console.WriteLine("Beau Shaw is standing there in a bright orange jumpsuit.");

					Console.WriteLine("Obvious exits: Bandroom");
					Tab();
					Console.WriteLine(what);
					answer = Console.ReadLine();
					//lowercases it so you can read it
					answer = answer.ToLower();
				
		
					//the move commands
					if (answer.IndexOf("bandroom") > -1)
					{
						pass = true;
						location = 3;
					}


					else if (answer.IndexOf("look") > -1)
					{
						
						Console.WriteLine("Its just a plain room used to practice in...");
						Console.WriteLine("Beau Shaw is looking rather sage like today, \nmaybe you should talk to him if you need advice...");
						
						if(p1.CheckFish() == false && p1.CheckUsedFish() == false)
							Console.WriteLine("There is a fish nearby, his name is Trill");
						if(p1.CheckKeys() == false)
							Console.WriteLine("Your instrument case is located here");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//unassinged take command
					else if (answer.IndexOf("take") > -1 && answer.IndexOf("fish") == -1 && answer.IndexOf("case") == -1)
					{
						Console.WriteLine("Take what?");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						//take live fish
					else if (answer.IndexOf("take") > -1 && (answer.IndexOf("fish") > -1 || answer.IndexOf("trill") > -1) && (p1.CheckFish() == false || p1.CheckUsedFish() == false))
					{
						Console.WriteLine("You can't take a live animal!");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
						
						//take case get keys
					else if (answer.IndexOf("take") > -1 && answer.IndexOf("case") > -1 && p1.CheckKeys() == false)
					{
						Console.WriteLine("You take your music case and find some keys\nYou get happy and do a little dance");
						p1.AddPoints(5);
						p1.AddKeys();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						
						//give fish SPK
					else if ( ( (answer.IndexOf("feed fish") > -1) ||(answer.IndexOf("give") > -1 && answer.IndexOf("sour patch kid") > -1)) && p1.CheckSPK() == true && (p1.CheckFish() == false || p1.CheckUsedFish() == true))
					{
						Console.WriteLine("You feed the fish, sour patch kids\nThe fish turns belly up.\nYou take the dead fish, (I guess thats kind of gross.)");
						p1.AddPoints(5);
						p1.AddFish();
						p1.UseSPK();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//talk fish
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("fish") > -1 && (p1.CheckFish() == false || p1.CheckUsedFish() == true) && answer.IndexOf("beau")==-1)
					{
						Console.WriteLine("The fish tells you he is hungry\nand wants some Sour Patch Kids.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

						//talk to beau
					else if (answer.IndexOf("talk") > -1 && answer.IndexOf("fish") ==-1 && answer.IndexOf("beau") > -1)
					{
						num =r1.Next(7);
						
						
						Console.WriteLine("Beau Shaw offers the following friendly advice,");
						Console.WriteLine("\""+advice[num]+"\"");
						Console.WriteLine(enter);
						Console.ReadLine();
					}
	
	
						//try to eat your frosty
					else if (answer.IndexOf("eat frosty") > -1 && p1.CheckFrostie() == true)
					{
						Console.WriteLine("You don't want to eat that now");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

															
					else if (answer.IndexOf("inv") > -1)
					{
						p1.GetInv();
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("help") > -1)
					{
						Console.WriteLine("You could try looking at your inventory by typing inv,\nOr look around by typing look.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else if (answer.IndexOf("play") > -1 && answer.IndexOf(instrument) > -1)
					{
						Console.WriteLine("\a\a\aYou play your instrument, you look around to see if anybody noticed.");
						Console.WriteLine(enter);
						Console.ReadLine();
					}

					else
					{
						Console.WriteLine("I don't understand that");
						Console.WriteLine(enter);
						Console.ReadLine();
						Console.WriteLine("\n\n\n");
					}

				} //end of while loop
				pass = false;

				#endregion

			}
#endregion 
			
	
	
		}
		//end of the main

		//just tabs down for formating
		public static void Tab()
		{
			Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
		}
	}

	class Player
	{
		
		//these are all of your items, its just easeier for me this way.
		//I'll come back and add more when there are more items
		private string instrument;
		private bool sourPK;		//Sour patch kids 5 points to take 5 points to feed fish with
		private int points;			//keeps track of your score
		private bool ticket;			//parking ticket 5 points to take 5 points to "take care of"
		private bool combo;			//locker combination 5 points to get, 5 points to use
		private bool keys;			//in your instrument case, 5 points to get
		private bool frosty;		//get at Wendy's and sacrifice to band god
		private bool usedFrostie;	//says if you used the frosty
		private bool useTicket;		//
		private bool fish;
		private bool usedFish;
		private bool usedSPK;
		private bool tape;
		private bool usedTape;


		public Player(string instrument)
		{
			this.instrument = instrument;
			this.sourPK = false;
			this.points = 0;
			this.ticket = false;
			this.combo = false;
			this.keys = false;
			this.frosty = false;
			this.usedFrostie = false;
			this.useTicket = false;
			this.usedFish = false;
			this.fish = false;
			this.usedSPK = false;
			this.tape = false;
			this.usedTape = false;
		
		}


		public void GetInv()
		{
			Console.WriteLine("\tInventory");
			Console.WriteLine("----------------------------");

			Console.WriteLine(this.instrument);

			if (sourPK == true && usedSPK == false)
			{
				Console.WriteLine("Sour Patch Kids");
			}

			if (fish == true && usedFish == false)
			{
				Console.WriteLine("Dead Fish");
			}

			if (ticket == true && useTicket == false)
			{
				Console.WriteLine("A Parking Ticket");
			}

			if (frosty == true)
			{
				Console.WriteLine("A frosty from Wendy's");
			}

			if (tape == true)
			{
				Console.WriteLine("A brand new roll of duct tape");
			}

			if (keys == true)
			{
				Console.WriteLine("A set of car keys");
			}

			if (combo == true)
			{
				Console.WriteLine("Your locker combination written on a slip of paper");
			}
		}

		//adds to your score
		public void AddPoints(int points)
		{
			this.points += points;
		}

		public int GetPoints()
		{
			return this.points;
		}
		
		
		#region Check, Add, and Use methods

		//these are all methods that will either check if you have
		//an item, add it, remove it, or use it
		//adds SPK to your inventory


		public void AddSPK()
		{
			this.sourPK = true;
		}

		public void UseSPK()
		{
			this.usedSPK = true;
		}

		public bool CheckUseSPK()
		{
			return this.usedSPK;
		}


		

		
		//checks if you have SPK
		public bool CheckSPK()
		{
			return this.sourPK;
		}

		public void AddTicket()
		{
			this.ticket = true;
		}

		public bool CheckTicket()
		{
			return this.ticket;
		}

		public void UseTicket()
		{
			this.useTicket = true;
		}

		public bool CheckUseTicket()
		{
			return this.useTicket;
		}

		public void AddKeys()
		{
			this.keys = true;
		}

		public bool CheckKeys()
		{
			return this.keys;
		}

		public void AddCombo()
		{
			this.combo = true;
		}

		public bool CheckCombo()
		{
			return this.combo;
		}

		public void AddFrostie()
		{
			this.frosty = true;
		}

		public void UseFrostie()
		{
			this.frosty = false;
			this.usedFrostie = true;
		}

		public bool CheckFrostie()
		{
			return this.frosty;
		}

		public bool CheckUsedFrostie()
		{
			return this.usedFrostie;
		}

		public bool CheckFish()
		{
			return this.fish;
		}
		
		public void AddFish()
		{
			this.fish = true;
		}

		public void UseFish()
		{
			this.fish = false;
			this.usedFish = true;
		}


		public bool CheckUsedFish()
		{
			return this.usedFish;
		}

		public void AddTape()
		{
			this.tape = true;
		}

		public void UseTape()
		{
			this.tape = false;
			this.usedTape = true;
		}
		public bool CheckTape()
		{
			return this.tape;
		}

		public bool CheckUsedTape()
		{
			return this.usedTape;
		}



		#endregion

	}
}
