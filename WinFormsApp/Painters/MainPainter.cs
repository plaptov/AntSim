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

		public Rectangle Bounds => _fieldBounds;

		public MainPainter(Engine engine, Control control)
		{
			_engine = engine;
			_fieldBounds = Calculator.CalcFieldBounds(_engine.Field, control);
		}

		public void Paint(Graphics gr)
		{
			CellPainter.PaintField(gr, _engine.Field, _fieldBounds);
			foreach (var c in _engine.Colonies)
			{
				ColonyPainter.PaintColony(gr, _engine.Field, _fieldBounds, c);
			}
		}
	}
}
