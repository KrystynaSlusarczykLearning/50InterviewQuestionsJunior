using System;

namespace LiskovSubstitutionPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var plane = new Plane();
            var toyPlane = new ToyPlane();
            PrintPercentOfRemainingFuel(plane);
            PrintPercentOfRemainingFuel(toyPlane); //this will produce NaN

            Console.ReadKey();
        }

        private static void PrintPercentOfRemainingFuel(Plane plane)
        {
            Console.WriteLine($"\nFuel left: {plane.PercentOfRemainingFuel()}");
        }
    }
}
