using System;
using System.Xml;

namespace Freqin__awesome
{

	class Class1
	{

		static void Main(string[] args)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("dude.xml");
			doc.Normalize();

			XmlElement root = doc.DocumentElement;

			XmlNodeList nodeList = root.GetElementsByTagName("dude");

			XmlNode node = nodeList[0];

			string stuff = node.InnerText;

			Console.WriteLine(stuff);
		}
	}
}
