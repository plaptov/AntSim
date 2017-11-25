using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSim.Core
{
	public class FieldGraph
	{
		private Cell[,] _cells;

		public void GenerateRectangleField(int width, int height)
		{
			_cells = new Cell[width, height];
			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
					_cells[x, y] = new Cell(x, y);

		}
	}
}
