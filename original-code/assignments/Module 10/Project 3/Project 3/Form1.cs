using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Project_3
{

	//Concepts Covered		f. write text to a file
	//						g. Read text from a file
	//What the program does: It can open text files and create new ones
	//What I learned: I have a better understanding on how to use StreamReader and Writer

	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.textBox = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Save";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Open";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// textBox
			// 
			this.textBox.Location = new System.Drawing.Point(96, 112);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(120, 80);
			this.textBox.TabIndex = 0;
			this.textBox.Text = "";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.textBox);
			this.Menu = this.mainMenu1;
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

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			try
			{
				openFileDialog1.Filter = "Text Files | *.txt";
				openFileDialog1.ShowDialog();
				StreamReader input = new StreamReader(openFileDialog1.FileName);
				string fileText;
				fileText = input.ReadLine();

				while(fileText != null)
				{
					textBox.Text += fileText;
					fileText = input.ReadLine();
				
				}
				input.Close();
			}

			catch(System.ArgumentException)
			{
				MessageBox.Show("File does not exist", "Error");
			}



		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			try
			{
				saveFileDialog1.Filter = "Text Files | *.txt";
				saveFileDialog1.ShowDialog();

				StreamWriter output = new StreamWriter(saveFileDialog1.FileName);    // Attempt to open the file named myFile.txt
				output.WriteLine(textBox.Text);                                  // Write a line of text to the file
				output.Close();                                                             // Close the file so that other programs can use it
			}
		
			catch(System.UnauthorizedAccessException)
			{
				MessageBox.Show("Cannont save, file is read-only","Error, you retard");
			}


		}
	}
}
