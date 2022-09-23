using System;
using System.Drawing;
using Ultra_Space.Properties;

namespace Ultra_Space
{
	//SShip stands for Spinning Ship
	//this is the baddie ship that continually does barrel rolls
	public class SShip : Ship
	{
		public SShip(int x, int y) : base(x,y)
		{
			this.maxSpeed = 3;
			this.maxHP = 2;
			this.hp = this.maxHP;
			this.maxShots = 10;
			this.cooldown = .5f;
			this.movingCount = 0;
			this.movingCounter = 0;
			this.right = false;
			this.projectiles = new Projectile[50];


			this.acceleration = 1.5f;

			#region load up the ships images
			this.ship[0] = Resources.SShip1;
			this.ship[1] = Resources.SShip2;
			this.ship[2] = Resources.SShip3;
			this.ship[3] = Resources.SShip4;
			this.ship[4] = Resources.SShip5;
			this.ship[5] = Resources.SShip6;
			//this.ship[6] = Image.FromFile("SShip7.gif");
			#endregion

			this.ChangeImage(this.ship[0]);

			#region Initalize the plasma array
			for(int i=0; i<projectiles.Length; i++)
			{
				projectiles[i] = new Plasma(0,0);
			}
			#endregion

			//set the ship to move on initailization
			this.xSpeed = this.maxSpeed * -1;
		}
		public SShip(int slide, int x, int y) : base(slide,x,y)
		{
			this.maxSpeed = 3;
			this.maxHP = 2;
			this.hp = this.maxHP;
			this.maxShots = 10;
			this.cooldown = .5f;
			this.movingCount = 0;
			this.movingCounter = 0;
			this.right = false;
			this.projectiles = new Projectile[15];


			this.acceleration = 1.5f;

            #region load up the ships images
            this.ship[0] = Resources.SShip1;
            this.ship[1] = Resources.SShip2;
            this.ship[2] = Resources.SShip3;
            this.ship[3] = Resources.SShip4;
            this.ship[4] = Resources.SShip5;
            this.ship[5] = Resources.SShip6;
            //this.ship[6] = Image.FromFile("SShip7.gif");
            #endregion

            this.ChangeImage(this.ship[slide]);

			#region Initalize the plasma array
			for(int i=0; i<projectiles.Length; i++)
			{
				projectiles[i] = new Plasma(0,0);
			}
			#endregion

			//set the ship to move on initailization
			this.xSpeed = this.maxSpeed * -1;
		}
		public SShip()
		{
			this.maxSpeed = 3;
			this.maxHP = 2;
			this.hp = this.maxHP;
			this.maxShots = 10;
			this.cooldown = .5f;
			this.movingCount = 0;
			this.movingCounter = 0;
			this.right = false;
			this.projectiles = new Projectile[15];


			this.acceleration = 1.5f;

            #region load up the ships images
            this.ship[0] = Resources.SShip1;
            this.ship[1] = Resources.SShip2;
            this.ship[2] = Resources.SShip3;
            this.ship[3] = Resources.SShip4;
            this.ship[4] = Resources.SShip5;
            this.ship[5] = Resources.SShip6;
            //this.ship[6] = Image.FromFile("SShip7.gif");
            #endregion

            this.ChangeImage(this.ship[0]);

			#region Initalize the plasma array
			for(int i=0; i<projectiles.Length; i++)
			{
				projectiles[i] = new Plasma(0,0);
			}
			#endregion

			//set the ship to move on initailization
			this.xSpeed = this.maxSpeed * -1;

			this.Spawn();
		}

		public override void Spawn()
		{
			this.movingCount = r.Next(5);
			base.Spawn ();
		}

		public override void MoveShip()
		{
			#region Makes the ship rotate
			if(this.exploding == false)
			{
				this.movingCounter++;
				if(this.movingCounter > 10)
				{
					this.movingCount++;
					this.movingCounter = 0;
				}	
				if(this.movingCount > 5)
				{
					this.movingCount = 0;
				}
				this.ChangeImage(this.ship[this.movingCount]);
				
				//makes the ship go up and down
				if(this.currentImage == this.ship[0])
				{
					this.AddYMomentum(-1);
					if(this.movingCounter == 0)
					{
						this.Fire();
					}
				}
				else if(this.currentImage == this.ship[2])
				{
					this.AddYMomentum(1);
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
			

			base.MoveShip ();
		}

	}
}
