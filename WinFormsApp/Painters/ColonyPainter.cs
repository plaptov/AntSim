using AntSim.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Painters
{
	class ColonyPainter
	{
		public static void PaintColony(Graphics gr, FieldGraph field, 
			Rectangle fieldBounds, AntsColony colony)
		{
			var rect = Calculator.CalcCellBounds(field, fieldBounds, colony.HomeCell);
			int w = rect.Width;
			int h = rect.Height;
			rect.Offset(w << 1, h << 1);
			rect.Inflate(w << 2, h << 2);
			var c = Color.Maroon;
			using (var pen = new Pen(c))
				gr.DrawRectangle(pen, rect);
			using (var brush = new SolidBrush(c))
				gr.FillRectangle(brush, rect);
		}
	}
}
