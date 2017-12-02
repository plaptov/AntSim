using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AntSim.Core;

namespace WinFormsApp.Painters
{
	class CellPainter
	{
		public static void PaintField(Graphics gr, FieldGraph field, Rectangle fieldBounds)
		{
			var w = field.Width;
			var h = field.Height;
			for (int i = 0; i < w; i++)
			{
				for (int j = 0; j < h; j++)
				{
					PaintCell(gr, field, fieldBounds, field[i, j]);
				}
			}
		}

		static Color emptyColor = Color.White;
		static Pen emptyPen = new Pen(emptyColor);
		static Brush emptyBrush = new SolidBrush(emptyColor);

		static Color obstacleColor = Color.Black;
		static Pen obstaclePen = new Pen(obstacleColor);
		static Brush obstacleBrush = new SolidBrush(obstacleColor);

		static Color foodColor = Color.DarkGreen;
		static Pen foodPen = new Pen(foodColor);
		static Brush foodBrush = new SolidBrush(foodColor);

		static Color antsColor = Color.Blue;
		static Pen antsPen = new Pen(antsColor);
		static Brush antsBrush = new SolidBrush(antsColor);

		static Color pheromonesColor = Color.LightYellow;
		static Pen pheromonesPen = new Pen(pheromonesColor);
		static Brush pheromonesBrush = new SolidBrush(pheromonesColor);

		public static void PaintCell(Graphics gr, FieldGraph field, Rectangle fieldBounds, Cell cell)
		{
			var rect = Calculator.CalcCellBounds(field, fieldBounds, cell);
			var pen = emptyPen;
			var brush = emptyBrush;
			if (cell.IsObstacle)
			{
				pen = obstaclePen;
				brush = obstacleBrush;
			}
			else if (cell.Food > 0)
			{
				pen = foodPen;
				brush = foodBrush;
			}
			else if (cell.Ants.Count > 0)
			{
				pen = antsPen;
				brush = antsBrush;
			}
			else if (cell.Pheromones > 0)
			{
				pen = pheromonesPen;
				brush = pheromonesBrush;
			}
			gr.DrawRectangle(pen, rect);
			//gr.FillRectangle(brush, rect);
			//gr.DrawLine(pen, rect.Location, rect.Location);
		}
	}
}
