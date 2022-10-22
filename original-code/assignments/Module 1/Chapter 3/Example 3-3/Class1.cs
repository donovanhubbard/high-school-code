using System;

namespace Example_3_3
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		
		public static int Cost(int days)
		{
			int pay;
			if (days <= 3)
				pay = 30 * days;
			else 
				pay = 90 + 20 * (days - 3);
			return pay;
		}

		[STAThread]
		static void Main(string[] args)
		{
			Console.Write("Enter the number of rental days: ");
			int days = int.Parse(Console.ReadLine());
			Console.WriteLine("The rental cost is {0:C}", Cost(days));
		}
	}
}
