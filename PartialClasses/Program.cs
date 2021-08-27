using System;

namespace PartialClasses
{
    //the below class is exactly the same as the 
    //class defined in two parts in files
    //DuckPartOne.cs and DuckPartTwo.cs
    //after compilation both parts will be merged together

    //class Duck
    //{
    //    private void Quack()
    //    {
    //        Console.WriteLine("Quack, quack, I'm a duck");
    //    }

    //    public void Fly()
    //    {
    //        Console.WriteLine("Flying high in the sky");
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.ReadKey();
        }
    }
}
