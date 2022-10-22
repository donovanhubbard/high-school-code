using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

namespace _7Ball_Server
{

	class Class1
	{

		

		static void Main(string[] args)
		{
			TcpListener server = new TcpListener(IPAddress.Any, 1111);
			server.Start();
			Console.WriteLine("Server Running....");

			while(true)
			{
				TcpClient c = server.AcceptTcpClient();
				User user = new User(c);
				Console.WriteLine("A new client has connected.");
				
			}

		}
	}

	public class User
	{
		TcpClient client;

		//three streams that are needed
		NetworkStream stream;
		StreamReader reader;
		StreamWriter writer;

		//Thread that listens
		Thread listen;

		// a random object so we can get a random answer
		Random r = new Random();
		
		public User(TcpClient c)
		{
			this.client = c;

			this.stream = c.GetStream();

			this.reader = new StreamReader(stream);
			this.writer = new StreamWriter(stream);

			this.listen = new Thread(new ThreadStart(Listen));
			
			listen.Start();
		}

		//this method gets the message from the client program and starts the chain
		public void Listen()
		{
			//we run this infinitly so we can get every message and not just one
			while(true)
			{
				string question = RecieveMessage();
				ProcessMessage(question);
			}
		}

		public string RecieveMessage()
		{
			//we pause here until a message is recived
			
			string question = reader.ReadLine();
			Console.WriteLine("A client has asked \" "+ question+"\"");
			return question;
		}
		public void ProcessMessage(string question)
		{
			//now its time to send a message back
			
			//we make the response randomised
			string answer;
			if(question.ToLower().IndexOf("hot") > -1)
			{
				answer = "NO!";
			}
			else if(question.ToLower().IndexOf("don") > -1)
			{
				answer = "I can't predict anything about him, he is just too cool...";
			}
			else if(r.Next(2) == 0)
			{
				answer = "No";
			}
			else
			{
				answer = "Yes";
			}

			Console.WriteLine("You told the client"+answer);
			this.writer.WriteLine(answer);
			writer.Flush();

		}
	

	
	}
	

}
