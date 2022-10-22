using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Media;
using Pirate_back.Properties;
//using Microsoft.DirectX;
//using Microsoft.DirectX.AudioVideoPlayback;
//using Microsoft.DirectX.DirectSound;

namespace Scallywags
{
	


	/*Donovan and Douglas Hubbard
	 * C# Intern Group project (2 modules)
	 * Contains about 3200 lines of code
	 * 
	 * This is a simple pirate game in which you sail around and try to sink the
	 * enemy ships. It uses almost every single concept learned to date, and took
	 * too long to program. It uses classes and inheritence extensivly, including
	 * some abstract classes. All lot of the methods or properties were written but
	 * fail to accomplish anything, but that is because a lot of the features that 
	 * were going to be put in the game had to be removed, because of deadline pressure.
	 * That is why there is an abstract projectile class, and an unused ship class.
	 * Many of the variables also remain unused. 
	 * 
	 * What we learned: It is difficult to program stuff like this on a large scale
	 * and it would have been easier to use dll files to write how the system worked.
	 * Planning is nesscary for such a large project like this. It made it so much
	 * easier, we probably should have spent more time doing that. Object oriented 
	 * programming is awesome! If you write it once you dont have to do it again.
	 * It is impossible to do this without using object oriented.
	 */

	/*
	 * September 2022
	 * Donovan Hubbard
	 * 
	 * While reviewing this code I realized that it won't work on a modern operating system so
	 * I made the minimum amount of changes possible to get a portable executable including:
	 * - adding the sound files as assets to the project
	 * - fixing the resolution
	 */

	
	public class Form1 : System.Windows.Forms.Form
	{
		//internal Device soundDevice = new Device();
		//internal SecondaryBuffernull;
		//public SecondaryBuffer splash;
		//internal SecondaryBuffer fire;
		//internal SecondaryBuffer shot;
        bool start = false;
		

		//internal SecondaryBuffer splash;
		//Microsoft.DirectX.AudioVideoPlayback.Audio x;
		int worldX = 350;
		int worldY = 400;
		//internal SecondaryBuffer pirate;

		Frigate Larry; //= new Frigate(1,0,0,0,350,500,0,0,0,"Larry",Color.FromArgb(154,36,157),0,0,0,true, bo);
		Frigate frigate1;// = new Frigate(1,1,1,1,100,100,0,0,0,"Shelby",Color.ForestGreen,0,0,0,true);
		Frigate frigate2, frigate3, frigate4, frigate5;
		Frigate[] ships = new Frigate[5];
		Seagull S1 = new Seagull(0,100);
		Seagull S2 = new Seagull(10,112);
		Seagull S3 = new Seagull(2,127);
		Land L1 = new Land(100,100);
		Land L2 = new Land(600, 600);
		Random r = new Random();
		int deaths = 0;
		int score = 0;

		
		float xWind = 0;
		float yWind = 0f;
		
		#region windows stuff to declare form stuff
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timerMaster;
		private System.Windows.Forms.ProgressBar weapon1Cooldown;
		private System.Windows.Forms.ProgressBar weapon2Cooldown;
		private System.Windows.Forms.ProgressBar weapon3Cooldown;
		private System.Windows.Forms.ProgressBar weapon4Cooldown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label cannon1Reload;
		private System.Windows.Forms.Label cannon2Reload;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label cannon3Reload;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label cannon4Reload;
		private System.Windows.Forms.Timer seagullTimer;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Timer healthTimer;
		private System.ComponentModel.IContainer components;
		#endregion

		public Form1()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			InitializeComponent();

            //Sound Stuff
            //soundDevice.SetCooperativeLevel(this, CooperativeLevel.Priority);

            //boom = new SecondaryBuffer("boom.wav", soundDevice);
            //splash = new SecondaryBuffer("poolsplash.wav", soundDevice);
            //fire = new SecondaryBuffer("drum roll.wav", soundDevice);
            //shot = new SecondaryBuffer("cannonShot.wav", soundDevice);
            //splash = new SecondaryBuffer("poolsplash.wav", soundDevice);
            //pirate = new SecondaryBuffer("pirates.mid", soundDevice);

            Larry = new Frigate(500,150,worldX,worldY,0,0,0,"Larry",Color.FromArgb(154,36,157), 500,0,0,true);
			frigate1 = new Frigate(500,350,worldX - 200,worldY+5010,6,0,0,"Shelby",Color.Wheat,500,0,0,true);	
			frigate2 = new Frigate(200,150,120,90,2,4,0,"Moe",Color.IndianRed,100,0,0,false);
			frigate3 = new Frigate(200,150,800,25,2,4,0,"Moe",Color.LightCyan,100,0,0,false);
			frigate4 = new Frigate(200,150,400,450,2,4,0,"Moe",Color.FromArgb(120,80,250),100,0,0,false);
			frigate5 = new Frigate(200,150,100,800,2,4,0,"Moe",Color.FromArgb(20,180,250),100,0,0,false);
			ships[0] = frigate1;
			ships[1] = frigate2;
			ships[2] = frigate3;
			ships[3] = frigate4;
			ships[3] = frigate5;

		}

