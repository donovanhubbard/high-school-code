using System;
using System.Drawing;

namespace Ultra_Space
{
	//The playable hero ship
	public class PShip : Ship
	{
		public PShip(int x, int y) : base(x,y)
		{
			this.maxSpeed = 7;
			this.maxHP = 20;
			this.hp = this.maxHP;
			this.maxShots = 10;
			this.cooldown = .5f;
			this.right = true;
			this.user = true;
			this.projectiles = new Projectile[15];


			this.acceleration = 1f;

			#region load up the ships images
			this.ship[0] = Image.FromFile("pShip1.gif");
			this.ship[1] = Image.FromFile("pShip2.gif");
			this.ship[2] = Image.FromFile("pShip3.gif");
			#endregion

			this.ChangeImage(this.ship[0]);

			#region Initalize the plasma array
			for(int i=0; i<projectiles.Length; i++)
			{
				projectiles[i] = new Plasma(0,0);
			}
			#endregion
		}
		public override void MoveShip()
		{
			#region Stops you from going off the screen
			if(this.x < 0)
			{
				this.x = 0;
			}
			else if(this.x > 1000)
			{
				this.x = 1000;
			}
			if(this.y < 10)
			{
				this.y = 10;
			}
			else if (this.y > 675)
			{
				this.y = 675;
			}
			#endregion

		
			#region makes you slow down even more than before
			if(this.xSpeed != 0)
			{
				this.xSpeed *= .97f;
			}
		
			if(this.ySpeed != 0)
			{
				this.ySpeed *= .97f;
			}
			#endregion
			

			base.MoveShip ();
		}
		public override void Fire()
		{
			if(Form1.levelComplete == false)
			{
												Form1.shots++;
			}
			base.Fire ();
		}


	}
}
