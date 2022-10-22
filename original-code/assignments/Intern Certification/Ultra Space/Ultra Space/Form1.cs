using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;
using System.Text;

namespace Ultra_Space
{

	public class Form1 : System.Windows.Forms.Form
	{
		public static int score = 0;
		public static int level = 0;
		//these are all reset each level
		public static int kills = 0;
		public static int shots = 0;
		public static int hits = 0;
		public static int accuracy;
		//this is set for a breif moment to adjust end level stuff
		public static bool upkeep = false;

		
		public static int accuracyPoints;
		public static int hpPoints;
		public static int killPoints;
		public static Random r = new Random();

		public static bool levelComplete = false;
		int highScore;
		public static bool pause = true;			//if the baddies will come after you
		Form2 form2 = new Form2();
		bool first = false;
		PShip user = new PShip(10, 200);
		SShip baddie = new SShip(400, 200);
		Mongo boss1 = new Mongo(1000, 200);
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		bool right = false;
		bool left = false;
		bool up = false;
		bool down = false;
		int time = 0;
		BinaryReader reader;
		BinaryWriter writer;

		internal int width;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		internal int height;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		
		

		ArrayList activeShips = new ArrayList();			//an array list of ships on the screen
		public static PowerUp[] powerUps = new PowerUp[1];
		public static Star[] stars = new Star[50];
		Cargo cargo = new Cargo(400, 400);

		//the powerUps
		public static Health health = new Health(0,0);


		public Form1()
		{
			form2.Show();
			//fill in all the ships that need to come on the screen
			//activeShips.Add(boss1);
			//activeShips.Add(user);
			//user.Spawn(50, 50);

			for(int i=0; i<stars.Length; i++)
			{
				stars[i] = new Star();
			}
			foreach(Star star in stars)
			{
				star.FirstSpawn();
			}
			
			
			powerUps[0] = health;
			activeShips.Add(cargo);
			
			for(int i=0; i<15; i++)
			{
				activeShips.Add(new SShip());
			}
			foreach(Ship ship in activeShips)
			{
				ship.Reset();
			}
			
			
			//creates the highscore file if it does not exist
			try
			{
				reader = new BinaryReader(new FileStream("score.uls", FileMode.Open));
			}
			catch
			{
				//creates the file and writes zero to it
				writer = new BinaryWriter(new FileStream("score.uls", FileMode.Create));
				writer.Write(0);
				writer.Close();
				reader = new BinaryReader(new FileStream("score.uls", FileMode.Open));
			}
			finally
			{
				highScore = reader.ReadInt32();
				reader.Close();
			}
			

			Thread waveBad = new Thread(new ThreadStart(SpawnWave));


			InitializeComponent();
			width = this.width;
			height = this.height;

			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			form2.Close();
			Cursor.Show();
		}

