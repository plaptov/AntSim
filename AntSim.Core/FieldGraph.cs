using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

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
			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
				{
					var curCell = _cells[x, y];
					var list = new List<Cell>();
					for (int i = Math.Max(x - 1, 0); i < Math.Min(x + 2, width); i++)
						for (int j = Math.Max(y - 1, 0); j < Math.Min(y + 2, height); j++)
						{
							if (i == x || j == y)
								continue;
							list.Add(_cells[i, j]);
						}
					curCell.Steps = list.ToArray();
				}
		}

		public int Width => _cells.GetLength(0);

		public int Height => _cells.GetLength(1);

		
		public Cell this[int x, int y]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => _cells[x, y];
		}

		public void Tick()
		{
			int w = Width;
			int h = Height;
			for (int i = 0; i < w; i++)
			{
				for (int j = 0; j < h; j++)
				{
					if (_cells[i,j].Pheromones > 0)
					_cells[i, j].Pheromones--;
				}
			}
		}
	}
}
