using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace Talk_Server
{

	class Class1
	{

		static void Main(string[] args)
		{
			
			TcpListener server = new TcpListener(IPAddress.Any, 8888);
			server.Start();
			Console.WriteLine("Server online...");

			//accept clients
			while(true)
			{
				TcpClient c = server.AcceptTcpClient();
				User user = new User(c);
				Console.WriteLine("New Client connected");
			}
		}
	}
	public class User
	{
		TcpClient client;
		
		NetworkStream stream;
		StreamReader reader;
		StreamWriter writer;

		string name;

		Thread thread;

		bool connected;

		public User(TcpClient client)
		{
			this.client = client;

			stream = client.GetStream();
			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);
			
			connected = true;
			
			thread = new Thread(new ThreadStart(Listen));
			thread.Start();

			

		}

		public void Listen()
		{
			while(connected)
			{
				string msg = RecieveMessage();
				ProcessMessage(msg);
			}
		}
		public string RecieveMessage()
		{
			try
			{
				return reader.ReadLine();
			}
			catch
			{
				Console.WriteLine("User has disconnected");
				connected = false;
				return null;

			}

		}
		public void ProcessMessage(string msg)
		{
			int commandCode =int.Parse(msg.Substring(0,1)); 
			msg = msg.Substring(1,msg.Length);

			switch(commandCode)
			{
				case 0:

					break;
				case 1:
					ChangeName(msg);
					break;
				default:
					Console.WriteLine("Invalid message from "+name);
					break;
			}

		}
		public void ChangeName(sting name)
		{
			name = name;
		}
		public void SendMessage(string msg)
		{
			writer.WriteLine(msg);
			writer.Flush();
		}
	}
}
