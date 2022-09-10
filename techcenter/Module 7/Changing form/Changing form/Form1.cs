using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Changing_form
{


	//Concepts Covered: f:Creating and using a custom delegate
	//					g: Using the standard windows controls
	//What the program does: It has all the standard windows controls which
				//alter various atrributes of the form.
	//What I learned: I now have a great understanding of how controls can be used
	//for various jobs. They can change just about anything.

	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;

		string color;
		string text;
		bool dispText = false;
		bool vanilla = false;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkFlag;
		private System.Windows.Forms.Button refresh;
		private System.Windows.Forms.CheckBox checkBackground;
		private System.Windows.Forms.ComboBox comboBack;
		private System.Windows.Forms.Label labelBack;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.RadioButton radioBrazil;
		private System.Windows.Forms.RadioButton radioSweden;
		private System.Windows.Forms.RadioButton radioCanada;
		private System.Windows.Forms.Label labelFlag;
		private System.Windows.Forms.Button buttonFlag;
		private System.Windows.Forms.CheckBox checkText;
		private System.Windows.Forms.TextBox textText;
		private System.Windows.Forms.Button buttonText;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.ListBox listIceCream;
		private System.Windows.Forms.CheckBox checkIceCream;
		private System.Windows.Forms.Label labelIceCream;
		private System.Windows.Forms.Label labelIceCreamDesc;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.comboBack = new System.Windows.Forms.ComboBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.radioBrazil = new System.Windows.Forms.RadioButton();
			this.radioSweden = new System.Windows.Forms.RadioButton();
			this.radioCanada = new System.Windows.Forms.RadioButton();
			this.labelBack = new System.Windows.Forms.Label();
			this.buttonBack = new System.Windows.Forms.Button();
			this.labelFlag = new System.Windows.Forms.Label();
			this.buttonFlag = new System.Windows.Forms.Button();
			this.textText = new System.Windows.Forms.TextBox();
			this.buttonText = new System.Windows.Forms.Button();
			this.labelText = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.checkFlag = new System.Windows.Forms.CheckBox();
			this.checkBackground = new System.Windows.Forms.CheckBox();
			this.checkText = new System.Windows.Forms.CheckBox();
			this.checkIceCream = new System.Windows.Forms.CheckBox();
			this.refresh = new System.Windows.Forms.Button();
			this.listIceCream = new System.Windows.Forms.ListBox();
			this.labelIceCreamDesc = new System.Windows.Forms.Label();
			this.labelIceCream = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// comboBack
			// 
			this.comboBack.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.comboBack.Items.AddRange(new object[] {
														   "Red",
														   "Yellow",
														   "Blue",
														   "Gainsboro",
														   "Azure",
														   "The great big book of everything"});
			this.comboBack.Location = new System.Drawing.Point(16, 136);
			this.comboBack.Name = "comboBack";
			this.comboBack.Size = new System.Drawing.Size(128, 21);
			this.comboBack.TabIndex = 0;
			this.comboBack.Text = "Background color";
			this.comboBack.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(208, 120);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// radioBrazil
			// 
			this.radioBrazil.Location = new System.Drawing.Point(168, 176);
			this.radioBrazil.Name = "radioBrazil";
			this.radioBrazil.TabIndex = 2;
			this.radioBrazil.Text = "Brazil";
			this.radioBrazil.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioSweden
			// 
			this.radioSweden.Location = new System.Drawing.Point(168, 208);
			this.radioSweden.Name = "radioSweden";
			this.radioSweden.TabIndex = 3;
			this.radioSweden.Text = "Sweden";
			this.radioSweden.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioCanada
			// 
			this.radioCanada.Location = new System.Drawing.Point(176, 240);
			this.radioCanada.Name = "radioCanada";
			this.radioCanada.Size = new System.Drawing.Size(96, 16);
			this.radioCanada.TabIndex = 4;
			this.radioCanada.Text = "Canada";
			// 
			// labelBack
			// 
			this.labelBack.Location = new System.Drawing.Point(24, 88);
			this.labelBack.Name = "labelBack";
			this.labelBack.Size = new System.Drawing.Size(120, 32);
			this.labelBack.TabIndex = 5;
			this.labelBack.Text = "Select the background color for this form.";
			// 
			// buttonBack
			// 
			this.buttonBack.Location = new System.Drawing.Point(32, 168);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(96, 24);
			this.buttonBack.TabIndex = 6;
			this.buttonBack.Text = "Change!";
			this.buttonBack.Click += new System.EventHandler(this.button1_Click);
			// 
			// labelFlag
			// 
			this.labelFlag.Location = new System.Drawing.Point(176, 152);
			this.labelFlag.Name = "labelFlag";
			this.labelFlag.Size = new System.Drawing.Size(72, 16);
			this.labelFlag.TabIndex = 7;
			this.labelFlag.Text = "Select Flag";
			this.labelFlag.Click += new System.EventHandler(this.label2_Click);
			// 
			// buttonFlag
			// 
			this.buttonFlag.Location = new System.Drawing.Point(176, 272);
			this.buttonFlag.Name = "buttonFlag";
			this.buttonFlag.Size = new System.Drawing.Size(104, 24);
			this.buttonFlag.TabIndex = 8;
			this.buttonFlag.Text = "Change!";
			this.buttonFlag.Click += new System.EventHandler(this.button2_Click);
			// 
			// textText
			// 
			this.textText.Location = new System.Drawing.Point(24, 272);
			this.textText.Name = "textText";
			this.textText.Size = new System.Drawing.Size(120, 20);
			this.textText.TabIndex = 9;
			this.textText.Text = "(Type in your message)";
			// 
			// buttonText
			// 
			this.buttonText.Location = new System.Drawing.Point(32, 304);
			this.buttonText.Name = "buttonText";
			this.buttonText.Size = new System.Drawing.Size(88, 24);
			this.buttonText.TabIndex = 10;
			this.buttonText.Text = "Display!";
			this.buttonText.Click += new System.EventHandler(this.button3_Click);
			// 
			// labelText
			// 
			this.labelText.Location = new System.Drawing.Point(16, 232);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(136, 24);
			this.labelText.TabIndex = 11;
			this.labelText.Text = "Pick a message to display";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(336, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 40);
			this.label4.TabIndex = 12;
			this.label4.Text = "Display the following";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// checkFlag
			// 
			this.checkFlag.Checked = true;
			this.checkFlag.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkFlag.Location = new System.Drawing.Point(328, 168);
			this.checkFlag.Name = "checkFlag";
			this.checkFlag.Size = new System.Drawing.Size(80, 16);
			this.checkFlag.TabIndex = 13;
			this.checkFlag.Text = "Flag";
			this.checkFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkFlag.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBackground
			// 
			this.checkBackground.Checked = true;
			this.checkBackground.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBackground.Location = new System.Drawing.Point(328, 184);
			this.checkBackground.Name = "checkBackground";
			this.checkBackground.Size = new System.Drawing.Size(88, 32);
			this.checkBackground.TabIndex = 14;
			this.checkBackground.Text = "Background can change";
			this.checkBackground.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// checkText
			// 
			this.checkText.Checked = true;
			this.checkText.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkText.Location = new System.Drawing.Point(328, 216);
			this.checkText.Name = "checkText";
			this.checkText.Size = new System.Drawing.Size(88, 24);
			this.checkText.TabIndex = 15;
			this.checkText.Text = "Display Text";
			// 
			// checkIceCream
			// 
			this.checkIceCream.Checked = true;
			this.checkIceCream.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkIceCream.Location = new System.Drawing.Point(328, 248);
			this.checkIceCream.Name = "checkIceCream";
			this.checkIceCream.Size = new System.Drawing.Size(80, 24);
			this.checkIceCream.TabIndex = 16;
			this.checkIceCream.Text = "Display Ice Cream";
			this.checkIceCream.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
			// 
			// refresh
			// 
			this.refresh.Location = new System.Drawing.Point(328, 280);
			this.refresh.Name = "refresh";
			this.refresh.Size = new System.Drawing.Size(72, 24);
			this.refresh.TabIndex = 17;
			this.refresh.Text = "Refresh";
			this.refresh.Click += new System.EventHandler(this.refresh_Click);
			// 
			// listIceCream
			// 
			this.listIceCream.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listIceCream.Items.AddRange(new object[] {
															  "Vanilla",
															  "Chocolate",
															  "Strawberry",
															  "Playdough",
															  "Dennis"});
			this.listIceCream.Location = new System.Drawing.Point(192, 32);
			this.listIceCream.Name = "listIceCream";
			this.listIceCream.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listIceCream.Size = new System.Drawing.Size(64, 69);
			this.listIceCream.TabIndex = 18;
			this.listIceCream.SelectedValueChanged += new System.EventHandler(this.listIceCream_SelectedValueChanged);
			this.listIceCream.SelectedIndexChanged += new System.EventHandler(this.listIceCream_SelectedIndexChanged);
			// 
			// labelIceCreamDesc
			// 
			this.labelIceCreamDesc.Location = new System.Drawing.Point(192, 0);
			this.labelIceCreamDesc.Name = "labelIceCreamDesc";
			this.labelIceCreamDesc.Size = new System.Drawing.Size(104, 32);
			this.labelIceCreamDesc.TabIndex = 19;
			this.labelIceCreamDesc.Text = "What Ice cream flavors do you like?";
			// 
			// labelIceCream
			// 
			this.labelIceCream.Location = new System.Drawing.Point(312, 32);
			this.labelIceCream.Name = "labelIceCream";
			this.labelIceCream.Size = new System.Drawing.Size(136, 40);
			this.labelIceCream.TabIndex = 20;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 341);
			this.Controls.Add(this.labelIceCream);
			this.Controls.Add(this.labelIceCreamDesc);
			this.Controls.Add(this.listIceCream);
			this.Controls.Add(this.refresh);
			this.Controls.Add(this.checkIceCream);
			this.Controls.Add(this.checkText);
			this.Controls.Add(this.checkBackground);
			this.Controls.Add(this.checkFlag);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.buttonText);
			this.Controls.Add(this.textText);
			this.Controls.Add(this.buttonFlag);
			this.Controls.Add(this.labelFlag);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.labelBack);
			this.Controls.Add(this.radioCanada);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.comboBack);
			this.Controls.Add(this.radioSweden);
			this.Controls.Add(this.radioBrazil);
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

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(comboBack.SelectedItem.ToString() == "Red")
				this.BackColor = Color.Red;
			else if(comboBack.SelectedItem.ToString() == "Azure")
				this.BackColor = Color.Azure;
			else if(comboBack.SelectedItem.ToString() == "Yellow")
				this.BackColor = Color.Yellow;
			else if(comboBack.SelectedItem.ToString() == "Gainsboro")
				this.BackColor = Color.Gainsboro;
			else if(comboBack.SelectedItem.ToString() == "Blue")
				this.BackColor = Color.Blue;
				
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(radioBrazil.Checked == true)
				pictureBox1.Image = Image.FromFile(@"C:\Program Files\Microsoft Visual Studio .NET 2003\Common7\Graphics\icons\Flags\FLGBRAZL.ico");
			else if(radioSweden.Checked == true)
				pictureBox1.Image = Image.FromFile(@"C:\Program Files\Microsoft Visual Studio .NET 2003\Common7\Graphics\icons\Flags\FLGSWED.ico");
			else if(radioCanada.Checked == true)
				pictureBox1.Image = Image.FromFile(@"C:\Program Files\Microsoft Visual Studio .NET 2003\Common7\Graphics\icons\Flags\FLGCAN.ico");

		
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("I don't like it when you click there", "Error: (not really)");
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			if(checkText.Checked == true)
			{
				text = textText.Text;
				dispText = true;
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			Font myFont = new Font(FontFamily.GenericSerif, 12);
			
			if(checkText.Checked == true)
			{
				g.DrawString(text, myFont, Brushes.Black, 15, 15);
			}

			base.OnPaint (e);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown (e);
		}


		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void refresh_Click(object sender, System.EventArgs e)
		{
			if(checkFlag.Checked == false)
			{
				pictureBox1.Hide();
				radioBrazil.Hide();
				radioCanada.Hide();
				radioSweden.Hide();
				labelFlag.Hide();
				buttonFlag.Hide();
			}
			else
			{
				pictureBox1.Show();
				radioBrazil.Show();
				radioCanada.Show();
				radioSweden.Show();
				labelFlag.Show();
				buttonFlag.Show();
			}
			if(checkBackground.Checked == false)
			{
				labelBack.Hide();
				comboBack.Hide();
				buttonBack.Hide();
			}
			else
			{
				labelBack.Show();
				comboBack.Show();
				buttonBack.Show();
			}

			if(checkText.Checked == false)
			{
				labelText.Hide();
				textText.Hide();
				buttonText.Hide();
			}
			else
			{
				labelText.Show();
				textText.Show();
				buttonText.Show();
			}

			if(checkIceCream.Checked == false)
			{
				labelIceCream.Hide();
				listIceCream.Hide();
				labelIceCreamDesc.Hide();
			}

			else
			{
					labelIceCream.Show();
					listIceCream.Show();
					labelIceCreamDesc.Show();
				
			}

			Invalidate();

		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void checkBox4_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			
		}

		private void listIceCream_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		private void label4_Click(object sender, System.EventArgs e)
		{
		
		}

		private void listIceCream_SelectedValueChanged(object sender, EventArgs e)
		{
			labelIceCream.Text = "";
			for(int i = 0; i<listIceCream.SelectedItems.Count; i++)
			{
				labelIceCream.Text += listIceCream.SelectedItems[i].ToString() + " ";
			}
		}
	}
}
