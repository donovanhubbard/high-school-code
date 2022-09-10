using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace VoteBooth
{

	//Concepts covered: Creating and using a custom delegate
	
	//What the program does: The voting buttons will disapear if you try to click on the wrong
	//candidate. A message box will also appear if you vote for Bush.

	// What I learned: I learned how to use delagates and event handlers to carry out actions
	//when the proper critiera is met.

	public class Form1 : System.Windows.Forms.Form
	{
		int bush = 112;
		Font myFont = new Font(FontFamily.GenericSansSerif, 24);
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{

			InitializeComponent();


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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Red;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(88, 96);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 40);
			this.button1.TabIndex = 0;
			this.button1.TabStop = false;
			this.button1.Text = "Bush";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
			this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Blue;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.Location = new System.Drawing.Point(88, 152);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 40);
			this.button2.TabIndex = 1;
			this.button2.TabStop = false;
			this.button2.Text = "Kerry";
			this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
			this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Green;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.Location = new System.Drawing.Point(88, 208);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(112, 40);
			this.button3.TabIndex = 2;
			this.button3.TabStop = false;
			this.button3.Text = "Nader";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
			this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.Location = new System.Drawing.Point(72, 264);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(152, 40);
			this.button4.TabIndex = 3;
			this.button4.Text = "Donovan";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 309);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "E-Voting Booth";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawString("Cast your vote \nfor President!", myFont, Brushes.Red, 35, 15);
			base.OnPaint (e);
		}

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button2_MouseEnter(object sender, EventArgs e)
		{
			button2.Hide();
		}
		private void button2_MouseLeave(object sender, EventArgs e)
		{
			button2.Show();
		}

		private void button3_MouseEnter(object sender, EventArgs e)
		{
			button3.Hide();
		}

		private void button3_MouseLeave(object sender, EventArgs e)
		{
			button3.Show();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			
		}

		private void button1_MouseEnter(object sender, EventArgs e)
		{
			button1.Hide();
		}

		private void button1_MouseLeave(object sender, EventArgs e)
		{
			button1.Show();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Good Job, you voted for the right person","Vote Received");
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
