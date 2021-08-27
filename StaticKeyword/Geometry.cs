using static System.Math;

namespace DotNet50JuniorInterviewQuestions
{
    static class Geometry
    {
        public static double SquareArea(double side)
        {
            return Pow(side, 2);
        }

        public static double CircleArea(double radius)
        {
            return PI * Pow(radius, 2);
        }

        public static double EquilateralTriangleArea(double side)
        {
            return (Pow(side, 2) * Sqrt(3)) / 4d;
        }
    }
}
