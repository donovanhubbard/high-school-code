using System;

namespace Project_6
{

	class Class1
	{
		//uhhh... I suppose that this program does stuff with fractions that are integers
		//Excersise #23 Page 214
		//it really doesn't accomplish much but it meets the requriements
		static void Main(string[] args)
		{
			//this makes all the fractions that will be used for the rest of the program
			Fraction f1 = new Fraction(1, 3);
			Fraction f2 = new Fraction(2, 5);
			
			Fraction f3 = f1.Add(f2);
			Fraction f4 = f1.Subtract(f2);
			Fraction f5 = f1.Multiply(f2);
			Fraction f6 = f1.Divide(f2);




			Console.WriteLine("The fraction is 1/3");

			//from this point on all we are doing is altering the number
			Console.WriteLine("If we add 2/5");
			Console.WriteLine(f3.DispNum()+"/"+f3.DispDen());

			Console.WriteLine("Now we can subtract 2/5");
			Console.WriteLine(f4.DispNum()+"/"+f4.DispDen());


			Console.WriteLine("Then we multiply the number by 2/5");
			Console.WriteLine(f5.DispNum()+"/"+f5.DispDen());


			Console.WriteLine("Then we divide by 2/5");
			Console.WriteLine(f6.DispNum()+"/"+f6.DispDen());



		}
	}

	class Fraction
	{
		//Instance variables
		private int numerator;
		private int denominator;


		//Constructors
		public Fraction(int numerator, int denominator)
		{
			this.numerator = numerator;
			this.denominator = denominator;
		}

		public Fraction()
		{
			this.numerator = 1;
			this.denominator = 1;
		}



		//this one adds fractions
		public Fraction Add (Fraction frac)
		{	
			int num, den;

			num = frac.denominator * this.numerator + frac.numerator * this.denominator;

			den = frac.denominator * this.denominator;


			Fraction temp = new Fraction(num, den);

			return temp;
		}

		public Fraction Subtract(Fraction frac)
		{	
			int num, den;

			num = frac.denominator * this.numerator - frac.numerator * this.denominator;

			den = frac.denominator * this.denominator;


			Fraction temp = new Fraction(num, den);

			return temp;
		}

		
		//this just multiplys straight across
		public Fraction Multiply(Fraction frac)
		{
			int num, den;
			num = this.numerator * frac.numerator;
			den = this.denominator * frac.denominator;

			Fraction temp = new Fraction(num, den);

			return temp;
		}

		//this divides the fractions
		public Fraction Divide(Fraction frac)
		{
			//all you do to divide is to multiply by the inverse
			//so this inverts the fraction
			
			//stores the values
			int num = frac.denominator;
			int den = frac.numerator;

			Fraction temp = new Fraction(num, den);

			return this.Multiply(temp);
		}

		public int DispNum()
		{
			return this.numerator;
		}

		public int DispDen()
		{
			return this.denominator;
		}




	}
}
