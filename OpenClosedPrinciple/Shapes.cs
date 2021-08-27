using System;

namespace OpenClosedPrinciple
{
    public interface IShape
    {
        double CalculateArea();
    }

    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Triangle : IShape
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }

        public double CalculateArea()
        {
            return Base * Height / 2.0;
        }
    }

    public class Square : IShape
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }

        public double CalculateArea()
        {
            return Side * Side;
        }
    }

    public class AreaCalculator
    {
        public double Calculate(IShape shape)
        {
            return shape.CalculateArea();
        }
    }

    //that breaks Open-Closed principle
    //public class AreaCalculator
    //{
    //    public double Calculate(Circle circle)
    //    {
    //        return Math.PI * circle.Radius * circle.Radius;
    //    }

    //    public double Calculate(Triangle triangle)
    //    {
    //        return triangle.Base * triangle.Height / 2.0;
    //    }

    //    public double Calculate(Square square)
    //    {
    //        return square.Side * square.Side;
    //    }
    //}
}
