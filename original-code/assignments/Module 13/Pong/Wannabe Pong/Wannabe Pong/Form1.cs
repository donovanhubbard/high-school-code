using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace Pong
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
		
		Network form = new Network();
		
		
		//Network stuff
		UdpClient server;


		//variables
		int p1X;
		int p1Y = 208;
		int p2X;
		int p2Y = 208;
		int mx;		//mouses x and y location
		int my;
		int homeScore = 0;
		int awayScore = 0;
		bool gameOver = false;
		float xSpeed = 2.5f;
		float ySpeed = 2.5f;
		float squareX = 200;
		float squareY = 175;
		int bounces = 0;
		bool pause = true;
		bool first = true;

		Keys key;

		Pen myPen = new Pen(Color.White, 5);
		Font myFont = new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold);
		Font smallFont = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
		Font bigFont = new Font(FontFamily.GenericMonospace, 48, FontStyle.Bold);

			//******Constructor*******
		public Form1()
		{

			//Turning on backbuffer
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			InitializeComponent();
			Size = new Size(415,370);
			form.ShowDialog();
		
			//get the server running
			if(form.host == true)
			{
				server = new UdpClient("localhost", int.Parse(form.port));
				
				Thread connect =  new Thread(new ThreadStart(Connect));

			}

		}
		
		public static void Connect()
		{
			while(true)
			{
				//UdpClient c = server
			}
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			
			base.OnMouseMove (e);
		}

		


		
		protected override void OnPaint(PaintEventArgs e)
		{			
			Graphics g = e.Graphics;
			#region first screen
			if(pause == true && first == true)
			{
				g.DrawString("Pong", bigFont, Brushes.White, 110, 50);
				g.DrawString("By", myFont, Brushes.White, 180, 150);
				g.DrawString("Donovan Hubbard", myFont, Brushes.White, 50, 200);
				g.DrawString("Press enter to play", smallFont, Brushes.White, 110, 275);
				//g.DrawString(form.port, smallFont, Brushes.White, 0,0);
			}
			#endregion
				
			#region Draw Regular
			if(pause == false)
			{

				//draws the paddles
				//also makes sure that the paddles dont leave the arena
				if(p1Y < 88)
					g.DrawLine(myPen, 25, 63, 25, 113);
				else if(p1Y > 283)
					g.DrawLine(myPen, 25, 258, 25, 308);
				else
					g.DrawLine(myPen, 25, p1Y-25, 25, p1Y+25);
				if(p2Y < 88)
					g.DrawLine(myPen, 380, 63, 380, 115);
				else if(p2Y > 283)
					g.DrawLine(myPen, 380, 258, 380, 308);
				else
					g.DrawLine(myPen, 380, p2Y-25, 380, p2Y+25);
			
				//draws the midline
				g.DrawLine(myPen, 195, 80, 195, 110);
				g.DrawLine(myPen, 195, 140, 195, 170);
				g.DrawLine(myPen, 195, 200, 195, 230);
				g.DrawLine(myPen, 195, 260, 195, 290);
			
				//the playing field
				g.DrawRectangle(myPen, 15, 60, 375, 250);

				//the title bar
				g.DrawString("Pong", myFont, Brushes.White, 150, 15);

				//draws the respective scores
				g.DrawString(homeScore.ToString(), myFont, Brushes.White, 15, 15);
				g.DrawString(awayScore.ToString(), myFont, Brushes.White, 330, 15);
				g.DrawString("Score", smallFont, Brushes.White, 5, 0);
				g.DrawString("Score", smallFont, Brushes.White, 315, 0);

			
				//endgame stuff
				if(homeScore >= 21)
				{
					g.DrawString("Player 1 wins!", myFont, Brushes.White, 50,310);
					gameOver = true;
				}
				else if (awayScore >= 21)
				{
					g.DrawString("Player 2 wins!", myFont, Brushes.White, 50,310);
					gameOver = true;
				}


				//Drawing the square!
				//bounce off southern wall
				if(squareY + ySpeed >= 306)
				{
					ySpeed = -2.5f - bounces*.1f;
					bounces+=2;
				}
					//bounce off northern wall
				else if(squareY +ySpeed <= 59)
				{
					ySpeed = + 2.5f + bounces*.1f;
					bounces+=2;
				}
				squareX += xSpeed;
				squareY += ySpeed;
				g.FillRectangle(Brushes.White, squareX, squareY, 5, 5);

				//player 1 scores
				if(squareX >= 386)
				{
					g.DrawString("Player 1 scores!", myFont, Brushes.White, 50,310);
					homeScore++;
					squareX = 200;
					squareY = 175;
					xSpeed = -2.5f;
					ySpeed = -2.5f;
					bounces = 0;
					pause = true;
				}
				//player 2 scores
				if(squareX <= 14)
				{
					g.DrawString("Player 2 scores!", myFont, Brushes.White, 50,310);
					awayScore++;
					squareX = 200;
					squareY = 175;
					xSpeed = 2.5f;
					ySpeed = 2.5f;
					bounces = 0;
					pause = true;
				}

				//bounce off of player 2's paddle
				if(squareX >= 373  && ((p2Y+29 >= squareY) && (p2Y-29 <= squareY)))
				{
					xSpeed = -2.5f - bounces*.1f;
					bounces += 5;
				}

				//bounce off of player 1's paddle
				if(squareX <= 25  && ((p1Y+29 >= squareY) && (p1Y-29 <= squareY)))
				{

						xSpeed = 2.5f + bounces*.1f;
						bounces += 5;

				}
				#endregion



				base.OnPaint (e);

				System.Threading.Thread.Sleep(10);
				if(gameOver == false && pause == false)
					Invalidate();

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
			this.BackColor = System.Drawing.SystemColors.ControlText;
			this.ClientSize = new System.Drawing.Size(407, 343);
			this.MaximumSize = new System.Drawing.Size(415, 370);
			this.MinimumSize = new System.Drawing.Size(415, 370);
			this.Name = "Form1";
			this.Text = "Pong";

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
