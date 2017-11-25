using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSim.Core
{
	public class AntsColony
	{
		public AntsColony(Cell homeCell)
		{
			HomeCell = homeCell;
		}

		public Cell HomeCell { get; private set; }
		public Ant MakeAnt() => new Ant(this) { CurrentCell = HomeCell };
	}
}
