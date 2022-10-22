using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;

namespace Ultra_Space
{

	public class Projectile
	{
		protected int x;
		protected int y;
		protected float xSpeed;
		protected float ySpeed;
		protected float maxSpeed;
		protected bool alive;
		protected int slide;
		protected int damage;

		protected Rectangle rec;
		protected Image[] projectile = new Image[4];
		protected Image currentImage;

		
		protected Matrix z = new Matrix();			//used to rotate the projectile

		public Projectile(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.alive = false;
			this.slide = 0;
			this.xSpeed = 0;
			this.ySpeed = 0;
			
		}
		public virtual void DrawProjectile(PaintEventArgs e)
		{
			if(alive)
			{
				Graphics g = e.Graphics;
				g.DrawImage(this.currentImage, x, y);
				this.slide++;
				if(this.slide > this.projectile.Length -1)
				{
					slide = 0;
				}
				if(this.projectile[slide] == null)
				{
					slide = 0;
				}
				this.ChangeImage(this.projectile[slide]);
			}
		}
		public void ChangeImage(Image newImage)
		{
			this.currentImage = newImage;
			this.rec.Width = newImage.Width;
			this.rec.Height = newImage.Height;
		}
		public virtual void MoveProjectile()
		{
			if(alive)
			{
				this.x += (int)this.xSpeed;
				this.y += (int)this.ySpeed;
				this.rec.X = this.x;
				this.rec.Y = this.y;

				#region Kill it if it goes off the screen

				if(this.x + this.currentImage.Width < 0)
				{
					this.SetAlive(false);
				}
				else if(this.x > 1050)
				{
					this.SetAlive(false);
				}
				if(this.y + this.currentImage.Height < 0)
				{
					this.SetAlive(false);
				}
				else if (this.y > 750)
				{
					this.SetAlive(false);
				}
				
				#endregion
			}
		}
		public void SetDirection(int xDirection, int yDirection)
		{
			if(xDirection > 0)
			{
				this.xSpeed = this.maxSpeed;
			}
			else if(xDirection < 0)
			{
				this.xSpeed = -1 * this.maxSpeed;
			}
			else
			{
				this.xSpeed = 0;
			}
			if(yDirection > 0)
			{
				this.ySpeed = this.maxSpeed;
			}
			else if(yDirection < 0)
			{
				this.ySpeed = -1 * this.maxSpeed;
			}
			else
			{
				this.ySpeed = 0;
			}
		}
		public void SetAlive(bool alive)
		{
			this.alive = alive;
		}
		public bool GetAlive()
		{
			return this.alive;
		}
		public void SetX(int x)
		{
			this.x = x;
		}
		public void SetY(int y)
		{
			this.y = y;
		}

		public Rectangle GetRectangle()
		{
			return this.rec;
		}

		public int GetDamage()
		{
			return this.damage;
		}
		public void Kill()
		{
			this.alive = false;
		}
	}
}
