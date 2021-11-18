using Abstract_Factory;
using Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Flyweight;
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
			//Singleton();
			//Strategy();
			//Flyweight();
		}

		static void Flyweight()
        {
			// Клиентский код обычно создает кучу предварительно заполненных
			// легковесов на этапе инициализации приложения.
			var factory = new FlyweightFactory(
				new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
				new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
				new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
				new Car { Company = "BMW", Model = "M5", Color = "red" },
				new Car { Company = "BMW", Model = "X6", Color = "white" }
			);
			factory.listFlyweights();

			addCarToPoliceDatabase(factory, new Car
			{
				Number = "CL234IR",
				Owner = "James Doe",
				Company = "BMW",
				Model = "M5",
				Color = "red"
			});

			addCarToPoliceDatabase(factory, new Car
			{
				Number = "CL234IR",
				Owner = "James Doe",
				Company = "BMW",
				Model = "X1",
				Color = "red"
			});

			factory.listFlyweights();

			void addCarToPoliceDatabase(FlyweightFactory Factory, Car car)
			{
				Console.WriteLine("\nClient: Adding a car to database.");

				var flyweight = Factory.GetFlyweight(new Car
				{
					Color = car.Color,
					Model = car.Model,
					Company = car.Company
				});

				// Клиентский код либо сохраняет, либо вычисляет внешнее состояние и
				// передает его методам легковеса.
				flyweight.Operation(car);
			}
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
