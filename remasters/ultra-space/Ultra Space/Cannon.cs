using System;
using System.Drawing;
using Ultra_Space.Properties;

namespace Ultra_Space
{
	/// <summary>
	/// Summary description for Cannon.
	/// </summary>
	public class Cannon : Projectile
	{
		public Cannon(int x, int y) : base(x,y)
		{
			this.projectile[0] = Resources.Cannon1;
			this.projectile[1] = Resources.Cannon2;
			this.currentImage = this.projectile[0];
			this.maxSpeed = 10;
			this.damage = 5;
			

		}
		public override void MoveProjectile()
		{
			if(this.currentImage == this.projectile[0])
			{
				this.ChangeImage(this.projectile[1]);
			}
			else
			{
				this.ChangeImage(this.projectile[0]);
			}
			base.MoveProjectile ();
		}

	}
}
