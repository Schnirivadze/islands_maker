using System;

namespace islands_maker
{
	class console_addition
	{
		Listanez lisDraw;
		public console_addition(Listanez lisDraw)
		{
			this.lisDraw = lisDraw;
		}
		public void writeError(string text)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(text);
			Console.ForegroundColor = ConsoleColor.White;
		}
		public void writeWarning(string text)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(text);
			Console.ForegroundColor = ConsoleColor.White;
		}
		public void writeSucsess(string text)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(text);
			Console.ForegroundColor = ConsoleColor.White;
		}
		public void writeColor(string text,ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			Console.ForegroundColor = ConsoleColor.White;
		}
		public void writeln(string text)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(text);
		}

		public void parcecommand(string command)
		{
			string[] parcedcommand = new string[10];
			//Перенести строку в массив исползуя пробелы как разделители
			int pos=0;
			for (int i = 0; i < command.Length; i++)
			{
				if (!command[i].Equals(" ")){parcedcommand[pos] += command[i];}else{pos++;}
			}
			//выполняем комманду
			switch (parcedcommand[0])
			{
				case "createocean":
					lisDraw.CreateOcean();
					Gline[] tempLine=lisDraw.ParceGraphics();
					lisDraw.UpdateCanvas(tempLine);
					break;

				default:
					writeError("There are no such function, try 'help <function_name>'");
					break;
			}
		}

		public void write(string text)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(text);
		}
		public string readln()
		{
			return Console.ReadLine();
		}
	}
}
