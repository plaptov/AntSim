using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSim.Core
{
	public class Engine
	{
		public FieldGraph Field { get; private set; }

		public List<AntsColony> Colonies { get; } = new List<AntsColony>();

		const int fieldSize = 500;

		public void Init()
		{
			Field = new FieldGraph();
			Field.GenerateRectangleField(fieldSize, fieldSize);
			Colonies.Add(new AntsColony(Field[Field.Width / 2, Field.Height / 2]));
		}

		public void Tick()
		{
			Field.Tick();
			Colonies.ForEach(c => c.Tick());
		}
	}
}
