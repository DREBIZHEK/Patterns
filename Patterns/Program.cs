using Abstract_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Patterns
{
	class Program
	{
		static void Main(string[] args)
		{
			var FastFactory = new FastSpaceshipFactory();
			var HevyFactory = new HevySpaceshipFactory();

			var FastBattle = FastFactory.CrateBattleSpaceship();
			var FastPeaceful = FastFactory.CreatePeacefulSpaceship();
			var HevyBattle = HevyFactory.CrateBattleSpaceship();
			var HevyPeaceful = HevyFactory.CreatePeacefulSpaceship();

			FastBattle.Shoot();
			FastPeaceful.Explore();
			HevyBattle.Shoot();
			HevyPeaceful.Explore();
		}
	}
}
