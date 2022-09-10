using System;
using System.Threading;

namespace Project_4
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

		//concepts covered: Threading

		//What the program does:
		//It calls two threads in infinite while loops and has one run faster than other

		//what I learned:
		//I understand how to use threads and properly start them.
		static void Main(string[] args)
		{

				Thread fast = new Thread(new ThreadStart(primtstuff));
				Thread slow = new Thread(new ThreadStart(printSlow));


				fast.Start();
				slow.Start();

				
			
			
			
		}
		static void primtstuff()
		{
			while(true)
			{
				Console.WriteLine("Wow this thread is fast!");
				System.Threading.Thread.Sleep(300);
			}
			
		}
		static void printSlow()
		{
			while(true)
			{
				Console.WriteLine("This thread is a little slower");
				Thread.Sleep(1000);
			}
		}
	}
}
