using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;

namespace Udper_Client
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		public static UdpClient client;
		//public static IPEndPoint ipEndPoint;

		static void Main(string[] args)
		{
			client = new UdpClient(3333);
			Console.WriteLine("Client running...");
			byte[] output;
			string plainTxt;
			
			while(true)
			{
				plainTxt=Console.ReadLine();
				output = Encoding.ASCII.GetBytes(plainTxt);
				
				client.Send(output, output.Length, "localhost", 4444);
			}

			//Thread listen = new Thread(new ThreadStart(Listen));
			//listen.Start();
			
		}
		public static void Listen()
		{
//			while(true)
//			{
//				byte[] input = server.Receive(ref ipEndPoint);
//				ProcessInfo(input);
//			}
		}
		public static void ProcessInfo(byte[] input)
		{
			Console.WriteLine("The client sent you: "+Encoding.ASCII.GetString(input, 0, input.Length));
		}
	}

}
