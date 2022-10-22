using System;

namespace Project__3
{

	//Concepts covered: Linked Lists

	//What the program does:
	//It keeps track of the store inventory in a linked list. You can search, add, or delete very easily

	//What I learned
	//I understand how linked lists work and how to modify them to do what I want.
	
	class Class1
	{

		static void Main(string[] args)
		{
			LinkedList inventory = new LinkedList();
			int choice = 0;
			int number;
			float price;
			string name;
			Node n;
			while(choice != 5)
			{
				Console.WriteLine("1. Add new product\n2.Remove a product from the list\n3.Search for a product\n4. Print the store inventory\n5. Quit");
				choice = int.Parse(Console.ReadLine());
				switch(choice)
				{
					case 1:
						Console.WriteLine("Enter the product number");
						number = int.Parse(Console.ReadLine());
						Console.WriteLine("Enter the product name.");
						name = Console.ReadLine();
						Console.WriteLine("Enter the products price.");
						price = float.Parse(Console.ReadLine());
						inventory.Insert(number, name, price);
						break;
					case 2:
						Console.WriteLine("Please enter the product number.");
						number = int.Parse(Console.ReadLine());
						if(inventory.Search(number) != null)
						{
							inventory.Remove();	
						}
						else
							Console.WriteLine("Item not found");
						
						break;
					case 3:
						Console.WriteLine("Please enter the product number");
						try
						{
							number = int.Parse(Console.ReadLine());
							if(inventory.Search(number) != null)
							{
								Console.WriteLine("Product# "+inventory.Search(number).number +" "+ inventory.Search(number).name +" $"+ inventory.Search(number).price);	
							}
						}
						catch(Exception)
						{
							Console.WriteLine("Item not found");
						}

						break;
					case 4:
						inventory.Reset();
						Console.WriteLine("Displaying inventory...");
						inventory.Display();
						break;
					case 5:
						return;
					default:
						Console.WriteLine("You suck, enter in a valid answer!");
						break;

						Console.WriteLine("\n");
						Console.ReadLine();
						
				}
			}
		}
	}
	class Node
	{
		internal int number;
		internal string name;
		internal float price;
		internal Node next;

		public Node(int number, string name, float price, Node n)
		{
			this.number = number;
			this.name = name;
			this.price = price;
			next = n;
		}
	}

	class LinkedList
	{
		private Node head;
		private Node previous;
		private Node current;

		public LinkedList()
		{
			head = null;
			previous = null;
			current = null;
		}

		public bool IsEmpty()
		{
			if(head == null)
				return true;
			else
				return false;
		}

		public void Insert(int number, string name, float price)
		{
			Node n = new Node(number, name,price, current);
			if (previous == null)
				head = n;
			else
				previous.next = n;
			current = n;
		}

		public void Remove()
		{
			if (head != null)
			{
				if (previous == null)
					head = head.next;
				else
					previous.next = current.next;
				current = current.next;
			}
		}
		public void GetData()
		{
			if (current != null)
				Console.WriteLine("Product# "+current.number+" "+current.name+" $"+current.price);
		}

		public bool AtEnd()
		{
			if (current == null)
				return true;
			else
				return false;
		}

		public void Advance()
		{
			if (!AtEnd())
			{
				previous = current;
				current = current.next;
			}
		}

		public void Reset()
		{
			previous = null;
			current = head;
		}

		public void Display()
		{
			Reset();
			if (head != null)
				do
				{
					GetData();
					Advance();
				} while (!AtEnd());
		}
		public Node Search(int number)
		{
			this.Reset();
			while(current != null)
			{
				if(current.number == number)
				{
					return current;
				}
				else
				{
					this.Advance();
				}
			}
			return null;

		}
	}
}
