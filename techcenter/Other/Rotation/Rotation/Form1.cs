using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace Rotation
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		int x = 150;
		private System.ComponentModel.IContainer components;
		GraphicsPath gPath = new GraphicsPath();
		Rectangle rec = new Rectangle(150, 150, 100, 50);
		private System.Windows.Forms.Timer timer1;
		Matrix z = new Matrix();
		int count = 0;
		Matrix away = new Matrix();
		Matrix come = new Matrix();
		GraphicsPath text = new GraphicsPath();
		Font myFont = new Font("arial", 12);
		bool run = true;



		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			gPath.AddRectangle(rec);
			InitializeComponent();
			z.RotateAt(1, new Point(x,x));
			z.Scale(.9f,.9f);
			z.Shear(.01f,.01f);

			z.Invert();
			away = z;
			z.Invert();
				come = z;
				come.Invert();
			text.AddString("Hello World!", FontFamily.GenericMonospace, 0, 24, new PointF(x,x),new StringFormat(StringFormat.GenericTypographic));
			for(int i=0; i>20;i++)
			{
				text.Transform(z);
			}
			text.Transform(away);
			//z.Invert();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// 
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			//z.Rotate(1);
			//z.RotateAt(2, new Point(x,x));
			gPath.Transform(z);
			//g.FillPath(Brushes.Red, gPath);
			count++;
			if(count>=20)
			{
				z.Invert();
				//count = 0;
			}
			//g.FillPath(Brushes.Black, gPath);
			g.FillPath(Brushes.Red, text);
			//text.Transform(z);
			text.Transform(z);


			

			base.OnPaint (e);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Invalidate();
		}
	}
}
