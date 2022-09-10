using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;

namespace Udper_Server
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		public static UdpClient server;
		public static IPEndPoint ipEndPoint;

		static void Main(string[] args)
		{
			server = new UdpClient(4444);
			Console.WriteLine("Server running...");
			Thread listen = new Thread(new ThreadStart(Listen));
			listen.Start();
			
		}
		public static void Listen()
		{
			while(true)
			{
				byte[] input = server.Receive(ref ipEndPoint);
				ProcessInfo(input);
			}
		}
		public static void ProcessInfo(byte[] input)
		{
			Console.WriteLine("The client sent you: "+Encoding.ASCII.GetString(input, 0, input.Length));
		}
	}

}
