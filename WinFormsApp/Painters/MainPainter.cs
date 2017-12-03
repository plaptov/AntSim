using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using AntSim.Core;

namespace WinFormsApp.Painters
{
	public class MainPainter
	{
		Engine _engine;
		Rectangle _fieldBounds;

		static Color emptyColor = Color.White;
		static Pen emptyPen = new Pen(emptyColor);
		static Brush emptyBrush = new SolidBrush(emptyColor);

		public Rectangle Bounds => _fieldBounds;

		public MainPainter(Engine engine, Control control)
		{
			_engine = engine;
			_fieldBounds = Calculator.CalcFieldBounds(_engine.Field, control);
		}

		public void Paint(Graphics gr)
		{
			gr.DrawRectangle(emptyPen, _fieldBounds);
			gr.FillRectangle(emptyBrush, _fieldBounds);
			CellPainter.PaintField(gr, _engine.Field, _fieldBounds);
			foreach (var c in _engine.Colonies)
			{
				ColonyPainter.PaintColony(gr, _engine.Field, _fieldBounds, c);
			}
		}
	}
}
