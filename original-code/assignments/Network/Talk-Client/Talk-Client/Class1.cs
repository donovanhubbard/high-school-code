using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

namespace Talk_Client
{

	class Class1
	{

		static void Main(string[] args)
		{
			TcpClient client = new TcpClient();
			try
			{
				client.Connect("localhost", 8888);
			}
			catch
			{
				Console.WriteLine("Connection Failed...");
				return;
			}

			User user = new User(client);
			string command;

			while(true)
			{
				command = Console.ReadLine();
				user.PrepMessage(command);
			
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
			Console.WriteLine(msg);
		}
		public void SendMessage(string msg)
		{
			writer.WriteLine(msg);
			writer.Flush();
		}
		//formats message so it can be sent proplery
		public void PrepMessage(string msg)
		{
			
		}
		public string GetCommand(string msg)
		{
			int space = msg.IndexOf(" ");
			return msg;
		
		}
	}
}
