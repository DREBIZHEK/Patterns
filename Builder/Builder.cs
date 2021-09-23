using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Builder
    {
        public interface IBuilder
        {
            void BuildDefaultCar();

            void BuildLeatherInterior();

            void BuildSportsEquipment();
        }

        public class ConcreteBuilder : IBuilder
        {
            private Product _product = new Product();

            public ConcreteBuilder()
            {
                this.Reset();
            }

            public void Reset()
            {
                this._product = new Product();
            }

            public void BuildDefaultCar()
            {
                this._product.Add("Simple car");
            }

            public void BuildLeatherInterior()
            {
                this._product.Add("Leather Interior");
            }

            public void BuildSportsEquipment()
            {
                this._product.Add("Sports Equipment");
            }

            public Product GetProduct()
            {
                Product result = this._product;

                this.Reset();

                return result;
            }
        }

        public class Product
        {
            private List<object> _parts = new List<object>();

            public void Add(string part)
            {
                this._parts.Add(part);
            }

            public string ListParts()
            {
                string str = string.Empty;

                for (int i = 0; i < this._parts.Count; i++)
                {
                    str += this._parts[i] + ", ";
                }

                str = str.Remove(str.Length - 2);

                return "Product parts: " + str + "\n";
            }
        }

        public class Director
        {
            private IBuilder _builder;

            public IBuilder Builder
            {
                set { _builder = value; }
            }

            public void BuildMinimalViableProduct()
            {
                this._builder.BuildDefaultCar();
            }

            public void BuildFullFeaturedProduct()
            {
                this._builder.BuildDefaultCar();
                this._builder.BuildLeatherInterior();
                this._builder.BuildSportsEquipment();
            }
        }
    }
}
