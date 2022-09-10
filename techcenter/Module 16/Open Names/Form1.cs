using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace Open_Names
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
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

			XmlDocument doc = new XmlDocument();

			doc.Load("people.xml");
			
			doc.Normalize();	//no validating for you!
			string stuff;
			
			//try
			{
				//get the root element
				XmlElement root = doc.DocumentElement;
				//this is the large element, i.e. persons

				XmlNodeList nodeList = root.GetElementsByTagName("person");

				XmlNode node = nodeList[0];

				XmlElement name = node["name"];
				stuff = name.InnerText.ToString();

			}
			//catch
			{
				//stuff = "Your an idgiot";
			}

			this.label1.Text = stuff;
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
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(80, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 64);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.label1);
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
	}
}
