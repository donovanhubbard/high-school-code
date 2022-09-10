using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Drawing.Drawing2D;


namespace Project_5
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 
	//Concepts covered: the use of strings in animations
	//What the program does:
	//a ball will appear randomly on the screen and you need to click on the ball
	//as you do this your score(the number at the top of the screen) will go up
	//as your score goes up, the ball moves faster and gets smaller

	//what I learned:
	//I know how to use strings much better and how to draw stuff on the screen oustide of 
	//the on paint method. I also learned how to change the cursor to one of the defaults
	//I also figured out how to transform objects acording to matrixes.
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		int x;
		int y;
		int bWidth = 75;
		GraphicsPath gPath = new GraphicsPath();
		GraphicsPath rectangle = new GraphicsPath();
		Rectangle rec = new Rectangle(250,50,100,200);
		Matrix z = new Matrix();
		Rectangle mouse = new Rectangle(0,0,5,5);
		int score = 0;
		bool visible = false;
		int sleep = 2000;
		public Form1()
		{
			
			InitializeComponent();


		}
		protected override void OnLoad(EventArgs e)
		{
			Thread animation = new Thread(new ThreadStart(Animate));
			animation.Start();
			rectangle.AddRectangle(rec);
			base.OnLoad (e);
		}


		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			if(rectangle == null)
			{
				rectangle = new GraphicsPath();
				Rectangle rec = new Rectangle(50,50,100,200);
			}
			g.DrawString(score.ToString(), new Font(FontFamily.GenericSansSerif, 15), Brushes.Black, 20,20);


			base.OnPaint (e);
		}

		protected override void OnClick(EventArgs e)
		{
			if(gPath.GetBounds().IntersectsWith(mouse) && visible == true)
			{
				score++;
				visible = false;
				this.Invalidate();
				if(score%5 == 0)
				{
					sleep -= 500;
					if(sleep <= 500)
					{
						sleep = 500;
					}
				}
				if(score%10 == 0)
				{
					bWidth -= 10;
					if(bWidth <= 10)
					{
						bWidth = 10;
					}
				}
			}
			base.OnClick (e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			

			base.OnMouseUp (e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			mouse.X = e.X;
			mouse.Y = e.Y;

			if(gPath.GetBounds().IntersectsWith(mouse) && visible == true)
			{
				
				this.Cursor = Cursors.Hand;

			}
			else
				this.Cursor = Cursors.Default;


			base.OnMouseMove (e);
		}




		

		public void Animate()
		{	
			
				
			while(true)
			{	
				gPath.Reset();
				Random r = new Random();
				x=r.Next(this.Width-50);
				y=r.Next(this.Height-50);
				Graphics g = this.CreateGraphics();
				gPath.AddEllipse(x,y, bWidth, bWidth);
				g.FillPath(Brushes.Red, gPath);
				visible = true;


				//z.Rotate(30);
				//rectangle.Transform(z);
				//g.FillPath(Brushes.Black, rectangle);



				
				//g.FillEllipse(Brushes.Red, x, y, bWidth, bWidth);
				System.Threading.Thread.Sleep(sleep);
				this.Invalidate();
				
			}
				
			

		}
		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 365);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Name = "Form1";
			this.Text = "Form1";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
