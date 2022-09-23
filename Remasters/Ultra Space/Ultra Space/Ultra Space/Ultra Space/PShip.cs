using System;
using System.Drawing;

namespace Ultra_Space
{

	public class PShip : Ship
	{
		public PShip(int x, int y) : base(x,y)
		{
			this.maxSpeed = 7;
			this.maxHP = 20;
			this.hp = this.maxHP;
			this.maxShots = 10;
			this.cooldown = .5f;


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
	}
}
