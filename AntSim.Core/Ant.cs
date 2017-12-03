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
			CurrentCell.Ants.Remove(this);
			Colony.Dead(this);
		}

		public AntsColony Colony { get; private set; }

		private Cell _currentCell;
		public Cell CurrentCell
		{
			get => _currentCell;
			set
			{
				if (IsReturning && CurrentPath.Count > 1 && CurrentPath.Peek() == value)
					CurrentPath.Pop();
				if (!IsReturning)
					CurrentPath.Push(value);
				PrevCell = _currentCell;
				_currentCell = value;
				PrevCell?.Ants.Remove(this);
				_currentCell.Ants.Add(this);
			}
		}

		public Cell PrevCell { get; set; }

		protected Stack<Cell> CurrentPath { get; private set; } = new Stack<Cell>();

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
			if (IsReturning && cell != CurrentPath.Peek())
				return false;
			return true;
		}

		public void Move()
		{
			if (CurrentCell == Colony.HomeCell)
				IsReturning = IsGoodReturning = false;
			if (IsReturning && CurrentCell == CurrentPath.Peek())
				CurrentPath.Pop();
			var steps = CurrentCell.Steps.Where(CanMoveTo).ToArray();
			if (steps.Length == 0)
			{
				if (!IsReturning)
				{
					IsReturning = true;
				}
				else
					Die();
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

		protected int PheromoneCountToPut() =>
			CurrentCell.DistanceTo(Colony.HomeCell) * 10;

		public void CheckCurrentCell()
		{
			if (IsGoodReturning)
			{
				CurrentCell.Pheromones += PheromoneCountToPut();
				return;
			}
			if (CurrentCell.Food > 0)
			{
				CurrentCell.Food--;
				CurrentCell.Pheromones += PheromoneCountToPut();
				IsReturning = IsGoodReturning = true;
			}
		}
	}
}
