using System.Collections.Generic;

namespace OpenClosedPrinciple
{
    public enum Color { Red, Green, Blue }
    public enum Size { Small, Medium, Large }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }
        // if its needed to filter by color? => copy and paste code for filtering by size
        // if you do this, you break open closed prinicple
        // to extent you implement inheritence
    }

    #region Fix
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }


    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    // to implement size filter  just inherent again
    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }

    //to implement filter by both
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> second, ISpecification<T> first)
        {
            this.second = second;
            this.first = first;
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Blue, Size.Large);
            Product[] products = { apple, tree };

            var bf = new BetterFilter();
            System.Console.WriteLine("Green products: ");
            foreach (var item in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                System.Console.WriteLine($"-  {item.Name} is green");
            }

            System.Console.WriteLine("Large Blue items");
            foreach(var item in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
            {
                System.Console.WriteLine($"-  {item.Name} is blue and large");
            }
        }
    }
}
