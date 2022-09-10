using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ultra_Space
{

	public class Ship
	{
		protected int x;
		protected int y;
		protected float xSpeed;
		protected float ySpeed;
		protected float maxSpeed;
		protected float acceleration;	//how fast the ship will accelerate
		protected bool alive;
		protected int hp;
		protected int maxHP;
		protected float cooldown;
		protected int maxShots;
		protected bool exploding;		//this will tell you if the ship is in the process of exploding
		protected int explodeCount;		//keeps track of which image in the array(index) should be displayed
		protected int explodeCounter;	//this is what we use to cycle through the explode count
		protected bool right;			//whether or not the ship faces right
		protected Projectile[] projectiles = new Projectile[50];
		protected int currentProjectile;//this keeps track of which projectile was fired last, (the index)

		protected Rectangle rec;
		
		protected Image[] explosions = new Image[6];
		protected Image[] ship = new Image[3];

		protected Image currentImage;

		public Ship(int x, int y)
		{
			this.alive = true;
			this.x = x;
			this.y = y;
			this.xSpeed = 0;
			this.ySpeed = 0;
			this.exploding = false;
			this.right = true;
			this.currentProjectile = 0;

			#region Load up the explosion array
			explosions[0] = Image.FromFile("explosion1.gif");
			explosions[1] = Image.FromFile("explosion2.gif");
			explosions[2] = Image.FromFile("explosion3.gif");
			explosions[3] = Image.FromFile("explosion4.gif");
			explosions[4] = Image.FromFile("explosion5.gif");
			explosions[5] = Image.FromFile("explosion6.gif");
			#endregion


		}

		public void FlipImages()
		{
			foreach(Image img in ship)
			{
				img.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipX);
			}

			if(right)
			{
				right = false;
			}
			else
			{
				right = true;
			}
		}
		public bool GetRight()
		{
			return this.right;
		}
		public void ChangeImage(Image newImage)
		{
			this.currentImage = newImage;
			this.rec.Width = newImage.Width;
			this.rec.Height = newImage.Height;
			if(this.rec.IsEmpty)
			{
				MessageBox.Show("No Rectangle", "Error: Ship.ChangeImage");
				System.Threading.Thread.Sleep(2000);
			}
		}
		public void DrawShip(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if(this.alive)
			{
				g.DrawImage(this.currentImage, this.x, this.y);
				this.Explode();
			}
			this.MoveShip();

			#region Draw Projectiles
			foreach(Projectile proj in projectiles)
			{
				proj.DrawProjectile(e);
			}
			#endregion

		}
		public void AddXMomentum(int rightOrLeft)
		{
			if(!exploding)
			{
				if(this.xSpeed < this.maxSpeed && this.xSpeed > this.maxSpeed * -1)
				{
					if(rightOrLeft > 0)
					{
						this.xSpeed += this.acceleration;
					}
					else
					{
						this.xSpeed -= this.acceleration;
					}
				}
				if(this.xSpeed > this.maxSpeed)
				{
					this.xSpeed = this.maxSpeed;
				}
				else if(this.xSpeed < this.maxSpeed * -1)
				{
					this.xSpeed = this.maxSpeed * -1;
				}
			}
		}
		public void AddYMomentum(int rightOrLeft)
		{
			if(!exploding)
			{
				if(this.ySpeed < this.maxSpeed)
				{
					if(rightOrLeft > 0)
					{
						this.ySpeed += this.acceleration;
					}
					else
					{
						this.ySpeed -= this.acceleration;
					}
				}
				if(this.ySpeed > this.maxSpeed)
				{
					this.ySpeed = this.maxSpeed;
				}
				else if(this.ySpeed < this.maxSpeed * -1)
				{
					this.ySpeed = this.maxSpeed * -1;
				}
			}
			
		}
		public void MoveShip()
		{
			this.x += (int)this.xSpeed;
			this.y += (int)this.ySpeed;
			
			this.rec.X = this.x;
			this.rec.Y = this.y;
			
			#region makes you slow down
			if(this.xSpeed != 0)
			{
				this.xSpeed *= .97f;
			}
		
			if(this.ySpeed != 0)
			{
				this.ySpeed *= .97f;
			}
			#endregion
			
			#region Stops you from going off the screen
			if(this.x < 0)
			{
				this.x = 0;
			}
			else if(this.x > 1000)
			{
				this.x = 1000;
			}
			if(this.y < 0)
			{
				this.y = 0;
			}
			else if (this.y > 700)
			{
				this.y = 700;
			}
			#endregion

			#region Move all of the ships projectiles
			foreach(Projectile proj in projectiles)
			{
				proj.MoveProjectile();
			}
			#endregion
		}
		public void Explode()
		{
			if(this.exploding)
			{
				this.currentImage = this.explosions[explodeCount];
				this.explodeCounter++;
				if(explodeCounter >= 4)
				{
					explodeCounter = 0;
					explodeCount++;
				}


				if(this.explodeCount >= 6)
				{
					this.explodeCount = 0;
					this.exploding = false;
					this.alive = false;
				}
			}
		}
		public void ChangeExploding(bool newValue)
		{
			this.exploding = newValue;
		}

		public void Reset()
		{
			this.alive = false;
			foreach(Projectile proj in projectiles)
			{
				proj.Kill();
			}
		}
		public void StartExplosion()
		{
			this.ChangeExploding(true);
			this.Explode();
		}
		public int GetX()
		{
			return this.x;
		}
		public int GetY()
		{
			return this.y;
		}
		public void SetX(int x)
		{
			this.x = x;
		}
		public void SetY(int y)
		{
			this.y = y;
		}
		public void Fire()
		{
			try
			{
				if(this.projectiles[this.currentProjectile].GetAlive() == false)
				{
					this.projectiles[this.currentProjectile].SetAlive(true);
				
					//set the proper direction
					if(this.right)
					{
						this.projectiles[this.currentProjectile].SetDirection(1,0);
					}
					else
					{
						this.projectiles[this.currentProjectile].SetDirection(-1,0);
					}
					this.projectiles[this.currentProjectile].SetX(this.x);
					this.projectiles[this.currentProjectile].SetY(this.y);

					this.currentProjectile++;
					if(this.currentProjectile > this.projectiles.Length)
					{
						this.currentProjectile = 0;
					}
				}

			}
			catch(System.IndexOutOfRangeException)
			{
				this.currentProjectile = 0;
			}
	
		}
		public void Damage()
		{
			this.hp--;
			if(this.hp <= 0)
			{
				this.StartExplosion();
			}
		}
		public void Damage(int damage)
		{
			this.hp -= damage;
			
			if(this.hp <= 0)
			{
				this.StartExplosion();
			}
		}
		public void CheckCollision(Ship enemyShip)
		{
			//if you hit the enemy ship
			if(this.rec.IntersectsWith(enemyShip.rec))
			{
				this.StartExplosion();
				enemyShip.Damage(this.hp);
			}
			//checks to see if your projectiles hit their ship
			foreach(Projectile proj in this.projectiles)
			{
				if(proj.GetRectangle().IntersectsWith(enemyShip.rec) && proj.GetAlive())
				{
					enemyShip.Damage(proj.GetDamage());
					proj.Kill();
				}
			}
			//checks if they hit you
			foreach(Projectile proj in enemyShip.projectiles)
			{
				if(proj.GetRectangle().IntersectsWith(this.rec) && proj.GetAlive())
				{
					this.Damage(proj.GetDamage());
					proj.Kill();
				}
			}
		}
		public void SetAlive(bool alive)
		{
			this.alive = alive;
		}
		public void Spawn(int x, int y)
		{
			this.alive = true;
			this.x = x;
			this.y = y;
			this.exploding = false;
			this.ChangeImage(this.ship[0]);
			this.hp = this.maxHP;
		}	
	}
}
