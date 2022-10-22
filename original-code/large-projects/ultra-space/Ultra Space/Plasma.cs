using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ultra_Space
{

	public class Plasma : Projectile
	{
		protected GraphicsPath g;
		public Plasma(int x, int y) : base(x,y)
		{
			//g = new GraphicsPath();
			this.maxSpeed = 12;
			this.projectile[0] = Image.FromFile("plasma1.gif");
			this.projectile[1] = Image.FromFile("plasma2.gif");
			this.projectile[2] = Image.FromFile("plasma3.gif");
			this.projectile[3] = Image.FromFile("plasma4.gif");
			this.currentImage = this.projectile[0];
			this.damage = 1;
		}


		
	}
}
