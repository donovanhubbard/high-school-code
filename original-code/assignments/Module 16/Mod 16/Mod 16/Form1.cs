using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Web;
using System.Net;

namespace Mod_16
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lName;
		private System.Windows.Forms.Label lHP;
		private System.Windows.Forms.Label lDamage;
		private System.Windows.Forms.Label lRace;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{

			InitializeComponent();
			
			// Validate the XML file
			XmlValidatingReader reader = new XmlValidatingReader(new XmlTextReader("units.xml"));
			//tell it to validate wit shcema
			reader.ValidationType = ValidationType.Schema;
			//delegate
			reader.ValidationEventHandler += new ValidationEventHandler(ValidateXML);

			//make the actual document
			XmlDocument doc = new XmlDocument();
			//load the xml into the document
			doc.Load(reader);
			//format it right
			doc.Normalize();


		//	try
			{
				//now we get individual elements of the document
				XmlElement root = doc.DocumentElement;

				//this is a list of all the nodes(list where each element of the 
				//list is unit node)
				XmlNodeList nodeList = root.GetElementsByTagName("unit");

				//this is the first node in the document
				XmlNode node = nodeList[0];
				
				//now we make each of the individual elements of the
				//node
				XmlAttribute name = node.Attributes["name"];
				XmlElement race = node["race"];
				XmlElement hp = node["hp"];
				XmlElement damage = node["damage"];
				XmlElement image = node["image"];

				//at this point we have all the info from the first
				//xml node loaded into seperate XmlElement objects
				//all we have to do is display it
				this.lRace.Text = race.InnerText;
				this.lName.Text = name.Value;
				this.lHP.Text += hp.InnerText;
				this.lDamage.Text += damage.InnerText;
				this.pictureBox1.Image = FetchImage(image.InnerText);
			}
			//catch
			{
				//MessageBox.Show("Something wrong happend dingbat");
				//Application.Exit();
			}

			


		}

		public Image FetchImage(string url) 
		{
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
			WebResponse webResponse = webRequest.GetResponse();
			Stream stream = webResponse.GetResponseStream();
			return Bitmap.FromStream(stream);
		}
		public static void ValidateXML(Object sender, ValidationEventArgs e)
		{
			MessageBox.Show("You did something wrong stupid. Now you have to watch some annoying message boxes");
			MessageBox.Show(e.Severity+" Level Warning",e.Message);
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
			this.lName = new System.Windows.Forms.Label();
			this.lHP = new System.Windows.Forms.Label();
			this.lDamage = new System.Windows.Forms.Label();
			this.lRace = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// lName
			// 
			this.lName.Location = new System.Drawing.Point(104, 16);
			this.lName.Name = "lName";
			this.lName.Size = new System.Drawing.Size(80, 32);
			this.lName.TabIndex = 0;
			this.lName.Text = "Name";
			// 
			// lHP
			// 
			this.lHP.Location = new System.Drawing.Point(112, 200);
			this.lHP.Name = "lHP";
			this.lHP.Size = new System.Drawing.Size(176, 16);
			this.lHP.TabIndex = 1;
			this.lHP.Text = "HP: ";
			// 
			// lDamage
			// 
			this.lDamage.Location = new System.Drawing.Point(112, 224);
			this.lDamage.Name = "lDamage";
			this.lDamage.Size = new System.Drawing.Size(168, 16);
			this.lDamage.TabIndex = 2;
			this.lDamage.Text = "Damage: ";
			// 
			// lRace
			// 
			this.lRace.Location = new System.Drawing.Point(112, 176);
			this.lRace.Name = "lRace";
			this.lRace.Size = new System.Drawing.Size(96, 16);
			this.lRace.TabIndex = 3;
			this.lRace.Text = "Race";
			this.lRace.Click += new System.EventHandler(this.label4_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(80, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(144, 120);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 261);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lRace);
			this.Controls.Add(this.lDamage);
			this.Controls.Add(this.lHP);
			this.Controls.Add(this.lName);
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

		private void label4_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
