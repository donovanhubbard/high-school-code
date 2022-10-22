using System;
using System.Drawing;
using Ultra_Space.Properties;

namespace Ultra_Space
{
	//this powerup will simply give you more life
	
	public class Health : PowerUp
	{
		public Health(int x, int y):base(x,y)
		{
			this.xSpeed = -1f;
			this.ChangeImage(Resources.health);
		}
		public override void Effect(Ship affectedShip)
		{
			affectedShip.AddHealth(5);
			this.alive = false;
			base.Effect (affectedShip);
			Form1.health.Reset();
		}

	}
}
