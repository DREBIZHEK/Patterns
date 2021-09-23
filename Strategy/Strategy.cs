using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Strategy
    {
        public class Context
        {
            private IStrategy _strategy;

            public Context()
            { }

            public Context(IStrategy strategy)
            {
                this._strategy = strategy;
            }

            public void SetStrategy(IStrategy strategy)
            {
                this._strategy = strategy;
            }

            public void DoSomething()
            {
				Console.WriteLine($"We must {_strategy.DoAlgorithm()}");
            }
        }

        public interface IStrategy
        {
            string DoAlgorithm();
        }

        public class ConcreteStrategyA : IStrategy
        {
            public string DoAlgorithm()
            {
                return "fight";
            }
        }

        public class ConcreteStrategyB : IStrategy
        {
            public string DoAlgorithm()
            {
                return "retreat";
            }
        }
    }
}
