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

		public int Attraction => 10 + Pheromones + Food;

		public override string ToString() =>
			$"X={X}\tY={Y}";

		public int DistanceTo(Cell cell) =>
			Convert.ToInt32(Math.Sqrt(Math.Pow(X - cell.X, 2) + Math.Pow(Y - cell.Y, 2)));
	}
}
