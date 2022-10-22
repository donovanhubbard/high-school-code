using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Talker_Client
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textIP;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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

		protected override void OnMouseMove(MouseEventArgs e)
		{
			
			base.OnMouseMove (e);
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textIP = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please Connect to Server";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 32);
			this.label2.TabIndex = 1;
			this.label2.Text = "IP Adress";
			// 
			// textIP
			// 
			this.textIP.Location = new System.Drawing.Point(120, 40);
			this.textIP.Name = "textIP";
			this.textIP.Size = new System.Drawing.Size(136, 20);
			this.textIP.TabIndex = 2;
			this.textIP.Text = "";
			this.textIP.TextChanged += new System.EventHandler(this.textIP_TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(72, 88);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 24);
			this.button1.TabIndex = 3;
			this.button1.Text = "Connect";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 117);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textIP);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Connect";
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

		private void textIP_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Nickname nick = new Nickname();
			this.Hide();
			nick.ShowDialog();
			
		}
	}
}
