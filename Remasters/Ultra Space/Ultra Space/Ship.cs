using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Ultra_Space.Properties;

namespace Ultra_Space
{

	public class Ship
	{
		protected Random r = new Random();
		protected bool user;
		protected bool boss;
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
		protected Projectile[] projectiles;
		protected int currentProjectile;//this keeps track of which projectile was fired last, (the index)
		protected int movingCount;		//keeps track of which image is being displayed for the movement of the ship
		protected int movingCounter;	//helps pause on each frame for a second or two;
		//protected Cannon[] cannons = new Cannon[50];		//only used in some clasess

		protected Rectangle rec;
		
		protected Image[] explosions = new Image[6];
		protected Image[] ship = new Image[10];

		protected Image currentImage;

		public Ship(int x, int y)
		{
			this.alive = false;
			this.x = x;
			this.y = y;
			this.xSpeed = 0;
			this.ySpeed = 0;
			this.exploding = false;
			this.currentProjectile = 0;

			#region Load up the explosion array
			explosions[0] = Resources.explosion1;
			explosions[1] = Resources.explosion2;
            explosions[2] = Resources.explosion3;
            explosions[3] = Resources.explosion4;
            explosions[4] = Resources.explosion5;
            explosions[5] = Resources.explosion6;
            #endregion

        }
		public Ship(int frame, int x, int y)
		{
			this.alive = true;
			this.x = x;
			this.y = y;
			this.xSpeed = 0;
			this.ySpeed = 0;
			this.exploding = false;
			this.currentProjectile = 0;

            #region Load up the explosion array
            explosions[0] = Resources.explosion1;
            explosions[1] = Resources.explosion2;
            explosions[2] = Resources.explosion3;
            explosions[3] = Resources.explosion4;
            explosions[4] = Resources.explosion5;
            explosions[5] = Resources.explosion6;
            #endregion

        }
		public Ship()
		{
			Random r = new Random();
			this.alive = true;
			this.x = 1000 + r.Next(1000);
			this.y = r.Next(675);
			this.xSpeed = 0;
			this.ySpeed = 0;
			this.exploding = false;
			this.currentProjectile = 0;

            #region Load up the explosion array
            explosions[0] = Resources.explosion1;
            explosions[1] = Resources.explosion2;
            explosions[2] = Resources.explosion3;
            explosions[3] = Resources.explosion4;
            explosions[4] = Resources.explosion5;
            explosions[5] = Resources.explosion6;
            #endregion
        }


		public void FlipImages()
		{
			foreach(Image img in ship)
			{
				if(img != null)
				{
					img.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipX);
				}
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
		public virtual void DrawShip(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if(this.alive)
			{
				g.DrawImage(this.currentImage, this.x, this.y);
				this.Explode();
			}
			this.MoveShip();

			#region Draw Projectiles
			if(this.projectiles[0] != null)
			{
				foreach(Projectile proj in projectiles)
				{
					proj.DrawProjectile(e);
				}
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
		public void AddXMomentum()
		{
				if(!exploding)
				{
					if(this.xSpeed < this.maxSpeed && this.xSpeed > this.maxSpeed * -1)
					{
						if(this.right)
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
		public virtual void MoveShip()
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
			
			if(this.x < -50)
			{
				this.Spawn();
			}

			#region Move all of the ships projectiles
			if(this.projectiles[0] != null)
			{
				foreach(Projectile proj in projectiles)
				{
					proj.MoveProjectile();
				}
			}
			#endregion

		}
		public virtual void Explode()
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
					this.hp = 0;
					//brings the people back to life, unless its you
					//only brings them back if the baddies arent paused
					if(Form1.pause == false)
					{
						if(!this.IfUser())
						{
							this.Spawn();
						}
					}
					//ends the level
					if(this.IfBoss())
					{
						Form1.upkeep = true;
					}
				}
			}
		}
		public void ChangeExploding(bool newValue)
		{
			this.exploding = newValue;
		}

		public virtual void Reset()
		{
			this.alive = false;
			if(this.projectiles[0] != null)
			{
				foreach(Projectile proj in projectiles)
				{
					proj.Kill();
				}
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
		public void AddHealth(int addedHP)
		{
			this.hp+=addedHP;
			if(this.hp>this.maxHP)
			{
				this.hp = this.maxHP;
			}
		}
		public void SetHp(int newHp)
		{
			this.hp = newHp;
		}
		public virtual void Fire()
		{
			if(this.alive)
			{
				try
				{
					this.currentProjectile++;
					if(this.currentProjectile > this.projectiles.Length)
					{
						this.currentProjectile = 0;
					}

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


					}

				}
				catch(System.IndexOutOfRangeException)
				{
					this.currentProjectile = 0;
				}
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
				if(this.GetType().ToString() != "Ultra_Space.PShip")
				{	
					Form1.kills++;
				}
			}
		}
		public virtual void CheckCollision(Ship enemyShip)
		{
			if(this.alive == true && enemyShip.alive == true)
			{
				//if you hit the enemy ship
				if(this.rec.IntersectsWith(enemyShip.rec))
				{
					this.StartExplosion();
					//enemyShip.Damage(this.hp/2);
				}
			}
			if(enemyShip.alive && !this.exploding)
			{
				//checks to see if your projectiles hit their ship
				foreach(Projectile proj in this.projectiles)
				{
					if(proj.GetRectangle().IntersectsWith(enemyShip.rec) && proj.GetAlive())
					{
						enemyShip.Damage(proj.GetDamage());
						Form1.score+=50;
						Form1.hits++;
						proj.Kill();
					}
				}
			}
			if(this.alive)
			{
				//checks if they hit you
				foreach(Projectile proj in enemyShip.projectiles)
				{
					if(proj.GetRectangle().IntersectsWith(this.rec) && proj.GetAlive())
					{
						this.Damage(proj.GetDamage());
						proj.Kill();
					}
				}
				enemyShip.CheckCannonCollision(this);
				
			}
		}
		public Rectangle GetRectangle()
		{
			return this.rec;
		}
		public virtual void CheckCannonCollision(Ship enemyShip)
		{

		}
		public void SetAlive(bool alive)
		{
			this.alive = alive;
		}
		public bool GetAlive()
		{
			return this.alive;
		}
		public virtual void Spawn(int x, int y)
		{
				this.alive = true;
				this.x = x;
				this.y = y;
				this.exploding = false;
				this.ChangeImage(this.ship[0]);
				this.hp = this.maxHP;
			
		}	
		public virtual void Spawn()
		{
			if(Form1.pause == false)
			{
				this.alive = true;
				this.x = 1000 + r.Next(1000);
				this.y = r.Next(750)- 50;
				this.exploding = false;
				this.ChangeImage(this.ship[0]);
				this.hp = this.maxHP;
				this.right = false;
			}
		}
		public int GetHp()
		{
			return this.hp;
		}
		public int GetMaxHp()
		{
			return this.maxHP;
		}
		public bool IfUser()
		{
			if(this.user == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool IfBoss()
		{
			return this.boss;
		}
		public void GetPowerUp(PowerUp powerUp)
		{
			if(this.rec.IntersectsWith(powerUp.GetRectangle()))
			{
				if(this.alive && powerUp.GetAlive())
				{
					powerUp.Effect(this);
				}
			}

		}
	}
}
