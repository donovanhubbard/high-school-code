using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Manual_Form
{

	//Concepts Covered: e: Creating a simple form without using the visual studios form editor

	//What the program does: If you click the button the form will change color and get progressively higher blue value

	//What I learned: It is much easier to use the form editor but I know how to do without it if nesacary
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		
		int blue = 50;
		private System.ComponentModel.Container components = null;
		Button button1 = new Button();

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//

			InitializeComponent();

			button1.Text = "Click me!";
			button1.Location = new Point(50,50);
			button1.Show();
			this.Controls.Add(button1);
			this.button1.Click += new EventHandler(button1_Click);

			this.Text = "This form does nothing";

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
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "Form1";

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

		private void button1_Click(object sender, EventArgs e)
		{
			this.BackColor = Color.FromArgb(50,50, blue);
			if (blue <250)
				blue+=5;
			else
				MessageBox.Show("It doesnt get any bluer than that", "Stop please");
		}
	}
}
