using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntSim.Core
{
	public class Ant
	{
		protected static readonly Random rnd = new Random();

		public Ant(AntsColony colony)
		{
			Colony = colony;
			CurrentCell = colony.HomeCell;
		}

		public void Die()
		{
			Colony.Dead(this);
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
				PrevCell?.Ants.Remove(this);
				_currentCell.Ants.Add(this);
			}
		}

		public Cell PrevCell { get; set; }

		protected List<Cell> CurrentPath { get; private set; } = new List<Cell>();

		protected bool IsReturning { get; set; }

		protected bool IsGoodReturning { get; set; }

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

		public void Move()
		{
			if (CurrentCell == Colony.HomeCell)
				IsReturning = IsGoodReturning = false;
			var steps = CurrentCell.Steps.Where(CanMoveTo).ToArray();
			if (steps.Length == 0)
			{
				if (!IsReturning)
					IsReturning = true;
				else
					;
				return;
			}
			int allSum = steps.Sum(c => c.Attraction);
			int val = rnd.Next(allSum);
			foreach (var item in steps)
			{
				if (val <= item.Attraction)
				{
					CurrentCell = item;
					break;
				}
				val -= item.Attraction;
			}
		}

		public void CheckCurrentCell()
		{
			if (IsGoodReturning)
			{
				CurrentCell.Pheromones++;
				return;
			}
			if (CurrentCell.Food > 0)
			{
				CurrentCell.Food--;
				CurrentCell.Pheromones += 100;
				IsReturning = IsGoodReturning = true;
			}
		}
	}
}
