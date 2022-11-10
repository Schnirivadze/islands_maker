using System;
using System.Drawing;
using System.Windows.Forms;

namespace islands_maker
{
	public partial class Form1 : Form
	{
		int panelwidth, panelheight;
		Graphics canvas;
		Listanez World;
		console_addition console;
		public Form1(int width,int height)
		{
			panelwidth = width;
			panelheight = height;
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			panel1.Size = new Size(panelwidth,panelheight);
			this.Size=new Size(panelwidth, panelheight+35);
			button1.Size = new Size(panelwidth, 35);
			button1.Location = new Point(0,panelheight-35);
			canvas = panel1.CreateGraphics();
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			World = new Listanez(panelwidth,panelheight,canvas);
			console = new console_addition(World);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Console.Write(">");
			string command = console.readln();
			console.parcecommand(command);
		}


	}
}
