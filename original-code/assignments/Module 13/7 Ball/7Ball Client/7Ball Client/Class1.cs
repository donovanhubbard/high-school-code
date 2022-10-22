using System;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace _7Ball_Client
{

	class Class1
	{
		public static TcpClient client = new TcpClient();

		//the three streams
		public static NetworkStream stream = null;
		public static StreamReader reader;
		public static StreamWriter writer;

		static void Main(string[] args)
		{
			//Attempt to connect
			try
			{
				client.Connect("localHost", 1111);	
			}
			catch
			{
				Console.WriteLine("You failed to connect");
				Console.ReadLine();
				return;
			}

			//at this point we have successfully connected so we can derive the streams
			Console.WriteLine("You have successfully connected.");
			stream = client.GetStream();
			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);

			while(true)
			{
				Console.WriteLine("What question do you have for the magic 7-Ball?");
				string msg = Console.ReadLine();
				SendMessage(msg);
			}
		}
		public static void SendMessage(string msg)
		{
			writer.WriteLine(msg);
			writer.Flush();
			Console.WriteLine("Message Sent");

			string answer = reader.ReadLine();
			Console.WriteLine("The mystical 7 ball answers\n" +answer);
		}
	}
}
