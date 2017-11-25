using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSim.Core
{
	public class Cell
	{
		public Cell(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; private set; }

		public int Y { get; private set; }

		public List<Ant> Ants { get; private set; } = new List<Ant>();

		public int Pheromones { get; set; }

		public int Food { get; set; }

		public bool IsObstacle { get; set; }

		public Cell[] Steps { get; internal set; }
	}
}
