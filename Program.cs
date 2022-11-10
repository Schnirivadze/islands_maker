using System;
using System.Windows.Forms;

namespace islands_maker
{
	static class Program
	{
		[STAThread]
		
		static void Main()
		{
			//Неизвестная хуйня
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//Узнать требуемые размеры графического окна
			int width, height;
			Console.WriteLine("Enter width and height of a graphics window in pixels");
			Console.Write("Width: ");  width  = Convert.ToInt32(Console.ReadLine());
			Console.Write("Height: "); height = Convert.ToInt32(Console.ReadLine());

			//Запустить графическое окно с заданными данными
			//Application.Run(new Form1(width,height));
			new Form1(width,height).ShowDialog();
			
		}

	}
}
