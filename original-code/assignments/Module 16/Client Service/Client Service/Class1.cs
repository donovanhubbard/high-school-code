using System;

namespace Client_Service
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			while(true)
			{
				insult.InsultGenerator insGen = new Client_Service.insult.InsultGenerator();
				Console.WriteLine(insGen.getInsult());
				Console.ReadLine();
			}
		}
	}
}
