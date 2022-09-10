using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ultra_Space
{
	//this is the super class that will hold all of the powerups
	public class PowerUp
	{
		protected int x;
		protected int y;
		protected float xSpeed;
		protected float ySpeed;
		protected bool alive;
		protected Rectangle rec;

		protected Image image;

		public PowerUp(int x, int y)
		{
			this.y = y;
			this.x = x;
			this.alive = false;
			this.rec = new Rectangle(this.x, this.y, 0, 0);
			this.Spawn(this.x, this.y);
		}
		public void ChangeImage(Image newImage)
		{
			this.image = newImage;
			this.rec.Width = this.image.Width;
			this.rec.Height = this.image.Height;
		}
		public void Spawn(int x, int y)
		{
			if(!Form1.pause)
			{
				this.alive = true;
				this.x = x;
				this.y = y;
			}
			
		}
		public void Move()
		{
			if(alive)
			{
				this.x+=(int)this.xSpeed;
				this.y+=(int)this.ySpeed;
				this.rec.X = this.x;
				this.rec.Y = this.y;
			}
			if(this.x<-100)
			{
				this.Reset();
			}
		}
		public void Draw(PaintEventArgs e)
		{
			if(this.alive)
			{
				Graphics g = e.Graphics;
				g.DrawImage(this.image, this.x, this.y);
			}
			this.Move();
		}
		public Rectangle GetRectangle()
		{
			return this.rec;
		}
		public bool GetAlive()
		{
			return this.alive;
		}
		public void Reset()
		{
			this.alive = false;
		}
		//this method will be blank in the super class but will be completely 
		//different in each subclass
		public virtual void Effect(Ship affectedShip)
		{

		}
	}
}
