using System;

namespace MultipleInheritance
{
    class WithMultipleInheritance
    {
        public abstract class Animal
        {
            public abstract string MakeSound();
        }

        public class HousePet : Animal
        {
            public override string MakeSound()
            {
                return "<happy noises when human comes back home>";
            }
        }

        public class Feline : Animal
        {
            public override string MakeSound()
            {
                return "Purr purr, I'm a ball of fur";
            }
        }

        //does not compile, we can't derive from two base classes
        //public class DomesticCat : HousePet, Feline 
        //{

        //}
    }


    public interface IAnimal
    {
        string MakeSound();
    }

    public interface IHousePet : IAnimal
    {
    }

    public interface IFeline : IAnimal
    {
    }

    public class HousePet : IHousePet
    {
        public string MakeSound()
        {
            return "<happy noises when human comes back home>";
        }
    }

    public class Feline : IFeline
    {
        public string MakeSound()
        {
            return "Purr purr, I'm a ball of fur";
        }
    }

    public class DomesticCat : IFeline, IHousePet
    {
        public string MakeSound()
        {
            return "Purr purr, I'm a ball of fur, " +
                "but I am not too excited when human comes back home.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //multiple inheritance
            //how can CLR know which method call - the one from Feline or HousePet?
            //var domesticCat = new WithMultipleInheritance.DomesticCat();
            //Console.WriteLine(domesticCat.MakeSound());

            //multiple interfaces implementation

            DomesticCat domesticCat = new DomesticCat();
            Console.WriteLine(domesticCat.MakeSound());

            IAnimal domesticCatAsAnimal = new DomesticCat();
            Console.WriteLine(domesticCatAsAnimal.MakeSound());

            IHousePet domesticCatAsHousePet = new DomesticCat();
            Console.WriteLine(domesticCatAsHousePet.MakeSound());

            IFeline domesticCatAsFeline = new DomesticCat();
            Console.WriteLine(domesticCatAsFeline.MakeSound());

            Console.ReadKey();
        }
    }
}
