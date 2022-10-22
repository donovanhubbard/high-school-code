using System;
using System.Drawing;
using Ultra_Space.Properties;

namespace Ultra_Space
{
	/// <summary>
	/// Summary description for Cargo.
	/// </summary>
	public class Cargo : Ship
	{
		public Cargo()
		{
			this.maxSpeed = 3f;
			this.xSpeed = -1 * this.maxSpeed;
			this.maxHP = 4;
			this.hp = this.maxHP;
			this.ship[0] = Resources.cargo;
			this.ChangeImage(this.ship[0]);
			this.projectiles = new Projectile[1];
			this.projectiles[0] = new Plasma(0,0);
		}
		public Cargo(int x, int y):base(x,y)
		{
			this.maxSpeed = 3f;
			this.xSpeed = -1 * this.maxSpeed;
			this.maxHP = 4;
			this.hp = this.maxHP;
			this.ship[0] = Resources.cargo;
			this.ChangeImage(this.ship[0]);
			this.projectiles = new Projectile[1];
			this.projectiles[0] = new Plasma(0,0);
		}
		public override void Explode()
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
					//Form1.powerUps.Add(new Health(this.x, this.y));
					if(!Form1.health.GetAlive())
					{
						Form1.health.Spawn(this.x, this.y);
					}

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
		public override void MoveShip()
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
			

			#region Move all of the ships projectiles
			if(this.projectiles[0] != null)
			{
				foreach(Projectile proj in projectiles)
				{
					proj.MoveProjectile();
				}
			}
			#endregion
			//keeps the ship from slowing down
			if(this.right == false)
			{
				this.xSpeed = this.maxSpeed * -1;
			}
			else
			{
				this.xSpeed = this.maxSpeed;
			}
		}

		public override void Spawn()
		{
			if(Form1.r.Next(500) == 1)
			{
				base.Spawn ();
			}
		}


	}
}