		#region Windows Form Designer generated code
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
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timerMaster = new System.Windows.Forms.Timer(this.components);
			this.weapon1Cooldown = new System.Windows.Forms.ProgressBar();
			this.weapon2Cooldown = new System.Windows.Forms.ProgressBar();
			this.weapon3Cooldown = new System.Windows.Forms.ProgressBar();
			this.weapon4Cooldown = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cannon1Reload = new System.Windows.Forms.Label();
			this.cannon2Reload = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cannon3Reload = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cannon4Reload = new System.Windows.Forms.Label();
			this.seagullTimer = new System.Windows.Forms.Timer(this.components);
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.healthTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Blue;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(808, 768);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			// 
			// timerMaster
			// 
			this.timerMaster.Enabled = true;
			this.timerMaster.Interval = 10;
			this.timerMaster.Tick += new System.EventHandler(this.timerMaster_Tick);
			// 
			// weapon1Cooldown
			// 
			this.weapon1Cooldown.Location = new System.Drawing.Point(832, 456);
			this.weapon1Cooldown.Name = "weapon1Cooldown";
			this.weapon1Cooldown.Size = new System.Drawing.Size(160, 16);
			this.weapon1Cooldown.TabIndex = 1;
			// 
			// weapon2Cooldown
			// 
			this.weapon2Cooldown.Location = new System.Drawing.Point(832, 520);
			this.weapon2Cooldown.Name = "weapon2Cooldown";
			this.weapon2Cooldown.Size = new System.Drawing.Size(160, 16);
			this.weapon2Cooldown.TabIndex = 4;
			// 
			// weapon3Cooldown
			// 
			this.weapon3Cooldown.Location = new System.Drawing.Point(832, 600);
			this.weapon3Cooldown.Name = "weapon3Cooldown";
			this.weapon3Cooldown.Size = new System.Drawing.Size(160, 16);
			this.weapon3Cooldown.TabIndex = 5;
			// 
			// weapon4Cooldown
			// 
			this.weapon4Cooldown.Location = new System.Drawing.Point(832, 688);
			this.weapon4Cooldown.Name = "weapon4Cooldown";
			this.weapon4Cooldown.Size = new System.Drawing.Size(160, 16);
			this.weapon4Cooldown.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Snow;
			this.label1.Location = new System.Drawing.Point(832, 408);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 24);
			this.label1.TabIndex = 8;
			this.label1.Text = "Cannon 1";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Snow;
			this.label2.Location = new System.Drawing.Point(832, 480);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 24);
			this.label2.TabIndex = 9;
			this.label2.Text = "Cannon 2";
			// 
			// cannon1Reload
			// 
			this.cannon1Reload.BackColor = System.Drawing.Color.Transparent;
			this.cannon1Reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cannon1Reload.ForeColor = System.Drawing.Color.Snow;
			this.cannon1Reload.Location = new System.Drawing.Point(832, 432);
			this.cannon1Reload.Name = "cannon1Reload";
			this.cannon1Reload.Size = new System.Drawing.Size(160, 16);
			this.cannon1Reload.TabIndex = 11;
			this.cannon1Reload.Text = "Reloading...";
			this.cannon1Reload.Visible = false;
			// 
			// cannon2Reload
			// 
			this.cannon2Reload.BackColor = System.Drawing.Color.Transparent;
			this.cannon2Reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cannon2Reload.ForeColor = System.Drawing.Color.Snow;
			this.cannon2Reload.Location = new System.Drawing.Point(832, 504);
			this.cannon2Reload.Name = "cannon2Reload";
			this.cannon2Reload.Size = new System.Drawing.Size(160, 16);
			this.cannon2Reload.TabIndex = 12;
			this.cannon2Reload.Text = "Reloading...";
			this.cannon2Reload.Visible = false;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Snow;
			this.label3.Location = new System.Drawing.Point(832, 552);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 24);
			this.label3.TabIndex = 13;
			this.label3.Text = "Cannon 3";
			// 
			// cannon3Reload
			// 
			this.cannon3Reload.BackColor = System.Drawing.Color.Transparent;
			this.cannon3Reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cannon3Reload.ForeColor = System.Drawing.Color.Snow;
			this.cannon3Reload.Location = new System.Drawing.Point(832, 584);
			this.cannon3Reload.Name = "cannon3Reload";
			this.cannon3Reload.Size = new System.Drawing.Size(160, 16);
			this.cannon3Reload.TabIndex = 15;
			this.cannon3Reload.Text = "Reloading...";
			this.cannon3Reload.Visible = false;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Snow;
			this.label4.Location = new System.Drawing.Point(832, 632);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 24);
			this.label4.TabIndex = 16;
			this.label4.Text = "Cannon 4";
			// 
			// cannon4Reload
			// 
			this.cannon4Reload.BackColor = System.Drawing.Color.Transparent;
			this.cannon4Reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cannon4Reload.ForeColor = System.Drawing.Color.Snow;
			this.cannon4Reload.Location = new System.Drawing.Point(832, 664);
			this.cannon4Reload.Name = "cannon4Reload";
			this.cannon4Reload.Size = new System.Drawing.Size(160, 16);
			this.cannon4Reload.TabIndex = 18;
			this.cannon4Reload.Text = "Reloading...";
			this.cannon4Reload.Visible = false;
			// 
			// seagullTimer
			// 
			this.seagullTimer.Enabled = true;
			this.seagullTimer.Interval = 100000;
			this.seagullTimer.Tick += new System.EventHandler(this.seagullTimer_Tick);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(840, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 88);
			this.label5.TabIndex = 19;
			this.label5.Text = "Up: W   Down: S  Right: D   Left: A";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(824, 176);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 24);
			this.label6.TabIndex = 20;
			this.label6.Text = "Fire";
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(840, 200);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 72);
			this.label7.TabIndex = 21;
			this.label7.Text = "Port: J  Starboard: L   All: K";
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(824, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 24);
			this.label8.TabIndex = 22;
			this.label8.Text = "Move";
			// 
			// healthTimer
			// 
			this.healthTimer.Enabled = true;
			this.healthTimer.Interval = 20000;
			this.healthTimer.Tick += new System.EventHandler(this.healthTimer_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1028, 768);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cannon4Reload);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cannon3Reload);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cannon2Reload);
			this.Controls.Add(this.cannon1Reload);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.weapon4Cooldown);
			this.Controls.Add(this.weapon3Cooldown);
			this.Controls.Add(this.weapon2Cooldown);
			this.Controls.Add(this.weapon1Cooldown);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Pirate";
			//this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion

		protected override bool ProcessDialogKey(Keys keyData)//void OnKeyDown(KeyEventArgs e) 
		{

			if(keyData == Keys.Space)
			{
				Larry.FireSingle();
			}
			if(keyData == Keys.Q)
			{
                frigate1.FireSingle();
			}
			if(keyData == Keys.J)
			{
                Larry.FirePort();
			}
			if(keyData == Keys.L)
			{
                Larry.FireStarboard();
			}
			if(keyData == Keys.K)
			{
                Larry.FireAll();
			}
			
			if( Larry.GetSlide()== 0)
			{
				if(keyData == Keys.W)
				{
					Larry.SubtractYMomentum();
				}
				else if(keyData == Keys.D)
				{
					Larry.AddSlide(2);
					
				}

				else if(keyData == Keys.A)
				{
					Larry.AddSlide(-2);
				}
				
				else if(keyData == Keys.S && Larry.GetYMomentum() <0)
					Larry.AddYMomentum();
			}
			else if( Larry.GetSlide()== 2)
			{
				if(keyData == Keys.W)
				{
					Larry.AddXMomentum();
				}
				else if(keyData == Keys.D)
				{
					Larry.AddSlide(2);
				}

				else if(keyData == Keys.A)
				{
					Larry.AddSlide(-2);
				}
				
				else if(keyData == Keys.S && Larry.GetXMomentum() >0)
					Larry.SubtractXMomentum();	
			}

			else if( Larry.GetSlide()== 4)
			{
				if(keyData == Keys.W)
				{
					Larry.AddYMomentum();
				}
				else if(keyData == Keys.D)
				{
					Larry.AddSlide(2);
				}

				else if(keyData == Keys.A)
				{
					Larry.AddSlide(-2);
				}
				
				else if(keyData == Keys.S && Larry.GetYMomentum() >0)
					Larry.SubtractYMomentum();

			}
			else if( Larry.GetSlide()== 6)
			{
				if(keyData == Keys.W)
				{
					Larry.SubtractXMomentum();
				}
				else if(keyData == Keys.D)
				{
					Larry.AddSlide(2);
				}

				else if(keyData == Keys.A)
				{
					Larry.AddSlide(-2);
				}
				
				else if(keyData == Keys.S && Larry.GetXMomentum() <0)
					Larry.AddXMomentum();

			}
			
			

			if(Larry.GetSlide() == 8)
				Larry.AddSlide(-8);
			if(Larry.GetSlide() == -2)
				Larry.AddSlide(+8);
			
			
			this.pictureBox1.Invalidate();
			return base.ProcessDialogKey (keyData);

		}

		
		#region event handler methods
		protected override void OnLoad(EventArgs e)
		{
			//x = new Audio("pirates.mid", true);
			//x.Ending+=new EventHandler(x_Ending);
			//frigate1.FrigateSmoke(5);
			base.OnLoad (e);
			//Cursor.Hide();
				
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

				
			if(Larry.GetAlive() == true)
			{
				#region Land
				L1.DrawLand(e);
				L2.DrawLand(e);
				//L3.DrawLand(e);

				
				#endregion	

				#region CheckCollisions

				frigate1.CollideBall(Larry);
				frigate2.CollideBall(Larry);
				frigate3.CollideBall(Larry);
				frigate4.CollideBall(Larry);
				frigate5.CollideBall(Larry);

				L1.DrawLand(e);
			
				Larry.CollideBall(frigate1);
				Larry.CollideBall(frigate2);
				Larry.CollideBall(frigate3);
				Larry.CollideBall(frigate4);
				Larry.CollideBall(frigate5);
				Larry.DrawShip(e);
				frigate1.DrawShip(e);
				frigate2.DrawShip(e);
				frigate3.DrawShip(e);
				frigate4.DrawShip(e);
				frigate5.DrawShip(e);
				frigate1.Move(xWind, yWind);
				frigate2.Move(xWind, yWind);
				frigate3.Move(xWind, yWind);
				frigate4.Move(xWind, yWind);
				frigate5.Move(xWind, yWind);
				Larry.Move(xWind,yWind);
				Larry.FrigateCollideFrigate(this.frigate1);
				Larry.FrigateCollideFrigate(this.frigate2);
				Larry.FrigateCollideFrigate(this.frigate3);
				Larry.FrigateCollideFrigate(this.frigate4);
				Larry.FrigateCollideFrigate(this.frigate5);

				frigate1.FrigateCollideFrigate(frigate2);
				frigate1.FrigateCollideFrigate(frigate3);
				frigate1.FrigateCollideFrigate(frigate4);
				frigate1.FrigateCollideFrigate(frigate5);
				
				frigate2.FrigateCollideFrigate(frigate3);
				frigate2.FrigateCollideFrigate(frigate4);
				frigate2.FrigateCollideFrigate(frigate5);

				frigate3.FrigateCollideFrigate(frigate4);
				frigate3.FrigateCollideFrigate(frigate5);

				frigate4.FrigateCollideFrigate(frigate5);

			
				//g.DrawString(Larry.GetSlide().ToString(),new Font("Arial",18),Brushes.Red,0,50);
				g.DrawString("Crew  " + Larry.GetCrew().ToString() + " /150",new Font("Arial",16),Brushes.White,610,45);
				g.DrawString("Score", new Font("Arial", 16), Brushes.White, 610, 80);
				g.DrawString(score.ToString(), new Font("Arial", 16), Brushes.White, 670, 100);
			
				S1.DrawSeagull(e);
				S2.DrawSeagull(e);
				S3.DrawSeagull(e);
				g.FillRectangle(Brushes.Red,610,15,Larry.GetHp()/4,20);
				g.DrawRectangle(new Pen(Brushes.Black,3),610,15,125,20);
			
			
				//ball1.FireFrigate(Shelby, Shelby.Weapon1);
				//frigate1.Mirror(Larry);
				//frigate1.Collision(Larry)

				#endregion

				#region ChangeCoolDown
				Larry.AddCooldown();
				frigate1.AddCooldown();
				frigate2.AddCooldown();
				frigate3.AddCooldown();
				frigate4.AddCooldown();
				frigate5.AddCooldown();

				#endregion
			
					
			}
			else
			{
				this.pictureBox1.BackColor = Color.Black;
				this.BackColor = Color.Black;
				this.label1.Visible = false;
				this.label2.Visible = false;
				this.label3.Visible = false;
				this.label4.Visible = false;
				this.label5.Visible = false;
				this.label6.Visible = false;
				this.label7.Visible = false;
				this.label8.Visible = false;
				this.BackgroundImage = null;

				g.DrawString("GAME OVER", new Font(FontFamily.GenericMonospace, 40), Brushes.Red, this.Width/2-150, this.Height/2-30);

			}

		}

		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

		}
		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void timerMaster_Tick(object sender, System.EventArgs e)
		{
			if (start)
			{
				//this if statement was added because the tickevent was occuring before all the objects could be initialized
					
					
				if(Larry !=null)
				{
					#region upkeep
					this.pictureBox1.Invalidate();
						
					frigate1.DumbAI(r);
					frigate2.DumbAI(r);
					frigate3.DumbAI(r);
					frigate4.DumbAI(r);
					frigate5.DumbAI(r);
				
					#region land 
					L1.FrigateCollideLand(Larry);
					L1.FrigateCollideLand(frigate1);
					L1.FrigateCollideLand(frigate2);
					L1.FrigateCollideLand(frigate3);
					L1.FrigateCollideLand(frigate4);
					L1.FrigateCollideLand(frigate5);

					L2.FrigateCollideLand(Larry);
					L2.FrigateCollideLand(frigate1);
					L2.FrigateCollideLand(frigate2);
					L2.FrigateCollideLand(frigate3);
					L2.FrigateCollideLand(frigate4);
					L2.FrigateCollideLand(frigate5);

					//						L3.FrigateCollideLand(Larry);
					//						L3.FrigateCollideLand(frigate1);
					//						L3.FrigateCollideLand(frigate2);
					//						L3.FrigateCollideLand(frigate3);
					//						L3.FrigateCollideLand(frigate4);
					//						L3.FrigateCollideLand(frigate5);
						
			
					#region CoolDown Bars
					weapon1Cooldown.Value = (int)Larry.Weapon1.GetCooldown();
					if(weapon1Cooldown.Value == 100)
					{
						cannon1Reload.Visible = false;
						weapon1Cooldown.Visible = false;
					}
					else
					{	
						cannon1Reload.Visible = true;
						weapon1Cooldown.Visible = true;
					}
					weapon2Cooldown.Value = (int)Larry.Weapon2.GetCooldown();
					if(weapon2Cooldown.Value == 100)
					{
						cannon2Reload.Visible = false;
						weapon2Cooldown.Visible = false;
					}
					else
					{
						cannon2Reload.Visible = true;
						weapon2Cooldown.Visible = true;
					}
					weapon3Cooldown.Value = (int)Larry.Weapon3.GetCooldown();
					if(weapon3Cooldown.Value == 100)
					{
						cannon3Reload.Visible = false;
						weapon3Cooldown.Visible = false;
					}
					else
					{
						cannon3Reload.Visible = true;
						weapon3Cooldown.Visible = true;
					}
					weapon4Cooldown.Value = (int)Larry.Weapon4.GetCooldown();
					if(weapon4Cooldown.Value == 100)
					{
						cannon4Reload.Visible = false;
						weapon4Cooldown.Visible = false;
					}
					else
					{
						cannon4Reload.Visible = true;
						weapon4Cooldown.Visible = true;
					}
					#endregion
					#endregion
					#endregion
					#region spawing stuff
					if(frigate1.GetAlive() == false)
					{
						deaths++;
						score+= 1000;
						frigate1.Spawn(r);
					}
					if(frigate2.GetAlive() == false)
					{
						if(deaths > 3)
						{
								
							deaths++;
							score+= 1000;
							frigate2.Spawn(r);
						}
					}
					if(frigate3.GetAlive() == false)
					{
						if(deaths > 7)
						{
								
							deaths++;
							score+= 1000;
							frigate3.Spawn(r);
								
						}
					}
					if(frigate4.GetAlive() == false)
					{
						if(deaths > 12)
						{

							deaths++;
							score+= 1000;
							frigate4.Spawn(r);
						}
					}
					if(frigate5.GetAlive() == false)
					{
						if(deaths > 20)
						{

							deaths++;
							score+= 1000;
							frigate5.Spawn(r);
						}
					}
					#endregion
				}
					
			}
			start = true;
				
					
			
		}

		private void x_Ending(object sender, EventArgs e)
		{
			//x.CurrentPosition = 0;
			//x.Play();
			
		}

		private void seagullTimer_Tick(object sender, System.EventArgs e)
		{
			Random seagulls = new Random();
			int random = seagulls.Next(1500);
			S1.SetXY(0,random);
			S2.SetXY(+3,random+12);
			S3.SetXY(-3,random+29);
			//Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile("Seagull.wav",true);
			//seagullSound.Play(0,BufferPlayFlags.Default);
			
		}
		#endregion
		
		static void Main() 
		{
			try
			{
				Form1 myForm = new Form1();
				Application.Run(myForm);
			}
			catch(System.StackOverflowException e)
			{
				Application.Exit();
			}
		}

		private void healthTimer_Tick(object sender, System.EventArgs e)
		{
			if(Larry.GetAlive() == true && Larry.GetSinkCount() == 0)
			{
				Larry.AddHP(Larry.GetCrew()/3);
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.timerMaster.Enabled = true;
		}


	}
	public class Ship
	{
		protected int cannons,crew,maxCrew, hp,maxHp, slide,ball,grape,chain,sinkCount;
		protected float x,y,yMomentum,xMomentum,weight,maxMomentum,acceleration;
		protected string name;
		protected bool alive;
		protected Brush brush;
		protected Color color;
		//public SecondaryBuffernull;
		//public SecondaryBuffernull;
		//public SecondaryBuffernull;
		//public SecondaryBuffer shot;
		protected Smoke Smoke1,Smoke2,Smoke3,Smoke4,Smoke5;
		
		

		public Ship(int hp,int crew,float x, float y,int slide, int cannons,int weight,string name, Color color, int ball, int grape, int chain, bool alive)
		{
			this.brush = new SolidBrush(color);
			this.hp= hp;
			this.crew = crew;
			this.maxCrew= maxCrew;
			this.x = x;
			this.y = y;
			this.slide = slide;
			this.cannons = cannons;
			this.weight = weight; 
			this.name = name;
			this.xMomentum = 0;
			this.yMomentum = 0;
			this.color = color;
			this.alive = alive;
			//this.boom =null;
			//this.boom.Volume = -200;
			//this.splash =null;
			//this.fire =null;
			//this.shot = shot;
			this.ball = ball;
			this.sinkCount = 0;
			this.Smoke1 = new Smoke(this.x,this.y,3);
			this.Smoke2 = new Smoke(this.x,this.y,6);
			this.Smoke3 = new Smoke(this.x,this.y,8);
			this.Smoke4 = new Smoke(this.x,this.y,1);
			this.Smoke5 = new Smoke(this.x,this.y,10);
			
			//this.splash.Volume = -500;
		}
		
		virtual	public void DrawShip()
		{
		}

		public void Mirror(Ship followedShip)
		{
			#region Match Slide
			this.slide = followedShip.slide + 4;
			if(this.slide >= 8)
			{
				this.slide -= 8;
			}
			#endregion
			this.xMomentum = followedShip.xMomentum *-1;
			this.yMomentum = followedShip.yMomentum *-1;
		}

		public int GetHp()
		{
			return this.hp;
		}
		public void Move(float xWind, float yWind)
		{
			
			if(this.alive == true && this.sinkCount == 0)
			{
				#region PacMan Screen jump thing
				//this will move the ship to the other side of the form if you go off screen, like on pacman
				//right side of the screen
				if(this.x < -100)
				{
					this.x = 800;
				}
				if(this.x > 800)
				{
					this.x = -75;
				}
				if(this.y < -100)
				{
					this.y = 820;
				}
				if(this.y > 821)
				{
					this.y = -99;
				}

				#endregion
				#region Max Momentum
				if(this.xMomentum > this.maxMomentum)
				{
					this.xMomentum = this.maxMomentum;
				}

				else if(this.xMomentum < this.maxMomentum*-1)
				{
					this.xMomentum = this.maxMomentum * -1;
				}

				else if(this.yMomentum > this.maxMomentum)
				{
					this.yMomentum = this.maxMomentum;
				}

				else if(this.yMomentum < this.maxMomentum * -1)
				{
					this.yMomentum = this.maxMomentum * -1;
				}
				#endregion


				this.x += this.xMomentum;
				this.y += this.yMomentum;
			
				//the wind must be added to the x and the y
				//instead of momentum because if that were so
				//the wind would be ever increasing
				this.x += xWind;
				this.y += yWind;
			
				//remeber that the momentum is always moving towards 0
				if(this.xMomentum > 0) 
					this.xMomentum -=.01f;
			
				else if(this.xMomentum <0)
					this.xMomentum += .01f;

				if(this.yMomentum > 0) 
					this.yMomentum -=.01f;
			
				else if(this.yMomentum <0)
					this.yMomentum += .01f;
			}

		}
		
		#region Get/Add x/yMomentum methods()
		public float GetXMomentum()
		{
			return this.xMomentum;
		}

		public float GetYMomentum()
		{
			return this.yMomentum;
		}
		
		public void AddXMomentum()
		{
			this.xMomentum += this.acceleration;
		}

		public void SubtractXMomentum()
		{
			this.xMomentum -= this.acceleration;
		}
	
		public void AddYMomentum()
		{
			this.yMomentum += this.acceleration;
		}

		public void SubtractYMomentum()
		{
			this.yMomentum -= this.acceleration;
		}
		#endregion

		public void MultiplyX(float multiply)
		{
			this.x *= multiply;
		}
		
		public void SwitchXY()
		{
			float saveX = this.x;
			this.x = this.y;
			this.y = saveX;
		}

		
		public float GetSlide()
		{
			return this.slide;
		}

		public void AddSlide(int slide)
		{
			if(this.alive == true && this.sinkCount == 0)
			{
				this.slide += slide;
			}
		}

		public int GetCrew()
		{
			return this.crew;
		}
		public int GetBallAmmo()
		{
			return this.ball;
		}
		public void AddBallAmmo(int add)
		{
			this.ball += add;
		}
		public bool GetAlive()
		{
			return this.alive;
		}
		public int GetSinkCount()
		{
			return this.sinkCount;
		}
		public void AddHP(int addedHP)
		{
			this.hp += addedHP;
			if(this.hp>this.maxHp)
			{
				this.hp = this.maxHp;
			}
		}
	}


	public class Frigate : Ship
	{
		public Weapon Weapon1,Weapon2,Weapon3,Weapon4;
		public Rectangle hitZone1, hitZone2;
		
		public Frigate (int hp,int crew,float x, float y,int slide, int cannons,int weight,string name, Color color, int ball, int grape, int chain, bool alive):base(hp,crew,x,y,slide,cannons,weight,name,color,ball,grape,chain,alive)
		{
			this.maxHp = 500;
			this.maxCrew = 150;
			this.maxMomentum = 3f;
			this.acceleration = .5f;
			this.Weapon1 = new Weapon(0,0,.7f);
			this.Weapon2 = new Weapon(0,0,.7f);
			this.Weapon3 = new Weapon(0,0,.7f);
			this.Weapon4 = new Weapon(0,0,.7f);
			this.alive = alive;
			
		}
		
		public void FrigateCollideFrigate(Frigate enemy)
		{
			
			if(this.FrigateIntersectFrigate(enemy))
			{
				//enemy.hp -= 50;
				//this.hp -=50;
				#region 0 and 4
				if(enemy.slide ==0 || enemy.slide == 4)
				{
					if(this.slide ==0 && enemy.slide == 0)
					{
						if(this.y > enemy.y)
						{
							this.y = enemy.y+165;
							enemy.yMomentum += this.yMomentum;
							this.yMomentum *=-1;
						}
					}
					if(this.slide ==0 && enemy.slide == 4)
					{
						if(this.y > enemy.y)
						{
							this.y = enemy.hitZone2.Bottom + 75;
							enemy.yMomentum += this.yMomentum;
							this.yMomentum *=-1;
						}
					}
					
					if(this.slide ==2)
					{
						if(this.x<enemy.x)
						{
							this.x = enemy.x-175;
							enemy.xMomentum += this.xMomentum;
							this.xMomentum *=-1;	
						}

					}
					
					if(this.slide ==6)
					{

						if(this.y < enemy.y && this.x +130 > enemy.x & this.x < enemy.x +50)
						{
							this.y = enemy.y+165;
							enemy.yMomentum += this.yMomentum;
							this.yMomentum *=-1;
						}


						if(this.x>enemy.x)
						{
							this.x = enemy.x+180;
							enemy.xMomentum += this.xMomentum;
							this.xMomentum *=-1;	
						}
					}
					
					if(this.slide == 4)
					{
						
						if(this.hitZone2.Bottom >= enemy.y )
						{
							this.y = enemy.y - 175;
							enemy.yMomentum += this.yMomentum;
							this.yMomentum *=-1;	
						}
					}
				}
				#endregion

				#region slide 2, 6
				if(enemy.slide == 2 || enemy.slide == 6)
				{
					if(this.slide == 0)
					{
						//if(this.hitZone1.Top < enemy.hitZone2.Bottom || this.hitZone1.Top < enemy.hitZone1.Bottom)
					{
						this.y = enemy.hitZone1.Bottom+100;
						enemy.yMomentum += this.yMomentum;
						this.yMomentum *=-1;

					}
					}
					
					if(this.slide ==2)
					{
						if(enemy.slide == 2)
						{
							this.x = enemy.hitZone1.Left - 195;
							enemy.xMomentum += this.xMomentum;
							this.xMomentum *=-1;	
						}
						else
						{
							this.x = enemy.hitZone2.Left - 195;
							enemy.xMomentum += this.xMomentum;
							this.xMomentum *=-1;
						}

					}
					
					if(this.slide ==6)
					{

						//						if(this.x < enemy.x && this.y +130 > enemy.y & this.y< enemy.y +50)
						if(enemy.slide == 2)
						{
							this.x = enemy.hitZone2.Right+170;
							enemy.xMomentum += this.xMomentum;
							this.xMomentum *=-1;
						}


						else if(enemy.slide == 6)
						{
							this.x = enemy.hitZone1.Right+170;
							enemy.xMomentum += this.xMomentum;
							this.xMomentum *=-1;	
						}
					}
					
					if(this.slide == 4)
					{
						
						//if(enemy.slide == 2)
					{
						this.y = enemy.hitZone1.Top-230;
						enemy.yMomentum += this.yMomentum;
						this.yMomentum *=-1;	
					}
					}
				}
				#endregion
				
			}
	

		}
		
		public bool FrigateIntersectFrigate(Frigate enemy)
		{
			bool collide = false;
			if(this.alive && enemy.alive)
			{
				
				
				if(this.hitZone1.IntersectsWith(enemy.hitZone1))
					collide = true;
				if(this.hitZone1.IntersectsWith(enemy.hitZone2))
					collide = true;
				if(this.hitZone2.IntersectsWith(enemy.hitZone1))
					collide = true;
				if(this.hitZone2.IntersectsWith(enemy.hitZone2))
					collide = true;
			}
			return collide;
		}
		
		public void FrigateSmoke(int number)
		{
			
			#region Slide 0
			if(this.slide == 0)
			{
				if(number >=1)
				{
					this.Smoke1.SetAlive(true);
					this.Smoke1.SetXY(this.x+23, this.y + 80);
				}
				if(number >=2 )
				{
					this.Smoke2.SetAlive(true);
					this.Smoke2.SetXY(this.x+23, this.y + 65);
				}
				if(number >=3)
				{
					this.Smoke3.SetAlive(true);
					this.Smoke3.SetXY(this.x+35,this.y + 50);
				}
				if(number >=4)
				{
					this.Smoke4.SetAlive(true);
					this.Smoke4.SetXY(this.x+30,this.y + 10);
				}
				if(number >=5)
				{
					this.Smoke5.SetAlive(true);
					this.Smoke5.SetXY(this.x+15,this.y );
				}
			}
			#endregion
			#region Slide 2
			if(this.slide == 2)
			{
				if(number >=1)
				{
					this.Smoke1.SetAlive(true);
					this.Smoke1.SetXY(this.x+23, this.y + 80);
				}
				if(number >=2 )
				{
					this.Smoke2.SetAlive(true);
					this.Smoke2.SetXY(this.x+29, this.y + 65);
				}
				if(number >=3)
				{
					this.Smoke3.SetAlive(true);
					this.Smoke3.SetXY(this.x+33,this.y + 50);
				}
				if(number >=4)
				{
					this.Smoke4.SetAlive(true);
					this.Smoke4.SetXY(this.x+70,this.y + 80);
				}
				if(number >=5)
				{
					this.Smoke5.SetAlive(true);
					this.Smoke5.SetXY(this.x+100,this.y+70 );
				}
			}
			#endregion
			#region Slide 4
			if(this.slide == 4)
			{
				if(number >=1)
				{
					this.Smoke1.SetAlive(true);
					this.Smoke1.SetXY(this.x+23, this.y + 90);
				}
				if(number >=2 )
				{
					this.Smoke2.SetAlive(true);
					this.Smoke2.SetXY(this.x+29, this.y + 120);
				}
				if(number >=3)
				{
					this.Smoke3.SetAlive(true);
					this.Smoke3.SetXY(this.x+13,this.y + 200);
				}
				if(number >=4)
				{
					this.Smoke4.SetAlive(true);
					this.Smoke4.SetXY(this.x+30,this.y + 60);
				}
				if(number >=5)
				{
					this.Smoke5.SetAlive(true);
					this.Smoke5.SetXY(this.x+15,this.y+160 );
				}
			}
			#endregion
			#region Slide 6
			if(this.slide == 6)
			{
				if(number >=1)
				{
					this.Smoke1.SetAlive(true);
					this.Smoke1.SetXY(this.x-10, this.y+20);
				}
				if(number >=2 )
				{
					this.Smoke2.SetAlive(true);
					this.Smoke2.SetXY(this.x+10, this.y + 60);
				}
				if(number >=3)
				{
					this.Smoke3.SetAlive(true);
					this.Smoke3.SetXY(this.x-13,this.y + 50);
				}
				if(number >=4)
				{
					this.Smoke4.SetAlive(true);
					this.Smoke4.SetXY(this.x,this.y + 10);
				}
				if(number >=5)
				{
					this.Smoke5.SetAlive(true);
					this.Smoke5.SetXY(this.x-20,this.y+60 );
				}
			}
			#endregion


		}
		public void DrawShip(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			
			if(this.alive)
			{

				if(this.hp <= 100 && this.Smoke1.GetSmokeCount() == 0)
				{
					this.FrigateSmoke(2);
				}
				else if(this.hp <= 50 && this.Smoke3.GetSmokeCount() == 0 && this.Smoke4.GetSmokeCount() == 0 && this.Smoke5.GetSmokeCount() ==0)
				{
					this.FrigateSmoke(3);
				}
				else if(this.hp <= 25 && this.Smoke3.GetSmokeCount() == 0 && this.Smoke4.GetSmokeCount() == 0 && this.Smoke5.GetSmokeCount() ==0)
				{
					this.FrigateSmoke(5);
				}

				this.Weapon1.ball.DrawBall(e);
				this.Weapon2.ball.DrawBall(e);
				this.Weapon3.ball.DrawBall(e);
				this.Weapon4.ball.DrawBall(e);
				
				if(this.slide == 0)
				{
					this.Weapon1.ChangeXY(this.x+7,this.y+45);
					this.Weapon2.ChangeXY(this.x+7,this.y+65);
					this.Weapon3.ChangeXY(this.x+57,this.y+45);
					this.Weapon4.ChangeXY(this.x+57,this.y+65);


					#region draw ship @ slide == 0
					Point[] head = {new Point((int)x, (int)y-10), new Point((int)x + 25,(int)y-60), new Point ( (int)x + 50, (int)y - 10)};	
					if(this.sinkCount <= 40)
					{
						g.DrawEllipse(Pens.Black,x,y + 65,50,40);
						//g.DrawLine(Pens.Yellow,this.x+7, this.y+65,this.x+1000,this.y+65);
						g.FillPolygon(this.brush,head);
						g.DrawPolygon(Pens.Black,head);
						g.FillRectangle(this.brush,x,y-10,50,100);
						g.FillEllipse(this.brush,x,y + 65,50,40);
						g.DrawLine(Pens.Black,x,y-10,x,y+90);
						g.DrawLine(Pens.Black,x+50,y-10,x+50,y+90);	
					}
					if(this.sinkCount >= 40)
					{
						SolidBrush sink = new SolidBrush(Color.FromArgb(0,120,255));
						g.FillEllipse(sink,this.x-10, this.y-70,75,200);
					}
					if(this.sinkCount <=150)
					{
						g.FillRectangle(Brushes.BurlyWood,x + 5,y-10,40,95);
						g.DrawLine(Pens.Chocolate,x+10,y-10,x+10,y+85);
						g.DrawLine(Pens.Chocolate,x+15,y-10,x+15,y+85);
						g.DrawLine(Pens.Chocolate,x+20,y-10,x+20,y+85);
						g.DrawLine(Pens.Chocolate,x+25,y-10,x+25,y+85);
						g.DrawLine(Pens.Chocolate,x+30,y-10,x+30,y+85);
						g.DrawLine(Pens.Chocolate,x+35,y-10,x+35,y+85);
						g.DrawLine(Pens.Chocolate,x+40,y-10,x+40,y+85);
						g.DrawRectangle(Pens.Black,x + 5,y-10,40,95);
						g.FillRectangle(Brushes.Black,x-5,y+40,15,10);//cannon 1
						g.FillEllipse(Brushes.Black,x+5,y+40,10,10);
						g.FillRectangle(Brushes.Black,x-5,y+60,15,10);
						g.FillEllipse(Brushes.Black,x+5,y+60,10,10);
						g.FillRectangle(Brushes.Black,x+40,y+60,15,10);
						g.FillEllipse(Brushes.Black,x+35,y+60,10,10);
						g.FillRectangle(Brushes.Black,x+40,y+40,15,10);
						g.FillEllipse(Brushes.Black,x+35,y+40,10,10);
						Pen helm = new Pen(this.brush,2);
						g.DrawEllipse(helm,x+20,y+5,10,5);//brown box
					}
					if(this.sinkCount <= 250)
					{
						g.FillEllipse(Brushes.White,x-10,y+15,70,20);
						g.DrawEllipse(Pens.Black,x-10,y+15,70,20);
						g.FillEllipse(this.brush,x-15,y+25,80,10);
						g.DrawEllipse(Pens.Black,x-15,y+25,80,10);
					}
					if(this.sinkCount >=275)
					{
						this.sinkCount = 0;
						this.alive = false;
					}
					//hit regions
					//g.FillRectangle(Brushes.Yellow, x+8, y-55, 33, 45);

					#endregion
					#region Draw MuzzleFlash
					
					if(this.Weapon1.GetCooldown() <= 10)
					{
						Point[] flash = {new Point((int)Weapon1.GetX()-10, (int)this.Weapon1.GetY()-5), new Point((int)Weapon1.GetX()-10, (int)this.Weapon1.GetY()+5), new Point((int)Weapon1.GetX()-17, (int)this.Weapon1.GetY()+7), new Point((int)Weapon1.GetX()-12, (int)this.Weapon1.GetY()+2) ,new Point((int)Weapon1.GetX()-20, (int)this.Weapon1.GetY()), new Point((int)Weapon1.GetX()-12, (int)this.Weapon1.GetY()-2), new Point((int)this.Weapon1.GetX()-17, (int)this.Weapon1.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon2.GetCooldown() <= 10)
					{
						Point[] flash = {new Point((int)Weapon2.GetX()-10, (int)this.Weapon2.GetY()-5), new Point((int)Weapon2.GetX()-10, (int)this.Weapon2.GetY()+5), new Point((int)Weapon2.GetX()-17, (int)this.Weapon2.GetY()+7), new Point((int)Weapon2.GetX()-12, (int)this.Weapon2.GetY()+2) ,new Point((int)Weapon2.GetX()-20, (int)this.Weapon2.GetY()), new Point((int)Weapon2.GetX()-12, (int)this.Weapon2.GetY()-2), new Point((int)this.Weapon2.GetX()-17, (int)this.Weapon2.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon3.GetCooldown() <= 10)
					{
						Point[] flash = {new Point((int)Weapon3.GetX(), (int)this.Weapon3.GetY()-5), new Point((int)Weapon3.GetX(), (int)this.Weapon3.GetY()+5), new Point((int)Weapon3.GetX()+7, (int)this.Weapon3.GetY()+7), new Point((int)Weapon3.GetX()+2, (int)this.Weapon3.GetY()+2) ,new Point((int)Weapon3.GetX()+10, (int)this.Weapon3.GetY()), new Point((int)Weapon3.GetX()+2, (int)this.Weapon3.GetY()-2), new Point((int)this.Weapon3.GetX()+7, (int)this.Weapon3.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon4.GetCooldown() <= 10)
					{
						Point[] flash = {new Point((int)Weapon4.GetX(), (int)this.Weapon4.GetY()-5), new Point((int)Weapon4.GetX(), (int)this.Weapon4.GetY()+5), new Point((int)Weapon4.GetX()+7, (int)this.Weapon4.GetY()+7), new Point((int)Weapon4.GetX()+2, (int)this.Weapon4.GetY()+2) ,new Point((int)Weapon4.GetX()+10, (int)this.Weapon4.GetY()), new Point((int)Weapon4.GetX()+2, (int)this.Weapon4.GetY()-2), new Point((int)this.Weapon4.GetX()+7, (int)this.Weapon4.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					
					//g.FillEllipse(Brushes.Yellow, this.Weapon1.GetX(), this.Weapon1.GetY(), 5, 5);

					#endregion
					#region Smoke
					
					if(this.Smoke1.GetAlive())
					{
						Smoke1.DrawSmoke(e, this.x+23, this.y + 80);
					}
					
					if(this.Smoke2.GetAlive())
					{
						Smoke2.DrawSmoke(e, this.x+29, this.y - 40);
					}
					if(this.Smoke3.GetAlive())
					{
						Smoke3.DrawSmoke(e, this.x+13, this.y + 50);
					}
					if(this.Smoke4.GetAlive())
					{
						Smoke4.DrawSmoke(e, this.x+30, this.y + 10);
					}
					if(this.Smoke5.GetAlive())
					{
						Smoke5.DrawSmoke(e, this.x+15, this.y );
					}


					#endregion
					#region Rectangle
					this.hitZone1.X = (int)this.x;
					this.hitZone1.Y = (int)this.y-20;
					this.hitZone1.Width = 50;
					this.hitZone1.Height = 125;
					this.hitZone2.X = (int)this.x+8;
					this.hitZone2.Y = (int)this.y-60;
					this.hitZone2.Width = 35;
					this.hitZone2.Height = 40;
					//g.DrawRectangle(new Pen(Brushes.Green,3),this.hitZone1);
					//g.DrawRectangle(new Pen(Brushes.Green,3),this.hitZone2);
					#endregion
					
				
				}
				
				else if(this.slide == 2)
				{
					this.Weapon1.ChangeXY(this.x+70,this.y+45);
					this.Weapon2.ChangeXY(this.x+50,this.y+45);
					this.Weapon3.ChangeXY(this.x+70,this.y+95);
					this.Weapon4.ChangeXY(this.x+50,this.y+95);
					#region draw ship @ slide == 2
					Point[] head = {new Point((int)x + 120, (int)y +50), new Point((int)x + 170,(int)y +75), new Point ( (int)x+120, (int)y + 100)};	
				
					if(this.sinkCount <= 40)
					{
						g.DrawEllipse(Pens.Black,x,y+50 ,40,50);
						g.FillPolygon(this.brush,head);
						g.FillRectangle(this.brush,x+20,y+50,100,50);//main rectangle
						g.FillEllipse(this.brush,x,y + 50,40,50);//stern
					}
					if(this.sinkCount > 40)
					{
						SolidBrush sink = new SolidBrush(Color.FromArgb(0,120,255));
						g.FillEllipse(sink,this.x-25, this.y+40,200,75);
					}
					if(this.sinkCount <=150)
					{
						g.FillRectangle(Brushes.BurlyWood,x+20,y+55,95,40);//deck
						g.DrawLine(Pens.Chocolate,x+20,y+60,x+115,y+60);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+65,x+115,y+65);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+70,x+115,y+70);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+75,x+115,y+75);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+80,x+115,y+80);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+85,x+115,y+85);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+90,x+115,y+90);//lines on the deck
						g.DrawRectangle(Pens.Black,x+20,y+55,95,40);//border to deck
						Pen helm = new Pen(this.brush,2);//pen for little circle
						g.DrawEllipse(helm,x+100,y+70,5,10);//little square it is actually a circle
						g.FillRectangle(Brushes.Black,x+60,y+45,10,15);//Cannon 1 Rectangle
						g.FillEllipse(Brushes.Black,x+60,y+55,10,10);//cannon 1 cirlce
						g.FillRectangle(Brushes.Black,x+40,y+45,10,15);//cannon 2 Rectangle
						g.FillEllipse(Brushes.Black,x+40,y+55,10,10);//cannon 2 circle
						g.FillRectangle(Brushes.Black,x+60,y+90,10,15);//cannon 3 rectangle
						g.FillEllipse(Brushes.Black,x+60,y+85,10,10);//cannon 3 circle
						g.FillRectangle(Brushes.Black,x+40,y+90,10,15);//CANNON 4 
						g.FillEllipse(Brushes.Black,x+40,y+85,10,10);//CANNON 4 
					}
					if(this.sinkCount <=250)
					{
						g.FillEllipse(Brushes.White,x+75,y+40,20,70);//sail
						g.DrawEllipse(Pens.Black,x+75,y+40,20,70);//sail border
						g.FillEllipse(this.brush,x+75,y+35,10,80);//Mast
						g.DrawEllipse(Pens.Black,x+75,y+35,10,80);//Mast Border
					}
					if(this.sinkCount > 270)
					{
						this.alive = false;			
						this.sinkCount = 0;
					}
					//hit region
					//					g.FillEllipse(Brushes.Yellow, x, y + 50, 10, 10);
					//					g.FillRectangle(Brushes.Yellow, x, y+50, 120, 50);
					//					g.FillRectangle(Brushes.Yellow, x+120, y+58, 45, 33);
					#endregion
					#region Draw MuzzleFlash
					if(this.Weapon1.GetCooldown() <= 10)
					{	
						Point[] flash = {new Point((int)this.Weapon1.GetX(), (int)this.Weapon1.GetY()), new Point((int)this.Weapon1.GetX()-10, (int)this.Weapon1.GetY()), new Point((int)this.Weapon1.GetX()-12, (int)this.Weapon1.GetY()-7), new Point((int)this.Weapon1.GetX()-7, (int)this.Weapon1.GetY()-3), new Point((int)this.Weapon1.GetX()-5, (int)this.Weapon1.GetY()-10), new Point((int)this.Weapon1.GetX()-3, (int)this.Weapon1.GetY()-3), new Point((int)this.Weapon1.GetX()+2, (int)this.Weapon1.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon2.GetCooldown() <= 10)
					{	
						Point[] flash = {new Point((int)this.Weapon2.GetX(), (int)this.Weapon2.GetY()), new Point((int)this.Weapon2.GetX()-10, (int)this.Weapon2.GetY()), new Point((int)this.Weapon2.GetX()-12, (int)this.Weapon2.GetY()-7), new Point((int)this.Weapon2.GetX()-7, (int)this.Weapon2.GetY()-3), new Point((int)this.Weapon2.GetX()-5, (int)this.Weapon2.GetY()-10), new Point((int)this.Weapon2.GetX()-3, (int)this.Weapon2.GetY()-3), new Point((int)this.Weapon2.GetX()+2, (int)this.Weapon2.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon3.GetCooldown() <= 10)
					{	
						Point[] flash = {new Point((int)this.Weapon3.GetX(), (int)this.Weapon3.GetY()+10), new Point((int)this.Weapon3.GetX()-10, (int)this.Weapon3.GetY()+10), new Point((int)this.Weapon3.GetX()-12, (int)this.Weapon3.GetY()+17), new Point((int)this.Weapon3.GetX()-7, (int)this.Weapon3.GetY()+13), new Point((int)this.Weapon3.GetX()-5, (int)this.Weapon3.GetY()+20), new Point((int)this.Weapon3.GetX()-3, (int)this.Weapon3.GetY()+13), new Point((int)this.Weapon3.GetX()+2, (int)this.Weapon3.GetY()+17)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon4.GetCooldown() <= 10)
					{	
						Point[] flash = {new Point((int)this.Weapon4.GetX(), (int)this.Weapon4.GetY()+10), new Point((int)this.Weapon4.GetX()-10, (int)this.Weapon4.GetY()+10), new Point((int)this.Weapon4.GetX()-12, (int)this.Weapon4.GetY()+17), new Point((int)this.Weapon4.GetX()-7, (int)this.Weapon4.GetY()+13), new Point((int)this.Weapon4.GetX()-5, (int)this.Weapon4.GetY()+20), new Point((int)this.Weapon4.GetX()-3, (int)this.Weapon4.GetY()+13), new Point((int)this.Weapon4.GetX()+2, (int)this.Weapon4.GetY()+17)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}

					#endregion
					#region Smoke
					
					if(this.Smoke1.GetAlive())
					{
						Smoke1.DrawSmoke(e, this.x+23, this.y + 80);
					}
					
					if(this.Smoke2.GetAlive())
					{
						Smoke2.DrawSmoke(e, this.x+60, this.y + 65);
					}
					if(this.Smoke3.GetAlive())
					{
						Smoke3.DrawSmoke(e, this.x+33, this.y + 50);
					}
					if(this.Smoke4.GetAlive())
					{
						Smoke4.DrawSmoke(e, this.x+120, this.y + 80);
					}
					if(this.Smoke5.GetAlive())
					{
						Smoke5.DrawSmoke(e, this.x+100, this.y +70);
					}


					#endregion
					#region Rectangle
					this.hitZone1.X = (int)this.x;
					this.hitZone1.Y = (int)this.y+50;
					this.hitZone1.Width = 125;
					this.hitZone1.Height = 50;
					this.hitZone2.X = (int)this.x+125;
					this.hitZone2.Y = (int)this.y+55;
					this.hitZone2.Width = 40;
					this.hitZone2.Height = 35;
					//g.DrawRectangle(new Pen(Brushes.Green,3),this.hitZone1);
					//g.DrawRectangle(new Pen(Brushes.Green,3),this.hitZone2);
					#endregion
				}
			
				else if(this.slide == 4)
				{
					this.Weapon1.ChangeXY(this.x+57,this.y+107);
					this.Weapon2.ChangeXY(this.x+57,this.y+85);
					this.Weapon3.ChangeXY(this.x+7,this.y +107);
					this.Weapon4.ChangeXY(this.x+7,this.y + 85);
					#region draw ship @ slide == 4
					if(this.sinkCount <= 40)
					{
						Point[] head = {new Point((int)x, (int)y+160), new Point((int)x + 25,(int)y+210), new Point ( (int)x + 50, (int)y + 160)};	
						g.DrawEllipse(Pens.Black,x,y + 45,50,40);//stern border
						g.FillPolygon(this.brush,head);//STEM
						//g.DrawPolygon(Pens.Black,head);//STERN
						g.FillRectangle(this.brush,x,y+60,50,100);//Main Rectangle
						g.FillEllipse(this.brush,x,y + 45,50,40);//stern circle
						g.DrawLine(Pens.Black,x,y+60,x,y+160);//Main Rectangle Border line1
						g.DrawLine(Pens.Black,x+50,y+60,x+50,y+160);//Main Rectangle Border Line 2
					}
					if(this.sinkCount >=40)
					{
						SolidBrush sink = new SolidBrush(Color.FromArgb(0,120,255));
						g.FillEllipse(sink,this.x-10, this.y,75,200);
					}
					if(this.sinkCount <= 150)
					{
						g.FillRectangle(Brushes.BurlyWood,x + 5,y+60,40,95);//Deck
						g.DrawLine(Pens.Chocolate,x+10,y+60,x+10,y+155);//Deck lines
						g.DrawLine(Pens.Chocolate,x+15,y+60,x+15,y+155);
						g.DrawLine(Pens.Chocolate,x+20,y+60,x+20,y+155);
						g.DrawLine(Pens.Chocolate,x+25,y+60,x+25,y+155);
						g.DrawLine(Pens.Chocolate,x+30,y+60,x+30,y+155);
						g.DrawLine(Pens.Chocolate,x+35,y+60,x+35,y+155);
						g.DrawLine(Pens.Chocolate,x+40,y+60,x+40,y+155);
						g.DrawRectangle(Pens.Black,x + 5,y+60,40,95);//Deck Border
						g.FillRectangle(Brushes.Black,x-5,y+100,15,10);//cannon 1 rectangle
						g.FillEllipse(Brushes.Black,x+5,y+100,10,10);
						g.FillRectangle(Brushes.Black,x-5,y+80,15,10);//cannon 2 rectangle
						g.FillEllipse(Brushes.Black,x+5,y+80,10,10);
						g.FillRectangle(Brushes.Black,x+40,y+100,15,10);//cannon 3 rectangle
						g.FillEllipse(Brushes.Black,x+35,y+100,10,10);
						g.FillRectangle(Brushes.Black,x+40,y+80,15,10);//cannon 4 rectangle
						g.FillEllipse(Brushes.Black,x+35,y+80,10,10);
						Pen helm = new Pen(this.brush,2);
						g.DrawEllipse(helm,x+20,y+140,10,5);//brown box
					}
					if(this.sinkCount <= 250)
					{
						g.FillEllipse(Brushes.White,x-10,y+115,70,20);//Sail
						g.DrawEllipse(Pens.Black,x-10,y+115,70,20);//Sail Border
						g.FillEllipse(this.brush,x-15,y+115,80,10);//mast
						g.DrawEllipse(Pens.Black,x-15,y+115,80,10);//mast border
					}
					if(this.sinkCount > 270)
					{
						this.alive = false;			
						this.sinkCount = 0;
					}
					

					
					//hit region
					//					g.FillEllipse(Brushes.Yellow, x, y, 10, 10);
					//					g.FillRectangle(Brushes.Yellow, x, y+45, 50, 120);
					//					g.FillRectangle(Brushes.Yellow, x+8, y+165, 33, 45);
					#endregion
					#region Draw Muzzle Flash
					if(this.Weapon3.GetCooldown() <= 10)
					{
						Point[] flash = {new Point((int)Weapon3.GetX()-10, (int)this.Weapon3.GetY()-5), new Point((int)Weapon3.GetX()-10, (int)this.Weapon3.GetY()+5), new Point((int)Weapon3.GetX()-17, (int)this.Weapon3.GetY()+7), new Point((int)Weapon3.GetX()-12, (int)this.Weapon3.GetY()+2) ,new Point((int)Weapon3.GetX()-20, (int)this.Weapon3.GetY()), new Point((int)Weapon3.GetX()-12, (int)this.Weapon3.GetY()-2), new Point((int)this.Weapon3.GetX()-17, (int)this.Weapon3.GetY()-7)}; 
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon4.GetCooldown() <= 10)
					{
						Point[] flash = {new Point((int)Weapon4.GetX()-10, (int)this.Weapon4.GetY()-5), new Point((int)Weapon4.GetX()-10, (int)this.Weapon4.GetY()+5), new Point((int)Weapon4.GetX()-17, (int)this.Weapon4.GetY()+7), new Point((int)Weapon4.GetX()-12, (int)this.Weapon4.GetY()+2) ,new Point((int)Weapon4.GetX()-20, (int)this.Weapon4.GetY()), new Point((int)Weapon4.GetX()-12, (int)this.Weapon4.GetY()-2), new Point((int)this.Weapon4.GetX()-17, (int)this.Weapon4.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon1.GetCooldown() <= 10)
					{
						Point[] flash = {new Point((int)Weapon1.GetX(), (int)this.Weapon1.GetY()-5), new Point((int)Weapon1.GetX(), (int)this.Weapon1.GetY()+5), new Point((int)Weapon1.GetX()+7, (int)this.Weapon1.GetY()+7), new Point((int)Weapon1.GetX()+2, (int)this.Weapon1.GetY()+2) ,new Point((int)Weapon1.GetX()+10, (int)this.Weapon1.GetY()), new Point((int)Weapon1.GetX()+2, (int)this.Weapon1.GetY()-2), new Point((int)this.Weapon1.GetX()+7, (int)this.Weapon1.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon2.GetCooldown() <= 10)
					{
						Point[] flash = {new Point((int)Weapon2.GetX(), (int)this.Weapon2.GetY()-5), new Point((int)Weapon2.GetX(), (int)this.Weapon2.GetY()+5), new Point((int)Weapon2.GetX()+7, (int)this.Weapon2.GetY()+7), new Point((int)Weapon2.GetX()+2, (int)this.Weapon2.GetY()+2) ,new Point((int)Weapon2.GetX()+10, (int)this.Weapon2.GetY()), new Point((int)Weapon2.GetX()+2, (int)this.Weapon2.GetY()-2), new Point((int)this.Weapon2.GetX()+7, (int)this.Weapon2.GetY()-7)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					#endregion
					#region Smoke
					
					if(this.Smoke1.GetAlive())
					{
						Smoke1.DrawSmoke(e, this.x+23, this.y + 90);
					}
					
					if(this.Smoke2.GetAlive())
					{
						Smoke2.DrawSmoke(e, this.x+29, this.y + 120);
					}
					if(this.Smoke3.GetAlive())
					{
						Smoke3.DrawSmoke(e, this.x+13, this.y + 200);
					}
					if(this.Smoke4.GetAlive())
					{
						Smoke4.DrawSmoke(e, this.x+30, this.y + 60);
					}
					if(this.Smoke5.GetAlive())
					{
						Smoke5.DrawSmoke(e, this.x+15, this.y+160 );
					}


					#endregion
					#region Rectangle
					this.hitZone1.X = (int)this.x;
					this.hitZone1.Y = (int)this.y+45;
					this.hitZone1.Width = 50;
					this.hitZone1.Height = 125;
					this.hitZone2.X = (int)this.x+8;
					this.hitZone2.Y = (int)this.y+170;
					this.hitZone2.Width = 35;
					this.hitZone2.Height = 40;
					//g.DrawRectangle(new Pen(Brushes.Green,3),this.hitZone1);
					//g.DrawRectangle(new Pen(Brushes.Green,3),this.hitZone2);
					#endregion
				}
				
				if(this.slide == 6)
				{
					this.Weapon1.ChangeXY(this.x-20,this.y+95);
					this.Weapon2.ChangeXY(this.x,this.y+95);
					this.Weapon3.ChangeXY(this.x-20,this.y+50);
					this.Weapon4.ChangeXY(this.x,this.y+50);
					#region draw ship @ slide == 6
					Point[] head = {new Point((int)x - 79, (int)y +50), new Point((int)x - 129,(int)y +75), new Point ( (int)x-79, (int)y + 100)};	
					if(this.sinkCount <=40)
					{
						g.DrawEllipse(Pens.Black,x,y+50 ,40,50);
						g.FillPolygon(this.brush,head);
						g.FillRectangle(this.brush,x-80,y+50,100,50);//main rectangle
						g.FillEllipse(this.brush,x,y + 50,40,50);//stern
					}
					if(this.sinkCount >=40)
					{
						SolidBrush sink = new SolidBrush(Color.FromArgb(0,120,255));
						g.FillEllipse(sink,this.x-125, this.y+40,200,75);

					}
					if(this.sinkCount<=150)
					{
						g.FillRectangle(Brushes.BurlyWood,x-75,y+55,95,40);//deck
						g.DrawLine(Pens.Chocolate,x+20,y+60,x-75,y+60);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+65,x-75,y+65);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+70,x-75,y+70);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+75,x-75,y+75);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+80,x-75,y+80);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+85,x-75,y+85);//lines on the deck
						g.DrawLine(Pens.Chocolate,x+20,y+90,x-75,y+90);//lines on the deck
						g.DrawRectangle(Pens.Black,x-75,y+55,95,40);//border to deck
						g.FillRectangle(Brushes.Black,x-30,y+45,10,15);//Cannon 1 Rectangle
						g.FillEllipse(Brushes.Black,x-30,y+55,10,10);//cannon 1 cirlce
						g.FillRectangle(Brushes.Black,x-10,y+45,10,15);//cannon 2 Rectangle
						g.FillEllipse(Brushes.Black,x-10,y+55,10,10);//cannon 2 circle
						g.FillRectangle(Brushes.Black,x-30,y+90,10,15);//cannon 3 rectangle
						g.FillEllipse(Brushes.Black,x-30,y+85,10,10);//cannon 3 circle
						g.FillRectangle(Brushes.Black,x-10,y+90,10,15);//Cannon 4 Rectangle
						g.FillEllipse(Brushes.Black,x-10,y+85,10,10);//Cannon 4 Circle
						Pen helm = new Pen(this.brush,2);//pen for little circle
						g.DrawEllipse(helm,x-65,y+70,5,10);//little square it is actually a circle
					}
					if(this.sinkCount<=250)
					{
						g.FillEllipse(Brushes.White,x-55,y+40,20,70);//sail
						g.DrawEllipse(Pens.Black,x-55,y+40,20,70);//sail border
						g.FillEllipse(this.brush,x-45,y+35,10,80);//Mast
						g.DrawEllipse(Pens.Black,x-45,y+35,10,80);//Mast Border
					}
					if(this.sinkCount > 270)
					{
						this.alive = false;			
						this.sinkCount = 0;
					}
					

					//hit region
					//					g.FillEllipse(Brushes.Yellow, x, y, 10, 10);
					//					g.FillRectangle(Brushes.Yellow, x-80, y+50, 120, 50);
					//					g.FillRectangle(Brushes.Yellow, x-125, y+58, 45, 33);
					#endregion
					#region Draw MuzzleFlash
					if(this.Weapon3.GetCooldown() <= 10)
					{	
						Point[] flash = {new Point((int)this.Weapon3.GetX(), (int)this.Weapon3.GetY()-5), new Point((int)this.Weapon3.GetX()-10, (int)this.Weapon3.GetY()-5), new Point((int)this.Weapon3.GetX()-12, (int)this.Weapon3.GetY()-12), new Point((int)this.Weapon3.GetX()-7, (int)this.Weapon3.GetY()-8), new Point((int)this.Weapon3.GetX()-5, (int)this.Weapon3.GetY()-15), new Point((int)this.Weapon3.GetX()-3, (int)this.Weapon3.GetY()-8), new Point((int)this.Weapon3.GetX()+2, (int)this.Weapon3.GetY()-12)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon4.GetCooldown() <= 10)
					{	
						Point[] flash = {new Point((int)this.Weapon4.GetX(), (int)this.Weapon4.GetY()-5), new Point((int)this.Weapon4.GetX()-10, (int)this.Weapon4.GetY()-5), new Point((int)this.Weapon4.GetX()-12, (int)this.Weapon4.GetY()-12), new Point((int)this.Weapon4.GetX()-7, (int)this.Weapon4.GetY()-8), new Point((int)this.Weapon4.GetX()-5, (int)this.Weapon4.GetY()-15), new Point((int)this.Weapon4.GetX()-3, (int)this.Weapon4.GetY()-8), new Point((int)this.Weapon4.GetX()+2, (int)this.Weapon4.GetY()-12)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon1.GetCooldown() <= 10)
					{	
						Point[] flash = {new Point((int)this.Weapon1.GetX(), (int)this.Weapon1.GetY()+10), new Point((int)this.Weapon1.GetX()-10, (int)this.Weapon1.GetY()+10), new Point((int)this.Weapon1.GetX()-12, (int)this.Weapon1.GetY()+17), new Point((int)this.Weapon1.GetX()-7, (int)this.Weapon1.GetY()+13), new Point((int)this.Weapon1.GetX()-5, (int)this.Weapon1.GetY()+20), new Point((int)this.Weapon1.GetX()-3, (int)this.Weapon1.GetY()+13), new Point((int)this.Weapon1.GetX()+2, (int)this.Weapon1.GetY()+17)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					if(this.Weapon2.GetCooldown() <= 10)
					{	
						Point[] flash = {new Point((int)this.Weapon2.GetX(), (int)this.Weapon2.GetY()+10), new Point((int)this.Weapon2.GetX()-10, (int)this.Weapon2.GetY()+10), new Point((int)this.Weapon2.GetX()-12, (int)this.Weapon2.GetY()+17), new Point((int)this.Weapon2.GetX()-7, (int)this.Weapon2.GetY()+13), new Point((int)this.Weapon2.GetX()-5, (int)this.Weapon2.GetY()+20), new Point((int)this.Weapon2.GetX()-3, (int)this.Weapon2.GetY()+13), new Point((int)this.Weapon2.GetX()+2, (int)this.Weapon2.GetY()+17)};
						g.FillPolygon(Brushes.OrangeRed, flash);
					}
					#endregion
					#region Smoke
					
					if(this.Smoke1.GetAlive())
					{
						Smoke1.DrawSmoke(e, this.x-83, this.hitZone2.Y+9);
					}
					
					if(this.Smoke2.GetAlive())
					{
						Smoke2.DrawSmoke(e, this.x-20, this.hitZone2.Y+15);
					}
					if(this.Smoke3.GetAlive())
					{
						Smoke3.DrawSmoke(e, this.x-103, this.hitZone2.Y);
					}
					if(this.Smoke4.GetAlive())
					{
						Smoke4.DrawSmoke(e, this.hitZone2.X, this.y + 20);
					}
					if(this.Smoke5.GetAlive())
					{
						Smoke5.DrawSmoke(e, this.hitZone2.Left+30, this.y +20);
					}


					#endregion
					#region Rectangle
					this.hitZone1.X = (int)this.x-85;
					this.hitZone1.Y = (int)this.y+50;
					this.hitZone1.Width = 125;
					this.hitZone1.Height = 50;
					this.hitZone2.X = (int)this.x-125;
					this.hitZone2.Y = (int)this.y+55;
					this.hitZone2.Width = 40;
					this.hitZone2.Height = 35;
					//g.DrawRectangle(new Pen(Brushes.Green,3),this.hitZone1);
					//g.DrawRectangle(new Pen(Brushes.Green,3),this.hitZone2);
					#endregion
				}
					   
			}
			
			base.DrawShip ();
			if(this.hp <= 0)
				this.sinkCount++;
			if(this.sinkCount >10 && this.sinkCount <12)
			{
				//Microsoft.DirectX.AudioVideoPlayback.Audio.FromFile("bubbles.wav",true);
			}


		}
		
	
		#region fire methods
		
		public void FireSingle()
		{
			if(this.alive)
			{
				if(!this.Weapon1.ball.CheckAlive())
				{
					this.Weapon1.ball.FireFrigate(this, this.Weapon1);
				}
				else if(!this.Weapon2.ball.CheckAlive())
				{
					this.Weapon2.ball.FireFrigate(this, this.Weapon2);
				}
				else if(!this.Weapon3.ball.CheckAlive())
				{
					this.Weapon3.ball.FireFrigate(this, this.Weapon3);
				}
				else if(!this.Weapon4.ball.CheckAlive())
				{
					this.Weapon4.ball.FireFrigate(this, this.Weapon4);
				}
			}
		}

		public void FirePort()
		{
			if(this.alive)
			{
				if(!this.Weapon1.ball.CheckAlive() && this.Weapon1.GetCooldown() == 100)
				{
					this.Weapon1.ball.FireFrigate(this, this.Weapon1);
				}
				else if(!this.Weapon2.ball.CheckAlive() && this.Weapon1.GetCooldown() != 100)
				{
					this.Weapon2.ball.FireFrigate(this, this.Weapon2);
				}
			}
		}

		public void FireStarboard()
		{
			if(this.alive)
			{
				if(!this.Weapon3.ball.CheckAlive() && this.Weapon3.GetCooldown() == 100)
				{
					this.Weapon3.ball.FireFrigate(this, this.Weapon3);
				}
				else if(!this.Weapon4.ball.CheckAlive() && this.Weapon3.GetCooldown() != 100)
				{
					this.Weapon4.ball.FireFrigate(this, this.Weapon4);
				}
			}
		}

		public void FireAll()
		{
			
			if(this.alive)
			{
				try
				{
					if(!this.Weapon1.ball.CheckAlive())
					{
						this.Weapon1.ball.FireFrigate(this, this.Weapon1);
					}
			
					if(!this.Weapon2.ball.CheckAlive())
					{
						this.Weapon2.ball.FireFrigate(this, this.Weapon2);
					}
					if(!this.Weapon3.ball.CheckAlive())
					{
						this.Weapon3.ball.FireFrigate(this, this.Weapon3);
					}
					if(!this.Weapon4.ball.CheckAlive())
					{
						this.Weapon4.ball.FireFrigate(this, this.Weapon4);
					}
				}

				catch
				{
					MessageBox.Show("No", "Hello");
				
				}
			}
		}

		#endregion
		
		public void AddCooldown()
		{
			this.Weapon1.AddCooldown();
			this.Weapon2.AddCooldown();
			this.Weapon3.AddCooldown();
			this.Weapon4.AddCooldown();
		}


		public void CollideBall(Frigate enemy)
		{
			if(this.alive)
			{
				if(enemy.Weapon1.ball.CheckAlive())
				{
					#region slide 0
					if(this.slide == 0)
					{
						if(enemy.Weapon1.ball.GetX() + 5 >= this.x && enemy.Weapon1.ball.GetX() + 5 <= this.x + 50)
						{
							if(enemy.Weapon1.ball.GetY() + 5 >= this.y - 5 && enemy.Weapon1.ball.GetY() <= this.y + 105)
							{
								enemy.Weapon1.ball.ChangeSplash(11);
								enemy.Weapon1.ball.ChangeExpCount(0);
								enemy.Weapon1.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon1.ball.R1.Next(11);
								this.crew -= this.Weapon1.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
					
							}
						}
						if(enemy.Weapon1.ball.GetX() + 5 >= this.x + 8 && enemy.Weapon1.ball.GetX() + 5 <= this.x + 41)
						{
							if(enemy.Weapon1.ball.GetY() + 5 >= this.y - 55 && enemy.Weapon1.ball.GetY() <= this.y - 10)
							{
								enemy.Weapon1.ball.ChangeSplash(11);
								enemy.Weapon1.ball.ChangeExpCount(0);
								enemy.Weapon1.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon1.ball.R1.Next(11);
								this.crew -= this.Weapon1.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

					#region slide 2
					if(this.slide == 2)
					{
						//body
						if(enemy.Weapon1.ball.GetX() + 5 >= this.x && enemy.Weapon1.ball.GetX() + 5 <= this.x + 120)
						{
							if(enemy.Weapon1.ball.GetY() + 5 >= this.y + 50 && enemy.Weapon1.ball.GetY() <= this.y + 100)
							{
								enemy.Weapon1.ball.ChangeSplash(11);
								enemy.Weapon1.ball.ChangeExpCount(0);
								enemy.Weapon1.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon1.ball.R1.Next(11);
								this.crew -= this.Weapon1.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						//bow
						if(enemy.Weapon1.ball.GetX() + 5 >= this.x + 120 && enemy.Weapon1.ball.GetX() + 5 <= this.x + 165)
						{
							if(enemy.Weapon1.ball.GetY() + 5 >= this.y + 58  && enemy.Weapon1.ball.GetY() <= this.y + 91)
							{
								enemy.Weapon1.ball.ChangeSplash(11);
								enemy.Weapon1.ball.ChangeExpCount(0);
								enemy.Weapon1.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon1.ball.R1.Next(11);
								this.crew -= this.Weapon1.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
						#endregion

						#region Slide 4
					else if (this.slide == 4)
					{
						if(enemy.Weapon1.ball.GetX() + 5 >= this.x && enemy.Weapon1.ball.GetX() + 5 <= this.x + 50)
						{
							if(enemy.Weapon1.ball.GetY() + 5 >= this.y + 45 && enemy.Weapon1.ball.GetY() <= this.y + 165)
							{
								enemy.Weapon1.ball.ChangeSplash(11);
								enemy.Weapon1.ball.ChangeExpCount(0);
								enemy.Weapon1.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon1.ball.R1.Next(11);
								this.crew -= this.Weapon1.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon1.ball.GetX() + 5 >= this.x + 8 && enemy.Weapon1.ball.GetX() + 5 <= this.x + 41)
						{
							if(enemy.Weapon1.ball.GetY() + 5 >= this.y + 165 && enemy.Weapon1.ball.GetY() <= this.y + 210)
							{
								enemy.Weapon1.ball.ChangeSplash(11);
								enemy.Weapon1.ball.ChangeExpCount(0);
								enemy.Weapon1.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon1.ball.R1.Next(11);
								this.crew -= this.Weapon1.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

					#region slide 6
					if(this.slide == 6)
					{
						if(enemy.Weapon1.ball.GetX() + 5 >= this.x - 80 && enemy.Weapon1.ball.GetX() + 5 <= this.x + 40)
						{
							if(enemy.Weapon1.ball.GetY() + 5 >= this.y + 50 && enemy.Weapon1.ball.GetY() <= this.y + 100)
							{
								enemy.Weapon1.ball.ChangeSplash(11);
								enemy.Weapon1.ball.ChangeExpCount(0);
								enemy.Weapon1.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon1.ball.R1.Next(11);
								this.crew -= this.Weapon1.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon1.ball.GetX() + 5 >= this.x - 165 && enemy.Weapon1.ball.GetX() + 5 <= this.x - 80)
						{
							if(enemy.Weapon1.ball.GetY() + 5 >= this.y + 58  && enemy.Weapon1.ball.GetY() <= this.y + 91)
							{
								enemy.Weapon1.ball.ChangeSplash(11);
								enemy.Weapon1.ball.ChangeExpCount(0);
								enemy.Weapon1.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon1.ball.R1.Next(11);
								this.crew -= this.Weapon1.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

				}
				if(enemy.Weapon2.ball.CheckAlive())
				{
					#region slide 0
					if(this.slide == 0)
					{
						if(enemy.Weapon2.ball.GetX() + 5 >= this.x && enemy.Weapon2.ball.GetX() + 5 <= this.x + 50)
						{
							if(enemy.Weapon2.ball.GetY() + 5 >= this.y - 5 && enemy.Weapon2.ball.GetY() <= this.y + 105)
							{
								enemy.Weapon2.ball.ChangeSplash(11);
								enemy.Weapon2.ball.ChangeExpCount(0);
								enemy.Weapon2.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon2.ball.R1.Next(11);
								this.crew -= this.Weapon2.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon2.ball.GetX() + 5 >= this.x + 8 && enemy.Weapon2.ball.GetX() + 5 <= this.x + 41)
						{
							if(enemy.Weapon2.ball.GetY() + 5 >= this.y - 55 && enemy.Weapon2.ball.GetY() <= this.y - 10)
							{
								enemy.Weapon2.ball.ChangeSplash(11);
								enemy.Weapon2.ball.ChangeExpCount(0);
								enemy.Weapon2.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon2.ball.R1.Next(11);
								this.crew -= this.Weapon2.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

					#region slide 2
					if(this.slide == 2)
					{
						if(enemy.Weapon2.ball.GetX() + 5 >= this.x && enemy.Weapon2.ball.GetX() + 5 <= this.x + 120)
						{
							if(enemy.Weapon2.ball.GetY() + 5 >= this.y + 50 && enemy.Weapon2.ball.GetY() <= this.y + 100)
							{
								enemy.Weapon2.ball.ChangeSplash(11);
								enemy.Weapon2.ball.ChangeExpCount(0);
								enemy.Weapon2.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon2.ball.R1.Next(11);
								this.crew -= this.Weapon2.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon2.ball.GetX() + 5 >= this.x + 120 && enemy.Weapon2.ball.GetX() + 5 <= this.x + 165)
						{
							if(enemy.Weapon2.ball.GetY() + 5 >= this.y + 58  && enemy.Weapon2.ball.GetY() <= this.y + 91)
							{
								enemy.Weapon2.ball.ChangeSplash(11);
								enemy.Weapon2.ball.ChangeExpCount(0);
								enemy.Weapon2.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon2.ball.R1.Next(11);
								this.crew -= this.Weapon2.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
						#endregion

						#region Slide 4
					else if (this.slide == 4)
					{
						if(enemy.Weapon2.ball.GetX() + 5 >= this.x && enemy.Weapon2.ball.GetX() + 5 <= this.x + 50)
						{
							if(enemy.Weapon2.ball.GetY() + 5 >= this.y + 45 && enemy.Weapon2.ball.GetY() <= this.y + 165)
							{
								enemy.Weapon2.ball.ChangeSplash(11);
								enemy.Weapon2.ball.ChangeExpCount(0);
								enemy.Weapon2.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon2.ball.R1.Next(11);
								this.crew -= this.Weapon2.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon2.ball.GetX() + 5 >= this.x + 8 && enemy.Weapon2.ball.GetX() + 5 <= this.x + 41)
						{
							if(enemy.Weapon2.ball.GetY() + 5 >= this.y + 165 && enemy.Weapon2.ball.GetY() <= this.y + 210)
							{
								enemy.Weapon2.ball.ChangeSplash(11);
								enemy.Weapon2.ball.ChangeExpCount(0);
								enemy.Weapon2.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon2.ball.R1.Next(11);
								this.crew -= this.Weapon2.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

					#region slide 6
					if(this.slide == 6)
					{
						if(enemy.Weapon2.ball.GetX() + 5 >= this.x - 80 && enemy.Weapon2.ball.GetX() + 5 <= this.x + 40)
						{
							if(enemy.Weapon2.ball.GetY() + 5 >= this.y + 50 && enemy.Weapon2.ball.GetY() <= this.y + 100)
							{
								enemy.Weapon2.ball.ChangeSplash(11);
								enemy.Weapon2.ball.ChangeExpCount(0);
								enemy.Weapon2.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon2.ball.R1.Next(11);
								this.crew -= this.Weapon2.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon2.ball.GetX() + 5 >= this.x - 165 && enemy.Weapon2.ball.GetX() + 5 <= this.x - 80)
						{
							if(enemy.Weapon2.ball.GetY() + 5 >= this.y + 58  && enemy.Weapon2.ball.GetY() <= this.y + 91)
							{
								enemy.Weapon2.ball.ChangeSplash(11);
								enemy.Weapon2.ball.ChangeExpCount(0);
								enemy.Weapon2.ball.ChangeAlive(false);
								this.crew -= this.Weapon2.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

				}

				if(enemy.Weapon3.ball.CheckAlive())
				{
					#region slide 0
					if(this.slide == 0)
					{
						if(enemy.Weapon3.ball.GetX() + 5 >= this.x && enemy.Weapon3.ball.GetX() + 5 <= this.x + 50)
						{
							if(enemy.Weapon3.ball.GetY() + 5 >= this.y - 5 && enemy.Weapon3.ball.GetY() <= this.y + 105)
							{
								enemy.Weapon3.ball.ChangeSplash(11);
								enemy.Weapon3.ball.ChangeExpCount(0);
								enemy.Weapon3.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon3.ball.R1.Next(11);
								this.crew -= this.Weapon3.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon3.ball.GetX() + 5 >= this.x + 8 && enemy.Weapon3.ball.GetX() + 5 <= this.x + 41)
						{
							if(enemy.Weapon3.ball.GetY() + 5 >= this.y - 55 && enemy.Weapon3.ball.GetY() <= this.y - 10)
							{
								enemy.Weapon3.ball.ChangeSplash(11);
								enemy.Weapon3.ball.ChangeExpCount(0);
								enemy.Weapon3.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon3.ball.R1.Next(11);
								this.crew -= this.Weapon3.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

					#region slide 2
					if(this.slide == 2)
					{
						if(enemy.Weapon3.ball.GetX() + 5 >= this.x && enemy.Weapon3.ball.GetX() + 5 <= this.x + 120)
						{
							if(enemy.Weapon3.ball.GetY() + 5 >= this.y + 50 && enemy.Weapon3.ball.GetY() <= this.y + 100)
							{
								enemy.Weapon3.ball.ChangeSplash(11);
								enemy.Weapon3.ball.ChangeExpCount(0);
								enemy.Weapon3.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon3.ball.R1.Next(11);
								this.crew -= this.Weapon3.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon3.ball.GetX() + 5 >= this.x + 120 && enemy.Weapon3.ball.GetX() + 5 <= this.x + 165)
						{
							if(enemy.Weapon3.ball.GetY() + 5 >= this.y + 58  && enemy.Weapon3.ball.GetY() <= this.y + 91)
							{
								enemy.Weapon3.ball.ChangeSplash(11);
								enemy.Weapon3.ball.ChangeExpCount(0);
								enemy.Weapon3.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon3.ball.R1.Next(11);
								this.crew -= this.Weapon3.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
						#endregion

						#region Slide 4
					else if (this.slide == 4)
					{
						if(enemy.Weapon3.ball.GetX() + 5 >= this.x && enemy.Weapon3.ball.GetX() + 5 <= this.x + 50)
						{
							if(enemy.Weapon3.ball.GetY() + 5 >= this.y + 45 && enemy.Weapon3.ball.GetY() <= this.y + 165)
							{
								enemy.Weapon3.ball.ChangeSplash(11);
								enemy.Weapon3.ball.ChangeExpCount(0);
								enemy.Weapon3.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon3.ball.R1.Next(11);
								this.crew -= this.Weapon3.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon3.ball.GetX() + 5 >= this.x + 8 && enemy.Weapon3.ball.GetX() + 5 <= this.x + 41)
						{
							if(enemy.Weapon3.ball.GetY() + 5 >= this.y + 165 && enemy.Weapon3.ball.GetY() <= this.y + 210)
							{
								enemy.Weapon3.ball.ChangeSplash(11);
								enemy.Weapon3.ball.ChangeExpCount(0);
								enemy.Weapon3.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon3.ball.R1.Next(11);
								this.crew -= this.Weapon3.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

					#region slide 6
					if(this.slide == 6)
					{
						if(enemy.Weapon3.ball.GetX() + 5 >= this.x - 80 && enemy.Weapon3.ball.GetX() + 5 <= this.x + 40)
						{
							if(enemy.Weapon3.ball.GetY() + 5 >= this.y + 50 && enemy.Weapon3.ball.GetY() <= this.y + 100)
							{
								enemy.Weapon3.ball.ChangeSplash(11);
								enemy.Weapon3.ball.ChangeExpCount(0);
								enemy.Weapon3.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon3.ball.R1.Next(11);
								this.crew -= this.Weapon3.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon3.ball.GetX() + 5 >= this.x - 165 && enemy.Weapon3.ball.GetX() + 5 <= this.x - 80)
						{
							if(enemy.Weapon3.ball.GetY() + 5 >= this.y + 58  && enemy.Weapon3.ball.GetY() <= this.y + 91)
							{
								enemy.Weapon3.ball.ChangeSplash(11);
								enemy.Weapon3.ball.ChangeExpCount(0);
								enemy.Weapon3.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon3.ball.R1.Next(11);
								this.crew -= this.Weapon3.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

				}

				if(enemy.Weapon4.ball.CheckAlive())
				{
					#region slide 0
					if(this.slide == 0)
					{
						if(enemy.Weapon4.ball.GetX() + 5 >= this.x && enemy.Weapon4.ball.GetX() + 5 <= this.x + 50)
						{
							if(enemy.Weapon4.ball.GetY() + 5 >= this.y - 5 && enemy.Weapon4.ball.GetY() <= this.y + 105)
							{
								enemy.Weapon4.ball.ChangeSplash(11);
								enemy.Weapon4.ball.ChangeExpCount(0);
								enemy.Weapon4.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon4.ball.R1.Next(11);
								this.crew -= this.Weapon4.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon4.ball.GetX() + 5 >= this.x + 8 && enemy.Weapon4.ball.GetX() + 5 <= this.x + 41)
						{
							if(enemy.Weapon4.ball.GetY() + 5 >= this.y - 55 && enemy.Weapon4.ball.GetY() <= this.y - 10)
							{
								enemy.Weapon4.ball.ChangeSplash(11);
								enemy.Weapon4.ball.ChangeExpCount(0);
								enemy.Weapon4.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon4.ball.R1.Next(11);
								this.crew -= this.Weapon4.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

					#region slide 2
					if(this.slide == 2)
					{
						if(enemy.Weapon4.ball.GetX() + 5 >= this.x && enemy.Weapon4.ball.GetX() + 5 <= this.x + 120)
						{
							if(enemy.Weapon4.ball.GetY() + 5 >= this.y + 50 && enemy.Weapon4.ball.GetY() <= this.y + 100)
							{
								enemy.Weapon4.ball.ChangeSplash(11);
								enemy.Weapon4.ball.ChangeExpCount(0);
								enemy.Weapon4.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon4.ball.R1.Next(11);
								this.crew -= this.Weapon4.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon4.ball.GetX() + 5 >= this.x + 120 && enemy.Weapon4.ball.GetX() + 5 <= this.x + 165)
						{
							if(enemy.Weapon4.ball.GetY() + 5 >= this.y + 58  && enemy.Weapon4.ball.GetY() <= this.y + 91)
							{
								enemy.Weapon4.ball.ChangeSplash(11);
								enemy.Weapon4.ball.ChangeExpCount(0);
								enemy.Weapon4.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon4.ball.R1.Next(11);
								this.crew -= this.Weapon4.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
						#endregion

						#region Slide 4
					else if (this.slide == 4)
					{
						if(enemy.Weapon4.ball.GetX() + 5 >= this.x && enemy.Weapon4.ball.GetX() + 5 <= this.x + 50)
						{
							if(enemy.Weapon4.ball.GetY() + 5 >= this.y + 45 && enemy.Weapon4.ball.GetY() <= this.y + 165)
							{
								enemy.Weapon4.ball.ChangeSplash(11);
								enemy.Weapon4.ball.ChangeExpCount(0);
								enemy.Weapon4.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon4.ball.R1.Next(11);
								this.crew -= this.Weapon4.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon4.ball.GetX() + 5 >= this.x + 8 && enemy.Weapon4.ball.GetX() + 5 <= this.x + 41)
						{
							if(enemy.Weapon4.ball.GetY() + 5 >= this.y + 165 && enemy.Weapon4.ball.GetY() <= this.y + 210)
							{
								enemy.Weapon4.ball.ChangeSplash(11);
								enemy.Weapon4.ball.ChangeExpCount(0);
								enemy.Weapon4.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon4.ball.R1.Next(11);
								this.crew -= this.Weapon4.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

					#region slide 6
					if(this.slide == 6)
					{
						if(enemy.Weapon4.ball.GetX() + 5 >= this.x - 80 && enemy.Weapon4.ball.GetX() + 5 <= this.x + 40)
						{
							if(enemy.Weapon4.ball.GetY() + 5 >= this.y + 50 && enemy.Weapon4.ball.GetY() <= this.y + 100)
							{
								enemy.Weapon4.ball.ChangeSplash(11);
								enemy.Weapon4.ball.ChangeExpCount(0);
								enemy.Weapon4.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon4.ball.R1.Next(11);
								this.crew -= this.Weapon4.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
						if(enemy.Weapon4.ball.GetX() + 5 >= this.x - 165 && enemy.Weapon4.ball.GetX() + 5 <= this.x - 80)
						{
							if(enemy.Weapon4.ball.GetY() + 5 >= this.y + 58  && enemy.Weapon4.ball.GetY() <= this.y + 91)
							{
								enemy.Weapon4.ball.ChangeSplash(11);
								enemy.Weapon4.ball.ChangeExpCount(0);
								enemy.Weapon4.ball.ChangeAlive(false);
								this.hp -= 40 + this.Weapon4.ball.R1.Next(11);
								this.crew -= this.Weapon4.ball.R1.Next(11);
								//this.boom.SetCurrentPosition(0);
								//this.boom.Play(0, BufferPlayFlags.Default);
							}
						}
					}
					#endregion

				}
			}
		}
		public void SetX(int x)
		{
			this.x = x;
		}

		public void SetY(int y)
		{
			this.y = y;
		}

		public void AddX(int x)
		{
			this.x += x;
		}
		public void AddY(int y)
		{
			this.y += y;
		}
	
		public float GetX()
		{
			return this.x;
		}
		public float Gety()
		{
			return this.y;
		}

		public void SetAlive(bool alive)
		{
			this.alive = alive;
		}

		public void Collision(Frigate followedShip)
		{
			
			#region MatchY
			if(followedShip.y > this.y + 100)
			{
				if(this.slide == 0 || this.slide == 2)
				{
					this.slide += 2;
				}
				else if (this.slide == 6)
				{
					this.slide -= 2;
				}
				else if(this.slide == 4)
				{
					this.AddYMomentum();
				}
			}

			else if(followedShip.y < this.y)
			{
				if(this.slide == 4 || this.slide == 2)
				{
					this.slide -= 2;
				}
				else if (this.slide == 6)
				{
					this.slide = 0;
				}
				else if(this.slide == 0)
				{
					this.SubtractYMomentum();
				}
			}

				#endregion

				#region MatchX
			else if(followedShip.x - 100 > this.x)
			{
				if(this.slide == 4 || this.slide == 6)
				{
					this.slide -= 2;
				}
				else if (this.slide == 0)
				{
					this.slide += 2;
				}
				else if(this.slide == 2)
				{
					this.AddXMomentum();
				}
			}

			else if(followedShip.x  < this.x)
			{
				if(this.slide == 4 || this.slide == 2)
				{
					this.slide += 2;
				}
				else if (this.slide == 0)
				{
					this.slide += 2;
				}
				else if(this.slide == 6)
				{
					this.SubtractXMomentum();
				}
			}
			#endregion

			this.FireAll();

		}
		
		public void DumbAI(Random r)
		{
			int count = r.Next(1000);
			if(count <995)
			{
				if(this.GetSlide() == 0)
					this.SubtractYMomentum();
				if(this.GetSlide() == 4)
					this.AddYMomentum();
				if(this.GetSlide() == 2)
					this.AddXMomentum();
				if(this.GetSlide() == 6)
					this.SubtractXMomentum();	

			}
			else 
			{
				this.AddSlide(2);
				if(this.slide > 6)
					this.slide = 0;
			}
			this.FireSingle();
		}
		public void Spawn(Random r)
		{
			this.alive = true;
			this.x =  700;
			this.y = r.Next(800);
			this.sinkCount = 0;
			this.AddHP(200);
			this.FrigateSmoke(0);
			//this.FrigateSmoke(0);
			this.Smoke1.KillSmoke();
			this.Smoke2.KillSmoke();
			this.Smoke3.KillSmoke();
			this.Smoke4.KillSmoke();
			this.Smoke5.KillSmoke();
			this.Smoke1.SetSmokeCount(0);
			this.Smoke2.SetSmokeCount(0);
			this.Smoke3.SetSmokeCount(0);
			this.Smoke4.SetSmokeCount(0);
			this.Smoke5.SetSmokeCount(0);

		}
	}


	public class Weapon
	{
		protected float x, y,cooldown,cooldownRate;
		protected bool alive;
		internal Ball ball;
		//protected SecondaryBuffernull;
		

		public Weapon (float x, float y, float cooldownRate)
		{
			this.x =x;
			this.y = y;
			this.cooldown = 100;
			this.cooldownRate = cooldownRate;
			//this.splash =null;
			ball = new Ball(0, 0, 0, 0);
		}
		
		
		public void ChangeXY(float x,float y)
		{
			this.x = x;
			this.y = y;
		}
		public float GetX()
		{
			return this.x;
		}
		public float GetY()
		{
			return this.y;
		}

		public void Fire(float xDirection,float yDirection)
		{
			
		}

		public void AddCooldown()
		{
			if(this.cooldown < 100)
			{
				this.cooldown += cooldownRate;

				if(this.cooldown > 100)
				{
					this.cooldown = 100;
				}
			}
		}
		public float GetCooldown()
		{
			return this.cooldown;
		}

		public void SetCooldown(float newNumber)
		{
			this.cooldown = newNumber;
		}


	}

	
	public abstract class Projectile
	{
		protected float x,y,xDirection,yDirection,range,speed,xEnd,yEnd;
		protected bool alive;
		protected int splashCount, expCount;  //expCount is Explosion Count

		public Random R1;
		//internal Device splashSoundDevice = new Device();


		
		public Projectile(float x, float y,float xDirection,float yDirection)
		{
			this.x = x;
			this.y = y;
			this.xDirection = xDirection;
			this.yDirection = yDirection;
			R1 = new Random();
			this.alive = false;
			//this.splash = splash;
		
			
		}

	}

	
	public class Ball:Projectile
	{
		
		public Ball(float x, float y, float xDirection, float yDirection): base(x,y, xDirection, yDirection)
		{
			this.speed = 7;
			this.range = 300;
			this.splashCount = 11;
			this.expCount = 11;
		}
		
		public void DrawBall(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if(this.alive == true)
			{
					
				if(this.xDirection < 0 && this.x > this.xEnd)
					g.FillEllipse(Brushes.Black,this.x,this.y,10,10);
				else if(this.xDirection > 0 && this.x < this.xEnd)
					g.FillEllipse(Brushes.Black,this.x,this.y,10,10);
				else if(this.yDirection > 0 && this.y < this.yEnd)
					g.FillEllipse(Brushes.Black,this.x,this.y,10,10);
				else if(this.yDirection<0 && this.y >this.yEnd)
					g.FillEllipse(Brushes.Black,this.x,this.y,10,10);
				else
				{
					this.alive = false;
					this.splashCount = 0;
				}
	
				if(this.xDirection < 0)
				{			
					this.x -= this.speed;
				}
				if(this.xDirection > 0)
				{
					this.x += this.speed;
				}
				if(this.yDirection > 0)
				{
					this.y += this.speed;
				}
				if(this.yDirection < 0)
				{
					this.y -= this.speed;
				}
				if(this.x == this.xEnd &&  this.y == this.yEnd)
				{	
					this.alive = false;
				}
			}
			if(this.alive == false && this.splashCount == 0)
			{
				//splash.Volume = -500;
				//splash.SetCurrentPosition(0);
				//splash.Play(0, BufferPlayFlags.Default);
			}

			
			if(this.alive == false && this.splashCount < 10)// && this.x == this.xEnd && this.y == this.yEnd)
			{
				g.FillEllipse(Brushes.LightBlue, this.xEnd, this.yEnd, this.splashCount*2, this.splashCount*2);
				this.splashCount++;
			}
			if(this.alive == false && this.expCount < 10)// && this.x == this.xEnd && this.y == this.yEnd)
			{
				g.FillEllipse(Brushes.Red, this.x, this.y, this.expCount*2, this.expCount*2);
				this.expCount++;
			}

		}

		public void FireFrigate(Frigate frigate,Weapon weapon)// float xDirection, float yDirection)
		{
			if(frigate.GetAlive() == true && frigate.GetSinkCount() == 0)
			{
				if(!this.alive && weapon.GetCooldown() == 100 && frigate.GetBallAmmo() > 0)// && this.splashCount == 11 && this.expCount == 11)
				{
				
					weapon.SetCooldown(0);
					//frigate.boom.Volume += 50;
					//frigate.shot.SetCurrentPosition(0);
					//frigate.shot.Play(0, BufferPlayFlags.Default);

					#region Set Direction
					if(frigate.GetSlide() == 0)
					{
						if(frigate.Weapon1 == weapon)
						{
							this.xDirection = -1;
							this.yDirection = 0;
						}
						else if(frigate.Weapon2 == weapon)
						{
							this.xDirection = -1;
							this.yDirection = 0;
						}
						else if(frigate.Weapon3 == weapon)
						{
							this.xDirection = 1;
							this.yDirection = 0;
						}
						else if(frigate.Weapon4 == weapon)
						{
							this.xDirection = 1;
							this.yDirection = 0;
						}
					}
					else if(frigate.GetSlide() == 2)
					{
						if(frigate.Weapon1 == weapon)
						{
							this.xDirection = 0;
							this.yDirection = -1;
						}
						else if(frigate.Weapon2 == weapon)
						{
							this.xDirection = 0;
							this.yDirection = -1;
						}
						else if(frigate.Weapon3 == weapon)
						{
							this.xDirection = 0;
							this.yDirection = 1;
						}
						else if(frigate.Weapon4 == weapon)
						{
							this.xDirection = 0;
							this.yDirection = 1;
						}
					}

					else if(frigate.GetSlide() == 4)
					{
						if(frigate.Weapon1 == weapon)
						{
							this.xDirection = 1;
							this.yDirection = 0;
						}
						else if(frigate.Weapon2 == weapon)
						{
							this.xDirection = 1;
							this.yDirection = 0;
						}
						else if(frigate.Weapon3 == weapon)
						{
							this.xDirection = -1;
							this.yDirection = 0;
						}
						else if(frigate.Weapon4 == weapon)
						{
							this.xDirection = -1;
							this.yDirection = 0;
						}
					}
					else if(frigate.GetSlide() == 6)
					{
						if(frigate.Weapon1 == weapon)
						{
							this.xDirection = 0;
							this.yDirection = 1;
						}
						else if(frigate.Weapon2 == weapon)
						{
							this.xDirection = 0;
							this.yDirection = 1;
						}
						else if(frigate.Weapon3 == weapon)
						{
							this.xDirection = 0;
							this.yDirection = -1;
						}
						else if(frigate.Weapon4 == weapon)
						{
							this.xDirection = 0;
							this.yDirection = -1;
						}
					
					}
					#endregion

					this.x = weapon.GetX()-13;
					this.y = weapon.GetY()-5;
					this.alive = true;
					if(xDirection <0)
					{
						this.xEnd = this.x - this.range;
					}
				
					else if(xDirection >0)
					{
						this.xEnd = this.x + this.range;
					}

					else if (xDirection == 0)
					{
						this.xEnd = this.x;
					}
					if(yDirection <0)
					{
						this.yEnd = this.y - this.range;
					}
					else if(yDirection >0)
					{
						this.yEnd = this.y + this.range;
					}
					else
					{
						this.yEnd = this.y;
					}
					this.splashCount = 0;
				}
			}
		}

		public bool CheckAlive()
		{
			return this.alive;
		}
		public float GetX()
		{
			return this.x;
		}
		public float GetY()
		{
			return this.y;
		}
		public void ChangeAlive(bool change)
		{
			this.alive = change;
		}
		public void ChangeSplash(int change)
		{
			this.splashCount = change;
		}
		public int GetExpCount()
		{
			return this.expCount;
		}
		public void ChangeExpCount(int newValue)
		{
			this.expCount = newValue;
		}
	}
																			 

	public class Seagull
	{
		private	float x,y;
		private int frame;//animation
		private int frameCount;

		public Seagull(int x,int y)
		{
			this.x = x;
			this.y = y;
			this.frame = 0;
			this.frameCount = 0;
		}
		public void DrawSeagull(PaintEventArgs e)
		{	
			Graphics g = e.Graphics;
			#region frame0
			if(this.frame == 0)
			{
				g.DrawArc(Pens.White,x-10,y-10,10,10,180,180);
				g.DrawArc(Pens.White,x,y-10,10,10,180,180);
				this.frameCount ++;
				this.x++;
				if(this.frameCount >= 30)
				{
					this.frame =1;
					//this.frameCount = 0;
				}
			}
				#endregion
				#region Frame1
			else if(this.frame ==1)
			{
				g.DrawLine(Pens.White,this.x-10,y-10,this.x,this.y);
				g.DrawLine(Pens.White,this.x,this.y,this.x+10,this.y-10);
				this.x++;
				this.frameCount ++;
				if(this.frameCount >= 60)
				{
					this.frame =0;
					this.frameCount = 0;
						
					//this.frameCount = 0;
				}
			}
			#endregion
			
		}
		public void SetXY(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

	
	}		
		

	public class Smoke
	{
		private float x,y,radius;
		private int smokeCount;
		private float speed;
		private bool alive;
		private bool ready;
		
		public Smoke(float x, float y, float radius)
		{
			this.x = x; 
			this.y = y;
			this.radius = radius;
			this.smokeCount = 0;
			this.speed = .3f;
			this.alive = false;
			this.ready = false;
		}
		public Smoke(float x, float y, float radius, float speed)
		{
			this.x = x; 
			this.y = y;
			this.radius = radius;
			this.smokeCount = 0;
			this.speed = .3f;
			this.alive = false;
			this.ready = false;
		}

		public void SetXY(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		public void SetAlive(bool alive)
		{
			this.alive = alive;
		}
		public void DrawSmoke(PaintEventArgs e,float startX, float startY)
		{
			Graphics g = e.Graphics;
			g.FillEllipse(Brushes.Black,this.x, this.y,this.radius *2, this.radius*2);
			if(this.radius <= 20)
			{
				this.radius += this.speed;
				smokeCount ++;
				this.x -= this.speed;
				this.y -= this.speed;
			}
			else if(this.smokeCount <=50)
			{
				this.smokeCount ++;
			}
			else 
			{
				this.smokeCount = 0;
				this.x = startX;
				this.y = startY;
				this.radius =5;
			}
		}
		public bool GetAlive()
		{
			return this.alive;
		}
		public float GetX()
		{
			return this.x;
		}

		public float GetY()
		{
			return this.y;
		}
		public float GetRadius()
		{
			return this.radius;
		}
		public float GetSmokeCount()
		{
			return this.smokeCount;
		}
		public void KillSmoke()
		{
			this.alive = false;
		}
		public void SetSmokeCount(int smoke)
		{
			this.smokeCount = smoke;
		}

	}


	class Land
	{
		private Rectangle r1;

		public Land (int x, int y)
		{	
			this.r1 = new Rectangle(x,y,100,100);
		}
		
		public void DrawLand(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.FillEllipse(Brushes.Green,r1.X,r1.Y,100,100);
			//g.FillRectangle( Brushes.Gold,this.r1);
		}

		public void FrigateCollideLand(Frigate frigate)
		{
			if(this.r1.IntersectsWith(frigate.hitZone1) || this.r1.IntersectsWith(frigate.hitZone2))
			{
				if(frigate.GetX() < this.r1.Left + 50)
					frigate.AddX(-20);
				if(frigate.GetX() > this.r1.Left + 50)
					frigate.AddX(+20);

			}

		}

	}
	

}






	


	

		





