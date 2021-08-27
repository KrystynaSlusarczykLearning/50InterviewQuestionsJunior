

using System;

namespace MethodOverridingVsMethodHiding
{
    public class Animal
    {
        public string AsText()
        {
            return $"This is an animal of type: {GetDescription()}";
        }

        public virtual string GetDescription()
        {
            return "generic animal";
        }
    }

    public class Tiger : Animal
    {
        public override string GetDescription()
        {
            return "tiger, the king of Asia";
        }
    }

    public class Lion : Animal
    {
        public new string GetDescription()
        {
            return "lion, the ruler of Africa";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal genericAnimal = new Animal();
            Console.WriteLine($"generic animal: {genericAnimal.AsText()}\n");

            Animal tiger = new Tiger();
            Console.WriteLine($"tiger: {tiger.AsText()}\n");

            Animal lion = new Lion();
            Console.WriteLine($"lion: {lion.AsText()}\n");


            Tiger tiger2 = new Tiger();
            Console.WriteLine($"tiger description: {tiger.GetDescription()}\n");
            Console.WriteLine($"tiger2 description: {tiger2.GetDescription()}\n");

            Lion lion2 = new Lion();
            Console.WriteLine($"lion description: {lion.GetDescription()}\n");
            Console.WriteLine($"lion2 description: {lion2.GetDescription()}\n");

            Circle circle = new Circle(1);
            Circle smartCircle = new SmartCircle(2);
            SmartCircle smartCircle2 = new SmartCircle(3);
            Console.WriteLine(circle.Draw());
            Console.WriteLine(smartCircle.Draw());
            Console.WriteLine(smartCircle2.Draw());

            Console.ReadKey();
        }
    }
}
