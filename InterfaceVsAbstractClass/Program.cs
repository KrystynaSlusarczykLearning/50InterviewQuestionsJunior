using System;

namespace InterfaceVsAbstractClass
{
    interface IFlyable
    {
        void Fly(); //no "public", no method body

        void MethodWithDefaultImplementation()
        {
            Console.WriteLine("this method is implemented in the interface");
        }
    }

    class Bird : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying using fuel of grain and worms.");
        }
    }

    class Drone : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying using energy stored in battery.");
        }
    }

    abstract class Animal
    {
        public abstract void Move();
    }

    abstract class Mammal : Animal //abstract class inheriting from abstract class
    {
        public void ProduceMilk()
        {
            Console.WriteLine("Producing milk to feed its young");
        }
    }

    class Snake : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Slithering on belly");
        }
    }

    class Dog : Mammal
    {
        public override void Move()
        {
            Console.WriteLine("Running using four legs");
        }
    }

    //class Cat : Mammal //does not compile - MUST provide implementation of the Move method
    //{
    //}

    class Program
    {
        static void Main(string[] args)
        {
            //var animal = new Animal(); //can't create an instance of an abstract class
            //var mammal = new Mammal(); //can't create an instance of an abstract class

            var dog = new Dog();
            var snake = new Snake();

            Console.ReadKey();
        }
    }
}
