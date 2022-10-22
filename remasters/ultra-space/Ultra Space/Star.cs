using System;
using System.Windows.Forms;
using System.Drawing;

namespace Ultra_Space
{
	/// <summary>
	/// Summary description for Star.
	/// </summary>
	public class Star
	{
		int x, y;
		int speed;

		public Star()
		{
			this.speed = -3;
		}
		public void Draw(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.FillEllipse(Brushes.White, this.x, this.y, 5, 5);
			this.Move();

		}
		public void Move()
		{
			this.x += this.speed;
			if(this.x < -20)
			{
				this.Spawn();
			}
		}
		public void Spawn()
		{
			this.x = 1000 + Form1.r.Next(1500);
			this.y = Form1.r.Next(700);
		}
		public void FirstSpawn()
		{
			this.x = Form1.r.Next(1500);
			this.y = Form1.r.Next(700);
		}
	}
}
