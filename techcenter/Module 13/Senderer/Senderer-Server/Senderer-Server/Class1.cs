using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Senderer_Server
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
			TcpListener server = new TcpListener(IPAddress.Any, 8888);
			server.Start();
			Console.WriteLine("Your server is running.");
			string msg;
			
			//accept a new client
			while(true)
			{
				//the program will wait on this line of code until a client manifests himself
				TcpClient c = server.AcceptTcpClient();

				Console.WriteLine("A new client has connected");
				//makes a new user class
				User u = new User(c);
				
			}
		}
	}
	public class User
	{
		TcpClient client;
		//now for the three streams
		NetworkStream stream;
		StreamReader reader;
		StreamWriter writer;

		Thread listen;

		public User(TcpClient c)
		{
			client = c;
			stream = c.GetStream();
			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);
			
			listen = new Thread(new ThreadStart(Listen));
			listen.Start();
		}

		public void Listen()
		{
			string msg;
			
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
			Console.WriteLine("The client has said: "+ msg);
		}
		public void SendMessage(string msg)
		{
			writer.WriteLine(msg);
			writer.Flush();
		}

		
	}
}
