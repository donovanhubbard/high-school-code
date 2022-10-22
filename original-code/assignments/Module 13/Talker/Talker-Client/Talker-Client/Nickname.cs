using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Talker_Client
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Nickname : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textNick;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Nickname()
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
		/// 

		private void button1_Click(object sender, System.EventArgs e)
		{

		}
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
		/// 

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textNick = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose a Nick Name";
			// 
			// textNick
			// 
			this.textNick.Location = new System.Drawing.Point(48, 48);
			this.textNick.Name = "textNick";
			this.textNick.Size = new System.Drawing.Size(136, 20);
			this.textNick.TabIndex = 1;
			this.textNick.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(80, 88);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Enter";
			this.button1.Click +=new EventHandler(button1_Click);
			// 
			// Nickname
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 125);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textNick);
			this.Controls.Add(this.label1);
			this.Name = "Nickname";
			this.Text = "Nick Name";
			this.ResumeLayout(false);

		}
		#endregion
	}

	
}
