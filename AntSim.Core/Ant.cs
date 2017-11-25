using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntSim.Core
{
	public class Ant
	{
		public Ant(AntsColony colony)
		{
			Colony = colony;
		}

		public AntsColony Colony { get; private set; }

		private Cell _currentCell;
		public Cell CurrentCell
		{
			get => _currentCell;
			set
			{
				if (IsReturning && CurrentPath.Count > 1 && CurrentPath[CurrentPath.Count - 2] == value)
					CurrentPath.RemoveAt(CurrentPath.Count - 1);
				if (!IsReturning)
					CurrentPath.Add(value);
				PrevCell = _currentCell;
				_currentCell = value;
			}
		}

		public Cell PrevCell { get; set; }

		protected List<Cell> CurrentPath { get; private set; } = new List<Cell>();

		protected bool IsReturning { get; set; }

		protected bool CanMoveTo(Cell cell)
		{
			if (cell.IsObstacle)
				return false;
			if (cell == CurrentCell)
				return false;
			if (!IsReturning && CurrentPath.Contains(cell))
				return false;
			return true;
		}
	}
}
