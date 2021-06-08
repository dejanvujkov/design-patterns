using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            // FACTORY METHOD
            var point1 = Point.NewPolarPoint(1.0, Math.PI / 2);
            System.Console.WriteLine(point1);

            // FACTORY
            var factory = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
            System.Console.WriteLine(factory);

            // INNER FACTORY
            var innerFactory = Point2.InnerFactory.NewPolarPoint(1.0, Math.PI / 2);
            System.Console.WriteLine(innerFactory);

            // ABSTRACT FACTORY
             var machine = new HotDrinkMachine();
             var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 100);
             drink.Consume();
        }
    }
}
