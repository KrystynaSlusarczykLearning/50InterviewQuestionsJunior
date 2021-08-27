using System;

namespace LiskovSubstitutionPrinciple
{
    interface IFlyable
    {
        void Fly();
    }

    class Bird : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying using fuel of grain and worms.");
        }

        public void FlapWings()
        {
            Console.WriteLine("Flapping my wings.");
        }
    }

    class Drone : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying using energy stored in battery.");
        }
    }

    class AllFlyer
    {
        static void FlyAll(IFlyable[] flyables)
        {
            foreach (var flyable in flyables)
            {
                if (flyable is Bird bird) //this method should not be aware of specific types implementing the IFlyable interface
                {
                    bird.FlapWings();
                    Console.WriteLine("Special case for a bird.");
                }
                flyable.Fly();
            }
        }
    }
}
