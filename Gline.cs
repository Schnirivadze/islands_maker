using System;

namespace islands_maker
{
	public class Gline
	{
		public int type;
		public int y;
		public int x_start;
		public int x_end;

		///<param name="type">Тип линии(тип испльзуемого ландшавтра)</param>
		///<param name="x_start">Начало линии</param>
		///<param name="x_end">Конец линии</param>
		///<param name="y">Line level</param>
		public Gline(int type, int x_start, int x_end, int y)
		{


			this.y = y;
			this.type = type;
			this.x_start = x_start;
			this.x_end = x_end;
		}
		public void WriteOutInfo()
		{
			///<summary>Выводиит всю информацию в консоль</summary>
			Console.WriteLine("-------------------" +
				"\nType: " + type +
				"\nX Start: " + x_start +
				"\nX End: " + x_end +
				"\nY: " + y
				+ "\n-------------------");
		}
	}
}
