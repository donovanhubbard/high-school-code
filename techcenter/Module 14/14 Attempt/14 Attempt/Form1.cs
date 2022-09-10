using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace _14_Attempt
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Data.SqlClient.SqlConnection conn;
		private System.Data.SqlClient.SqlCommand cmd;
		private System.Data.SqlClient.SqlCommand insert;
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.cmd = new System.Data.SqlClient.SqlCommand();
			this.button1 = new System.Windows.Forms.Button();
			this.insert = new System.Data.SqlClient.SqlCommand();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(112, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(128, 88);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(120, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// conn
			// 
			this.conn.ConnectionString = "workstation id=COMPANY30;packet size=4096;integrated security=SSPI;data source=co" +
				"mpanyaspnet;persist security info=False;initial catalog=DonH";
			this.conn.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(this.sqlConnection1_InfoMessage);
			// 
			// cmd
			// 
			this.cmd.CommandText = "SELECT Password FROM UserID WHERE ([User Name] = @UserName)";
			this.cmd.Connection = this.conn;
			this.cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.VarChar, 50, "User Name"));
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(96, 160);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// insert
			// 
			this.insert.CommandText = "INSERT INTO UserID ([User Name], Password) VALUES (\'@UserName\', \'@Password\')";
			this.insert.Connection = this.conn;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			conn.Open();
			String userName = textBox1.Text;
			cmd.Parameters [@UserName].Value = userName;
			string password = cmd.ExecuteScalar();
			conn.Close();




			

		}
	}
}
