using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Password
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textUserName;
		private System.Windows.Forms.TextBox textPassword;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlConnection conn;
		private Password.dsTable dsTable;
		private System.Data.SqlClient.SqlDataAdapter da1;
		private System.Windows.Forms.Button button3;
		private System.ComponentModel.IContainer components;

		public Form2()
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
			this.textUserName = new System.Windows.Forms.TextBox();
			this.dsTable = new Password.dsTable();
			this.textPassword = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.da1 = new System.Data.SqlClient.SqlDataAdapter();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dsTable)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password";
			// 
			// textUserName
			// 
			this.textUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsTable, "UserID.User Name"));
			this.textUserName.Location = new System.Drawing.Point(136, 24);
			this.textUserName.Name = "textUserName";
			this.textUserName.TabIndex = 2;
			this.textUserName.Text = "";
			// 
			// dsTable
			// 
			this.dsTable.DataSetName = "dsTable";
			this.dsTable.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// textPassword
			// 
			this.textPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsTable, "UserID.Password"));
			this.textPassword.Location = new System.Drawing.Point(136, 72);
			this.textPassword.Name = "textPassword";
			this.textPassword.TabIndex = 3;
			this.textPassword.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 112);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "Previous";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(152, 112);
			this.button2.Name = "button2";
			this.button2.TabIndex = 5;
			this.button2.Text = "Next";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT [ID Number], [User Name], Password FROM UserID";
			this.sqlSelectCommand1.Connection = this.conn;
			// 
			// conn
			// 
			this.conn.ConnectionString = "workstation id=COMPANY33;packet size=4096;integrated security=SSPI;data source=CO" +
				"MPANYASPNET;persist security info=True;initial catalog=DonH";
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO UserID([ID Number], [User Name], Password) VALUES (@Param1, @Param2, " +
				"@Password); SELECT [ID Number], [User Name], Password FROM UserID WHERE ([ID Num" +
				"ber] = @ID_Number)";
			this.sqlInsertCommand1.Connection = this.conn;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.Int, 4, "ID Number"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 50, "User Name"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50, "Password"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_Number", System.Data.SqlDbType.Int, 4, "ID Number"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE UserID SET [ID Number] = @Param3, [User Name] = @Param4, Password = @Password WHERE ([ID Number] = @Original_ID_Number) AND (Password = @Original_Password OR @Original_Password IS NULL AND Password IS NULL) AND ([User Name] = @Original_User_Name OR @Original_User_Name IS NULL AND [User Name] IS NULL); SELECT [ID Number], [User Name], Password FROM UserID WHERE ([ID Number] = @ID_Number)";
			this.sqlUpdateCommand1.Connection = this.conn;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Param3", System.Data.SqlDbType.Int, 4, "ID Number"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Param4", System.Data.SqlDbType.VarChar, 50, "User Name"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50, "Password"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID_Number", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID Number", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Password", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_User_Name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "User Name", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_Number", System.Data.SqlDbType.Int, 4, "ID Number"));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM UserID WHERE ([ID Number] = @Original_ID_Number) AND (Password = @Ori" +
				"ginal_Password OR @Original_Password IS NULL AND Password IS NULL) AND ([User Na" +
				"me] = @Original_User_Name OR @Original_User_Name IS NULL AND [User Name] IS NULL" +
				")";
			this.sqlDeleteCommand1.Connection = this.conn;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID_Number", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID Number", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Password", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_User_Name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "User Name", System.Data.DataRowVersion.Original, null));
			// 
			// da1
			// 
			this.da1.DeleteCommand = this.sqlDeleteCommand1;
			this.da1.InsertCommand = this.sqlInsertCommand1;
			this.da1.SelectCommand = this.sqlSelectCommand1;
			this.da1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																						  new System.Data.Common.DataTableMapping("Table", "UserID", new System.Data.Common.DataColumnMapping[] {
																																																	new System.Data.Common.DataColumnMapping("ID Number", "ID Number"),
																																																	new System.Data.Common.DataColumnMapping("User Name", "User Name"),
																																																	new System.Data.Common.DataColumnMapping("Password", "Password")})});
			this.da1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(88, 144);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 24);
			this.button3.TabIndex = 6;
			this.button3.Text = "Log Out";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 181);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textPassword);
			this.Controls.Add(this.textUserName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.Form2_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsTable)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[dsTable, "UserID"].Position += 1;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[dsTable, "UserID"].Position -= 1;
		}
		protected override void OnClosed(EventArgs e)
		{
			Application.Exit();
			base.OnClosed (e);
		}

		private void Form2_Load(object sender, System.EventArgs e)
		{
			da1.Fill(dsTable);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Good Bye!", "Signing Out...", MessageBoxButtons.OK, MessageBoxIcon.Information);
			Application.Exit();
		}

	}
}
