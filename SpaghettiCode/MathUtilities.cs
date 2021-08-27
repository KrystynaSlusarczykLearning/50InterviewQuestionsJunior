using System;

namespace SpaghettiCode
{
    static class MathUtilities
    {
        public static QuadraticFunctionRoots CalculateQuadraticFunctionRoots(
            double a, double b, double c)
        {
            var delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                var firstRoot = (-b - Math.Sqrt(delta)) / (2 * a);
                var secondRoot = (-b + Math.Sqrt(delta)) / (2 * a);
                return new QuadraticFunctionRoots(firstRoot, secondRoot);
            }
            else if (delta == 0)
            {
                var onlyRoot = -b / (2 * a);
                return new QuadraticFunctionRoots(onlyRoot);
            }
            else
            {
                return new QuadraticFunctionRoots();
            }
        }
    }
}
