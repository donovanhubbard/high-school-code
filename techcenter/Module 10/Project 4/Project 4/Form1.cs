using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Project_4
{

	//Concepts covered			h. use random access to read and write from a file
	//							i. ues a menu dialog and a file dialog
	//What the program does: It can display certain properties of an mp3 file
	//What I learned: I learned how to read binary information


	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelArtist;
		private System.Windows.Forms.Label labelAlbum;
		private System.Windows.Forms.Label labelYear;
		private System.Windows.Forms.Label labelComments;
		private System.Windows.Forms.Label labelGenre;
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.labelArtist = new System.Windows.Forms.Label();
			this.labelAlbum = new System.Windows.Forms.Label();
			this.labelYear = new System.Windows.Forms.Label();
			this.labelComments = new System.Windows.Forms.Label();
			this.labelGenre = new System.Windows.Forms.Label();
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
																					  this.menuItem2});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Open";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// labelTitle
			// 
			this.labelTitle.Location = new System.Drawing.Point(136, 8);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(104, 32);
			this.labelTitle.TabIndex = 0;
			// 
			// labelArtist
			// 
			this.labelArtist.Location = new System.Drawing.Point(136, 48);
			this.labelArtist.Name = "labelArtist";
			this.labelArtist.Size = new System.Drawing.Size(112, 24);
			this.labelArtist.TabIndex = 1;
			this.labelArtist.Text = "label1";
			// 
			// labelAlbum
			// 
			this.labelAlbum.Location = new System.Drawing.Point(144, 80);
			this.labelAlbum.Name = "labelAlbum";
			this.labelAlbum.Size = new System.Drawing.Size(104, 24);
			this.labelAlbum.TabIndex = 2;
			this.labelAlbum.Text = "label2";
			// 
			// labelYear
			// 
			this.labelYear.Location = new System.Drawing.Point(136, 112);
			this.labelYear.Name = "labelYear";
			this.labelYear.Size = new System.Drawing.Size(88, 32);
			this.labelYear.TabIndex = 3;
			this.labelYear.Text = "label3";
			// 
			// labelComments
			// 
			this.labelComments.Location = new System.Drawing.Point(136, 152);
			this.labelComments.Name = "labelComments";
			this.labelComments.Size = new System.Drawing.Size(96, 24);
			this.labelComments.TabIndex = 4;
			this.labelComments.Text = "label1";
			// 
			// labelGenre
			// 
			this.labelGenre.Location = new System.Drawing.Point(136, 192);
			this.labelGenre.Name = "labelGenre";
			this.labelGenre.Size = new System.Drawing.Size(96, 32);
			this.labelGenre.TabIndex = 5;
			this.labelGenre.Text = "label2";
			this.labelGenre.Click += new System.EventHandler(this.labelGenre_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.labelGenre);
			this.Controls.Add(this.labelComments);
			this.Controls.Add(this.labelYear);
			this.Controls.Add(this.labelAlbum);
			this.Controls.Add(this.labelArtist);
			this.Controls.Add(this.labelTitle);
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

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.Filter = "MP3 file | *.mp3";
			openFileDialog1.ShowDialog();

			BinaryReader f = new BinaryReader(new FileStream(openFileDialog1.FileName,FileMode.Open));  // Open the binary file named song.mp3 for reading (FileMode.Open)
						//  open it as a FileStream so that we can move around in the file
						// (random access)
			f.BaseStream.Seek(-125,SeekOrigin.End);        // Seek the end of the file (SeekOrigin.End) and then go back 128 bytes (that's why it's negative 128)
			string title = new String(f.ReadChars(30));            // To hold the next 3 characters of the file in a string
			labelTitle.Text = title;                                   // Should write the word TAG to the screen

			string artist = new String(f.ReadChars(30));            // To hold the next 3 characters of the file in a string
			labelArtist.Text = artist; 

			string album = new String(f.ReadChars(30));            // To hold the next 3 characters of the file in a string
			labelAlbum.Text = album; 

			string year = new String(f.ReadChars(4));            // To hold the next 3 characters of the file in a string
			labelYear.Text = year; 

			string comments = new String(f.ReadChars(30));            // To hold the next 3 characters of the file in a string
			labelComments.Text = comments; 

			string genre = new String(f.ReadChars(1));            // To hold the next 3 characters of the file in a string
			labelGenre.Text = genre; 



			f.Close();                                                        // Close the file so that other programs can use it

		}

		private void labelGenre_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
