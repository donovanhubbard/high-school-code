using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Loading_bar
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer2;
		private System.ComponentModel.IContainer components;

		

		int loading = 0;
		bool up = true;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer3;
		float timeLeft = 2;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.timer3 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(32, 184);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(216, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(80, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 48);
			this.label1.TabIndex = 1;
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(128, 232);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "2 minutes left";
			// 
			// timer3
			// 
			this.timer3.Enabled = true;
			this.timer3.Interval = 1000;
			this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar1);
			this.Name = "Form1";
			this.Text = "Really Cool Program";
			this.ResumeLayout(false);

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
			if(progressBar1.Value < 50 && up == true)
			{
				progressBar1.Value++;

			}
			else if(progressBar1.Value > 0)
			{
				progressBar1.Value--;
				up = false;

			}
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			
			if(progressBar1.Value > 0)
			{
				loading++;

				if(loading >= 5)
				{
					loading = 0;
				}
				switch(loading)
				{
					case 0:
						label1.Text = "Loading";
						break;

					case 1:
						label1.Text = "Loading .";
						break;
					case 2:
						label1.Text = "Loading . .";
						break;
					case 3:
						label1.Text = "Loading . . .";
						break;
					case 4:
						label1.Text = "Loading . . . .";
						break;
					default:
						label1.Text = "ERROR!";
						break;
				}
			}
			else if (up == false && progressBar1.Value == 0)
				label1.Text = "It ain't ganna happen!";
		}

		private void timer3_Tick(object sender, System.EventArgs e)
		{
			if(up == true)
			{
				timeLeft -= .2f;
			}
			else
			{
				timeLeft++;
			}
			label2.Text = timeLeft+" minutes left";
		}


		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove (e);
		}


		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing (e);
		}

	}
}
