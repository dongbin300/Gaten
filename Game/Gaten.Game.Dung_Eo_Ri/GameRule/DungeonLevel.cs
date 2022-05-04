using System;
using System.Collections.Generic;
using System.Text;

namespace Gaten.Game.Dung_Eo_Ri.GameRule
{
	public class DungeonLevel
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public int StairX { get; set; }
		public int StairY { get; set; }

		public DungeonLevel(int width, int height, int stairX, int stairY)
		{
			Width = width;
			Height = height;
			StairX = stairX;
			StairY = stairY;
		}
	}
}
