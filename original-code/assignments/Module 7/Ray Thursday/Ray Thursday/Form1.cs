using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;
using Microsoft.DirectX.DirectSound;
using Buffer = Microsoft.DirectX.DirectSound.SecondaryBuffer;



namespace RayDude
{
	
	//Concepts Covered: a: Drawing lines, rectangles ellipses, pie slices, and polygons
	//					b: Drawing text in different font sizes, colors, and font types,
	//					c: Using common and custom defined colors (custom colors on the sheild
	//					d: Responding to mouse and keyboard events(the space bar and b key may be used for the shield and gun respectivly)

	//What the program does: This is a simple game in which you are assualted by penguins with revolvers. 
	//						You shoot the penguins and use a sheild to defend yourself

	//What I leanred:  I gained a vast understanding of how to animate things. I now feel
	//			complete capable of animating simple shapes and have the user interact with them
	//			I also learned how to make the computer respond to the keyboard
	public class Form1 : System.Windows.Forms.Form
	{
		
		Random rand = new Random();
		
		Color custom = Color.FromArgb( 46, 45 , 89);
		
		bool sound = true;
		int acc;
		float percent;
		int hits = 0;
		int clicks = 0;
		float sPower = 100f; // shield power
		bool shield; //on or off
		bool hit = false;
		int jawY = 170;
		bool jawUp = true; //jawUp true means the jaw is moving up
		int count = 0;
		int mX;
		int mY;
		int health = 10;
		int level = 0;

		int lives = 10;
		int kills = 0;
		Keys key;
		Baddie b1 = new Baddie(0,0, false, 0, 1);
		Baddie b2 = new Baddie(0,0, false, 0, 1);
		Baddie b3 = new Baddie(0,0, false, 0, 1);
		Baddie b4 = new Baddie(0,0, false, 0, 1);
		Baddie b5 = new Baddie(0,0, false, 0, 1);
		float lasX;
		float lasY;
		float lasX2;
		float lasY2;
		float lasX3;
		float lasY3;

		bool laser3 = false;
		bool laser2 = false;
		bool laser = false;
		float lasSpeed = 5f;
		float badLas = -3f;
		int dudeX = 10;
		int dudeY = 10;
		bool dudeAlive = true;

		private Device SoundDevice = new Device();
		private Buffer Background;

		
		Pen myPen = new Pen(Brushes.White, 3f);
		
		
		Pen bonePen = new Pen(Brushes.BlanchedAlmond, 20f);
		Font bigFont = new Font("Impact", 26);
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			Background = new SecondaryBuffer("laugh1.wav", SoundDevice);
			InitializeComponent();
			
			SoundDevice.SetCooperativeLevel(this, CooperativeLevel.Priority);
			
		
			
			//hides cursor
			Cursor.Hide();


		}

		protected override void OnLoad(EventArgs e)
		{

			
			//Background.Play(0, BufferPlayFlags.Looping);
			//Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\tetris_drm_tetrisbgm1.mid", true);
			base.OnLoad (e);
		}

		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			
			MouseButtons button = new MouseButtons();
			button = e.Button;
			if(e.Button == MouseButtons.Left)
			{
				if(dudeAlive == true)
				{
					if(laser == false)// && laser2 == false && laser3 == false)// && laser2 == false)
					{
						laser = true;
						lasX = dudeX + 55;
						lasY = dudeY + 35;
						clicks++;

						
					}
					else if (laser == true && laser2 == false)// && laser3 == false)
					{
						laser2 = true;
						lasX2 = dudeX + 55;
						lasY2 = dudeY + 35;
						clicks++;
					}

					else if (laser == true && laser2 == true && laser3 == false)
					{
						laser3 = true;
						lasX3 = dudeX + 55;
						lasY3 = dudeY + 35;
						clicks++;
					}
				}
			}

