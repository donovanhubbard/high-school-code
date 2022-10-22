using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Collections;

namespace Ultra_Space
{
	//this is the rather large boss. 
	//I dont know why I called him mongo, but he is the round boss
	public enum FireType {Shotgun, Bombardment};

	
	public class Mongo : Ship
	{
		int currentCannon;
		int extendExplosion;		//keeps the booms going longer
		protected Cannon[] cannons = new Cannon[50];		//only used in some clasess
		public Mongo(int x, int y) : base(x,y)
		{
			this.maxSpeed = 1.5f;
			this.maxHP = 100;
			this.hp = this.maxHP;
			this.right = false;
			//int currentCannon = 0;
			this.user = true;
			this.extendExplosion = 0;
			this.boss = true;
			this.projectiles = new Projectile[150];
			




			this.acceleration = this.maxSpeed;

			#region load up the ships images
			this.ship[0] = Image.FromFile("Boss1.gif");
			#endregion

			this.ChangeImage(this.ship[0]);

			#region Initalize the plasma array
			for(int i=0; i<projectiles.Length; i++)
			{
				projectiles[i] = new Plasma(0,0);
			}
			#endregion
			#region Initalize the Cannon array
			for(int i=0; i< 50; i++)
			{
				cannons[i] = new Cannon(0,0);
			}
			#endregion

			//set the ship to move on initailization
			this.xSpeed = this.maxSpeed * -1;

		}

		public override void Reset()
		{
			this.maxSpeed = 1.5f;
			this.maxHP = 100;
			this.hp = this.maxHP;
			this.right = false;
			//int currentCannon = 0;
			this.user = true;
			this.extendExplosion = 0;
			
			if(this.GetType().ToString() == "Ultra_Space.Mongo" )
			{
				foreach(Projectile proj in cannons)
				{
					proj.Kill();
				}
			}
			base.Reset ();
		}

		public override void CheckCannonCollision(Ship enemyShip)
		{
			base.CheckCannonCollision (enemyShip);
			//if they have a cannon
			
				foreach(Cannon proj in this.cannons)
				{
					if(proj.GetRectangle().IntersectsWith(enemyShip.GetRectangle()) && proj.GetAlive())
					{
						enemyShip.Damage(proj.GetDamage());
						proj.Kill();
					}
				}
		}

		public override void Spawn()
		{
			this.right = false;
			base.Spawn ();
		}

		public override void MoveShip()
		{
			
			//this sets the AI's movement behavior 
			if(this.x < 600)
			{
				this.xSpeed = 0;
				this.x = 600;
			}
			else if(this.x > 620)
			{
				this.AddXMomentum(-1);
			}
			

			if(this.right && this.y < 500&& this.y > 400)
			{
				this.right = false;
			}
			else if(this.y > 0 && this.right)
			{
				this.AddYMomentum(1);
				
			}
			else if(this.y < 100 && this.right == false)
			{
				this.right = true;
			}
			else if(this.y < 600 && this.right == false)
			{
				this.AddYMomentum(-1);
			}


			#region Firing Script
			#region ShotGun Firing
			if(this.y > 300)
			{
				if(this.y % 10 == 0)
				{
					this.ShotgunFire(150);
				}
				else if(this.y % 10 == 5)
				{
					this.ShotgunFire(80);
				}
			}
			#endregion
			#region Cannon Series
			if(this.y> 100 && this.y < 200)
			{
				if(this.y % 20 == 0)
				{
					this.FireCannon(45);
				}
				else if(this.y%20 == 5)
				{
					this.FireCannon(90);
				}
				else if(this.y%20 == 10)
				{
					this.FireCannon(150);
				}
				if(this.y % 4 == 1)
				{
					this.FireSingle(75);
					this.FireSingle(150);
				}

			}
			#endregion
			#endregion
			#region Move Cannons
			if(this.GetType().ToString() == "Ultra_Space.Mongo")
				if(this.cannons[0] != null)
				{
					foreach(Projectile proj in cannons)
					{
						proj.MoveProjectile();
					}
				}
			#endregion
			base.MoveShip ();
		}


		public void ShotgunFire(int yPosition)
		{
			if(this.alive)
			{
				for(int j = 0; j< 10; j++)
				{
					#region Base Fire
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
					#endregion
					//set the proper direction
					if(j%3 == 0)
					{
						this.projectiles[this.currentProjectile].SetDirection(-1,0);
					}
					else if(j%3 == 1)
					{
						this.projectiles[this.currentProjectile].SetDirection(-1,-1);
					}
					else
					{
						this.projectiles[this.currentProjectile].SetDirection(-1,1);
					}
					this.projectiles[this.currentProjectile].SetX(this.x + 20);
					this.projectiles[this.currentProjectile].SetY(this.y + yPosition);
					
				}
		
			}
		}	
		public void FireSingle(int y)
		{
			if(this.alive)
			{
				 #region Base Fire
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
					 this.projectiles[this.currentProjectile].SetDirection(-1,0);

					 this.projectiles[this.currentProjectile].SetX(this.x);
					 this.projectiles[this.currentProjectile].SetY(this.y + y);


				 }
			 }
			 catch(System.IndexOutOfRangeException)
			 {
				 this.currentProjectile = 0;
			 }
			 #endregion
			}
		}
		public void FireCannon(int y)
		{
			if(this.alive && !this.exploding)
			{
				try
				{
					this.currentCannon++;
					if(this.currentCannon > this.cannons.Length)
					{
						this.currentCannon = 0;
					}

					if(this.cannons[this.currentCannon].GetAlive() == false)
					{
						this.cannons[this.currentCannon].SetAlive(true);
				
						//set the proper direction

						this.cannons[this.currentCannon].SetDirection(-1,0);

						this.cannons[this.currentCannon].SetX(this.x);
						this.cannons[this.currentCannon].SetY(this.y + y);


					}

				}
				catch(System.IndexOutOfRangeException)
				{
					this.currentCannon = 0;
				}
			}
		}
		public override void DrawShip(System.Windows.Forms.PaintEventArgs e)
		{
			base.DrawShip (e);
			
			Graphics g =e.Graphics;
			if(this.alive)
			{
				#region Draw Cannon
				foreach(Projectile proj in cannons)
				{
					proj.DrawProjectile(e);
				}
				#endregion
				#region Draw Life Bar
				g.FillRectangle(Brushes.Red, 20, 650, this.hp*10, 20);
				g.DrawRectangle(Pens.White, 20, 650, this.maxHP*10, 20);
				g.DrawString("Boss", new Font("Impact", 36), Brushes.White, 20, 600);
				#endregion
			}

			#region New Exploding code
			if(this.exploding)
			{
				for(int i = 0; i<5; i++)
				{
					int j = this.explodeCount+i;

					int tempY = this.y;
					switch(i)
					{
						case 0:
							tempY += 75;
							break;
						case 1:
							tempY += 40;
							break;
						case 2:
							tempY += 150;
							break;
						case 3:
							tempY += 105;
							break;
						case 4:
							tempY += 60;
							break;
						case 5:
							tempY += 0;
							break;
					}
					while(j> this.explosions.Length)
					{
						j-=this.explosions.Length;
					}
					try
					{
						g.DrawImage(this.explosions[j], this.x + i*20, tempY);
					}
					catch
					{

					}
					if(this.explodeCount == 5 && this.extendExplosion < 4)
					{
						this.explodeCount = 0;
						this.extendExplosion++;
					}
					if(this.extendExplosion == 4)
					{
						g.FillRectangle(Brushes.White, 0, 0, 1500, 1000);
					}
					
				}	
			}
			#endregion

			
		}

	}
}
