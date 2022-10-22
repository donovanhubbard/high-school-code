using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Invisiwall
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		Image bob = Image.FromFile("hip.bmp");
		int x = 50;
		private System.Windows.Forms.Timer timer1;
		int y = 50;
		Cursor hammer = new Cursor("hammer.cur");
		bool click = false;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			this.Cursor = new Cursor("hammer.cur");
			Cursor.Current = hammer;
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Gray;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.White;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(click == false)
			{
				//this.Cursor = hammer;
			}
			base.OnMouseMove (e);
		}

		
		static void Main() 
		{
			Application.Run(new Form1());
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			//g.FillEllipse(Brushes.Black, 10, 50, 20, 20);
			//g.DrawImage(bob, 50, 50);
			//g.FillEllipse(Brushes.Blue, x, y, 20, 20);
			g.DrawString("Virus on computer!", new Font(FontFamily.GenericMonospace, 32), Brushes.Black, x, y);
			x++;
			y++;
			//for(int i =0; i<30; i++)
			{
				//g.DrawString("VIRUS", new Font(FontFamily.GenericSerif, 24), Brushes.Black, i-1,i-1);
				//g.DrawString("VIRUS", new Font(FontFamily.GenericSerif, 24), Brushes.White, i,i);
				//System.Threading.Thread.Sleep(100);
			}
			base.OnPaint (e);
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Invalidate();
		}

	}
}
