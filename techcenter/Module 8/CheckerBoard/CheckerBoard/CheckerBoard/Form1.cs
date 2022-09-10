using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace CheckerBoard
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		int chipX = 2;
		int chipY = 2;
		int mouseX = 0;
		int mouseY = 0;
		private GraphicsPath p =new GraphicsPath();
		private Region r;
		bool moving = false;

		public enum Quad {square};

		
		public Form1()
		{
			//this.Size=(486,505);
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			p.AddEllipse(chipX, chipY, 55, 55);
			r = new Region(p);
			//this.Region = new Region(p);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// 

		protected override void OnMouseMove(MouseEventArgs e)
		{
			mouseX = e.X;
			mouseY = e.Y;
			if(moving)
			{
				p = new GraphicsPath();
				
				p.AddEllipse(e.X-20, e.Y-20, 55, 55);
				r = new Region(p);
			}

			base.OnMouseMove (e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			
			if(r.GetBounds(CreateGraphics()).Contains(e.X, e.Y))
				moving = true;
			else 
				moving = false;

			chipX = mouseX-20;
			chipY = mouseY-20;
			Invalidate();
			base.OnMouseDown (e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (moving)
			{
				moving = false;
				p = new GraphicsPath();
				
				p.AddEllipse((e.X/60)*60, (e.Y/60)*60, 55, 55);
				r = new Region(p);
			}
			base.OnMouseUp (e);
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

		protected override void OnPaint(PaintEventArgs e)
		{	int x = 0;
			int y = 0;
			Graphics g = e.Graphics;
			g.FillRectangle(Brushes.White,0,0,480,480);
			
			while( x <= 480)
			{g.FillRectangle(Brushes.Black,x,y,60,60);
					y = 0;
				while(y <= 480)
				{
				g.FillRectangle(Brushes.Black,x,y,60,60);	
					y += 120;
				}
				x += 120;
			}
			x = 60;
			y = 60;
			
			
			while( x <= 480)
			{
					g.FillRectangle(Brushes.Black,x,y,60,60);
				y = 60;
				while(y <= 480)
				{
					g.FillRectangle(Brushes.Black,x,y,60,60);	
					y += 120;
				}
				x += 120;
			}
			g.FillRegion(Brushes.Red, r);


				Invalidate();

			base.OnPaint (e);
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
			this.ClientSize = new System.Drawing.Size(486, 505);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(486, 505);
			this.MinimumSize = new System.Drawing.Size(486, 505);
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
