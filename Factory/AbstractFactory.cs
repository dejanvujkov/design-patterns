using System;
using System.Collections.Generic;

namespace Factory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            System.Console.WriteLine("This tea is nice!");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            System.Console.WriteLine("Coffee is even better!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            System.Console.WriteLine($"Put tea bag, boil water, putr {amount}ml ");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            System.Console.WriteLine($"Gring some beans, boil water, pour {amount}ml and add cream");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink { Coffee, Tea }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    // here we create dynamic factory by name in enum i.e AvailableDrink.Coffee makes CoffeeFactory, ..
                    //     this is namespace name                                         this is sufix
                    Type.GetType("Factory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory")
                );
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
}