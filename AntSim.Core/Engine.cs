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

		public void Init()
		{
			Field = new FieldGraph();
			Field.GenerateRectangleField(400, 400);
			Colonies.Add(new AntsColony(Field[10, 10]));
		}

		public void Tick()
		{
			Field.Tick();
			Colonies.ForEach(c => c.Tick());
		}
	}
}
