using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Ultra_Space.Properties;

namespace Ultra_Space
{

	public class Plasma : Projectile
	{
		protected GraphicsPath g;
		public Plasma(int x, int y) : base(x,y)
		{
			//g = new GraphicsPath();
			this.maxSpeed = 12;
			this.projectile[0] = Resources.plasma1;
			this.projectile[1] = Resources.plasma1;
			this.projectile[2] = Resources.plasma1;
			this.projectile[3] = Resources.plasma1;
			this.currentImage = this.projectile[0];
			this.damage = 1;
		}


		
	}
}
