using System;

namespace Project_2
{

	class Class1
	{
		//this program will use an interface class to sell you a house and cookies
		static void Main(string[] args)
		{
			RealEstateAgent realEA = new RealEstateAgent();
			GirlScout girlScout = new GirlScout();

			realEA.SalesSpeech();
			realEA.MakeSale();

			Console.WriteLine();

			girlScout.SalesSpeech();
			girlScout.MakeSale();
		}
	}

	public interface ISalesperson
	{
		void SalesSpeech();
		void MakeSale();
	}

	public class RealEstateAgent : ISalesperson
	{
		#region ISalesperson Members

		public void SalesSpeech()
		{
			Console.WriteLine("The Real Estate agent says, \n\"I can give you a wicked bad house!\"");
		}

		public void MakeSale()
		{
			Console.WriteLine("The Real Estate agent sells you you house for $4,000,000,000, \nbut it really is wicked bad");
		}

		#endregion

	}

	public class GirlScout : ISalesperson
	{
		#region ISalesperson Members

		public void SalesSpeech()
		{
			Console.WriteLine("The girl scout tells you, \"Hey Loser!\nBuy my cookies or I'll kick you in the shin!");
		}

		public void MakeSale()
		{
			Console.WriteLine("You get scared and buy 500 boxes of cookies. \nLater you eat them all and throw up.");
		}

		#endregion

	}


}
