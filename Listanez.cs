using System;
using System.Drawing;
namespace islands_maker
{
	public class Listanez
	{
		int[,] world_terrain;
		int world_width = -1;
		int world_height = -1;
		Graphics graphics;


		string[] surface_types = new string[] { "WATER_OCEAN", "WATER_LAKE", "LAND_GRASS", "LAND_SAND" };
		Color[] surface_colors = new Color[] { Color.Blue, Color.LightBlue, Color.Green, Color.Yellow };
		//----------------------------------------------ФУНКЦИИ/FUNCTIONS---------------------------------------------
		public Listanez(int world_width, int world_height, Graphics graphics)
		{///<summary>Конструктор класса листанец</summary>
			this.world_width = world_width;
			this.world_height = world_height;
			this.world_terrain = new int[world_height, world_width];
			this.graphics = graphics;
			Console.WriteLine(world_terrain.Length);
		}
		//-------------------------------------------ГРАФИКА/GRAPHICS-------------------------------------------------
		public void DrawPoint(Pen pixelType, int x, int y)
		{///<summary>Нарисовать точку размером в 1 пиксель</summary>
			graphics.DrawLine(pixelType, x, y, x + 1, y + 1);
		}
		public void Drawline(Pen pixelType, int x_start, int x_end, int y)
		{///<summary>Нарисовать линию</summary>
			graphics.DrawLine(pixelType, x_start, y, x_end, y);
		}

		public void UpdateCanvas(Gline[] world_lines)
		{///<summary>Обновить холст</summary>
			int i = 0;
			while(world_lines[i]!=null)
			{
				Drawline(new Pen(GetColor(world_lines[i].type)),
				world_lines[i].x_start,
				world_lines[i].x_end,
				world_lines[i].y);
				i++;
			}
		}
		//-------------------------------------------ГЕТЕРЫ/GETTERS---------------------------------------------------
		public int GetTerrainType(string SearchText)
		{///<summary>Получить тип ландшавта во входному названию ландшафта</summary>
			return Array.IndexOf(surface_types, SearchText);
		}
		public Color GetColor(int SearchNum)
		{///<summary>Получить цвет ландшавта во входному тиу ландшафта</summary>
			return surface_colors[SearchNum];
		}

		//-------------------------------------------ПАРСЕРЫ/PARCERS--------------------------------------------------
		public Gline[] ParceGraphics()
		{
			///<summary>Переводит массив из точек в массив из линий для большей скорости</summary>
			Gline[] parced_world_terrain = new Gline[world_width * world_height];
			int added_lines = 0;
			for (int y = 0; y < world_height; y++)
			{
				int right_now_terrain = -1;
				for (int x = 0; x < world_width; x++)
				{
					/*если тип ландшавта которы небыл предыдущим то создать новую линию, если нет то увеличить старую*/
					if (world_terrain[y, x] != right_now_terrain)
					{
						parced_world_terrain[added_lines] = new Gline(world_terrain[x, y], x, x, y);
						added_lines++;
					}
					else
					{
						parced_world_terrain[added_lines-1].x_end += 1;
					}
					right_now_terrain = world_terrain[y, x];
				}

			}
			return parced_world_terrain;
		}
		//-------------------------------------------ОСТАЛЬНОЕ/OTHER--------------------------------------------------
		public void CreateOcean()
		{///<summary>Создает океан на всех уровнях(пока только на главном уровне)</summary>
			for (int y = 0; y < world_height; y++)
			{
				for (int x = 0; x < world_width; x++)
				{
					world_terrain[y, x] = GetTerrainType("WATER_OCEAN");
				}
			}
		}

	}
}
