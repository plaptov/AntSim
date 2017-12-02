using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AntSim.Core;
using System.Windows.Forms;

namespace WinFormsApp.Painters
{
	class Calculator
	{
		public static Rectangle CalcFieldBounds(FieldGraph field, Control parentControl)
		{
			return new Rectangle(parentControl.ClientRectangle.Location, new Size(field.Width, field.Height));
		}

		public static Rectangle CalcCellBounds(FieldGraph field, Rectangle fieldBounds, Cell cell)
		{
			return new Rectangle(fieldBounds.X + cell.X, fieldBounds.Y + cell.Y, 1, 1);
		}

		public static Cell GetCellByPoint(FieldGraph field, Rectangle fieldBounds, Point point)
		{
			int x = point.X - fieldBounds.X;
			int y = point.Y - fieldBounds.Y;
			if (x < 0 || y < 0)
				return null;
			if (x >= field.Width || y >= field.Height)
				return null;
			return field[x, y];
		}
	}
}
