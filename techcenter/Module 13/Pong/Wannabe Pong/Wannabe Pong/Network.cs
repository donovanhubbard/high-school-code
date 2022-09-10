using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pong
{
	/// <summary>
	/// Summary description for Network.
	/// </summary>
	public class Network : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textPortCreate;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textPortJoin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textIPJoin;
		private System.Windows.Forms.Button buttonJoin;



		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public string ipAdress;
		public string port;
		public bool host;

		public Network()
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
				if(components != null)
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
			this.label3 = new System.Windows.Forms.Label();
			this.textPortCreate = new System.Windows.Forms.TextBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textPortJoin = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textIPJoin = new System.Windows.Forms.TextBox();
			this.buttonJoin = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Create a game";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(48, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 32);
			this.label2.TabIndex = 1;
			this.label2.Text = "Join a game";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(40, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Port #";
			// 
			// textPortCreate
			// 
			this.textPortCreate.Location = new System.Drawing.Point(96, 56);
			this.textPortCreate.Name = "textPortCreate";
			this.textPortCreate.Size = new System.Drawing.Size(96, 20);
			this.textPortCreate.TabIndex = 3;
			this.textPortCreate.Text = "textBox1";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(56, 88);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(96, 24);
			this.buttonStart.TabIndex = 4;
			this.buttonStart.Text = "Start";
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.buttonStart);
			this.groupBox1.Controls.Add(this.textPortCreate);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(40, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(224, 128);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonJoin);
			this.groupBox2.Controls.Add(this.textIPJoin);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.textPortJoin);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(32, 152);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(240, 144);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(56, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Port #";
			// 
			// textPortJoin
			// 
			this.textPortJoin.Location = new System.Drawing.Point(112, 48);
			this.textPortJoin.Name = "textPortJoin";
			this.textPortJoin.Size = new System.Drawing.Size(88, 20);
			this.textPortJoin.TabIndex = 3;
			this.textPortJoin.Text = "textBox2";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(40, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "IP Adress";
			// 
			// textIPJoin
			// 
			this.textIPJoin.Location = new System.Drawing.Point(112, 88);
			this.textIPJoin.Name = "textIPJoin";
			this.textIPJoin.Size = new System.Drawing.Size(88, 20);
			this.textIPJoin.TabIndex = 5;
			this.textIPJoin.Text = "textBox3";
			// 
			// buttonJoin
			// 
			this.buttonJoin.Location = new System.Drawing.Point(64, 120);
			this.buttonJoin.Name = "buttonJoin";
			this.buttonJoin.Size = new System.Drawing.Size(128, 16);
			this.buttonJoin.TabIndex = 6;
			this.buttonJoin.Text = "Join";
			this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
			// 
			// Network
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 309);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Network";
			this.Text = "Network";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void buttonStart_Click(object sender, System.EventArgs e)
		{
			port = this.textPortCreate.Text;
			host = true;
			this.Close();
		}

		private void buttonJoin_Click(object sender, System.EventArgs e)
		{
			host = false;
			port = this.textPortJoin.Text;
			ipAdress = this.textIPJoin.Text;
			this.Close();
		}
	}
}
