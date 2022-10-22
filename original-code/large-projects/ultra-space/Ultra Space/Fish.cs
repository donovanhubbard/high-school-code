using System;
using System.Drawing;

namespace Ultra_Space
{

	public class Fish : Ship
	{

		public Fish()
		{
			this.maxSpeed = 2;
			this.maxHP = 1;
			this.hp = this.maxHP;
			this.maxShots = 10;
			this.cooldown = .5f;
			this.movingCount = 0;
			this.movingCounter = 0;
			this.right = false;
			this.projectiles = new Projectile[10];


			this.acceleration = 1.5f;

			#region load up the ships images
			this.ship[0] = Image.FromFile("fish.gif");
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

			//keeps the ship from slowing down
			if(this.right == false)
			{
				this.xSpeed = 6 * -1;
			}
			else
			{
				this.xSpeed = 6;
			}
			
			#region makes the ship go up and down
			if(this.r.Next(100) <= 2)
			{
				this.ySpeed = -5;

			}
			if(this.r.Next(100) <= 2)
			{
				this.ySpeed = 5;
			}
			#endregion
			
			if(this.r.Next(100) == 0)
			{
				this.Fire();
			}

			base.MoveShip ();
		}

	}
}
	

