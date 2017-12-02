using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSim.Core
{
	public class AntsColony
	{
		private List<Ant> _ants = new List<Ant>();

		public AntsColony(Cell homeCell)
		{
			HomeCell = homeCell;
		}

		public int MaxCount { get; set; } = 100;

		public Cell HomeCell { get; private set; }
		public Ant MakeAnt() => Add(new Ant(this));

		public Ant Add(Ant ant)
		{
			_ants.Add(ant);
			return ant;
		}

		internal void Dead(Ant ant)
		{
			_ants.Remove(ant);
		}

		public void Tick()
		{
			if (_ants.Count < MaxCount)
				MakeAnt();
			_ants.ForEach(a => a.Move());
		}

	}
}
