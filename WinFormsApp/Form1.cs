using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Painters;
using AntSim.Core;

namespace WinFormsApp
{
	public partial class Form1 : Form
	{
		Engine _engine;
		MainPainter _painter;

		public Form1()
		{
			InitializeComponent();
			_engine = new Engine();
			_engine.Init();
			_painter = new MainPainter(_engine, this);
			this.Size = _painter.Bounds.Size;
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			new System.Threading.Thread(() =>
			{
				while (true)
				{
					_engine.Tick();
					SpinWait spin = new SpinWait();
					while (!spin.NextSpinWillYield)
						spin.SpinOnce();
				}
			})
			{ IsBackground = true }
			.Start();
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Refresh();
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			var cell = Calculator.GetCellByPoint(_engine.Field, _painter.Bounds, e.Location);
			if (cell == null || cell.IsObstacle)
				return;
			cell.Food += 1000_000;
			Array.ForEach(cell.Steps, c => c.Food += 1000_000);
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			_painter.Paint(e.Graphics);
		}
	}
}