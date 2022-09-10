using System;

namespace Project_6
{

	class Class1
	{
		//This is a delivery program. You enter in the zip code
		//and the type of delivery and then it gives you a big fee
		static void Main(string[] args)
		{
			int zipCode = 84092;
			bool pass = false;
			char deliveryType;
			int cost;
			char answer;

			int[,] zipCodes = new int[3,4];
			
			for(int i = 0; i<3; i++)
			{
				for(int j =0; j<4; j++)
				{
					zipCodes[i,j] = zipCode;
					zipCode++;
				}
			}

			do{
			Console.WriteLine("Welcome to the FedEx Delivery system thing!\n");

			//gets the zip code
			Console.Write("What zip code whould you like us to deliver to? ");
			zipCode = int.Parse(Console.ReadLine());
			Console.WriteLine("\n\n");

			//checks to see if they put in a valid zip code
			do
			{
				for(int i = 0; i<3; i++)
				{
					for(int j =0; j<4; j++)
					{
						if(zipCode == zipCodes[i,j])
							pass = true;
					}
				}
				//if they put in a bad code
				if(pass == false)
				{
					Console.WriteLine("That was not a zipcode that we deliver to dingus.\nEnter a REAL zipcode:");
					zipCode = int.Parse(Console.ReadLine());
				
				}
			}
			while(pass == false);
			pass = false;

			//gets the delivery type
			do
			{
				Console.Write("Would you like Standard, Express, or Overnight delivery (type s, e, or o): ");
				deliveryType = char.Parse(Console.ReadLine());

				if(deliveryType.ToString() != "s" && deliveryType.ToString() != "e" && deliveryType.ToString() != "o")
				{
					Console.WriteLine("Your a ditz, put in s, e, or o");
				}
			}
			while(deliveryType.ToString() != "s" && deliveryType.ToString() != "e" && deliveryType.ToString() != "o");


			#region Price for each delivery

			if(zipCode == 84092)
			{
				if(deliveryType.ToString() == "e")
					cost = 48;
				else if (deliveryType.ToString() == "o")
					cost = 84;
				else
					cost = 75;
			}

			else if(zipCode == 84093)
			{
				if(deliveryType.ToString() == "e")
					cost = 49;
				else if (deliveryType.ToString() == "o")
					cost = 94;
				else
					cost = 21;
			}

			else if(zipCode == 84094)
			{
				if(deliveryType.ToString() == "e")
					cost = 42;
				else if (deliveryType.ToString() == "o")
					cost = 4;
				else
					cost = 750;
			}

			else if(zipCode == 84095)
			{
				if(deliveryType.ToString() == "e")
					cost = 450;
				else if (deliveryType.ToString() == "o")
					cost = 98;
				else
					cost = 70;
			}

			else if(zipCode == 84096)
			{
				if(deliveryType.ToString() == "e")
					cost = 402;
				else if (deliveryType.ToString() == "o")
					cost = 87;
				else
					cost = 75;
			}

			else if(zipCode == 84097)
			{
				if(deliveryType.ToString() == "e")
					cost = 402;
				else if (deliveryType.ToString() == "o")
					cost = 49;
				else
					cost = 710;
			}

			else if(zipCode == 84098)
			{
				if(deliveryType.ToString() == "e")
					cost = 41;
				else if (deliveryType.ToString() == "o")
					cost = 12;
				else
					cost = 7;
			}

			else if(zipCode == 84099)
			{
				if(deliveryType.ToString() == "e")
					cost = 68;
				else if (deliveryType.ToString() == "o")
					cost = 2;
				else
					cost = 87;
			}

			else if(zipCode == 84100)
			{
				if(deliveryType.ToString() == "e")
					cost = 46;
				else if (deliveryType.ToString() == "o")
					cost = 92;
				else
					cost = 1;
			}

			else if(zipCode == 84101)
			{
				if(deliveryType.ToString() == "e")
					cost = 71;
				else if (deliveryType.ToString() == "o")
					cost = 98;
				else
					cost = 156;
			}

			else if(zipCode == 84102)
			{
				if(deliveryType.ToString() == "e")
					cost = 36;
				else if (deliveryType.ToString() == "o")
					cost = 17;
				else
					cost = 98;
			}

			else if(zipCode == 84103)
			{
				if(deliveryType.ToString() == "e")
					cost = 12;
				else if (deliveryType.ToString() == "o")
					cost = 85;
				else
					cost = 20;
			}

			else 
				cost = 0;
			#endregion

			Console.WriteLine("The price for delivery is {0:C}",cost);
			Console.WriteLine("Thank you for using FedEx");
			Console.WriteLine("Would you like to ship another package?(y or n)");
			answer = char.Parse(Console.ReadLine());

		}
		while(answer.ToString() == "y");
		Console.WriteLine("\n\n\nthank you see ya next time!");




		}
	}
}
