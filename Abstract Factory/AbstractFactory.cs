using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public interface ISpaceshipFactory
    {
        IBattleSpaceship CrateBattleSpaceship();
        IPeacefulSpaceship CreatePeacefulSpaceship();
    }
    public interface IBattleSpaceship
    {
		void Shoot();
    }
    public interface IPeacefulSpaceship
    {
		void Explore();

	}
	public class FastSpaceshipFactory : ISpaceshipFactory
	{
		public IBattleSpaceship CrateBattleSpaceship()
		{
			return new FastBattleSpaceship();
		}

		public IPeacefulSpaceship CreatePeacefulSpaceship()
		{
			return new FastPeacefulSpaceship();
		}
	}
	public class HevySpaceshipFactory : ISpaceshipFactory
	{
		public IBattleSpaceship CrateBattleSpaceship()
		{
			return new HevyBattleSpaceship();
		}

		public IPeacefulSpaceship CreatePeacefulSpaceship()
		{
			return new HevyPeacefulSpaceship();
		}
	}
	public class HevyBattleSpaceship : IBattleSpaceship
	{
		public void Shoot()
		{
			Console.WriteLine("Spaceship shoots BOOM BOOM");
		}
	}
	public class FastBattleSpaceship : IBattleSpaceship
	{
		public void Shoot()
		{
			Console.WriteLine("Spaceship shoots PEW PEW");
		}
	}
	public class HevyPeacefulSpaceship : IPeacefulSpaceship
	{
		public void Explore()
		{
			Console.WriteLine("I'm slowly exploring");
		}
	}
	public class FastPeacefulSpaceship : IPeacefulSpaceship
	{
		public void Explore()
		{
			Console.WriteLine("I'm quickly exploring");
		}
	}
}
