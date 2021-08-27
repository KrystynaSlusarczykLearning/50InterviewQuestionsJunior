using System;
using System.Collections.Generic;

namespace Polymorphism
{
    interface IFlyable
    {
        void Fly();
    }

    class Duck : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying by flapping the wings");
        }
    }

    class Plane : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying by jet propulsion");
        }
    }

    class Kite : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying by being carried by the wind");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IFlyable> flyables = new List<IFlyable>
            {
                new Duck(),
                new Plane(),
                new Kite()
            };

            FlyAll(flyables);

            Console.ReadKey();
        }

        private static void FlyAll(List<IFlyable> flyables)
        {
            foreach (var flyable in flyables)
            {
                flyable.Fly();
            }
        }
    }
}
