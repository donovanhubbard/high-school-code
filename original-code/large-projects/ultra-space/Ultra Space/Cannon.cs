using System;
using System.Drawing;

namespace Ultra_Space
{
	/// <summary>
	/// Summary description for Cannon.
	/// </summary>
	public class Cannon : Projectile
	{
		public Cannon(int x, int y) : base(x,y)
		{
			this.projectile[0] = Image.FromFile("Cannon1.gif");
			this.projectile[1] = Image.FromFile("Cannon2.gif");
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
