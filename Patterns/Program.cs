using Abstract_Factory;
using Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Builder.Builder;
using static Strategy.Strategy;

namespace Patterns
{
	class Program
	{
		static void Main(string[] args)
		{
			//Factory();
			//Builder();
			Singleton();
		}

		static void Factory()
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

		static void Builder()
		{
			var director = new Director();
			var builder = new ConcreteBuilder();
			director.Builder = builder;

			Console.WriteLine("Basic configuration:");
			director.BuildMinimalViableProduct();
			Console.WriteLine(builder.GetProduct().ListParts());

			Console.WriteLine("Full configuration:");
			director.BuildFullFeaturedProduct();
			Console.WriteLine(builder.GetProduct().ListParts());

			Console.WriteLine("Custom configuration:");
			builder.BuildDefaultCar();
			builder.BuildSportsEquipment();
			Console.Write(builder.GetProduct().ListParts());
		}

		static void Singleton()
		{
			Singleton.Singleton s1 = global::Singleton.Singleton.GetInstance();
			Singleton.Singleton s2 = global::Singleton.Singleton.GetInstance();

			if (s1 == s2)
			{
				Console.WriteLine("Singleton works, both variables contain the same instance.");
			}
			else
			{
				Console.WriteLine("Singleton failed, variables contain different instances.");
			}
		}

		static void Strategy()
		{
			var context = new Context();
			context.SetStrategy(new ConcreteStrategyA());
			context.DoSomething();
			context.SetStrategy(new ConcreteStrategyB());
			context.DoSomething();
		}
	}
}
