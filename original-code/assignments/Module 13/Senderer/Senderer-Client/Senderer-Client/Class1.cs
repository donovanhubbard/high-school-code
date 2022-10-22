using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Senderer_Client
{

	class Class1
	{
		public static TcpClient client = new TcpClient();
		public static NetworkStream stream = null;
		public static StreamReader reader;
		public static StreamWriter writer;

		
		static void Main(string[] args)
		{
			string msg;
			try
			{
				client.Connect("localhost", 8888);
			}
			catch(Exception)
			{
				Console.WriteLine("You failed to connect");
			}
			
			
			stream = client.GetStream();
			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);

			while(true)
			{
				msg = Console.ReadLine();
				SendMessage(msg);
			}


		}
		public static void SendMessage(string msg)
		{
			writer.WriteLine(msg);
			writer.Flush();
		}
	}
}