		public void SpawnWave()
		{
			int i = 0;
			while(i < 5)
			{
				activeShips.Add(new SShip(1000, 200));
				Thread.Sleep(100);
				i++;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			
			Graphics g = e.Graphics;
			
			foreach(Star star in stars)
			{
				star.Draw(e);
			}
			
			g.DrawImage(Image.FromFile("biometalHealther.gif"), 800, 15);
			g.FillRectangle(Brushes.Blue, 825, 27, user.GetHp()*8, 5);
			g.FillRectangle(Brushes.White,825, 29, user.GetHp()*8, 1);

			user.DrawShip(e);


			foreach(Ship ship in activeShips)
			{
				ship.DrawShip(e);
			}
			
			foreach(Ship ship in activeShips)
			{
				if(ship != user)
				{
					user.CheckCollision(ship);
				}
			}
			
			if(!cargo.GetAlive())
			{
				cargo.Spawn();
			}
			foreach(PowerUp powerUp in powerUps)
			{
				powerUp.Draw(e);
			}
			
			foreach(PowerUp powerUp in powerUps)
			{
				user.GetPowerUp(powerUp);
			}

			
			#region Update High Score
			if(score > highScore)
			{
				highScore = score;
				writer = new BinaryWriter(new FileStream("score.uls", FileMode.Truncate));
				writer.Write(highScore);
				writer.Close();
			}
			#endregion
			
			g.DrawString("Score: "+score.ToString(), new Font("Impact", 24), Brushes.White, 100, 10);
			g.DrawString("High Score: "+highScore.ToString(), new Font("Impact", 24), Brushes.White, 400, 10);
			g.DrawString("Health", new Font("Impact", 24), Brushes.White, 700, 10);

			#region Inbetween Level Stuff
			if(upkeep == true)
			{
				level++;
				this.SetEndLevelReport();
				upkeep = false;
				time = 0;
			}
			if(levelComplete)
			{
				g.DrawString("Level Complete!", new Font("Impact", 48), Brushes.Yellow, 250, 150);
				g.DrawString("Kills:  "+kills.ToString(), new Font("Impact", 24), Brushes.Yellow, 400, 250);
				g.DrawString("Shots Fired:  "+shots.ToString(), new Font("Impact", 24), Brushes.Yellow, 400, 300);
				g.DrawString("Hits:  "+hits.ToString(), new Font("Impact", 24), Brushes.Yellow, 400, 350);
				g.DrawString("Bonus", new Font("Impact", 36), Brushes.Yellow, 350, 400);
				g.DrawString("Accuracy:  "+accuracyPoints.ToString(), new Font("Impact", 24), Brushes.Yellow, 400, 500);
				g.DrawString("Kills:  "+killPoints.ToString(), new Font("Impact", 24), Brushes.Yellow, 400, 550);
				g.DrawString("Remaining Life:  "+hpPoints.ToString(), new Font("Impact", 24), Brushes.Yellow, 400, 600);

				if(killPoints > 0)
				{
					score += 3;
					killPoints -=3;
				}
				else
				{
					killPoints = 0;
				}
				if(hpPoints > 0)
				{
					hpPoints -=3;
					score += 3;
				}
				else
				{
					hpPoints = 0;
				}
				if(accuracyPoints > 0)
				{
					accuracyPoints-=5;
					score+=5;
				}
				else
				{
					accuracyPoints = 0;
				}
			}
			#endregion

			if(level==1 && time == 500)
			{
				pause = false;
				if(level == 1)
				{
					activeShips.RemoveRange(0,activeShips.Count);
					for(int i=0; i<10; i++)
					{
						activeShips.Add(new Fish());
					}
					for(int i=0; i < 5; i++)
					{
						activeShips.Add(new SShip());
					}
					
				
				}
			}
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

		protected override void OnKeyDown(KeyEventArgs e)
		{
			#region Controls the direction of the ship
			if(e.KeyCode == Keys.Right && right == false)
			{
				if(user.GetRight() == false)
				{
					user.FlipImages();
				}
				right = true;
				
			}
			if(e.KeyCode == Keys.Left && left == false)
			{
				if(user.GetRight())
				{
					//user.FlipImages();
				}
				left = true;
			}
			if(e.KeyCode == Keys.Up && up == false)
			{
				up = true;
			}
			if(e.KeyCode == Keys.Down && down == false)
			{
				down = true;
			}
			#endregion

			if(e.KeyCode == Keys.Space)
			{
				//user.Fire();
			}
			base.OnKeyDown (e);
		}
		
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Right && right == true)
			{
				right = false;
			}
			if(e.KeyCode == Keys.Left && left == true)
			{
				left = false;
			}
			if(e.KeyCode == Keys.Up && up == true)
			{
				up = false;
			}
			if(e.KeyCode == Keys.Down && down == true)
			{
				down = false;
			}
			if(e.KeyCode == Keys.Space)
			{
				user.Fire();
			}
			base.OnKeyUp (e);
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem3,
																					  this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.menuItem2.Text = "New Game";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem6});
			this.menuItem3.Text = "Help";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "How to play";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "Controls";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "About";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Ultra Space";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

	
		static void Main() 
		{
			Form1 form1 = new Form1();
			Application.Run(form1);
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(right)
			{
				user.AddXMomentum(1);
			}
			else if(left)
			{
				user.AddXMomentum(-1);
			}

			if(up)
			{
				user.AddYMomentum(-1);
			}
			else if(down)
			{
				user.AddYMomentum(1);
			}
			
			this.Invalidate();
			time++;
			if(time == 2000 && level == 0 && user.GetAlive())
			{
				if(first == false)
				{
					activeShips.Add(boss1);
					first = true;
				}
				boss1.Spawn(1000, 400);
				pause = true;
			}
			if(levelComplete == true && time >= 400)
			{
				levelComplete = false;
//				score = 100;
//				pause = false;
//				foreach(Ship ship in activeShips)
//				{
//					ship.Spawn();
//				}
				
			}

		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick (e);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			foreach(Ship ship in activeShips)
			{
				if(!ship.IfUser())
				{
					ship.Reset();
					ship.Spawn();
				}
			}
			foreach(PowerUp powerUp in powerUps)
			{
				powerUp.Reset();
			}

			//user
			user.Spawn(50,400);
			baddie.Spawn(800, 200);
			boss1.Reset();
			time = 0;
			score = 0;
			pause = false;
			levelComplete = false;
			level = 0;
			activeShips.RemoveRange(0,activeShips.Count);
			activeShips.Add(cargo);
			first = false;
			
			for(int i=0; i<15; i++)
			{
				activeShips.Add(new SShip());
			}
//			foreach(Ship ship in activeShips)
//			{
//				ship.Reset();
//			}
			
			
		}
		public void ResetLevel()
		{
			kills = 0;
			shots = 0;
			hits = 0;
			time = 0;
		}
		public void SetEndLevelReport()
		{
			killPoints = kills*10;
			hpPoints = user.GetHp() * 15;
			if(shots != 0)
			{
				accuracy = (int)(((float)hits / (float)shots) * 1000);
			}
			accuracyPoints = accuracy;
			levelComplete = true;
			user.SetHp(user.GetMaxHp());

//			if(level == 1)
//			{
//				activeShips.RemoveRange(0,activeShips.Count);
//				for(int i=0; i<10; i++)
//				{
//					activeShips.Add(new Fish());
//				}
//				for(int i=0; i < 5; i++)
//				{
//					activeShips.Add(new SShip());
//				}
//				
//			}
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			Application.Exit();
			base.OnClosing (e);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			How how = new How();
			how.Show();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Contols control = new Contols();
			control.Show();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			About about = new About();
			about.Show();
		}

	}
}
