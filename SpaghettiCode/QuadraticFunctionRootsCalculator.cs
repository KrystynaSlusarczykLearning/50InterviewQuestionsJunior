using System;

namespace SpaghettiCode
{
    class QuadraticFunctionRootsCalculator : IQuadraticFunctionRootsCalculator
    {
        public void Calculate()
        {
            var isFinished = false;
            while (!isFinished)
            {
                Console.WriteLine("Quadratic Function: y = ax^2 + bx + c");

                double a = ConsoleReader.ReadDouble("a");
                double b = ConsoleReader.ReadDouble("b");
                double c = ConsoleReader.ReadDouble("c");

                var roots = MathUtilities.CalculateQuadraticFunctionRoots(a, b, c);
                if (roots.AreTwo)
                {
                    Console.WriteLine($"Two roots: {roots.FirstRoot}, {roots.SecondRoot}");
                }
                else if (roots.IsOne)
                {
                    Console.WriteLine($"One root: {roots.FirstRoot}");
                }
                else
                {
                    Console.WriteLine("Zero roots.");
                }

                isFinished = ConsoleReader.ReadBool("Run calculation again?");
            }
        }
    }
}
