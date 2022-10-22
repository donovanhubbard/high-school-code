using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Ultra_Space
{

	public class Form1 : System.Windows.Forms.Form
	{
		PShip user = new PShip(10, 200);
		PShip enemy = new PShip(200, 400);
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		bool right = false;
		bool left = false;
		bool up = false;
		bool down = false;

		internal int width;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		internal int height;


		public Form1()
		{

			InitializeComponent();
			width = this.width;
			height = this.height;

			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			user.DrawShip(e);
			enemy.DrawShip(e);
			user.CheckCollision(enemy);
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
					user.FlipImages();
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
				user.Fire();
			}
			if(e.KeyCode == Keys.Enter)
			{
				enemy.Fire();
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
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
																					  this.menuItem1});
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
			this.menuItem2.Text = "New Game";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Ultra Space";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion

	
		static void Main() 
		{
			Application.Run(new Form1());
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
		}

		protected override void OnClick(EventArgs e)
		{
			user.ChangeExploding(true);
			base.OnClick (e);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			user.Reset();
			enemy.Reset();
			user.Spawn(50,50);
			enemy.Spawn(100, 100);
		}

	}
}
