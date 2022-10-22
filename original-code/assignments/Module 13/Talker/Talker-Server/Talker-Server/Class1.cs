using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;

namespace Talker_Server
{

	class Class1
	{
		//the listener listens to the specefied port and takes it in
		

		static void Main(string[] args)
		{
			TcpListener server = new TcpListener(IPAddress.Any, 6000);
			Console.WriteLine("Server Running...");
			server.Start();
			while(true)
			{
				TcpClient c = server.AcceptTcpClient();
				Console.WriteLine("New client Connected.");

				//creates the user object so I can keep track of them all
				User u = new User(c);
			}
		}
	}

	public class User
	{
		TcpClient client;

		//the three streams
		NetworkStream stream;
		StreamReader reader;
		StreamWriter writer;

		Thread listen; 

		public User(TcpClient c)
		{
			this.client = c;
			stream = c.GetStream();

			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);

			listen = new Thread(new ThreadStart(Listen));
			listen.Start();
		}

		public void Listen()
		{
			string msg;

			//what we are going to do here is constantly listen so we dont miss anything
			while(true)
			{
				msg = ReceiveMessage();
				ProcessMessage(msg);
			}

		}

		public string ReceiveMessage()
		{
			return reader.ReadLine();
		}

		public void ProcessMessage(string msg)
		{
			//as of right now this method does nothing
			//all messages sent by the client end up here
			Console.WriteLine("Client says "+msg);
		}
		


	}
}