			else if(e.Button == MouseButtons.Right)
			{
				shield = true;
			}
			base.OnMouseDown (e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				shield = false;
			}
			base.OnMouseUp (e);
		}


		public void readStuff()
		{
			//FileInfo score = new FileInfo(@"//msdn...");

			//StreamReader reader = score.OpenText();

			//reader.ReadLine();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			key = e.KeyCode;
			if(e.Control == true)
				key = Keys.Control;
			switch(key)
			{
				/*case Keys.Down:
					dudeY+=20;
					break;
				case Keys.Up:
					dudeY-=20;
					break;
				case Keys.Right:
					dudeX += 20;
					break;
				case Keys.Left:
					dudeX -= 20;
					break;
					*/
				case Keys.Space:
					if(laser == false)// && laser2 == false && laser3 == false)// && laser2 == false)
					{
						laser = true;
						lasX = dudeX + 55;
						lasY = dudeY + 35;
						clicks++;

						
					}
					else if (laser == true && laser2 == false)// && laser3 == false)
					{
						laser2 = true;
						lasX2 = dudeX + 55;
						lasY2 = dudeY + 35;
					}

					else if (laser == true && laser2 == true && laser3 == false)
					{
						laser3 = true;
						lasX3 = dudeX + 55;
						lasY3 = dudeY + 35;
					}

				break;
				
	
		
			}


			base.OnKeyDown (e);
		}

		
		protected override void OnKeyPress(KeyPressEventArgs e)
		{


			if (key == Keys.B)
			{
				shield = true;
				sPower -= .5f;
			}

			base.OnKeyPress (e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			key = Keys.B;
			if (key == Keys.B)
				shield = false;
			
			base.OnKeyUp (e);
		}


		protected override void OnMouseMove(MouseEventArgs e)
		{
			mX = e.X;
			mY = e.Y;
			base.OnMouseMove (e);
		}

		
		protected override void OnPaint(PaintEventArgs e)
		{
			
			if(health <= 0)
			{
				dudeAlive = false;
			}
			
			if(dudeAlive == true)
			{
			
				#region levels
				if(kills == 5)
				{
					level = 1;
				}
				else if(kills == 15)
				{
					level = 2;
				}
				else if(kills == 30)
				{
					level = 3;
				}
				else if(kills == 50)
				{
					level = 4;
				}
				else if(kills == 60)
				{
					level = 4;
				}
			
				//600 is end of screen
				if(level == 0)
				{
					if(b1.GetAlive() == false)
						b1.Spawn(700,rand.Next(320), -1f, 0);
				}

				if(level == 1)
				{
					if(b1.GetAlive() == false)
						b1.Spawn(700,rand.Next(320), -1.5f, 5);
					if(b2.GetAlive() == false)
						b2.Spawn(700,rand.Next(320),-1f, 10);
				}
				if(level == 2)
				{
					if(b1.GetAlive() == false)
						b1.Spawn(700,rand.Next(320), -1.5f, 1);
					if(b2.GetAlive() == false)
						b2.Spawn(700,rand.Next(320),-1.5f, 4);
					if(b3.GetAlive() == false)
						b3.Spawn(700,rand.Next(320),-1f, 25);	
				}

				if(level == 3)
				{
					if(b1.GetAlive() == false)
						b1.Spawn(700,rand.Next(320), -1.5f, 1);
					if(b2.GetAlive() == false)
						b2.Spawn(700,rand.Next(320),-1.5f, 4);
					if(b3.GetAlive() == false)
						b3.Spawn(700,rand.Next(320),-1f, 25);	
					if(b4.GetAlive() == false)
						b4.Spawn(700,rand.Next(320),-1.5f, 20);
				}
				if(level == 4)
				{
					if(b1.GetAlive() == false)
						b1.Spawn(700,rand.Next(320), -1.5f, 10);
					if(b2.GetAlive() == false)
						b2.Spawn(700,rand.Next(320),-2f, 50);
					if(b3.GetAlive() == false)
						b3.Spawn(700,rand.Next(320),-2.5f, 25);	
					if(b4.GetAlive() == false)
						b4.Spawn(700,rand.Next(320),-1.5f, 20);
					if(b5.GetAlive() == false)
						b5.Spawn(700,rand.Next(320),-2f, 5);
				}

				if(level == 5)
				{
					if(b1.GetAlive() == false)
						b1.Spawn(700,rand.Next(320), -5f, 90);
					if(b2.GetAlive() == false)
						b2.Spawn(700,rand.Next(320),-4.5f, 90);
					if(b3.GetAlive() == false)
						b3.Spawn(700,rand.Next(320),-8f, 90);	
					if(b4.GetAlive() == false)
						b4.Spawn(700,rand.Next(320),-6f, 90);
					if(b5.GetAlive() == false)
						b5.Spawn(700,rand.Next(320),-5f, 90);
					badLas = -9f;
				}



			


				#endregion
			
				Graphics g = e.Graphics;
				dudeX = mX - 10;
				dudeY = mY - 35;
				Font myFont = new Font(FontFamily.GenericSansSerif, 12);
				g.FillEllipse(Brushes.Coral, dudeX, dudeY, 25, 25);
				g.FillRectangle(Brushes.DarkGreen, dudeX, dudeY + 25, 25, 50);
				g.FillRectangle(Brushes.Black, dudeX + 15, dudeY + 30, 35, 15);
				g.FillPie(Brushes.DarkGreen, dudeX, dudeY, 25, 25, 180, 180);
				g.FillPie(Brushes.Green, dudeX, dudeY + 70, 10, 10, 0, 180);
				g.FillPie(Brushes.Green, dudeX + 15, dudeY + 70, 10, 10, 0, 180);

				if(hit == true && count < 11)
				{
					g.FillEllipse(Brushes.Red, dudeX, dudeY, 25, 25);
					g.FillRectangle(Brushes.Red, dudeX, dudeY + 25, 25, 50);
					g.FillRectangle(Brushes.Red, dudeX + 15, dudeY + 30, 35, 15);
					g.FillPie(Brushes.Red, dudeX, dudeY, 25, 25, 180, 180);
					g.FillPie(Brushes.Red, dudeX, dudeY + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.Red, dudeX + 15, dudeY + 70, 10, 10, 0, 180);
				

					count++;

				}
			
				if(hit == true && count >= 11)
				{
					count = 0;
					hit = false;
				}

				//draw the force feild
				if(shield == true && sPower > 0)
				{
					Pen sheildPen = new Pen(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), 10f);
					g.DrawArc(sheildPen, dudeX +20, dudeY - 10, 30f, 100f, 270, 180); 
					sPower-= .5f;
				}
				if(shield == false && sPower < 100f)
				{
					sPower+=.01f;
				}

	


				//draw health bar
				g.FillRectangle(Brushes.Black, 200, 8, 100, 10);
				g.FillRectangle(Brushes.Red, 200, 8, 10*health, 10);
				g.DrawRectangle(myPen, 198, 6, 103, 12);

				//draw shield bar
				g.FillRectangle(Brushes.Black, 380, 8, 100, 10);
				g.FillRectangle(Brushes.Red, 380, 8, sPower, 10);
				g.DrawRectangle(myPen, 378, 6, 103, 12);
			
				g.DrawString("Kills: "+kills, myFont, Brushes.Black,90,3);
				g.DrawString("HP", myFont, Brushes.Black,165,3);
				g.DrawString("Shield", myFont, Brushes.Black,325,3);



				#region Create/Destroy Lasers	
				//create las1
				if(laser == true && lasX + 30 < this.Width)
				{
					g.FillRectangle(Brushes.IndianRed, lasX, lasY, 30, 5);
					lasX += lasSpeed;				
				}
				//destroy las1
				if(laser == true && lasX + 30 >= this.Width)
				{
					laser = false;
				}
				//create las2
				if(laser2 == true && lasX2 + 30 < this.Width)
				{
					g.FillRectangle(Brushes.IndianRed, lasX2, lasY2, 30, 5);
					lasX2 += lasSpeed;
				}
				//destroy las2
				if(laser2 == true && lasX2 + 30 >= this.Width)
				{
					laser2 = false;
				}

				//create las3
				if(laser3 == true && lasX3 + 30 < this.Width)
				{
					g.FillRectangle(Brushes.IndianRed, lasX3, lasY3, 30, 5);
					lasX3 += lasSpeed;
				}
				//destroy las3
				if(laser3 == true && lasX3 + 30 >= this.Width)
				{
					laser3 = false;
				}
			
				#endregion

				#region Baddie Lasers
				#region baddie laser 1
				if(b1.GetLaser() == false && b1.Fire(b1.GetFreq()) == true)
				{
					b1.SpawnLaser();
				}

				if(b1.GetLaser() == true)
				{
					b1.AddLasX(badLas);
					g.FillRectangle(Brushes.IndianRed, b1.GetLasX(), b1.GetLasY(), 30, 5);
				}
				if(b1.GetLasX() + 30 <= 0)
				{
					b1.ChangeLaser(false);
				}
				//they hit you
				if(b1.GetLaser() == true && (( b1.GetLasX()+ 30 >= dudeX && b1.GetLasX() <= dudeX + 25) || (b1.GetLasX() >= dudeX && b1.GetLasX() <= dudeX + 25)) && b1.GetLasY() >= dudeY && b1.GetLasY() <= dudeY + 70)
				{
					health--;
					hit = true;
					b1.ChangeLaser(false);
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}
				//they hit your sheild
				if( b1.GetLaser() == true && shield == true && b1.GetLasX() > dudeX && b1.GetLasX() < dudeX + 50 && b1.GetLasY() > dudeY -15 && b1.GetLasY() < dudeY + 90)
				{
					b1.ChangeLaser(false);
				}
				#endregion

				#region baddie laser 2
				if(b2.GetLaser() == false && b2.Fire(b2.GetFreq()) == true)
				{
					b2.SpawnLaser();
				}

				if(b2.GetLaser() == true)
				{
					b2.AddLasX(badLas);
					g.FillRectangle(Brushes.IndianRed, b2.GetLasX(), b2.GetLasY(), 30, 5);
				}
				if(b2.GetLasX() + 30 <= 0)
				{
					b2.ChangeLaser(false);
				}
				//they hit you
				if(b2.GetLaser() == true && (( b2.GetLasX()+ 30 >= dudeX && b2.GetLasX() <= dudeX + 25) || (b2.GetLasX() >= dudeX && b2.GetLasX() <= dudeX + 25)) && b2.GetLasY() >= dudeY && b2.GetLasY() <= dudeY + 70)
				{
					health--;
					hit = true;
					b2.ChangeLaser(false);
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}

				//they hit your sheild
				if( b2.GetLaser() == true && shield == true && b2.GetLasX() > dudeX && b2.GetLasX() < dudeX + 50 && b2.GetLasY() > dudeY -15 && b2.GetLasY() < dudeY + 90)
				{
					b2.ChangeLaser(false);
				}
				#endregion

				#region baddie laser 3
				if(b3.GetLaser() == false && b3.Fire(b3.GetFreq()) == true)
				{
					b3.SpawnLaser();
				}

				if(b3.GetLaser() == true)
				{
					b3.AddLasX(badLas);
					g.FillRectangle(Brushes.IndianRed, b3.GetLasX(), b3.GetLasY(), 30, 5);
				}
				if(b3.GetLasX() + 30 <= 0)
				{
					b3.ChangeLaser(false);
				}
				//they hit you
				if(b3.GetLaser() == true &&  (( b3.GetLasX()+ 30 >= dudeX && b3.GetLasX() <= dudeX + 25) || (b3.GetLasX() >= dudeX && b3.GetLasX() <= dudeX + 25)) && b3.GetLasY() >= dudeY && b3.GetLasY() <= dudeY + 60)
				{
					health--;
					hit = true;
					b3.ChangeLaser(false);
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}
				//they hit your sheild
				if( b3.GetLaser() == true && shield == true && b3.GetLasX() > dudeX && b3.GetLasX() < dudeX + 50 && b3.GetLasY() > dudeY -15 && b3.GetLasY() < dudeY + 90)
				{
					b3.ChangeLaser(false);
				}
				#endregion

				#region baddie laser 4
				if(b4.GetLaser() == false && b4.Fire(b4.GetFreq()) == true)
				{
					b4.SpawnLaser();
				}

				if(b4.GetLaser() == true)
				{
					b4.AddLasX(badLas);
					g.FillRectangle(Brushes.IndianRed, b4.GetLasX(), b4.GetLasY(), 30, 5);
				}
				if(b4.GetLasX() + 30 <= 0)
				{
					b4.ChangeLaser(false);
				}
				//they hit you
				if(b4.GetLaser() == true &&  (( b4.GetLasX()+ 30 >= dudeX && b4.GetLasX() <= dudeX + 25) || (b4.GetLasX() >= dudeX && b4.GetLasX() <= dudeX + 25)) && b4.GetLasY() >= dudeY && b4.GetLasY() <= dudeY + 60)
				{
					health--;
					hit = true;
					b4.ChangeLaser(false);
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}

				//they hit your sheild
				if( b4.GetLaser() == true && shield == true && b4.GetLasX() > dudeX && b4.GetLasX() < dudeX + 50 && b4.GetLasY() > dudeY -15 && b4.GetLasY() < dudeY + 90)
				{
					b4.ChangeLaser(false);
				}
				#endregion

				#region baddie laser 5
				if(b5.GetLaser() == false && b5.Fire(b5.GetFreq()) == true)
				{
					b5.SpawnLaser();
				}

				if(b5.GetLaser() == true)
				{
					b5.AddLasX(badLas);
					g.FillRectangle(Brushes.IndianRed, b5.GetLasX(), b5.GetLasY(), 30, 5);
				}
				if(b5.GetLasX() + 30 <= 0)
				{
					b5.ChangeLaser(false);
				}
				//they hit you
				if(b5.GetLaser() == true &&  (( b5.GetLasX()+ 30 >= dudeX && b5.GetLasX() <= dudeX + 25) || (b5.GetLasX() >= dudeX && b5.GetLasX() <= dudeX + 25)) && b5.GetLasY() >= dudeY && b5.GetLasY() <= dudeY + 60)
				{
					health--;
					hit = true;
					b5.ChangeLaser(false);
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}

				//they hit your sheild
				if( b5.GetLaser() == true && shield == true && b5.GetLasX() > dudeX && b5.GetLasX() < dudeX + 50 && b5.GetLasY() > dudeY -15 && b5.GetLasY() < dudeY + 90)
				{
					b5.ChangeLaser(false);
				}
				#endregion



				#endregion
				
				#region Baddie 1
				#region Kill baddie 1	
				//kill baddie 1 with laser1
				if(lasX >= b1.GetX() && lasY >= b1.GetY() && lasY <= b1.GetY() + 70 && laser == true && b1.GetAlive() && b1.GetX()>= dudeX)
				{
					b1.ChangeAlive(false);
					laser = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser2
				if(lasX2 >= b1.GetX() && lasY2 >= b1.GetY() && lasY2 <= b1.GetY() + 70 && laser2 == true && b1.GetAlive() && b1.GetX() >= dudeX)
				{
					b1.ChangeAlive(false);
					laser2 = false;
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser3
				if(lasX3 >= b1.GetX() && lasY3 >= b1.GetY() && lasY3 <= b1.GetY() + 70 && laser3 == true && b1.GetAlive() && b1.GetX() >= dudeX)
				{
					b1.ChangeAlive(false);
					laser3 = false;
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion

				if(b1.GetAlive() == true)
				{
					/*
					 * old draw method
					g.FillEllipse(Brushes.Coral, b1.GetX(), b1.GetY(), 25, 25);
					g.FillRectangle(Brushes.DarkKhaki, b1.GetX(), b1.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.Black, b1.GetX() - 15, b1.GetY() + 30, 35, 15);
					g.FillPie(Brushes.DarkKhaki, b1.GetX(), b1.GetY(), 25, 25, 180, 180);
					g.FillPie(Brushes.DarkGray, b1.GetX(), b1.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.DarkGray, b1.GetX() + 15, b1.GetY() + 70, 10, 10, 0, 180);
					*/
					
					//pengiun skin
					
					g.FillEllipse(Brushes.Black, b1.GetX(), b1.GetY(), 25, 25);
					g.FillEllipse(Brushes.Black, b1.GetX(), b1.GetY()+15, 25, 20);
					g.FillRectangle(Brushes.Black, b1.GetX(), b1.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.White, b1.GetX()+5, b1.GetY() + 35, 15, 40);
					g.FillEllipse(Brushes.White, b1.GetX()+5, b1.GetY()+25, 15, 20);
					g.FillPie(Brushes.Orange, b1.GetX(), b1.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.Orange, b1.GetX() + 15, b1.GetY() + 70, 10, 10, 0, 180);
					g.FillEllipse(Brushes.White, b1.GetX()+4, b1.GetY()+4, 18, 18);
					g.FillEllipse(Brushes.Black, b1.GetX()+6, b1.GetY()+8, 5,5);
					g.FillEllipse(Brushes.Black, b1.GetX()+13, b1.GetY()+8, 5,5);
					g.FillRectangle(Brushes.Chocolate, b1.GetX() + 6, b1.GetY() + 40, 8, 9);
					g.DrawRectangle(Pens.Black, b1.GetX() + 6, b1.GetY() + 40, 8, 9);
					
					g.FillRectangle(Brushes.Gray, b1.GetX() - 15, b1.GetY() + 35, 15, 5);
					g.DrawRectangle(Pens.Black, b1.GetX()-16, b1.GetY() + 35, 16, 5);

					g.FillRectangle(Brushes.Gray, b1.GetX(), b1.GetY() + 35, 10, 8);
					g.DrawRectangle(Pens.Black, b1.GetX()-1, b1.GetY()+ 34,11,9);
					g.DrawLine(Pens.Black, b1.GetX()+1, b1.GetY() + 36, b1.GetX()+8, b1.GetY()+36);
					g.DrawLine(Pens.Black, b1.GetX()+1, b1.GetY() + 38, b1.GetX()+8, b1.GetY()+38);
					g.DrawLine(Pens.Black, b1.GetX()+1, b1.GetY() + 40, b1.GetX()+8, b1.GetY()+40);

					//nose
					Point[] triangle = new Point[] {new Point((int)b1.GetX()+8 , (int)b1.GetY()+15 ), new Point((int)b1.GetX()+18 , (int)b1.GetY()+15 ), new Point((int)b1.GetX()+13 , (int)b1.GetY()+25 )};
					g.FillPolygon(Brushes.Orange, triangle);

					b1.AddX(b1.GetSpeed());
				}
				//lose a life
				if(b1.GetAlive() == true && b1.GetX() <= -25)
				{
					lives--;
					b1.ChangeAlive(false);
				}

				//they run into you															   
				if(b1.GetAlive() == true && (( b1.GetX() + 30 >= dudeX && b1.GetX() <= dudeX + 20) || (b1.GetX() >= dudeX && b1.GetX()*100 <= dudeX)) && (b1.GetY() >= dudeY - 70 && b1.GetY() <= dudeY + 70))
				{
					health--;
					hit = true;
					b1.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}

				//they hit your sheild
				if( b1.GetAlive() == true && shield == true && b1.GetX() > dudeX && b1.GetX() < dudeX + 50 && b1.GetY() > dudeY - 90 && b1.GetY() < dudeY + 70)
				{
					b1.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);

				}
				#endregion

				#region Baddie 2
				#region Kill baddie 2	
				//kill baddie 2 with laser1
				if(lasX >= b2.GetX() && lasY >= b2.GetY() && lasY <= b2.GetY() + 70 && laser == true && b2.GetAlive()&& b2.GetX() >= dudeX)
				{
					b2.ChangeAlive(false);
					laser = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser2
				if(lasX2 >= b2.GetX() && lasY2 >= b2.GetY() && lasY2 <= b2.GetY() + 70 && laser2 == true && b2.GetAlive() && b2.GetX() >= dudeX)
				{
					b2.ChangeAlive(false);
					laser2 = false;
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser3
				if(lasX3 >= b2.GetX() && lasY3 >= b2.GetY() && lasY3 <= b2.GetY() + 70 && laser3 == true && b2.GetAlive()&& b2.GetX() >= dudeX)
				{
					b2.ChangeAlive(false);
					laser3 = false;
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion

				if(b2.GetAlive() == true)
				{
					/*
					 * old skin
					g.FillEllipse(Brushes.Coral, b2.GetX(), b2.GetY(), 25, 25);
					g.FillRectangle(Brushes.DarkKhaki, b2.GetX(), b2.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.Black, b2.GetX() - 15, b2.GetY() + 30, 35, 15);
					g.FillPie(Brushes.DarkKhaki, b2.GetX(), b2.GetY(), 25, 25, 180, 180);
					g.FillPie(Brushes.DarkGray, b2.GetX(), b2.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.DarkGray, b2.GetX() + 15, b2.GetY() + 70, 10, 10, 0, 180);
					*/

					//pengiun skin
					
					g.FillEllipse(Brushes.Black, b2.GetX(), b2.GetY(), 25, 25);
					g.FillEllipse(Brushes.Black, b2.GetX(), b2.GetY()+15, 25, 20);
					g.FillRectangle(Brushes.Black, b2.GetX(), b2.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.White, b2.GetX()+5, b2.GetY() + 35, 15, 40);
					g.FillEllipse(Brushes.White, b2.GetX()+5, b2.GetY()+25, 15, 20);
					g.FillPie(Brushes.Orange, b2.GetX(), b2.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.Orange, b2.GetX() + 15, b2.GetY() + 70, 10, 10, 0, 180);
					g.FillEllipse(Brushes.White, b2.GetX()+4, b2.GetY()+4, 18, 18);
					g.FillEllipse(Brushes.Black, b2.GetX()+6, b2.GetY()+8, 5,5);
					g.FillEllipse(Brushes.Black, b2.GetX()+13, b2.GetY()+8, 5,5);
					g.FillRectangle(Brushes.Chocolate, b2.GetX() + 6, b2.GetY() + 40, 8, 9);
					g.DrawRectangle(Pens.Black, b2.GetX() + 6, b2.GetY() + 40, 8, 9);
					
					g.FillRectangle(Brushes.Gray, b2.GetX() - 15, b2.GetY() + 35, 15, 5);
					g.DrawRectangle(Pens.Black, b2.GetX()-16, b2.GetY() + 35, 16, 5);

					g.FillRectangle(Brushes.Gray, b2.GetX(), b2.GetY() + 35, 10, 8);
					g.DrawRectangle(Pens.Black, b2.GetX()-1, b2.GetY()+ 34,11,9);
					g.DrawLine(Pens.Black, b2.GetX()+1, b2.GetY() + 36, b2.GetX()+8, b2.GetY()+36);
					g.DrawLine(Pens.Black, b2.GetX()+1, b2.GetY() + 38, b2.GetX()+8, b2.GetY()+38);
					g.DrawLine(Pens.Black, b2.GetX()+1, b2.GetY() + 40, b2.GetX()+8, b2.GetY()+40);

					//nose
					Point[] triangle = new Point[] {new Point((int)b2.GetX()+8 , (int)b2.GetY()+15 ), new Point((int)b2.GetX()+18 , (int)b2.GetY()+15 ), new Point((int)b2.GetX()+13 , (int)b2.GetY()+25 )};
					g.FillPolygon(Brushes.Orange, triangle);

					b2.AddX(b2.GetSpeed());
				}

				if(b2.GetAlive() == true && b2.GetX() <= -25)
				{
					lives--;
					b2.ChangeAlive(false);
				}

				//they run into you															   
				if(b2.GetAlive() == true && (( b2.GetX() + 30 >= dudeX && b2.GetX() <= dudeX + 20) || (b2.GetX() >= dudeX && b2.GetX()*100 <= dudeX)) && (b2.GetY() >= dudeY - 70 && b2.GetY() <= dudeY + 70))
				{
					health--;
					hit = true;
					b2.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}
				//they hit your sheild
				if( b2.GetAlive() == true && shield == true && b2.GetX() > dudeX && b2.GetX() < dudeX + 50 && b2.GetY() > dudeY - 90 && b2.GetY() < dudeY + 70)
				{
					b2.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion

				#region Baddie 3
				#region Kill baddie 3	
				//kill baddie 2 with laser1
				if(lasX >= b3.GetX() && lasY >= b3.GetY() && lasY <= b3.GetY() + 70 && laser == true && b3.GetAlive()&& b3.GetX() >= dudeX)
				{
					b3.ChangeAlive(false);
					laser = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser2
				if(lasX2 >= b3.GetX() && lasY2 >= b3.GetY() && lasY2 <= b3.GetY() + 70 && laser2 == true && b3.GetAlive()&& b3.GetX() >= dudeX)
				{
					b3.ChangeAlive(false);
					laser2 = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser3
				if(lasX3 >= b3.GetX() && lasY3 >= b3.GetY() && lasY3 <= b3.GetY() + 70 && laser3 == true && b3.GetAlive()&& b3.GetX() >= dudeX)
				{
					b3.ChangeAlive(false);
					laser3 = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion

				if(b3.GetAlive() == true)
				{
					/*
					 * old skin
					g.FillEllipse(Brushes.Coral, b3.GetX(), b3.GetY(), 25, 25);
					g.FillRectangle(Brushes.DarkKhaki, b3.GetX(), b3.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.Black, b3.GetX() - 15, b3.GetY() + 30, 35, 15);
					g.FillPie(Brushes.DarkKhaki, b3.GetX(), b3.GetY(), 25, 25, 180, 180);
					g.FillPie(Brushes.DarkGray, b3.GetX(), b3.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.DarkGray, b3.GetX() + 15, b3.GetY() + 70, 10, 10, 0, 180);
					
					*/
					//penguin skin
					//pengiun skin
					
					g.FillEllipse(Brushes.Black, b3.GetX(), b3.GetY(), 25, 25);
					g.FillEllipse(Brushes.Black, b3.GetX(), b3.GetY()+15, 25, 20);
					g.FillRectangle(Brushes.Black, b3.GetX(), b3.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.White, b3.GetX()+5, b3.GetY() + 35, 15, 40);
					g.FillEllipse(Brushes.White, b3.GetX()+5, b3.GetY()+25, 15, 20);
					g.FillPie(Brushes.Orange, b3.GetX(), b3.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.Orange, b3.GetX() + 15, b3.GetY() + 70, 10, 10, 0, 180);
					g.FillEllipse(Brushes.White, b3.GetX()+4, b3.GetY()+4, 18, 18);
					g.FillEllipse(Brushes.Black, b3.GetX()+6, b3.GetY()+8, 5,5);
					g.FillEllipse(Brushes.Black, b3.GetX()+13, b3.GetY()+8, 5,5);
					g.FillRectangle(Brushes.Chocolate, b3.GetX() + 6, b3.GetY() + 40, 8, 9);
					g.DrawRectangle(Pens.Black, b3.GetX() + 6, b3.GetY() + 40, 8, 9);
					
					g.FillRectangle(Brushes.Gray, b3.GetX() - 15, b3.GetY() + 35, 15, 5);
					g.DrawRectangle(Pens.Black, b3.GetX()-16, b3.GetY() + 35, 16, 5);

					g.FillRectangle(Brushes.Gray, b3.GetX(), b3.GetY() + 35, 10, 8);
					g.DrawRectangle(Pens.Black, b3.GetX()-1, b3.GetY()+ 34,11,9);
					g.DrawLine(Pens.Black, b3.GetX()+1, b3.GetY() + 36, b3.GetX()+8, b3.GetY()+36);
					g.DrawLine(Pens.Black, b3.GetX()+1, b3.GetY() + 38, b3.GetX()+8, b3.GetY()+38);
					g.DrawLine(Pens.Black, b3.GetX()+1, b3.GetY() + 40, b3.GetX()+8, b3.GetY()+40);

					//nose
					Point[] triangle = new Point[] {new Point((int)b3.GetX()+8 , (int)b3.GetY()+15 ), new Point((int)b3.GetX()+18 , (int)b3.GetY()+15 ), new Point((int)b3.GetX()+13 , (int)b3.GetY()+25 )};
					g.FillPolygon(Brushes.Orange, triangle);

					b3.AddX(b3.GetSpeed());
				}

				if(b3.GetAlive() == true && b3.GetX() <= -25)
				{
					lives--;
					b3.ChangeAlive(false);
				}

				//they run into you															   
				if(b3.GetAlive() == true && (( b3.GetX() + 30 >= dudeX && b3.GetX() <= dudeX + 20) || (b3.GetX() >= dudeX && b3.GetX()*100 <= dudeX)) && (b3.GetY() >= dudeY - 70 && b3.GetY() <= dudeY + 70))
				{
					health--;
					hit = true;
					b3.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury", true);
				}
				//they hit your sheild
				if( b3.GetAlive() == true && shield == true && b3.GetX() > dudeX && b3.GetX() < dudeX + 50 && b3.GetY() > dudeY - 90 && b3.GetY() < dudeY + 70)
				{
					b3.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion

				#region Baddie 4
				#region Kill baddie 4	
				//kill baddie 2 with laser1
				if(lasX >= b4.GetX() && lasY >= b4.GetY() && lasY <= b4.GetY() + 70 && laser == true && b4.GetAlive()&& b4.GetX() >= dudeX)
				{
					b4.ChangeAlive(false);
					laser = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser2
				if(lasX2 >= b4.GetX() && lasY2 >= b4.GetY() && lasY2 <= b4.GetY() + 70 && laser2 == true && b4.GetAlive()&& b4.GetX() >= dudeX)
				{
					b4.ChangeAlive(false);
					laser2 = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser3
				if(lasX3 >= b4.GetX() && lasY3 >= b4.GetY() && lasY3 <= b4.GetY() + 70 && laser3 == true && b4.GetAlive()&& b4.GetX() >= dudeX)
				{
					b4.ChangeAlive(false);
					laser3 = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion

				if(b4.GetAlive() == true)
				{
					/*
					 * old skin
					g.FillEllipse(Brushes.Coral, b4.GetX(), b4.GetY(), 25, 25);
					g.FillRectangle(Brushes.DarkKhaki, b4.GetX(), b4.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.Black, b4.GetX() - 15, b4.GetY() + 30, 35, 15);
					g.FillPie(Brushes.DarkKhaki, b4.GetX(), b4.GetY(), 25, 25, 180, 180);
					g.FillPie(Brushes.DarkGray, b4.GetX(), b4.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.DarkGray, b4.GetX() + 15, b4.GetY() + 70, 10, 10, 0, 180);

					*/

					//penguin skin
					
					g.FillEllipse(Brushes.Black, b4.GetX(), b4.GetY(), 25, 25);
					g.FillEllipse(Brushes.Black, b4.GetX(), b4.GetY()+15, 25, 20);
					g.FillRectangle(Brushes.Black, b4.GetX(), b4.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.White, b4.GetX()+5, b4.GetY() + 35, 15, 40);
					g.FillEllipse(Brushes.White, b4.GetX()+5, b4.GetY()+25, 15, 20);
					g.FillPie(Brushes.Orange, b4.GetX(), b4.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.Orange, b4.GetX() + 15, b4.GetY() + 70, 10, 10, 0, 180);
					g.FillEllipse(Brushes.White, b4.GetX()+4, b4.GetY()+4, 18, 18);
					g.FillEllipse(Brushes.Black, b4.GetX()+6, b4.GetY()+8, 5,5);
					g.FillEllipse(Brushes.Black, b4.GetX()+13, b4.GetY()+8, 5,5);
					g.FillRectangle(Brushes.Chocolate, b4.GetX() + 6, b4.GetY() + 40, 8, 9);
					g.DrawRectangle(Pens.Black, b4.GetX() + 6, b4.GetY() + 40, 8, 9);
					
					g.FillRectangle(Brushes.Gray, b4.GetX() - 15, b4.GetY() + 35, 15, 5);
					g.DrawRectangle(Pens.Black, b4.GetX()-16, b4.GetY() + 35, 16, 5);

					g.FillRectangle(Brushes.Gray, b4.GetX(), b4.GetY() + 35, 10, 8);
					g.DrawRectangle(Pens.Black, b4.GetX()-1, b4.GetY()+ 34,11,9);
					g.DrawLine(Pens.Black, b4.GetX()+1, b4.GetY() + 36, b4.GetX()+8, b4.GetY()+36);
					g.DrawLine(Pens.Black, b4.GetX()+1, b4.GetY() + 38, b4.GetX()+8, b4.GetY()+38);
					g.DrawLine(Pens.Black, b4.GetX()+1, b4.GetY() + 40, b4.GetX()+8, b4.GetY()+40);

					//nose
					Point[] triangle = new Point[] {new Point((int)b4.GetX()+8 , (int)b4.GetY()+15 ), new Point((int)b4.GetX()+18 , (int)b4.GetY()+15 ), new Point((int)b4.GetX()+13 , (int)b4.GetY()+25 )};
					g.FillPolygon(Brushes.Orange, triangle);
					b4.AddX(b4.GetSpeed());
				}

				if(b4.GetAlive() == true && b4.GetX() <= -25)
				{
					lives--;
					b4.ChangeAlive(false);
				}

				//they run into you															   
				if(b4.GetAlive() == true && (( b4.GetX() + 30 >= dudeX && b4.GetX() <= dudeX + 20) || (b4.GetX() >= dudeX && b4.GetX()*100 <= dudeX)) && (b4.GetY() >= dudeY - 70 && b4.GetY() <= dudeY + 70))
				{
					health--;
					hit = true;
					b4.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}
				//they hit your sheild
				if( b4.GetAlive() == true && shield == true && b4.GetX() > dudeX && b4.GetX() < dudeX + 50 && b4.GetY() > dudeY - 90 && b4.GetY() < dudeY + 70)
				{
					b4.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion

				#region Baddie 5
				#region Kill baddie 5	
				//kill baddie 2 with laser1
				if(lasX >= b5.GetX() && lasY >= b5.GetY() && lasY <= b5.GetY() + 70 && laser == true && b5.GetAlive()&& b5.GetX() >= dudeX)
				{
					b5.ChangeAlive(false);
					laser = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser2
				if(lasX2 >= b5.GetX() && lasY2 >= b5.GetY() && lasY2 <= b5.GetY() + 70 && laser2 == true && b5.GetAlive()&& b5.GetX() >= dudeX)
				{
					b5.ChangeAlive(false);
					laser2 = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}

				//kill baddie 1 with laser3
				if(lasX3 >= b5.GetX() && lasY3 >= b5.GetY() && lasY3 <= b5.GetY() + 70 && laser3 == true && b5.GetAlive()&& b5.GetX() >= dudeX)
				{
					b5.ChangeAlive(false);
					laser3 = false;
					kills++;
					hits++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion

				if(b5.GetAlive() == true)
				{
					/*
					 * old skin
					g.FillEllipse(Brushes.Coral, b5.GetX(), b5.GetY(), 25, 25);
					g.FillRectangle(Brushes.DarkKhaki, b5.GetX(), b5.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.Black, b5.GetX() - 15, b5.GetY() + 30, 35, 15);
					g.FillPie(Brushes.DarkKhaki, b5.GetX(), b5.GetY(), 25, 25, 180, 180);
					g.FillPie(Brushes.DarkGray, b5.GetX(), b5.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.DarkGray, b5.GetX() + 15, b5.GetY() + 70, 10, 10, 0, 180);
					*/

					//pengiun skin
					
					g.FillEllipse(Brushes.Black, b5.GetX(), b5.GetY(), 25, 25);
					g.FillEllipse(Brushes.Black, b5.GetX(), b5.GetY()+15, 25, 20);
					g.FillRectangle(Brushes.Black, b5.GetX(), b5.GetY() + 25, 25, 50);
					g.FillRectangle(Brushes.White, b5.GetX()+5, b5.GetY() + 35, 15, 40);
					g.FillEllipse(Brushes.White, b5.GetX()+5, b5.GetY()+25, 15, 20);
					g.FillPie(Brushes.Orange, b5.GetX(), b5.GetY() + 70, 10, 10, 0, 180);
					g.FillPie(Brushes.Orange, b5.GetX() + 15, b5.GetY() + 70, 10, 10, 0, 180);
					g.FillEllipse(Brushes.White, b5.GetX()+4, b5.GetY()+4, 18, 18);
					g.FillEllipse(Brushes.Black, b5.GetX()+6, b5.GetY()+8, 5,5);
					g.FillEllipse(Brushes.Black, b5.GetX()+13, b5.GetY()+8, 5,5);
					g.FillRectangle(Brushes.Chocolate, b5.GetX() + 6, b5.GetY() + 40, 8, 9);
					g.DrawRectangle(Pens.Black, b5.GetX() + 6, b5.GetY() + 40, 8, 9);
					
					g.FillRectangle(Brushes.Gray, b5.GetX() - 15, b5.GetY() + 35, 15, 5);
					g.DrawRectangle(Pens.Black, b5.GetX()-16, b5.GetY() + 35, 16, 5);

					g.FillRectangle(Brushes.Gray, b5.GetX(), b5.GetY() + 35, 10, 8);
					g.DrawRectangle(Pens.Black, b5.GetX()-1, b5.GetY()+ 34,11,9);
					g.DrawLine(Pens.Black, b5.GetX()+1, b5.GetY() + 36, b5.GetX()+8, b5.GetY()+36);
					g.DrawLine(Pens.Black, b5.GetX()+1, b5.GetY() + 38, b5.GetX()+8, b5.GetY()+38);
					g.DrawLine(Pens.Black, b5.GetX()+1, b5.GetY() + 40, b5.GetX()+8, b5.GetY()+40);

					//nose
					Point[] triangle = new Point[] {new Point((int)b5.GetX()+8 , (int)b5.GetY()+15 ), new Point((int)b5.GetX()+18 , (int)b5.GetY()+15 ), new Point((int)b5.GetX()+13 , (int)b5.GetY()+25 )};
					g.FillPolygon(Brushes.Orange, triangle);

					b5.AddX(b5.GetSpeed());
				}

				if(b5.GetAlive() == true && b5.GetX() <= -25)
				{
					lives--;
					b5.ChangeAlive(false);
				}

				//they run into you															   
				if(b5.GetAlive() == true && (( b5.GetX() + 30 >= dudeX && b5.GetX() <= dudeX + 20) || (b5.GetX() >= dudeX && b5.GetX()*100 <= dudeX)) && (b5.GetY() >= dudeY - 70 && b5.GetY() <= dudeY + 70))
				{
					health--;
					hit = true;
					b5.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\Copy of sm64_injury.wav", true);
				}
				//they hit your sheild
				if( b5.GetAlive() == true && shield == true && b5.GetX() > dudeX && b5.GetX() < dudeX + 50 && b5.GetY() > dudeY - 90 && b5.GetY() < dudeY + 70)
				{
					b5.ChangeAlive(false);
					kills++;
					Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\smw_kick.wav", true);
				}
				#endregion





				Invalidate();
			}

			#region end game animation
			else
			{
				this.BackColor = Color.Black;
				Cursor.Show();
				Graphics g = e.Graphics;
				
				
				//-50 to the y

				percent =((float)hits/clicks*100);
				acc = (int)percent;
				if(clicks == 0)
					acc = 0;
				
				g.DrawString("Kills: "+kills, bigFont, Brushes.Red, 20,50);
				g.DrawString("Shots fired", bigFont, Brushes.Red, 400, 50);
				g.DrawString(clicks.ToString(), bigFont, Brushes.Red, 465, 90);
				g.DrawString("Hits", bigFont, Brushes.Red, 450, 130);
				g.DrawString(hits.ToString(), bigFont, Brushes.Red, 465, 170);				
				g.DrawString("Accuracy", bigFont, Brushes.Red, 20,125);
				g.DrawString(acc+"%", bigFont, Brushes.Red, 40, 175);

				//skull
				g.FillEllipse(Brushes.BlanchedAlmond, 225, 0, 150, 150);

				//upper jaw
				g.FillRectangle(Brushes.BlanchedAlmond, 260, 125, 10, 35);
				g.FillRectangle(Brushes.BlanchedAlmond, 285, 125, 10, 35);
				g.FillRectangle(Brushes.BlanchedAlmond, 310, 125, 10, 35);
				g.FillRectangle(Brushes.BlanchedAlmond, 335, 125, 10, 35);
				
				//jawY initalizes at 170
				//lower jaw
				g.FillPie(Brushes.BlanchedAlmond, 260, jawY, 85, 40, 0, 180);
				g.FillRectangle(Brushes.BlanchedAlmond, 270, jawY+10, 15, 10);
				g.FillRectangle(Brushes.BlanchedAlmond, 295, jawY+10, 15, 10);
				g.FillRectangle(Brushes.BlanchedAlmond, 320, jawY+10, 15, 10);
				
				if(jawY >150 && jawUp == true)
				{// && jawUp == true)
					jawY-=1;

				}
				if(jawY <= 151)
					jawUp = false;
				if(jawUp == false)
				{
					jawY += 1;
				}
				if(jawY == 170)
				{
					jawUp = true;
				}
				g.FillRectangle(Brushes.BlanchedAlmond, 335, 230, 10, 10);
				
				//cross bones
				g.DrawLine(bonePen, 190, 200, 410, 300);
				g.DrawLine(bonePen, 410, 200, 190, 300);
				
				//eyes
				g.FillEllipse(Brushes.Black, 260, 50, 30, 30); 
				g.FillEllipse(Brushes.Black, 310, 50, 30, 30); 
				g.DrawString("GAME OVER", bigFont, Brushes.Red, 190, 325);

				//nose	
				Point[] triangle = new Point[] {new Point(285, 120), new Point(315, 120), new Point(300, 90)};
				g.FillPolygon(Brushes.Black, triangle);

				//if(timer1.Enabled == false)
			//	{
					timer1.Enabled = true;
			//	}
				
				try
				{
					if(sound == true)
					{
						//Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\laugh1.wav", true);
						Background.Play(0, BufferPlayFlags.Looping);
						sound = false;
					}
				}
				catch(System.IO.FileNotFoundException)
				{
					
				}
				
				Invalidate();
				
			}
			#endregion

			base.OnPaint (e);
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.SkyBlue;
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 400);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 400);
			this.Name = "Form1";
			this.Text = "Form1";
			this.TopMost = true;

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

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\laugh1.wav", true);
		}


		private void timer2_Tick_1(object sender, System.EventArgs e)
		{
			Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile(@"\\msdn\Documents\Programming\donhubbard\My Documents\Programming\C#\Module 7\Ray Thursday\Ray Thursday\tetris_drm_tetrisbgm1.mid", true);
		}
	}

	public class Baddie
	{
		private float x;
		private float y;
		private bool alive;
		private float speed;
		
		private bool laser;
		private float lasX;
		private float lasY;
		private int lasFreq;


		public Baddie(float x, float y, bool alive, float speed, int lasFreq)
		{
			this.x = x;
			this.y = y;
			this.alive = alive;
			this.speed = speed;
			this.laser = false;
			this.lasX = 0;
			this.lasY = 0;
			this.lasFreq = lasFreq;

		}

		public bool Fire(int lasFreq)
		{
			Random r1 = new Random();
			if(r1.Next(1000) <= lasFreq)
			{
				
				this.lasX = this.GetX();
				this.lasY = this.GetY() + 25;
				this.laser = true;
				return this.laser;
			}
			else
				return this.laser;

		}
		public void SpawnLaser()
		{
			this.lasX = this.GetX() - 30;
			this.lasY = this.GetY() + 35;
		}
		public void ChangeLaser(bool laser)
		{
			this.laser = laser;
		}
		public bool GetLaser()
		{
			return this.laser;
		}
		public int GetFreq()
		{
			return this.lasFreq;
		}
		public float GetLasX()
		{
			return this.lasX;
		}
		public void AddLasX(float badLasSpeed)
		{
			this.lasX += badLasSpeed;
		}
		public float GetLasY()
		{
			return this.lasY;
		}

		public float GetX()
		{
			return this.x;
		}

		public float GetY()
		{
			return this.y;
		}

		public bool GetAlive()
		{
			return this.alive;
		}
	
		public float GetSpeed()
		{
			return this.speed;
		}
		public void AddX(float add)
		{
			this.x += add;
		}

		public void AddY(float add)
		{
			this.y += add;
		}

		public void ChangeAlive(bool alive)
		{
			this.alive = alive;
		}

		public void AddSpeed(float add)
		{
			this.speed += speed;
		}
		public void Spawn(float x, float y, float speed, int lasFreq)
		{
			this.alive = true;
			this.x = x;
			this.y = y;
			this.speed = speed;
			this.lasFreq = lasFreq;
			
		}
	
	

	
	}
}
